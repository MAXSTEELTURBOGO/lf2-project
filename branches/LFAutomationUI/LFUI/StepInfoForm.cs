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
    public partial class StepInfoForm : Form
    {
        Step step = new Step();

        /// <summary>
        /// 判断数字正则表达式（1-3位） “\d”等价于“[0-9]”
        /// </summary>
        private string pattern = @"\b\d{1,2}\b";

        public StepInfoForm()
        {
            InitializeComponent();
        }

        private void StepInfoForm_Load(object sender, EventArgs e)
        {
            lvStepInfo_DataBind();
        }
        private void lvStepInfo_DataBind()
        {
            lvStepInfo.Items.Clear();
            IList<StepInfo> stepInfos = step.GetAllStepInfo();
            foreach (StepInfo stepInfo in stepInfos)
            {
                ListViewItem item = new ListViewItem(stepInfo.StepId.ToString());
                item.SubItems.Add(stepInfo.StepName);
                lvStepInfo.Items.Add(item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvStepInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStepInfo.SelectedItems.Count>0)
            {
                txtStepId.Text = lvStepInfo.SelectedItems[0].SubItems[0].Text;
                txtStepName.Text = lvStepInfo.SelectedItems[0].SubItems[1].Text;
            }
        }

        private void btnNewStep_Click(object sender, EventArgs e)
        {
            txtStepId.Text = "";
            txtStepName.Text = "";
            txtStepId.ReadOnly = false;
            txtStepName.ReadOnly = false;
            btnNewStep.Enabled = false;
            btnModifyStep.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
            lvStepInfo.Enabled = false;
        }

        private void btnModifyStep_Click(object sender, EventArgs e)
        {
            txtStepName.ReadOnly = false;
            btnNewStep.Enabled = false;
            btnModifyStep.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
            lvStepInfo.Enabled = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtStepId.ReadOnly == false)    //新增步骤信息
            {
                if (Regex.IsMatch(txtStepId.Text,pattern))
                {
                    int stepCount = 0;
                    for (int i = 0; i < lvStepInfo.Items.Count; i++)
                    {
                        if (lvStepInfo.Items[i].SubItems[0].Text == txtStepId.Text)
                        {
                            stepCount++;
                        }
                    }
                    if (stepCount == 0)
                    {
                        StepInfo stepInfo = new StepInfo(Convert.ToInt32(txtStepId.Text), txtStepName.Text);
                        step.InsertNewStepInfo(stepInfo);
                        txtStepId.ReadOnly = true;
                    }
                    else
                    {
                        MessageBox.Show("该步骤号已存在，请输入新的步骤号！");
                    }
                }
                else
                {
                    MessageBox.Show("步骤号必须为数字，请重新输入！");
                }
            }
            else    //更新步骤信息
            {
                StepInfo stepInfo = new StepInfo(Convert.ToInt32(txtStepId.Text), txtStepName.Text);
                step.UpdateStepInfoByStepId(stepInfo);
            }
            txtStepId.Text = "";
            txtStepName.Text = "";
            txtStepName.ReadOnly = true;
            btnNewStep.Enabled = true;
            btnModifyStep.Enabled = true;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            lvStepInfo.Enabled = true;
            lvStepInfo_DataBind();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtStepId.Text = "";
            txtStepName.Text = "";
            txtStepId.ReadOnly = true;
            txtStepName.ReadOnly = true;
            btnNewStep.Enabled = true;
            btnModifyStep.Enabled = true;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            lvStepInfo.Enabled = true;
            lvStepInfo_DataBind();
        }
    }
}
