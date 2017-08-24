using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
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
        enum APP_STATE { WAIT, ADD, EDIT, REMOVE };

        String DEFAULT_PATH = @"C:\smart_jump_list\data.dat";
        GROUP_STATE CURRENT_GROUP_STATE;
        APP_STATE CURRENT_APP_STATE;
        Dictionary<String, Dictionary<String, String>> appList;

        void loadAppList()
        {
            if (!File.Exists(DEFAULT_PATH))
            {
                File.Create(DEFAULT_PATH).Dispose();
            }
            using (System.IO.StreamReader r = new System.IO.StreamReader(DEFAULT_PATH))
            {
                string line_data;
                while ((line_data = r.ReadLine()) != null)
                {
                    string[] line = line_data.Split(';');
                    if (line.Length == 3)
                    {
                        // Put group
                        if (!appList.ContainsKey(line[0]))
                        {
                            appList.Add(line[0], new Dictionary<string, string>());
                        }

                       // appList[""].Add(line
                        
                    }
                }
            }
        }

        void saveAppList()
        {

        }

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            CURRENT_GROUP_STATE = GROUP_STATE.WAIT;
            CURRENT_APP_STATE = APP_STATE.WAIT;

            appList = new Dictionary<string, Dictionary<string, string>>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str1 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            string str2 = "Chrome";
            JumpList jl = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, this.Handle);

            JumpListCustomCategory ct1 = new JumpListCustomCategory("Developer Tool");
            // Add aplication
                JumpListLink jll = new JumpListLink(str1, str2);
                jll.IconReference = new IconReference(str1.ToString(), 0);
                ct1.AddJumpListItems(jll);
            jl.AddCustomCategories(ct1);

            jl.Refresh();
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {

        }

    }
}
