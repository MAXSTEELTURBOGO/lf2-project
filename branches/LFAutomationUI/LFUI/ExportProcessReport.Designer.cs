namespace LFAutomationUI.LFUI
{
    partial class ExportProcessReport
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
            this.proBarExportExcel = new System.Windows.Forms.ProgressBar();
            this.lblExportExcelState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // proBarExportExcel
            // 
            this.proBarExportExcel.Location = new System.Drawing.Point(12, 12);
            this.proBarExportExcel.Maximum = 11;
            this.proBarExportExcel.Name = "proBarExportExcel";
            this.proBarExportExcel.Size = new System.Drawing.Size(300, 23);
            this.proBarExportExcel.TabIndex = 0;
            // 
            // lblExportExcelState
            // 
            this.lblExportExcelState.AutoSize = true;
            this.lblExportExcelState.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExportExcelState.Location = new System.Drawing.Point(10, 48);
            this.lblExportExcelState.Name = "lblExportExcelState";
            this.lblExportExcelState.Size = new System.Drawing.Size(84, 14);
            this.lblExportExcelState.TabIndex = 1;
            this.lblExportExcelState.Text = "正在导出...";
            // 
            // ExportProcessReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 81);
            this.ControlBox = false;
            this.Controls.Add(this.lblExportExcelState);
            this.Controls.Add(this.proBarExportExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportProcessReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在导出...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar proBarExportExcel;
        public System.Windows.Forms.Label lblExportExcelState;

    }
}