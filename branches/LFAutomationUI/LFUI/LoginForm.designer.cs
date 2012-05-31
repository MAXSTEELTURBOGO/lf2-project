namespace LFAutomationUI.LFUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtUserPwd = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblCopyRight = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxLoginInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxLoginBtn = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxLoginInfo.SuspendLayout();
            this.groupBoxLoginBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(21, 15);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 24);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登录系统";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(21, 44);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 24);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出系统";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtUserPwd
            // 
            this.txtUserPwd.Location = new System.Drawing.Point(96, 46);
            this.txtUserPwd.MaxLength = 50;
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '*';
            this.txtUserPwd.Size = new System.Drawing.Size(124, 21);
            this.txtUserPwd.TabIndex = 6;
            this.txtUserPwd.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(96, 17);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(124, 21);
            this.txtUserName.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassword.Location = new System.Drawing.Point(38, 46);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(37, 20);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "密码";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(24, 17);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(51, 20);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "用户名";
            // 
            // lblCopyRight
            // 
            this.lblCopyRight.AutoSize = true;
            this.lblCopyRight.Location = new System.Drawing.Point(126, 255);
            this.lblCopyRight.Name = "lblCopyRight";
            this.lblCopyRight.Size = new System.Drawing.Size(167, 12);
            this.lblCopyRight.TabIndex = 4;
            this.lblCopyRight.Text = "Copyright@2010 西安理工大学";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LFAutomationUI.LFUI.Properties.Resources.登陆图片;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(396, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // groupBoxLoginInfo
            // 
            this.groupBoxLoginInfo.Controls.Add(this.lblUserName);
            this.groupBoxLoginInfo.Controls.Add(this.txtUserPwd);
            this.groupBoxLoginInfo.Controls.Add(this.txtUserName);
            this.groupBoxLoginInfo.Controls.Add(this.lblPassword);
            this.groupBoxLoginInfo.Location = new System.Drawing.Point(12, 158);
            this.groupBoxLoginInfo.Name = "groupBoxLoginInfo";
            this.groupBoxLoginInfo.Size = new System.Drawing.Size(272, 82);
            this.groupBoxLoginInfo.TabIndex = 7;
            this.groupBoxLoginInfo.TabStop = false;
            // 
            // groupBoxLoginBtn
            // 
            this.groupBoxLoginBtn.Controls.Add(this.btnLogin);
            this.groupBoxLoginBtn.Controls.Add(this.btnExit);
            this.groupBoxLoginBtn.Location = new System.Drawing.Point(290, 158);
            this.groupBoxLoginBtn.Name = "groupBoxLoginBtn";
            this.groupBoxLoginBtn.Size = new System.Drawing.Size(117, 82);
            this.groupBoxLoginBtn.TabIndex = 8;
            this.groupBoxLoginBtn.TabStop = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(419, 273);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxLoginBtn);
            this.Controls.Add(this.groupBoxLoginInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCopyRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "欢迎使用济钢LF-230t自动化系统";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxLoginInfo.ResumeLayout(false);
            this.groupBoxLoginInfo.PerformLayout();
            this.groupBoxLoginBtn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtUserPwd;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblCopyRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxLoginInfo;
        private System.Windows.Forms.GroupBox groupBoxLoginBtn;
    }
}