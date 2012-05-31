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
    public partial class BasicInfoForm : Form
    {
        Basic basicBLL;
        IList<BasicInfo> basicInfoList;
        public BasicInfoForm()
        {
            InitializeComponent();
        }

        private void BasicInfoForm_Load(object sender, EventArgs e)
        {
            basicBLL = new Basic();
            basicInfoList = basicBLL.GetBasicInfos();
            lvBasicInfoList_DataBind();
        }

        private void lvBasicInfoList_DataBind()
        {
            lvBasicInfoList.Items.Clear();
            foreach (BasicInfo basicInfo in basicInfoList)
            {
                ListViewItem item = new ListViewItem(basicInfo.InfoName);
                item.SubItems.Add(basicInfo.InfoData);
                item.SubItems.Add(basicInfo.InfoDescription);
                lvBasicInfoList.Items.Add(item);
            }
        }
        private void lvBasicInfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBasicInfoList.SelectedItems.Count > 0)
            {
                btnModify.Enabled = true;
                txtInfoName.Text = lvBasicInfoList.SelectedItems[0].SubItems[0].Text;
                txtInfoData.Text = lvBasicInfoList.SelectedItems[0].SubItems[1].Text;
                txtInfoDesc.Text = lvBasicInfoList.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                btnModify.Enabled = false;
                clearControlsContent();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtInfoName.ReadOnly = false;
            setEditMode();
            clearControlsContent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            setEditMode();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInfoName.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(txtInfoData.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(txtInfoDesc.Text.Trim()))
                    {
                        BasicInfo basicInfo = new BasicInfo(txtInfoName.Text, txtInfoData.Text, txtInfoDesc.Text);
                        if (txtInfoName.ReadOnly == false) //新增
                        {
                            if ((from i in basicInfoList where i.InfoName == txtInfoName.Text select i).Count() == 0)
                            {
                                basicBLL.InsertBasicInfo(basicInfo);
                                MessageBox.Show("基础信息添加成功！", "提示");
                            }
                            else
                            {
                                MessageBox.Show("当前输入的信息名称已经存在，请重新输入", "提示");
                                txtInfoName.Text = "";
                            }
                        }
                        else //修改
                        {
                            basicBLL.UpdateBasicInfo(basicInfo);
                            MessageBox.Show("基础信息修改成功！", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("信息描述不能为空！", "提示");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("信息数据不能为空！", "提示");
                    return;
                }
            }
            else
            {
                MessageBox.Show("信息名称不能为空！", "提示");
                return;
            }
            cancelEditMode();
            clearControlsContent();
            basicInfoList = basicBLL.GetBasicInfos();
            lvBasicInfoList_DataBind();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelEditMode();
            clearControlsContent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void setEditMode()
        {
            txtInfoData.ReadOnly = false;
            txtInfoDesc.ReadOnly = false;
            btnNew.Enabled = false;
            btnModify.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void cancelEditMode()
        {
            txtInfoName.ReadOnly = true;
            txtInfoData.ReadOnly = true;
            txtInfoDesc.ReadOnly = true;
            btnNew.Enabled = true;
            btnModify.Enabled = false;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            clearControlsContent();
        }
        private void clearControlsContent()
        {
            txtInfoName.Text = "";
            txtInfoDesc.Text = "";
            txtInfoData.Text = "";
        }

        private void txtInfoName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtInfoName.Text, @"^.{0,50}$"))
            {
                MessageBox.Show("输入的基础信息名称过长，请重新输入！","提示");
                txtInfoName.Text = "";
            }
        }

        private void txtInfoData_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtInfoData.Text, @"^.{0,50}$"))
            {
                MessageBox.Show("输入的基础信息数据过长，请重新输入！","提示");
                txtInfoData.Text = "";
            }
        }

        private void txtInfoDesc_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtInfoDesc.Text, @"^.{0,99}$"))
            {
                MessageBox.Show("输入的基础信息描述过长，请重新输入！","提示");
                txtInfoDesc.Text = "";
            }
        }
    }
}
