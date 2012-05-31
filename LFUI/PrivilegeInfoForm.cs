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

namespace LFAutomationUI.LFUI
{
    public partial class PrivilegeInfoForm : Form
    {
        private IList<PrivilegeInfo> privileges;

        public PrivilegeInfoForm()
        {
            InitializeComponent();
        }

        public PrivilegeInfoForm(IList<PrivilegeInfo> privileges)
        {
            InitializeComponent();
            this.privileges = privileges;
        }
        private void PrivilegeInfoForm_Load(object sender, EventArgs e)
        {
            if (privileges == null)
            {
                Privilege priviBLL = new Privilege();
                privileges = priviBLL.GetAllPrivileges();
            }

            foreach (PrivilegeInfo privi in privileges)
            {
                ListViewItem lvItem = new ListViewItem(privi.PrivilegeId.ToString());
                lvItem.SubItems.Add(privi.PrivilegeName);
                lvItem.SubItems.Add(privi.CreatedDate.ToString());
                lvItem.SubItems.Add(privi.LastModifiedDate.ToString());
                lvItem.SubItems.Add(privi.ParentPrivilegeId.ToString());
                lvPrivileges.Items.Add(lvItem);
            }
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }

        private void lvPrivileges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPrivileges.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = lvPrivileges.SelectedItems[0];
                this.lblPrivilegeId.Text = lvItem.SubItems[0].Text;
                this.txtPrivilegeName.Text = lvItem.SubItems[1].Text;
                this.lblCreatedDate.Text = lvItem.SubItems[2].Text;
                this.lblLastModifiedDate.Text = lvItem.SubItems[3].Text;
                this.cmbParentPrivilegeId.Text = lvItem.SubItems[4].Text;
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetEditMode();
            cmbParentPrivilegeIdDataBind();
            this.lblPrivilegeId.Text = "";
            this.lblCreatedDate.Text = "";
            this.lblLastModifiedDate.Text = "";
            this.txtPrivilegeName.Text = "";
        }

