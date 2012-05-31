using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LFAutomationUI.Model;
using LFAutomationUI.BLL;

namespace LFAutomationUI.LFUI
{
    public partial class SteelInfoSearchForm : Form
    {
        private Technic technic;
        private IList<TechnicsInfo> technicInfos;
        private SteelAnalysis steelAnalysis;
        private SteelGradeDetails steelGrade;
        string routeId;
        public SteelInfoSearchForm()
        {
            steelAnalysis = new SteelAnalysis();
            steelGrade = new SteelGradeDetails();
            technic = new Technic();
            technicInfos = technic.GetAllTechnicInfo();
            InitializeComponent();
        }

        private void SteelInfoSearchForm_Load(object sender, EventArgs e)
        {
            dgvSteelAnalysis.AutoGenerateColumns = false;
            lvSteelGradeList_DataBind();
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
        /// 该方法用于清空该界面数据
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
            lvSteelFormulaInfo.Items.Clear();
            lvProcessRoute.Items.Clear();
            dgvSteelAnalysis.Rows.Clear();
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
                txtSteelGradeId.Text = steelGradeDetailsInfo.SteelGradeId;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SteelGradeDetailInfo steelGradeDetailsInfo = steelGrade.GetSteelGradeInfoBySteelGradeId(txtSteelGradeIdSearch.Text);
            if (steelGradeDetailsInfo==null)
            {
                MessageBox.Show("没有钢种代码为 "+txtSteelGradeIdSearch.Text+" 的钢种,请重新输入查询!","提示");
                clearControls();
                return;
            }
            else
            {
                txtSteelGradeId.Text = steelGradeDetailsInfo.SteelGradeId.ToString();
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
                lvProcessRoute_DataBind(steelGradeDetailsInfo.TechnicsInfo.TechnicStepInfo);
                IList<SteelAnalysisInfo> steelAnalysisInfos = steelAnalysis.GetSteelAnalysisBySteelGradeId(steelGradeDetailsInfo.SteelGradeId);
                dgvSteelAnalysis_DataBind(steelAnalysisInfos);     
            }
        }
    }
}
