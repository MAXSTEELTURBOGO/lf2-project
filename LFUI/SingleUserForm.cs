using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class SingleUserForm : Form
    {
        private UserInfo user;
        public SingleUserForm(UserInfo user)
        {
            InitializeComponent();
            this.user = user;
        }


        private void btnClose_Click(object sender, EventArgs e)
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
        private void SingleUserForm_Load(object sender, EventArgs e)
        {
            this.lblUserName.Text = user.UserName;
            this.lblClass.Text = user.ClassId;
            this.lblCreatedDate.Text = user.CreatedDate.ToString();
            this.lblLastModifiedDate.Text = user.LastModifiedDate.ToString();

            foreach (RoleInfo role in user.Roles)
            {
                this.lvRoleInfo.Items.Add(role.RoleName);
            }

            foreach (PrivilegeInfo privi in user.Privileges)
            {
                ListViewItem lvi = new ListViewItem(privi.PrivilegeName);
                lvi.SubItems.Add(privi.PriviDescription == 1 ? "绝对拥有" : ((privi.PriviDescription == 3) ? "意向拥有" : "拒绝"));
                this.lvPriviInfo.Items.Add(lvi);
            }
        }

        private void btnModifyPassword_Click(object sender, EventArgs e)
        {
            ModifyPasswordForm modifyPasswordForm = new ModifyPasswordForm(user);
            DialogResult d = modifyPasswordForm.ShowDialog();
        }
    }
}
