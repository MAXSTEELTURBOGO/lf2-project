using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LFAutomationUI.Model;
using LFAutomationUI.BLL;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace LFAutomationUI.LFUI
{
    public partial class MultiHeatReportForm : Form
    {
        private LFHeatInfo heatInfo;
        LFHeat lfHeatBll;
        IList<LFHeatInfo> lfHeatInfoList;
        IList<LFHeatInfo> cmbHeatInfoList;
        ExportProcessReport exportForm = new ExportProcessReport();
        IList<LFHeatInfo> bgWorkHeatList;
        int ExportCount = 0;

        public MultiHeatReportForm()
        {
            lfHeatBll = new LFHeat();
            cmbHeatInfoList = lfHeatBll.GetHeatIdList();
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
        private void MultiHeatReportForm_Load(object sender, EventArgs e)
        {
            refresh_cmbHeatId();
        }
        /// <summary>
        /// cmbHeatId炉次号数据绑定
        /// </summary>
        private void refresh_cmbHeatId()
        {
            cmbHeatId.Items.Clear();
            IList<string> heatIdList = (from i in cmbHeatInfoList
                                        select i.HeatId).Distinct().ToList<string>();
            cmbHeatId.DataSource = heatIdList;
        }
        /// <summary>
        /// cmbTreatmentCount冶炼次数数据绑定
        /// </summary>
        /// <param name="treatmentCountList">冶炼次数列表</param>
        private void refresh_cmbTreatmentCount()
        {
            cmbTreatmentCount.Text = "";
            IList<int> treatmentCountList = (from i in cmbHeatInfoList
                                             where i.HeatId == cmbHeatId.Text
                                             select i.TreatmentCount).Distinct().ToList<Int32>();
            cmbTreatmentCount.Items.Clear();
            foreach (int item in treatmentCountList)
            {
                cmbTreatmentCount.Items.Add(item);
            }
            cmbTreatmentCount.Items.Add("");
        }
        /// <summary>
        /// lvMultiHeatReportList数据绑定方法
        /// </summary>
        /// <param name="heatInfos">炉次信息</param>
        private void lvMultiHeatReportList_DataBind(IList<LFHeatInfo> heatInfos)
        {
            lvMultiHeatReportList.Items.Clear();
            if (heatInfos.Count==0)
            {
                MessageBox.Show("没有您要查询的炉次报告信息！");
            }
            foreach (LFHeatInfo info in heatInfos)
            {
                if (!string.IsNullOrEmpty(info.DepartTime.ToString()))
                {
                    ListViewItem item = new ListViewItem(info.PlanId == null ? null : info.PlanId.ToString());
                    item.SubItems.Add(info.HeatId);
                    item.SubItems.Add(info.TreatmentCount.ToString());
                    item.SubItems.Add(info.IntParseCar().ToString());
                    item.SubItems.Add(info.OperatorUser.ClassId);
                    item.SubItems.Add(info.OperatorUser.UserName);
                    item.SubItems.Add(info.SteelGrade.SteelGradeId);
                    item.SubItems.Add(info.ArrivalTime == null ? null : info.ArrivalTime.ToString());
                    item.SubItems.Add(info.DepartTime == null ? null : info.DepartTime.ToString());
                    item.SubItems.Add(info.ArrivalTemperature == null ? null : info.ArrivalTemperature.TemperatureData.ToString());
                    item.SubItems.Add(info.DepartTemperature == null ? null : info.DepartTemperature.TemperatureData.ToString());
                    item.SubItems.Add(info.ArDuration == null ? null : info.ArDuration.ToString());
                    item.SubItems.Add(info.ArConsumptin == null ? null : info.ArConsumptin.ToString());
                    item.SubItems.Add(info.PowerDuration == null ? null : info.PowerDuration.ToString());
                    item.SubItems.Add(info.PowerConsumption == null ? null : info.PowerConsumption.ToString());
                    item.SubItems.Add(info.ArDurationAfterFeed == null ? null : info.ArDurationAfterFeed.ToString());
                    item.SubItems.Add(info.ArConsumptionAfterFeed == null ? null : info.ArConsumptionAfterFeed.ToString());
                    item.SubItems.Add(info.FeedSpeed == null ? null : info.FeedSpeed.ToString());
                    item.UseItemStyleForSubItems = false;
                    lvMultiHeatReportList.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// 查看当月报告按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchCurrentMonth_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            lfHeatInfoList = lfHeatBll.GetLFHeatInfo(startTime, DateTime.Now);
            lvMultiHeatReportList_DataBind(lfHeatInfoList);
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

        /// <summary>
        /// 按日期查询按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, 0, 0, 0);
            DateTime endDate = new DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day, 23, 59, 59);
            lfHeatInfoList = lfHeatBll.GetLFHeatInfo(startDate, endDate);
            lvMultiHeatReportList_DataBind(lfHeatInfoList);
        }
        /// <summary>
        /// 按炉次号和冶炼次数查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByHeatId_Click(object sender, EventArgs e)
        {
            lfHeatInfoList = lfHeatBll.GetLFHeatInfo(cmbHeatId.Text);
            if (cmbTreatmentCount.Text == "")
            {
                lvMultiHeatReportList_DataBind(lfHeatInfoList);
            }
            else
            {
                lfHeatInfoList = (from i in lfHeatInfoList
                                  where i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                  select i).ToList<LFHeatInfo>();
                lvMultiHeatReportList_DataBind(lfHeatInfoList);
            }
        }

        private void cmbHeatId_TextChanged(object sender, EventArgs e)
        {
            refresh_cmbTreatmentCount();
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.MaxDate = dtpEndDate.Value;
        }

        private void lvMultiHeatReportList_ItemActivate(object sender, EventArgs e)
        {
            if (lvMultiHeatReportList.SelectedItems.Count>0)
            {
                SingleHeatReportForm singleHeatReport = new SingleHeatReportForm(lvMultiHeatReportList.SelectedItems[0].SubItems[1].Text, Convert.ToInt32(lvMultiHeatReportList.SelectedItems[0].SubItems[2].Text));
                singleHeatReport.ShowDialog();
            }     
        }

        private void bgWorkMultiExportExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (LFHeatInfo info in bgWorkHeatList)
            {
                heatInfo = new LFHeatInfo();
                lfHeatBll = new LFHeat();
                heatInfo = lfHeatBll.GetLFHeatInfo(info.HeatId,info.TreatmentCount);

                ExportCount++;
                bgWorkMultiExportExcel.ReportProgress(ExportCount);
                #region <导出表>
                string NowTime = DateTime.Now.ToLongDateString() + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分" + DateTime.Now.Second.ToString() + "秒";
                string fileName;
                if (Directory.Exists("D:\\LF二级冶炼报告"))
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
                #endregion
            }
        }

        private void bgWorkMultiExportExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportForm.proBarExportExcel.Value = e.ProgressPercentage;
            exportForm.lblExportExcelState.Text = "正在导出第" + e.ProgressPercentage + "个炉次报告文件..." + "\r\n" + "[共"+ bgWorkHeatList.Count.ToString() + "个文件]";
            exportForm.lblExportExcelState.Update();
        }

        private void bgWorkMultiExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportForm.Close();
        }

        private void btnMultiExport_Click(object sender, EventArgs e)
        {
            bgWorkHeatList = new List<LFHeatInfo>();
            foreach (ListViewItem item in lvMultiHeatReportList.SelectedItems)
            {
                LFHeatInfo info = new LFHeatInfo();
                info.HeatId = item.SubItems[1].Text;
                info.TreatmentCount = int.Parse(item.SubItems[2].Text);
                bgWorkHeatList.Add(info);
            }
            exportForm = new ExportProcessReport();
            exportForm.proBarExportExcel.Maximum = lvMultiHeatReportList.SelectedItems.Count;
            exportForm.Show();
            bgWorkMultiExportExcel.RunWorkerAsync();
        }
    }
}
