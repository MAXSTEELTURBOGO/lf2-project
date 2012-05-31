namespace LFAutomationUI.LFUI
{
    partial class NewLFHeatPlanForm
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
            this.tabControlNewPlan = new System.Windows.Forms.TabControl();
            this.tabPageNewHeatPlan = new System.Windows.Forms.TabPage();
            this.gBoxNewLFHeatPlanInfo = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewLFHeatPlan = new System.Windows.Forms.Button();
            this.btnSelectRouteId = new System.Windows.Forms.Button();
            this.txtRouteId = new System.Windows.Forms.TextBox();
            this.lblRouteId = new System.Windows.Forms.Label();
            this.txtStationId = new System.Windows.Forms.TextBox();
            this.lblStationId = new System.Windows.Forms.Label();
            this.txtAimTemperature = new System.Windows.Forms.TextBox();
            this.lblAimTemperature = new System.Windows.Forms.Label();
            this.txtLadleId = new System.Windows.Forms.TextBox();
            this.lblLadleId = new System.Windows.Forms.Label();
            this.cmbSteelGradeId = new System.Windows.Forms.ComboBox();
            this.lblSteelGradeId = new System.Windows.Forms.Label();
            this.txtHeatId = new System.Windows.Forms.TextBox();
            this.lblHeatId = new System.Windows.Forms.Label();
            this.tabPageNewHeatBackPlan = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBackHeatLadleId = new System.Windows.Forms.TextBox();
            this.lblBackHeatLadleId = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btnNewHeatBackPlan = new System.Windows.Forms.Button();
            this.cmbBackHeatSteelGradeId = new System.Windows.Forms.ComboBox();
            this.lblBackHeatSteelGradeId = new System.Windows.Forms.Label();
            this.txtBackHeatId = new System.Windows.Forms.TextBox();
            this.lblBackHeatId = new System.Windows.Forms.Label();
            this.tabControlNewPlan.SuspendLayout();
            this.tabPageNewHeatPlan.SuspendLayout();
            this.gBoxNewLFHeatPlanInfo.SuspendLayout();
            this.tabPageNewHeatBackPlan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlNewPlan
            // 
            this.tabControlNewPlan.Controls.Add(this.tabPageNewHeatPlan);
            this.tabControlNewPlan.Controls.Add(this.tabPageNewHeatBackPlan);
            this.tabControlNewPlan.Location = new System.Drawing.Point(12, 28);
            this.tabControlNewPlan.Name = "tabControlNewPlan";
            this.tabControlNewPlan.SelectedIndex = 0;
            this.tabControlNewPlan.Size = new System.Drawing.Size(511, 467);
            this.tabControlNewPlan.TabIndex = 0;
            // 
            // tabPageNewHeatPlan
            // 
            this.tabPageNewHeatPlan.Controls.Add(this.gBoxNewLFHeatPlanInfo);
            this.tabPageNewHeatPlan.Location = new System.Drawing.Point(4, 25);
            this.tabPageNewHeatPlan.Name = "tabPageNewHeatPlan";
            this.tabPageNewHeatPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewHeatPlan.Size = new System.Drawing.Size(503, 438);
            this.tabPageNewHeatPlan.TabIndex = 0;
            this.tabPageNewHeatPlan.Text = "新炉次计划信息";
            this.tabPageNewHeatPlan.UseVisualStyleBackColor = true;
            // 
            // gBoxNewLFHeatPlanInfo
            // 
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.btnCancel);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.btnNewLFHeatPlan);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.btnSelectRouteId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.txtRouteId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblRouteId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.txtStationId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblStationId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.txtAimTemperature);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblAimTemperature);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.txtLadleId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblLadleId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.cmbSteelGradeId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblSteelGradeId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.txtHeatId);
            this.gBoxNewLFHeatPlanInfo.Controls.Add(this.lblHeatId);
            this.gBoxNewLFHeatPlanInfo.Location = new System.Drawing.Point(18, 25);
            this.gBoxNewLFHeatPlanInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gBoxNewLFHeatPlanInfo.Name = "gBoxNewLFHeatPlanInfo";
            this.gBoxNewLFHeatPlanInfo.Padding = new System.Windows.Forms.Padding(4);
            this.gBoxNewLFHeatPlanInfo.Size = new System.Drawing.Size(465, 398);
            this.gBoxNewLFHeatPlanInfo.TabIndex = 3;
            this.gBoxNewLFHeatPlanInfo.TabStop = false;
            this.gBoxNewLFHeatPlanInfo.Text = "新炉次计划信息";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(249, 336);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 41);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewLFHeatPlan
            // 
            this.btnNewLFHeatPlan.Location = new System.Drawing.Point(116, 336);
            this.btnNewLFHeatPlan.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewLFHeatPlan.Name = "btnNewLFHeatPlan";
            this.btnNewLFHeatPlan.Size = new System.Drawing.Size(100, 41);
            this.btnNewLFHeatPlan.TabIndex = 15;
            this.btnNewLFHeatPlan.Text = "新增";
            this.btnNewLFHeatPlan.UseVisualStyleBackColor = true;
            this.btnNewLFHeatPlan.Click += new System.EventHandler(this.btnNewLFHeatPlan_Click);
            // 
            // btnSelectRouteId
            // 
            this.btnSelectRouteId.Location = new System.Drawing.Point(384, 201);
            this.btnSelectRouteId.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectRouteId.Name = "btnSelectRouteId";
            this.btnSelectRouteId.Size = new System.Drawing.Size(48, 31);
            this.btnSelectRouteId.TabIndex = 12;
            this.btnSelectRouteId.Text = "...";
            this.btnSelectRouteId.UseVisualStyleBackColor = true;
            this.btnSelectRouteId.Click += new System.EventHandler(this.btnSelectRouteId_Click);
            // 
            // txtRouteId
            // 
            this.txtRouteId.Location = new System.Drawing.Point(115, 202);
            this.txtRouteId.Margin = new System.Windows.Forms.Padding(4);
            this.txtRouteId.Name = "txtRouteId";
            this.txtRouteId.ReadOnly = true;
            this.txtRouteId.Size = new System.Drawing.Size(260, 26);
            this.txtRouteId.TabIndex = 11;
            // 
            // lblRouteId
            // 
            this.lblRouteId.AutoSize = true;
            this.lblRouteId.Location = new System.Drawing.Point(23, 206);
            this.lblRouteId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRouteId.Name = "lblRouteId";
            this.lblRouteId.Size = new System.Drawing.Size(72, 16);
            this.lblRouteId.TabIndex = 10;
            this.lblRouteId.Text = "工艺路径";
            // 
            // txtStationId
            // 
            this.txtStationId.Location = new System.Drawing.Point(115, 164);
            this.txtStationId.Margin = new System.Windows.Forms.Padding(4);
            this.txtStationId.Name = "txtStationId";
            this.txtStationId.Size = new System.Drawing.Size(160, 26);
            this.txtStationId.TabIndex = 9;
            // 
            // lblStationId
            // 
            this.lblStationId.AutoSize = true;
            this.lblStationId.Location = new System.Drawing.Point(60, 168);
            this.lblStationId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStationId.Name = "lblStationId";
            this.lblStationId.Size = new System.Drawing.Size(40, 16);
            this.lblStationId.TabIndex = 8;
            this.lblStationId.Text = "站号";
            // 
            // txtAimTemperature
            // 
            this.txtAimTemperature.Location = new System.Drawing.Point(115, 125);
            this.txtAimTemperature.Margin = new System.Windows.Forms.Padding(4);
            this.txtAimTemperature.Name = "txtAimTemperature";
            this.txtAimTemperature.Size = new System.Drawing.Size(160, 26);
            this.txtAimTemperature.TabIndex = 7;
            // 
            // lblAimTemperature
            // 
            this.lblAimTemperature.AutoSize = true;
            this.lblAimTemperature.Location = new System.Drawing.Point(23, 129);
            this.lblAimTemperature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAimTemperature.Name = "lblAimTemperature";
            this.lblAimTemperature.Size = new System.Drawing.Size(72, 16);
            this.lblAimTemperature.TabIndex = 6;
            this.lblAimTemperature.Text = "目标温度";
            // 
            // txtLadleId
            // 
            this.txtLadleId.Location = new System.Drawing.Point(115, 242);
            this.txtLadleId.Margin = new System.Windows.Forms.Padding(4);
            this.txtLadleId.Name = "txtLadleId";
            this.txtLadleId.Size = new System.Drawing.Size(160, 26);
            this.txtLadleId.TabIndex = 5;
            // 
            // lblLadleId
            // 
            this.lblLadleId.AutoSize = true;
            this.lblLadleId.Location = new System.Drawing.Point(41, 245);
            this.lblLadleId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLadleId.Name = "lblLadleId";
            this.lblLadleId.Size = new System.Drawing.Size(56, 16);
            this.lblLadleId.TabIndex = 4;
            this.lblLadleId.Text = "钢包号";
            // 
            // cmbSteelGradeId
            // 
            this.cmbSteelGradeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSteelGradeId.FormattingEnabled = true;
            this.cmbSteelGradeId.Location = new System.Drawing.Point(115, 88);
            this.cmbSteelGradeId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSteelGradeId.Name = "cmbSteelGradeId";
            this.cmbSteelGradeId.Size = new System.Drawing.Size(160, 24);
            this.cmbSteelGradeId.TabIndex = 3;
            // 
            // lblSteelGradeId
            // 
            this.lblSteelGradeId.AutoSize = true;
            this.lblSteelGradeId.Location = new System.Drawing.Point(41, 92);
            this.lblSteelGradeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSteelGradeId.Name = "lblSteelGradeId";
            this.lblSteelGradeId.Size = new System.Drawing.Size(56, 16);
            this.lblSteelGradeId.TabIndex = 2;
            this.lblSteelGradeId.Text = "钢种号";
            // 
            // txtHeatId
            // 
            this.txtHeatId.Location = new System.Drawing.Point(115, 49);
            this.txtHeatId.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeatId.Name = "txtHeatId";
            this.txtHeatId.Size = new System.Drawing.Size(160, 26);
            this.txtHeatId.TabIndex = 1;
            // 
            // lblHeatId
            // 
            this.lblHeatId.AutoSize = true;
            this.lblHeatId.Location = new System.Drawing.Point(41, 53);
            this.lblHeatId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeatId.Name = "lblHeatId";
            this.lblHeatId.Size = new System.Drawing.Size(56, 16);
            this.lblHeatId.TabIndex = 0;
            this.lblHeatId.Text = "炉次号";
            // 
            // tabPageNewHeatBackPlan
            // 
            this.tabPageNewHeatBackPlan.Controls.Add(this.groupBox1);
            this.tabPageNewHeatBackPlan.Location = new System.Drawing.Point(4, 25);
            this.tabPageNewHeatBackPlan.Name = "tabPageNewHeatBackPlan";
            this.tabPageNewHeatBackPlan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewHeatBackPlan.Size = new System.Drawing.Size(503, 438);
            this.tabPageNewHeatBackPlan.TabIndex = 1;
            this.tabPageNewHeatBackPlan.Text = "回炉计划信息";
            this.tabPageNewHeatBackPlan.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBackHeatLadleId);
            this.groupBox1.Controls.Add(this.lblBackHeatLadleId);
            this.groupBox1.Controls.Add(this.btn_Cancel);
            this.groupBox1.Controls.Add(this.btnNewHeatBackPlan);
            this.groupBox1.Controls.Add(this.cmbBackHeatSteelGradeId);
            this.groupBox1.Controls.Add(this.lblBackHeatSteelGradeId);
            this.groupBox1.Controls.Add(this.txtBackHeatId);
            this.groupBox1.Controls.Add(this.lblBackHeatId);
            this.groupBox1.Location = new System.Drawing.Point(18, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 398);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "回炉计划信息";
            // 
            // txtBackHeatLadleId
            // 
            this.txtBackHeatLadleId.Location = new System.Drawing.Point(189, 173);
            this.txtBackHeatLadleId.Name = "txtBackHeatLadleId";
            this.txtBackHeatLadleId.Size = new System.Drawing.Size(160, 26);
            this.txtBackHeatLadleId.TabIndex = 11;
            // 
            // lblBackHeatLadleId
            // 
            this.lblBackHeatLadleId.AutoSize = true;
            this.lblBackHeatLadleId.Location = new System.Drawing.Point(115, 178);
            this.lblBackHeatLadleId.Name = "lblBackHeatLadleId";
            this.lblBackHeatLadleId.Size = new System.Drawing.Size(56, 16);
            this.lblBackHeatLadleId.TabIndex = 10;
            this.lblBackHeatLadleId.Text = "钢包号";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(235, 236);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(113, 41);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewHeatBackPlan
            // 
            this.btnNewHeatBackPlan.Location = new System.Drawing.Point(117, 236);
            this.btnNewHeatBackPlan.Name = "btnNewHeatBackPlan";
            this.btnNewHeatBackPlan.Size = new System.Drawing.Size(113, 41);
            this.btnNewHeatBackPlan.TabIndex = 8;
            this.btnNewHeatBackPlan.Text = "新增回炉信息";
            this.btnNewHeatBackPlan.UseVisualStyleBackColor = true;
            this.btnNewHeatBackPlan.Click += new System.EventHandler(this.btnNewHeatBackPlan_Click);
            // 
            // cmbBackHeatSteelGradeId
            // 
            this.cmbBackHeatSteelGradeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackHeatSteelGradeId.FormattingEnabled = true;
            this.cmbBackHeatSteelGradeId.Location = new System.Drawing.Point(189, 131);
            this.cmbBackHeatSteelGradeId.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBackHeatSteelGradeId.Name = "cmbBackHeatSteelGradeId";
            this.cmbBackHeatSteelGradeId.Size = new System.Drawing.Size(160, 24);
            this.cmbBackHeatSteelGradeId.TabIndex = 7;
            // 
            // lblBackHeatSteelGradeId
            // 
            this.lblBackHeatSteelGradeId.AutoSize = true;
            this.lblBackHeatSteelGradeId.Location = new System.Drawing.Point(115, 135);
            this.lblBackHeatSteelGradeId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackHeatSteelGradeId.Name = "lblBackHeatSteelGradeId";
            this.lblBackHeatSteelGradeId.Size = new System.Drawing.Size(56, 16);
            this.lblBackHeatSteelGradeId.TabIndex = 6;
            this.lblBackHeatSteelGradeId.Text = "钢种号";
            // 
            // txtBackHeatId
            // 
            this.txtBackHeatId.Location = new System.Drawing.Point(189, 87);
            this.txtBackHeatId.Margin = new System.Windows.Forms.Padding(4);
            this.txtBackHeatId.Name = "txtBackHeatId";
            this.txtBackHeatId.Size = new System.Drawing.Size(160, 26);
            this.txtBackHeatId.TabIndex = 5;
            // 
            // lblBackHeatId
            // 
            this.lblBackHeatId.AutoSize = true;
            this.lblBackHeatId.Location = new System.Drawing.Point(115, 92);
            this.lblBackHeatId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackHeatId.Name = "lblBackHeatId";
            this.lblBackHeatId.Size = new System.Drawing.Size(56, 16);
            this.lblBackHeatId.TabIndex = 4;
            this.lblBackHeatId.Text = "炉次号";
            // 
            // NewLFHeatPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 517);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlNewPlan);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewLFHeatPlanForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加炉次计划";
            this.Load += new System.EventHandler(this.NewLFHeatPlanForm_Load);
            this.tabControlNewPlan.ResumeLayout(false);
            this.tabPageNewHeatPlan.ResumeLayout(false);
            this.gBoxNewLFHeatPlanInfo.ResumeLayout(false);
            this.gBoxNewLFHeatPlanInfo.PerformLayout();
            this.tabPageNewHeatBackPlan.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlNewPlan;
        private System.Windows.Forms.TabPage tabPageNewHeatPlan;
        private System.Windows.Forms.GroupBox gBoxNewLFHeatPlanInfo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewLFHeatPlan;
        private System.Windows.Forms.Button btnSelectRouteId;
        private System.Windows.Forms.TextBox txtRouteId;
        private System.Windows.Forms.Label lblRouteId;
        private System.Windows.Forms.TextBox txtStationId;
        private System.Windows.Forms.Label lblStationId;
        private System.Windows.Forms.TextBox txtAimTemperature;
        private System.Windows.Forms.Label lblAimTemperature;
        private System.Windows.Forms.TextBox txtLadleId;
        private System.Windows.Forms.Label lblLadleId;
        private System.Windows.Forms.ComboBox cmbSteelGradeId;
        private System.Windows.Forms.Label lblSteelGradeId;
        private System.Windows.Forms.TextBox txtHeatId;
        private System.Windows.Forms.Label lblHeatId;
        private System.Windows.Forms.TabPage tabPageNewHeatBackPlan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btnNewHeatBackPlan;
        private System.Windows.Forms.ComboBox cmbBackHeatSteelGradeId;
        private System.Windows.Forms.Label lblBackHeatSteelGradeId;
        private System.Windows.Forms.TextBox txtBackHeatId;
        private System.Windows.Forms.Label lblBackHeatId;
        private System.Windows.Forms.TextBox txtBackHeatLadleId;
        private System.Windows.Forms.Label lblBackHeatLadleId;

    }
}