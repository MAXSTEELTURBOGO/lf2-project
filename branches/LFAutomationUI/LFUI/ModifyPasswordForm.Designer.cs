namespace LFAutomationUI.LFUI
{
    partial class ModifyPasswordForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.lblOriginalPwd = new System.Windows.Forms.Label();
            this.lblNewPwd = new System.Windows.Forms.Label();
            this.lblConfirmPwd = new System.Windows.Forms.Label();
            this.panelModifyPwd = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtOriginalPassword = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelModifyPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(46, 198);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 38);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确认修改";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblOriginalPwd
            // 
            this.lblOriginalPwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOriginalPwd.Location = new System.Drawing.Point(12, 38);
            this.lblOriginalPwd.Name = "lblOriginalPwd";
            this.lblOriginalPwd.Size = new System.Drawing.Size(100, 21);
            this.lblOriginalPwd.TabIndex = 1;
            this.lblOriginalPwd.Text = "请输入原密码";
            this.lblOriginalPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNewPwd
            // 
            this.lblNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNewPwd.Location = new System.Drawing.Point(21, 94);
            this.lblNewPwd.Name = "lblNewPwd";
            this.lblNewPwd.Size = new System.Drawing.Size(91, 20);
            this.lblNewPwd.TabIndex = 2;
            this.lblNewPwd.Text = "输入新密码";
            this.lblNewPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfirmPwd
            // 
            this.lblConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfirmPwd.Location = new System.Drawing.Point(21, 146);
            this.lblConfirmPwd.Name = "lblConfirmPwd";
            this.lblConfirmPwd.Size = new System.Drawing.Size(91, 20);
            this.lblConfirmPwd.TabIndex = 3;
            this.lblConfirmPwd.Text = "确认新密码";
            this.lblConfirmPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelModifyPwd
            // 
            this.panelModifyPwd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelModifyPwd.Controls.Add(this.txtConfirmPassword);
            this.panelModifyPwd.Controls.Add(this.txtNewPassword);
            this.panelModifyPwd.Controls.Add(this.txtOriginalPassword);
            this.panelModifyPwd.Controls.Add(this.btnExit);
            this.panelModifyPwd.Controls.Add(this.lblOriginalPwd);
            this.panelModifyPwd.Controls.Add(this.btnOK);
            this.panelModifyPwd.Controls.Add(this.lblConfirmPwd);
            this.panelModifyPwd.Controls.Add(this.lblNewPwd);
            this.panelModifyPwd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panelModifyPwd.Location = new System.Drawing.Point(12, 12);
            this.panelModifyPwd.Name = "panelModifyPwd";
            this.panelModifyPwd.Size = new System.Drawing.Size(268, 249);
            this.panelModifyPwd.TabIndex = 5;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(118, 143);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(125, 23);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(118, 91);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(125, 23);
            this.txtNewPassword.TabIndex = 6;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtOriginalPassword
            // 
            this.txtOriginalPassword.Location = new System.Drawing.Point(118, 36);
            this.txtOriginalPassword.Name = "txtOriginalPassword";
            this.txtOriginalPassword.Size = new System.Drawing.Size(125, 23);
            this.txtOriginalPassword.TabIndex = 5;
            this.txtOriginalPassword.UseSystemPasswordChar = true;
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnExit.Location = new System.Drawing.Point(140, 198);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 38);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "关闭窗口";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ModifyPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.panelModifyPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifyPasswordForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.panelModifyPwd.ResumeLayout(false);
            this.panelModifyPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblOriginalPwd;
        private System.Windows.Forms.Label lblNewPwd;
        private System.Windows.Forms.Label lblConfirmPwd;
        private System.Windows.Forms.Panel panelModifyPwd;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOriginalPassword;
        private System.Windows.Forms.Button btnExit;
    }
}