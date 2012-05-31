namespace LFAutomationUI.LFUI
{
    partial class ChooseHeatOptionForm
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
            this.gBoxChoose = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbReplace = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdbEndLastAndStartNew = new System.Windows.Forms.RadioButton();
            this.lblTip = new System.Windows.Forms.Label();
            this.gBoxChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxChoose
            // 
            this.gBoxChoose.Controls.Add(this.label2);
            this.gBoxChoose.Controls.Add(this.label1);
            this.gBoxChoose.Controls.Add(this.rdbReplace);
            this.gBoxChoose.Controls.Add(this.btnCancel);
            this.gBoxChoose.Controls.Add(this.btnOK);
            this.gBoxChoose.Controls.Add(this.rdbEndLastAndStartNew);
            this.gBoxChoose.Controls.Add(this.lblTip);
            this.gBoxChoose.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gBoxChoose.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.gBoxChoose.Location = new System.Drawing.Point(12, 12);
            this.gBoxChoose.Name = "gBoxChoose";
            this.gBoxChoose.Size = new System.Drawing.Size(574, 332);
            this.gBoxChoose.TabIndex = 0;
            this.gBoxChoose.TabStop = false;
            this.gBoxChoose.Text = "仔细阅读选项，然后进行选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("KaiTi_GB2312", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(51, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "（该情况可能由于上次冶炼结束信号未正常到达引起）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("KaiTi_GB2312", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(51, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "（该情况可能由于选择延误引起）";
            // 
            // rdbReplace
            // 
            this.rdbReplace.AutoSize = true;
            this.rdbReplace.Checked = true;
            this.rdbReplace.Font = new System.Drawing.Font("KaiTi_GB2312", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbReplace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdbReplace.Location = new System.Drawing.Point(38, 99);
            this.rdbReplace.Name = "rdbReplace";
            this.rdbReplace.Size = new System.Drawing.Size(447, 61);
            this.rdbReplace.TabIndex = 4;
            this.rdbReplace.TabStop = true;
            this.rdbReplace.Text = "\r\n使用当前选择炉次替换“正在冶炼”的炉次\r\n被替换炉次的冶炼信息将复制到新选择的炉次上";
            this.rdbReplace.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(312, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 34);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Location = new System.Drawing.Point(131, 278);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(131, 34);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确  定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdbEndLastAndStartNew
            // 
            this.rdbEndLastAndStartNew.AutoSize = true;
            this.rdbEndLastAndStartNew.Font = new System.Drawing.Font("KaiTi_GB2312", 14.25F);
            this.rdbEndLastAndStartNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdbEndLastAndStartNew.Location = new System.Drawing.Point(38, 202);
            this.rdbEndLastAndStartNew.Name = "rdbEndLastAndStartNew";
            this.rdbEndLastAndStartNew.Size = new System.Drawing.Size(487, 23);
            this.rdbEndLastAndStartNew.TabIndex = 3;
            this.rdbEndLastAndStartNew.Text = "强制结束\"正在冶炼\"的炉次，并选择您当前选择炉次";
            this.rdbEndLastAndStartNew.UseVisualStyleBackColor = true;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTip.Location = new System.Drawing.Point(51, 24);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(384, 72);
            this.lblTip.TabIndex = 2;
            this.lblTip.Text = "工位{0}上存在炉次号:{1} 的炉次“正在冶炼”，\r\n你所选择的炉次炉次号:{2}\r\n有两种情况可以进行选择:";
            // 
            // ChooseHeatOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(598, 364);
            this.ControlBox = false;
            this.Controls.Add(this.gBoxChoose);
            this.Font = new System.Drawing.Font("SimSun", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseHeatOptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请仔细阅读后，进行选择";
            this.gBoxChoose.ResumeLayout(false);
            this.gBoxChoose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxChoose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.RadioButton rdbReplace;
        private System.Windows.Forms.RadioButton rdbEndLastAndStartNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}