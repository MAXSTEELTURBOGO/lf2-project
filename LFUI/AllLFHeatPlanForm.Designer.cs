namespace LFAutomationUI.LFUI
{
    partial class AllLFHeatPlanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllLFHeatPlanForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlAllHeatPlan = new System.Windows.Forms.TabControl();
            this.tabPageToBeDoneHeatPlan = new System.Windows.Forms.TabPage();
            this.lvNotHeatPlan = new System.Windows.Forms.ListView();
            this.colTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHideStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPlanId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHeatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTreatmentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSteelGrade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLadleId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRouteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageDoneHeatPlan = new System.Windows.Forms.TabPage();
            this.lvEndHeatPlan = new System.Windows.Forms.ListView();
            this.colEndHeatingTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHeatStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageOnGoingHeatPlan = new System.Windows.Forms.TabPage();
            this.lvHeatingPlan = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelHide = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewPlan = new System.Windows.Forms.Button();
            this.btnSetHide = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlAllHeatPlan.SuspendLayout();
            this.tabPageToBeDoneHeatPlan.SuspendLayout();
            this.tabPageDoneHeatPlan.SuspendLayout();
            this.tabPageOnGoingHeatPlan.SuspendLayout();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControlAllHeatPlan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelHide);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddNewPlan);
            this.splitContainer1.Panel2.Controls.Add(this.btnSetHide);
            this.splitContainer1.Size = new System.Drawing.Size(855, 493);
            this.splitContainer1.SplitterDistance = 439;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControlAllHeatPlan
            // 
            this.tabControlAllHeatPlan.Controls.Add(this.tabPageToBeDoneHeatPlan);
            this.tabControlAllHeatPlan.Controls.Add(this.tabPageDoneHeatPlan);
            this.tabControlAllHeatPlan.Controls.Add(this.tabPageOnGoingHeatPlan);
            this.tabControlAllHeatPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAllHeatPlan.Location = new System.Drawing.Point(0, 0);
            this.tabControlAllHeatPlan.Name = "tabControlAllHeatPlan";
            this.tabControlAllHeatPlan.SelectedIndex = 0;
            this.tabControlAllHeatPlan.Size = new System.Drawing.Size(855, 439);
            this.tabControlAllHeatPlan.TabIndex = 2;
            this.tabControlAllHeatPlan.SelectedIndexChanged += new System.EventHandler(this.tabControlAllHeatPlan_SelectedIndexChanged);
            // 
            // tabPageToBeDoneHeatPlan
            // 
            this.tabPageToBeDoneHeatPlan.Controls.Add(this.lvNotHeatPlan);
            this.tabPageToBeDoneHeatPlan.Location = new System.Drawing.Point(4, 23);
            this.tabPageToBeDoneHeatPlan.Name = "tabPageToBeDoneHeatPlan";
            this.tabPageToBeDoneHeatPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageToBeDoneHeatPlan.Size = new System.Drawing.Size(847, 412);
            this.tabPageToBeDoneHeatPlan.TabIndex = 0;
            this.tabPageToBeDoneHeatPlan.Text = "尚未冶炼的炉次";
            this.tabPageToBeDoneHeatPlan.UseVisualStyleBackColor = true;
            // 
            // lvNotHeatPlan
            // 
            this.lvNotHeatPlan.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvNotHeatPlan.CheckBoxes = true;
            this.lvNotHeatPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTag,
            this.colHideStatus,
            this.columnHeaderPlanId,
            this.columnHeaderHeatId,
            this.columnHeaderTreatmentCount,
            this.columnHeaderSteelGrade,
            this.columnHeaderLadleId,
            this.columnHeaderRouteName});
            this.lvNotHeatPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNotHeatPlan.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvNotHeatPlan.FullRowSelect = true;
            this.lvNotHeatPlan.GridLines = true;
            this.lvNotHeatPlan.Location = new System.Drawing.Point(3, 3);
            this.lvNotHeatPlan.MultiSelect = false;
            this.lvNotHeatPlan.Name = "lvNotHeatPlan";
            this.lvNotHeatPlan.Size = new System.Drawing.Size(841, 406);
            this.lvNotHeatPlan.TabIndex = 2;
            this.lvNotHeatPlan.UseCompatibleStateImageBehavior = false;
            this.lvNotHeatPlan.View = System.Windows.Forms.View.Details;
            // 
            // colTag
            // 
            this.colTag.Text = "标记";
            this.colTag.Width = 50;
            // 
            // colHideStatus
            // 
            this.colHideStatus.Text = "隐藏状态";
            this.colHideStatus.Width = 80;
            // 
            // columnHeaderPlanId
            // 
            this.columnHeaderPlanId.Text = "计划号";
            this.columnHeaderPlanId.Width = 100;
            // 
            // columnHeaderHeatId
            // 
            this.columnHeaderHeatId.Text = "炉次号";
            this.columnHeaderHeatId.Width = 90;
            // 
            // columnHeaderTreatmentCount
            // 
            this.columnHeaderTreatmentCount.Text = "处理次数";
            this.columnHeaderTreatmentCount.Width = 80;
            // 
            // columnHeaderSteelGrade
            // 
            this.columnHeaderSteelGrade.Text = "钢种号";
            this.columnHeaderSteelGrade.Width = 95;
            // 
            // columnHeaderLadleId
            // 
            this.columnHeaderLadleId.Text = "钢包号";
            this.columnHeaderLadleId.Width = 80;
            // 
            // columnHeaderRouteName
            // 
            this.columnHeaderRouteName.Text = "冶炼路径";
            this.columnHeaderRouteName.Width = 450;
            // 
            // tabPageDoneHeatPlan
            // 
            this.tabPageDoneHeatPlan.Controls.Add(this.lvEndHeatPlan);
            this.tabPageDoneHeatPlan.Location = new System.Drawing.Point(4, 21);
            this.tabPageDoneHeatPlan.Name = "tabPageDoneHeatPlan";
            this.tabPageDoneHeatPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDoneHeatPlan.Size = new System.Drawing.Size(851, 418);
            this.tabPageDoneHeatPlan.TabIndex = 1;
            this.tabPageDoneHeatPlan.Text = "冶炼结束的炉次";
            this.tabPageDoneHeatPlan.UseVisualStyleBackColor = true;
            // 
            // lvEndHeatPlan
            // 
            this.lvEndHeatPlan.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvEndHeatPlan.CheckBoxes = true;
            this.lvEndHeatPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEndHeatingTag,
            this.columnHeader17,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeaderCar,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeaderHeatStatus,
            this.columnHeader6});
            this.lvEndHeatPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEndHeatPlan.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvEndHeatPlan.FullRowSelect = true;
            this.lvEndHeatPlan.GridLines = true;
            this.lvEndHeatPlan.Location = new System.Drawing.Point(3, 3);
            this.lvEndHeatPlan.MultiSelect = false;
            this.lvEndHeatPlan.Name = "lvEndHeatPlan";
            this.lvEndHeatPlan.Size = new System.Drawing.Size(845, 412);
            this.lvEndHeatPlan.TabIndex = 1;
            this.lvEndHeatPlan.UseCompatibleStateImageBehavior = false;
            this.lvEndHeatPlan.View = System.Windows.Forms.View.Details;
            // 
            // colEndHeatingTag
            // 
            this.colEndHeatingTag.Text = "标记";
            this.colEndHeatingTag.Width = 50;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "隐藏状态";
            this.columnHeader17.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "计划号";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "炉次号";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "处理次数";
            this.columnHeader3.Width = 75;
            // 
            // columnHeaderCar
            // 
            this.columnHeaderCar.Text = "工位";
            this.columnHeaderCar.Width = 45;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "钢种号";
            this.columnHeader4.Width = 95;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "钢包号";
            // 
            // columnHeaderHeatStatus
            // 
            this.columnHeaderHeatStatus.Text = "炉次状态";
            this.columnHeaderHeatStatus.Width = 140;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "冶炼路径";
            this.columnHeader6.Width = 440;
            // 
            // tabPageOnGoingHeatPlan
            // 
            this.tabPageOnGoingHeatPlan.Controls.Add(this.lvHeatingPlan);
            this.tabPageOnGoingHeatPlan.Location = new System.Drawing.Point(4, 21);
            this.tabPageOnGoingHeatPlan.Name = "tabPageOnGoingHeatPlan";
            this.tabPageOnGoingHeatPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOnGoingHeatPlan.Size = new System.Drawing.Size(851, 418);
            this.tabPageOnGoingHeatPlan.TabIndex = 2;
            this.tabPageOnGoingHeatPlan.Text = "正在冶炼的炉次";
            this.tabPageOnGoingHeatPlan.UseVisualStyleBackColor = true;
            // 
            // lvHeatingPlan
            // 
            this.lvHeatingPlan.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvHeatingPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader15,
            this.columnHeader16});
            this.lvHeatingPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHeatingPlan.Enabled = false;
            this.lvHeatingPlan.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvHeatingPlan.FullRowSelect = true;
            this.lvHeatingPlan.GridLines = true;
            this.lvHeatingPlan.Location = new System.Drawing.Point(3, 3);
            this.lvHeatingPlan.MultiSelect = false;
            this.lvHeatingPlan.Name = "lvHeatingPlan";
            this.lvHeatingPlan.Size = new System.Drawing.Size(845, 412);
            this.lvHeatingPlan.TabIndex = 1;
            this.lvHeatingPlan.UseCompatibleStateImageBehavior = false;
            this.lvHeatingPlan.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "计划号";
            this.columnHeader7.Width = 85;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "炉次号";
            this.columnHeader8.Width = 85;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "处理次数";
            this.columnHeader9.Width = 75;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "工位";
            this.columnHeader10.Width = 45;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "钢种号";
            this.columnHeader11.Width = 95;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "钢包号";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "炉次状态";
            this.columnHeader15.Width = 140;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "冶炼路径";
            this.columnHeader16.Width = 440;
            // 
            // btnCancelHide
            // 
            this.btnCancelHide.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancelHide.Location = new System.Drawing.Point(648, 5);
            this.btnCancelHide.Name = "btnCancelHide";
            this.btnCancelHide.Size = new System.Drawing.Size(127, 41);
            this.btnCancelHide.TabIndex = 0;
            this.btnCancelHide.Text = "取消隐藏";
            this.btnCancelHide.UseVisualStyleBackColor = true;
            this.btnCancelHide.Click += new System.EventHandler(this.btnCancelHide_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(775, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(127, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewPlan
            // 
            this.btnAddNewPlan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddNewPlan.Location = new System.Drawing.Point(416, 5);
            this.btnAddNewPlan.Name = "btnAddNewPlan";
            this.btnAddNewPlan.Size = new System.Drawing.Size(116, 41);
            this.btnAddNewPlan.TabIndex = 0;
            this.btnAddNewPlan.Text = "新 增";
            this.btnAddNewPlan.UseVisualStyleBackColor = true;
            this.btnAddNewPlan.Click += new System.EventHandler(this.btnAddNewPlan_Click);
            // 
            // btnSetHide
            // 
            this.btnSetHide.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetHide.Location = new System.Drawing.Point(532, 5);
            this.btnSetHide.Name = "btnSetHide";
            this.btnSetHide.Size = new System.Drawing.Size(116, 41);
            this.btnSetHide.TabIndex = 0;
            this.btnSetHide.Text = "隐 藏";
            this.btnSetHide.UseVisualStyleBackColor = true;
            this.btnSetHide.Click += new System.EventHandler(this.btnSetHide_Click);
            // 
            // AllLFHeatPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(855, 493);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllLFHeatPlanForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "所有炉次计划信息";
            this.Load += new System.EventHandler(this.AllLFHeatPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControlAllHeatPlan.ResumeLayout(false);
            this.tabPageToBeDoneHeatPlan.ResumeLayout(false);
            this.tabPageDoneHeatPlan.ResumeLayout(false);
            this.tabPageOnGoingHeatPlan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlAllHeatPlan;
        private System.Windows.Forms.TabPage tabPageToBeDoneHeatPlan;
        private System.Windows.Forms.TabPage tabPageDoneHeatPlan;
        private System.Windows.Forms.ListView lvEndHeatPlan;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeaderCar;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeaderHeatStatus;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TabPage tabPageOnGoingHeatPlan;
        private System.Windows.Forms.ListView lvHeatingPlan;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSetHide;
        private System.Windows.Forms.Button btnAddNewPlan;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader colEndHeatingTag;
        private System.Windows.Forms.Button btnCancelHide;
        private System.Windows.Forms.ListView lvNotHeatPlan;
        private System.Windows.Forms.ColumnHeader colTag;
        private System.Windows.Forms.ColumnHeader colHideStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderPlanId;
        private System.Windows.Forms.ColumnHeader columnHeaderHeatId;
        private System.Windows.Forms.ColumnHeader columnHeaderTreatmentCount;
        private System.Windows.Forms.ColumnHeader columnHeaderSteelGrade;
        private System.Windows.Forms.ColumnHeader columnHeaderLadleId;
        private System.Windows.Forms.ColumnHeader columnHeaderRouteName;


    }
}