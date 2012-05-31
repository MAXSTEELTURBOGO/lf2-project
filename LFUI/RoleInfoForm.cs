using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class RoleInfoForm : Form
    {
        private IList<RoleInfo> roles;
        IList<PrivilegeInfo> privileges;
        public RoleInfoForm()
        {
            InitializeComponent();
        }
        public RoleInfoForm(IList<RoleInfo> roles)
        {
            InitializeComponent();
            this.roles = roles;
        }

        private void RoleInfoForm_Load(object sender, EventArgs e)
        {
            Privilege priviBLL = new Privilege();
            privileges = priviBLL.GetAllPrivileges();
            RefreshForm();
        }

        private void RefreshForm()
        {
            lvRolesInfo.Items.Clear();
            treeViewPrivileges.Nodes.Clear();
            treeViewPrivileges.Nodes.Add("Root");

            Role roleBLL = new Role();
            this.roles = roleBLL.GetAllRoles();

            foreach (RoleInfo role in roles)
            {
                ListViewItem lvItem = new ListViewItem(role.RoleID.ToString());
                lvItem.SubItems.Add(role.RoleName);
                lvItem.SubItems.Add(role.CreatedDate.ToString());
                lvItem.SubItems.Add(role.LastModifiedDate.ToString());
                lvRolesInfo.Items.Add(lvItem);
            }

            TreeNode rootTreeNode = treeViewPrivileges.Nodes[0];
            IEnumerable<PrivilegeInfo> enumPrivi = privileges.Where<PrivilegeInfo>(i => i.ParentPrivilegeId == 0);
            foreach (PrivilegeInfo privi in enumPrivi)
            {
                BuildPrivilegeTree(rootTreeNode, privi, privileges);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lvRolesInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvRolesInfo.SelectedItems.Count == 1)
            {
                this.btnEditRole.Enabled = true;
                this.btnDeleteRole.Enabled = true;
                this.btnModifyMenuPrivilege.Enabled = true;

                int roleId = Convert.ToInt16(this.lvRolesInfo.SelectedItems[0].SubItems[0].Text);
                RoleInfo role = roles.Single<RoleInfo>(i => i.RoleID == roleId);

                if (role.Privileges != null)
                {
                    foreach (TreeNode treeNode in treeViewPrivileges.Nodes[0].Nodes)
                    {
                        SetTreeNode(treeNode, role.Privileges);
                    }
                }
                else
                {
                    DisableTreeNode(treeViewPrivileges.Nodes[0]);
                }
                this.lblRoleId.Text = role.RoleID.ToString();
                this.txtRoleName.Text = role.RoleName;
                this.lblCreatedDate.Text = role.CreatedDate.ToString();
                this.lblLastModifiedDate.Text = role.LastModifiedDate.ToString();
            }
            else
            {
                this.btnEditRole.Enabled = false;
                this.btnDeleteRole.Enabled = false;
                this.btnModifyMenuPrivilege.Enabled = false;
            }
        }



        /// <summary>
        /// 创建树节点结构
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        /// <param name="privilege">当前权限信息</param>
        /// <param name="privileges">所有权限信息</param>
        private void BuildPrivilegeTree(TreeNode treeNode, PrivilegeInfo privilege, IList<PrivilegeInfo> privileges)
        {
            TreeNode thisTreeNode = treeNode.Nodes.Add(privilege.PrivilegeName);

            IEnumerable<PrivilegeInfo> enumPrivilege = privileges.Where<PrivilegeInfo>(i => i.ParentPrivilegeId == privilege.PrivilegeId);
            if (enumPrivilege.Count() > 0)
            {
                foreach (PrivilegeInfo privi in enumPrivilege)
                {
                    BuildPrivilegeTree(thisTreeNode, privi, privileges);
                }
            }
        }

        private void btnNewRole_Click(object sender, EventArgs e)
        {
            this.lblRoleId.Text = "";
            this.txtRoleName.Text = "";
            this.lblCreatedDate.Text = "";
            this.lblLastModifiedDate.Text = "";
            SetEditMode();
            DisableTreeNode(treeViewPrivileges.Nodes[0]);
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEditMode();
        }

        private void btnModifyMenuPrivilege_Click(object sender, EventArgs e)
        {
            RoleInfo role = roles.Single<RoleInfo>(i => i.RoleID == Convert.ToInt16(this.lblRoleId.Text));
            Role roleBLL = new Role();
            role.RoleName = this.txtRoleName.Text.Trim();
            role.Privileges = TranslateTree();
            roleBLL.UpdateRoleInfo(role);
            MessageBox.Show("菜单权限信息更新成功！", "提示");
        }

        private void treeViewPrivileges_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked)
                {
                    EnableTreeNode(e.Node);
                }
                else
                {
                    DisableTreeNode(e.Node);
                }
            }
            SetParentTreeNode(e.Node);
        }


        /// <summary>
        /// 设置指定节点的父节点状态
        /// </summary>
        /// <param name="treeNode">树节点</param>
        private void SetParentTreeNode(TreeNode treeNode)
        {
            TreeNode parentTreeNode = treeNode.Parent;
            if (parentTreeNode != treeViewPrivileges.Nodes[0] && treeNode != treeViewPrivileges.Nodes[0])
            {
                if (treeNode.Checked)
                {
                    parentTreeNode.Checked=true;
                    parentTreeNode.ForeColor=Color.Green;

                    foreach (TreeNode node in parentTreeNode.Nodes)
                    {
                        if (node.ForeColor != Color.Green)
                        {
                            parentTreeNode.ForeColor = Color.Blue;
                            break;
                        }
                    }
                }
                else
                {
                    parentTreeNode.Checked = false;
                    parentTreeNode.ForeColor = Color.Red;

                    foreach (TreeNode node in parentTreeNode.Nodes)
                    {
                        if (node.ForeColor != Color.Red)
                        {
                            parentTreeNode.ForeColor = Color.Blue;
                            parentTreeNode.Checked = true;
                            break;
                        }
                    }

                }
                SetParentTreeNode(parentTreeNode);
            }
        }

        /// <summary>
        /// 设置角色信息编辑模式
        /// </summary>
        private void SetEditMode()
        {
            this.btnNewRole.Enabled = false;
            this.btnEditRole.Enabled = false;
            this.btnDeleteRole.Enabled = false;
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
            this.txtRoleName.Enabled = true;
            this.lvRolesInfo.Enabled = false;
        }

        /// <summary>
        /// 清楚角色信息编辑模式
        /// </summary>
        private void ClearEditMode()
        {
            this.btnNewRole.Enabled = true;
            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = false;

            this.txtRoleName.Enabled = false;
            this.lvRolesInfo.Enabled = true;
        }


        private void DisableTreeNode(TreeNode treeNode)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                DisableTreeNode(treeNode.Nodes[i]);
            }

            treeNode.Checked = false;
            treeNode.ForeColor = Color.Red;
        }

        private void EnableTreeNode(TreeNode treeNode)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                EnableTreeNode(treeNode.Nodes[i]);
            }

            treeNode.Checked = true;
            treeNode.ForeColor = Color.Green;
        }

        private void SetTreeNode(TreeNode treeNode, IList<PrivilegeInfo> privileges)
        {
            try
            {
                PrivilegeInfo privi = (from i in privileges
                                       where i.PrivilegeName == treeNode.Text
                                       select i).First();

                if (privi.PriviDescription == 1)
                {
                    EnableTreeNode(treeNode);
                }
                else
                {
                    if (privi.PriviDescription == 2)
                    {
                        DisableTreeNode(treeNode);
                    }
                    else
                    {

                        treeNode.Checked = true;
                        treeNode.ForeColor = Color.Blue;

                        for (int i = 0; i < treeNode.Nodes.Count; i++)
                        {
                            SetTreeNode(treeNode.Nodes[i], privileges);
                        }
                    }
                }
            }
            catch (Exception)
            {
                DisableTreeNode(treeNode);
            }

        }

        private IList<PrivilegeInfo> TranslateTree()
        {
  
            IList<PrivilegeInfo> privileges=new List<PrivilegeInfo>();
            foreach (TreeNode node in treeViewPrivileges.Nodes[0].Nodes)
            {
                TranslateTree(node, privileges);
            }
            return privileges;

        }
        private void TranslateTree(TreeNode treeNode,IList<PrivilegeInfo> privileges)
        {
            string privilegeName = treeNode.Text;
            PrivilegeInfo tempPrivi=this.privileges.Single<PrivilegeInfo>(i => i.PrivilegeName == privilegeName);
            tempPrivi.PriviDescription = TranslateColor(treeNode.ForeColor);
            privileges.Add(tempPrivi);

            foreach (TreeNode node in treeNode.Nodes)
            {
                TranslateTree(node, privileges);
            }
        }

        private int TranslateColor(Color color)
        {
            if (color == Color.Green)
            {
                return 1;
            }
            else 
            {
                if (color == Color.Red)
                {
                    return 2;
                }
                return 3;
            }
            

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lblRoleId.Text.Trim()))
            {
                if (string.IsNullOrEmpty(this.txtRoleName.Text.Trim()))
                {
                    MessageBox.Show("角色名称不能为空", "提示");
                }
                else
                {
                    string roleName = this.txtRoleName.Text.Trim();
                    RoleInfo role = new RoleInfo();
                    role.RoleName = roleName;
                    role.Privileges = TranslateTree();
                    Role roleBLL = new Role();
                    roleBLL.InsertRoleInfo(role);
                    MessageBox.Show("新建角色成功!", "提示");
                    ClearEditMode();
                    RefreshForm();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(this.txtRoleName.Text.Trim()))
                {
                    MessageBox.Show("角色名称不能为空", "提示");
                }
                else
                {
                    if (MessageBox.Show("确定要删除角色编号为\n"+this.lblRoleId.Text+"\n的角色信息吗?","确认删除",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        RoleInfo role = roles.Single<RoleInfo>(i => i.RoleID == Convert.ToInt16(this.lblRoleId.Text));
                        Role roleBLL = new Role();
                        role.RoleName = this.txtRoleName.Text.Trim();
                        role.Privileges = TranslateTree();
                        roleBLL.UpdateRoleInfo(role);
                        MessageBox.Show("角色信息更新成功！", "提示");
                        ClearEditMode();
                        RefreshForm();
                    }     
                } 
            }
        }

        private void btnDeleteRole_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除角色名称为\n"+this.txtRoleName.Text+"\n的角色信息吗?","确认删除",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RoleInfo role = roles.Single<RoleInfo>(i => i.RoleID == Convert.ToInt16(this.lblRoleId.Text));
                Role roleBLL = new Role();
                roleBLL.DeleteRoleInfo(role);
                MessageBox.Show("角色信息删除成功！","提示");
                RefreshForm();
            }
            

        }


    }
}
