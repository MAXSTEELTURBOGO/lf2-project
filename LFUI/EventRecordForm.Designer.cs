namespace LFAutomationUI.LFUI
{
    partial class EventRecordForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearch = new System.Windows.Forms.SplitContainer();
            this.gBoxSearchByHeatId = new System.Windows.Forms.GroupBox();
            this.cmbHeatId = new System.Windows.Forms.ComboBox();
            this.btnSearchByHeatId = new System.Windows.Forms.Button();
            this.cmbTreatmentCount = new System.Windows.Forms.ComboBox();
            this.lblTreatmentCount = new System.Windows.Forms.Label();
            this.lblHeatId = new System.Windows.Forms.Label();
            this.gBoxSearchByDate = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchByDate = new System.Windows.Forms.Button();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.splitContainerRecordContent = new System.Windows.Forms.SplitContainer();
            this.splitContainerDetailRecord = new System.Windows.Forms.SplitContainer();
            this.lvEventRecordList = new System.Windows.Forms.ListView();
            this.colLvMsgTimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvHeatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvTreatmentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvEventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvEventInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtEventDetailInfo = new System.Windows.Forms.TextBox();
            this.cbSlagQuality = new System.Windows.Forms.CheckBox();
            this.cbQuality = new System.Windows.Forms.CheckBox();
            this.cbHeatProcess = new System.Windows.Forms.CheckBox();
            this.cbPower = new System.Windows.Forms.CheckBox();
            this.cbTempOxygen = new System.Windows.Forms.CheckBox();
            this.cbAdditionMat = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.splitContainerSearch.Panel1.SuspendLayout();
            this.splitContainerSearch.Panel2.SuspendLayout();
            this.splitContainerSearch.SuspendLayout();
            this.gBoxSearchByHeatId.SuspendLayout();
            this.gBoxSearchByDate.SuspendLayout();
            this.splitContainerRecordContent.Panel1.SuspendLayout();
            this.splitContainerRecordContent.Panel2.SuspendLayout();
            this.splitContainerRecordContent.SuspendLayout();
            this.splitContainerDetailRecord.Panel1.SuspendLayout();
            this.splitContainerDetailRecord.Panel2.SuspendLayout();
            this.splitContainerDetailRecord.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(879, 579);
            this.panelMain.TabIndex = 3;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerSearch);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRecordContent);
            this.splitContainerMain.Size = new System.Drawing.Size(875, 575);
            this.splitContainerMain.SplitterDistance = 52;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerSearch
            // 
            this.splitContainerSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearch.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSearch.Name = "splitContainerSearch";
            // 
            // splitContainerSearch.Panel1
            // 
            this.splitContainerSearch.Panel1.Controls.Add(this.gBoxSearchByHeatId);
            // 
            // splitContainerSearch.Panel2
            // 
            this.splitContainerSearch.Panel2.Controls.Add(this.gBoxSearchByDate);
            this.splitContainerSearch.Size = new System.Drawing.Size(875, 52);
            this.splitContainerSearch.SplitterDistance = 379;
            this.splitContainerSearch.TabIndex = 0;
            // 
            // gBoxSearchByHeatId
            // 
            this.gBoxSearchByHeatId.Controls.Add(this.cmbHeatId);
            this.gBoxSearchByHeatId.Controls.Add(this.btnSearchByHeatId);
            this.gBoxSearchByHeatId.Controls.Add(this.cmbTreatmentCount);
            this.gBoxSearchByHeatId.Controls.Add(this.lblTreatmentCount);
            this.gBoxSearchByHeatId.Controls.Add(this.lblHeatId);
            this.gBoxSearchByHeatId.Location = new System.Drawing.Point(3, 3);
            this.gBoxSearchByHeatId.Name = "gBoxSearchByHeatId";
            this.gBoxSearchByHeatId.Size = new System.Drawing.Size(371, 42);
            this.gBoxSearchByHeatId.TabIndex = 0;
            this.gBoxSearchByHeatId.TabStop = false;
            this.gBoxSearchByHeatId.Text = "按炉次查询";
            // 
            // cmbHeatId
            // 
            this.cmbHeatId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHeatId.FormattingEnabled = true;
            this.cmbHeatId.Location = new System.Drawing.Point(61, 13);
            this.cmbHeatId.Name = "cmbHeatId";
            this.cmbHeatId.Size = new System.Drawing.Size(104, 22);
            this.cmbHeatId.TabIndex = 4;
            this.cmbHeatId.TextChanged += new System.EventHandler(this.cmbHeatId_TextChanged);
            // 
            // btnSearchByHeatId
            // 
            this.btnSearchByHeatId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchByHeatId.Location = new System.Drawing.Point(303, 10);
            this.btnSearchByHeatId.Name = "btnSearchByHeatId";
            this.btnSearchByHeatId.Size = new System.Drawing.Size(63, 28);
            this.btnSearchByHeatId.TabIndex = 3;
            this.btnSearchByHeatId.Text = "查 询";
            this.btnSearchByHeatId.UseVisualStyleBackColor = true;
            this.btnSearchByHeatId.Click += new System.EventHandler(this.btnSearchByHeatId_Click);
            // 
            // cmbTreatmentCount
            // 
            this.cmbTreatmentCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTreatmentCount.FormattingEnabled = true;
            this.cmbTreatmentCount.Location = new System.Drawing.Point(240, 13);
            this.cmbTreatmentCount.Name = "cmbTreatmentCount";
            this.cmbTreatmentCount.Size = new System.Drawing.Size(57, 22);
            this.cmbTreatmentCount.TabIndex = 2;
            // 
            // lblTreatmentCount
            // 
            this.lblTreatmentCount.AutoSize = true;
            this.lblTreatmentCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTreatmentCount.Location = new System.Drawing.Point(171, 17);
            this.lblTreatmentCount.Name = "lblTreatmentCount";
            this.lblTreatmentCount.Size = new System.Drawing.Size(63, 14);
            this.lblTreatmentCount.TabIndex = 0;
            this.lblTreatmentCount.Text = "冶炼次数";
            // 
            // lblHeatId
            // 
            this.lblHeatId.AutoSize = true;
            this.lblHeatId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHeatId.Location = new System.Drawing.Point(6, 17);
            this.lblHeatId.Name = "lblHeatId";
            this.lblHeatId.Size = new System.Drawing.Size(49, 14);
            this.lblHeatId.TabIndex = 0;
            this.lblHeatId.Text = "炉次号";
            // 
            // gBoxSearchByDate
            // 
            this.gBoxSearchByDate.Controls.Add(this.dtpEndDate);
            this.gBoxSearchByDate.Controls.Add(this.dtpStartDate);
            this.gBoxSearchByDate.Controls.Add(this.btnSearchByDate);
            this.gBoxSearchByDate.Controls.Add(this.lblStartDate);
            this.gBoxSearchByDate.Controls.Add(this.lblEndDate);
            this.gBoxSearchByDate.Location = new System.Drawing.Point(3, 3);
            this.gBoxSearchByDate.Name = "gBoxSearchByDate";
            this.gBoxSearchByDate.Size = new System.Drawing.Size(482, 42);
            this.gBoxSearchByDate.TabIndex = 1;
            this.gBoxSearchByDate.TabStop = false;
            this.gBoxSearchByDate.Text = "按日期查询";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-mm-dd 00:00:00";
            this.dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndDate.Location = new System.Drawing.Point(275, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(131, 23);
            this.dtpEndDate.TabIndex = 9;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-mm-dd 00:00:00";
            this.dtpStartDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartDate.Location = new System.Drawing.Point(69, 13);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(131, 23);
            this.dtpStartDate.TabIndex = 9;
            this.dtpStartDate.Value = new System.DateTime(2010, 6, 15, 0, 0, 0, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // btnSearchByDate
            // 
            this.btnSearchByDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchByDate.Location = new System.Drawing.Point(412, 10);
            this.btnSearchByDate.Name = "btnSearchByDate";
            this.btnSearchByDate.Size = new System.Drawing.Size(63, 28);
            this.btnSearchByDate.TabIndex = 8;
            this.btnSearchByDate.Text = "查 询";
            this.btnSearchByDate.UseVisualStyleBackColor = true;
            this.btnSearchByDate.Click += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartDate.Location = new System.Drawing.Point(6, 17);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(63, 14);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "起始日期";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEndDate.Location = new System.Drawing.Point(206, 17);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(63, 14);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "截止日期";
            // 
            // splitContainerRecordContent
            // 
            this.splitContainerRecordContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerRecordContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRecordContent.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRecordContent.Name = "splitContainerRecordContent";
            this.splitContainerRecordContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRecordContent.Panel1
            // 
            this.splitContainerRecordContent.Panel1.Controls.Add(this.splitContainerDetailRecord);
            // 
            // splitContainerRecordContent.Panel2
            // 
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbSlagQuality);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbQuality);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbHeatProcess);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbPower);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbTempOxygen);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.cbAdditionMat);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnClose);
            this.splitContainerRecordContent.Size = new System.Drawing.Size(875, 519);
            this.splitContainerRecordContent.SplitterDistance = 466;
            this.splitContainerRecordContent.TabIndex = 0;
            // 
            // splitContainerDetailRecord
            // 
            this.splitContainerDetailRecord.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerDetailRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDetailRecord.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDetailRecord.Name = "splitContainerDetailRecord";
            this.splitContainerDetailRecord.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDetailRecord.Panel1
            // 
            this.splitContainerDetailRecord.Panel1.Controls.Add(this.lvEventRecordList);
            // 
            // splitContainerDetailRecord.Panel2
            // 
            this.splitContainerDetailRecord.Panel2.Controls.Add(this.txtEventDetailInfo);
            this.splitContainerDetailRecord.Size = new System.Drawing.Size(875, 466);
            this.splitContainerDetailRecord.SplitterDistance = 363;
            this.splitContainerDetailRecord.TabIndex = 0;
            // 
            // lvEventRecordList
            // 
            this.lvEventRecordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvMsgTimeStamp,
            this.colLvHeatId,
            this.colLvTreatmentCount,
            this.colLvEventType,
            this.colLvEventInfo});
            this.lvEventRecordList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvEventRecordList.FullRowSelect = true;
            this.lvEventRecordList.GridLines = true;
            this.lvEventRecordList.Location = new System.Drawing.Point(4, 3);
            this.lvEventRecordList.MultiSelect = false;
            this.lvEventRecordList.Name = "lvEventRecordList";
            this.lvEventRecordList.Size = new System.Drawing.Size(863, 353);
            this.lvEventRecordList.TabIndex = 1;
            this.lvEventRecordList.UseCompatibleStateImageBehavior = false;
            this.lvEventRecordList.View = System.Windows.Forms.View.Details;
            this.lvEventRecordList.SelectedIndexChanged += new System.EventHandler(this.lvEventRecordList_SelectedIndexChanged);
            // 
            // colLvMsgTimeStamp
            // 
            this.colLvMsgTimeStamp.Text = "记录插入时间";
            this.colLvMsgTimeStamp.Width = 160;
            // 
            // colLvHeatId
            // 
            this.colLvHeatId.Text = "炉次号";
            this.colLvHeatId.Width = 80;
            // 
            // colLvTreatmentCount
            // 
            this.colLvTreatmentCount.Text = "冶炼次数";
            this.colLvTreatmentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvTreatmentCount.Width = 70;
            // 
            // colLvEventType
            // 
            this.colLvEventType.Text = "类型";
            this.colLvEventType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvEventType.Width = 80;
            // 
            // colLvEventInfo
            // 
            this.colLvEventInfo.Text = "事件信息";
            this.colLvEventInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvEventInfo.Width = 450;
            // 
            // txtEventDetailInfo
            // 
            this.txtEventDetailInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEventDetailInfo.Location = new System.Drawing.Point(4, 4);
            this.txtEventDetailInfo.Multiline = true;
            this.txtEventDetailInfo.Name = "txtEventDetailInfo";
            this.txtEventDetailInfo.Size = new System.Drawing.Size(863, 88);
            this.txtEventDetailInfo.TabIndex = 0;
            // 
            // cbSlagQuality
            // 
            this.cbSlagQuality.AutoSize = true;
            this.cbSlagQuality.Checked = true;
            this.cbSlagQuality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSlagQuality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbSlagQuality.Location = new System.Drawing.Point(441, 13);
            this.cbSlagQuality.Name = "cbSlagQuality";
            this.cbSlagQuality.Size = new System.Drawing.Size(96, 18);
            this.cbSlagQuality.TabIndex = 10;
            this.cbSlagQuality.Text = "渣化验信息";
            this.cbSlagQuality.UseVisualStyleBackColor = true;
            // 
            // cbQuality
            // 
            this.cbQuality.AutoSize = true;
            this.cbQuality.Checked = true;
            this.cbQuality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbQuality.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQuality.Location = new System.Drawing.Point(351, 13);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(82, 18);
            this.cbQuality.TabIndex = 10;
            this.cbQuality.Text = "化验信息";
            this.cbQuality.UseVisualStyleBackColor = true;
            // 
            // cbHeatProcess
            // 
            this.cbHeatProcess.AutoSize = true;
            this.cbHeatProcess.Checked = true;
            this.cbHeatProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHeatProcess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbHeatProcess.Location = new System.Drawing.Point(261, 13);
            this.cbHeatProcess.Name = "cbHeatProcess";
            this.cbHeatProcess.Size = new System.Drawing.Size(82, 18);
            this.cbHeatProcess.TabIndex = 10;
            this.cbHeatProcess.Text = "冶炼进程";
            this.cbHeatProcess.UseVisualStyleBackColor = true;
            // 
            // cbPower
            // 
            this.cbPower.AutoSize = true;
            this.cbPower.Checked = true;
            this.cbPower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPower.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPower.Location = new System.Drawing.Point(171, 13);
            this.cbPower.Name = "cbPower";
            this.cbPower.Size = new System.Drawing.Size(82, 18);
            this.cbPower.TabIndex = 10;
            this.cbPower.Text = "通电断电";
            this.cbPower.UseVisualStyleBackColor = true;
            // 
            // cbTempOxygen
            // 
            this.cbTempOxygen.AutoSize = true;
            this.cbTempOxygen.Checked = true;
            this.cbTempOxygen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTempOxygen.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTempOxygen.Location = new System.Drawing.Point(74, 13);
            this.cbTempOxygen.Name = "cbTempOxygen";
            this.cbTempOxygen.Size = new System.Drawing.Size(89, 18);
            this.cbTempOxygen.TabIndex = 10;
            this.cbTempOxygen.Text = "测温/测氧";
            this.cbTempOxygen.UseVisualStyleBackColor = true;
            // 
            // cbAdditionMat
            // 
            this.cbAdditionMat.AutoSize = true;
            this.cbAdditionMat.Checked = true;
            this.cbAdditionMat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAdditionMat.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbAdditionMat.Location = new System.Drawing.Point(12, 13);
            this.cbAdditionMat.Name = "cbAdditionMat";
            this.cbAdditionMat.Size = new System.Drawing.Size(54, 18);
            this.cbAdditionMat.TabIndex = 10;
            this.cbAdditionMat.Text = "加料";
            this.cbAdditionMat.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(759, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 38);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EventRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(879, 579);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventRecordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "事件记录查询界面";
            this.Load += new System.EventHandler(this.EventRecordForm_Load);
            this.panelMain.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerSearch.Panel1.ResumeLayout(false);
            this.splitContainerSearch.Panel2.ResumeLayout(false);
            this.splitContainerSearch.ResumeLayout(false);
            this.gBoxSearchByHeatId.ResumeLayout(false);
            this.gBoxSearchByHeatId.PerformLayout();
            this.gBoxSearchByDate.ResumeLayout(false);
            this.gBoxSearchByDate.PerformLayout();
            this.splitContainerRecordContent.Panel1.ResumeLayout(false);
            this.splitContainerRecordContent.Panel2.ResumeLayout(false);
            this.splitContainerRecordContent.Panel2.PerformLayout();
            this.splitContainerRecordContent.ResumeLayout(false);
            this.splitContainerDetailRecord.Panel1.ResumeLayout(false);
            this.splitContainerDetailRecord.Panel2.ResumeLayout(false);
            this.splitContainerDetailRecord.Panel2.PerformLayout();
            this.splitContainerDetailRecord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerSearch;
        private System.Windows.Forms.GroupBox gBoxSearchByHeatId;
        private System.Windows.Forms.Button btnSearchByHeatId;
        private System.Windows.Forms.ComboBox cmbTreatmentCount;
        private System.Windows.Forms.Label lblTreatmentCount;
        private System.Windows.Forms.Label lblHeatId;
        private System.Windows.Forms.GroupBox gBoxSearchByDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnSearchByDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.SplitContainer splitContainerRecordContent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainerDetailRecord;
        private System.Windows.Forms.ListView lvEventRecordList;
        private System.Windows.Forms.ColumnHeader colLvMsgTimeStamp;
        private System.Windows.Forms.ColumnHeader colLvHeatId;
        private System.Windows.Forms.ColumnHeader colLvTreatmentCount;
        private System.Windows.Forms.ColumnHeader colLvEventType;
        private System.Windows.Forms.ColumnHeader colLvEventInfo;
        private System.Windows.Forms.TextBox txtEventDetailInfo;
        private System.Windows.Forms.CheckBox cbSlagQuality;
        private System.Windows.Forms.CheckBox cbQuality;
        private System.Windows.Forms.CheckBox cbHeatProcess;
        private System.Windows.Forms.CheckBox cbTempOxygen;
        private System.Windows.Forms.CheckBox cbAdditionMat;
        private System.Windows.Forms.ComboBox cmbHeatId;
        private System.Windows.Forms.CheckBox cbPower;
    }
}