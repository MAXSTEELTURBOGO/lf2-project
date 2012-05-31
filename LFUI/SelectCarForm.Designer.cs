namespace LFAutomationUI.LFUI
{
    partial class SelectCarForm
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
            this.lblTip = new System.Windows.Forms.Label();
            this.gBoxSelectCar = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdbCarTwo = new System.Windows.Forms.RadioButton();
            this.rdbCarOne = new System.Windows.Forms.RadioButton();
            this.gBoxSelectCar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.Location = new System.Drawing.Point(12, 9);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(240, 20);
            this.lblTip.TabIndex = 0;
            this.lblTip.Text = "请选择炉次冶炼所在工位";
            // 
            // gBoxSelectCar
            // 
            this.gBoxSelectCar.Controls.Add(this.btnCancel);
            this.gBoxSelectCar.Controls.Add(this.btnOK);
            this.gBoxSelectCar.Controls.Add(this.rdbCarTwo);
            this.gBoxSelectCar.Controls.Add(this.rdbCarOne);
            this.gBoxSelectCar.Font = new System.Drawing.Font("宋体", 12F);
            this.gBoxSelectCar.Location = new System.Drawing.Point(16, 35);
            this.gBoxSelectCar.Name = "gBoxSelectCar";
            this.gBoxSelectCar.Size = new System.Drawing.Size(236, 119);
            this.gBoxSelectCar.TabIndex = 3;
            this.gBoxSelectCar.TabStop = false;
            this.gBoxSelectCar.Text = "选择工位";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(117, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 33);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(36, 70);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdbCarTwo
            // 
            this.rdbCarTwo.AutoSize = true;
            this.rdbCarTwo.Location = new System.Drawing.Point(117, 31);
            this.rdbCarTwo.Name = "rdbCarTwo";
            this.rdbCarTwo.Size = new System.Drawing.Size(66, 20);
            this.rdbCarTwo.TabIndex = 4;
            this.rdbCarTwo.TabStop = true;
            this.rdbCarTwo.Text = "工位2";
            this.rdbCarTwo.UseVisualStyleBackColor = true;
            // 
            // rdbCarOne
            // 
            this.rdbCarOne.AutoSize = true;
            this.rdbCarOne.Location = new System.Drawing.Point(48, 31);
            this.rdbCarOne.Name = "rdbCarOne";
            this.rdbCarOne.Size = new System.Drawing.Size(66, 20);
            this.rdbCarOne.TabIndex = 3;
            this.rdbCarOne.TabStop = true;
            this.rdbCarOne.Text = "工位1";
            this.rdbCarOne.UseVisualStyleBackColor = true;
            // 
            // SelectHeatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 166);
            this.ControlBox = false;
            this.Controls.Add(this.gBoxSelectCar);
            this.Controls.Add(this.lblTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectHeatForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择工位";
            this.gBoxSelectCar.ResumeLayout(false);
            this.gBoxSelectCar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.GroupBox gBoxSelectCar;
        private System.Windows.Forms.RadioButton rdbCarTwo;
        private System.Windows.Forms.RadioButton rdbCarOne;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}