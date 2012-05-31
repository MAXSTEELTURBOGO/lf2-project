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
    public partial class AllUsersInfoForm : Form
    {
        private IList<UserInfo> users;
        private IList<ClassesInfo> classes;
        private IList<RoleInfo> roles;
        public AllUsersInfoForm()
        {
            InitializeComponent();
        }

        private void AllUsersInfoForm_Load(object sender, EventArgs e)
        {
            Classes clsBLL = new Classes();
            this.classes = clsBLL.GetAllClasses();
            Role roleBLL = new Role();
            this.roles = roleBLL.GetAllRoles();
            RefreshForm();
            buildRoleCheckListBox();
        }

        private void buildRoleCheckListBox()
        {
            ckListBoxUserRoleInfo.Items.Clear();
            if (this.roles != null)
            {
                foreach (RoleInfo role in this.roles)
                {
                    ckListBoxUserRoleInfo.Items.Add(role.RoleName);
                }
            }

        }

        private void setRoleCheckListBox(IList<RoleInfo> roles)
        {
            clearRoleCheckListBox();
            if (roles != null)
            {
                foreach (RoleInfo role in roles)
                {
                    int index = ckListBoxUserRoleInfo.Items.IndexOf(role.RoleName);
                    ckListBoxUserRoleInfo.SetItemChecked(index, true);
                }
            }
        }

        private void clearRoleCheckListBox()
        {
            for (int i = 0; i < ckListBoxUserRoleInfo.Items.Count; i++)
            {
                ckListBoxUserRoleInfo.SetItemChecked(i, false);
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

        private void RefreshForm()
        {
            User userBLL = new User();
            this.users = userBLL.GetAllUsers();
            lvUserInfo.Items.Clear();
            foreach (UserInfo user in users)
            {
                ListViewItem lvItem = new ListViewItem(user.UserId.ToString());
                lvItem.SubItems.Add(user.UserName);
                lvItem.SubItems.Add(user.ClassId);
                lvItem.SubItems.Add(user.CreatedDate.ToString());
                lvItem.SubItems.Add(user.LastModifiedDate.ToString());
                lvUserInfo.Items.Add(lvItem);
            }

        }

        protected void SetEditMode()
        {
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnNewUser.Enabled = false;
            this.btnEditUser.Enabled = false;
            this.btnDeleteUser.Enabled = false;
            this.txtUserName.ReadOnly = false;
            this.cmbClassId.Enabled = true;

            cmbClassId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassId.Items.Clear();
            cmbClassId.Items.Add("");
            foreach (ClassesInfo cls in classes)
            {
                cmbClassId.Items.Add(cls.ClassId);
            }

            this.lvUserInfo.Enabled = false;
            this.ckListBoxUserRoleInfo.Enabled = true;
        }

        protected void ClearEditMode()
        {
            this.btnOK.Enabled = false; ;
            this.btnCancel.Enabled = false;
            this.btnNewUser.Enabled = true;


            this.txtUserName.ReadOnly = true;
            cmbClassId.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbClassId.Enabled = false;
            this.lvUserInfo.Enabled = true;
            this.ckListBoxUserRoleInfo.Enabled = true;
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            SetEditMode();
            this.Text += " -- [新增用户模式]";

            clearUserInfo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEditMode();
            this.Text = "所有用户信息";
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            SetEditMode();
            this.cmbClassId.SelectedIndex = this.cmbClassId.FindString(this.lvUserInfo.SelectedItems[0].SubItems[2].Text);
            this.txtUserName.ReadOnly = true;
            this.Text += " -- [修改用户模式]";
        }

        private void lvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvUserInfo.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = lvUserInfo.SelectedItems[0];
                int userId = Convert.ToInt16(lvItem.SubItems[0].Text);
                UserInfo user = users.Single<UserInfo>(i => i.UserId == userId);
                showUserInfo(user);

                this.btnResetPassword.Enabled = true;
                this.btnEditUser.Enabled = true;
                this.btnDeleteUser.Enabled = true;
            }
            else
            {
                this.btnResetPassword.Enabled = false;
                this.btnEditUser.Enabled = false;
                this.btnDeleteUser.Enabled = false;
            }
        }

        private void showUserInfo(UserInfo user)
        {
            this.lblUserId.Text = user.UserId.ToString();
            this.txtUserName.Text = user.UserName;
            this.cmbClassId.Text = user.ClassId;
            this.lblCreatedDate.Text = user.CreatedDate.ToString();
            this.lblLastModifiedDate.Text = user.LastModifiedDate.ToString();

            setRoleCheckListBox(user.Roles);
        }

        private void clearUserInfo()
        {
            this.lblUserId.Text = "";
            this.lblCreatedDate.Text = "";
            this.lblLastModifiedDate.Text = "";
            this.txtUserName.Text = "";

            clearRoleCheckListBox();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt16(this.lblUserId.Text);
            UserInfo user = users.Single<UserInfo>(i => i.UserId == userId);
            if (MessageBox.Show("你确定要删除用户名为" + user.UserName + "的用户信息吗?", "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                User userBLL = new User();
                userBLL.DeleteUserInfo(user);
                MessageBox.Show("用户成功删除!", "提示");
                RefreshForm();
                ClearEditMode();
                clearUserInfo();
                this.btnEditUser.Enabled = false;
                this.btnDeleteUser.Enabled = false;
            }
        }

        private IList<RoleInfo> getRoles()
        {
            IList<RoleInfo> roles = new List<RoleInfo>();
            for (int i = 0; i < ckListBoxUserRoleInfo.CheckedItems.Count; i++)
            {
                string roleName = ckListBoxUserRoleInfo.CheckedItems[i].ToString();
                RoleInfo role = this.roles.Single<RoleInfo>(j => j.RoleName == roleName);
                roles.Add(role);
            }
            return roles;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.lblUserId.Text.Trim()))
            {
                //新增模式
                string userName = this.txtUserName.Text.Trim();
                string userPassword = "123456";
                string pattern = @"^[a-zA-Z0-9\u4e00-\u9fa5]{1,20}$";
                if (!Regex.IsMatch(userName, pattern) || !Regex.IsMatch(userPassword, @"^[a-zA-Z0-9]{6,20}$"))
                {
                    MessageBox.Show("用户名必须为1-20位的字母数字中文序列,\n密码必须为6-20位的字母数字序列", "提示");
                }
                else
                {
                    string classId = this.cmbClassId.Text;
                    User userBLL = new User();
                    UserInfo user = userBLL.GetUserInfo(userName);
                    if (user != null)
                    {
                        MessageBox.Show("用户名为" + userName + "的用户已经存在");
                    }
                    else
                    {
                        user = new UserInfo(userName, userPassword, classId);
                        user.Roles = getRoles();
                        userBLL.InsertUserInfo(user);
                        MessageBox.Show("用户添加成功!", "提示");
                        clearRoleCheckListBox();
                        ClearEditMode();
                        RefreshForm();
                    }
                }
            }
            else
            {
                //编辑模式
                int userId = Convert.ToInt16(this.lblUserId.Text);
                UserInfo user = this.users.Single<UserInfo>(i => i.UserId == userId);  
                if (MessageBox.Show("你确定要更新用户名为" + user.UserName + "的用户吗?", "确认更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    user.ClassId  = this.cmbClassId.Text;
                    user.Roles = getRoles();
                    User userBLL = new User();
                    userBLL.UpdateUserInfo(user);
                    MessageBox.Show("用户更新成功!", "提示");
                    clearRoleCheckListBox();
                    ClearEditMode();
                    RefreshForm();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt16(this.lblUserId.Text);
            UserInfo user = this.users.Single<UserInfo>(i => i.UserId == userId);

            if (MessageBox.Show("你确定要恢复用户名为" + user.UserName + "的密码为默认密码‘123456’吗?", "确认更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                user.UserPassword = "123456";

                User userBLL = new User();
                userBLL.UpdateUserInfo(user);
                MessageBox.Show("用户更新成功!", "提示");
                clearRoleCheckListBox();
                ClearEditMode();
                RefreshForm();
            }
        }

        private void ckListBoxUserRoleInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ckListBoxUserRoleInfo.SelectedIndex;
            for (int i = 0; i < ckListBoxUserRoleInfo.Items.Count; i++)
            {
                ckListBoxUserRoleInfo.SetItemChecked(i, false);
            }
            ckListBoxUserRoleInfo.SetItemChecked(index, true);
        }
    }
}
