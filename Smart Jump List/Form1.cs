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

namespace Smart_Jump_List
{
    public partial class Form1 : Form
    {
        enum GROUP_STATE { WAIT, ADD, EDIT, REMOVE };
        enum ITEM_STATE { WAIT, ADD, EDIT, REMOVE };

        String DEFAULT_PATH = "D:\\SMART_JUMP_LIST\\data.dat";
        GROUP_STATE CURRENT_GROUP_STATE;
        ITEM_STATE CURRENT_APP_STATE;
        Dictionary<String, GroupModel> group_dictionary;
        List<GroupModel> groups;

        void loadData()
        {
            if (!File.Exists(DEFAULT_PATH))
            {
                File.Create(DEFAULT_PATH).Dispose();
                return;
            }
            using (System.IO.StreamReader r = new System.IO.StreamReader(DEFAULT_PATH))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] line_data = line.Split(';');
                    if (line.StartsWith("//"))
                    {
                        for (int i = 0; i < line_data.Length; i++)
                        {
                            string[] group_data = line_data[i].Split('-');
                            GroupModel group = new GroupModel
                            {
                                ID = group_data[0],
                                Name = group_data[1],
                                Items = new Dictionary<string, ItemModel>()

                            };
                            groups.Add(group);
                            group_dictionary.Add(group_data[0], group);
                        }
                    }
                    else
                    {
                        if (line_data.Length == 4)
                        {
                            string groupID = line_data[0];
                            string itemID = line_data[1];
                            string itemName = line_data[2];
                            string itemUrl = line_data[3];

                            ItemModel item = new ItemModel()
                            {
                                ID = itemID,
                                Name = itemName,
                                Url = itemUrl
                            };
                            group_dictionary[groupID].Items.Add(itemID, item);
                        }
                    }

                    
                    
                }
            }
        }

        void saveData()
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(DEFAULT_PATH);
            int b = 4;
            List<string> group_keys = new List<string>(group_dictionary.Keys);
            int keySize = group_keys.Count;
            string write_line = "//";

            for (var i = 0; i < group_keys.Count - 1; i++) {
                write_line += group_keys[i] + "-" + group_dictionary[group_keys[i]].Name + ";";
            }

            write_line += group_keys[keySize - 1] + "-" + group_dictionary[group_keys[keySize - 1]].Name;

            SaveFile.AutoFlush = true;
            
            SaveFile.WriteLine(write_line);
            foreach (string groupID in group_keys)
            {
                
                GroupModel groupModel= group_dictionary[groupID];
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

            SaveFile.Close();
        }

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            CURRENT_APP_STATE = ITEM_STATE.WAIT;

            group_dictionary = new Dictionary<string, GroupModel>();

            //appList = new Dictionary<string, Dictionary<string, string>>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string str1 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            //string str2 = "Chrome";
            //JumpList jl = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, this.Handle);

            //JumpListCustomCategory ct1 = new JumpListCustomCategory("Developer Tool");
            //// Add aplication
            //    JumpListLink jll = new JumpListLink(str1, str2);
            //    jll.IconReference = new IconReference(str1.ToString(), 0);
            //    ct1.AddJumpListItems(jll);
            //jl.AddCustomCategories(ct1);

            //jl.Refresh();

            loadData();
        }

        string  getUnixTime() {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp.ToString();
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            string ID = getUnixTime();
            string name = txtGroupName.Text;

            // Add to dictionary
            GroupModel group = new GroupModel
            {
                ID = ID,
                Name = name,
                Items = new Dictionary<string, ItemModel>()
            };
            group_dictionary.Add(ID, group);

            // Add to dgv
            var index = dgvGroup.Rows.Add();
            dgvGroup.Rows[index].Cells[0].Value = ID;
            dgvGroup.Rows[index].Cells[1].Value = name;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveData();
        }
    }
}
