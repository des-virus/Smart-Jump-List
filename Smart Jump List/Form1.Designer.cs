namespace Smart_Jump_List
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAppCancel = new System.Windows.Forms.Button();
            this.btnAppOk = new System.Windows.Forms.Button();
            this.btnAppEdit = new System.Windows.Forms.Button();
            this.btnAppDelete = new System.Windows.Forms.Button();
            this.btnAppAdd = new System.Windows.Forms.Button();
            this.btnAppPathChoose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppPath = new System.Windows.Forms.TextBox();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.dgvApp = new System.Windows.Forms.DataGridView();
            this.orderApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGroupCancel = new System.Windows.Forms.Button();
            this.btnGroupOk = new System.Windows.Forms.Button();
            this.btnGroupEdit = new System.Windows.Forms.Button();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.btnGroupAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1338, 126);
            this.label3.TabIndex = 2;
            this.label3.Text = "SMART JUMP LIST";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAppCancel);
            this.groupBox1.Controls.Add(this.btnAppOk);
            this.groupBox1.Controls.Add(this.btnAppEdit);
            this.groupBox1.Controls.Add(this.btnAppDelete);
            this.groupBox1.Controls.Add(this.btnAppAdd);
            this.groupBox1.Controls.Add(this.btnAppPathChoose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAppPath);
            this.groupBox1.Controls.Add(this.txtAppName);
            this.groupBox1.Controls.Add(this.dgvApp);
            this.groupBox1.Location = new System.Drawing.Point(588, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 536);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ứng dụng";
            // 
            // btnAppCancel
            // 
            this.btnAppCancel.Location = new System.Drawing.Point(417, 128);
            this.btnAppCancel.Name = "btnAppCancel";
            this.btnAppCancel.Size = new System.Drawing.Size(80, 30);
            this.btnAppCancel.TabIndex = 14;
            this.btnAppCancel.Text = "Hủy";
            this.btnAppCancel.UseVisualStyleBackColor = true;
            this.btnAppCancel.Click += new System.EventHandler(this.btnAppCancel_Click);
            // 
            // btnAppOk
            // 
            this.btnAppOk.Location = new System.Drawing.Point(331, 127);
            this.btnAppOk.Name = "btnAppOk";
            this.btnAppOk.Size = new System.Drawing.Size(80, 30);
            this.btnAppOk.TabIndex = 14;
            this.btnAppOk.Text = "Ok";
            this.btnAppOk.UseVisualStyleBackColor = true;
            this.btnAppOk.Click += new System.EventHandler(this.btnAppOk_Click);
            // 
            // btnAppEdit
            // 
            this.btnAppEdit.Location = new System.Drawing.Point(156, 128);
            this.btnAppEdit.Name = "btnAppEdit";
            this.btnAppEdit.Size = new System.Drawing.Size(80, 30);
            this.btnAppEdit.TabIndex = 10;
            this.btnAppEdit.Text = "Sửa";
            this.btnAppEdit.UseVisualStyleBackColor = true;
            this.btnAppEdit.Click += new System.EventHandler(this.btnAppEdit_Click);
            // 
            // btnAppDelete
            // 
            this.btnAppDelete.Location = new System.Drawing.Point(242, 127);
            this.btnAppDelete.Name = "btnAppDelete";
            this.btnAppDelete.Size = new System.Drawing.Size(80, 30);
            this.btnAppDelete.TabIndex = 11;
            this.btnAppDelete.Text = "Xóa";
            this.btnAppDelete.UseVisualStyleBackColor = true;
            // 
            // btnAppAdd
            // 
            this.btnAppAdd.Location = new System.Drawing.Point(70, 128);
            this.btnAppAdd.Name = "btnAppAdd";
            this.btnAppAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAppAdd.TabIndex = 12;
            this.btnAppAdd.Text = "Thêm";
            this.btnAppAdd.UseVisualStyleBackColor = true;
            this.btnAppAdd.Click += new System.EventHandler(this.btnAppAdd_Click);
            // 
            // btnAppPathChoose
            // 
            this.btnAppPathChoose.Location = new System.Drawing.Point(361, 79);
            this.btnAppPathChoose.Name = "btnAppPathChoose";
            this.btnAppPathChoose.Size = new System.Drawing.Size(64, 30);
            this.btnAppPathChoose.TabIndex = 13;
            this.btnAppPathChoose.Text = "Chọn";
            this.btnAppPathChoose.UseVisualStyleBackColor = true;
            this.btnAppPathChoose.Click += new System.EventHandler(this.btnAppPathChoose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Đường dẫn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tên ứng dụng";
            // 
            // txtAppPath
            // 
            this.txtAppPath.Location = new System.Drawing.Point(125, 81);
            this.txtAppPath.Name = "txtAppPath";
            this.txtAppPath.Size = new System.Drawing.Size(215, 26);
            this.txtAppPath.TabIndex = 6;
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(125, 36);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(215, 26);
            this.txtAppName.TabIndex = 7;
            // 
            // dgvApp
            // 
            this.dgvApp.AllowUserToAddRows = false;
            this.dgvApp.AllowUserToDeleteRows = false;
            this.dgvApp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderApp,
            this.codeApp,
            this.nameApp,
            this.pathApp});
            this.dgvApp.Location = new System.Drawing.Point(6, 171);
            this.dgvApp.Name = "dgvApp";
            this.dgvApp.ReadOnly = true;
            this.dgvApp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApp.Size = new System.Drawing.Size(714, 359);
            this.dgvApp.TabIndex = 5;
            // 
            // orderApp
            // 
            this.orderApp.HeaderText = "STT";
            this.orderApp.Name = "orderApp";
            this.orderApp.ReadOnly = true;
            // 
            // codeApp
            // 
            this.codeApp.HeaderText = "Mã ứng dụng";
            this.codeApp.Name = "codeApp";
            this.codeApp.ReadOnly = true;
            // 
            // nameApp
            // 
            this.nameApp.FillWeight = 300F;
            this.nameApp.HeaderText = "Tên ứng dụng";
            this.nameApp.Name = "nameApp";
            this.nameApp.ReadOnly = true;
            this.nameApp.Width = 200;
            // 
            // pathApp
            // 
            this.pathApp.HeaderText = "Đường dẫn";
            this.pathApp.Name = "pathApp";
            this.pathApp.ReadOnly = true;
            this.pathApp.Width = 356;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGroupCancel);
            this.groupBox2.Controls.Add(this.btnGroupOk);
            this.groupBox2.Controls.Add(this.btnGroupEdit);
            this.groupBox2.Controls.Add(this.btnGroupDelete);
            this.groupBox2.Controls.Add(this.btnGroupAdd);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtGroupName);
            this.groupBox2.Controls.Add(this.dgvGroup);
            this.groupBox2.Location = new System.Drawing.Point(9, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(573, 536);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhóm";
            // 
            // btnGroupCancel
            // 
            this.btnGroupCancel.Location = new System.Drawing.Point(421, 102);
            this.btnGroupCancel.Name = "btnGroupCancel";
            this.btnGroupCancel.Size = new System.Drawing.Size(80, 30);
            this.btnGroupCancel.TabIndex = 11;
            this.btnGroupCancel.Text = "Hủy";
            this.btnGroupCancel.UseVisualStyleBackColor = true;
            this.btnGroupCancel.Click += new System.EventHandler(this.btnGroupCancel_Click);
            // 
            // btnGroupOk
            // 
            this.btnGroupOk.Location = new System.Drawing.Point(335, 102);
            this.btnGroupOk.Name = "btnGroupOk";
            this.btnGroupOk.Size = new System.Drawing.Size(80, 30);
            this.btnGroupOk.TabIndex = 11;
            this.btnGroupOk.Text = "Ok";
            this.btnGroupOk.UseVisualStyleBackColor = true;
            this.btnGroupOk.Click += new System.EventHandler(this.btnGroupOk_Click);
            // 
            // btnGroupEdit
            // 
            this.btnGroupEdit.Location = new System.Drawing.Point(160, 103);
            this.btnGroupEdit.Name = "btnGroupEdit";
            this.btnGroupEdit.Size = new System.Drawing.Size(80, 30);
            this.btnGroupEdit.TabIndex = 8;
            this.btnGroupEdit.Text = "Sửa";
            this.btnGroupEdit.UseVisualStyleBackColor = true;
            this.btnGroupEdit.Click += new System.EventHandler(this.btnGroupEdit_Click);
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Location = new System.Drawing.Point(249, 103);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(80, 30);
            this.btnGroupDelete.TabIndex = 9;
            this.btnGroupDelete.Text = "Xóa";
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.Location = new System.Drawing.Point(74, 103);
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(80, 30);
            this.btnGroupAdd.TabIndex = 10;
            this.btnGroupAdd.Text = "Thêm";
            this.btnGroupAdd.UseVisualStyleBackColor = true;
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên nhóm";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(99, 42);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(402, 26);
            this.txtGroupName.TabIndex = 6;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.code,
            this.name});
            this.dgvGroup.Location = new System.Drawing.Point(6, 149);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(561, 381);
            this.dgvGroup.TabIndex = 5;
            this.dgvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellClick);
            // 
            // order
            // 
            this.order.HeaderText = "STT";
            this.order.Name = "order";
            this.order.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "Mã nhóm";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Tên nhóm";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(843, 112);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(125, 39);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Test thử";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1337, 731);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmMain";
            this.Text = "Smart Jump List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAppOk;
        private System.Windows.Forms.Button btnAppEdit;
        private System.Windows.Forms.Button btnAppDelete;
        private System.Windows.Forms.Button btnAppAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppPath;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.DataGridView dgvApp;
        private System.Windows.Forms.Button btnGroupOk;
        private System.Windows.Forms.Button btnGroupEdit;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.Button btnGroupAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.Button btnAppPathChoose;
        private System.Windows.Forms.Button btnGroupCancel;
        private System.Windows.Forms.Button btnAppCancel;
        private System.Windows.Forms.Button btnTest;
    }
}

