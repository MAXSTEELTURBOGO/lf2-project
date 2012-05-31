using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LFAutomationUI.Model;
using LFAutomationUI.BLL;

namespace LFAutomationUI.LFUI
{
    public partial class ModifyPasswordForm : Form
    {
        private UserInfo user;
        public ModifyPasswordForm(UserInfo user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (user.UserPassword == Encryption.Encrypt(this.txtOriginalPassword.Text.Trim(),user.UserName))
            {
                string pattern = @"^[0-9a-zA-Z]{6,20}$";
                string newPwd = this.txtNewPassword.Text.Trim();
                string confirmPwd=this.txtConfirmPassword.Text.Trim();
                if (Regex.IsMatch(newPwd, pattern) && Regex.IsMatch(confirmPwd, pattern))
                {
                    if (newPwd == confirmPwd)
                    {
                        User userBLL = new User();
                        userBLL.ModifyPassword(user, newPwd);
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("密码修改成功!","提示");
                    }
                    else
                    {
                        MessageBox.Show("新密码与确认密码必须相同!","提示");
                    }
                }
                else
                {
                    MessageBox.Show("密码必须为6-20为的数字、字母序列!","提示");
                }
            }
            else
            {
                MessageBox.Show("原密码输入不正确!","提示");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult ==DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
    }
}
