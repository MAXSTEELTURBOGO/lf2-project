namespace LFAutomationUI.LFUI
{
    partial class RoleInfoForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root");
            this.panelRole = new System.Windows.Forms.Panel();
            this.splitContainerEditRole = new System.Windows.Forms.SplitContainer();
            this.lblRoleId = new System.Windows.Forms.Label();
            this.lblLastModifiedDate = new System.Windows.Forms.Label();
            this.lbl_RoleLastModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lbl_RoleName = new System.Windows.Forms.Label();
            this.lbl_RoleId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnEditRole = new System.Windows.Forms.Button();
            this.btnDeleteRole = new System.Windows.Forms.Button();
            this.btnNewRole = new System.Windows.Forms.Button();
            this.splitContainerRoleInfo = new System.Windows.Forms.SplitContainer();
            this.lvRolesInfo = new System.Windows.Forms.ListView();
            this.columnHeaderRoleId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRoleName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRoleCreatedDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLastModifiedDate = new System.Windows.Forms.ColumnHeader();
            this.treeViewPrivileges = new System.Windows.Forms.TreeView();
            this.btnModifyMenuPrivilege = new System.Windows.Forms.Button();
            this.panelRole.SuspendLayout();
            this.splitContainerEditRole.Panel1.SuspendLayout();
            this.splitContainerEditRole.Panel2.SuspendLayout();
            this.splitContainerEditRole.SuspendLayout();
            this.splitContainerRoleInfo.Panel1.SuspendLayout();
            this.splitContainerRoleInfo.Panel2.SuspendLayout();
            this.splitContainerRoleInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRole
            // 
            this.panelRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRole.Controls.Add(this.splitContainerEditRole);
            this.panelRole.Controls.Add(this.splitContainerRoleInfo);
            this.panelRole.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.panelRole.Location = new System.Drawing.Point(13, 13);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(703, 546);
            this.panelRole.TabIndex = 0;
            // 
            // splitContainerEditRole
            // 
            this.splitContainerEditRole.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerEditRole.IsSplitterFixed = true;
            this.splitContainerEditRole.Location = new System.Drawing.Point(3, 395);
            this.splitContainerEditRole.Name = "splitContainerEditRole";
            this.splitContainerEditRole.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerEditRole.Panel1
            // 
            this.splitContainerEditRole.Panel1.Controls.Add(this.lblRoleId);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lblLastModifiedDate);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lbl_RoleLastModifiedDate);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lblCreatedDate);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lbl_CreatedDate);
            this.splitContainerEditRole.Panel1.Controls.Add(this.txtRoleName);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lbl_RoleName);
            this.splitContainerEditRole.Panel1.Controls.Add(this.lbl_RoleId);
            // 
            // splitContainerEditRole.Panel2
            // 
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnClose);
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnOK);
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnEditRole);
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnDeleteRole);
            this.splitContainerEditRole.Panel2.Controls.Add(this.btnNewRole);
            this.splitContainerEditRole.Size = new System.Drawing.Size(689, 144);
            this.splitContainerEditRole.SplitterDistance = 72;
            this.splitContainerEditRole.TabIndex = 1;
            // 
            // lblRoleId
            // 
            this.lblRoleId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRoleId.Location = new System.Drawing.Point(162, 9);
            this.lblRoleId.Name = "lblRoleId";
            this.lblRoleId.Size = new System.Drawing.Size(123, 23);
            this.lblRoleId.TabIndex = 8;
            this.lblRoleId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastModifiedDate
            // 
            this.lblLastModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastModifiedDate.Location = new System.Drawing.Point(463, 38);
            this.lblLastModifiedDate.Name = "lblLastModifiedDate";
            this.lblLastModifiedDate.Size = new System.Drawing.Size(219, 23);
            this.lblLastModifiedDate.TabIndex = 7;
            this.lblLastModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_RoleLastModifiedDate
            // 
            this.lbl_RoleLastModifiedDate.AutoSize = true;
            this.lbl_RoleLastModifiedDate.Location = new System.Drawing.Point(338, 42);
            this.lbl_RoleLastModifiedDate.Name = "lbl_RoleLastModifiedDate";
            this.lbl_RoleLastModifiedDate.Size = new System.Drawing.Size(119, 14);
            this.lbl_RoleLastModifiedDate.TabIndex = 6;
            this.lbl_RoleLastModifiedDate.Text = "最后一次修改时间";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedDate.Location = new System.Drawing.Point(463, 9);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(219, 23);
            this.lblCreatedDate.TabIndex = 5;
            this.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Location = new System.Drawing.Point(366, 13);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(91, 14);
            this.lbl_CreatedDate.TabIndex = 4;
            this.lbl_CreatedDate.Text = "角色创建时间";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Enabled = false;
            this.txtRoleName.Location = new System.Drawing.Point(162, 39);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(123, 23);
            this.txtRoleName.TabIndex = 3;
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.AutoSize = true;
            this.lbl_RoleName.Location = new System.Drawing.Point(93, 42);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(63, 14);
            this.lbl_RoleName.TabIndex = 2;
            this.lbl_RoleName.Text = "角色名称";
            // 
            // lbl_RoleId
            // 
            this.lbl_RoleId.AutoSize = true;
            this.lbl_RoleId.Location = new System.Drawing.Point(107, 13);
            this.lbl_RoleId.Name = "lbl_RoleId";
            this.lbl_RoleId.Size = new System.Drawing.Size(49, 14);
            this.lbl_RoleId.TabIndex = 0;
            this.lbl_RoleId.Text = "角色ID";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(595, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 48);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(380, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 48);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(310, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 48);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnEditRole
            // 
            this.btnEditRole.Enabled = false;
            this.btnEditRole.Location = new System.Drawing.Point(73, 8);
            this.btnEditRole.Name = "btnEditRole";
            this.btnEditRole.Size = new System.Drawing.Size(64, 48);
            this.btnEditRole.TabIndex = 2;
            this.btnEditRole.Text = "修改";
            this.btnEditRole.UseVisualStyleBackColor = true;
            this.btnEditRole.Click += new System.EventHandler(this.btnEditRole_Click);
            // 
            // btnDeleteRole
            // 
            this.btnDeleteRole.Enabled = false;
            this.btnDeleteRole.Location = new System.Drawing.Point(143, 8);
            this.btnDeleteRole.Name = "btnDeleteRole";
            this.btnDeleteRole.Size = new System.Drawing.Size(64, 48);
            this.btnDeleteRole.TabIndex = 1;
            this.btnDeleteRole.Text = "删除";
            this.btnDeleteRole.UseVisualStyleBackColor = true;
            this.btnDeleteRole.Click += new System.EventHandler(this.btnDeleteRole_Click);
            // 
            // btnNewRole
            // 
            this.btnNewRole.Location = new System.Drawing.Point(3, 8);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(64, 48);
            this.btnNewRole.TabIndex = 0;
            this.btnNewRole.Text = "新增";
            this.btnNewRole.UseVisualStyleBackColor = true;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // splitContainerRoleInfo
            // 
            this.splitContainerRoleInfo.AllowDrop = true;
            this.splitContainerRoleInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerRoleInfo.IsSplitterFixed = true;
            this.splitContainerRoleInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRoleInfo.Name = "splitContainerRoleInfo";
            // 
            // splitContainerRoleInfo.Panel1
            // 
            this.splitContainerRoleInfo.Panel1.Controls.Add(this.lvRolesInfo);
            // 
            // splitContainerRoleInfo.Panel2
            // 
            this.splitContainerRoleInfo.Panel2.Controls.Add(this.treeViewPrivileges);
            this.splitContainerRoleInfo.Panel2.Controls.Add(this.btnModifyMenuPrivilege);
            this.splitContainerRoleInfo.Size = new System.Drawing.Size(697, 389);
            this.splitContainerRoleInfo.SplitterDistance = 472;
            this.splitContainerRoleInfo.TabIndex = 0;
            // 
            // lvRolesInfo
            // 
            this.lvRolesInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRoleId,
            this.columnHeaderRoleName,
            this.columnHeaderRoleCreatedDate,
            this.columnHeaderLastModifiedDate});
            this.lvRolesInfo.FullRowSelect = true;
            this.lvRolesInfo.GridLines = true;
            this.lvRolesInfo.HideSelection = false;
            this.lvRolesInfo.Location = new System.Drawing.Point(1, 3);
            this.lvRolesInfo.MultiSelect = false;
            this.lvRolesInfo.Name = "lvRolesInfo";
            this.lvRolesInfo.Size = new System.Drawing.Size(464, 379);
            this.lvRolesInfo.TabIndex = 0;
            this.lvRolesInfo.UseCompatibleStateImageBehavior = false;
            this.lvRolesInfo.View = System.Windows.Forms.View.Details;
            this.lvRolesInfo.SelectedIndexChanged += new System.EventHandler(this.lvRolesInfo_SelectedIndexChanged);
            // 
            // columnHeaderRoleId
            // 
            this.columnHeaderRoleId.Text = "角色编号";
            this.columnHeaderRoleId.Width = 80;
            // 
            // columnHeaderRoleName
            // 
            this.columnHeaderRoleName.Text = "角色名称";
            this.columnHeaderRoleName.Width = 96;
            // 
            // columnHeaderRoleCreatedDate
            // 
            this.columnHeaderRoleCreatedDate.Text = "创建时间";
            this.columnHeaderRoleCreatedDate.Width = 122;
            // 
            // columnHeaderLastModifiedDate
            // 
            this.columnHeaderLastModifiedDate.Text = "最后一次修改时间";
            this.columnHeaderLastModifiedDate.Width = 149;
            // 
            // treeViewPrivileges
            // 
            this.treeViewPrivileges.CheckBoxes = true;
            this.treeViewPrivileges.Font = new System.Drawing.Font("SimSun", 11F);
            this.treeViewPrivileges.FullRowSelect = true;
            this.treeViewPrivileges.Location = new System.Drawing.Point(3, 3);
            this.treeViewPrivileges.Name = "treeViewPrivileges";
            treeNode1.Name = "NodeRoot";
            treeNode1.Text = "Root";
            this.treeViewPrivileges.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewPrivileges.Size = new System.Drawing.Size(211, 349);
            this.treeViewPrivileges.TabIndex = 0;
            this.treeViewPrivileges.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPrivileges_AfterCheck);
            // 
            // btnModifyMenuPrivilege
            // 
            this.btnModifyMenuPrivilege.Enabled = false;
            this.btnModifyMenuPrivilege.Location = new System.Drawing.Point(29, 358);
            this.btnModifyMenuPrivilege.Name = "btnModifyMenuPrivilege";
            this.btnModifyMenuPrivilege.Size = new System.Drawing.Size(159, 24);
            this.btnModifyMenuPrivilege.TabIndex = 2;
            this.btnModifyMenuPrivilege.Text = "修改当前用户菜单权限";
            this.btnModifyMenuPrivilege.UseVisualStyleBackColor = true;
            this.btnModifyMenuPrivilege.Click += new System.EventHandler(this.btnModifyMenuPrivilege_Click);
            // 
            // RoleInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(728, 571);
            this.ControlBox = false;
            this.Controls.Add(this.panelRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoleInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "角色信息";
            this.Load += new System.EventHandler(this.RoleInfoForm_Load);
            this.panelRole.ResumeLayout(false);
            this.splitContainerEditRole.Panel1.ResumeLayout(false);
            this.splitContainerEditRole.Panel1.PerformLayout();
            this.splitContainerEditRole.Panel2.ResumeLayout(false);
            this.splitContainerEditRole.ResumeLayout(false);
            this.splitContainerRoleInfo.Panel1.ResumeLayout(false);
            this.splitContainerRoleInfo.Panel2.ResumeLayout(false);
            this.splitContainerRoleInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRole;
        private System.Windows.Forms.SplitContainer splitContainerRoleInfo;
        private System.Windows.Forms.TreeView treeViewPrivileges;
        private System.Windows.Forms.ListView lvRolesInfo;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleId;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleName;
        private System.Windows.Forms.ColumnHeader columnHeaderRoleCreatedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderLastModifiedDate;
        private System.Windows.Forms.SplitContainer splitContainerEditRole;
        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnEditRole;
        private System.Windows.Forms.Button btnDeleteRole;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLastModifiedDate;
        private System.Windows.Forms.Label lbl_RoleLastModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lbl_RoleName;
        private System.Windows.Forms.Label lbl_RoleId;
        private System.Windows.Forms.Label lblRoleId;
        private System.Windows.Forms.Button btnModifyMenuPrivilege;
    }
}