        private void SetEditMode()
        {
            this.txtPrivilegeName.Enabled = true;
            this.cmbParentPrivilegeId.Enabled = true;
            this.cmbParentPrivilegeId.DropDownStyle = ComboBoxStyle.DropDownList;

            this.btnNew.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnDelete.Enabled = false;
            this.lvPrivileges.Enabled = false;

            this.btnOK.Enabled = true;
            this.btnCancle.Enabled = true;
        }
        private void ClearEditMode()
        {
            this.txtPrivilegeName.Enabled = false;
            this.cmbParentPrivilegeId.Enabled = false;
            this.cmbParentPrivilegeId.DropDownStyle = ComboBoxStyle.DropDown;

            this.btnNew.Enabled = true;
            this.btnEdit.Enabled = true;
            this.btnDelete.Enabled = true;
            this.lvPrivileges.Enabled = true;

            this.btnOK.Enabled = false;
            this.btnCancle.Enabled = false;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            ClearEditMode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lblPrivilegeId.Text))
            {
                MessageBox.Show("当前未选中项!", "提示");
            }
            else
            {
                SetEditMode();
                cmbParentPrivilegeIdDataBind();
                this.cmbParentPrivilegeId.SelectedIndex = this.cmbParentPrivilegeId.FindString(this.lvPrivileges.SelectedItems[0].SubItems[4].Text);
            }
        }

        private void cmbParentPrivilegeIdDataBind()
        {
            this.cmbParentPrivilegeId.Items.Clear();
            this.cmbParentPrivilegeId.Items.Add("0");
            foreach (PrivilegeInfo privi in privileges)
            {
                this.cmbParentPrivilegeId.Items.Add(privi.PrivilegeId);
            }
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            Privilege priviBLL = new Privilege();
            if (string.IsNullOrEmpty(this.lblPrivilegeId.Text)) //新增权限信息
            {
                int count = (from i in privileges where i.PrivilegeName == this.txtPrivilegeName.Text select i).Count();
                if (count == 0)
                {
                    if (string.IsNullOrEmpty(this.txtPrivilegeName.Text))
                    {
                        MessageBox.Show("权限名称不能为空", "提示");
                    }
                    else
                    {
                        string privilegeName = this.txtPrivilegeName.Text.Trim();
                        int parentPrivilegeId;
                        try
                        {
                            parentPrivilegeId = Convert.ToInt16(this.cmbParentPrivilegeId.Text);

                        }
                        catch (Exception)
                        {
                            parentPrivilegeId = 0;
                        }

                        PrivilegeInfo privilege = new PrivilegeInfo(privilegeName, parentPrivilegeId);
                        priviBLL.InsertPrivilegeInfo(privilege);
                        MessageBox.Show("记录添加成功!", "提示");
                        ClearEditMode();
                        this.txtPrivilegeName.Text = "";
                        this.cmbParentPrivilegeId.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("输入的权限信息名称已存在，请重新输入！");
                    txtPrivilegeName.Text = "";
                    return;
                } 
            }
            else //修改权限信息
            {
                if (string.IsNullOrEmpty(this.txtPrivilegeName.Text))
                {
                    MessageBox.Show("权限名称不能为空", "提示");
                }
                else
                {
                    int privilegeId=Convert.ToInt16(this.lblPrivilegeId.Text);
                    string privilegeName = this.txtPrivilegeName.Text.Trim();
                    int parentPrivilegeId = string.IsNullOrEmpty(this.cmbParentPrivilegeId.Text) ? 0 : Convert.ToInt16(this.cmbParentPrivilegeId.Text);
                    PrivilegeInfo privilege = privileges.Single<PrivilegeInfo>(i => i.PrivilegeId == privilegeId);
                    if (SearchChild(parentPrivilegeId, privilege) == true)
                    {
                        MessageBox.Show("不能将父亲节点设置为自己的子孙节点!", "提示");
                    }
                    else
                    {
                        if (MessageBox.Show("你确定要更新编号为\n"+privilege.PrivilegeId.ToString()+"\n的权限信息吗?","确认更新",MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
                        {
                            
                        }
                        privilege.PrivilegeName = privilegeName;
                        privilege.ParentPrivilegeId = parentPrivilegeId;

                        priviBLL.UpdatePrivilegeInfo(privilege);
                        MessageBox.Show("权限信息更新成功!", "提示");
                        lvPrivilegeInfoDataBind();
                        ClearEditMode();
                        ClearAll();
                    }
                }
            }
            lvPrivilegeInfoDataBind();
        }

        private void lvPrivilegeInfoDataBind()
        {
            lvPrivileges.Items.Clear();
            Privilege priviBLL=new Privilege();
            privileges = priviBLL.GetAllPrivileges();
            foreach (PrivilegeInfo privi in privileges)
            {
                ListViewItem lvItem = new ListViewItem(privi.PrivilegeId.ToString());
                lvItem.SubItems.Add(privi.PrivilegeName);
                lvItem.SubItems.Add(privi.CreatedDate.ToString());
                lvItem.SubItems.Add(privi.LastModifiedDate.ToString());
                lvItem.SubItems.Add(privi.ParentPrivilegeId.ToString());
                lvPrivileges.Items.Add(lvItem);
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"确定要删除权限名称为\n\""+this.txtPrivilegeName.Text+"\"\n的权限信息吗?","确认删除",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                int privilegeId = Convert.ToInt16(this.lblPrivilegeId.Text);
                string privilegeName = this.txtPrivilegeName.Text;
                int parentPrivilgeId = Convert.ToInt16(this.cmbParentPrivilegeId.Text);
                DateTime createdDate = Convert.ToDateTime(this.lblCreatedDate.Text);
                DateTime lastModifiedDate = Convert.ToDateTime(this.lblLastModifiedDate.Text);
                PrivilegeInfo privilege = new PrivilegeInfo(privilegeId, privilegeName, parentPrivilgeId, createdDate, lastModifiedDate);
                Privilege priviBLL = new Privilege();
                priviBLL.DeletePrivilegeInfo(privilege);
                MessageBox.Show("权限信息删除成功!","提示");
                lvPrivilegeInfoDataBind();
            }
        }

        private bool SearchChild(int childPrivilegeId, PrivilegeInfo privilege)
        {
            if (privilege.PrivilegeId == childPrivilegeId)
            {
                return true;
            }
            else
            {
                IEnumerable<PrivilegeInfo> enumPrivileges = from i in privileges
                                                            where i.ParentPrivilegeId == privilege.PrivilegeId
                                                            select i;
                foreach (PrivilegeInfo privi in enumPrivileges)
                {
                    if (SearchChild(childPrivilegeId,privi) == true)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 清空所有显示项
        /// </summary>
        private void ClearAll()
        {
            this.lblPrivilegeId.Text = "";
            this.txtPrivilegeName.Text = "";
            this.cmbParentPrivilegeId.Text = "";
            this.lblCreatedDate.Text = "";
            this.lblLastModifiedDate.Text = "";
        }


    }
}
