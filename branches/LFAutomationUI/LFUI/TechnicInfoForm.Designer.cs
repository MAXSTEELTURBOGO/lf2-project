namespace LFAutomationUI.LFUI
{
    partial class TechnicInfoForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("工艺名称");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerTechnicMaintenanceInfo = new System.Windows.Forms.SplitContainer();
            this.lvStepInfo = new System.Windows.Forms.ListView();
            this.columnHeaderStepId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStepName = new System.Windows.Forms.ColumnHeader();
            this.treeViewTechnicList = new System.Windows.Forms.TreeView();
            this.splitContainerTechnicViewerAndConfiger = new System.Windows.Forms.SplitContainer();
            this.dgvTechnicStepInfo = new System.Windows.Forms.DataGridView();
            this.dgvColBtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dgvColSequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColStepId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColStepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanPowerDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanTopArConsump = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColPlanBottomArConsumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTapPosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColTapPositionPoint = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvColTapVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTapCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTapPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTempChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnResetTechnicSteps = new System.Windows.Forms.Button();
            this.btnModifyTechnic = new System.Windows.Forms.Button();
            this.btnDeleteTechnic = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCopyTechnic = new System.Windows.Forms.Button();
            this.btnNewTechnic = new System.Windows.Forms.Button();
            this.panelTechnicBasicInfo = new System.Windows.Forms.Panel();
            this.txtTechnicName = new System.Windows.Forms.TextBox();
            this.lblTechnicName = new System.Windows.Forms.Label();
            this.txtTechnicId = new System.Windows.Forms.TextBox();
            this.lblTechnicId = new System.Windows.Forms.Label();
            this.splitContainerTechnicMaintenanceInfo.Panel1.SuspendLayout();
            this.splitContainerTechnicMaintenanceInfo.Panel2.SuspendLayout();
            this.splitContainerTechnicMaintenanceInfo.SuspendLayout();
            this.splitContainerTechnicViewerAndConfiger.Panel1.SuspendLayout();
            this.splitContainerTechnicViewerAndConfiger.Panel2.SuspendLayout();
            this.splitContainerTechnicViewerAndConfiger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicStepInfo)).BeginInit();
            this.panelTechnicBasicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerTechnicMaintenanceInfo
            // 
            this.splitContainerTechnicMaintenanceInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTechnicMaintenanceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTechnicMaintenanceInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTechnicMaintenanceInfo.Name = "splitContainerTechnicMaintenanceInfo";
            // 
            // splitContainerTechnicMaintenanceInfo.Panel1
            // 
            this.splitContainerTechnicMaintenanceInfo.Panel1.Controls.Add(this.lvStepInfo);
            this.splitContainerTechnicMaintenanceInfo.Panel1.Controls.Add(this.treeViewTechnicList);
            // 
            // splitContainerTechnicMaintenanceInfo.Panel2
            // 
            this.splitContainerTechnicMaintenanceInfo.Panel2.Controls.Add(this.splitContainerTechnicViewerAndConfiger);
            this.splitContainerTechnicMaintenanceInfo.Size = new System.Drawing.Size(884, 430);
            this.splitContainerTechnicMaintenanceInfo.SplitterDistance = 161;
            this.splitContainerTechnicMaintenanceInfo.SplitterWidth = 5;
            this.splitContainerTechnicMaintenanceInfo.TabIndex = 0;
            // 
            // lvStepInfo
            // 
            this.lvStepInfo.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvStepInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStepId,
            this.columnHeaderStepName});
            this.lvStepInfo.FullRowSelect = true;
            this.lvStepInfo.GridLines = true;
            this.lvStepInfo.Location = new System.Drawing.Point(3, 3);
            this.lvStepInfo.MultiSelect = false;
            this.lvStepInfo.Name = "lvStepInfo";
            this.lvStepInfo.Size = new System.Drawing.Size(156, 425);
            this.lvStepInfo.TabIndex = 1;
            this.lvStepInfo.UseCompatibleStateImageBehavior = false;
            this.lvStepInfo.View = System.Windows.Forms.View.Details;
            this.lvStepInfo.Visible = false;
            this.lvStepInfo.ItemActivate += new System.EventHandler(this.lvStepInfo_ItemActivate);
            // 
            // columnHeaderStepId
            // 
            this.columnHeaderStepId.Text = "NO";
            this.columnHeaderStepId.Width = 30;
            // 
            // columnHeaderStepName
            // 
            this.columnHeaderStepName.Text = "步骤名称";
            this.columnHeaderStepName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderStepName.Width = 120;
            // 
            // treeViewTechnicList
            // 
            this.treeViewTechnicList.Location = new System.Drawing.Point(3, 3);
            this.treeViewTechnicList.Name = "treeViewTechnicList";
            treeNode1.Name = "TreeViewTechnicNode";
            treeNode1.Text = "工艺名称";
            this.treeViewTechnicList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewTechnicList.Size = new System.Drawing.Size(156, 425);
            this.treeViewTechnicList.TabIndex = 0;
            this.treeViewTechnicList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewTechnicList_NodeMouseClick);
            // 
            // splitContainerTechnicViewerAndConfiger
            // 
            this.splitContainerTechnicViewerAndConfiger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTechnicViewerAndConfiger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTechnicViewerAndConfiger.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTechnicViewerAndConfiger.Name = "splitContainerTechnicViewerAndConfiger";
            this.splitContainerTechnicViewerAndConfiger.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTechnicViewerAndConfiger.Panel1
            // 
            this.splitContainerTechnicViewerAndConfiger.Panel1.Controls.Add(this.dgvTechnicStepInfo);
            // 
            // splitContainerTechnicViewerAndConfiger.Panel2
            // 
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnClose);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnResetTechnicSteps);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnModifyTechnic);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnDeleteTechnic);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnCopyTechnic);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.btnNewTechnic);
            this.splitContainerTechnicViewerAndConfiger.Panel2.Controls.Add(this.panelTechnicBasicInfo);
            this.splitContainerTechnicViewerAndConfiger.Size = new System.Drawing.Size(718, 430);
            this.splitContainerTechnicViewerAndConfiger.SplitterDistance = 306;
            this.splitContainerTechnicViewerAndConfiger.SplitterWidth = 5;
            this.splitContainerTechnicViewerAndConfiger.TabIndex = 0;
            // 
            // dgvTechnicStepInfo
            // 
            this.dgvTechnicStepInfo.AllowUserToAddRows = false;
            this.dgvTechnicStepInfo.AllowUserToDeleteRows = false;
            this.dgvTechnicStepInfo.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvTechnicStepInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTechnicStepInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTechnicStepInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTechnicStepInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColBtnDelete,
            this.dgvColSequence,
            this.dgvColStepId,
            this.dgvColStepName,
            this.dgvColPlanDuration,
            this.dgvColPlanPowerDuration,
            this.dgvColPlanTopArConsump,
            this.dgvColPlanBottomArConsumption,
            this.dgvColTapPosition,
            this.dgvColTapPositionPoint,
            this.dgvColTapVoltage,
            this.dgvColTapCurrent,
            this.dgvColTapPower,
            this.dgvColTempChange});
            this.dgvTechnicStepInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvTechnicStepInfo.Name = "dgvTechnicStepInfo";
            this.dgvTechnicStepInfo.ReadOnly = true;
            this.dgvTechnicStepInfo.RowHeadersWidth = 4;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTechnicStepInfo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTechnicStepInfo.RowTemplate.Height = 23;
            this.dgvTechnicStepInfo.Size = new System.Drawing.Size(711, 301);
            this.dgvTechnicStepInfo.TabIndex = 0;
            this.dgvTechnicStepInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTechnicStepInfo_CellValueChanged);
            this.dgvTechnicStepInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTechnicStepInfo_CellContentClick);
            // 
            // dgvColBtnDelete
            // 
            this.dgvColBtnDelete.HeaderText = "";
            this.dgvColBtnDelete.Name = "dgvColBtnDelete";
            this.dgvColBtnDelete.ReadOnly = true;
            this.dgvColBtnDelete.Text = "删除";
            this.dgvColBtnDelete.Visible = false;
            this.dgvColBtnDelete.Width = 40;
            // 
            // dgvColSequence
            // 
            this.dgvColSequence.HeaderText = "顺序";
            this.dgvColSequence.Name = "dgvColSequence";
            this.dgvColSequence.ReadOnly = true;
            this.dgvColSequence.Width = 50;
            // 
            // dgvColStepId
            // 
            this.dgvColStepId.HeaderText = "步骤号";
            this.dgvColStepId.Name = "dgvColStepId";
            this.dgvColStepId.ReadOnly = true;
            this.dgvColStepId.Visible = false;
            // 
            // dgvColStepName
            // 
            this.dgvColStepName.HeaderText = "步骤名称";
            this.dgvColStepName.Name = "dgvColStepName";
            this.dgvColStepName.ReadOnly = true;
            this.dgvColStepName.Width = 80;
            // 
            // dgvColPlanDuration
            // 
            dataGridViewCellStyle2.NullValue = "0";
            this.dgvColPlanDuration.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColPlanDuration.HeaderText = "计划持续时间";
            this.dgvColPlanDuration.Name = "dgvColPlanDuration";
            this.dgvColPlanDuration.ReadOnly = true;
            // 
            // dgvColPlanPowerDuration
            // 
            dataGridViewCellStyle3.NullValue = "0";
            this.dgvColPlanPowerDuration.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvColPlanPowerDuration.HeaderText = "计划加电时间";
            this.dgvColPlanPowerDuration.Name = "dgvColPlanPowerDuration";
            this.dgvColPlanPowerDuration.ReadOnly = true;
            // 
            // dgvColPlanTopArConsump
            // 
            dataGridViewCellStyle4.NullValue = "0";
            this.dgvColPlanTopArConsump.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvColPlanTopArConsump.HeaderText = "计划顶吹氩量";
            this.dgvColPlanTopArConsump.Name = "dgvColPlanTopArConsump";
            this.dgvColPlanTopArConsump.ReadOnly = true;
            // 
            // dgvColPlanBottomArConsumption
            // 
            dataGridViewCellStyle5.NullValue = "0";
            this.dgvColPlanBottomArConsumption.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvColPlanBottomArConsumption.HeaderText = "计划底吹氩量";
            this.dgvColPlanBottomArConsumption.Name = "dgvColPlanBottomArConsumption";
            this.dgvColPlanBottomArConsumption.ReadOnly = true;
            // 
            // dgvColTapPosition
            // 
            dataGridViewCellStyle6.NullValue = "1";
            this.dgvColTapPosition.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvColTapPosition.HeaderText = "档位";
            this.dgvColTapPosition.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13"});
            this.dgvColTapPosition.Name = "dgvColTapPosition";
            this.dgvColTapPosition.ReadOnly = true;
            this.dgvColTapPosition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTapPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTapPosition.Width = 55;
            // 
            // dgvColTapPositionPoint
            // 
            dataGridViewCellStyle7.NullValue = "1";
            this.dgvColTapPositionPoint.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvColTapPositionPoint.HeaderText = "设定点";
            this.dgvColTapPositionPoint.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.dgvColTapPositionPoint.Name = "dgvColTapPositionPoint";
            this.dgvColTapPositionPoint.ReadOnly = true;
            this.dgvColTapPositionPoint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColTapPositionPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColTapPositionPoint.Width = 70;
            // 
            // dgvColTapVoltage
            // 
            this.dgvColTapVoltage.HeaderText = "档位电压";
            this.dgvColTapVoltage.Name = "dgvColTapVoltage";
            this.dgvColTapVoltage.ReadOnly = true;
            this.dgvColTapVoltage.Width = 80;
            // 
            // dgvColTapCurrent
            // 
            this.dgvColTapCurrent.HeaderText = "档位电流";
            this.dgvColTapCurrent.Name = "dgvColTapCurrent";
            this.dgvColTapCurrent.ReadOnly = true;
            this.dgvColTapCurrent.Width = 80;
            // 
            // dgvColTapPower
            // 
            this.dgvColTapPower.HeaderText = "档位功率";
            this.dgvColTapPower.Name = "dgvColTapPower";
            this.dgvColTapPower.ReadOnly = true;
            this.dgvColTapPower.Width = 80;
            // 
            // dgvColTempChange
            // 
            this.dgvColTempChange.HeaderText = "温升值";
            this.dgvColTempChange.Name = "dgvColTempChange";
            this.dgvColTempChange.ReadOnly = true;
            this.dgvColTempChange.Width = 70;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(609, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnResetTechnicSteps
            // 
            this.btnResetTechnicSteps.Enabled = false;
            this.btnResetTechnicSteps.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetTechnicSteps.Location = new System.Drawing.Point(432, 15);
            this.btnResetTechnicSteps.Name = "btnResetTechnicSteps";
            this.btnResetTechnicSteps.Size = new System.Drawing.Size(145, 41);
            this.btnResetTechnicSteps.TabIndex = 5;
            this.btnResetTechnicSteps.Text = "重新选择工艺步骤";
            this.btnResetTechnicSteps.UseVisualStyleBackColor = true;
            this.btnResetTechnicSteps.Click += new System.EventHandler(this.btnResetTechnicSteps_Click);
            // 
            // btnModifyTechnic
            // 
            this.btnModifyTechnic.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyTechnic.Location = new System.Drawing.Point(255, 69);
            this.btnModifyTechnic.Name = "btnModifyTechnic";
            this.btnModifyTechnic.Size = new System.Drawing.Size(86, 41);
            this.btnModifyTechnic.TabIndex = 4;
            this.btnModifyTechnic.Text = "修 改";
            this.btnModifyTechnic.UseVisualStyleBackColor = true;
            this.btnModifyTechnic.Click += new System.EventHandler(this.btnModifyTechnic_Click);
            // 
            // btnDeleteTechnic
            // 
            this.btnDeleteTechnic.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteTechnic.Location = new System.Drawing.Point(373, 69);
            this.btnDeleteTechnic.Name = "btnDeleteTechnic";
            this.btnDeleteTechnic.Size = new System.Drawing.Size(86, 41);
            this.btnDeleteTechnic.TabIndex = 4;
            this.btnDeleteTechnic.Text = "删 除";
            this.btnDeleteTechnic.UseVisualStyleBackColor = true;
            this.btnDeleteTechnic.Click += new System.EventHandler(this.btnDeleteTechnic_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(491, 69);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(86, 41);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "确 认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(609, 69);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 41);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCopyTechnic
            // 
            this.btnCopyTechnic.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCopyTechnic.Location = new System.Drawing.Point(137, 69);
            this.btnCopyTechnic.Name = "btnCopyTechnic";
            this.btnCopyTechnic.Size = new System.Drawing.Size(86, 41);
            this.btnCopyTechnic.TabIndex = 1;
            this.btnCopyTechnic.Text = "复 制";
            this.btnCopyTechnic.UseVisualStyleBackColor = true;
            this.btnCopyTechnic.Click += new System.EventHandler(this.btnCopyTechnic_Click);
            // 
            // btnNewTechnic
            // 
            this.btnNewTechnic.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNewTechnic.Location = new System.Drawing.Point(19, 69);
            this.btnNewTechnic.Name = "btnNewTechnic";
            this.btnNewTechnic.Size = new System.Drawing.Size(86, 41);
            this.btnNewTechnic.TabIndex = 1;
            this.btnNewTechnic.Text = "新 增";
            this.btnNewTechnic.UseVisualStyleBackColor = true;
            this.btnNewTechnic.Click += new System.EventHandler(this.btnNewTechnic_Click);
            // 
            // panelTechnicBasicInfo
            // 
            this.panelTechnicBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTechnicBasicInfo.Controls.Add(this.txtTechnicName);
            this.panelTechnicBasicInfo.Controls.Add(this.lblTechnicName);
            this.panelTechnicBasicInfo.Controls.Add(this.txtTechnicId);
            this.panelTechnicBasicInfo.Controls.Add(this.lblTechnicId);
            this.panelTechnicBasicInfo.Font = new System.Drawing.Font("NSimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelTechnicBasicInfo.Location = new System.Drawing.Point(19, 8);
            this.panelTechnicBasicInfo.Name = "panelTechnicBasicInfo";
            this.panelTechnicBasicInfo.Size = new System.Drawing.Size(395, 55);
            this.panelTechnicBasicInfo.TabIndex = 0;
            // 
            // txtTechnicName
            // 
            this.txtTechnicName.Location = new System.Drawing.Point(239, 12);
            this.txtTechnicName.Name = "txtTechnicName";
            this.txtTechnicName.ReadOnly = true;
            this.txtTechnicName.Size = new System.Drawing.Size(141, 26);
            this.txtTechnicName.TabIndex = 1;
            this.txtTechnicName.TextChanged += new System.EventHandler(this.txtTechnicName_TextChanged);
            // 
            // lblTechnicName
            // 
            this.lblTechnicName.AutoSize = true;
            this.lblTechnicName.Location = new System.Drawing.Point(161, 17);
            this.lblTechnicName.Name = "lblTechnicName";
            this.lblTechnicName.Size = new System.Drawing.Size(72, 16);
            this.lblTechnicName.TabIndex = 0;
            this.lblTechnicName.Text = "工艺名称";
            // 
            // txtTechnicId
            // 
            this.txtTechnicId.Location = new System.Drawing.Point(72, 12);
            this.txtTechnicId.Name = "txtTechnicId";
            this.txtTechnicId.ReadOnly = true;
            this.txtTechnicId.Size = new System.Drawing.Size(83, 26);
            this.txtTechnicId.TabIndex = 1;
            // 
            // lblTechnicId
            // 
            this.lblTechnicId.AutoSize = true;
            this.lblTechnicId.Location = new System.Drawing.Point(10, 17);
            this.lblTechnicId.Name = "lblTechnicId";
            this.lblTechnicId.Size = new System.Drawing.Size(56, 16);
            this.lblTechnicId.TabIndex = 0;
            this.lblTechnicId.Text = "工艺号";
            // 
            // TechnicInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(884, 430);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerTechnicMaintenanceInfo);
            this.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TechnicInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工艺维护界面";
            this.Load += new System.EventHandler(this.TechnicInfoForm_Load);
            this.splitContainerTechnicMaintenanceInfo.Panel1.ResumeLayout(false);
            this.splitContainerTechnicMaintenanceInfo.Panel2.ResumeLayout(false);
            this.splitContainerTechnicMaintenanceInfo.ResumeLayout(false);
            this.splitContainerTechnicViewerAndConfiger.Panel1.ResumeLayout(false);
            this.splitContainerTechnicViewerAndConfiger.Panel2.ResumeLayout(false);
            this.splitContainerTechnicViewerAndConfiger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTechnicStepInfo)).EndInit();
            this.panelTechnicBasicInfo.ResumeLayout(false);
            this.panelTechnicBasicInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerTechnicMaintenanceInfo;
        private System.Windows.Forms.TreeView treeViewTechnicList;
        private System.Windows.Forms.SplitContainer splitContainerTechnicViewerAndConfiger;
        private System.Windows.Forms.ListView lvStepInfo;
        private System.Windows.Forms.DataGridView dgvTechnicStepInfo;
        private System.Windows.Forms.Panel panelTechnicBasicInfo;
        private System.Windows.Forms.Label lblTechnicId;
        private System.Windows.Forms.TextBox txtTechnicName;
        private System.Windows.Forms.Label lblTechnicName;
        private System.Windows.Forms.TextBox txtTechnicId;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResetTechnicSteps;
        private System.Windows.Forms.Button btnModifyTechnic;
        private System.Windows.Forms.Button btnDeleteTechnic;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCopyTechnic;
        private System.Windows.Forms.Button btnNewTechnic;
        private System.Windows.Forms.ColumnHeader columnHeaderStepId;
        private System.Windows.Forms.ColumnHeader columnHeaderStepName;
        private System.Windows.Forms.DataGridViewButtonColumn dgvColBtnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColSequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColStepId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColStepName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPlanDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPlanPowerDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPlanTopArConsump;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColPlanBottomArConsumption;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTapPosition;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvColTapPositionPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTapVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTapCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTapPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTempChange;


    }
}