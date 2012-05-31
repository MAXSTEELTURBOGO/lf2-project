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
using System.Text.RegularExpressions;

namespace LFAutomationUI.LFUI
{
    public partial class NewLFHeatPlanForm : Form
    {
        private string routeName;
        public NewLFHeatPlanForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.Yes || this.DialogResult == DialogResult.No)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void btnSelectRouteId_Click(object sender, EventArgs e)
        {
            RouteModifyForm routeModifyForm = new RouteModifyForm();
            if (routeModifyForm.ShowDialog() == DialogResult.OK)
            {
                this.txtRouteId.Text = routeModifyForm.selectRouteDesc;
                this.routeName = routeModifyForm.selectRouteCode;
            }
        }

        private void btnNewLFHeatPlan_Click(object sender, EventArgs e)
        {
            this.btnNewLFHeatPlan.Enabled = false;

            string heatId = this.txtHeatId.Text.Trim();


            string pattern = @"^[0-9a-zA-Z]{1,8}$";

            if (Regex.IsMatch(heatId, pattern))
            {
                if (!string.IsNullOrEmpty(this.cmbSteelGradeId.Text))
                {
                    string steelGradeId = this.cmbSteelGradeId.Text;
                    if (Regex.IsMatch(this.txtStationId.Text.Trim(), @"^[0-9]{1,10}$"))
                    {
                        if (Regex.IsMatch(this.txtAimTemperature.Text.Trim(), @"^[0-9]{4}$"))
                        {
                            int stationId = Convert.ToInt32(this.txtStationId.Text.Trim());
                            string routeId = this.txtRouteId.Text.Trim();
                            string ladleId = this.txtLadleId.Text.Trim();

                            int aimTemperature = Convert.ToInt16(this.txtAimTemperature.Text.Trim());
                            LFHeat lfHeatBLL = new LFHeat();
                            IList<LFHeatInfo> lfHeatList = lfHeatBLL.GetLFHeatInfo(heatId);
                            if (lfHeatList.Count == 0)
                            {
                                LFHeatInfo lfHeat = new LFHeatInfo();
                                lfHeat.PlanId = null;
                                lfHeat.HeatId = heatId;
                                lfHeat.TreatmentCount = 1;
                                lfHeat.SteelGrade = new SteelGradeDetailInfo();
                                lfHeat.SteelGrade.SteelGradeId = steelGradeId;
                                lfHeat.PlanStationId = stationId;
                                lfHeat.SteelGrade.RouteId = this.routeName;
                                lfHeat.TargetTemperature = aimTemperature;
                                lfHeat.Ladle = new LadleInfo();
                                lfHeat.Ladle.LadleId = ladleId;
                                lfHeat.PreStartTime = null;
                                lfHeatBLL.InsertLFHeatPlan(lfHeat);

                                MessageBox.Show("新炉次计划信息添加成功!","提示");

                                this.DialogResult = DialogResult.Yes;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("炉次号" + heatId + "的炉次在计划中已经存在。\n添加已经存在的炉次的计划信息，请使用'回炉计划信息'选项卡'。", "错误提示");
                            }
                        }
                        else
                        {
                            MessageBox.Show("目标温度必须为四位数字","错误提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("站号必须为1-10位的整数", "错误提示");
                    }
                }
                else
                {
                    MessageBox.Show("钢种号不能为空！", "错误提示");
                }
            }
            else
            {
                MessageBox.Show("炉次号必须为1-8位的数字字母序列", "提示");
            }

            this.btnNewLFHeatPlan.Enabled = true;

        }

        private void NewLFHeatPlanForm_Load(object sender, EventArgs e)
        {
            SteelGradeDetails steelGradeBLL = new SteelGradeDetails();
            IList<SteelGradeDetailInfo> steelGradeList = steelGradeBLL.GetAllSteelGradeInfo();
            foreach (SteelGradeDetailInfo item in steelGradeList)
            {
                this.cmbSteelGradeId.Items.Add(item.SteelGradeId);
                this.cmbBackHeatSteelGradeId.Items.Add(item.SteelGradeId);
            }
        }

        private void btnNewHeatBackPlan_Click(object sender, EventArgs e)
        {
            this.btnNewHeatBackPlan.Enabled = false;
            if (string.IsNullOrEmpty(this.txtBackHeatId.Text.Trim()) || string.IsNullOrEmpty(cmbBackHeatSteelGradeId.Text.Trim()))
            {
                MessageBox.Show("炉次号和钢种号不能为空!", "错误提示");
            }
            else
            {
                string heatId = this.txtBackHeatId.Text.Trim();
                string steelGradeId = cmbBackHeatSteelGradeId.Text.Trim();
                string ladleId = this.txtBackHeatLadleId.Text.Trim();
                string pattern = @"^[0-9a-zA-Z]{1,8}$";
                if (Regex.IsMatch(heatId, pattern))
                {
                    LFHeat lfHeatBLL = new LFHeat();
                    IList<LFHeatInfo> lfHeatList = lfHeatBLL.GetLFHeatInfo(heatId);
                    if (lfHeatList.Count == 0)
                    {
                        MessageBox.Show("炉次计划中不存在炉次号" + heatId + "的信息。", "错误提示");
                    }
                    else
                    {
                        LFHeatInfo lfHeat = lfHeatList.OrderByDescending<LFHeatInfo, int>(i => i.TreatmentCount).First<LFHeatInfo>();
                        SteelGradeDetails steelGradeBLL = new SteelGradeDetails();
                        lfHeat.SteelGrade = steelGradeBLL.GetSteelGradeInfoBySteelGradeId(steelGradeId);
                        lfHeat.TreatmentCount = lfHeat.TreatmentCount + 1;
                        lfHeat.Ladle.LadleId = ladleId;

                        lfHeatBLL.InsertLFHeatPlan(lfHeat);
                        MessageBox.Show("炉次号为" + heatId + "的回炉信息添加成功!", "提示");
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("炉次号必须为1-8位的数字字母序列", "提示");
                }
            }
            this.btnNewHeatBackPlan.Enabled = true;

        }
    }
}
