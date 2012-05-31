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
    public partial class ClassInfoForm : Form
    {
        private IList<ClassesInfo> classes;
        private int mode;
        public ClassInfoForm()
        {
            InitializeComponent();
        }

        private void ClassInfoForm_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            Classes clsBLL = new Classes();
            classes = clsBLL.GetAllClasses();
            lvClassesInfo.Items.Clear();
            foreach (ClassesInfo cls in classes)
            {
                ListViewItem lvItem = new ListViewItem(cls.ClassId);
                lvItem.SubItems.Add(cls.ClassHeader);
                lvClassesInfo.Items.Add(lvItem);
            }
            this.txtClassHeader.Text = "";
            this.txtClassId.Text = "";
        }

        private void btnNewClass_Click(object sender, EventArgs e)
        {
            SetEditMode();
            this.Text += " -- [新增班组模式]";
            this.txtClassId.ReadOnly = false;
            this.mode = 0;
            this.txtClassId.Text = "";
            this.txtClassHeader.Text = "";
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            SetEditMode();
            this.mode = 1;
            this.Text += " -- [修改班组模式]";
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            string classId = this.txtClassId.Text;
            if (MessageBox.Show("删除该班组将导致该班组上所有成员被删除!\n你确定要删除班组"+classId+"吗?","确认删除",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ClassesInfo cls = new ClassesInfo(classId);
                Classes clsBLL = new Classes();
                clsBLL.DeleteClassInfo(cls);
                MessageBox.Show("成功删除班组信息！","提示");
                RefreshForm();
                ClearEditMode();
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.mode == 0)
            {
                if (string.IsNullOrEmpty(this.txtClassId.Text.Trim()))
                {
                    MessageBox.Show("班组名称不能为空！", "提示");
                }
                else
                {
                    string classId = this.txtClassId.Text.Trim();
                    Classes clsBLL = new Classes();
                    if (clsBLL.GetClassInfo(classId) != null)
                    {
                        MessageBox.Show("已存在班组名为" + classId + "的班组信息.", "提示");
                    }
                    else
                    {
                        string classHeader = this.txtClassHeader.Text.Trim();
                        ClassesInfo cls = new ClassesInfo(classId, classHeader);
                        clsBLL.InsertClassInfo(cls);
                        MessageBox.Show("班组信息添加成功!", "提示");
                        RefreshForm();
                        ClearEditMode();
                    }
                }
            }
            else
            {
                string classId = this.txtClassId.Text.Trim();
                string classHeader = this.txtClassHeader.Text.Trim();
                if (MessageBox.Show("你确定更新班组名为" + classId + "的班组信息吗?", "确认更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Classes clsBLL = new Classes();
                    ClassesInfo cls = new ClassesInfo(classId, classHeader);
                    clsBLL.UpdateClassInfo(cls);
                    MessageBox.Show("班组信息更新成功!", "提示");
                    RefreshForm();
                    ClearEditMode();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearEditMode();
            this.Text = "班组信息管理";
        }

        private void btnCloseWindows_Click(object sender, EventArgs e)
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

        protected void SetEditMode()
        {
            this.btnNewClass.Enabled = false;
            this.btnEditClass.Enabled = false;
            this.btnDeleteClass.Enabled = false;
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;

            this.txtClassHeader.ReadOnly = false;

            this.lvClassesInfo.Enabled = false;
        }

        protected void ClearEditMode()
        {
            this.btnNewClass.Enabled = true;

            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = false;

            this.txtClassHeader.ReadOnly = true;
            this.txtClassId.ReadOnly = true;

            this.lvClassesInfo.Enabled = true;
        }

        private void lvClassesInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClassesInfo.SelectedItems.Count == 1)
            {
                ListViewItem lvItem = lvClassesInfo.SelectedItems[0];
                this.txtClassId.Text = lvItem.SubItems[0].Text;
                this.txtClassHeader.Text = lvItem.SubItems[1].Text;
                this.btnEditClass.Enabled = true;
                this.btnDeleteClass.Enabled = true;
            }
            else
            {
                this.txtClassId.Text = "";
                this.txtClassHeader.Text = "";
                this.btnEditClass.Enabled = false;
                this.btnDeleteClass.Enabled = false;
            }
        }

        
    }
}
