namespace LFAutomationUI.LFUI
{
    partial class AllUsersInfoForm
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
            this.splitContainerUser = new System.Windows.Forms.SplitContainer();
            this.splitContainerUserInfo = new System.Windows.Forms.SplitContainer();
            this.lvUserInfo = new System.Windows.Forms.ListView();
            this.columnHeaderUserId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderClassID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastModifiedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblRoleInfo = new System.Windows.Forms.Label();
            this.ckListBoxUserRoleInfo = new System.Windows.Forms.CheckedListBox();
            this.splitContainerEditUser = new System.Windows.Forms.SplitContainer();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lblLastModifiedDate = new System.Windows.Forms.Label();
            this.lbl_LastModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.cmbClassId = new System.Windows.Forms.ComboBox();
            this.lbl_ClassId = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.lbl_UserId = new System.Windows.Forms.Label();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.splitContainerUser.Panel1.SuspendLayout();
            this.splitContainerUser.Panel2.SuspendLayout();
            this.splitContainerUser.SuspendLayout();
            this.splitContainerUserInfo.Panel1.SuspendLayout();
            this.splitContainerUserInfo.Panel2.SuspendLayout();
            this.splitContainerUserInfo.SuspendLayout();
            this.splitContainerEditUser.Panel1.SuspendLayout();
            this.splitContainerEditUser.Panel2.SuspendLayout();
            this.splitContainerEditUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerUser
            // 
            this.splitContainerUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUser.IsSplitterFixed = true;
            this.splitContainerUser.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUser.Name = "splitContainerUser";
            this.splitContainerUser.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerUser.Panel1
            // 
            this.splitContainerUser.Panel1.Controls.Add(this.splitContainerUserInfo);
            // 
            // splitContainerUser.Panel2
            // 
            this.splitContainerUser.Panel2.Controls.Add(this.splitContainerEditUser);
            this.splitContainerUser.Size = new System.Drawing.Size(659, 477);
            this.splitContainerUser.SplitterDistance = 335;
            this.splitContainerUser.SplitterWidth = 5;
            this.splitContainerUser.TabIndex = 0;
            // 
            // splitContainerUserInfo
            // 
            this.splitContainerUserInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUserInfo.IsSplitterFixed = true;
            this.splitContainerUserInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUserInfo.Name = "splitContainerUserInfo";
            // 
            // splitContainerUserInfo.Panel1
            // 
            this.splitContainerUserInfo.Panel1.Controls.Add(this.lvUserInfo);
            // 
            // splitContainerUserInfo.Panel2
            // 
            this.splitContainerUserInfo.Panel2.Controls.Add(this.lblRoleInfo);
            this.splitContainerUserInfo.Panel2.Controls.Add(this.ckListBoxUserRoleInfo);
            this.splitContainerUserInfo.Size = new System.Drawing.Size(659, 335);
            this.splitContainerUserInfo.SplitterDistance = 438;
            this.splitContainerUserInfo.SplitterWidth = 5;
            this.splitContainerUserInfo.TabIndex = 0;
            // 
            // lvUserInfo
            // 
            this.lvUserInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderUserId,
            this.columnHeaderUserName,
            this.columnHeaderClassID,
            this.columnHeaderCreatedDate,
            this.columnHeaderLastModifiedDate});
            this.lvUserInfo.FullRowSelect = true;
            this.lvUserInfo.GridLines = true;
            this.lvUserInfo.Location = new System.Drawing.Point(3, 7);
            this.lvUserInfo.MultiSelect = false;
            this.lvUserInfo.Name = "lvUserInfo";
            this.lvUserInfo.Size = new System.Drawing.Size(426, 321);
            this.lvUserInfo.TabIndex = 0;
            this.lvUserInfo.UseCompatibleStateImageBehavior = false;
            this.lvUserInfo.View = System.Windows.Forms.View.Details;
            this.lvUserInfo.SelectedIndexChanged += new System.EventHandler(this.lvUserInfo_SelectedIndexChanged);
            // 
            // columnHeaderUserId
            // 
            this.columnHeaderUserId.Text = "用户编号";
            this.columnHeaderUserId.Width = 68;
            // 
            // columnHeaderUserName
            // 
            this.columnHeaderUserName.Text = "用户名称";
            this.columnHeaderUserName.Width = 75;
            // 
            // columnHeaderClassID
            // 
            this.columnHeaderClassID.Text = "班组";
            this.columnHeaderClassID.Width = 49;
            // 
            // columnHeaderCreatedDate
            // 
            this.columnHeaderCreatedDate.Text = "创建日期";
            this.columnHeaderCreatedDate.Width = 96;
            // 
            // columnHeaderLastModifiedDate
            // 
            this.columnHeaderLastModifiedDate.Text = "最后修改日期";
            this.columnHeaderLastModifiedDate.Width = 120;
            // 
            // lblRoleInfo
            // 
            this.lblRoleInfo.AutoSize = true;
            this.lblRoleInfo.Location = new System.Drawing.Point(6, 11);
            this.lblRoleInfo.Name = "lblRoleInfo";
            this.lblRoleInfo.Size = new System.Drawing.Size(105, 14);
            this.lblRoleInfo.TabIndex = 1;
            this.lblRoleInfo.Text = "拥有的角色信息";
            // 
            // ckListBoxUserRoleInfo
            // 
            this.ckListBoxUserRoleInfo.CheckOnClick = true;
            this.ckListBoxUserRoleInfo.FormattingEnabled = true;
            this.ckListBoxUserRoleInfo.Location = new System.Drawing.Point(6, 32);
            this.ckListBoxUserRoleInfo.Name = "ckListBoxUserRoleInfo";
            this.ckListBoxUserRoleInfo.Size = new System.Drawing.Size(203, 292);
            this.ckListBoxUserRoleInfo.TabIndex = 0;
            this.ckListBoxUserRoleInfo.SelectedIndexChanged += new System.EventHandler(this.ckListBoxUserRoleInfo_SelectedIndexChanged);
            // 
            // splitContainerEditUser
            // 
            this.splitContainerEditUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerEditUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerEditUser.IsSplitterFixed = true;
            this.splitContainerEditUser.Location = new System.Drawing.Point(0, 0);
            this.splitContainerEditUser.Name = "splitContainerEditUser";
            this.splitContainerEditUser.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEditUser.Panel1
            // 
            this.splitContainerEditUser.Panel1.Controls.Add(this.btnResetPassword);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lblLastModifiedDate);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lbl_LastModifiedDate);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lblCreatedDate);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lbl_CreatedDate);
            this.splitContainerEditUser.Panel1.Controls.Add(this.cmbClassId);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lbl_ClassId);
            this.splitContainerEditUser.Panel1.Controls.Add(this.txtUserName);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lbl_UserName);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lblUserId);
            this.splitContainerEditUser.Panel1.Controls.Add(this.lbl_UserId);
            // 
            // splitContainerEditUser.Panel2
            // 
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnCloseWindow);
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnOK);
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnDeleteUser);
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnEditUser);
            this.splitContainerEditUser.Panel2.Controls.Add(this.btnNewUser);
            this.splitContainerEditUser.Size = new System.Drawing.Size(659, 137);
            this.splitContainerEditUser.SplitterDistance = 74;
            this.splitContainerEditUser.SplitterWidth = 5;
            this.splitContainerEditUser.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Enabled = false;
            this.btnResetPassword.Location = new System.Drawing.Point(485, 37);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(160, 28);
            this.btnResetPassword.TabIndex = 12;
            this.btnResetPassword.Text = "恢复默认密码[123456]";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // lblLastModifiedDate
            // 
            this.lblLastModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastModifiedDate.Location = new System.Drawing.Point(286, 41);
            this.lblLastModifiedDate.Name = "lblLastModifiedDate";
            this.lblLastModifiedDate.Size = new System.Drawing.Size(193, 24);
            this.lblLastModifiedDate.TabIndex = 11;
            this.lblLastModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LastModifiedDate
            // 
            this.lbl_LastModifiedDate.AutoSize = true;
            this.lbl_LastModifiedDate.Location = new System.Drawing.Point(189, 46);
            this.lbl_LastModifiedDate.Name = "lbl_LastModifiedDate";
            this.lbl_LastModifiedDate.Size = new System.Drawing.Size(91, 14);
            this.lbl_LastModifiedDate.TabIndex = 10;
            this.lbl_LastModifiedDate.Text = "最后修改时间";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedDate.Location = new System.Drawing.Point(452, 5);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(193, 24);
            this.lblCreatedDate.TabIndex = 9;
            this.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Location = new System.Drawing.Point(383, 10);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(63, 14);
            this.lbl_CreatedDate.TabIndex = 8;
            this.lbl_CreatedDate.Text = "创建时间";
            // 
            // cmbClassId
            // 
            this.cmbClassId.Enabled = false;
            this.cmbClassId.FormattingEnabled = true;
            this.cmbClassId.Location = new System.Drawing.Point(258, 7);
            this.cmbClassId.Name = "cmbClassId";
            this.cmbClassId.Size = new System.Drawing.Size(102, 22);
            this.cmbClassId.TabIndex = 7;
            // 
            // lbl_ClassId
            // 
            this.lbl_ClassId.AutoSize = true;
            this.lbl_ClassId.Location = new System.Drawing.Point(189, 10);
            this.lbl_ClassId.Name = "lbl_ClassId";
            this.lbl_ClassId.Size = new System.Drawing.Size(63, 14);
            this.lbl_ClassId.TabIndex = 6;
            this.lbl_ClassId.Text = "所在班组";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(80, 43);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(103, 23);
            this.txtUserName.TabIndex = 3;
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(11, 46);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(63, 14);
            this.lbl_UserName.TabIndex = 2;
            this.lbl_UserName.Text = "用户名称";
            // 
            // lblUserId
            // 
            this.lblUserId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserId.Location = new System.Drawing.Point(80, 5);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(103, 24);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_UserId
            // 
            this.lbl_UserId.AutoSize = true;
            this.lbl_UserId.Location = new System.Drawing.Point(11, 10);
            this.lbl_UserId.Name = "lbl_UserId";
            this.lbl_UserId.Size = new System.Drawing.Size(63, 14);
            this.lbl_UserId.TabIndex = 0;
            this.lbl_UserId.Text = "用户编号";
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseWindow.Location = new System.Drawing.Point(572, 7);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(73, 40);
            this.btnCloseWindow.TabIndex = 5;
            this.btnCloseWindow.Text = "关闭窗口";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(407, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(73, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(328, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(73, 40);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Enabled = false;
            this.btnDeleteUser.Location = new System.Drawing.Point(168, 7);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(73, 40);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "删除";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(89, 7);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(73, 40);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "修改";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(10, 7);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(73, 40);
            this.btnNewUser.TabIndex = 0;
            this.btnNewUser.Text = "新增";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // AllUsersInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseWindow;
            this.ClientSize = new System.Drawing.Size(659, 477);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerUser);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllUsersInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "所有用户信息";
            this.Load += new System.EventHandler(this.AllUsersInfoForm_Load);
            this.splitContainerUser.Panel1.ResumeLayout(false);
            this.splitContainerUser.Panel2.ResumeLayout(false);
            this.splitContainerUser.ResumeLayout(false);
            this.splitContainerUserInfo.Panel1.ResumeLayout(false);
            this.splitContainerUserInfo.Panel2.ResumeLayout(false);
            this.splitContainerUserInfo.Panel2.PerformLayout();
            this.splitContainerUserInfo.ResumeLayout(false);
            this.splitContainerEditUser.Panel1.ResumeLayout(false);
            this.splitContainerEditUser.Panel1.PerformLayout();
            this.splitContainerEditUser.Panel2.ResumeLayout(false);
            this.splitContainerEditUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerUser;
        private System.Windows.Forms.SplitContainer splitContainerUserInfo;
        private System.Windows.Forms.SplitContainer splitContainerEditUser;
        private System.Windows.Forms.ListView lvUserInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderUserId;
        private System.Windows.Forms.ColumnHeader columnHeaderUserName;
        private System.Windows.Forms.ColumnHeader columnHeaderClassID;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderLastModifiedDate;
        private System.Windows.Forms.CheckedListBox ckListBoxUserRoleInfo;
        private System.Windows.Forms.Label lblRoleInfo;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lbl_UserId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.ComboBox cmbClassId;
        private System.Windows.Forms.Label lbl_ClassId;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.Label lblLastModifiedDate;
        private System.Windows.Forms.Label lbl_LastModifiedDate;
        private System.Windows.Forms.Button btnResetPassword;
    }
}