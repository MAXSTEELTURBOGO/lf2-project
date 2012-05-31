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
    public partial class SteelInfoForm : Form
    {
        private Technic technic;
        private IList<TechnicsInfo> technicInfos;
        private SteelAnalysis steelAnalysis;
        private SteelGradeDetails steelGrade;
        string routeId;
        private string pattern;

        /// <summary>
        /// SteelInfoForm构造函数
        /// </summary>
        public SteelInfoForm()
        {
            InitializeComponent();
            steelAnalysis = new SteelAnalysis();
            steelGrade = new SteelGradeDetails();
            technic = new Technic();
            technicInfos = technic.GetAllTechnicInfo();
        }
        /// <summary>
        /// 打开窗口Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SteelInfoForm_Load(object sender, EventArgs e)
        {
            routeId = "";
            lvSteelGradeList_DataBind();
            dgvSteelAnalysis.AutoGenerateColumns = false;
            cmbTechnicId_DataBind();
        }
        /// <summary>
        /// lvSteelGradeList数据绑定
        /// </summary>
        private void lvSteelGradeList_DataBind()
        {
            IList<SteelGradeDetailInfo> steelInfos = steelGrade.GetAllSteelGradeInfo();
            foreach (SteelGradeDetailInfo steelInfo in steelInfos)
            {
                ListViewItem item = new ListViewItem(steelInfo.SteelGradeId);
                lvSteelGradeList.Items.Add(item);
            }
        }
        private void cmbTechnicId_DataBind()
        {
            foreach (TechnicsInfo technicInfo in technicInfos)
            {
                cmbTechnicId.Items.Add(technicInfo.TechnicId);
            }
            cmbTechnicId.Items.Add("");
        }
        private void lvSteelFormulaInfo_DataBind(IList<FormulaInfo> formulaInfos)
        {
            lvSteelFormulaInfo.Items.Clear();
            foreach (FormulaInfo info in formulaInfos)
            {
                ListViewItem item = new ListViewItem(info.FormulaId);
                item.SubItems.Add(info.FormulaType);
                item.SubItems.Add(info.Formula);
                lvSteelFormulaInfo.Items.Add(item);
            }
        }
        /// <summary>
        /// lvProcessRoute工艺步骤数据绑定
        /// </summary>
        /// <param name="technicStepInfos">工艺步骤信息</param>
        private void lvProcessRoute_DataBind(IList<TechnicStepInfo> technicStepInfos)
        {
            foreach (TechnicStepInfo technicStepInfo in technicStepInfos)
            {
                ListViewItem item = new ListViewItem(technicStepInfo.Steps.StepName);
                item.SubItems.Add(technicStepInfo.PlanDuration.ToString());
                item.SubItems.Add(technicStepInfo.PlanPowerDuration.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TapPosition.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TapPositionPoint.ToString());
                item.SubItems.Add(technicStepInfo.PlanTopArConsumption.ToString());
                item.SubItems.Add(technicStepInfo.PlanBottomArConsumption.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Voltage.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Current.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TempPerMin.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Power.ToString());
                lvProcessRoute.Items.Add(item);
            }
        }
        /// <summary>
        /// dgvSteelAnalysis钢种化学分析数据绑定
        /// </summary>
        /// <param name="steelAnalysisInfos">钢种化学分析信息</param>
        private void dgvSteelAnalysis_DataBind(IList<SteelAnalysisInfo> steelAnalysisInfos)
        {
            foreach (SteelAnalysisInfo steelAnalysisInfo in steelAnalysisInfos)
            {
                object[] row = new object[] { steelAnalysisInfo.ElemInfo.ElementId, steelAnalysisInfo.ElemInfo.ElementShortName, steelAnalysisInfo.MinValue.ToString(), steelAnalysisInfo.AimValue.ToString(), steelAnalysisInfo.MaxValue.ToString() };
                dgvSteelAnalysis.Rows.Add(row);
            }
        }
        /// <summary>
        /// 点“新增”按钮时使用的对元素信息的绑定的方法 dgvSteelAnalysis
        /// </summary>
        private void dgvSteelAnalysis_Add_DataBind()
        {
            Element element = new Element();
            IList<ElementInfo> elementInfos = element.GetElementInfo();
            foreach (ElementInfo elementInfo in elementInfos)
            {
                object[] row = new object[] { elementInfo.ElementId, elementInfo.ElementShortName };
                dgvSteelAnalysis.Rows.Add(row);
            }
        }
        /// <summary>
        /// 点“关闭窗口”调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// lvSteelGradeList中选择一项时调用的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvSteelGradeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSteelGradeList.SelectedItems.Count > 0)
            {
                SteelGradeDetailInfo steelGradeDetailsInfo = steelGrade.GetSteelGradeInfoBySteelGradeId(lvSteelGradeList.SelectedItems[0].SubItems[0].Text);
                txtSteelGradeId.Text = lvSteelGradeList.SelectedItems[0].SubItems[0].Text;
                txtSteelGradeName.Text = steelGradeDetailsInfo.SteelGradeName;
                txtSteelGradeGroupId.Text = steelGradeDetailsInfo.SteelGradeGroupCode;
                txtSteelGradeGroupName.Text = steelGradeDetailsInfo.SteelGradeGroupName;
                txtSteelGradeDesc.Text = steelGradeDetailsInfo.SteelGradeDescr;
                txtLiquidTemp.Text = steelGradeDetailsInfo.LiquidTemp.ToString();
                txtHeatingCount.Text = steelGradeDetailsInfo.HeatingCount.ToString();
                txtSlagModel.Text = steelGradeDetailsInfo.SlagModel;
                txtArgonModel.Text = steelGradeDetailsInfo.ArgonModel;
                txtMinArDuraBefFeedWire.Text = steelGradeDetailsInfo.ArDuraBefFeedWire.ToString();
                txtMinArDuraAftFeedWire.Text = steelGradeDetailsInfo.ArDuraAftFeedWire.ToString();
                txtTiFeAftMainHeating.Text = steelGradeDetailsInfo.FeTiAftHeating.ToString();
                txtMaxHeatingDuraPerHeat.Text = steelGradeDetailsInfo.MaxDuraEachHeating.ToString();
                txtWireFeedWgt.Text = steelGradeDetailsInfo.WireWgtAftHeating.ToString();
                routeId = steelGradeDetailsInfo.RouteId;
                txtRoute.Text = steelGradeDetailsInfo.RouteDesc;
                cmbTechnicId.Text = steelGradeDetailsInfo.TechnicsInfo.TechnicId.ToString();
                txtTechnicName.Text = steelGradeDetailsInfo.TechnicsInfo.TechnicName;
                lvProcessRoute.Items.Clear();
                dgvSteelAnalysis.Rows.Clear();
                lvSteelFormulaInfo_DataBind(steelGradeDetailsInfo.FormulaInfos);
                lvProcessRoute_DataBind(steelGradeDetailsInfo.TechnicsInfo.TechnicStepInfo);
                IList<SteelAnalysisInfo> steelAnalysisInfos = steelAnalysis.GetSteelAnalysisBySteelGradeId(lvSteelGradeList.SelectedItems[0].SubItems[0].Text);
                dgvSteelAnalysis_DataBind(steelAnalysisInfos);
            }
            else
            {
                this.clearControls();
            }
        }
        /// <summary>
        /// 点“新增”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtSteelGradeId.ReadOnly = false;
            setEditMode();
            clearControls();
            dgvSteelAnalysis_Add_DataBind();
            dgvSteelAnalysis.ReadOnly = false;
            dgvSteelAnalysis.Columns[0].ReadOnly = true;
        }
        /// <summary>
        /// 点“修改”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (txtSteelGradeId.Text == "")
            {
                MessageBox.Show("请先选择要修改的钢种！");
            }
            else
            {
                this.setEditMode();
                dgvSteelAnalysis.Rows.Clear();
                IList<SteelAnalysisInfo> steelAnalysisInfos = steelAnalysis.GetSteelAllElementAnalysisBySteelGradeId(txtSteelGradeId.Text);
                dgvSteelAnalysis_DataBind(steelAnalysisInfos);
                dgvSteelAnalysis.ReadOnly = false;
                dgvSteelAnalysis.Columns[0].ReadOnly = true;
            }
        }
        /// <summary>
        /// 点“复制”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtSteelGradeId.Text == "")
            {
                MessageBox.Show("请先选择要修改的钢种！");
            }
            else
            {
                this.setEditMode();
                txtSteelGradeId.ReadOnly = false;
                dgvSteelAnalysis.Rows.Clear();
                IList<SteelAnalysisInfo> steelAnalysisInfos = steelAnalysis.GetSteelAllElementAnalysisBySteelGradeId(txtSteelGradeId.Text);
                dgvSteelAnalysis_DataBind(steelAnalysisInfos);
                dgvSteelAnalysis.ReadOnly = false;
                dgvSteelAnalysis.Columns[0].ReadOnly = true;
                txtSteelGradeId.Text = "";
            }
        }
        /// <summary>
        /// 点“删除”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSteelGradeId.Text != "")
            {
                if (MessageBox.Show(this, "确定要删除钢种号为" + this.txtSteelGradeId.Text + "的钢种信息吗?\n（钢种删除后不可恢复，请慎重考虑！）", "确认删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    steelGrade.DeleteSteelGradeInfoBySteelGradeId(txtSteelGradeId.Text);
                    lvSteelGradeList.SelectedItems[0].Remove();
                    this.clearControls();
                }
            }
            else
            {
                MessageBox.Show("请先在钢种列表中选择要删除的钢种！");
            }
        }
        /// <summary>
        /// 点“确认”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtSteelGradeId.Text != "")
            {
                string steelGradeId = txtSteelGradeId.Text;
                string steelGradeName = txtSteelGradeName.Text;
                string steelGradeGroupId = txtSteelGradeGroupId.Text;
                string steelGradeGroupName = txtSteelGradeGroupName.Text;
                string steelGradeDesc = txtSteelGradeDesc.Text;
                double? liquidTemp = string.IsNullOrEmpty(txtLiquidTemp.Text.Trim()) ? null : new Nullable<double>(Convert.ToDouble(txtLiquidTemp.Text));
                string slagModel = txtSlagModel.Text;
                string argonModel = txtArgonModel.Text;
                int? maxDuraEachHeating = string.IsNullOrEmpty(txtMaxHeatingDuraPerHeat.Text.Trim()) ? null : new Nullable<int>(Convert.ToInt32(txtMaxHeatingDuraPerHeat.Text));
                int? heatingCount = string.IsNullOrEmpty(txtHeatingCount.Text.Trim()) ? null : new Nullable<int>(Convert.ToInt32(txtHeatingCount.Text));
                double? feTiAftHeating = string.IsNullOrEmpty(txtTiFeAftMainHeating.Text.Trim()) ? null : new Nullable<double>(Convert.ToDouble(txtTiFeAftMainHeating.Text));
                double? wireWgtAftHeating = string.IsNullOrEmpty(txtWireFeedWgt.Text.Trim()) ? null : new Nullable<double>(Convert.ToDouble(txtWireFeedWgt.Text));
                int? arDuraBefFeedWire = string.IsNullOrEmpty(txtMinArDuraBefFeedWire.Text.Trim()) ? null : new Nullable<int>(Convert.ToInt32(txtMinArDuraBefFeedWire.Text));
                int? arDuraAftFeedWire = string.IsNullOrEmpty(txtMinArDuraAftFeedWire.Text.Trim()) ? null : new Nullable<int>(Convert.ToInt32(txtMinArDuraAftFeedWire.Text));
                string routeDesc = txtRoute.Text;
                int? technicId = string.IsNullOrEmpty(cmbTechnicId.Text.Trim()) ? null : new Nullable<int>(Convert.ToInt32(cmbTechnicId.Text));
                string technicName = txtTechnicName.Text;

                TechnicsInfo technicInfo = new TechnicsInfo(technicId, technicName);
                SteelGradeDetailInfo steelGradeBasicInfo = new SteelGradeDetailInfo(steelGradeId, steelGradeName, steelGradeGroupId, steelGradeGroupName,
                                                        steelGradeDesc, liquidTemp, slagModel, argonModel, maxDuraEachHeating, heatingCount,
                                                        feTiAftHeating, wireWgtAftHeating, arDuraBefFeedWire, arDuraAftFeedWire, routeId, routeDesc, technicInfo);
                if (txtSteelGradeId.ReadOnly == false)  //新增钢种
                {
                    steelGrade.InsertSteelGradeInfo(steelGradeBasicInfo);
                    lvSteelGradeList.Items.Add(steelGradeBasicInfo.SteelGradeId);
                    this.insertSteelAnalysisBydgvSteelAnalysis();
                }
                else if (txtSteelGradeId.ReadOnly == true)//修改钢种
                {
                    steelGrade.UpdateSteelGradeBasicInfo(steelGradeBasicInfo);
                    this.insertSteelAnalysisBydgvSteelAnalysis();
                }
            }
            this.clearControls();
            this.cancelEditMode();
        }
        /// <summary>
        /// 点“取消”按钮时调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.clearControls();
            cancelEditMode();
        }
        /// <summary>
        /// 点“修改步骤”调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyProcessSteps_Click(object sender, EventArgs e)
        {
            TechnicInfoForm technicInfoForm = new TechnicInfoForm();
            technicInfoForm.ShowDialog();
        }
        /// <summary>
        /// 点击lvSteelFormulaInfo的“更改”按钮调用的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifySteelFormula_Click(object sender, EventArgs e)
        {
            IList<FormulaInfo> formulaList = new List<FormulaInfo>();
            foreach (ListViewItem item in lvSteelFormulaInfo.Items)
            {
                FormulaInfo formulaInfo = new FormulaInfo(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text);
                formulaList.Add(formulaInfo);
            }
            FormulaChooseForm formulaChooseForm = new FormulaChooseForm(formulaList);
            formulaChooseForm.ShowDialog();
            if (formulaChooseForm.DialogResult == DialogResult.OK)
            {
                lvSteelFormulaInfo_DataBind(formulaChooseForm.chooseFormulaList);
            }
        }
        /// <summary>
        /// 点击冶炼路径文本框后的“更多”按钮调用的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoreRoute_Click(object sender, EventArgs e)
        {
            RouteModifyForm routeModifyForm = new RouteModifyForm();
            DialogResult diag = routeModifyForm.ShowDialog();
            if (diag == DialogResult.OK)
            {
                routeId = routeModifyForm.selectRouteCode;
                txtRoute.Text = routeModifyForm.selectRouteDesc;
            }
        }
        /// <summary>
        /// 该方法用于清空该界面所使用的textbox  listview datagridview中的数据
        /// </summary>
        private void clearControls()
        {
            txtSteelGradeId.Text = "";
            txtSteelGradeName.Text = "";
            txtSteelGradeGroupId.Text = "";
            txtSteelGradeGroupName.Text = "";
            txtSteelGradeDesc.Text = "";
            txtHeatingCount.Text = "";
            txtLiquidTemp.Text = "";
            txtSlagModel.Text = "";
            txtArgonModel.Text = "";
            txtTiFeAftMainHeating.Text = "";
            txtMaxHeatingDuraPerHeat.Text = "";
            txtMinArDuraAftFeedWire.Text = "";
            txtMinArDuraBefFeedWire.Text = "";
            routeId = "";
            txtRoute.Text = "";
            txtWireFeedWgt.Text = "";
            cmbTechnicId.Text = "";
            lvProcessRoute.Items.Clear();
            dgvSteelAnalysis.Rows.Clear();
        }
        /// <summary>
        /// 该方法用于取消编辑模式
        /// </summary>
        private void cancelEditMode()
        {
            cmbTechnicId.Enabled = false;
            txtSteelGradeId.ReadOnly = true;
            txtSteelGradeName.ReadOnly = true;
            txtSteelGradeGroupId.ReadOnly = true;
            txtSteelGradeGroupName.ReadOnly = true;
            txtSteelGradeDesc.ReadOnly = true;
            txtHeatingCount.ReadOnly = true;
            txtLiquidTemp.ReadOnly = true;
            txtSlagModel.ReadOnly = true;
            txtArgonModel.ReadOnly = true;
            txtTiFeAftMainHeating.ReadOnly = true;
            txtMaxHeatingDuraPerHeat.ReadOnly = true;
            txtMinArDuraAftFeedWire.ReadOnly = true;
            txtMinArDuraBefFeedWire.ReadOnly = true;
            txtWireFeedWgt.ReadOnly = true;
            btnNew.Enabled = true;
            btnModify.Enabled = true;
            btnCopy.Enabled = true;
            btnDelete.Enabled = true;
            btnMoreRoute.Enabled = false;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            btnModifyProcessStep.Enabled = false;
            lvSteelGradeList.Enabled = true;
        }
        /// <summary>
        /// 该方法用于启动编辑模式
        /// </summary>
        private void setEditMode()
        {
            cmbTechnicId.Enabled = true;
            cmbTechnicId.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSteelGradeName.ReadOnly = false;
            txtSteelGradeGroupId.ReadOnly = false;
            txtSteelGradeGroupName.ReadOnly = false;
            txtSteelGradeDesc.ReadOnly = false;
            txtHeatingCount.ReadOnly = false;
            txtLiquidTemp.ReadOnly = false;
            txtSlagModel.ReadOnly = false;
            txtArgonModel.ReadOnly = false;
            txtTiFeAftMainHeating.ReadOnly = false;
            txtMaxHeatingDuraPerHeat.ReadOnly = false;
            txtMinArDuraAftFeedWire.ReadOnly = false;
            txtMinArDuraBefFeedWire.ReadOnly = false;
            txtWireFeedWgt.ReadOnly = false;
            btnNew.Enabled = false;
            btnModify.Enabled = false;
            btnCopy.Enabled = false;
            btnDelete.Enabled = false;
            btnModifySteelFormula.Enabled = true;
            btnMoreRoute.Enabled = true;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
            btnModifyProcessStep.Enabled = true;
            lvSteelGradeList.Enabled = false; ;
        }
        /// <summary>
        /// 对comboBox  cmbTechnicId进行数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbTechnicId_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvProcessRoute.Items.Clear();
            if (cmbTechnicId.SelectedItem.ToString() != "")
            {
                TechnicsInfo technicInfo = (from i in technicInfos
                                            where i.TechnicId == Convert.ToInt32(cmbTechnicId.SelectedItem.ToString())
                                            select i).First<TechnicsInfo>();
                lvProcessRoute_DataBind(technicInfo.TechnicStepInfo);
            }
        }
        /// <summary>
        /// 根据钢种号向tb_steel_analysis插入钢种分析信息
        /// </summary>
        private void insertSteelAnalysisBydgvSteelAnalysis()
        {
            string steelGradeId = txtSteelGradeId.Text;
            IList<SteelAnalysisInfo> steelAnalysisInfos = new List<SteelAnalysisInfo>();
            foreach (DataGridViewRow row in dgvSteelAnalysis.Rows)
            {
                if (Convert.ToDouble(row.Cells[2].Value) > double.Epsilon || Convert.ToDouble(row.Cells[3].Value) > double.Epsilon || Convert.ToDouble(row.Cells[4].Value) > double.Epsilon)
                {
                    int elementId = Convert.ToInt32(row.Cells[0].Value);
                    string elementShortName = row.Cells[1].Value.ToString();
                    double minValue = Convert.ToDouble(row.Cells[2].Value);
                    double aimValue = Convert.ToDouble(row.Cells[3].Value);
                    double maxValue = Convert.ToDouble(row.Cells[4].Value);
                    ElementInfo elementInfo = new ElementInfo(elementId, elementShortName, "", "");
                    SteelAnalysisInfo steelAnalysisInfo = new SteelAnalysisInfo(steelGradeId, elementInfo, maxValue, minValue, aimValue);
                    steelAnalysisInfos.Add(steelAnalysisInfo);
                }
            }
            steelAnalysis.InsSteelAnalysisInfos(steelAnalysisInfos);
        }
        /// <summary>
        /// 防止窗口误关闭的方法
        /// </summary>
        /// <param name="e"></param>
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
        /// <summary>
        /// 对dgvSteelAnalysis输入的钢种元素分析值进行验证，要求只能输入2位整数，6位小数组成的数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSteelAnalysis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.RowIndex >= 0)
            {
                pattern = @"(^\d{0,2}\.\d{0,6}$)|(^\d{0,2}$)";
                if (dgvSteelAnalysis.CurrentCell.Value == null)
                {
                    dgvSteelAnalysis.CurrentCell.Value = 0;
                }
                if (!Regex.IsMatch(dgvSteelAnalysis.CurrentCell.Value.ToString(), pattern))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvSteelAnalysis.CurrentCell.Value = 0;
                }
            }
        }

        private void txtSteelGradeId_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9]{0,50}$";
                if (!Regex.IsMatch(txtSteelGradeId.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种号 " + txtSteelGradeId.Text + " 不符合格式要求，请重新输入！");
                    txtSteelGradeId.Text = "";
                }
            }
        }

        private void txtSteelGradeName_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,50}$";
                if (!Regex.IsMatch(txtSteelGradeName.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种名 " + txtSteelGradeName.Text + " 不符合格式要求，请重新输入！");
                    txtSteelGradeName.Text = "";
                }
            }
        }

        private void txtSteelGradeGroupId_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9]{0,2}$";
                if (!Regex.IsMatch(txtSteelGradeGroupId.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种组代码 " + txtSteelGradeGroupId.Text + " 不符合格式要求，请重新输入！");
                    txtSteelGradeGroupId.Text = "";
                }
            }
        }

        private void txtSteelGradeGroupName_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,30}$";
                if (!Regex.IsMatch(txtSteelGradeGroupName.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种组名称 " + txtSteelGradeGroupName.Text + " 不符合格式要求，请重新输入！");
                    txtSteelGradeGroupName.Text = "";
                }
            }
        }

        private void txtSteelGradeDesc_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,80}$";
                if (!Regex.IsMatch(txtSteelGradeDesc.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种描述 " + txtSteelGradeDesc.Text + " 不符合格式要求，请重新输入！");
                    txtSteelGradeDesc.Text = "";
                }
            }
        }

        private void txtHeatingCount_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^\d{0,2}$";
                if (!Regex.IsMatch(txtHeatingCount.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种每次冶炼最大冶炼次数 " + txtHeatingCount.Text + "\n不符合格式要求，请重新输入！");
                    txtHeatingCount.Text = "";
                }
            }
        }

        private void txtLiquidTemp_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"(^\d{0,4}\.\d{0,2}$)|(^\d{0,4}$)";
                if (!Regex.IsMatch(txtLiquidTemp.Text, pattern))
                {
                    MessageBox.Show("您输入的钢种液上限温度 " + txtLiquidTemp.Text + " 不符合格式要求，请重新输入！");
                    txtLiquidTemp.Text = "";
                }
            }
        }

        private void txtTiFeAftMainHeating_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"(^\d{0,4}\.\d{0,2}$)|(^\d{0,4}$)";
                if (!Regex.IsMatch(txtTiFeAftMainHeating.Text, pattern))
                {
                    MessageBox.Show("您输入的加热后加钛铁量 " + txtTiFeAftMainHeating.Text + " 不符合格式要求，请重新输入！");
                    txtTiFeAftMainHeating.Text = "";
                }
            }
        }

        private void txtSlagModel_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,50}$";
                if (!Regex.IsMatch(txtSlagModel.Text, pattern))
                {
                    MessageBox.Show("您输入的渣料模式 " + txtSlagModel.Text + " 不符合格式要求，请重新输入！");
                    txtSlagModel.Text = "";
                }
            }
        }

        private void txtMaxHeatingDuraPerHeat_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^\d{0,2}$";
                if (!Regex.IsMatch(txtMaxHeatingDuraPerHeat.Text, pattern))
                {
                    MessageBox.Show("您输入的每次加热最大时长 " + txtMaxHeatingDuraPerHeat + " 不符合格式要求，请重新输入！");
                    txtMaxHeatingDuraPerHeat.Text = "";
                }
            }
        }

        private void txtArgonModel_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,50}$";
                if (!Regex.IsMatch(txtArgonModel.Text, pattern))
                {
                    MessageBox.Show("您输入的吹氩模式 " + txtArgonModel + " 不符合格式要求，请重新输入！");
                    txtArgonModel.Text = "";
                }
            }
        }
        private void txtWireFeedWgt_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"(^\d{0,4}\.\d{0,2}$)|(^\d{0,4}$)";
                if (!Regex.IsMatch(txtWireFeedWgt.Text, pattern))
                {
                    MessageBox.Show("您输入的加热后喂丝重量 " + txtWireFeedWgt.Text + " 不符合格式要求，请重新输入！");
                    txtWireFeedWgt.Text = "";
                }
            }
        }

        private void txtMinArDuraBefFeedWire_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^\d{0,2}$";
                if (!Regex.IsMatch(txtMinArDuraBefFeedWire.Text, pattern))
                {
                    MessageBox.Show("您输入的喂丝前最短软吹时间 " + txtMinArDuraBefFeedWire.Text + " 不符合格式要求，请重新输入！");
                    txtMinArDuraBefFeedWire.Text = "";
                }
            }
        }
        private void txtMinArDuraAftFeedWire_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^\d{0,2}$";
                if (!Regex.IsMatch(txtMinArDuraAftFeedWire.Text, pattern))
                {
                    MessageBox.Show("您输入的喂丝后最短软吹时间 " + txtMinArDuraAftFeedWire.Text + " 不符合格式要求，请重新输入！");
                    txtMinArDuraAftFeedWire.Text = "";
                }
            }
        }
        private void txtTechnicName_TextChanged(object sender, EventArgs e)
        {
            if (btnConfirm.Enabled == true)  //只有在 “新增” “修改” “复制“ 模式下才调用该方法
            {
                pattern = @"^[A-Za-z0-9\u4e00-\u9fa5]{0,50}$";
                if (!Regex.IsMatch(txtTechnicName.Text, pattern))
                {
                    MessageBox.Show("您输入的工艺名称 " + txtTechnicName.Text + " 不符合格式要求，请重新输入！");
                    txtTechnicName.Text = "";
                }
            }
        }
    }
}
