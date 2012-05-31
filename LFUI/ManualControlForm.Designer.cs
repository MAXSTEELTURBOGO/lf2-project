namespace LFAutomationUI.LFUI
{
    partial class ManualControlForm
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
            this.lblManualControlTip = new System.Windows.Forms.Label();
            this.gBoxManualSignal = new System.Windows.Forms.GroupBox();
            this.rdbLadleDepart = new System.Windows.Forms.RadioButton();
            this.rdbFeedStop = new System.Windows.Forms.RadioButton();
            this.rdbFeedStart = new System.Windows.Forms.RadioButton();
            this.rdbPowerStop = new System.Windows.Forms.RadioButton();
            this.rdbPowerStart = new System.Windows.Forms.RadioButton();
            this.rdbLadleArrival = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gBoxManualSignal.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblManualControlTip
            // 
            this.lblManualControlTip.AutoSize = true;
            this.lblManualControlTip.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblManualControlTip.Location = new System.Drawing.Point(29, 29);
            this.lblManualControlTip.Name = "lblManualControlTip";
            this.lblManualControlTip.Size = new System.Drawing.Size(312, 32);
            this.lblManualControlTip.TabIndex = 0;
            this.lblManualControlTip.Text = "手动控制主要在系统由于某种原因造成无法\r\n正确读取一级信息时使用，请谨慎使用！";
            // 
            // gBoxManualSignal
            // 
            this.gBoxManualSignal.Controls.Add(this.rdbLadleDepart);
            this.gBoxManualSignal.Controls.Add(this.rdbFeedStop);
            this.gBoxManualSignal.Controls.Add(this.rdbFeedStart);
            this.gBoxManualSignal.Controls.Add(this.rdbPowerStop);
            this.gBoxManualSignal.Controls.Add(this.rdbPowerStart);
            this.gBoxManualSignal.Controls.Add(this.rdbLadleArrival);
            this.gBoxManualSignal.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxManualSignal.Location = new System.Drawing.Point(32, 87);
            this.gBoxManualSignal.Name = "gBoxManualSignal";
            this.gBoxManualSignal.Size = new System.Drawing.Size(309, 120);
            this.gBoxManualSignal.TabIndex = 1;
            this.gBoxManualSignal.TabStop = false;
            this.gBoxManualSignal.Text = "手动控制信号";
            // 
            // rdbLadleDepart
            // 
            this.rdbLadleDepart.AutoSize = true;
            this.rdbLadleDepart.Location = new System.Drawing.Point(153, 30);
            this.rdbLadleDepart.Name = "rdbLadleDepart";
            this.rdbLadleDepart.Size = new System.Drawing.Size(90, 20);
            this.rdbLadleDepart.TabIndex = 5;
            this.rdbLadleDepart.TabStop = true;
            this.rdbLadleDepart.Text = "钢包离开";
            this.rdbLadleDepart.UseVisualStyleBackColor = true;
            this.rdbLadleDepart.CheckedChanged += new System.EventHandler(this.rdbLadleDepart_CheckedChanged);
            // 
            // rdbFeedStop
            // 
            this.rdbFeedStop.AutoSize = true;
            this.rdbFeedStop.Location = new System.Drawing.Point(153, 82);
            this.rdbFeedStop.Name = "rdbFeedStop";
            this.rdbFeedStop.Size = new System.Drawing.Size(90, 20);
            this.rdbFeedStop.TabIndex = 4;
            this.rdbFeedStop.TabStop = true;
            this.rdbFeedStop.Text = "喂丝结束";
            this.rdbFeedStop.UseVisualStyleBackColor = true;
            this.rdbFeedStop.CheckedChanged += new System.EventHandler(this.rdbFeedStop_CheckedChanged);
            // 
            // rdbFeedStart
            // 
            this.rdbFeedStart.AutoSize = true;
            this.rdbFeedStart.Location = new System.Drawing.Point(57, 82);
            this.rdbFeedStart.Name = "rdbFeedStart";
            this.rdbFeedStart.Size = new System.Drawing.Size(90, 20);
            this.rdbFeedStart.TabIndex = 3;
            this.rdbFeedStart.TabStop = true;
            this.rdbFeedStart.Text = "喂丝开始";
            this.rdbFeedStart.UseVisualStyleBackColor = true;
            this.rdbFeedStart.CheckedChanged += new System.EventHandler(this.rdbFeedStart_CheckedChanged);
            // 
            // rdbPowerStop
            // 
            this.rdbPowerStop.AutoSize = true;
            this.rdbPowerStop.Location = new System.Drawing.Point(153, 56);
            this.rdbPowerStop.Name = "rdbPowerStop";
            this.rdbPowerStop.Size = new System.Drawing.Size(90, 20);
            this.rdbPowerStop.TabIndex = 2;
            this.rdbPowerStop.TabStop = true;
            this.rdbPowerStop.Text = "通电结束";
            this.rdbPowerStop.UseVisualStyleBackColor = true;
            this.rdbPowerStop.CheckedChanged += new System.EventHandler(this.rdbPowerStop_CheckedChanged);
            // 
            // rdbPowerStart
            // 
            this.rdbPowerStart.AutoSize = true;
            this.rdbPowerStart.Location = new System.Drawing.Point(57, 56);
            this.rdbPowerStart.Name = "rdbPowerStart";
            this.rdbPowerStart.Size = new System.Drawing.Size(90, 20);
            this.rdbPowerStart.TabIndex = 1;
            this.rdbPowerStart.TabStop = true;
            this.rdbPowerStart.Text = "通电开始";
            this.rdbPowerStart.UseVisualStyleBackColor = true;
            this.rdbPowerStart.CheckedChanged += new System.EventHandler(this.rdbPowerStart_CheckedChanged);
            // 
            // rdbLadleArrival
            // 
            this.rdbLadleArrival.AutoSize = true;
            this.rdbLadleArrival.Location = new System.Drawing.Point(57, 30);
            this.rdbLadleArrival.Name = "rdbLadleArrival";
            this.rdbLadleArrival.Size = new System.Drawing.Size(90, 20);
            this.rdbLadleArrival.TabIndex = 0;
            this.rdbLadleArrival.TabStop = true;
            this.rdbLadleArrival.Text = "钢包到达";
            this.rdbLadleArrival.UseVisualStyleBackColor = true;
            this.rdbLadleArrival.CheckedChanged += new System.EventHandler(this.rdbLadleArrival_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(89, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(200, 232);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManualControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(380, 290);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gBoxManualSignal);
            this.Controls.Add(this.lblManualControlTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "手动控制";
            this.gBoxManualSignal.ResumeLayout(false);
            this.gBoxManualSignal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManualControlTip;
        private System.Windows.Forms.GroupBox gBoxManualSignal;
        private System.Windows.Forms.RadioButton rdbLadleDepart;
        private System.Windows.Forms.RadioButton rdbFeedStop;
        private System.Windows.Forms.RadioButton rdbFeedStart;
        private System.Windows.Forms.RadioButton rdbPowerStop;
        private System.Windows.Forms.RadioButton rdbPowerStart;
        private System.Windows.Forms.RadioButton rdbLadleArrival;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}