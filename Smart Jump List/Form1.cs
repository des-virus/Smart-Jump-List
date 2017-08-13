using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Jump_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str1 = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            string str2 = "Chrome";
            JumpList jl = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, this.Handle);

            JumpListCustomCategory ct1 = new JumpListCustomCategory("Developer Tool");
            // Add aplication
                JumpListLink jll = new JumpListLink(str1, str2.ToString());
                jll.IconReference = new IconReference(str1.ToString(), 0);
                ct1.AddJumpListItems(jll);
            jl.AddCustomCategories(ct1);

            jl.Refresh();
        }
    }
}
