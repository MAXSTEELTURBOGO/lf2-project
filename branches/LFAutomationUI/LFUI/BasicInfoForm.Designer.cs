namespace LFAutomationUI.LFUI
{
    partial class BasicInfoForm
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
            this.splitContainerBasicInfo = new System.Windows.Forms.SplitContainer();
            this.lvBasicInfoList = new System.Windows.Forms.ListView();
            this.collvInfoName = new System.Windows.Forms.ColumnHeader();
            this.colLvInfoData = new System.Windows.Forms.ColumnHeader();
            this.colLvInfoDesc = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panelOperation = new System.Windows.Forms.Panel();
            this.txtInfoData = new System.Windows.Forms.TextBox();
            this.txtInfoDesc = new System.Windows.Forms.TextBox();
            this.txtInfoName = new System.Windows.Forms.TextBox();
            this.lblInfoData = new System.Windows.Forms.Label();
            this.lblInfoDesc = new System.Windows.Forms.Label();
            this.lblInfoName = new System.Windows.Forms.Label();
            this.splitContainerBasicInfo.Panel1.SuspendLayout();
            this.splitContainerBasicInfo.Panel2.SuspendLayout();
            this.splitContainerBasicInfo.SuspendLayout();
            this.panelOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerBasicInfo
            // 
            this.splitContainerBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBasicInfo.Name = "splitContainerBasicInfo";
            this.splitContainerBasicInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBasicInfo.Panel1
            // 
            this.splitContainerBasicInfo.Panel1.Controls.Add(this.lvBasicInfoList);
            // 
            // splitContainerBasicInfo.Panel2
            // 
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.btnClose);
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.btnModify);
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.btnNew);
            this.splitContainerBasicInfo.Panel2.Controls.Add(this.panelOperation);
            this.splitContainerBasicInfo.Size = new System.Drawing.Size(535, 425);
            this.splitContainerBasicInfo.SplitterDistance = 292;
            this.splitContainerBasicInfo.SplitterWidth = 5;
            this.splitContainerBasicInfo.TabIndex = 0;
            // 
            // lvBasicInfoList
            // 
            this.lvBasicInfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.collvInfoName,
            this.colLvInfoData,
            this.colLvInfoDesc});
            this.lvBasicInfoList.FullRowSelect = true;
            this.lvBasicInfoList.GridLines = true;
            this.lvBasicInfoList.Location = new System.Drawing.Point(3, 3);
            this.lvBasicInfoList.MultiSelect = false;
            this.lvBasicInfoList.Name = "lvBasicInfoList";
            this.lvBasicInfoList.Size = new System.Drawing.Size(533, 288);
            this.lvBasicInfoList.TabIndex = 0;
            this.lvBasicInfoList.UseCompatibleStateImageBehavior = false;
            this.lvBasicInfoList.View = System.Windows.Forms.View.Details;
            this.lvBasicInfoList.SelectedIndexChanged += new System.EventHandler(this.lvBasicInfoList_SelectedIndexChanged);
            // 
            // collvInfoName
            // 
            this.collvInfoName.Text = "信息名称";
            this.collvInfoName.Width = 180;
            // 
            // colLvInfoData
            // 
            this.colLvInfoData.Text = "信息数据";
            this.colLvInfoData.Width = 120;
            // 
            // colLvInfoDesc
            // 
            this.colLvInfoDesc.Text = "信息描述";
            this.colLvInfoDesc.Width = 225;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(441, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 42);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(334, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 42);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(227, 81);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(81, 42);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "确 认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnModify
            // 
            this.btnModify.Enabled = false;
            this.btnModify.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModify.Location = new System.Drawing.Point(120, 81);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(81, 42);
            this.btnModify.TabIndex = 12;
            this.btnModify.Text = "修 改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Location = new System.Drawing.Point(13, 81);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(81, 42);
            this.btnNew.TabIndex = 13;
            this.btnNew.Text = "新 增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panelOperation
            // 
            this.panelOperation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOperation.Controls.Add(this.txtInfoData);
            this.panelOperation.Controls.Add(this.txtInfoDesc);
            this.panelOperation.Controls.Add(this.txtInfoName);
            this.panelOperation.Controls.Add(this.lblInfoData);
            this.panelOperation.Controls.Add(this.lblInfoDesc);
            this.panelOperation.Controls.Add(this.lblInfoName);
            this.panelOperation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOperation.Location = new System.Drawing.Point(0, 0);
            this.panelOperation.Name = "panelOperation";
            this.panelOperation.Size = new System.Drawing.Size(531, 75);
            this.panelOperation.TabIndex = 0;
            // 
            // txtInfoData
            // 
            this.txtInfoData.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfoData.Location = new System.Drawing.Point(370, 7);
            this.txtInfoData.Name = "txtInfoData";
            this.txtInfoData.ReadOnly = true;
            this.txtInfoData.Size = new System.Drawing.Size(151, 26);
            this.txtInfoData.TabIndex = 9;
            this.txtInfoData.TextChanged += new System.EventHandler(this.txtInfoData_TextChanged);
            // 
            // txtInfoDesc
            // 
            this.txtInfoDesc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfoDesc.Location = new System.Drawing.Point(87, 38);
            this.txtInfoDesc.Name = "txtInfoDesc";
            this.txtInfoDesc.ReadOnly = true;
            this.txtInfoDesc.Size = new System.Drawing.Size(434, 26);
            this.txtInfoDesc.TabIndex = 7;
            this.txtInfoDesc.TextChanged += new System.EventHandler(this.txtInfoDesc_TextChanged);
            // 
            // txtInfoName
            // 
            this.txtInfoName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInfoName.Location = new System.Drawing.Point(87, 7);
            this.txtInfoName.Name = "txtInfoName";
            this.txtInfoName.ReadOnly = true;
            this.txtInfoName.Size = new System.Drawing.Size(151, 26);
            this.txtInfoName.TabIndex = 8;
            this.txtInfoName.TextChanged += new System.EventHandler(this.txtInfoName_TextChanged);
            // 
            // lblInfoData
            // 
            this.lblInfoData.AutoSize = true;
            this.lblInfoData.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfoData.Location = new System.Drawing.Point(293, 12);
            this.lblInfoData.Name = "lblInfoData";
            this.lblInfoData.Size = new System.Drawing.Size(72, 16);
            this.lblInfoData.TabIndex = 6;
            this.lblInfoData.Text = "信息数据";
            // 
            // lblInfoDesc
            // 
            this.lblInfoDesc.AutoSize = true;
            this.lblInfoDesc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfoDesc.Location = new System.Drawing.Point(9, 41);
            this.lblInfoDesc.Name = "lblInfoDesc";
            this.lblInfoDesc.Size = new System.Drawing.Size(72, 16);
            this.lblInfoDesc.TabIndex = 4;
            this.lblInfoDesc.Text = "信息描述";
            // 
            // lblInfoName
            // 
            this.lblInfoName.AutoSize = true;
            this.lblInfoName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfoName.Location = new System.Drawing.Point(9, 12);
            this.lblInfoName.Name = "lblInfoName";
            this.lblInfoName.Size = new System.Drawing.Size(72, 16);
            this.lblInfoName.TabIndex = 5;
            this.lblInfoName.Text = "信息名称";
            // 
            // BasicInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(535, 425);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerBasicInfo);
            this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "基础信息维护界面";
            this.Load += new System.EventHandler(this.BasicInfoForm_Load);
            this.splitContainerBasicInfo.Panel1.ResumeLayout(false);
            this.splitContainerBasicInfo.Panel2.ResumeLayout(false);
            this.splitContainerBasicInfo.ResumeLayout(false);
            this.panelOperation.ResumeLayout(false);
            this.panelOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerBasicInfo;
        private System.Windows.Forms.ListView lvBasicInfoList;
        private System.Windows.Forms.Panel panelOperation;
        private System.Windows.Forms.TextBox txtInfoData;
        private System.Windows.Forms.TextBox txtInfoDesc;
        private System.Windows.Forms.TextBox txtInfoName;
        private System.Windows.Forms.Label lblInfoData;
        private System.Windows.Forms.Label lblInfoDesc;
        private System.Windows.Forms.Label lblInfoName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader collvInfoName;
        private System.Windows.Forms.ColumnHeader colLvInfoData;
        private System.Windows.Forms.ColumnHeader colLvInfoDesc;
    }
}