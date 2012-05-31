using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;
using System.Text.RegularExpressions;

namespace LFAutomationUI.LFUI
{
    public partial class LoginInfoForm : Form
    {
        private IList<LoginInfo> loginList;
        public LoginInfoForm()
        {
            Login loginBLL = new Login();
            loginList = loginBLL.GetAllLoginInfo();

            InitializeComponent();
        }

        private void LoginInfoForm_Load(object sender, EventArgs e)
        {
            BindListViewLoginInfo(this.loginList);
        }

        private void BindListViewLoginInfo(IList<LoginInfo> loginList)
        {
            this.lvLoginInfo.Items.Clear();
            foreach (LoginInfo item in loginList)
            {
                ListViewItem lvItem = new ListViewItem(item.MsgId.ToString());
                lvItem.SubItems.Add(item.MsgTimeStamp.ToString());
                lvItem.SubItems.Add(item.User.UserName);
                lvItem.SubItems.Add(item.User.ClassId);
                lvItem.SubItems.Add(item.LoginTime.ToString());
                lvItem.SubItems.Add(item.LogoffTime.ToString());
                lvLoginInfo.Items.Add(lvItem);
            }
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void btnSearchByTimeSpan_Click(object sender, EventArgs e)
        {
            if (mTextBoxStartTime.MaskCompleted || mTextBoxEndTime.MaskCompleted)
            {
                DateTime startTime;
                DateTime endTime;
                if (DateTime.TryParse(this.mTextBoxStartTime.Text.Trim(), out startTime) && DateTime.TryParse(this.mTextBoxEndTime.Text, out endTime))
                {
                    IList<LoginInfo> loginListWithTimeSpan = (from i in this.loginList
                                                             where i.LoginTime >= startTime && i.LoginTime <= endTime
                                                             select i).ToList<LoginInfo>();
                    BindListViewLoginInfo(loginListWithTimeSpan);
                }
                else
                {
                    MessageBox.Show("时间格式输入不正确，请检查输入！","提示");
                }
            }
            else
            {
                MessageBox.Show("开始时间和结束时间均不能为空","提示");
            }
        }

        private void btnSearchByUserName_Click(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9\u4e00-\u9fa5]{1,20}$";
            if (Regex.IsMatch(this.txtUserName.Text.Trim(), pattern))
            {
                string userName = this.txtUserName.Text.Trim();
                IList<LoginInfo> loginList = (from i in this.loginList
                                              where i.User.UserName == userName
                                              select i).ToList<LoginInfo>();
                BindListViewLoginInfo(loginList);
            }
            else
            {
                MessageBox.Show("用户名必须为1-20位的字母数字中文序列","提示");
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            BindListViewLoginInfo(this.loginList);
        }
    }
}
