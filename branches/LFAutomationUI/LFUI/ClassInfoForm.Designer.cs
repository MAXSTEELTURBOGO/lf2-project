namespace LFAutomationUI.LFUI
{
    partial class ClassInfoForm
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
            this.lvClassesInfo = new System.Windows.Forms.ListView();
            this.columnHeaderClassId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderClassHeader = new System.Windows.Forms.ColumnHeader();
            this.splitContainerClassInfo = new System.Windows.Forms.SplitContainer();
            this.txtClassId = new System.Windows.Forms.TextBox();
            this.txtClassHeader = new System.Windows.Forms.TextBox();
            this.lbl_ClassHeader = new System.Windows.Forms.Label();
            this.lbl_ClassId = new System.Windows.Forms.Label();
            this.btnCloseWindows = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnDeleteClass = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnNewClass = new System.Windows.Forms.Button();
            this.splitContainerClassInfo.Panel1.SuspendLayout();
            this.splitContainerClassInfo.Panel2.SuspendLayout();
            this.splitContainerClassInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvClassesInfo
            // 
            this.lvClassesInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderClassId,
            this.columnHeaderClassHeader});
            this.lvClassesInfo.FullRowSelect = true;
            this.lvClassesInfo.GridLines = true;
            this.lvClassesInfo.Location = new System.Drawing.Point(14, 14);
            this.lvClassesInfo.MultiSelect = false;
            this.lvClassesInfo.Name = "lvClassesInfo";
            this.lvClassesInfo.Size = new System.Drawing.Size(291, 157);
            this.lvClassesInfo.TabIndex = 0;
            this.lvClassesInfo.UseCompatibleStateImageBehavior = false;
            this.lvClassesInfo.View = System.Windows.Forms.View.Details;
            this.lvClassesInfo.SelectedIndexChanged += new System.EventHandler(this.lvClassesInfo_SelectedIndexChanged);
            // 
            // columnHeaderClassId
            // 
            this.columnHeaderClassId.Text = "班组";
            this.columnHeaderClassId.Width = 103;
            // 
            // columnHeaderClassHeader
            // 
            this.columnHeaderClassHeader.Text = "班组负责人";
            this.columnHeaderClassHeader.Width = 136;
            // 
            // splitContainerClassInfo
            // 
            this.splitContainerClassInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerClassInfo.IsSplitterFixed = true;
            this.splitContainerClassInfo.Location = new System.Drawing.Point(14, 178);
            this.splitContainerClassInfo.Name = "splitContainerClassInfo";
            this.splitContainerClassInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerClassInfo.Panel1
            // 
            this.splitContainerClassInfo.Panel1.Controls.Add(this.txtClassId);
            this.splitContainerClassInfo.Panel1.Controls.Add(this.txtClassHeader);
            this.splitContainerClassInfo.Panel1.Controls.Add(this.lbl_ClassHeader);
            this.splitContainerClassInfo.Panel1.Controls.Add(this.lbl_ClassId);
            // 
            // splitContainerClassInfo.Panel2
            // 
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnCloseWindows);
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnOK);
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnDeleteClass);
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnEditClass);
            this.splitContainerClassInfo.Panel2.Controls.Add(this.btnNewClass);
            this.splitContainerClassInfo.Size = new System.Drawing.Size(292, 194);
            this.splitContainerClassInfo.SplitterDistance = 97;
            this.splitContainerClassInfo.SplitterWidth = 5;
            this.splitContainerClassInfo.TabIndex = 1;
            // 
            // txtClassId
            // 
            this.txtClassId.Location = new System.Drawing.Point(91, 14);
            this.txtClassId.Name = "txtClassId";
            this.txtClassId.ReadOnly = true;
            this.txtClassId.Size = new System.Drawing.Size(116, 23);
            this.txtClassId.TabIndex = 4;
            // 
            // txtClassHeader
            // 
            this.txtClassHeader.Location = new System.Drawing.Point(91, 52);
            this.txtClassHeader.Name = "txtClassHeader";
            this.txtClassHeader.ReadOnly = true;
            this.txtClassHeader.Size = new System.Drawing.Size(116, 23);
            this.txtClassHeader.TabIndex = 3;
            // 
            // lbl_ClassHeader
            // 
            this.lbl_ClassHeader.AutoSize = true;
            this.lbl_ClassHeader.Location = new System.Drawing.Point(8, 55);
            this.lbl_ClassHeader.Name = "lbl_ClassHeader";
            this.lbl_ClassHeader.Size = new System.Drawing.Size(77, 14);
            this.lbl_ClassHeader.TabIndex = 2;
            this.lbl_ClassHeader.Text = "班组负责人";
            // 
            // lbl_ClassId
            // 
            this.lbl_ClassId.AutoSize = true;
            this.lbl_ClassId.Location = new System.Drawing.Point(50, 17);
            this.lbl_ClassId.Name = "lbl_ClassId";
            this.lbl_ClassId.Size = new System.Drawing.Size(35, 14);
            this.lbl_ClassId.TabIndex = 0;
            this.lbl_ClassId.Text = "班组";
            // 
            // btnCloseWindows
            // 
            this.btnCloseWindows.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseWindows.Location = new System.Drawing.Point(213, 3);
            this.btnCloseWindows.Name = "btnCloseWindows";
            this.btnCloseWindows.Size = new System.Drawing.Size(74, 82);
            this.btnCloseWindows.TabIndex = 5;
            this.btnCloseWindows.Text = "关闭窗口";
            this.btnCloseWindows.UseVisualStyleBackColor = true;
            this.btnCloseWindows.Click += new System.EventHandler(this.btnCloseWindows_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(113, 46);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(113, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 39);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDeleteClass
            // 
            this.btnDeleteClass.Enabled = false;
            this.btnDeleteClass.Location = new System.Drawing.Point(11, 62);
            this.btnDeleteClass.Name = "btnDeleteClass";
            this.btnDeleteClass.Size = new System.Drawing.Size(74, 23);
            this.btnDeleteClass.TabIndex = 2;
            this.btnDeleteClass.Text = "删除";
            this.btnDeleteClass.UseVisualStyleBackColor = true;
            this.btnDeleteClass.Click += new System.EventHandler(this.btnDeleteClass_Click);
            // 
            // btnEditClass
            // 
            this.btnEditClass.Enabled = false;
            this.btnEditClass.Location = new System.Drawing.Point(11, 32);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(74, 23);
            this.btnEditClass.TabIndex = 1;
            this.btnEditClass.Text = "修改";
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnNewClass
            // 
            this.btnNewClass.Location = new System.Drawing.Point(11, 3);
            this.btnNewClass.Name = "btnNewClass";
            this.btnNewClass.Size = new System.Drawing.Size(74, 23);
            this.btnNewClass.TabIndex = 0;
            this.btnNewClass.Text = "新增";
            this.btnNewClass.UseVisualStyleBackColor = true;
            this.btnNewClass.Click += new System.EventHandler(this.btnNewClass_Click);
            // 
            // ClassInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseWindows;
            this.ClientSize = new System.Drawing.Size(320, 386);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerClassInfo);
            this.Controls.Add(this.lvClassesInfo);
            this.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClassInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "班组信息管理";
            this.Load += new System.EventHandler(this.ClassInfoForm_Load);
            this.splitContainerClassInfo.Panel1.ResumeLayout(false);
            this.splitContainerClassInfo.Panel1.PerformLayout();
            this.splitContainerClassInfo.Panel2.ResumeLayout(false);
            this.splitContainerClassInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvClassesInfo;
        private System.Windows.Forms.SplitContainer splitContainerClassInfo;
        private System.Windows.Forms.TextBox txtClassHeader;
        private System.Windows.Forms.Label lbl_ClassHeader;
        private System.Windows.Forms.Label lbl_ClassId;
        private System.Windows.Forms.ColumnHeader columnHeaderClassId;
        private System.Windows.Forms.ColumnHeader columnHeaderClassHeader;
        private System.Windows.Forms.Button btnCloseWindows;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnDeleteClass;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnNewClass;
        private System.Windows.Forms.TextBox txtClassId;
    }
}