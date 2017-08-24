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
            //System.IO.Directory.CreateDirectory(DEFAULT_PATH);
            using (System.IO.StreamReader r = File.AppendText(DEFAULT_PATH))
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

            List<string> group_keys = new List<string>(group_dictionary.Keys);
            var groups = "//" + String.Join(";", group_keys.ToArray());
            SaveFile.WriteLine(groups);
            foreach (string groupID in group_keys)
            {
                string write_line;
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

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
