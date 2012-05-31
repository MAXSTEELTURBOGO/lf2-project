namespace LFAutomationUI.LFUI
{
    partial class MaterialInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMaterialDetailInfo = new System.Windows.Forms.SplitContainer();
            this.splitContainerMaterialBasicInfo = new System.Windows.Forms.SplitContainer();
            this.gBoxBasicInfo = new System.Windows.Forms.GroupBox();
            this.txtFeContent = new System.Windows.Forms.TextBox();
            this.lblFeContent = new System.Windows.Forms.Label();
            this.cmbMaterialNote = new System.Windows.Forms.ComboBox();
            this.cmbMaterialType = new System.Windows.Forms.ComboBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.lblMaterialNote = new System.Windows.Forms.Label();
            this.lblMaterialClass = new System.Windows.Forms.Label();
            this.txtMaterialDescription = new System.Windows.Forms.TextBox();
            this.txtWireWgt = new System.Windows.Forms.TextBox();
            this.txtBulkWgt = new System.Windows.Forms.TextBox();
            this.txtMaterialYield = new System.Windows.Forms.TextBox();
            this.txtChillRate = new System.Windows.Forms.TextBox();
            this.txtL3MaterialId = new System.Windows.Forms.TextBox();
            this.txtMaterialId = new System.Windows.Forms.TextBox();
            this.lblMaterialDescription = new System.Windows.Forms.Label();
            this.lblWireWgt = new System.Windows.Forms.Label();
            this.lblBulkWgt = new System.Windows.Forms.Label();
            this.lblMaterialYield = new System.Windows.Forms.Label();
            this.lblChillRate = new System.Windows.Forms.Label();
            this.lblL3MaterialId = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblMaterialId = new System.Windows.Forms.Label();
            this.splitContainerMaterialElementInfo = new System.Windows.Forms.SplitContainer();
            this.gBoxSlagElementInfo = new System.Windows.Forms.GroupBox();
            this.dgvCompoundAnalysis = new System.Windows.Forms.DataGridView();
            this.ColCompoundShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCompoundNetContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBoxAlloyElementInfo = new System.Windows.Forms.GroupBox();
            this.dgvElementAnalysis = new System.Windows.Forms.DataGridView();
            this.ColElementShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNetContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColYield = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDeleteElementInfo = new System.Windows.Forms.Button();
            this.btnModifyElementInfo = new System.Windows.Forms.Button();
            this.btnAddNewElementInfo = new System.Windows.Forms.Button();
            this.gBoxMaterialList = new System.Windows.Forms.GroupBox();
            this.lvMaterialList = new System.Windows.Forms.ListView();
            this.splitContainerUI = new System.Windows.Forms.SplitContainer();
            this.splitContainerMaterialDetailInfo.Panel1.SuspendLayout();
            this.splitContainerMaterialDetailInfo.Panel2.SuspendLayout();
            this.splitContainerMaterialDetailInfo.SuspendLayout();
            this.splitContainerMaterialBasicInfo.Panel1.SuspendLayout();
            this.splitContainerMaterialBasicInfo.Panel2.SuspendLayout();
            this.splitContainerMaterialBasicInfo.SuspendLayout();
            this.gBoxBasicInfo.SuspendLayout();
            this.splitContainerMaterialElementInfo.Panel1.SuspendLayout();
            this.splitContainerMaterialElementInfo.Panel2.SuspendLayout();
            this.splitContainerMaterialElementInfo.SuspendLayout();
            this.gBoxSlagElementInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompoundAnalysis)).BeginInit();
            this.gBoxAlloyElementInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementAnalysis)).BeginInit();
            this.gBoxMaterialList.SuspendLayout();
            this.splitContainerUI.Panel1.SuspendLayout();
            this.splitContainerUI.Panel2.SuspendLayout();
            this.splitContainerUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMaterialDetailInfo
            // 
            this.splitContainerMaterialDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMaterialDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaterialDetailInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMaterialDetailInfo.Name = "splitContainerMaterialDetailInfo";
            this.splitContainerMaterialDetailInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMaterialDetailInfo.Panel1
            // 
            this.splitContainerMaterialDetailInfo.Panel1.Controls.Add(this.splitContainerMaterialBasicInfo);
            // 
            // splitContainerMaterialDetailInfo.Panel2
            // 
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnConfirm);
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnClose);
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnDeleteElementInfo);
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnModifyElementInfo);
            this.splitContainerMaterialDetailInfo.Panel2.Controls.Add(this.btnAddNewElementInfo);
            this.splitContainerMaterialDetailInfo.Size = new System.Drawing.Size(567, 566);
            this.splitContainerMaterialDetailInfo.SplitterDistance = 520;
            this.splitContainerMaterialDetailInfo.TabIndex = 0;
            // 
            // splitContainerMaterialBasicInfo
            // 
            this.splitContainerMaterialBasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMaterialBasicInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaterialBasicInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMaterialBasicInfo.Name = "splitContainerMaterialBasicInfo";
            this.splitContainerMaterialBasicInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMaterialBasicInfo.Panel1
            // 
            this.splitContainerMaterialBasicInfo.Panel1.Controls.Add(this.gBoxBasicInfo);
            // 
            // splitContainerMaterialBasicInfo.Panel2
            // 
            this.splitContainerMaterialBasicInfo.Panel2.Controls.Add(this.splitContainerMaterialElementInfo);
            this.splitContainerMaterialBasicInfo.Size = new System.Drawing.Size(567, 520);
            this.splitContainerMaterialBasicInfo.SplitterDistance = 149;
            this.splitContainerMaterialBasicInfo.TabIndex = 0;
            // 
            // gBoxBasicInfo
            // 
            this.gBoxBasicInfo.Controls.Add(this.txtFeContent);
            this.gBoxBasicInfo.Controls.Add(this.lblFeContent);
            this.gBoxBasicInfo.Controls.Add(this.cmbMaterialNote);
            this.gBoxBasicInfo.Controls.Add(this.cmbMaterialType);
            this.gBoxBasicInfo.Controls.Add(this.txtMaterialName);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialNote);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialClass);
            this.gBoxBasicInfo.Controls.Add(this.txtMaterialDescription);
            this.gBoxBasicInfo.Controls.Add(this.txtWireWgt);
            this.gBoxBasicInfo.Controls.Add(this.txtBulkWgt);
            this.gBoxBasicInfo.Controls.Add(this.txtMaterialYield);
            this.gBoxBasicInfo.Controls.Add(this.txtChillRate);
            this.gBoxBasicInfo.Controls.Add(this.txtL3MaterialId);
            this.gBoxBasicInfo.Controls.Add(this.txtMaterialId);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialDescription);
            this.gBoxBasicInfo.Controls.Add(this.lblWireWgt);
            this.gBoxBasicInfo.Controls.Add(this.lblBulkWgt);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialYield);
            this.gBoxBasicInfo.Controls.Add(this.lblChillRate);
            this.gBoxBasicInfo.Controls.Add(this.lblL3MaterialId);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialName);
            this.gBoxBasicInfo.Controls.Add(this.lblMaterialId);
            this.gBoxBasicInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxBasicInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gBoxBasicInfo.Location = new System.Drawing.Point(3, 3);
            this.gBoxBasicInfo.Name = "gBoxBasicInfo";
            this.gBoxBasicInfo.Size = new System.Drawing.Size(551, 137);
            this.gBoxBasicInfo.TabIndex = 2;
            this.gBoxBasicInfo.TabStop = false;
            this.gBoxBasicInfo.Text = "物料基本信息";
            // 
            // txtFeContent
            // 
            this.txtFeContent.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFeContent.Location = new System.Drawing.Point(438, 45);
            this.txtFeContent.Name = "txtFeContent";
            this.txtFeContent.ReadOnly = true;
            this.txtFeContent.Size = new System.Drawing.Size(103, 27);
            this.txtFeContent.TabIndex = 4;
            this.txtFeContent.TextChanged += new System.EventHandler(this.txtFeContent_TextChanged);
            // 
            // lblFeContent
            // 
            this.lblFeContent.AutoSize = true;
            this.lblFeContent.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFeContent.Location = new System.Drawing.Point(388, 48);
            this.lblFeContent.Name = "lblFeContent";
            this.lblFeContent.Size = new System.Drawing.Size(49, 20);
            this.lblFeContent.TabIndex = 3;
            this.lblFeContent.Text = "Fe[%]";
            // 
            // cmbMaterialNote
            // 
            this.cmbMaterialNote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbMaterialNote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterialNote.Enabled = false;
            this.cmbMaterialNote.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMaterialNote.FormattingEnabled = true;
            this.cmbMaterialNote.Location = new System.Drawing.Point(284, 73);
            this.cmbMaterialNote.Name = "cmbMaterialNote";
            this.cmbMaterialNote.Size = new System.Drawing.Size(72, 28);
            this.cmbMaterialNote.TabIndex = 2;
            // 
            // cmbMaterialType
            // 
            this.cmbMaterialType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbMaterialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterialType.Enabled = false;
            this.cmbMaterialType.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbMaterialType.FormattingEnabled = true;
            this.cmbMaterialType.Location = new System.Drawing.Point(438, 73);
            this.cmbMaterialType.Name = "cmbMaterialType";
            this.cmbMaterialType.Size = new System.Drawing.Size(103, 28);
            this.cmbMaterialType.TabIndex = 2;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaterialName.Location = new System.Drawing.Point(240, 16);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.ReadOnly = true;
            this.txtMaterialName.Size = new System.Drawing.Size(116, 27);
            this.txtMaterialName.TabIndex = 1;
            this.txtMaterialName.TextChanged += new System.EventHandler(this.txtMaterialName_TextChanged);
            // 
            // lblMaterialNote
            // 
            this.lblMaterialNote.AutoSize = true;
            this.lblMaterialNote.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialNote.Location = new System.Drawing.Point(208, 77);
            this.lblMaterialNote.Name = "lblMaterialNote";
            this.lblMaterialNote.Size = new System.Drawing.Size(69, 20);
            this.lblMaterialNote.TabIndex = 0;
            this.lblMaterialNote.Text = "物料单位";
            // 
            // lblMaterialClass
            // 
            this.lblMaterialClass.AutoSize = true;
            this.lblMaterialClass.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialClass.Location = new System.Drawing.Point(368, 77);
            this.lblMaterialClass.Name = "lblMaterialClass";
            this.lblMaterialClass.Size = new System.Drawing.Size(69, 20);
            this.lblMaterialClass.TabIndex = 0;
            this.lblMaterialClass.Text = "物料类型";
            // 
            // txtMaterialDescription
            // 
            this.txtMaterialDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.txtMaterialDescription.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaterialDescription.Location = new System.Drawing.Point(80, 45);
            this.txtMaterialDescription.Name = "txtMaterialDescription";
            this.txtMaterialDescription.ReadOnly = true;
            this.txtMaterialDescription.Size = new System.Drawing.Size(276, 27);
            this.txtMaterialDescription.TabIndex = 1;
            this.txtMaterialDescription.TextChanged += new System.EventHandler(this.txtMaterialDescription_TextChanged);
            // 
            // txtWireWgt
            // 
            this.txtWireWgt.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWireWgt.Location = new System.Drawing.Point(131, 74);
            this.txtWireWgt.Name = "txtWireWgt";
            this.txtWireWgt.ReadOnly = true;
            this.txtWireWgt.Size = new System.Drawing.Size(70, 27);
            this.txtWireWgt.TabIndex = 1;
            this.txtWireWgt.TextChanged += new System.EventHandler(this.txtWireWgt_TextChanged);
            // 
            // txtBulkWgt
            // 
            this.txtBulkWgt.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBulkWgt.Location = new System.Drawing.Point(131, 103);
            this.txtBulkWgt.Name = "txtBulkWgt";
            this.txtBulkWgt.ReadOnly = true;
            this.txtBulkWgt.Size = new System.Drawing.Size(70, 27);
            this.txtBulkWgt.TabIndex = 1;
            this.txtBulkWgt.TextChanged += new System.EventHandler(this.txtBulkWgt_TextChanged);
            // 
            // txtMaterialYield
            // 
            this.txtMaterialYield.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaterialYield.Location = new System.Drawing.Point(471, 103);
            this.txtMaterialYield.Name = "txtMaterialYield";
            this.txtMaterialYield.ReadOnly = true;
            this.txtMaterialYield.Size = new System.Drawing.Size(70, 27);
            this.txtMaterialYield.TabIndex = 1;
            this.txtMaterialYield.TextChanged += new System.EventHandler(this.txtMaterialYield_TextChanged);
            // 
            // txtChillRate
            // 
            this.txtChillRate.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChillRate.Location = new System.Drawing.Point(325, 103);
            this.txtChillRate.Name = "txtChillRate";
            this.txtChillRate.ReadOnly = true;
            this.txtChillRate.Size = new System.Drawing.Size(63, 27);
            this.txtChillRate.TabIndex = 1;
            this.txtChillRate.TextChanged += new System.EventHandler(this.txtChillRate_TextChanged);
            // 
            // txtL3MaterialId
            // 
            this.txtL3MaterialId.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtL3MaterialId.Location = new System.Drawing.Point(438, 16);
            this.txtL3MaterialId.Name = "txtL3MaterialId";
            this.txtL3MaterialId.ReadOnly = true;
            this.txtL3MaterialId.Size = new System.Drawing.Size(103, 27);
            this.txtL3MaterialId.TabIndex = 1;
            this.txtL3MaterialId.TextChanged += new System.EventHandler(this.txtL3MaterialId_TextChanged);
            // 
            // txtMaterialId
            // 
            this.txtMaterialId.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMaterialId.Location = new System.Drawing.Point(80, 16);
            this.txtMaterialId.Name = "txtMaterialId";
            this.txtMaterialId.ReadOnly = true;
            this.txtMaterialId.Size = new System.Drawing.Size(77, 27);
            this.txtMaterialId.TabIndex = 1;
            this.txtMaterialId.TextChanged += new System.EventHandler(this.txtMaterialId_TextChanged);
            // 
            // lblMaterialDescription
            // 
            this.lblMaterialDescription.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.lblMaterialDescription.AutoSize = true;
            this.lblMaterialDescription.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialDescription.Location = new System.Drawing.Point(6, 48);
            this.lblMaterialDescription.Name = "lblMaterialDescription";
            this.lblMaterialDescription.Size = new System.Drawing.Size(69, 20);
            this.lblMaterialDescription.TabIndex = 0;
            this.lblMaterialDescription.Text = "物料描述";
            // 
            // lblWireWgt
            // 
            this.lblWireWgt.AutoSize = true;
            this.lblWireWgt.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWireWgt.Location = new System.Drawing.Point(6, 77);
            this.lblWireWgt.Name = "lblWireWgt";
            this.lblWireWgt.Size = new System.Drawing.Size(117, 20);
            this.lblWireWgt.TabIndex = 0;
            this.lblWireWgt.Text = "线状重量[kg/m]";
            // 
            // lblBulkWgt
            // 
            this.lblBulkWgt.AutoSize = true;
            this.lblBulkWgt.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBulkWgt.Location = new System.Drawing.Point(6, 106);
            this.lblBulkWgt.Name = "lblBulkWgt";
            this.lblBulkWgt.Size = new System.Drawing.Size(123, 20);
            this.lblBulkWgt.TabIndex = 0;
            this.lblBulkWgt.Text = "块状重量[kg/m³]";
            // 
            // lblMaterialYield
            // 
            this.lblMaterialYield.AutoSize = true;
            this.lblMaterialYield.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialYield.Location = new System.Drawing.Point(394, 106);
            this.lblMaterialYield.Name = "lblMaterialYield";
            this.lblMaterialYield.Size = new System.Drawing.Size(77, 20);
            this.lblMaterialYield.TabIndex = 0;
            this.lblMaterialYield.Text = "收得率(%)";
            // 
            // lblChillRate
            // 
            this.lblChillRate.AutoSize = true;
            this.lblChillRate.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChillRate.Location = new System.Drawing.Point(208, 106);
            this.lblChillRate.Name = "lblChillRate";
            this.lblChillRate.Size = new System.Drawing.Size(118, 20);
            this.lblChillRate.TabIndex = 0;
            this.lblChillRate.Text = "温降[△T℃/kg/t]";
            // 
            // lblL3MaterialId
            // 
            this.lblL3MaterialId.AutoSize = true;
            this.lblL3MaterialId.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblL3MaterialId.Location = new System.Drawing.Point(365, 19);
            this.lblL3MaterialId.Name = "lblL3MaterialId";
            this.lblL3MaterialId.Size = new System.Drawing.Size(69, 20);
            this.lblL3MaterialId.TabIndex = 0;
            this.lblL3MaterialId.Text = "三级代码";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialName.Location = new System.Drawing.Point(163, 19);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(69, 20);
            this.lblMaterialName.TabIndex = 0;
            this.lblMaterialName.Text = "物料名称";
            // 
            // lblMaterialId
            // 
            this.lblMaterialId.AutoSize = true;
            this.lblMaterialId.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMaterialId.Location = new System.Drawing.Point(6, 19);
            this.lblMaterialId.Name = "lblMaterialId";
            this.lblMaterialId.Size = new System.Drawing.Size(69, 20);
            this.lblMaterialId.TabIndex = 0;
            this.lblMaterialId.Text = "物料代码";
            // 
            // splitContainerMaterialElementInfo
            // 
            this.splitContainerMaterialElementInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMaterialElementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMaterialElementInfo.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMaterialElementInfo.Name = "splitContainerMaterialElementInfo";
            // 
            // splitContainerMaterialElementInfo.Panel1
            // 
            this.splitContainerMaterialElementInfo.Panel1.Controls.Add(this.gBoxSlagElementInfo);
            // 
            // splitContainerMaterialElementInfo.Panel2
            // 
            this.splitContainerMaterialElementInfo.Panel2.Controls.Add(this.gBoxAlloyElementInfo);
            this.splitContainerMaterialElementInfo.Size = new System.Drawing.Size(567, 367);
            this.splitContainerMaterialElementInfo.SplitterDistance = 229;
            this.splitContainerMaterialElementInfo.TabIndex = 0;
            // 
            // gBoxSlagElementInfo
            // 
            this.gBoxSlagElementInfo.Controls.Add(this.dgvCompoundAnalysis);
            this.gBoxSlagElementInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxSlagElementInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gBoxSlagElementInfo.Location = new System.Drawing.Point(3, 3);
            this.gBoxSlagElementInfo.Name = "gBoxSlagElementInfo";
            this.gBoxSlagElementInfo.Size = new System.Drawing.Size(219, 357);
            this.gBoxSlagElementInfo.TabIndex = 2;
            this.gBoxSlagElementInfo.TabStop = false;
            this.gBoxSlagElementInfo.Text = "物料渣元素信息";
            // 
            // dgvCompoundAnalysis
            // 
            this.dgvCompoundAnalysis.AllowUserToAddRows = false;
            this.dgvCompoundAnalysis.AllowUserToDeleteRows = false;
            this.dgvCompoundAnalysis.AllowUserToResizeColumns = false;
            this.dgvCompoundAnalysis.AllowUserToResizeRows = false;
            this.dgvCompoundAnalysis.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompoundAnalysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompoundAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompoundAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCompoundShortName,
            this.ColCompoundNetContent});
            this.dgvCompoundAnalysis.Location = new System.Drawing.Point(9, 20);
            this.dgvCompoundAnalysis.Name = "dgvCompoundAnalysis";
            this.dgvCompoundAnalysis.ReadOnly = true;
            this.dgvCompoundAnalysis.RowHeadersWidth = 4;
            this.dgvCompoundAnalysis.RowTemplate.Height = 23;
            this.dgvCompoundAnalysis.Size = new System.Drawing.Size(204, 331);
            this.dgvCompoundAnalysis.TabIndex = 0;
            this.dgvCompoundAnalysis.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompoundAnalysis_CellValueChanged);
            // 
            // ColCompoundShortName
            // 
            this.ColCompoundShortName.DataPropertyName = "ElemInfo.ElementShortName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColCompoundShortName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColCompoundShortName.HeaderText = "化合物名";
            this.ColCompoundShortName.Name = "ColCompoundShortName";
            this.ColCompoundShortName.ReadOnly = true;
            this.ColCompoundShortName.Width = 90;
            // 
            // ColCompoundNetContent
            // 
            this.ColCompoundNetContent.DataPropertyName = "NetContent";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "0";
            this.ColCompoundNetContent.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColCompoundNetContent.HeaderText = "净含量(%)";
            this.ColCompoundNetContent.Name = "ColCompoundNetContent";
            this.ColCompoundNetContent.ReadOnly = true;
            // 
            // gBoxAlloyElementInfo
            // 
            this.gBoxAlloyElementInfo.Controls.Add(this.dgvElementAnalysis);
            this.gBoxAlloyElementInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxAlloyElementInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gBoxAlloyElementInfo.Location = new System.Drawing.Point(3, 3);
            this.gBoxAlloyElementInfo.Name = "gBoxAlloyElementInfo";
            this.gBoxAlloyElementInfo.Size = new System.Drawing.Size(323, 357);
            this.gBoxAlloyElementInfo.TabIndex = 2;
            this.gBoxAlloyElementInfo.TabStop = false;
            this.gBoxAlloyElementInfo.Text = "物料合金元素信息";
            // 
            // dgvElementAnalysis
            // 
            this.dgvElementAnalysis.AllowUserToAddRows = false;
            this.dgvElementAnalysis.AllowUserToDeleteRows = false;
            this.dgvElementAnalysis.AllowUserToResizeColumns = false;
            this.dgvElementAnalysis.AllowUserToResizeRows = false;
            this.dgvElementAnalysis.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvElementAnalysis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvElementAnalysis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvElementAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColElementShortName,
            this.ColNetContent,
            this.ColYield});
            this.dgvElementAnalysis.Location = new System.Drawing.Point(6, 20);
            this.dgvElementAnalysis.MultiSelect = false;
            this.dgvElementAnalysis.Name = "dgvElementAnalysis";
            this.dgvElementAnalysis.ReadOnly = true;
            this.dgvElementAnalysis.RowHeadersWidth = 4;
            this.dgvElementAnalysis.RowTemplate.Height = 23;
            this.dgvElementAnalysis.Size = new System.Drawing.Size(311, 331);
            this.dgvElementAnalysis.TabIndex = 0;
            this.dgvElementAnalysis.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElementAnalysis_CellValueChanged);
            // 
            // ColElementShortName
            // 
            this.ColElementShortName.DataPropertyName = "ElemInfo.ElementShortName";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColElementShortName.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColElementShortName.HeaderText = "元素名称";
            this.ColElementShortName.Name = "ColElementShortName";
            this.ColElementShortName.ReadOnly = true;
            // 
            // ColNetContent
            // 
            this.ColNetContent.DataPropertyName = "NetContent";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.NullValue = "0";
            this.ColNetContent.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColNetContent.HeaderText = "净含量(%)";
            this.ColNetContent.Name = "ColNetContent";
            this.ColNetContent.ReadOnly = true;
            // 
            // ColYield
            // 
            this.ColYield.DataPropertyName = "Yield";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.NullValue = "100";
            this.ColYield.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColYield.HeaderText = "收得率(%)";
            this.ColYield.Name = "ColYield";
            this.ColYield.ReadOnly = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(282, 1);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(93, 37);
            this.btnConfirm.TabIndex = 13;
            this.btnConfirm.Text = "确  认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(468, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 37);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "关闭窗口";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(375, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 37);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDeleteElementInfo
            // 
            this.btnDeleteElementInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteElementInfo.Location = new System.Drawing.Point(189, 1);
            this.btnDeleteElementInfo.Name = "btnDeleteElementInfo";
            this.btnDeleteElementInfo.Size = new System.Drawing.Size(93, 37);
            this.btnDeleteElementInfo.TabIndex = 10;
            this.btnDeleteElementInfo.Text = "删  除";
            this.btnDeleteElementInfo.UseVisualStyleBackColor = true;
            this.btnDeleteElementInfo.Click += new System.EventHandler(this.btnDeleteElementInfo_Click);
            // 
            // btnModifyElementInfo
            // 
            this.btnModifyElementInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyElementInfo.Location = new System.Drawing.Point(96, 1);
            this.btnModifyElementInfo.Name = "btnModifyElementInfo";
            this.btnModifyElementInfo.Size = new System.Drawing.Size(93, 37);
            this.btnModifyElementInfo.TabIndex = 9;
            this.btnModifyElementInfo.Text = "修  改";
            this.btnModifyElementInfo.UseVisualStyleBackColor = true;
            this.btnModifyElementInfo.Click += new System.EventHandler(this.btnModifyElementInfo_Click);
            // 
            // btnAddNewElementInfo
            // 
            this.btnAddNewElementInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewElementInfo.Location = new System.Drawing.Point(2, 1);
            this.btnAddNewElementInfo.Name = "btnAddNewElementInfo";
            this.btnAddNewElementInfo.Size = new System.Drawing.Size(93, 37);
            this.btnAddNewElementInfo.TabIndex = 7;
            this.btnAddNewElementInfo.Text = "新  增";
            this.btnAddNewElementInfo.UseVisualStyleBackColor = true;
            this.btnAddNewElementInfo.Click += new System.EventHandler(this.btnAddNewElementInfo_Click);
            // 
            // gBoxMaterialList
            // 
            this.gBoxMaterialList.Controls.Add(this.lvMaterialList);
            this.gBoxMaterialList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxMaterialList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gBoxMaterialList.Location = new System.Drawing.Point(3, 3);
            this.gBoxMaterialList.Name = "gBoxMaterialList";
            this.gBoxMaterialList.Size = new System.Drawing.Size(218, 556);
            this.gBoxMaterialList.TabIndex = 1;
            this.gBoxMaterialList.TabStop = false;
            this.gBoxMaterialList.Text = "物料列表";
            // 
            // lvMaterialList
            // 
            this.lvMaterialList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvMaterialList.AutoArrange = false;
            this.lvMaterialList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvMaterialList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvMaterialList.FullRowSelect = true;
            this.lvMaterialList.GridLines = true;
            this.lvMaterialList.Location = new System.Drawing.Point(6, 20);
            this.lvMaterialList.MultiSelect = false;
            this.lvMaterialList.Name = "lvMaterialList";
            this.lvMaterialList.Size = new System.Drawing.Size(206, 530);
            this.lvMaterialList.TabIndex = 0;
            this.lvMaterialList.UseCompatibleStateImageBehavior = false;
            this.lvMaterialList.View = System.Windows.Forms.View.Details;
            this.lvMaterialList.SelectedIndexChanged += new System.EventHandler(this.lvMaterialList_SelectedIndexChanged);
            // 
            // splitContainerUI
            // 
            this.splitContainerUI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerUI.Location = new System.Drawing.Point(0, 0);
            this.splitContainerUI.Name = "splitContainerUI";
            // 
            // splitContainerUI.Panel1
            // 
            this.splitContainerUI.Panel1.Controls.Add(this.gBoxMaterialList);
            // 
            // splitContainerUI.Panel2
            // 
            this.splitContainerUI.Panel2.Controls.Add(this.splitContainerMaterialDetailInfo);
            this.splitContainerUI.Size = new System.Drawing.Size(800, 566);
            this.splitContainerUI.SplitterDistance = 229;
            this.splitContainerUI.TabIndex = 0;
            // 
            // MaterialInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainerUI);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaterialInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "物料维护界面";
            this.Load += new System.EventHandler(this.MaterialInfoMaintenanceUI_Load);
            this.splitContainerMaterialDetailInfo.Panel1.ResumeLayout(false);
            this.splitContainerMaterialDetailInfo.Panel2.ResumeLayout(false);
            this.splitContainerMaterialDetailInfo.ResumeLayout(false);
            this.splitContainerMaterialBasicInfo.Panel1.ResumeLayout(false);
            this.splitContainerMaterialBasicInfo.Panel2.ResumeLayout(false);
            this.splitContainerMaterialBasicInfo.ResumeLayout(false);
            this.gBoxBasicInfo.ResumeLayout(false);
            this.gBoxBasicInfo.PerformLayout();
            this.splitContainerMaterialElementInfo.Panel1.ResumeLayout(false);
            this.splitContainerMaterialElementInfo.Panel2.ResumeLayout(false);
            this.splitContainerMaterialElementInfo.ResumeLayout(false);
            this.gBoxSlagElementInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompoundAnalysis)).EndInit();
            this.gBoxAlloyElementInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElementAnalysis)).EndInit();
            this.gBoxMaterialList.ResumeLayout(false);
            this.splitContainerUI.Panel1.ResumeLayout(false);
            this.splitContainerUI.Panel2.ResumeLayout(false);
            this.splitContainerUI.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMaterialDetailInfo;
        private System.Windows.Forms.SplitContainer splitContainerMaterialBasicInfo;
        private System.Windows.Forms.GroupBox gBoxBasicInfo;
        private System.Windows.Forms.TextBox txtFeContent;
        private System.Windows.Forms.Label lblFeContent;
        private System.Windows.Forms.ComboBox cmbMaterialNote;
        private System.Windows.Forms.ComboBox cmbMaterialType;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.Label lblMaterialNote;
        private System.Windows.Forms.Label lblMaterialClass;
        private System.Windows.Forms.TextBox txtMaterialDescription;
        private System.Windows.Forms.TextBox txtWireWgt;
        private System.Windows.Forms.TextBox txtBulkWgt;
        private System.Windows.Forms.TextBox txtChillRate;
        private System.Windows.Forms.TextBox txtL3MaterialId;
        private System.Windows.Forms.TextBox txtMaterialId;
        private System.Windows.Forms.Label lblMaterialDescription;
        private System.Windows.Forms.Label lblWireWgt;
        private System.Windows.Forms.Label lblBulkWgt;
        private System.Windows.Forms.Label lblChillRate;
        private System.Windows.Forms.Label lblL3MaterialId;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label lblMaterialId;
        private System.Windows.Forms.SplitContainer splitContainerMaterialElementInfo;
        private System.Windows.Forms.GroupBox gBoxMaterialList;
        private System.Windows.Forms.ListView lvMaterialList;
        private System.Windows.Forms.SplitContainer splitContainerUI;
        private System.Windows.Forms.GroupBox gBoxSlagElementInfo;
        private System.Windows.Forms.GroupBox gBoxAlloyElementInfo;
        private System.Windows.Forms.Button btnAddNewElementInfo;
        private System.Windows.Forms.Button btnModifyElementInfo;
        private System.Windows.Forms.Button btnDeleteElementInfo;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvCompoundAnalysis;
        private System.Windows.Forms.DataGridView dgvElementAnalysis;
        private System.Windows.Forms.TextBox txtMaterialYield;
        private System.Windows.Forms.Label lblMaterialYield;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCompoundShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCompoundNetContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColElementShortName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNetContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColYield;

    }
}