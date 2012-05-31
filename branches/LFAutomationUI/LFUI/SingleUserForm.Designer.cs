namespace LFAutomationUI.LFUI
{
    partial class SingleUserForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnModifyPassword = new System.Windows.Forms.Button();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.panelUserDetailInfo = new System.Windows.Forms.Panel();
            this.gBoxPrivilegesInfo = new System.Windows.Forms.GroupBox();
            this.lvPriviInfo = new System.Windows.Forms.ListView();
            this.columnHeaderPriviInfo = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPriviDesc = new System.Windows.Forms.ColumnHeader();
            this.gBoxRoleInfo = new System.Windows.Forms.GroupBox();
            this.lvRoleInfo = new System.Windows.Forms.ListView();
            this.columnHeaderRoleName = new System.Windows.Forms.ColumnHeader();
            this.lblClass = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblLastModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lbl_LastModifiedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.lbl_Class = new System.Windows.Forms.Label();
            this.panelUserDetailInfo.SuspendLayout();
            this.gBoxPrivilegesInfo.SuspendLayout();
            this.gBoxRoleInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(220, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnModifyPassword
            // 
            this.btnModifyPassword.Location = new System.Drawing.Point(126, 387);
            this.btnModifyPassword.Name = "btnModifyPassword";
            this.btnModifyPassword.Size = new System.Drawing.Size(75, 34);
            this.btnModifyPassword.TabIndex = 1;
            this.btnModifyPassword.Text = "修改密码";
            this.btnModifyPassword.UseVisualStyleBackColor = true;
            this.btnModifyPassword.Click += new System.EventHandler(this.btnModifyPassword_Click);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Font = new System.Drawing.Font("宋体", 10F);
            this.lbl_UserName.Location = new System.Drawing.Point(29, 21);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(49, 14);
            this.lbl_UserName.TabIndex = 2;
            this.lbl_UserName.Text = "用户名";
            // 
            // panelUserDetailInfo
            // 
            this.panelUserDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelUserDetailInfo.Controls.Add(this.gBoxPrivilegesInfo);
            this.panelUserDetailInfo.Controls.Add(this.gBoxRoleInfo);
            this.panelUserDetailInfo.Controls.Add(this.lblClass);
            this.panelUserDetailInfo.Controls.Add(this.lblUserName);
            this.panelUserDetailInfo.Controls.Add(this.lblLastModifiedDate);
            this.panelUserDetailInfo.Controls.Add(this.lblCreatedDate);
            this.panelUserDetailInfo.Controls.Add(this.lbl_LastModifiedDate);
            this.panelUserDetailInfo.Controls.Add(this.lbl_CreatedDate);
            this.panelUserDetailInfo.Controls.Add(this.lbl_Class);
            this.panelUserDetailInfo.Controls.Add(this.lbl_UserName);
            this.panelUserDetailInfo.Controls.Add(this.btnClose);
            this.panelUserDetailInfo.Controls.Add(this.btnModifyPassword);
            this.panelUserDetailInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panelUserDetailInfo.Location = new System.Drawing.Point(12, 12);
            this.panelUserDetailInfo.Name = "panelUserDetailInfo";
            this.panelUserDetailInfo.Size = new System.Drawing.Size(460, 428);
            this.panelUserDetailInfo.TabIndex = 3;
            // 
            // gBoxPrivilegesInfo
            // 
            this.gBoxPrivilegesInfo.Controls.Add(this.lvPriviInfo);
            this.gBoxPrivilegesInfo.Location = new System.Drawing.Point(187, 71);
            this.gBoxPrivilegesInfo.Name = "gBoxPrivilegesInfo";
            this.gBoxPrivilegesInfo.Size = new System.Drawing.Size(251, 310);
            this.gBoxPrivilegesInfo.TabIndex = 12;
            this.gBoxPrivilegesInfo.TabStop = false;
            this.gBoxPrivilegesInfo.Text = "权限信息";
            // 
            // lvPriviInfo
            // 
            this.lvPriviInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPriviInfo,
            this.columnHeaderPriviDesc});
            this.lvPriviInfo.FullRowSelect = true;
            this.lvPriviInfo.GridLines = true;
            this.lvPriviInfo.Location = new System.Drawing.Point(20, 22);
            this.lvPriviInfo.Name = "lvPriviInfo";
            this.lvPriviInfo.Size = new System.Drawing.Size(225, 282);
            this.lvPriviInfo.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvPriviInfo.TabIndex = 1;
            this.lvPriviInfo.UseCompatibleStateImageBehavior = false;
            this.lvPriviInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderPriviInfo
            // 
            this.columnHeaderPriviInfo.Text = "权限名称";
            this.columnHeaderPriviInfo.Width = 75;
            // 
            // columnHeaderPriviDesc
            // 
            this.columnHeaderPriviDesc.Text = "权限描述";
            this.columnHeaderPriviDesc.Width = 86;
            // 
            // gBoxRoleInfo
            // 
            this.gBoxRoleInfo.Controls.Add(this.lvRoleInfo);
            this.gBoxRoleInfo.Location = new System.Drawing.Point(6, 71);
            this.gBoxRoleInfo.Name = "gBoxRoleInfo";
            this.gBoxRoleInfo.Size = new System.Drawing.Size(161, 310);
            this.gBoxRoleInfo.TabIndex = 11;
            this.gBoxRoleInfo.TabStop = false;
            this.gBoxRoleInfo.Text = "角色信息";
            // 
            // lvRoleInfo
            // 
            this.lvRoleInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRoleName});
            this.lvRoleInfo.GridLines = true;
            this.lvRoleInfo.Location = new System.Drawing.Point(20, 22);
            this.lvRoleInfo.Name = "lvRoleInfo";
            this.lvRoleInfo.Size = new System.Drawing.Size(113, 282);
            this.lvRoleInfo.TabIndex = 0;
            this.lvRoleInfo.UseCompatibleStateImageBehavior = false;
            this.lvRoleInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderRoleName
            // 
            this.columnHeaderRoleName.Text = "角色名";
            this.columnHeaderRoleName.Width = 107;
            // 
            // lblClass
            // 
            this.lblClass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblClass.Location = new System.Drawing.Point(84, 46);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(83, 21);
            this.lblClass.TabIndex = 10;
            // 
            // lblUserName
            // 
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Location = new System.Drawing.Point(84, 19);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(83, 21);
            this.lblUserName.TabIndex = 9;
            // 
            // lblLastModifiedDate
            // 
            this.lblLastModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastModifiedDate.Location = new System.Drawing.Point(301, 46);
            this.lblLastModifiedDate.Name = "lblLastModifiedDate";
            this.lblLastModifiedDate.Size = new System.Drawing.Size(137, 21);
            this.lblLastModifiedDate.TabIndex = 8;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedDate.Location = new System.Drawing.Point(301, 19);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(137, 21);
            this.lblCreatedDate.TabIndex = 7;
            // 
            // lbl_LastModifiedDate
            // 
            this.lbl_LastModifiedDate.AutoSize = true;
            this.lbl_LastModifiedDate.Location = new System.Drawing.Point(204, 47);
            this.lbl_LastModifiedDate.Name = "lbl_LastModifiedDate";
            this.lbl_LastModifiedDate.Size = new System.Drawing.Size(91, 14);
            this.lbl_LastModifiedDate.TabIndex = 6;
            this.lbl_LastModifiedDate.Text = "最后修改时间";
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Location = new System.Drawing.Point(232, 20);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(63, 14);
            this.lbl_CreatedDate.TabIndex = 5;
            this.lbl_CreatedDate.Text = "创建时间";
            // 
            // lbl_Class
            // 
            this.lbl_Class.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Class.Location = new System.Drawing.Point(38, 47);
            this.lbl_Class.Name = "lbl_Class";
            this.lbl_Class.Size = new System.Drawing.Size(40, 14);
            this.lbl_Class.TabIndex = 4;
            this.lbl_Class.Text = "班组";
            // 
            // SingleUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(484, 452);
            this.ControlBox = false;
            this.Controls.Add(this.panelUserDetailInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleUserForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "当前用户信息";
            this.Load += new System.EventHandler(this.SingleUserForm_Load);
            this.panelUserDetailInfo.ResumeLayout(false);
            this.panelUserDetailInfo.PerformLayout();
            this.gBoxPrivilegesInfo.ResumeLayout(false);
            this.gBoxRoleInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnModifyPassword;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Panel panelUserDetailInfo;
        private System.Windows.Forms.Label lbl_LastModifiedDate;
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.Label lbl_Class;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblLastModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.GroupBox gBoxPrivilegesInfo;
        private System.Windows.Forms.ListView lvPriviInfo;
        private System.Windows.Forms.GroupBox gBoxRoleInfo;
        private System.Windows.Forms.ListView lvRoleInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleName;
        private System.Windows.Forms.ColumnHeader columnHeaderPriviInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderPriviDesc;
    }
}