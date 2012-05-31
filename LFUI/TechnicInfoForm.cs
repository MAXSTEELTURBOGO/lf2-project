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
    public partial class TechnicInfoForm : Form
    {
        private Technic technicBLL;
        private IList<TechnicsInfo> technicInfoList;
        Step stepBLL;
        IList<StepInfo> stepInfoList;
        TransformerParam transformerParamBLL;
        IList<TransformerParamInfo> transformerParamList;
        public TechnicInfoForm()
        {
            technicBLL = new Technic();
            technicInfoList = technicBLL.GetAllTechnicInfo();
            stepBLL = new Step();
            stepInfoList = stepBLL.GetAllStepInfo();
            transformerParamBLL = new TransformerParam();
            transformerParamList = transformerParamBLL.GetAllTransFormerParamInfo();
            InitializeComponent();
        }

        private void TechnicInfoForm_Load(object sender, EventArgs e)
        {  
            treeViewTechnicList_DataBind();
        }

        private void treeViewTechnicList_DataBind()
        {
            foreach (TechnicsInfo item in technicInfoList)
            {
                treeViewTechnicList.Nodes[0].Nodes.Add(item.TechnicName);
            }
        }

        private void lvStepInfo_DataBind()
        {
            stepInfoList = stepBLL.GetAllStepInfo();
            lvStepInfo.Items.Clear();
            foreach (DataGridViewRow row in dgvTechnicStepInfo.Rows)
            {
                if (row.Cells[2].Value.ToString() != "")
                {
                    StepInfo stepInfo = (from i in stepInfoList
                                         where i.StepId.ToString() == row.Cells[2].Value.ToString()
                                         select i).First<StepInfo>();
                    stepInfoList.Remove(stepInfo);
                }
            }
            foreach (StepInfo stepInfo in stepInfoList)
            {
                ListViewItem item = new ListViewItem(stepInfo.StepId.ToString());
                item.SubItems.Add(stepInfo.StepName);
                lvStepInfo.Items.Add(item);
            }
        }

        private void dgvTechnicStepInfo_DataBind(TechnicsInfo technicInfo)
        {
            dgvTechnicStepInfo.Rows.Clear();
            foreach (TechnicStepInfo item in technicInfo.TechnicStepInfo)
            {
                if (item.Steps.StepId != null)
                {
                    object[] row = new object[]{"删除",item.Sequence.ToString(),item.Steps.StepId.ToString(),item.Steps.StepName,item.PlanDuration.ToString(),
                                            item.PlanPowerDuration.ToString(),item.PlanTopArConsumption.ToString(),item.PlanBottomArConsumption.ToString(),
                                            item.TransFormerParams.TapPosition.ToString(),item.TransFormerParams.TapPositionPoint.ToString(),item.TransFormerParams.Voltage.ToString(),
                                            item.TransFormerParams.Current.ToString(),item.TransFormerParams.Power.ToString(),item.TransFormerParams.TempPerMin.ToString()};
                    dgvTechnicStepInfo.Rows.Add(row);
                }
            }
        }

        private void treeViewTechnicList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text != "工艺名称")
            {
                TechnicsInfo technicInfo = (from i in technicInfoList
                                            where i.TechnicName == e.Node.Text
                                            select i).First<TechnicsInfo>();
                this.dgvTechnicStepInfo_DataBind(technicInfo);
                txtTechnicId.Text = technicInfo.TechnicId.ToString();
                txtTechnicName.Text = technicInfo.TechnicName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnResetTechnicSteps_Click(object sender, EventArgs e)
        {
            dgvTechnicStepInfo.Rows.Clear();
            lvStepInfo_DataBind();
        }

        private void btnNewTechnic_Click(object sender, EventArgs e)
        {
            clearControls();
            setEditMode();
            txtTechnicName.ReadOnly = false;
        }

        private void btnCopyTechnic_Click(object sender, EventArgs e)
        {
            txtTechnicId.Text = "";
            txtTechnicName.Text = "";
            setEditMode();
        }

        private void btnModifyTechnic_Click(object sender, EventArgs e)
        {
            setEditMode();
        }

        private void btnDeleteTechnic_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除该工艺过程吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                technicBLL.DeleteTechnicInfo(Convert.ToInt32(txtTechnicId.Text));
                MessageBox.Show("成功删除工艺过程！", "提示");
                clearControls();
                technicInfoList = technicBLL.GetAllTechnicInfo();
                treeViewTechnicList.Nodes[0].Nodes.Clear();
                treeViewTechnicList_DataBind();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTechnicName.Text))
            {
                if (string.IsNullOrEmpty(txtTechnicId.Text)) //新增
                {
                    if ((from i in technicInfoList where i.TechnicName == txtTechnicName.Text select i).Count() == 0)
                    {
                        InsertTechnicInfo();
                        MessageBox.Show("工艺步骤添加成功！", "提示");
                    }
                    else
                    {
                        MessageBox.Show("输入的工艺名称已经存在，请重新输入！", "提示");
                        txtTechnicName.Text = "";
                        return;
                    }
                }
                else //修改
                {
                    technicBLL.DeleteTechnicInfo(Convert.ToInt32(txtTechnicId.Text));
                    InsertTechnicInfo();
                    MessageBox.Show("工艺步骤修改成功！", "提示");
                }
            }
            else
            {
                MessageBox.Show("工艺名称不能为空，请输入后再点'确定'键！");
                return;
            }
            clearControls();
            cancelEditMode();
            technicInfoList = technicBLL.GetAllTechnicInfo();
            treeViewTechnicList.Nodes[0].Nodes.Clear();
            treeViewTechnicList_DataBind();
        }

        private void InsertTechnicInfo()
        {
            IList<TechnicStepInfo> technicStepList = new List<TechnicStepInfo>();
            technicBLL.InsertTechnicInfo(txtTechnicName.Text.Trim());
            int? technicId = technicBLL.GetTechnicsId(txtTechnicName.Text.Trim());
            foreach (DataGridViewRow row in dgvTechnicStepInfo.Rows)
            {
                TechnicStepInfo technicStepInfo = null;
                StepInfo stepInfo = null;
                TransformerParamInfo transformerParamInfo = null;
                int? sequence = Convert.ToInt32(row.Cells[1].Value.ToString().Trim());
                int stepId = Convert.ToInt32(row.Cells[2].Value.ToString().Trim());
                string stepName = row.Cells[3].Value.ToString().Trim();
                int? planDuration = row.Cells[4].Value == null ? 0 : new Nullable<int>(Convert.ToInt32(row.Cells[4].Value.ToString().Trim()));
                int? planPowerDuration = row.Cells[5].Value == null ? 0 : new Nullable<int>(Convert.ToInt32(row.Cells[5].Value.ToString().Trim()));
                int? planTopArConsumption = row.Cells[6].Value == null ? 0 : new Nullable<int>(Convert.ToInt32(row.Cells[6].Value.ToString().Trim()));
                int? planBottomArConsumption = row.Cells[7].Value == null ? 0 : new Nullable<int>(Convert.ToInt32(row.Cells[7].Value.ToString().Trim()));
                int? tapPosition = row.Cells[8].Value == null ? 1 : new Nullable<int>(Convert.ToInt32(row.Cells[8].Value.ToString().Trim()));
                int? tapPositionPoint = row.Cells[9].Value == null ? 1 : new Nullable<int>(Convert.ToInt32(row.Cells[9].Value.ToString().Trim()));
                stepInfo = new StepInfo(stepId, stepName);
                transformerParamInfo = new TransformerParamInfo(tapPosition, tapPositionPoint);
                technicStepInfo = new TechnicStepInfo(technicId, stepInfo, planDuration, planPowerDuration, planTopArConsumption, planBottomArConsumption, sequence, transformerParamInfo);
                technicStepList.Add(technicStepInfo);
            }
            if (technicStepList.Count != 0)
            {
                TechnicStep technicStep = new TechnicStep();
                technicStep.InsertTechnicStepInfo(technicStepList);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelEditMode();
        }

        private void setEditMode()
        {
            dgvColBtnDelete.Visible = true;
            dgvColTapPower.Visible = false;
            dgvColTapVoltage.Visible = false;
            dgvColTapCurrent.Visible = false;
            dgvColTempChange.Visible = false;
            treeViewTechnicList.Visible = false;
            lvStepInfo_DataBind();
            lvStepInfo.Visible = true;
            dgvTechnicStepInfo.ReadOnly = false;
            dgvColSequence.ReadOnly = true;
            dgvColStepName.ReadOnly = true;
            btnNewTechnic.Enabled = false;
            btnCopyTechnic.Enabled = false;
            btnModifyTechnic.Enabled = false;
            btnDeleteTechnic.Enabled = false;
            btnResetTechnicSteps.Enabled = true;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void cancelEditMode()
        {
            dgvColBtnDelete.Visible = false;
            dgvColTapPower.Visible = true;
            dgvColTapVoltage.Visible = true;
            dgvColTapCurrent.Visible = true;
            dgvColTempChange.Visible = true;
            treeViewTechnicList.Visible = true;
            lvStepInfo.Visible = false;
            dgvTechnicStepInfo.ReadOnly = true;
            txtTechnicId.ReadOnly = true;
            txtTechnicName.ReadOnly = true;
            btnNewTechnic.Enabled = true;
            btnCopyTechnic.Enabled = true;
            btnModifyTechnic.Enabled = true;
            btnDeleteTechnic.Enabled = true;
            btnResetTechnicSteps.Enabled = false;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            clearControls();
        }

        private void clearControls()
        {
            dgvTechnicStepInfo.Rows.Clear();
            txtTechnicId.Text = "";
            txtTechnicName.Text = "";
        }

        private void lvStepInfo_ItemActivate(object sender, EventArgs e)
        {
            if (lvStepInfo.SelectedItems.Count > 0)
            {
                object[] row = new object[] { "删除", dgvTechnicStepInfo.Rows.Count + 1, lvStepInfo.SelectedItems[0].SubItems[0].Text, 
                                            lvStepInfo.SelectedItems[0].SubItems[1].Text };
                dgvTechnicStepInfo.Rows.Add(row);
                lvStepInfo.Items.Remove(lvStepInfo.SelectedItems[0]);
            }
        }

        private void dgvTechnicStepInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ListViewItem item = new ListViewItem(dgvTechnicStepInfo.Rows[e.RowIndex].Cells[2].Value.ToString());
                item.SubItems.Add(dgvTechnicStepInfo.Rows[e.RowIndex].Cells[3].Value.ToString());
                lvStepInfo.Items.Add(item);
                dgvTechnicStepInfo.Rows.Remove(dgvTechnicStepInfo.Rows[e.RowIndex]);
                for (int i = e.RowIndex; i < dgvTechnicStepInfo.Rows.Count; i++)
                {
                    dgvTechnicStepInfo.Rows[i].Cells[1].Value = (Convert.ToInt32(dgvTechnicStepInfo.Rows[i].Cells[1].Value) - 1).ToString();
                }
            }
        }

        private void dgvTechnicStepInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    if (dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value != null)
                    {
                        if (dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                        {
                            if (!(Convert.ToInt32(dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) < Convert.ToInt32(dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString())))
                            {
                                MessageBox.Show("计划通电时间必须比计划持续时间短，请重新输入！", "提示");
                                dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            }
                        }
                        else
                        {
                            MessageBox.Show("输入的计划通电时间不能为空！", "提示");
                            dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先输入计划持续时间，再输入计划通电时间！", "提示");
                        dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        return;
                    }
                }
                if (e.ColumnIndex > 3 && e.ColumnIndex < 8)
                {
                    if (dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        if (!Regex.IsMatch(dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim(), @"^\d{1,5}$"))
                        {
                            MessageBox.Show("您输入的数值不符合要求，请重新输入！", "提示");
                            dgvTechnicStepInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        }
                    }
                }
            }
        }

        private void txtTechnicName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTechnicName.Text, @"^.{0,50}$"))
            {
                MessageBox.Show("您输入工艺名称过长，请重新输入！", "提示");
                txtTechnicName.Text = "";
            }
        }
    }
}
