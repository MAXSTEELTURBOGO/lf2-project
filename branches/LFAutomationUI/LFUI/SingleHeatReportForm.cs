using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization.Charting;

namespace LFAutomationUI.LFUI
{
    public partial class SingleHeatReportForm : Form
    {
        private string heatId;
        private int treatmentCount;
        private LFHeatInfo heatInfo;
        private LFHeat lfHeatBll;
        private IList<LFHeatInfo> heatIdList;
        ExportProcessReport exportForm = new ExportProcessReport();
        public int I = 0;
        public string UserState = "";

        public SingleHeatReportForm()
        {
            InitializeComponent();
            btnExpSingleHeatReport.Enabled = false;
        }
        public SingleHeatReportForm(string heatId, int treatmentCount)
        {
            InitializeComponent();
            this.heatId = heatId;
            this.treatmentCount = treatmentCount;
        }

        private void SingleHeatReportForm_Load(object sender, EventArgs e)
        {
            lfHeatBll = new LFHeat();
            heatIdList = lfHeatBll.GetHeatIdList();
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
            dtpStartDate.Value = new DateTime(2010, 3, 1, 0, 0, 0);
            dtpEndDate.Value = DateTime.Now;
            if (!string.IsNullOrEmpty(heatId) && treatmentCount != 0)
            {
                heatInfo = lfHeatBll.GetLFHeatInfo(heatId, treatmentCount);
                showHeatDetailInfos();
            }
        }
        private void refreshCmbHeatId()
        {
            DateTime startTime = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, 0, 0, 0);
            DateTime endTime = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day, 23, 59, 59);
            IList<string> heatInfoList = (from i in heatIdList
                                          where i.MsgTimeStamp < dtpEndDate.Value && i.MsgTimeStamp > dtpStartDate.Value
                                          select i.HeatId).Distinct().ToList<string>();
            cmbHeatId_DataBind(heatInfoList);
        }
        private void cmbHeatId_DataBind(IList<string> heatIdList)
        {
            cmbHeatId.DataSource = heatIdList;
        }
        private void cmbTreatmentCount_DataBind(IList<int> treatmentCountList)
        {
            cmbTreatmentCount.DataSource = treatmentCountList;
        }
        private void lvAddition_DataBind(IList<AdditionRecordInfo> addMatList)
        {
            lvAdditionEach.Items.Clear();
            foreach (AdditionRecordInfo info in addMatList)
            {
                ListViewItem item = new ListViewItem(info.AdditionTime.ToString());
                item.SubItems.Add(info.AdditionType);
                item.SubItems.Add(info.SiloId.ToString());
                item.SubItems.Add(info.MaterialName);
                item.SubItems.Add(info.AdditionAmount.ToString());
                lvAdditionEach.Items.Add(item);
            }
            lvAdditionSum.Items.Clear();
            var query = from i in addMatList
                        group i by i.MaterialName into g
                        select new
                        {
                            materialName = g.Key,
                            addMatTotalWgt = g.Sum(i => i.AdditionAmount)
                        };
            foreach (var info in query)
            {
                ListViewItem item = new ListViewItem(info.materialName);
                item.SubItems.Add(info.addMatTotalWgt.ToString());
                lvAdditionSum.Items.Add(item);
            }
        }
        private void lvHeatStatus_DataBind(IList<LFHeatStatusInfo> lfHeatStatusInfos)
        {
            lvHeatStatus.Items.Clear();
            foreach (LFHeatStatusInfo info in lfHeatStatusInfos)
            {
                ListViewItem item = new ListViewItem(info.StatusTimeStamp.ToString());
                item.SubItems.Add(info.HeatStatus.StatusName);
                item.SubItems.Add(info.StausTemperature.ToString());
                item.SubItems.Add(info.SteelWeight.ToString());
                lvHeatStatus.Items.Add(item);
            }
        }
        private void lvTempOxygenRecord_DataBind(IList<TempOxygenRecordInfo> tempOxygenInfos)
        {
            lvTempOxygenRecord.Items.Clear();
            foreach (TempOxygenRecordInfo info in tempOxygenInfos)
            {
                ListViewItem item = new ListViewItem(info.MsgTimeStamp.ToString());
                item.SubItems.Add(info.TemperatureData.ToString());
                item.SubItems.Add(info.OxygenData.ToString());
                item.SubItems.Add(info.Type);
                lvTempOxygenRecord.Items.Add(item);
            }
        }
        private void lvPowerRecord_DataBind(IList<PowerOnRecordInfo> powerOnInfos)
        {
            lvPowerRecord.Items.Clear();
            foreach (PowerOnRecordInfo info in powerOnInfos)
            {
                ListViewItem item = new ListViewItem(info.StartPowerOnTime.ToString());
                item.SubItems.Add(info.EndPowerOnTime.ToString());
                item.SubItems.Add((info.EndPowerOnTime - info.StartPowerOnTime).ToString());
                item.SubItems.Add(info.PowerConsumption.ToString());
                lvPowerRecord.Items.Add(item);
            }
        }
        private void lvQuality_DataBind(IList<QualityHorizontalInfo> qualityInfos)
        {
            lvQuality.Items.Clear();
            foreach (QualityHorizontalInfo info in qualityInfos)
            {
                ListViewItem item = new ListViewItem(info.HeatId);
                item.SubItems.Add(info.SampleTime.ToString());
                item.SubItems.Add(info.SamplePlace);
                item.SubItems.Add(info.SampleNumber.ToString());
                item.SubItems.Add(info.EleC.ToString());
                item.SubItems.Add(info.EleSI.ToString());
                item.SubItems.Add(info.EleMN.ToString());
                item.SubItems.Add(info.EleP.ToString());
                item.SubItems.Add(info.EleS.ToString());
                item.SubItems.Add(info.EleCU.ToString());
                item.SubItems.Add(info.EleTAL.ToString());
                item.SubItems.Add(info.EleSOL.ToString());
                item.SubItems.Add(info.EleB.ToString());
                item.SubItems.Add(info.EleNI.ToString());
                item.SubItems.Add(info.EleCR.ToString());
                item.SubItems.Add(info.EleMO.ToString());
                item.SubItems.Add(info.EleW.ToString());
                item.SubItems.Add(info.EleTI.ToString());
                item.SubItems.Add(info.EleV.ToString());
                item.SubItems.Add(info.EleZR.ToString());
                item.SubItems.Add(info.ElePB.ToString());
                item.SubItems.Add(info.EleSN.ToString());
                item.SubItems.Add(info.EleAS.ToString());
                item.SubItems.Add(info.EleCA.ToString());
                item.SubItems.Add(info.EleCO.ToString());
                item.SubItems.Add(info.EleMG.ToString());
                item.SubItems.Add(info.EleTE.ToString());
                item.SubItems.Add(info.EleBI.ToString());
                item.SubItems.Add(info.EleSB.ToString());
                item.SubItems.Add(info.EleZN.ToString());
                item.SubItems.Add(info.EleNB.ToString());
                item.SubItems.Add(info.EleH.ToString());
                item.SubItems.Add(info.EleN.ToString());
                item.SubItems.Add(info.EleO.ToString());
                item.SubItems.Add(info.EleAL.ToString());
                item.SubItems.Add(info.EleALT.ToString());
                item.SubItems.Add(info.EleSE.ToString());
                item.SubItems.Add(info.EleRE.ToString());
                item.SubItems.Add(info.EleALS.ToString());
                item.SubItems.Add(info.EleCEQ.ToString());
                item.SubItems.Add(info.ElePCM.ToString());
                item.SubItems.Add(info.ElePSR.ToString());
                item.SubItems.Add(info.EleTA.ToString());
                item.SubItems.Add(info.EleALN.ToString());
                item.SubItems.Add(info.EleCAS.ToString());
                item.SubItems.Add(info.EleCRMO.ToString());
                item.SubItems.Add(info.EleCRMOCU.ToString());
                item.SubItems.Add(info.EleCRMOCUNI.ToString());
                item.SubItems.Add(info.EleCUCR.ToString());
                item.SubItems.Add(info.EleCUNI.ToString());
                item.SubItems.Add(info.EleMNSI.ToString());
                item.SubItems.Add(info.EleNBN.ToString());
                item.SubItems.Add(info.EleNBJN.ToString());
                item.SubItems.Add(info.EleNBVTI.ToString());
                item.SubItems.Add(info.EleNICR.ToString());
                item.SubItems.Add(info.EleNICRCU.ToString());
                item.SubItems.Add(info.ElePS.ToString());
                item.SubItems.Add(info.EleTIN.ToString());
                item.SubItems.Add(info.EleVNB.ToString());
                lvQuality.Items.Add(item);
            }
        }
        /// <summary>
        /// 点击查询按钮 调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByHeatId_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbHeatId.Text))
            {
                MessageBox.Show("请填入一个有效炉号！");
            }
            else if (string.IsNullOrEmpty(cmbTreatmentCount.Text))
            {
                MessageBox.Show("请填入一个冶炼次数！");
            }
            else
            {
                string heatId =cmbHeatId.Text;
                
                if (string.IsNullOrEmpty(heatId))
                {
                    MessageBox.Show("该炉次没有冶炼，请重新输入查询！");
                }
                else
                {
                    clearChartPoints();
                    heatInfo = lfHeatBll.GetLFHeatInfo(heatId, Convert.ToInt32(cmbTreatmentCount.Text));
                    showHeatDetailInfos();
                    showReatTimeInfo(heatId, Convert.ToInt32(cmbTreatmentCount.Text));
                    btnExpSingleHeatReport.Enabled = true;
                }
            }
        }

        private void showReatTimeInfo(string heatId,int treatmentCount)
        {
            
            RealTime realTimeBLL = new RealTime();
            IList<RealTimeInfo> realTimeList = realTimeBLL.GetRealTimeInfo(heatId, treatmentCount);
            foreach (RealTimeInfo item in realTimeList)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.ArgonFlow1.HasValue ? item.ArgonFlow1.Value : 0);
                chartArFlow.Series[0].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.ArgonFlow2.HasValue ? item.ArgonFlow2.Value : 0);
                chartArFlow.Series[1].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.AEAC.HasValue ? item.AEAC.Value : 0);
                chartEAC.Series[0].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.BEAC.HasValue ? item.BEAC.Value : 0);
                chartEAC.Series[1].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.CEAC.HasValue ? item.CEAC.Value : 0);
                chartEAC.Series[2].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.AEAV.HasValue ? item.AEAV.Value : 0);
                chartEAV.Series[0].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.BEAV.HasValue ? item.BEAV.Value : 0);
                chartEAV.Series[1].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.CEAV.HasValue ? item.CEAV.Value : 0);
                chartEAV.Series[2].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.ArgonPressure1.HasValue ? item.ArgonPressure1.Value : 0);
                chartArPressure.Series[0].Points.Add(dp);

                dp = new DataPoint();
                dp.SetValueXY(item.MsgTimeStamp, item.ArgonPressure2.HasValue ? item.ArgonPressure2.Value : 0);
                chartArPressure.Series[1].Points.Add(dp);

            }
        }

        private void clearChartPoints()
        {
            chartArFlow.Series[0].Points.Clear();
            chartArFlow.Series[1].Points.Clear();
            chartArPressure.Series[0].Points.Clear();
            chartArPressure.Series[1].Points.Clear();
            chartEAC.Series[0].Points.Clear();
            chartEAC.Series[1].Points.Clear();
            chartEAC.Series[2].Points.Clear();
            chartEAV.Series[0].Points.Clear();
            chartEAV.Series[1].Points.Clear();
            chartEAV.Series[2].Points.Clear();
        }

        private void showHeatDetailInfos()
        {
            txtHeatId.Text = heatInfo.HeatId;
            txtTreatmentCount.Text = heatInfo.TreatmentCount.ToString();
            txtCarId.Text = heatInfo.IntParseCar().ToString();
            txtClass.Text = heatInfo.OperatorUser.ClassId;
            txtOperator.Text = heatInfo.OperatorUser.UserName;
            txtArrivalTime.Text = heatInfo.ArrivalTime == null ? null : heatInfo.ArrivalTime.ToString();
            txtDepartTime.Text = heatInfo.DepartTime == null ? null : heatInfo.DepartTime.ToString();
            txtPlanId.Text = heatInfo.PlanId == null ? null : heatInfo.PlanId.ToString();
            txtSteelGradeId.Text = heatInfo.SteelGrade == null ? null : heatInfo.SteelGrade.SteelGradeId.ToString();
            txtTreatmentStation.Text = "LF1";
            txtArrivalTemperature.Text = heatInfo.ArrivalTemperature == null ? null : heatInfo.ArrivalTemperature.TemperatureData.ToString();
            txtDepartTemperature.Text = heatInfo.DepartTemperature == null ? null : heatInfo.DepartTemperature.TemperatureData.ToString();
            txtLadleId.Text = heatInfo.Ladle.LadleId;
            txtLadleAge.Text = heatInfo.Ladle.LadleAge.ToString();
            txtArConsump.Text = heatInfo.ArConsumptin == null ? null : heatInfo.ArConsumptin.ToString();
            txtArDuration.Text = heatInfo.ArDuration == null ? null : heatInfo.ArDuration.ToString();
            txtPowerDuration.Text = heatInfo.PowerDuration == null ? null : heatInfo.PowerDuration.ToString();
            txtPowerConsump.Text = heatInfo.PowerConsumption == null ? null : heatInfo.PowerConsumption.ToString();
            txtArDurationAfterFeed.Text = heatInfo.ArDurationAfterFeed == null ? null : heatInfo.ArDurationAfterFeed.ToString();
            txtArConsumpAfterFeed.Text = heatInfo.ArConsumptionAfterFeed == null ? null : heatInfo.ArConsumptionAfterFeed.ToString();
            txtFeedSpeed.Text = heatInfo.FeedSpeed == null ? null : heatInfo.FeedSpeed.ToString();
            txtCapAge.Text = heatInfo.HeatEquipment.RoofAge.ToString();
            txtAElectrodeAge.Text = heatInfo.HeatEquipment.AElectrodeAge.ToString();
            txtBElectrodeAge.Text = heatInfo.HeatEquipment.BElectrodeAge.ToString();
            txtCElectrodeAge.Text = heatInfo.HeatEquipment.CElectrodeAge.ToString();
            txtAElectrodeCnt.Text = heatInfo.HeatEquipment.APoleCircleUseCount.ToString();
            txtBElectrodeCnt.Text = heatInfo.HeatEquipment.BPoleCircleUseCount.ToString();
            txtCElectrodeCnt.Text = heatInfo.HeatEquipment.CPoleCircleUseCount.ToString();
            lvTempOxygenRecord_DataBind(heatInfo.TempOxygenList);
            lvPowerRecord_DataBind(heatInfo.PowerOnList);
            lvAddition_DataBind(heatInfo.AdditionList);
            lvQuality_DataBind(heatInfo.LfHeatQualityHorizontalList);
            lvHeatStatus_DataBind(heatInfo.LFHeatStatusList);
            lvPowerRecord_DataBind(heatInfo.PowerOnList);
        }
        /// <summary>
        /// 导出当前单炉次报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpSingleHeatReport_Click(object sender, EventArgs e)
        {
            if (heatInfo != null)
            {
                exportForm = new ExportProcessReport();
                exportForm.Show();
                bgWorkExportExcel.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 关闭窗口方法重载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        /// <summary>
        /// '关闭窗口'按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            btnExpSingleHeatReport.Enabled = false;
            dtpEndDate.MinDate = dtpStartDate.Value;
            refreshCmbHeatId();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            btnExpSingleHeatReport.Enabled = false;
            dtpStartDate.MaxDate = dtpEndDate.Value;
            refreshCmbHeatId();
        }

        private void cmbHeatId_TextChanged(object sender, EventArgs e)
        {
            IList<int> treatmentCountList = (from i in heatIdList
                                             where i.HeatId == cmbHeatId.Text
                                             select i.TreatmentCount).ToList<int>();
            cmbTreatmentCount_DataBind(treatmentCountList);
            btnExpSingleHeatReport.Enabled = false;
        }

        private void cmbTreatmentCount_TextChanged(object sender, EventArgs e)
        {
            btnExpSingleHeatReport.Enabled = false;
        }

        private void bgWorkExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            string NowTime = DateTime.Now.ToLongDateString() + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分" + DateTime.Now.Second.ToString() + "秒";
            string fileName;
            if(Directory.Exists("D:\\LF二级冶炼报告"))
            {
                if (heatInfo.HeatId.Contains("?"))
                {
                    fileName = "D:\\LF二级冶炼报告" + "\\" + heatInfo.HeatId.Replace("?", "未知炉次") + "_" + NowTime + ".XLS";
                }
                else
                {
                    fileName = "D:\\LF二级冶炼报告" + "\\" + heatInfo.HeatId + "_" + NowTime + ".XLS";
                }
            }
            else
            {
                Directory.CreateDirectory("D:\\LF二级冶炼报告");
                if (heatInfo.HeatId.Contains("?"))
                {
                    fileName = "D:\\LF二级冶炼报告" + "\\" + heatInfo.HeatId.Replace("?", "未知炉次") + "_" + NowTime + ".XLS";
                }
                else
                {
                    fileName = "D:\\LF二级冶炼报告" + "\\" + heatInfo.HeatId + "_" + NowTime + ".XLS";
                }
            }
            SteelGradeDetails steelGradeBLL = new SteelGradeDetails();

            if (heatInfo.SteelGrade != null)
            {
                heatInfo.SteelGrade = steelGradeBLL.GetSteelGradeInfoBySteelGradeId(heatInfo.SteelGrade.SteelGradeId);
            }
            Formula formulaBLL = new Formula();
            IList<FormulaInfo> formulaList = formulaBLL.GetFormulaListByHeatId(heatInfo.HeatId);
            if (formulaList != null && formulaList.Count != 0)
            {
                heatInfo.SteelGrade.FormulaInfos = formulaList;
            }
            FormulaCalculator fc = new FormulaCalculator();

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "JScript";

            Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = false;

            string appPath = Application.ExecutablePath;
            string appPathDir = appPath.Substring(0, appPath.LastIndexOf('\\'));
            string excelPath = appPathDir + System.Configuration.ConfigurationSettings.AppSettings["ExcelTemplatePath"];
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@excelPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.ActiveSheet;

            I = 1;
            UserState = "正在导出冶炼基本信息...";
            bgWorkExportExcel.ReportProgress(I,UserState);
            #region <冶炼基本信息>
            Excel.Range range = excelWorkSheet.get_Range("F3", Missing.Value);
            range.Value2 = heatInfo.MsgTimeStamp.ToString();

            range = excelWorkSheet.get_Range("S3", Missing.Value);
            range.Value2 = heatInfo.PlanId.ToString();

            range = excelWorkSheet.get_Range("AB3", Missing.Value);
            range.Value2 = heatInfo.HeatId;

            range = excelWorkSheet.get_Range("AL3", Missing.Value);
            range.Value2 = heatInfo.TreatmentCount.ToString();

            range = excelWorkSheet.get_Range("AQ3", Missing.Value);
            range.Value2 = heatInfo.IntParseCar().ToString();

            range = excelWorkSheet.get_Range("AV3", Missing.Value);
            if (heatInfo.SteelGrade != null)
            {
                range.Value2 = heatInfo.SteelGrade.SteelGradeId;
            }

            range = excelWorkSheet.get_Range("BG3", Missing.Value);
            range.Value2 = heatInfo.ArrivalTime.ToString();

            range = excelWorkSheet.get_Range("BU3", Missing.Value);
            range.Value2 = heatInfo.DepartTime.ToString();

            range = excelWorkSheet.get_Range("F4", Missing.Value);
            range.Value2 = heatInfo.OperatorUser.UserName;

            range = excelWorkSheet.get_Range("M4", Missing.Value);
            range.Value2 = heatInfo.OperatorUser.ClassId;

            range = excelWorkSheet.get_Range("S4", Missing.Value);
            range.Value2 = heatInfo.PowerConsumption.ToString();

            range = excelWorkSheet.get_Range("AB4", Missing.Value);
            range.Value2 = heatInfo.PowerDuration.ToString();

            range = excelWorkSheet.get_Range("AI4", Missing.Value);
            range.Value2 = heatInfo.ArConsumptin.ToString();

            range = excelWorkSheet.get_Range("AR4", Missing.Value);
            range.Value2 = heatInfo.ArDuration.ToString();

            range = excelWorkSheet.get_Range("BC4", Missing.Value);
            range.Value2 = heatInfo.ArDurationAfterFeed.ToString();

            range = excelWorkSheet.get_Range("BN4", Missing.Value);
            range.Value2 = heatInfo.ArConsumptionAfterFeed.ToString();

            range = excelWorkSheet.get_Range("BU4", Missing.Value);
            range.Value2 = heatInfo.FeedSpeed.ToString();

            range = excelWorkSheet.get_Range("F5", Missing.Value);
            range.Value2 = heatInfo.Ladle.LadleId;

            range = excelWorkSheet.get_Range("M5", Missing.Value);
            range.Value2 = heatInfo.Ladle.LadleAge;

            range = excelWorkSheet.get_Range("V5", Missing.Value);
            range.Value2 = heatInfo.ArrivalSteelWeight.ToString();

            range = excelWorkSheet.get_Range("AF5", Missing.Value);
            range.Value2 = heatInfo.DepartSteelWeight.ToString();

            range = excelWorkSheet.get_Range("AN5", Missing.Value);
            range.Value2 = heatInfo.DepartSlagWeight.ToString();

            range = excelWorkSheet.get_Range("AU5", Missing.Value);
            if (heatInfo.SteelGrade != null)
            {
                range.Value2 = heatInfo.SteelGrade.RouteDesc;
            }
            #endregion

            I = 2;
            UserState = "正在导出设备使用信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <设备使用信息>
            range = excelWorkSheet.get_Range("BO42", "BZ51");

            range.Cells[1, 1] = "A项电极[min]";
            range.Cells[1, 7] = heatInfo.HeatEquipment.AElectrodeAge;
            range.Cells[2, 1] = "B项电极[min]";
            range.Cells[2, 7] = heatInfo.HeatEquipment.BElectrodeAge;
            range.Cells[3, 1] = "C项电极[min]";
            range.Cells[3, 7] = heatInfo.HeatEquipment.CElectrodeAge;

            range.Cells[4, 1] = "A项电极环[次]";
            range.Cells[4, 7] = heatInfo.HeatEquipment.APoleCircleUseCount;
            range.Cells[5, 1] = "B项电极环[次]";
            range.Cells[5, 7] = heatInfo.HeatEquipment.BPoleCircleUseCount;
            range.Cells[6, 1] = "C项电极环[次]";
            range.Cells[6, 7] = heatInfo.HeatEquipment.CPoleCircleUseCount;

            range.Cells[7, 1] = "炉盖[次]";
            range.Cells[7, 7] = heatInfo.HeatEquipment.RoofAge;
            #endregion

            I = 3;
            UserState = "正在导出冶炼过程信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <冶炼过程信息>
            range = excelWorkSheet.get_Range("A9", "L51");

            int rowIndex = 1;
            foreach (LFHeatStatusInfo item in heatInfo.LFHeatStatusList)
            {
                range.Cells[rowIndex, 1] = item.StatusTimeStamp.ToString();
                range.Cells[rowIndex, 12] = item.HeatStatus.StatusName;
                rowIndex++;
            }
            #endregion

            I = 5;
            UserState = "正在导出通电记录信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region<通电记录信息>
            range = excelWorkSheet.get_Range("S42", "AS51");

            rowIndex = 1;
            foreach (PowerOnRecordInfo item in heatInfo.PowerOnList)
            {
                range.Cells[rowIndex, 1] = item.StartPowerOnTime.ToString();
                range.Cells[rowIndex, 11] = item.EndPowerOnTime.ToString();
                range.Cells[rowIndex, 22] = (item.EndPowerOnTime - item.StartPowerOnTime).ToString();
                range.Cells[rowIndex, 27] = item.PowerConsumption.ToString();
                rowIndex++;
            }
            #endregion

            I = 6;
            UserState = "正在导出测温记录信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <测温记录信息>
            range = excelWorkSheet.get_Range("AW42", "BK51");

            rowIndex = 1;

            foreach (TempOxygenRecordInfo item in heatInfo.TempOxygenList)
            {
                range.Cells[rowIndex, 1] = item.MsgTimeStamp.ToString();
                range.Cells[rowIndex, 11] = item.TemperatureData.ToString();
                range.Cells[rowIndex, 15] = item.OxygenData.ToString();
                rowIndex++;
            }
            #endregion

            I = 7;
            UserState = "正在导出加料记录信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <加料记录信息>
            range = range = excelWorkSheet.get_Range("S9", "AH38");
            rowIndex = 1;

            foreach (var item in heatInfo.AdditionList)
            {
                range.Cells[rowIndex, 1] = item.AdditionTime.ToString();
                range.Cells[rowIndex, 5] = item.MaterialName;
                range.Cells[rowIndex, 10] = item.AdditionType;
                range.Cells[rowIndex, 13] = item.AdditionAmount.ToString();
                range.Cells[rowIndex, 16] = item.Note;
                rowIndex++;
            }
            #endregion

            I = 8;
            UserState = "正在导出合金化验和渣化验信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <合金化验信息和渣化验信息>
            range = excelWorkSheet.get_Range("AJ9", "AT38");
            rowIndex = 1;


            SteelAnalysis steelAnalysisBLL = new SteelAnalysis();

            IList<SteelAnalysisInfo> steelAnalysisList = steelAnalysisBLL.GetSteelAnalysisByHeatId(heatInfo.HeatId);
            if (steelAnalysisList == null || steelAnalysisList.Count == 0)
            {
                if (heatInfo.SteelGrade != null)
                {
                    steelAnalysisList = steelAnalysisBLL.GetSteelAnalysisBySteelGradeId(heatInfo.SteelGrade.SteelGradeId);
                }
            }

            if (steelAnalysisList != null && steelAnalysisList.Count != 0)
            {

                foreach (SteelAnalysisInfo item in steelAnalysisList)
                {
                    range.Cells[rowIndex, 1] = item.ElemInfo.ElementFullName;
                    range.Cells[rowIndex, 5] = item.MinValue.ToString();
                    range.Cells[rowIndex, 8] = item.AimValue.ToString();
                    range.Cells[rowIndex, 11] = item.MaxValue.ToString();
                    rowIndex++;
                }


                HeatQuality heatQualityBLL = new HeatQuality();
                IList<HeatQualityInfo> heatQualityList = heatQualityBLL.GetHeatQualityInfo(heatInfo.HeatId);

                int startCellRow = 7;
                int endCellRow = 38;

                string templateCell = "AW";

                int colInc = 3;
                int maxLoopCount = 7;
                int currLoopCount = 0;

                foreach (HeatQualityInfo heatQuality in heatQualityList.OrderByDescending(i => i.SampleTime))
                {
                    if (currLoopCount < maxLoopCount)
                    {
                        char c = (char)((int)templateCell[1] + colInc * currLoopCount);

                        string startCell = ((char)((int)templateCell[0] + (c > 'Z' ? 1 : 0))).ToString() + ((char)(c > 'Z' ? (char)((int)'A' + ((int)c) % ((int)'Z') - 1) : c)).ToString() + startCellRow.ToString();
                        string endCell = ((char)((int)templateCell[0] + (c > 'Z' ? 1 : 0))).ToString() + ((char)(c > 'Z' ? (char)((int)'A' + ((int)c) % ((int)'Z') - 1) : c)).ToString() + endCellRow.ToString();

                        range = excelWorkSheet.get_Range(startCell, endCell);
                        range.Cells[1, 1] = heatQuality.SampleTime.ToString();
                        range.Cells[2, 1] = heatQuality.SamplePlace;
                        range.Cells[2, 3] = heatQuality.SampleNumber.ToString();
                        rowIndex = 3;
                        foreach (SteelAnalysisInfo steelAnaylysis in steelAnalysisList)
                        {
                            QualityInfo tmpQuaitliy = heatQuality.QualityList.Where<QualityInfo>(k => k.Element.ElementFullName == steelAnaylysis.ElemInfo.ElementFullName).First();

                            Excel.Range tmpRange = excelWorkSheet.get_Range(range.Cells[rowIndex, 1], range.Cells[rowIndex, 1]);

                            int colorIndex = 2;

                            if (tmpQuaitliy.Element.ElementType == "ELEMENT" || tmpQuaitliy.Element.ElementType == "COMPOUND")
                            {
                                double? qualityValue = tmpQuaitliy.QualityValue;

                                if (qualityValue.HasValue)
                                {
                                    if (qualityValue < steelAnaylysis.MinValue)
                                    {
                                        colorIndex = 37;
                                    }
                                    else
                                    {
                                        if (qualityValue > steelAnaylysis.MaxValue)
                                        {
                                            colorIndex = 38;
                                        }
                                    }
                                    range.Cells[rowIndex, 1] = qualityValue.ToString();
                                }
                            }
                            else
                            {

                                if (tmpQuaitliy.Element.ElementType == "FORMULA")
                                {
                                    string digitalFormulaString = fc.FormulaParse(heatQuality.QualityList, steelAnaylysis.ElemInfo.ElementFullName);
                                    try
                                    {
                                        double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                        if (result < steelAnaylysis.MinValue)
                                        {
                                            colorIndex = 37;
                                        }
                                        else
                                        {
                                            if (result > steelAnaylysis.MaxValue)
                                            {
                                                colorIndex = 38;
                                            }
                                        }
                                        range.Cells[rowIndex, 1] = result.ToString();
                                    }
                                    catch { }
                                }
                                else
                                {
                                    //计算CEQ
                                    try
                                    {
                                        FormulaInfo formula = heatInfo.SteelGrade.FormulaInfos.Single<FormulaInfo>(k => k.FormulaType.ToUpper() == steelAnaylysis.ElemInfo.ElementFullName);

                                        string digitalFormulaString = fc.FormulaParse(heatQuality.QualityList, formula.Formula);

                                        double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                        if (result < steelAnaylysis.MinValue)
                                        {
                                            colorIndex = 37;
                                        }
                                        else
                                        {
                                            if (result > steelAnaylysis.MaxValue)
                                            {
                                                colorIndex = 38;
                                            }
                                        }
                                        range.Cells[rowIndex, 1] = Math.Round(result, 5).ToString();
                                    }
                                    catch { }
                                }

                            }
                            tmpRange.Interior.ColorIndex = colorIndex;
                            rowIndex++;
                        }
                        currLoopCount++;
                    }
                }

                HeatSlagQuality heatSlagQualityBLL = new HeatSlagQuality();

                heatInfo.LFHeatSlagQualityList = heatSlagQualityBLL.GetHeatSlagQualityInfo(heatInfo.HeatId);

                range = excelWorkSheet.get_Range("BR7", "CB38");
                rowIndex = 3;
                if (heatInfo.LFHeatSlagQualityList != null && heatInfo.LFHeatSlagQualityList.Count != 0)
                {
                    foreach (QualityInfo item in heatInfo.LFHeatSlagQualityList.First().SlagQualityList.OrderBy<QualityInfo, decimal>(i => i.Element.ViewSequence))
                    {
                        range.Cells[rowIndex, 1] = item.Element.ElementFullName;
                        rowIndex++;
                    }
                    rowIndex = 3;
                    range = excelWorkSheet.get_Range("BV7", "CB38");

                    colInc = 3;
                    maxLoopCount = 3;
                    currLoopCount = 0;
                    templateCell = "BV";

                    foreach (HeatSlagQualityInfo heatSlagQuality in heatInfo.LFHeatSlagQualityList.OrderByDescending<HeatSlagQualityInfo, DateTime>(i => i.SampleTime))
                    {
                        if (currLoopCount < maxLoopCount)
                        {
                            char c = (char)((int)templateCell[1] + colInc * currLoopCount);

                            string startCell = ((char)((int)templateCell[0] + (c > 'Z' ? 1 : 0))).ToString() + ((char)(c > 'Z' ? (char)((int)'A' + ((int)c) % ((int)'Z') - 1) : c)).ToString() + startCellRow.ToString();
                            string endCell = ((char)((int)templateCell[0] + (c > 'Z' ? 1 : 0))).ToString() + ((char)(c > 'Z' ? (char)((int)'A' + ((int)c) % ((int)'Z') - 1) : c)).ToString() + endCellRow.ToString();

                            range = excelWorkSheet.get_Range(startCell, endCell);
                            range.Cells[1, 1] = heatSlagQuality.SampleTime.ToString();
                            range.Cells[2, 1] = heatSlagQuality.SampleAddress;
                            range.Cells[2, 3] = heatSlagQuality.SampleNumber.ToString();
                            rowIndex = 3;

                            foreach (QualityInfo item in heatSlagQuality.SlagQualityList.OrderBy<QualityInfo, decimal>(i => i.Element.ViewSequence))
                            {
                                range.Cells[rowIndex, 1] = item.QualityValue.ToString();
                                rowIndex++;
                            }
                            currLoopCount++;
                        }

                    }
                }
            }
            #endregion

            I = 9;
            UserState = "正在导出事件记录信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <事件记录信息>
            rowIndex = 1;
            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets["事件记录"];
            range = excelWorkSheet.get_Range("A5", "L63");

            EventRecord eventRecordBLL = new EventRecord();

            IList<EventRecordInfo> eventRecordList = eventRecordBLL.GetEventRecords(heatInfo.HeatId, heatInfo.TreatmentCount);

            foreach (EventRecordInfo item in eventRecordList)
            {
                range.Cells[rowIndex, 1] = rowIndex;
                range.Cells[rowIndex, 6] = item.MsgTimeStamp.ToString();
                range.Cells[rowIndex, 12] = item.Info;
                rowIndex++;
            }

            #endregion

            I = 10;
            UserState = "正在导出实时数据信息...";
            bgWorkExportExcel.ReportProgress(I, UserState);
            #region <实时数据信息>
            excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets["实时数据"];

            rowIndex = 1;
            range = excelWorkSheet.get_Range("A4", Missing.Value);

            foreach (RealTimeInfo item in heatInfo.ReatTimeList)
            {
                range.Cells[rowIndex, 1] = item.MsgTimeStamp.ToString();
                range.Cells[rowIndex, 2] = item.AEAC;
                range.Cells[rowIndex, 3] = item.BEAC;
                range.Cells[rowIndex, 4] = item.BEAC;
                range.Cells[rowIndex, 5] = item.AEAV;
                range.Cells[rowIndex, 6] = item.BEAV;
                range.Cells[rowIndex, 7] = item.CEAV;
                range.Cells[rowIndex, 8] = item.ArgonFlow1;
                range.Cells[rowIndex, 9] = item.ArgonFlow2;
                range.Cells[rowIndex, 10] = item.ArgonPressure1;
                range.Cells[rowIndex, 11] = item.ArgonPressure2;
                rowIndex++;
            }
            #endregion 

            excelWorkBook.SaveAs(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            excelWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            excelApp.Workbooks.Close();
            excelApp.Application.Quit();
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkSheet);
            excelWorkSheet = null;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkBook);
            excelWorkBook = null;

            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;


            I = 11;
            UserState = "已成功导出!";
            bgWorkExportExcel.ReportProgress(I, UserState);
        }

        private void bgWorkExportExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportForm.proBarExportExcel.Value = e.ProgressPercentage;
            exportForm.lblExportExcelState.Text = e.UserState.ToString();
            exportForm.lblExportExcelState.Update();
        }

        private void bgWorkExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportForm.Close();
        }
    }
}
