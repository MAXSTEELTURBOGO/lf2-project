namespace LFAutomationUI.LFUI
{
    partial class AdditionMaterialRecordForm
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabControlAddMat = new System.Windows.Forms.TabControl();
            this.tabPageBasicSearch = new System.Windows.Forms.TabPage();
            this.splitContainerRecordContentByHeatId = new System.Windows.Forms.SplitContainer();
            this.splitContainerSearchByHeatId = new System.Windows.Forms.SplitContainer();
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
            this.lvAdditionRecordList = new System.Windows.Forms.ListView();
            this.colLvHeatId = new System.Windows.Forms.ColumnHeader();
            this.colLvTreatmentCount = new System.Windows.Forms.ColumnHeader();
            this.colLvCar = new System.Windows.Forms.ColumnHeader();
            this.colLvTreatmentStation = new System.Windows.Forms.ColumnHeader();
            this.colLvAdditionTime = new System.Windows.Forms.ColumnHeader();
            this.colLvSiloId = new System.Windows.Forms.ColumnHeader();
            this.colLvMaterialId = new System.Windows.Forms.ColumnHeader();
            this.colLvMaterialL3Id = new System.Windows.Forms.ColumnHeader();
            this.colLvMaterialName = new System.Windows.Forms.ColumnHeader();
            this.colLvMaterialType = new System.Windows.Forms.ColumnHeader();
            this.colLvAdditionAmount = new System.Windows.Forms.ColumnHeader();
            this.tabPageClassSearch = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvAddSumByClass = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.btnSearchRecentRecord = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabControlAddMat.SuspendLayout();
            this.tabPageBasicSearch.SuspendLayout();
            this.splitContainerRecordContentByHeatId.Panel1.SuspendLayout();
            this.splitContainerRecordContentByHeatId.Panel2.SuspendLayout();
            this.splitContainerRecordContentByHeatId.SuspendLayout();
            this.splitContainerSearchByHeatId.Panel1.SuspendLayout();
            this.splitContainerSearchByHeatId.Panel2.SuspendLayout();
            this.splitContainerSearchByHeatId.SuspendLayout();
            this.gBoxSearchByHeatId.SuspendLayout();
            this.gBoxSearchByDate.SuspendLayout();
            this.tabPageClassSearch.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainerMain.Panel1.Controls.Add(this.tabControlAddMat);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.btnSearchRecentRecord);
            this.splitContainerMain.Panel2.Controls.Add(this.btnClose);
            this.splitContainerMain.Size = new System.Drawing.Size(916, 575);
            this.splitContainerMain.SplitterDistance = 519;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabControlAddMat
            // 
            this.tabControlAddMat.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlAddMat.Controls.Add(this.tabPageBasicSearch);
            this.tabControlAddMat.Controls.Add(this.tabPageClassSearch);
            this.tabControlAddMat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAddMat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlAddMat.Location = new System.Drawing.Point(0, 0);
            this.tabControlAddMat.Name = "tabControlAddMat";
            this.tabControlAddMat.SelectedIndex = 0;
            this.tabControlAddMat.Size = new System.Drawing.Size(912, 515);
            this.tabControlAddMat.TabIndex = 0;
            // 
            // tabPageBasicSearch
            // 
            this.tabPageBasicSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageBasicSearch.Controls.Add(this.splitContainerRecordContentByHeatId);
            this.tabPageBasicSearch.Location = new System.Drawing.Point(4, 33);
            this.tabPageBasicSearch.Name = "tabPageBasicSearch";
            this.tabPageBasicSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasicSearch.Size = new System.Drawing.Size(904, 478);
            this.tabPageBasicSearch.TabIndex = 0;
            this.tabPageBasicSearch.Text = "按照炉次或日期查询";
            this.tabPageBasicSearch.UseVisualStyleBackColor = true;
            // 
            // splitContainerRecordContentByHeatId
            // 
            this.splitContainerRecordContentByHeatId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerRecordContentByHeatId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRecordContentByHeatId.Location = new System.Drawing.Point(3, 3);
            this.splitContainerRecordContentByHeatId.Name = "splitContainerRecordContentByHeatId";
            this.splitContainerRecordContentByHeatId.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRecordContentByHeatId.Panel1
            // 
            this.splitContainerRecordContentByHeatId.Panel1.Controls.Add(this.splitContainerSearchByHeatId);
            // 
            // splitContainerRecordContentByHeatId.Panel2
            // 
            this.splitContainerRecordContentByHeatId.Panel2.Controls.Add(this.lvAdditionRecordList);
            this.splitContainerRecordContentByHeatId.Size = new System.Drawing.Size(894, 468);
            this.splitContainerRecordContentByHeatId.SplitterDistance = 56;
            this.splitContainerRecordContentByHeatId.TabIndex = 2;
            // 
            // splitContainerSearchByHeatId
            // 
            this.splitContainerSearchByHeatId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerSearchByHeatId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSearchByHeatId.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSearchByHeatId.Name = "splitContainerSearchByHeatId";
            // 
            // splitContainerSearchByHeatId.Panel1
            // 
            this.splitContainerSearchByHeatId.Panel1.Controls.Add(this.gBoxSearchByHeatId);
            // 
            // splitContainerSearchByHeatId.Panel2
            // 
            this.splitContainerSearchByHeatId.Panel2.Controls.Add(this.gBoxSearchByDate);
            this.splitContainerSearchByHeatId.Size = new System.Drawing.Size(894, 56);
            this.splitContainerSearchByHeatId.SplitterDistance = 393;
            this.splitContainerSearchByHeatId.TabIndex = 1;
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
            this.gBoxSearchByHeatId.Size = new System.Drawing.Size(385, 42);
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
            // 
            // btnSearchByHeatId
            // 
            this.btnSearchByHeatId.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchByHeatId.Location = new System.Drawing.Point(316, 10);
            this.btnSearchByHeatId.Name = "btnSearchByHeatId";
            this.btnSearchByHeatId.Size = new System.Drawing.Size(63, 28);
            this.btnSearchByHeatId.TabIndex = 3;
            this.btnSearchByHeatId.Text = "查 询";
            this.btnSearchByHeatId.UseVisualStyleBackColor = true;
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
            this.gBoxSearchByDate.Size = new System.Drawing.Size(491, 42);
            this.gBoxSearchByDate.TabIndex = 1;
            this.gBoxSearchByDate.TabStop = false;
            this.gBoxSearchByDate.Text = "按日期查询";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEndDate.Location = new System.Drawing.Point(275, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(131, 23);
            this.dtpEndDate.TabIndex = 9;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "";
            this.dtpStartDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStartDate.Location = new System.Drawing.Point(69, 13);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(131, 23);
            this.dtpStartDate.TabIndex = 9;
            // 
            // btnSearchByDate
            // 
            this.btnSearchByDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchByDate.Location = new System.Drawing.Point(422, 10);
            this.btnSearchByDate.Name = "btnSearchByDate";
            this.btnSearchByDate.Size = new System.Drawing.Size(63, 28);
            this.btnSearchByDate.TabIndex = 8;
            this.btnSearchByDate.Text = "查 询";
            this.btnSearchByDate.UseVisualStyleBackColor = true;
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
            // lvAdditionRecordList
            // 
            this.lvAdditionRecordList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLvHeatId,
            this.colLvTreatmentCount,
            this.colLvCar,
            this.colLvTreatmentStation,
            this.colLvAdditionTime,
            this.colLvSiloId,
            this.colLvMaterialId,
            this.colLvMaterialL3Id,
            this.colLvMaterialName,
            this.colLvMaterialType,
            this.colLvAdditionAmount});
            this.lvAdditionRecordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAdditionRecordList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvAdditionRecordList.FullRowSelect = true;
            this.lvAdditionRecordList.GridLines = true;
            this.lvAdditionRecordList.Location = new System.Drawing.Point(0, 0);
            this.lvAdditionRecordList.MultiSelect = false;
            this.lvAdditionRecordList.Name = "lvAdditionRecordList";
            this.lvAdditionRecordList.Size = new System.Drawing.Size(890, 404);
            this.lvAdditionRecordList.TabIndex = 1;
            this.lvAdditionRecordList.UseCompatibleStateImageBehavior = false;
            this.lvAdditionRecordList.View = System.Windows.Forms.View.Details;
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
            this.colLvTreatmentCount.Width = 72;
            // 
            // colLvCar
            // 
            this.colLvCar.Text = "小车号";
            this.colLvCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvCar.Width = 58;
            // 
            // colLvTreatmentStation
            // 
            this.colLvTreatmentStation.Text = "处理站";
            this.colLvTreatmentStation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colLvAdditionTime
            // 
            this.colLvAdditionTime.Text = "加料时间";
            this.colLvAdditionTime.Width = 160;
            // 
            // colLvSiloId
            // 
            this.colLvSiloId.Text = "料仓号";
            this.colLvSiloId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvSiloId.Width = 58;
            // 
            // colLvMaterialId
            // 
            this.colLvMaterialId.Text = "物料ID";
            this.colLvMaterialId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colLvMaterialL3Id
            // 
            this.colLvMaterialL3Id.Text = "物料三级ID";
            this.colLvMaterialL3Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvMaterialL3Id.Width = 85;
            // 
            // colLvMaterialName
            // 
            this.colLvMaterialName.Text = "物料名称";
            this.colLvMaterialName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvMaterialName.Width = 80;
            // 
            // colLvMaterialType
            // 
            this.colLvMaterialType.Text = "加料类型";
            this.colLvMaterialType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvMaterialType.Width = 72;
            // 
            // colLvAdditionAmount
            // 
            this.colLvAdditionAmount.Text = "加料重量";
            this.colLvAdditionAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLvAdditionAmount.Width = 90;
            // 
            // tabPageClassSearch
            // 
            this.tabPageClassSearch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageClassSearch.Controls.Add(this.splitContainer1);
            this.tabPageClassSearch.Location = new System.Drawing.Point(4, 33);
            this.tabPageClassSearch.Name = "tabPageClassSearch";
            this.tabPageClassSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClassSearch.Size = new System.Drawing.Size(904, 478);
            this.tabPageClassSearch.TabIndex = 1;
            this.tabPageClassSearch.Text = "按照班组日期查询";
            this.tabPageClassSearch.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvAddSumByClass);
            this.splitContainer1.Size = new System.Drawing.Size(894, 468);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblClass);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(886, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "按日期查询";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(670, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 28);
            this.comboBox1.TabIndex = 10;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日  HH:mm:ss";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(394, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 26);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy年MM月dd日  HH:mm:ss";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(85, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(224, 26);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(785, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "查 询";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "起始日期：";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(624, 16);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(57, 20);
            this.lblClass.TabIndex = 5;
            this.lblClass.Text = "班组：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(315, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "截止日期：";
            // 
            // lvAddSumByClass
            // 
            this.lvAddSumByClass.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader11});
            this.lvAddSumByClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAddSumByClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAddSumByClass.FullRowSelect = true;
            this.lvAddSumByClass.GridLines = true;
            this.lvAddSumByClass.Location = new System.Drawing.Point(0, 0);
            this.lvAddSumByClass.MultiSelect = false;
            this.lvAddSumByClass.Name = "lvAddSumByClass";
            this.lvAddSumByClass.Size = new System.Drawing.Size(890, 405);
            this.lvAddSumByClass.TabIndex = 1;
            this.lvAddSumByClass.UseCompatibleStateImageBehavior = false;
            this.lvAddSumByClass.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "物料名称";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "加料重量";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 120;
            // 
            // btnSearchRecentRecord
            // 
            this.btnSearchRecentRecord.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearchRecentRecord.Location = new System.Drawing.Point(295, 3);
            this.btnSearchRecentRecord.Name = "btnSearchRecentRecord";
            this.btnSearchRecentRecord.Size = new System.Drawing.Size(152, 43);
            this.btnSearchRecentRecord.TabIndex = 11;
            this.btnSearchRecentRecord.Text = "查看当日加料记录";
            this.btnSearchRecentRecord.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(478, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 43);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Controls.Add(this.splitContainerMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(920, 579);
            this.panelMain.TabIndex = 0;
            // 
            // AdditionMaterialRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 579);
            this.ControlBox = false;
            this.Controls.Add(this.panelMain);
            this.MinimizeBox = false;
            this.Name = "AdditionMaterialRecordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "加料记录信息界面";
            this.Load += new System.EventHandler(this.AdditionMaterialRecordForm_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            this.tabControlAddMat.ResumeLayout(false);
            this.tabPageBasicSearch.ResumeLayout(false);
            this.splitContainerRecordContentByHeatId.Panel1.ResumeLayout(false);
            this.splitContainerRecordContentByHeatId.Panel2.ResumeLayout(false);
            this.splitContainerRecordContentByHeatId.ResumeLayout(false);
            this.splitContainerSearchByHeatId.Panel1.ResumeLayout(false);
            this.splitContainerSearchByHeatId.Panel2.ResumeLayout(false);
            this.splitContainerSearchByHeatId.ResumeLayout(false);
            this.gBoxSearchByHeatId.ResumeLayout(false);
            this.gBoxSearchByHeatId.PerformLayout();
            this.gBoxSearchByDate.ResumeLayout(false);
            this.gBoxSearchByDate.PerformLayout();
            this.tabPageClassSearch.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnSearchRecentRecord;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControlAddMat;
        private System.Windows.Forms.TabPage tabPageBasicSearch;
        private System.Windows.Forms.SplitContainer splitContainerRecordContentByHeatId;
        private System.Windows.Forms.SplitContainer splitContainerSearchByHeatId;
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
        private System.Windows.Forms.ListView lvAdditionRecordList;
        private System.Windows.Forms.ColumnHeader colLvHeatId;
        private System.Windows.Forms.ColumnHeader colLvTreatmentCount;
        private System.Windows.Forms.ColumnHeader colLvCar;
        private System.Windows.Forms.ColumnHeader colLvTreatmentStation;
        private System.Windows.Forms.ColumnHeader colLvAdditionTime;
        private System.Windows.Forms.ColumnHeader colLvSiloId;
        private System.Windows.Forms.ColumnHeader colLvMaterialId;
        private System.Windows.Forms.ColumnHeader colLvMaterialL3Id;
        private System.Windows.Forms.ColumnHeader colLvMaterialName;
        private System.Windows.Forms.ColumnHeader colLvMaterialType;
        private System.Windows.Forms.ColumnHeader colLvAdditionAmount;
        private System.Windows.Forms.TabPage tabPageClassSearch;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvAddSumByClass;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblClass;

    }
}