namespace LFAutomationUI.LFUI
{
    partial class PrivilegeInfoForm
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
            this.lvPrivileges = new System.Windows.Forms.ListView();
            this.columnHeaderPrivilegeId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderPrivilegeName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderCreatedDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLastModifiedDate = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderParentPriviId = new System.Windows.Forms.ColumnHeader();
            this.panelPrivilege = new System.Windows.Forms.Panel();
            this.splitContainerPrivilege = new System.Windows.Forms.SplitContainer();
            this.lblPrivilegeId = new System.Windows.Forms.Label();
            this.cmbParentPrivilegeId = new System.Windows.Forms.ComboBox();
            this.lblParentPrivilegeId = new System.Windows.Forms.Label();
            this.txtPrivilegeName = new System.Windows.Forms.TextBox();
            this.lblLastModifiedDate = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lbl_LastModifiedDate = new System.Windows.Forms.Label();
            this.lbl_CreatedDate = new System.Windows.Forms.Label();
            this.lbl_PrivilegeName = new System.Windows.Forms.Label();
            this.lbl_PrivilegeId = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnCloseWindow = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelPrivilege.SuspendLayout();
            this.splitContainerPrivilege.Panel1.SuspendLayout();
            this.splitContainerPrivilege.Panel2.SuspendLayout();
            this.splitContainerPrivilege.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPrivileges
            // 
            this.lvPrivileges.AllowColumnReorder = true;
            this.lvPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPrivilegeId,
            this.columnHeaderPrivilegeName,
            this.columnHeaderCreatedDate,
            this.columnHeaderLastModifiedDate,
            this.columnHeaderParentPriviId});
            this.lvPrivileges.FullRowSelect = true;
            this.lvPrivileges.GridLines = true;
            this.lvPrivileges.Location = new System.Drawing.Point(4, 4);
            this.lvPrivileges.MultiSelect = false;
            this.lvPrivileges.Name = "lvPrivileges";
            this.lvPrivileges.Size = new System.Drawing.Size(593, 286);
            this.lvPrivileges.TabIndex = 0;
            this.lvPrivileges.UseCompatibleStateImageBehavior = false;
            this.lvPrivileges.View = System.Windows.Forms.View.Details;
            this.lvPrivileges.SelectedIndexChanged += new System.EventHandler(this.lvPrivileges_SelectedIndexChanged);
            // 
            // columnHeaderPrivilegeId
            // 
            this.columnHeaderPrivilegeId.Text = "权限编号";
            this.columnHeaderPrivilegeId.Width = 81;
            // 
            // columnHeaderPrivilegeName
            // 
            this.columnHeaderPrivilegeName.Text = "权限名称";
            this.columnHeaderPrivilegeName.Width = 97;
            // 
            // columnHeaderCreatedDate
            // 
            this.columnHeaderCreatedDate.Text = "创建时间";
            this.columnHeaderCreatedDate.Width = 151;
            // 
            // columnHeaderLastModifiedDate
            // 
            this.columnHeaderLastModifiedDate.Text = "最后一次修改时间";
            this.columnHeaderLastModifiedDate.Width = 169;
            // 
            // columnHeaderParentPriviId
            // 
            this.columnHeaderParentPriviId.Text = "父ID";
            this.columnHeaderParentPriviId.Width = 73;
            // 
            // panelPrivilege
            // 
            this.panelPrivilege.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPrivilege.Controls.Add(this.splitContainerPrivilege);
            this.panelPrivilege.Controls.Add(this.lvPrivileges);
            this.panelPrivilege.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panelPrivilege.Location = new System.Drawing.Point(12, 12);
            this.panelPrivilege.Name = "panelPrivilege";
            this.panelPrivilege.Size = new System.Drawing.Size(604, 461);
            this.panelPrivilege.TabIndex = 0;
            // 
            // splitContainerPrivilege
            // 
            this.splitContainerPrivilege.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerPrivilege.Location = new System.Drawing.Point(4, 296);
            this.splitContainerPrivilege.Name = "splitContainerPrivilege";
            this.splitContainerPrivilege.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPrivilege.Panel1
            // 
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lblPrivilegeId);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.cmbParentPrivilegeId);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lblParentPrivilegeId);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.txtPrivilegeName);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lblLastModifiedDate);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lblCreatedDate);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lbl_LastModifiedDate);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lbl_CreatedDate);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lbl_PrivilegeName);
            this.splitContainerPrivilege.Panel1.Controls.Add(this.lbl_PrivilegeId);
            // 
            // splitContainerPrivilege.Panel2
            // 
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnOK);
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnCancle);
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnCloseWindow);
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnDelete);
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnEdit);
            this.splitContainerPrivilege.Panel2.Controls.Add(this.btnNew);
            this.splitContainerPrivilege.Size = new System.Drawing.Size(593, 148);
            this.splitContainerPrivilege.SplitterDistance = 98;
            this.splitContainerPrivilege.TabIndex = 1;
            // 
            // lblPrivilegeId
            // 
            this.lblPrivilegeId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPrivilegeId.Location = new System.Drawing.Point(84, 13);
            this.lblPrivilegeId.Name = "lblPrivilegeId";
            this.lblPrivilegeId.Size = new System.Drawing.Size(53, 23);
            this.lblPrivilegeId.TabIndex = 10;
            this.lblPrivilegeId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbParentPrivilegeId
            // 
            this.cmbParentPrivilegeId.Enabled = false;
            this.cmbParentPrivilegeId.FormattingEnabled = true;
            this.cmbParentPrivilegeId.Location = new System.Drawing.Point(84, 60);
            this.cmbParentPrivilegeId.Name = "cmbParentPrivilegeId";
            this.cmbParentPrivilegeId.Size = new System.Drawing.Size(136, 22);
            this.cmbParentPrivilegeId.TabIndex = 9;
            // 
            // lblParentPrivilegeId
            // 
            this.lblParentPrivilegeId.AutoSize = true;
            this.lblParentPrivilegeId.Location = new System.Drawing.Point(43, 63);
            this.lblParentPrivilegeId.Name = "lblParentPrivilegeId";
            this.lblParentPrivilegeId.Size = new System.Drawing.Size(35, 14);
            this.lblParentPrivilegeId.TabIndex = 8;
            this.lblParentPrivilegeId.Text = "父ID";
            // 
            // txtPrivilegeName
            // 
            this.txtPrivilegeName.Enabled = false;
            this.txtPrivilegeName.Location = new System.Drawing.Point(217, 13);
            this.txtPrivilegeName.MaxLength = 50;
            this.txtPrivilegeName.Name = "txtPrivilegeName";
            this.txtPrivilegeName.Size = new System.Drawing.Size(109, 23);
            this.txtPrivilegeName.TabIndex = 6;
            // 
            // lblLastModifiedDate
            // 
            this.lblLastModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastModifiedDate.Location = new System.Drawing.Point(401, 59);
            this.lblLastModifiedDate.Name = "lblLastModifiedDate";
            this.lblLastModifiedDate.Size = new System.Drawing.Size(160, 23);
            this.lblLastModifiedDate.TabIndex = 5;
            this.lblLastModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCreatedDate.Location = new System.Drawing.Point(401, 12);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(160, 23);
            this.lblCreatedDate.TabIndex = 4;
            this.lblCreatedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LastModifiedDate
            // 
            this.lbl_LastModifiedDate.AutoSize = true;
            this.lbl_LastModifiedDate.Location = new System.Drawing.Point(276, 63);
            this.lbl_LastModifiedDate.Name = "lbl_LastModifiedDate";
            this.lbl_LastModifiedDate.Size = new System.Drawing.Size(119, 14);
            this.lbl_LastModifiedDate.TabIndex = 3;
            this.lbl_LastModifiedDate.Text = "最后一次修改时间";
            // 
            // lbl_CreatedDate
            // 
            this.lbl_CreatedDate.AutoSize = true;
            this.lbl_CreatedDate.Location = new System.Drawing.Point(332, 16);
            this.lbl_CreatedDate.Name = "lbl_CreatedDate";
            this.lbl_CreatedDate.Size = new System.Drawing.Size(63, 14);
            this.lbl_CreatedDate.TabIndex = 2;
            this.lbl_CreatedDate.Text = "创建时间";
            // 
            // lbl_PrivilegeName
            // 
            this.lbl_PrivilegeName.AutoSize = true;
            this.lbl_PrivilegeName.Location = new System.Drawing.Point(148, 16);
            this.lbl_PrivilegeName.Name = "lbl_PrivilegeName";
            this.lbl_PrivilegeName.Size = new System.Drawing.Size(63, 14);
            this.lbl_PrivilegeName.TabIndex = 1;
            this.lbl_PrivilegeName.Text = "权限名称";
            // 
            // lbl_PrivilegeId
            // 
            this.lbl_PrivilegeId.AutoSize = true;
            this.lbl_PrivilegeId.Location = new System.Drawing.Point(15, 16);
            this.lbl_PrivilegeId.Name = "lbl_PrivilegeId";
            this.lbl_PrivilegeId.Size = new System.Drawing.Size(63, 14);
            this.lbl_PrivilegeId.TabIndex = 0;
            this.lbl_PrivilegeId.Text = "权限编号";
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(300, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 38);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.Enabled = false;
            this.btnCancle.Location = new System.Drawing.Point(381, 2);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 38);
            this.btnCancle.TabIndex = 4;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnCloseWindow
            // 
            this.btnCloseWindow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseWindow.Location = new System.Drawing.Point(511, 2);
            this.btnCloseWindow.Name = "btnCloseWindow";
            this.btnCloseWindow.Size = new System.Drawing.Size(75, 38);
            this.btnCloseWindow.TabIndex = 3;
            this.btnCloseWindow.Text = "关闭窗口";
            this.btnCloseWindow.UseVisualStyleBackColor = true;
            this.btnCloseWindow.Click += new System.EventHandler(this.btnCloseWindow_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(165, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(84, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 38);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 38);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // PrivilegeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseWindow;
            this.ClientSize = new System.Drawing.Size(628, 485);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrivilege);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrivilegeInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "权限信息";
            this.Load += new System.EventHandler(this.PrivilegeInfoForm_Load);
            this.panelPrivilege.ResumeLayout(false);
            this.splitContainerPrivilege.Panel1.ResumeLayout(false);
            this.splitContainerPrivilege.Panel1.PerformLayout();
            this.splitContainerPrivilege.Panel2.ResumeLayout(false);
            this.splitContainerPrivilege.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPrivileges;
        private System.Windows.Forms.ColumnHeader columnHeaderPrivilegeId;
        private System.Windows.Forms.ColumnHeader columnHeaderPrivilegeName;
        private System.Windows.Forms.ColumnHeader columnHeaderCreatedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderLastModifiedDate;
        private System.Windows.Forms.ColumnHeader columnHeaderParentPriviId;
        private System.Windows.Forms.Panel panelPrivilege;
        private System.Windows.Forms.SplitContainer splitContainerPrivilege;
        private System.Windows.Forms.Label lbl_LastModifiedDate;
        private System.Windows.Forms.Label lbl_CreatedDate;
        private System.Windows.Forms.Label lbl_PrivilegeName;
        private System.Windows.Forms.Label lbl_PrivilegeId;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblLastModifiedDate;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblParentPrivilegeId;
        private System.Windows.Forms.TextBox txtPrivilegeName;
        private System.Windows.Forms.ComboBox cmbParentPrivilegeId;
        private System.Windows.Forms.Label lblPrivilegeId;
        private System.Windows.Forms.Button btnCloseWindow;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDelete;

    }
}