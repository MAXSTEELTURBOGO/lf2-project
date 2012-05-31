using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class LoginForm : Form
    {
        public UserInfo User;
        public LoginForm()
        {
            User = null;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text;
            string userPassword = this.txtUserPwd.Text;

            string patternUserName = @"^[a-zA-Z0-9\u4e00-\u9fa5]{1,20}$";
            string patternPwd = @"^[a-z0-9A-Z]{6,20}$";

            if (Regex.IsMatch(userName, patternUserName) && Regex.IsMatch(userPassword, patternPwd))
            {
                User userBLL = new User();
                User = userBLL.GetUserInfo(userName,userPassword);
                if (User != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("登录失败!请重新登录!","提示");
                }
            }
            else
            {
                MessageBox.Show("用户名必须为1-20位的字母数字中文序列，密码必须为6-20为的字母数字序列", "错误提示");
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
            
        }
    }
}
