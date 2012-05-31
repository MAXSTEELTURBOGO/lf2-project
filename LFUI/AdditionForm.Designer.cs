namespace LFAutomationUI.LFUI
{
    partial class AdditionForm
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
            this.gBoxAddition = new System.Windows.Forms.GroupBox();
            this.lbl_HeatId = new System.Windows.Forms.Label();
            this.lbl_TreatmentCount = new System.Windows.Forms.Label();
            this.lblHeatId = new System.Windows.Forms.Label();
            this.lblTreatmentCount = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.cmbMaterialName = new System.Windows.Forms.ComboBox();
            this.lbl_AddtionAmount = new System.Windows.Forms.Label();
            this.txtAdditionAmount = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblAdditionTime = new System.Windows.Forms.Label();
            this.dptAdditionTime = new System.Windows.Forms.DateTimePicker();
            this.gBoxAddition.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxAddition
            // 
            this.gBoxAddition.Controls.Add(this.dptAdditionTime);
            this.gBoxAddition.Controls.Add(this.lblAdditionTime);
            this.gBoxAddition.Controls.Add(this.btnCancel);
            this.gBoxAddition.Controls.Add(this.btnOK);
            this.gBoxAddition.Controls.Add(this.txtAdditionAmount);
            this.gBoxAddition.Controls.Add(this.lbl_AddtionAmount);
            this.gBoxAddition.Controls.Add(this.cmbMaterialName);
            this.gBoxAddition.Controls.Add(this.lblMaterialName);
            this.gBoxAddition.Controls.Add(this.lblTreatmentCount);
            this.gBoxAddition.Controls.Add(this.lblHeatId);
            this.gBoxAddition.Controls.Add(this.lbl_TreatmentCount);
            this.gBoxAddition.Controls.Add(this.lbl_HeatId);
            this.gBoxAddition.Location = new System.Drawing.Point(13, 24);
            this.gBoxAddition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxAddition.Name = "gBoxAddition";
            this.gBoxAddition.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gBoxAddition.Size = new System.Drawing.Size(371, 309);
            this.gBoxAddition.TabIndex = 0;
            this.gBoxAddition.TabStop = false;
            this.gBoxAddition.Text = "添加物料信息";
            // 
            // lbl_HeatId
            // 
            this.lbl_HeatId.AutoSize = true;
            this.lbl_HeatId.Location = new System.Drawing.Point(84, 52);
            this.lbl_HeatId.Name = "lbl_HeatId";
            this.lbl_HeatId.Size = new System.Drawing.Size(64, 16);
            this.lbl_HeatId.TabIndex = 0;
            this.lbl_HeatId.Text = "炉次号:";
            // 
            // lbl_TreatmentCount
            // 
            this.lbl_TreatmentCount.AutoSize = true;
            this.lbl_TreatmentCount.Location = new System.Drawing.Point(68, 90);
            this.lbl_TreatmentCount.Name = "lbl_TreatmentCount";
            this.lbl_TreatmentCount.Size = new System.Drawing.Size(80, 16);
            this.lbl_TreatmentCount.TabIndex = 1;
            this.lbl_TreatmentCount.Text = "处理次数:";
            // 
            // lblHeatId
            // 
            this.lblHeatId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHeatId.Location = new System.Drawing.Point(154, 50);
            this.lblHeatId.Name = "lblHeatId";
            this.lblHeatId.Size = new System.Drawing.Size(127, 26);
            this.lblHeatId.TabIndex = 2;
            this.lblHeatId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTreatmentCount
            // 
            this.lblTreatmentCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTreatmentCount.Location = new System.Drawing.Point(154, 88);
            this.lblTreatmentCount.Name = "lblTreatmentCount";
            this.lblTreatmentCount.Size = new System.Drawing.Size(127, 26);
            this.lblTreatmentCount.TabIndex = 3;
            this.lblTreatmentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(68, 171);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(80, 16);
            this.lblMaterialName.TabIndex = 4;
            this.lblMaterialName.Text = "物料名称:";
            // 
            // cmbMaterialName
            // 
            this.cmbMaterialName.FormattingEnabled = true;
            this.cmbMaterialName.Location = new System.Drawing.Point(154, 168);
            this.cmbMaterialName.Name = "cmbMaterialName";
            this.cmbMaterialName.Size = new System.Drawing.Size(127, 24);
            this.cmbMaterialName.TabIndex = 5;
            // 
            // lbl_AddtionAmount
            // 
            this.lbl_AddtionAmount.AutoSize = true;
            this.lbl_AddtionAmount.Location = new System.Drawing.Point(68, 207);
            this.lbl_AddtionAmount.Name = "lbl_AddtionAmount";
            this.lbl_AddtionAmount.Size = new System.Drawing.Size(80, 16);
            this.lbl_AddtionAmount.TabIndex = 7;
            this.lbl_AddtionAmount.Text = "添加重量:";
            // 
            // txtAdditionAmount
            // 
            this.txtAdditionAmount.Location = new System.Drawing.Point(154, 204);
            this.txtAdditionAmount.Name = "txtAdditionAmount";
            this.txtAdditionAmount.Size = new System.Drawing.Size(127, 26);
            this.txtAdditionAmount.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 33);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(188, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAdditionTime
            // 
            this.lblAdditionTime.AutoSize = true;
            this.lblAdditionTime.Location = new System.Drawing.Point(68, 130);
            this.lblAdditionTime.Name = "lblAdditionTime";
            this.lblAdditionTime.Size = new System.Drawing.Size(80, 16);
            this.lblAdditionTime.TabIndex = 11;
            this.lblAdditionTime.Text = "加料时间:";
            // 
            // dptAdditionTime
            // 
            this.dptAdditionTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dptAdditionTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptAdditionTime.Location = new System.Drawing.Point(154, 125);
            this.dptAdditionTime.Name = "dptAdditionTime";
            this.dptAdditionTime.Size = new System.Drawing.Size(180, 26);
            this.dptAdditionTime.TabIndex = 12;
            // 
            // AdditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 357);
            this.ControlBox = false;
            this.Controls.Add(this.gBoxAddition);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimSun", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "记录手动添加物料";
            this.Load += new System.EventHandler(this.AdditionForm_Load);
            this.gBoxAddition.ResumeLayout(false);
            this.gBoxAddition.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxAddition;
        private System.Windows.Forms.Label lblTreatmentCount;
        private System.Windows.Forms.Label lblHeatId;
        private System.Windows.Forms.Label lbl_TreatmentCount;
        private System.Windows.Forms.Label lbl_HeatId;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.TextBox txtAdditionAmount;
        private System.Windows.Forms.Label lbl_AddtionAmount;
        private System.Windows.Forms.ComboBox cmbMaterialName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dptAdditionTime;
        private System.Windows.Forms.Label lblAdditionTime;
    }
}