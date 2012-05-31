namespace LFAutomationUI.LFUI
{
    partial class ElementInfoForm
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
            this.gBoxElementInfo = new System.Windows.Forms.GroupBox();
            this.lvElementInfo = new System.Windows.Forms.ListView();
            this.colLvElementCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvElementShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colElementFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvElementType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvAppearanceOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvCalModify = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainerElementMaintenance = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gBoxElementOperation = new System.Windows.Forms.GroupBox();
            this.cmbElementType = new System.Windows.Forms.ComboBox();
            this.lblElementType = new System.Windows.Forms.Label();
            this.txtCalModify = new System.Windows.Forms.TextBox();
            this.txtElementFullName = new System.Windows.Forms.TextBox();
            this.txtElementShortName = new System.Windows.Forms.TextBox();
            this.lblElementCalModify = new System.Windows.Forms.Label();
            this.lblElementFullName = new System.Windows.Forms.Label();
            this.txtApearanceOrder = new System.Windows.Forms.TextBox();
            this.txtElementId = new System.Windows.Forms.TextBox();
            this.lblElementShortName = new System.Windows.Forms.Label();
            this.lblApearanceOrder = new System.Windows.Forms.Label();
            this.lblElementId = new System.Windows.Forms.Label();
            this.btnAddNewElementInfo = new System.Windows.Forms.Button();
            this.btnDeleteElementInfo = new System.Windows.Forms.Button();
            this.btnModifyElementInfo = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gBoxElementInfo.SuspendLayout();
            this.splitContainerElementMaintenance.Panel1.SuspendLayout();
            this.splitContainerElementMaintenance.Panel2.SuspendLayout();
            this.splitContainerElementMaintenance.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gBoxElementOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxElementInfo
            // 
            this.gBoxElementInfo.Controls.Add(this.lvElementInfo);
            this.gBoxElementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxElementInfo.Location = new System.Drawing.Point(0, 0);
            this.gBoxElementInfo.Name = "gBoxElementInfo";
            this.gBoxElementInfo.Size = new System.Drawing.Size(751, 359);
            this.gBoxElementInfo.TabIndex = 2;
            this.gBoxElementInfo.TabStop = false;
            this.gBoxElementInfo.Text = "元素信息";
            // 
            // lvElementInfo
            // 
            this.lvElementInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvElementCode,
            this.colLvElementShortName,
            this.colElementFullName,
            this.colLvElementType,
            this.colLvAppearanceOrder,
            this.colLvCalModify});
            this.lvElementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvElementInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvElementInfo.FullRowSelect = true;
            this.lvElementInfo.GridLines = true;
            this.lvElementInfo.Location = new System.Drawing.Point(3, 17);
            this.lvElementInfo.Name = "lvElementInfo";
            this.lvElementInfo.Size = new System.Drawing.Size(745, 339);
            this.lvElementInfo.TabIndex = 1;
            this.lvElementInfo.UseCompatibleStateImageBehavior = false;
            this.lvElementInfo.View = System.Windows.Forms.View.Details;
            this.lvElementInfo.SelectedIndexChanged += new System.EventHandler(this.lvElementInfo_SelectedIndexChanged);
            // 
            // colLvElementCode
            // 
            this.colLvElementCode.Text = "元素代码";
            this.colLvElementCode.Width = 80;
            // 
            // colLvElementShortName
            // 
            this.colLvElementShortName.Text = "元素简称";
            this.colLvElementShortName.Width = 145;
            // 
            // colElementFullName
            // 
            this.colElementFullName.Text = "元素全称";
            this.colElementFullName.Width = 220;
            // 
            // colLvElementType
            // 
            this.colLvElementType.Text = "元素类型";
            this.colLvElementType.Width = 150;
            // 
            // colLvAppearanceOrder
            // 
            this.colLvAppearanceOrder.Text = "显示顺序";
            this.colLvAppearanceOrder.Width = 80;
            // 
            // colLvCalModify
            // 
            this.colLvCalModify.Text = "计算校正值";
            this.colLvCalModify.Width = 95;
            // 
            // splitContainerElementMaintenance
            // 
            this.splitContainerElementMaintenance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerElementMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerElementMaintenance.Location = new System.Drawing.Point(0, 0);
            this.splitContainerElementMaintenance.Name = "splitContainerElementMaintenance";
            this.splitContainerElementMaintenance.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerElementMaintenance.Panel1
            // 
            this.splitContainerElementMaintenance.Panel1.Controls.Add(this.gBoxElementInfo);
            // 
            // splitContainerElementMaintenance.Panel2
            // 
            this.splitContainerElementMaintenance.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerElementMaintenance.Size = new System.Drawing.Size(755, 494);
            this.splitContainerElementMaintenance.SplitterDistance = 363;
            this.splitContainerElementMaintenance.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gBoxElementOperation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAddNewElementInfo);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteElementInfo);
            this.splitContainer1.Panel2.Controls.Add(this.btnModifyElementInfo);
            this.splitContainer1.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(751, 123);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // gBoxElementOperation
            // 
            this.gBoxElementOperation.Controls.Add(this.cmbElementType);
            this.gBoxElementOperation.Controls.Add(this.lblElementType);
            this.gBoxElementOperation.Controls.Add(this.txtCalModify);
            this.gBoxElementOperation.Controls.Add(this.txtElementFullName);
            this.gBoxElementOperation.Controls.Add(this.txtElementShortName);
            this.gBoxElementOperation.Controls.Add(this.lblElementCalModify);
            this.gBoxElementOperation.Controls.Add(this.lblElementFullName);
            this.gBoxElementOperation.Controls.Add(this.txtApearanceOrder);
            this.gBoxElementOperation.Controls.Add(this.txtElementId);
            this.gBoxElementOperation.Controls.Add(this.lblElementShortName);
            this.gBoxElementOperation.Controls.Add(this.lblApearanceOrder);
            this.gBoxElementOperation.Controls.Add(this.lblElementId);
            this.gBoxElementOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBoxElementOperation.Location = new System.Drawing.Point(0, 0);
            this.gBoxElementOperation.Name = "gBoxElementOperation";
            this.gBoxElementOperation.Size = new System.Drawing.Size(751, 72);
            this.gBoxElementOperation.TabIndex = 1;
            this.gBoxElementOperation.TabStop = false;
            this.gBoxElementOperation.Text = "元素操作栏";
            // 
            // cmbElementType
            // 
            this.cmbElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbElementType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbElementType.FormattingEnabled = true;
            this.cmbElementType.Items.AddRange(new object[] {
            "ELEMENT",
            "COMPOUND",
            "FORMULA",
            "SPECIAL FORMULA",
            " "});
            this.cmbElementType.Location = new System.Drawing.Point(241, 49);
            this.cmbElementType.Name = "cmbElementType";
            this.cmbElementType.Size = new System.Drawing.Size(139, 29);
            this.cmbElementType.TabIndex = 14;
            // 
            // lblElementType
            // 
            this.lblElementType.AutoSize = true;
            this.lblElementType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElementType.Location = new System.Drawing.Point(161, 53);
            this.lblElementType.Name = "lblElementType";
            this.lblElementType.Size = new System.Drawing.Size(74, 21);
            this.lblElementType.TabIndex = 13;
            this.lblElementType.Text = "元素类型";
            // 
            // txtCalModify
            // 
            this.txtCalModify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCalModify.Location = new System.Drawing.Point(486, 49);
            this.txtCalModify.Name = "txtCalModify";
            this.txtCalModify.ReadOnly = true;
            this.txtCalModify.Size = new System.Drawing.Size(120, 29);
            this.txtCalModify.TabIndex = 11;
            // 
            // txtElementFullName
            // 
            this.txtElementFullName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtElementFullName.Location = new System.Drawing.Point(486, 13);
            this.txtElementFullName.Name = "txtElementFullName";
            this.txtElementFullName.ReadOnly = true;
            this.txtElementFullName.Size = new System.Drawing.Size(311, 29);
            this.txtElementFullName.TabIndex = 11;
            // 
            // txtElementShortName
            // 
            this.txtElementShortName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtElementShortName.Location = new System.Drawing.Point(241, 13);
            this.txtElementShortName.Name = "txtElementShortName";
            this.txtElementShortName.ReadOnly = true;
            this.txtElementShortName.Size = new System.Drawing.Size(139, 29);
            this.txtElementShortName.TabIndex = 5;
            // 
            // lblElementCalModify
            // 
            this.lblElementCalModify.AutoSize = true;
            this.lblElementCalModify.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElementCalModify.Location = new System.Drawing.Point(390, 53);
            this.lblElementCalModify.Name = "lblElementCalModify";
            this.lblElementCalModify.Size = new System.Drawing.Size(90, 21);
            this.lblElementCalModify.TabIndex = 3;
            this.lblElementCalModify.Text = "计算校正值";
            // 
            // lblElementFullName
            // 
            this.lblElementFullName.AutoSize = true;
            this.lblElementFullName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElementFullName.Location = new System.Drawing.Point(406, 17);
            this.lblElementFullName.Name = "lblElementFullName";
            this.lblElementFullName.Size = new System.Drawing.Size(74, 21);
            this.lblElementFullName.TabIndex = 3;
            this.lblElementFullName.Text = "元素全称";
            // 
            // txtApearanceOrder
            // 
            this.txtApearanceOrder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtApearanceOrder.Location = new System.Drawing.Point(74, 49);
            this.txtApearanceOrder.Name = "txtApearanceOrder";
            this.txtApearanceOrder.ReadOnly = true;
            this.txtApearanceOrder.Size = new System.Drawing.Size(72, 29);
            this.txtApearanceOrder.TabIndex = 7;
            // 
            // txtElementId
            // 
            this.txtElementId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtElementId.Location = new System.Drawing.Point(74, 13);
            this.txtElementId.Name = "txtElementId";
            this.txtElementId.ReadOnly = true;
            this.txtElementId.Size = new System.Drawing.Size(72, 29);
            this.txtElementId.TabIndex = 7;
            // 
            // lblElementShortName
            // 
            this.lblElementShortName.AutoSize = true;
            this.lblElementShortName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElementShortName.Location = new System.Drawing.Point(161, 17);
            this.lblElementShortName.Name = "lblElementShortName";
            this.lblElementShortName.Size = new System.Drawing.Size(74, 21);
            this.lblElementShortName.TabIndex = 2;
            this.lblElementShortName.Text = "元素简称";
            // 
            // lblApearanceOrder
            // 
            this.lblApearanceOrder.AutoSize = true;
            this.lblApearanceOrder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApearanceOrder.Location = new System.Drawing.Point(10, 53);
            this.lblApearanceOrder.Name = "lblApearanceOrder";
            this.lblApearanceOrder.Size = new System.Drawing.Size(58, 21);
            this.lblApearanceOrder.TabIndex = 4;
            this.lblApearanceOrder.Text = "顺序号";
            // 
            // lblElementId
            // 
            this.lblElementId.AutoSize = true;
            this.lblElementId.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblElementId.Location = new System.Drawing.Point(10, 17);
            this.lblElementId.Name = "lblElementId";
            this.lblElementId.Size = new System.Drawing.Size(58, 21);
            this.lblElementId.TabIndex = 4;
            this.lblElementId.Text = "元素号";
            // 
            // btnAddNewElementInfo
            // 
            this.btnAddNewElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewElementInfo.Location = new System.Drawing.Point(2, 2);
            this.btnAddNewElementInfo.Name = "btnAddNewElementInfo";
            this.btnAddNewElementInfo.Size = new System.Drawing.Size(107, 42);
            this.btnAddNewElementInfo.TabIndex = 13;
            this.btnAddNewElementInfo.Text = "新  增";
            this.btnAddNewElementInfo.UseVisualStyleBackColor = true;
            this.btnAddNewElementInfo.Click += new System.EventHandler(this.btnAddNewElementInfo_Click);
            // 
            // btnDeleteElementInfo
            // 
            this.btnDeleteElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteElementInfo.Location = new System.Drawing.Point(280, 2);
            this.btnDeleteElementInfo.Name = "btnDeleteElementInfo";
            this.btnDeleteElementInfo.Size = new System.Drawing.Size(107, 42);
            this.btnDeleteElementInfo.TabIndex = 15;
            this.btnDeleteElementInfo.Text = "删  除";
            this.btnDeleteElementInfo.UseVisualStyleBackColor = true;
            this.btnDeleteElementInfo.Click += new System.EventHandler(this.btnDeleteElementInfo_Click);
            // 
            // btnModifyElementInfo
            // 
            this.btnModifyElementInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyElementInfo.Location = new System.Drawing.Point(141, 2);
            this.btnModifyElementInfo.Name = "btnModifyElementInfo";
            this.btnModifyElementInfo.Size = new System.Drawing.Size(107, 42);
            this.btnModifyElementInfo.TabIndex = 14;
            this.btnModifyElementInfo.Text = "修  改";
            this.btnModifyElementInfo.UseVisualStyleBackColor = true;
            this.btnModifyElementInfo.Click += new System.EventHandler(this.btnModifyElementInfo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(419, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(107, 42);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "确  认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(697, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 42);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(558, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 42);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ElementInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 494);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerElementMaintenance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "ElementInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "元素信息维护";
            this.Load += new System.EventHandler(this.ElementInfoMaintenanceUI_Load);
            this.gBoxElementInfo.ResumeLayout(false);
            this.splitContainerElementMaintenance.Panel1.ResumeLayout(false);
            this.splitContainerElementMaintenance.Panel2.ResumeLayout(false);
            this.splitContainerElementMaintenance.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gBoxElementOperation.ResumeLayout(false);
            this.gBoxElementOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxElementInfo;
        private System.Windows.Forms.ListView lvElementInfo;
        private System.Windows.Forms.SplitContainer splitContainerElementMaintenance;
        private System.Windows.Forms.ColumnHeader colLvElementCode;
        private System.Windows.Forms.ColumnHeader colLvElementShortName;
        private System.Windows.Forms.ColumnHeader colElementFullName;
        private System.Windows.Forms.ColumnHeader colLvElementType;
        private System.Windows.Forms.ColumnHeader colLvAppearanceOrder;
        private System.Windows.Forms.ColumnHeader colLvCalModify;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gBoxElementOperation;
        private System.Windows.Forms.ComboBox cmbElementType;
        private System.Windows.Forms.Label lblElementType;
        private System.Windows.Forms.TextBox txtElementFullName;
        private System.Windows.Forms.TextBox txtElementShortName;
        private System.Windows.Forms.Label lblElementFullName;
        private System.Windows.Forms.TextBox txtElementId;
        private System.Windows.Forms.Label lblElementShortName;
        private System.Windows.Forms.Label lblElementId;
        private System.Windows.Forms.Button btnAddNewElementInfo;
        private System.Windows.Forms.Button btnDeleteElementInfo;
        private System.Windows.Forms.Button btnModifyElementInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCalModify;
        private System.Windows.Forms.Label lblElementCalModify;
        private System.Windows.Forms.TextBox txtApearanceOrder;
        private System.Windows.Forms.Label lblApearanceOrder;


    }
}