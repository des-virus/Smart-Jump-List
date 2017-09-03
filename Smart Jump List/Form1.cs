using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using Smart_Jump_List.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Jump_List {
    public partial class frmMain : Form {
        enum GROUP_STATE { WAIT, ADD, EDIT, REMOVE };
        enum ITEM_STATE { WAIT, ADD, EDIT, REMOVE };

        String DEFAULT_PATH = "D:\\SMART_JUMP_LIST\\";
        GROUP_STATE CURRENT_GROUP_STATE;
        ITEM_STATE CURRENT_ITEM_STATE;
        Dictionary<String, GroupModel> groupMapping;
        //List<GroupModel> groups;

        #region Util functions: read, write, load, change state
        void readDataFromFile() {
            if (!Directory.Exists(DEFAULT_PATH)) {
                System.IO.Directory.CreateDirectory(DEFAULT_PATH);
                return;
            }
            using (System.IO.StreamReader r = new System.IO.StreamReader(DEFAULT_PATH + "\\data.dat")) {
                string line;
                while ((line = r.ReadLine()) != null) {
                    #region Read groups
                    //Format: //GroupID-groupName;groupID-groupName
                    if (line.StartsWith("//")) {
                        line = line.TrimStart('/');
                        string[] line_data = line.Split(';');
                        for (int i = 0; i < line_data.Length; i++) {
                            string[] group_data = line_data[i].Split('-');
                            GroupModel groupModel = new GroupModel {
                                ID = group_data[0],
                                Name = group_data[1],
                                Items = new Dictionary<string, ItemModel>()

                            };
                            //groups.Add(groupModel);
                            groupMapping.Add(group_data[0], groupModel);
                        }
                    }
                    #endregion

                    #region Read items of each group
                    //Format: groupID;itemID;itemName;itemUrl
                    else {
                        string[] line_data = line.Split(';');
                        if (line_data.Length == 4) {
                            string groupID = line_data[0];
                            string itemID = line_data[1];
                            string itemName = line_data[2];
                            string itemUrl = line_data[3];

                            ItemModel item = new ItemModel() {
                                ID = itemID,
                                Name = itemName,
                                Url = itemUrl
                            };
                            groupMapping[groupID].Items.Add(itemID, item);
                        }
                    }
                    #endregion
                }
            }
        }

        void writeDataToFile() {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(DEFAULT_PATH + "\\data.dat");
            List<string> group_keys = new List<string>(groupMapping.Keys);
            int keySize = group_keys.Count;
            string write_line = "//";

            if (keySize > 0) {
                for (var i = 0; i < group_keys.Count - 1; i++) {
                    write_line += group_keys[i] + "-" + groupMapping[group_keys[i]].Name + ";";
                }

                write_line += group_keys[keySize - 1] + "-" + groupMapping[group_keys[keySize - 1]].Name;
                SaveFile.AutoFlush = true;

                SaveFile.WriteLine(write_line);
                foreach (string groupID in group_keys) {

                    GroupModel groupModel = groupMapping[groupID];
                    List<string> item_keys = new List<string>(groupModel.Items.Keys);
                    foreach (string itemID in item_keys) {
                        ItemModel item = groupModel.Items[itemID];
                        write_line = groupID + ";";
                        write_line += item.ID + ";";
                        write_line += item.Name + ";";
                        write_line += item.Url;
                        SaveFile.WriteLine(write_line);
                    }
                }
            }

            SaveFile.Close();
        }

        void loadGroupDataToDataGridView() {
            dgvGroup.Rows.Clear();
            #region Load group item to data gridview
            List<GroupModel> groups = new List<GroupModel>(groupMapping.Values);
            foreach (var group in groups) {
                var index = dgvGroup.Rows.Add();
                dgvGroup.Rows[index].Cells["order"].Value = index + 1;
                dgvGroup.Rows[index].Cells["code"].Value = group.ID;
                dgvGroup.Rows[index].Cells["name"].Value = group.Name;
            }
            #endregion
        }

        void loadAppDataToDataGridView(string groupCode)
        {
            dgvApp.Rows.Clear();

            GroupModel groupModel = groupMapping[groupCode];
            List<string> item_ids = new List<string>(groupModel.Items.Keys);
            for (int i = 0; i < item_ids.Count; i++) {
                var index = dgvApp.Rows.Add();
                dgvApp.Rows[index].Cells["orderApp"].Value = index + 1;
                dgvApp.Rows[index].Cells["codeApp"].Value = groupModel.Items[item_ids[i]].ID;
                dgvApp.Rows[index].Cells["nameApp"].Value = groupModel.Items[item_ids[i]].Name;
                dgvApp.Rows[index].Cells["pathApp"].Value = groupModel.Items[item_ids[i]].Url;
            }

            txtGroupName.Text = groupModel.Name;
        }

        void refreshJumlist()
        {
            JumpList jumpList = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, this.Handle);

            List<GroupModel> groups = new List<GroupModel>(groupMapping.Values);
            foreach (var group in groups)
            {
                string groupName = group.Name;
                JumpListCustomCategory category = new JumpListCustomCategory(groupName);

                List<ItemModel> items = new List<ItemModel>(group.Items.Values);
                foreach (var item in items)
                {
                    string itemName = item.Name;
                    string itemPath = item.Url;

                    JumpListLink jll = new JumpListLink(itemPath, itemName);
                    jll.IconReference = new IconReference(itemPath.ToString(), 0);
                    category.AddJumpListItems(jll);
                }
                jumpList.AddCustomCategories(category);
            }

            jumpList.Refresh();
        }

        void changeGroupState() {
            switch (CURRENT_GROUP_STATE) {
                case GROUP_STATE.ADD:
                    txtGroupName.Text = "";
                    txtGroupName.Enabled = true;
                  
                    btnGroupAdd.Enabled = false;
                    btnGroupDelete.Enabled = false;
                    btnGroupEdit.Enabled = false;
                    btnGroupOk.Enabled = true;
                    btnGroupCancel.Enabled = true;
                    break;
                case GROUP_STATE.EDIT:
                    txtGroupName.Enabled = true;
                    btnGroupAdd.Enabled = false;
                    btnGroupDelete.Enabled = false;
                    btnGroupEdit.Enabled = false;
                    btnGroupOk.Enabled = true;
                    btnGroupCancel.Enabled = true;
                    break;
                case GROUP_STATE.REMOVE:
                    txtGroupName.Enabled = false;
                    btnGroupAdd.Enabled = false;
                    btnGroupDelete.Enabled = false;
                    btnGroupEdit.Enabled = false;
                    btnGroupOk.Enabled = true;
                    btnGroupCancel.Enabled = true;
                    break;
                case GROUP_STATE.WAIT:
                    txtGroupName.Enabled = false;
                    btnGroupAdd.Enabled = true;
                    btnGroupDelete.Enabled = true;
                    btnGroupEdit.Enabled = true;
                    btnGroupOk.Enabled = false;
                    btnGroupCancel.Enabled = false;
                    break;
            }
        }

        void changeAppState() {
            switch (CURRENT_ITEM_STATE) {
                case ITEM_STATE.ADD:
                    txtAppName.Text = "";
                    txtAppPath.Text = "";
                    btnAppPathChoose.Enabled = true;
                    txtAppName.Enabled = true;
                    txtAppPath.Enabled = true;
                    btnAppAdd.Enabled = false;
                    btnAppDelete.Enabled = false;
                    btnAppEdit.Enabled = false;
                    btnAppOk.Enabled = true;
                    btnAppCancel.Enabled = true;
                    break;
                case ITEM_STATE.EDIT:
                    txtAppName.Enabled = true;
                    txtAppPath.Enabled = true;
                    btnAppPathChoose.Enabled = true;
                    btnAppAdd.Enabled = false;
                    btnAppDelete.Enabled = false;
                    btnAppEdit.Enabled = false;
                    btnAppOk.Enabled = true;
                    btnAppCancel.Enabled = true;
                    break;
                case ITEM_STATE.REMOVE:
                    txtAppName.Enabled = false;
                    btnAppAdd.Enabled = false;
                    btnAppPathChoose.Enabled = true;
                    btnAppDelete.Enabled = false;
                    btnAppEdit.Enabled = false;
                    btnAppOk.Enabled = true;
                    btnAppCancel.Enabled = true;
                    break;
                case ITEM_STATE.WAIT:
                    txtAppName.Enabled = false;
                    txtAppPath.Enabled = false;
                    btnAppPathChoose.Enabled = false;
                    btnAppAdd.Enabled = true;
                    btnAppDelete.Enabled = true;
                    btnAppEdit.Enabled = true;
                    btnAppOk.Enabled = false;
                    btnAppCancel.Enabled = false;
                    break;
            }
        }
        #endregion


        public frmMain() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            CURRENT_ITEM_STATE = ITEM_STATE.WAIT;

            groupMapping = new Dictionary<string, GroupModel>();
           // groups = new List<GroupModel>();


        }

        private void Form1_Load(object sender, EventArgs e) {
            readDataFromFile();
            loadGroupDataToDataGridView();
            changeGroupState();
            changeAppState();
        }

        string getUnixTime() {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp.ToString();
        }

        private void btnGroupAdd_Click(object sender, EventArgs e) {
            CURRENT_GROUP_STATE = GROUP_STATE.ADD;
            changeGroupState();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            writeDataToFile();
        }

        private void btnAppAdd_Click(object sender, EventArgs e) {
            CURRENT_ITEM_STATE = ITEM_STATE.ADD;
            changeAppState();
        }


        private void dgvGroup_CellClick(object sender, DataGridViewCellEventArgs e) {

            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            changeGroupState();
            int selectedGroupIndex = dgvGroup.SelectedCells[0].RowIndex;
            if (selectedGroupIndex < 0) {
                return;
            }
           
            string groupCode = dgvGroup.Rows[selectedGroupIndex].Cells["code"].Value.ToString();
            loadAppDataToDataGridView(groupCode);
        }

        private void btnAppPathChoose_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                txtAppPath.Text = dialog.FileName;
            }
        }

        private void btnGroupOk_Click(object sender, EventArgs e) {
            string ID = getUnixTime();
            string name = txtGroupName.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên không được rỗng");
                return;
            }

            switch (CURRENT_GROUP_STATE) {
                case GROUP_STATE.ADD:
                    // Add to dictionary
                    GroupModel group = new GroupModel {
                        ID = ID,
                        Name = name,
                        Items = new Dictionary<string, ItemModel>()
                    };
                    groupMapping.Add(ID, group);
                    loadGroupDataToDataGridView();
                    break;
                case GROUP_STATE.EDIT:
                    string selectedGroupID = dgvGroup.SelectedRows[0].Cells["code"].Value.ToString();
                    groupMapping[selectedGroupID].Name = name;
                    loadGroupDataToDataGridView();

                    break;
            }

            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            changeGroupState();
        }

        private void btnGroupEdit_Click(object sender, EventArgs e) {
            CURRENT_GROUP_STATE = GROUP_STATE.EDIT;
            changeGroupState();
        }

        private void btnGroupCancel_Click(object sender, EventArgs e) {
            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            changeGroupState();
        }

        private void btnAppEdit_Click(object sender, EventArgs e) {
            CURRENT_ITEM_STATE =  ITEM_STATE.EDIT;
            changeAppState();
        }

        private void btnAppOk_Click(object sender, EventArgs e) {
            string ID = getUnixTime();
            string name = txtAppName.Text;
            string path = txtAppPath.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path)) {
                MessageBox.Show("Tên hoặc đường dẫn không được rỗng");
                return;
            }
            string selectedGroupID = dgvGroup.SelectedRows[0].Cells["code"].Value.ToString();
            GroupModel currentGroup = groupMapping[selectedGroupID];
            if (currentGroup != null)
            {
                switch (CURRENT_ITEM_STATE)
                {
                    case ITEM_STATE.ADD:
                        currentGroup.Items.Add(ID, new ItemModel()
                        {
                            ID =  ID,
                            Name = name,
                            Url = path
                        });
                        loadAppDataToDataGridView(currentGroup.ID);
                        break;
                    case ITEM_STATE.EDIT:


                        break;
                }
                CURRENT_ITEM_STATE = ITEM_STATE.WAIT;
                changeAppState();
            }
            else
            {
                MessageBox.Show("Chưa chọn nhóm");
            }
            
            
        }

        private void btnAppCancel_Click(object sender, EventArgs e) {
            CURRENT_ITEM_STATE = ITEM_STATE.WAIT;
            changeAppState();
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = dgvGroup.SelectedRows[0].Index;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Chọn nhóm cần xóa trước", "Chưa chọn nhóm", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }
            string groupID = dgvGroup.Rows[selectedIndex].Cells["code"].Value.ToString();
            string groupName = dgvGroup.Rows[selectedIndex].Cells["name"].Value.ToString();
            if (MessageBox.Show("Tất các đường dẫn ứng dụng đi kèm trong nhóm " + groupName + " sẽ bị xóa theo.\n Bạn có thực sự muốn xóa ?" , "Cảnh báo xóa nhóm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (groupMapping.Remove(groupID))
                {
                    MessageBox.Show("Xóa thành công.");
                }
                else
                {
                    MessageBox.Show("Đã xảy ra lỗi!");
                }
                loadGroupDataToDataGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            refreshJumlist();
        }
    }
}
