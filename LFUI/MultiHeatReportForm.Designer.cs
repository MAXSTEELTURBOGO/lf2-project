namespace LFAutomationUI.LFUI
{
    partial class MultiHeatReportForm
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
            this.lvMultiHeatReportList = new System.Windows.Forms.ListView();
            this.colLvPlanId = new System.Windows.Forms.ColumnHeader();
            this.colLvHeatId = new System.Windows.Forms.ColumnHeader();
            this.colLvTreatmentCount = new System.Windows.Forms.ColumnHeader();
            this.colLvCar = new System.Windows.Forms.ColumnHeader();
            this.colLvClass = new System.Windows.Forms.ColumnHeader();
            this.colLvOperator = new System.Windows.Forms.ColumnHeader();
            this.colLvSteelGradeId = new System.Windows.Forms.ColumnHeader();
            this.colLvArrivalTime = new System.Windows.Forms.ColumnHeader();
            this.colLvDepartTime = new System.Windows.Forms.ColumnHeader();
            this.colLvArrivalTemperature = new System.Windows.Forms.ColumnHeader();
            this.colLvDepartTemperature = new System.Windows.Forms.ColumnHeader();
            this.colLvArDuration = new System.Windows.Forms.ColumnHeader();
            this.colLvArConsumption = new System.Windows.Forms.ColumnHeader();
            this.colLvPowerDuration = new System.Windows.Forms.ColumnHeader();
            this.colLvPowerConsumption = new System.Windows.Forms.ColumnHeader();
            this.colLvArDurationAftFeedWire = new System.Windows.Forms.ColumnHeader();
            this.colLVArConsumpAftFeedWire = new System.Windows.Forms.ColumnHeader();
            this.colLvFeedSpeed = new System.Windows.Forms.ColumnHeader();
            this.btnMultiExport = new System.Windows.Forms.Button();
            this.btnSearchCurrentMonth = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.bgWorkMultiExportExcel = new System.ComponentModel.BackgroundWorker();
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
            this.panelMain.Size = new System.Drawing.Size(879, 579);
            this.panelMain.TabIndex = 4;
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
            this.cmbHeatId.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHeatId.FormattingEnabled = true;
            this.cmbHeatId.Location = new System.Drawing.Point(61, 13);
            this.cmbHeatId.Name = "cmbHeatId";
            this.cmbHeatId.Size = new System.Drawing.Size(104, 22);
            this.cmbHeatId.TabIndex = 4;
            this.cmbHeatId.TextChanged += new System.EventHandler(this.cmbHeatId_TextChanged);
            // 
            // btnSearchByHeatId
            // 
            this.btnSearchByHeatId.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearchByHeatId.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.cmbTreatmentCount.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbTreatmentCount.FormattingEnabled = true;
            this.cmbTreatmentCount.Location = new System.Drawing.Point(240, 13);
            this.cmbTreatmentCount.Name = "cmbTreatmentCount";
            this.cmbTreatmentCount.Size = new System.Drawing.Size(57, 22);
            this.cmbTreatmentCount.TabIndex = 2;
            // 
            // lblTreatmentCount
            // 
            this.lblTreatmentCount.AutoSize = true;
            this.lblTreatmentCount.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTreatmentCount.Location = new System.Drawing.Point(171, 17);
            this.lblTreatmentCount.Name = "lblTreatmentCount";
            this.lblTreatmentCount.Size = new System.Drawing.Size(63, 14);
            this.lblTreatmentCount.TabIndex = 0;
            this.lblTreatmentCount.Text = "冶炼次数";
            // 
            // lblHeatId
            // 
            this.lblHeatId.AutoSize = true;
            this.lblHeatId.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.gBoxSearchByDate.Text = "按炉次查询";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-mm-dd 00:00:00";
            this.dtpEndDate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndDate.Location = new System.Drawing.Point(275, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(131, 23);
            this.dtpEndDate.TabIndex = 9;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-mm-dd 00:00:00";
            this.dtpStartDate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartDate.Location = new System.Drawing.Point(69, 13);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(131, 23);
            this.dtpStartDate.TabIndex = 9;
            this.dtpStartDate.Value = new System.DateTime(2010, 6, 15, 0, 0, 0, 0);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // btnSearchByDate
            // 
            this.btnSearchByDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearchByDate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.lblStartDate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartDate.Location = new System.Drawing.Point(6, 17);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(63, 14);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "起始日期";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.splitContainerRecordContent.Panel1.Controls.Add(this.lvMultiHeatReportList);
            // 
            // splitContainerRecordContent.Panel2
            // 
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnMultiExport);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnSearchCurrentMonth);
            this.splitContainerRecordContent.Panel2.Controls.Add(this.btnClose);
            this.splitContainerRecordContent.Size = new System.Drawing.Size(875, 519);
            this.splitContainerRecordContent.SplitterDistance = 466;
            this.splitContainerRecordContent.TabIndex = 0;
            // 
            // lvMultiHeatReportList
            // 
            this.lvMultiHeatReportList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvMultiHeatReportList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvPlanId,
            this.colLvHeatId,
            this.colLvTreatmentCount,
            this.colLvCar,
            this.colLvClass,
            this.colLvOperator,
            this.colLvSteelGradeId,
            this.colLvArrivalTime,
            this.colLvDepartTime,
            this.colLvArrivalTemperature,
            this.colLvDepartTemperature,
            this.colLvArDuration,
            this.colLvArConsumption,
            this.colLvPowerDuration,
            this.colLvPowerConsumption,
            this.colLvArDurationAftFeedWire,
            this.colLVArConsumpAftFeedWire,
            this.colLvFeedSpeed});
            this.lvMultiHeatReportList.Font = new System.Drawing.Font("NSimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvMultiHeatReportList.FullRowSelect = true;
            this.lvMultiHeatReportList.GridLines = true;
            this.lvMultiHeatReportList.Location = new System.Drawing.Point(3, 3);
            this.lvMultiHeatReportList.Name = "lvMultiHeatReportList";
            this.lvMultiHeatReportList.Size = new System.Drawing.Size(863, 456);
            this.lvMultiHeatReportList.TabIndex = 2;
            this.lvMultiHeatReportList.UseCompatibleStateImageBehavior = false;
            this.lvMultiHeatReportList.View = System.Windows.Forms.View.Details;
            this.lvMultiHeatReportList.ItemActivate += new System.EventHandler(this.lvMultiHeatReportList_ItemActivate);
            // 
            // colLvPlanId
            // 
            this.colLvPlanId.Text = "计划号";
            this.colLvPlanId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvPlanId.Width = 90;
            // 
            // colLvHeatId
            // 
            this.colLvHeatId.Text = "炉次号";
            this.colLvHeatId.Width = 95;
            // 
            // colLvTreatmentCount
            // 
            this.colLvTreatmentCount.Text = "冶炼次数";
            this.colLvTreatmentCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvTreatmentCount.Width = 80;
            // 
            // colLvCar
            // 
            this.colLvCar.Text = "工位";
            this.colLvCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvCar.Width = 48;
            // 
            // colLvClass
            // 
            this.colLvClass.Text = "班组";
            // 
            // colLvOperator
            // 
            this.colLvOperator.Text = "操作员";
            this.colLvOperator.Width = 70;
            // 
            // colLvSteelGradeId
            // 
            this.colLvSteelGradeId.Text = "钢种号";
            this.colLvSteelGradeId.Width = 85;
            // 
            // colLvArrivalTime
            // 
            this.colLvArrivalTime.Text = "到站时间";
            this.colLvArrivalTime.Width = 160;
            // 
            // colLvDepartTime
            // 
            this.colLvDepartTime.Text = "离站时间";
            this.colLvDepartTime.Width = 160;
            // 
            // colLvArrivalTemperature
            // 
            this.colLvArrivalTemperature.Text = "进站温度";
            this.colLvArrivalTemperature.Width = 80;
            // 
            // colLvDepartTemperature
            // 
            this.colLvDepartTemperature.Text = "离站温度";
            this.colLvDepartTemperature.Width = 80;
            // 
            // colLvArDuration
            // 
            this.colLvArDuration.Text = "吹氩时间";
            this.colLvArDuration.Width = 80;
            // 
            // colLvArConsumption
            // 
            this.colLvArConsumption.Text = "吹氩量";
            // 
            // colLvPowerDuration
            // 
            this.colLvPowerDuration.Text = "通电时间";
            this.colLvPowerDuration.Width = 80;
            // 
            // colLvPowerConsumption
            // 
            this.colLvPowerConsumption.Text = "耗电量";
            // 
            // colLvArDurationAftFeedWire
            // 
            this.colLvArDurationAftFeedWire.Text = "喂丝后吹氩时间";
            this.colLvArDurationAftFeedWire.Width = 125;
            // 
            // colLVArConsumpAftFeedWire
            // 
            this.colLVArConsumpAftFeedWire.Text = "喂丝后氩耗量";
            this.colLVArConsumpAftFeedWire.Width = 110;
            // 
            // colLvFeedSpeed
            // 
            this.colLvFeedSpeed.Text = "喂丝速度";
            this.colLvFeedSpeed.Width = 80;
            // 
            // btnMultiExport
            // 
            this.btnMultiExport.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMultiExport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMultiExport.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMultiExport.Location = new System.Drawing.Point(361, 1);
            this.btnMultiExport.Name = "btnMultiExport";
            this.btnMultiExport.Size = new System.Drawing.Size(158, 43);
            this.btnMultiExport.TabIndex = 10;
            this.btnMultiExport.Text = "导出所选炉次报表";
            this.btnMultiExport.UseVisualStyleBackColor = true;
            this.btnMultiExport.Click += new System.EventHandler(this.btnMultiExport_Click);
            // 
            // btnSearchCurrentMonth
            // 
            this.btnSearchCurrentMonth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearchCurrentMonth.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchCurrentMonth.Location = new System.Drawing.Point(163, 1);
            this.btnSearchCurrentMonth.Name = "btnSearchCurrentMonth";
            this.btnSearchCurrentMonth.Size = new System.Drawing.Size(158, 43);
            this.btnSearchCurrentMonth.TabIndex = 9;
            this.btnSearchCurrentMonth.Text = "查看本月炉次报告";
            this.btnSearchCurrentMonth.UseVisualStyleBackColor = true;
            this.btnSearchCurrentMonth.Click += new System.EventHandler(this.btnSearchCurrentMonth_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(550, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 43);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bgWorkMultiExportExcel
            // 
            this.bgWorkMultiExportExcel.WorkerReportsProgress = true;
            this.bgWorkMultiExportExcel.WorkerSupportsCancellation = true;
            this.bgWorkMultiExportExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkMultiExportExcel_DoWork);
            this.bgWorkMultiExportExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkMultiExportExcel_RunWorkerCompleted);
            this.bgWorkMultiExportExcel.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkMultiExportExcel_ProgressChanged);
            // 
            // MultiHeatReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(879, 579);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiHeatReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "多炉次报告";
            this.Load += new System.EventHandler(this.MultiHeatReportForm_Load);
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
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvMultiHeatReportList;
        private System.Windows.Forms.ColumnHeader colLvHeatId;
        private System.Windows.Forms.ColumnHeader colLvTreatmentCount;
        private System.Windows.Forms.ColumnHeader colLvPlanId;
        private System.Windows.Forms.ColumnHeader colLvCar;
        private System.Windows.Forms.Button btnSearchCurrentMonth;
        private System.Windows.Forms.ColumnHeader colLvSteelGradeId;
        private System.Windows.Forms.ColumnHeader colLvArrivalTime;
        private System.Windows.Forms.ColumnHeader colLvDepartTime;
        private System.Windows.Forms.ColumnHeader colLvArDuration;
        private System.Windows.Forms.ColumnHeader colLvArConsumption;
        private System.Windows.Forms.ColumnHeader colLvPowerDuration;
        private System.Windows.Forms.ColumnHeader colLvPowerConsumption;
        private System.Windows.Forms.ColumnHeader colLvArDurationAftFeedWire;
        private System.Windows.Forms.ColumnHeader colLVArConsumpAftFeedWire;
        private System.Windows.Forms.ColumnHeader colLvFeedSpeed;
        private System.Windows.Forms.ColumnHeader colLvArrivalTemperature;
        private System.Windows.Forms.ColumnHeader colLvDepartTemperature;
        private System.Windows.Forms.ColumnHeader colLvClass;
        private System.Windows.Forms.ColumnHeader colLvOperator;
        private System.Windows.Forms.Button btnMultiExport;
        private System.ComponentModel.BackgroundWorker bgWorkMultiExportExcel;
    }
}