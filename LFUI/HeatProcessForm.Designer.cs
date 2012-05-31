namespace LFAutomationUI.LFUI
{
    partial class HeatProcessForm
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
            this.lvHeatStatusList = new System.Windows.Forms.ListView();
            this.colLvMsgTimeStamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvHeatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvTreatmentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvStatusName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvPowerDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLvPowerConsumption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearchRecentRecord = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(822, 505);
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
            this.splitContainerMain.Size = new System.Drawing.Size(818, 501);
            this.splitContainerMain.SplitterDistance = 250;
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
            this.splitContainerSearch.Size = new System.Drawing.Size(818, 250);
            this.splitContainerSearch.SplitterDistance = 351;
            this.splitContainerSearch.TabIndex = 0;
            // 
            // gBoxSearchByHeatId
            // 
            this.gBoxSearchByHeatId.Controls.Add(this.cmbHeatId);
            this.gBoxSearchByHeatId.Controls.Add(this.btnSearchByHeatId);
            this.gBoxSearchByHeatId.Controls.Add(this.cmbTreatmentCount);
            this.gBoxSearchByHeatId.Controls.Add(this.lblTreatmentCount);
            this.gBoxSearchByHeatId.Controls.Add(this.lblHeatId);
            this.gBoxSearchByHeatId.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.gBoxSearchByDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.splitContainerRecordContent.Panel1.Controls.Add(this.lvHeatStatusList);
            // 
            // splitContainerRecordContent.Panel2
            // 
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnSearchRecentRecord);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnClose);
            this.splitContainerRecordContent.Size = new System.Drawing.Size(818, 247);
            this.splitContainerRecordContent.SplitterDistance = 217;
            this.splitContainerRecordContent.TabIndex = 0;
            // 
            // lvHeatStatusList
            // 
            this.lvHeatStatusList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvMsgTimeStamp,
            this.colLvHeatId,
            this.colLvTreatmentCount,
            this.colLvStatusName,
            this.colLvPowerDuration,
            this.colLvPowerConsumption});
            this.lvHeatStatusList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHeatStatusList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvHeatStatusList.FullRowSelect = true;
            this.lvHeatStatusList.GridLines = true;
            this.lvHeatStatusList.Location = new System.Drawing.Point(0, 0);
            this.lvHeatStatusList.MultiSelect = false;
            this.lvHeatStatusList.Name = "lvHeatStatusList";
            this.lvHeatStatusList.Size = new System.Drawing.Size(814, 213);
            this.lvHeatStatusList.TabIndex = 0;
            this.lvHeatStatusList.UseCompatibleStateImageBehavior = false;
            this.lvHeatStatusList.View = System.Windows.Forms.View.Details;
            // 
            // colLvMsgTimeStamp
            // 
            this.colLvMsgTimeStamp.Text = "状态插入时间";
            this.colLvMsgTimeStamp.Width = 200;
            // 
            // colLvHeatId
            // 
            this.colLvHeatId.Text = "炉次号";
            this.colLvHeatId.Width = 120;
            // 
            // colLvTreatmentCount
            // 
            this.colLvTreatmentCount.Text = "冶炼次数";
            this.colLvTreatmentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvTreatmentCount.Width = 85;
            // 
            // colLvStatusName
            // 
            this.colLvStatusName.Text = "状态";
            this.colLvStatusName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvStatusName.Width = 200;
            // 
            // colLvPowerDuration
            // 
            this.colLvPowerDuration.Text = "通电时间";
            this.colLvPowerDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvPowerDuration.Width = 120;
            // 
            // colLvPowerConsumption
            // 
            this.colLvPowerConsumption.Text = "电耗[KW.H]";
            this.colLvPowerConsumption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvPowerConsumption.Width = 110;
            // 
            // btnSearchRecentRecord
            // 
            this.btnSearchRecentRecord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchRecentRecord.Location = new System.Drawing.Point(246, 1);
            this.btnSearchRecentRecord.Name = "btnSearchRecentRecord";
            this.btnSearchRecentRecord.Size = new System.Drawing.Size(180, 44);
            this.btnSearchRecentRecord.TabIndex = 9;
            this.btnSearchRecentRecord.Text = "查看当日冶炼进程记录";
            this.btnSearchRecentRecord.UseVisualStyleBackColor = true;
            this.btnSearchRecentRecord.Click += new System.EventHandler(this.btnSearchRecentRecord_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(444, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 44);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // HeatProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(822, 505);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeatProcessForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "冶炼进程查询界面";
            this.Load += new System.EventHandler(this.HeatProcessForm_Load);
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
            this.splitContainerRecordContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerSearch;
        private System.Windows.Forms.GroupBox gBoxSearchByHeatId;
        private System.Windows.Forms.ComboBox cmbHeatId;
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
        private System.Windows.Forms.ListView lvHeatStatusList;
        private System.Windows.Forms.ColumnHeader colLvMsgTimeStamp;
        private System.Windows.Forms.ColumnHeader colLvHeatId;
        private System.Windows.Forms.ColumnHeader colLvTreatmentCount;
        private System.Windows.Forms.Button btnSearchRecentRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colLvStatusName;
        private System.Windows.Forms.ColumnHeader colLvPowerDuration;
        private System.Windows.Forms.ColumnHeader colLvPowerConsumption;
    }
}