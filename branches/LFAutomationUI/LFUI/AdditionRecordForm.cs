using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;

namespace LFAutomationUI.LFUI
{
    public partial class AdditionRecordForm : Form
    {
        private LFHeat lfHeatBLL;
        private Classes classBLL;
        private IList<LFHeatInfo> lfHeatList;
        private AdditionRecord additionRecordBLL;
        private IList<AdditionRecordInfo> additionRecordList;
        private SteelGradeDetails steelGradeBLL;
        ExportProcessReport exportForm = new ExportProcessReport();
        public int I = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AdditionRecordForm()
        {
            classBLL = new Classes();
            lfHeatBLL = new LFHeat();
            additionRecordBLL = new AdditionRecord();
            steelGradeBLL = new SteelGradeDetails();
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
            dtpStartTimeByClass.MaxDate = dtpEndTimeByClass.Value;
            dtpEndTimeByClass.MinDate = dtpStartTimeByClass.Value;
        }

        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdditionMaterialRecordForm_Load(object sender, EventArgs e)
        {
            refresh_cmbHeatId();
            refresh_cmbClass();
            refresh_cmbSteelGradeId();
        }

        /// <summary>
        /// cmbHeatId炉次号数据刷新
        /// </summary>
        private void refresh_cmbHeatId()
        {
            lfHeatList = lfHeatBLL.GetHeatIdList();
            cmbHeatId.Items.Clear();
            IList<string> heatIdList = (from i in lfHeatList
                                        select i.HeatId).Distinct().ToList<string>();
            cmbHeatId.DataSource = heatIdList;
        }

        /// <summary>
        /// cmbTreatmentCount冶炼次数数据刷新
        /// </summary>
        private void refresh_cmbTreatmentCount()
        {
            cmbTreatmentCount.Text = "";
            IList<int> treatmentCountList = (from i in lfHeatList
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
        /// cmbClass班组列表的数据绑定
        /// </summary>
        private void refresh_cmbClass()
        {
            cmbClass.Items.Clear();
            IList<ClassesInfo> classList = classBLL.GetAllClasses();
            foreach (ClassesInfo item in classList)
            {
                cmbClass.Items.Add(item.ClassId);
            }
            cmbClass.Items.Add("所有");
            cmbClass.Text = "所有";
        }
        private void refresh_cmbSteelGradeId()
        {
            cmbSteelGradeId.Items.Clear();
            IList<string> steelGradeList = steelGradeBLL.GetSteelGradeIdList();
            foreach (string item in steelGradeList)
            {
                cmbSteelGradeId.Items.Add(item);
            }
            cmbSteelGradeId.Items.Add("");
            cmbSteelGradeId.Text = "";
        }
        /// <summary>
        /// lvAdditionRecordList加料记录列表数据绑定
        /// </summary>
        /// <param name="additionRecordInfos">加料记录</param>
        private void lvAddByMultiMode_DataBind(IList<AdditionRecordInfo> additionRecordInfos)
        {
            lvEachAdditionListByMultiMode.Items.Clear();
            lvSumAddListByMultiMode.Items.Clear();
            if (additionRecordInfos.Count == 0)
            {
                MessageBox.Show("没有您要查询的加料信息！");
            }
            else
            {
                foreach (AdditionRecordInfo additionRecordInfo in additionRecordInfos)
                {
                    ListViewItem item = new ListViewItem(additionRecordInfo.HeatId);
                    item.SubItems.Add(additionRecordInfo.TreatmentCount.ToString());
                    item.SubItems.Add(additionRecordInfo.Car.ToString());
                    item.SubItems.Add(additionRecordInfo.AdditionTime.ToString());
                    item.SubItems.Add(additionRecordInfo.SiloId.ToString());
                    item.SubItems.Add(additionRecordInfo.MaterialName);
                    item.SubItems.Add(additionRecordInfo.MaterialType);
                    item.SubItems.Add(additionRecordInfo.AdditionAmount.ToString() + additionRecordInfo.Note);
                    lvEachAdditionListByMultiMode.Items.Add(item);
                }
                var query = (from i in additionRecordInfos
                             group i by i.HeatId into g1
                             select new
                             {
                                 heatId = g1.Key,
                                 treatmentCount = (from j in g1
                                                   group j by j.TreatmentCount into g2
                                                   select new
                                                   {
                                                       treatmentCount = g2.Key,
                                                       addMaterial = (from k in g2
                                                                      group k by k.MaterialName into g3
                                                                      select new
                                                                      {
                                                                          materialName = g3.Key,
                                                                          sumAddAmount = g3.Sum(k => k.AdditionAmount)
                                                                      })
                                                   })
                             });
                foreach (var addHeatId in query)
                {
                    foreach (var addTreatmentCount in addHeatId.treatmentCount)
                    {
                        foreach (var addSumAmount in addTreatmentCount.addMaterial)
                        {
                            ListViewItem item = new ListViewItem(addHeatId.heatId);
                            item.SubItems.Add(addTreatmentCount.treatmentCount.ToString());
                            item.SubItems.Add(addSumAmount.materialName);
                            item.SubItems.Add(addSumAmount.sumAddAmount.ToString());
                            lvSumAddListByMultiMode.Items.Add(item);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// lvAddEachByClass和lvAddSumByClass数据绑定 - 按班组和日期查询加料记录
        /// </summary>
        /// <param name="additionRecordInfos"></param>
        private void lvAddByClass_DataBind(IList<AdditionRecordInfo> additionRecordInfos)
        {
            lvAddEachByClass.Items.Clear();
            lvAddSumByClass.Items.Clear();
            if (additionRecordInfos.Count == 0)
            {
                MessageBox.Show("没有您要查询的加料信息！");
            }
            else
            {
                foreach (AdditionRecordInfo info in additionRecordInfos)
                {
                    ListViewItem item = new ListViewItem(info.ClassName);
                    item.SubItems.Add(info.HeatId);
                    item.SubItems.Add(info.TreatmentCount.ToString());
                    item.SubItems.Add(info.Car.ToString());
                    item.SubItems.Add(info.AdditionTime.ToString());
                    item.SubItems.Add(info.SiloId.ToString());
                    item.SubItems.Add(info.MaterialType);
                    item.SubItems.Add(info.MaterialName);
                    item.SubItems.Add(info.AdditionAmount.ToString());
                    lvAddEachByClass.Items.Add(item);
                }
                var query = from i in additionRecordList
                            group i by i.MaterialName into g
                            select new
                            {
                                materialName = g.Key,
                                additionAmount = g.Sum(i => i.AdditionAmount)
                            };
                foreach (var info in query)
                {
                    ListViewItem item = new ListViewItem(info.materialName);
                    item.SubItems.Add(info.additionAmount.ToString());
                    lvAddSumByClass.Items.Add(item);
                }
            }
        }
        private void lvAddBySteelGrade_DataBind(IList<AdditionRecordInfo> additionRecordInfos)
        {
            lvEachAdditionListBySteelGrade.Items.Clear();
            dgvAddSumBySteelGrade.Columns.Clear();
            if (additionRecordInfos.Count == 0)
            {
                MessageBox.Show("没有您要查询的加料信息！");
            }
            else
            {
                foreach (AdditionRecordInfo additionRecordInfo in additionRecordInfos)
                {
                    ListViewItem item = new ListViewItem(additionRecordInfo.SteelGradeId);
                    item.SubItems.Add(additionRecordInfo.HeatId);
                    item.SubItems.Add(additionRecordInfo.TreatmentCount.ToString());
                    item.SubItems.Add(additionRecordInfo.AdditionTime.ToString());
                    item.SubItems.Add(additionRecordInfo.SiloId.ToString());
                    item.SubItems.Add(additionRecordInfo.MaterialName);
                    item.SubItems.Add(additionRecordInfo.MaterialType);
                    item.SubItems.Add(additionRecordInfo.AdditionAmount.ToString() + additionRecordInfo.Note);
                    lvEachAdditionListBySteelGrade.Items.Add(item);
                }
                var queryMatName = (from i in additionRecordInfos
                                    select i.MaterialName).Distinct();
                dgvAddSumBySteelGrade.Columns.Add("colSteelGradeId", "钢种号");
                dgvAddSumBySteelGrade.Columns.Add("colTreatmentCount", "冶炼次数");
                foreach (var item in queryMatName)
                {
                    dgvAddSumBySteelGrade.Columns.Add("colMaterial1", item);
                }
                var queryHeatInfo = (from i in additionRecordList
                                     select new
                                     {
                                         HeatId = i.HeatId,
                                         TreatmentCount = i.TreatmentCount,
                                         SteelGradeId = i.SteelGradeId
                                     }).Distinct();
                int index = 0;
                foreach (var item in queryHeatInfo)
                {
                    object[] row = new object[] { item.SteelGradeId, item.TreatmentCount.ToString() };
                    dgvAddSumBySteelGrade.Rows.Add(row);
                    dgvAddSumBySteelGrade.Rows[index++].HeaderCell.Value = item.HeatId;
                }
                var queryAddList = (from i in additionRecordInfos
                                    group i by i.HeatId into g1
                                    select new
                                    {
                                        heatId = g1.Key,
                                        steelGradeId = (from m in g1
                                                        select m.SteelGradeId).ToList<string>(),
                                        treatmentCount = (from j in g1
                                                          group j by j.TreatmentCount into g2
                                                          select new
                                                          {
                                                              treatmentCount = g2.Key,
                                                              addMaterial = (from k in g2
                                                                             group k by k.MaterialName into g3
                                                                             select new
                                                                             {
                                                                                 materialName = g3.Key,
                                                                                 sumAddAmount = g3.Sum(k => k.AdditionAmount)
                                                                             })
                                                          })
                                    });

                foreach (var addHeatId in queryAddList)
                {
                    foreach (var addTreatmentCount in addHeatId.treatmentCount)
                    {
                        foreach (DataGridViewRow rows in dgvAddSumBySteelGrade.Rows)
                        {
                            if (rows.HeaderCell.Value != null)
                            {
                                if (addHeatId.heatId == rows.HeaderCell.Value.ToString() && addTreatmentCount.treatmentCount == Convert.ToInt32(rows.Cells[1].Value))
                                {
                                    foreach (DataGridViewCell cells in rows.Cells)
                                    {
                                        foreach (var addAddition in addTreatmentCount.addMaterial)
                                        {
                                            if (dgvAddSumBySteelGrade.Columns[cells.ColumnIndex].HeaderText == addAddition.materialName)
                                            {
                                                cells.Value = addAddition.sumAddAmount;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
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
        /// <summary>
        /// 按日期查询按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByDate_Click(object sender, EventArgs e)
        {
            btnExpAddReport.Enabled = true;
            additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(dtpStartDate.Value, dtpEndDate.Value);
            lvAddByMultiMode_DataBind(additionRecordList);
        }
        /// <summary>
        /// 按照日期查看班组的加料信息按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByClass_Click(object sender, EventArgs e)
        {
            btnExpAddReport.Enabled = true;
            additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(dtpStartTimeByClass.Value, dtpEndTimeByClass.Value);
            if (cmbClass.Text == "所有")
            {
                lvAddByClass_DataBind(additionRecordList);
            }
            else
            {
                additionRecordList = (from i in additionRecordList
                                      where i.ClassName == cmbClass.Text
                                      orderby i.AdditionTime descending
                                      select i).ToList<AdditionRecordInfo>();
                lvAddByClass_DataBind(additionRecordList);
            }
        }
        /// <summary>
        /// 按炉次号和冶炼次数查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByHeatId_Click(object sender, EventArgs e)
        {
            btnExpAddReport.Enabled = true;
            IList<AdditionRecordInfo> additionRecordInfos;
            if (!string.IsNullOrEmpty(cmbHeatId.Text))
            {
                additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(cmbHeatId.Text);
                if (cmbTreatmentCount.Text == "")
                {
                    additionRecordInfos = (from i in additionRecordList
                                           orderby i.AdditionTime descending
                                           select i).ToList<AdditionRecordInfo>();
                }
                else
                {
                    additionRecordInfos = (from i in additionRecordList
                                           where i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                           orderby i.AdditionTime descending
                                           select i).ToList<AdditionRecordInfo>();
                }
                lvAddByMultiMode_DataBind(additionRecordInfos);
            }
            else
            {
                MessageBox.Show("请选择或者输入一个炉次号！");
            }
        }

        private void btnSearchBySteelGrade_Click(object sender, EventArgs e)
        {
            btnExpAddReport.Enabled = true;
            additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(dtpStartTimeBySteelGrade.Value, dtpEndTimeBySteelGrade.Value);
            if (string.IsNullOrEmpty(cmbSteelGradeId.Text))
            {
                lvAddBySteelGrade_DataBind(additionRecordList);
            }
            else
            {
                additionRecordList = (from i in additionRecordList
                                      where i.SteelGradeId == cmbSteelGradeId.Text
                                      orderby i.AdditionTime descending
                                      select i).ToList<AdditionRecordInfo>();
                lvAddBySteelGrade_DataBind(additionRecordList);
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

        private void dtpStartTimeByClass_ValueChanged(object sender, EventArgs e)
        {
            dtpEndTimeByClass.MinDate = dtpStartTimeByClass.Value;
        }

        private void dtpEndTimeByClass_ValueChanged(object sender, EventArgs e)
        {
            dtpStartTimeByClass.MaxDate = dtpEndTimeByClass.Value;
        }

        private void dtpStartTimeBySteelGrade_ValueChanged(object sender, EventArgs e)
        {
            dtpEndTimeBySteelGrade.MinDate = dtpStartTimeBySteelGrade.Value;
        }

        private void dtpEndTimeBySteelGrade_ValueChanged(object sender, EventArgs e)
        {
            dtpStartTimeBySteelGrade.MaxDate = dtpEndTimeBySteelGrade.Value;
        }

        private void btnExpAddReport_Click(object sender, EventArgs e)
        {
            if (additionRecordList != null)
            {
                exportForm = new ExportProcessReport();
                exportForm.proBarExportExcel.Maximum = 4;
                exportForm.Show();
                bgWorkExportMatAddExcle.RunWorkerAsync();
            }
        }

        private void bgWorkExportMatAddExcle_DoWork(object sender, DoWorkEventArgs e)
        {
            if (additionRecordList != null && additionRecordList.Count != 0)
            {
                I = 1;   //导出进度显示
                bgWorkExportMatAddExcle.ReportProgress(I);
                string NowTime = DateTime.Now.ToLongDateString() + DateTime.Now.Hour.ToString() + "时" + DateTime.Now.Minute.ToString() + "分" + DateTime.Now.Second.ToString() + "秒";
                string fileName;
                if (Directory.Exists("D:\\LF二级加料报告"))
                {
                    fileName = "D:\\LF二级加料报告" + "\\" + tabControlAddMat.SelectedTab.Text + "_" + NowTime + ".XLS";
                }
                else
                {
                    Directory.CreateDirectory("D:\\LF二级加料报告");
                    fileName = "D:\\LF二级加料报告" + "\\" + tabControlAddMat.SelectedTab.Text + "_" + NowTime + ".XLS";
                }

                Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                string appPath = Application.ExecutablePath;
                string appPathDir = appPath.Substring(0, appPath.LastIndexOf('\\'));
                string excelPath = appPathDir + System.Configuration.ConfigurationSettings.AppSettings["ExcelAdditionRecordTemplatePath"];

                I = 2;   //导出进度显示
                bgWorkExportMatAddExcle.ReportProgress(I);
                Excel.Workbook excelWorkBook = excelApp.Workbooks.Open(@excelPath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.ActiveSheet;
                Excel.Range range = excelWorkSheet.get_Range("A4", "T1018");

                int rowIndex = 1;
                foreach (AdditionRecordInfo item in additionRecordList)
                {
                    range.Cells[rowIndex, 1] = item.AdditionTime.ToString();
                    range.Cells[rowIndex, 5] = item.HeatId;
                    range.Cells[rowIndex, 8] = item.TreatmentCount.ToString();
                    range.Cells[rowIndex, 10] = item.SteelGradeId;
                    range.Cells[rowIndex, 13] = item.SiloId.ToString();
                    range.Cells[rowIndex, 15] = item.MaterialName;
                    range.Cells[rowIndex, 18] = item.AdditionAmount.ToString();
                    range.Cells[rowIndex, 20] = item.Note;
                    rowIndex++;
                }

                if (tabControlAddMat.SelectedTab == tabPageAdditionBySteelGrade)
                {
                    excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets.Add(Missing.Value, Missing.Value, 1, Missing.Value);

                    excelWorkSheet.Name = "加料统计—横向显示";
                    int row, col;
                    row = 1;
                    col = 1;
                    excelWorkSheet.Cells[row, col++] = "炉次号";
                    foreach (DataGridViewColumn item in dgvAddSumBySteelGrade.Columns)
                    {
                        excelWorkSheet.Cells[row, col++] = item.HeaderText;
                    }
                    row++;
                    col = 1;

                    range = excelWorkSheet.get_Range("A1", "A10000");
                    range.NumberFormatLocal = "@";

                    foreach (DataGridViewRow item in dgvAddSumBySteelGrade.Rows)
                    {
                        excelWorkSheet.Cells[row, col] = item.HeaderCell.Value;
                        col++;
                        foreach (DataGridViewCell cell in item.Cells)
                        {
                            excelWorkSheet.Cells[row, col] = cell.Value;
                            col++;
                        }
                        col = 1;
                        row++;
                    }
                }
                else
                {
                    var queryAddList = (from i in additionRecordList
                                        group i by i.HeatId into g1
                                        select new
                                        {
                                            heatId = g1.Key,
                                            treatmentCount = (from j in g1
                                                              group j by j.TreatmentCount into g2
                                                              select new
                                                              {
                                                                  treatmentCount = g2.Key,
                                                                  addMaterial = (from k in g2
                                                                                 group k by k.MaterialName into g3
                                                                                 select new
                                                                                 {
                                                                                     materialName = g3.Key,
                                                                                     sumAddAmount = g3.Sum(k => k.AdditionAmount),
                                                                                     steelGradeId = (from m in g3
                                                                                                     select m.SteelGradeId).ToList<string>(),
                                                                                     note = (from n in g3
                                                                                             where n.MaterialName == g3.Key
                                                                                             select n.Note).ToList<string>()
                                                                                 })
                                                              })
                                        });

                    excelWorkSheet = (Excel.Worksheet)excelWorkBook.Worksheets["累计加料记录"];
                    range = excelWorkSheet.get_Range("A4", "T1018");

                    I = 3;   //导出进度显示
                    bgWorkExportMatAddExcle.ReportProgress(I);
                    rowIndex = 1;
                    foreach (var heatIdList in queryAddList)
                    {
                        foreach (var treatmentCountList in heatIdList.treatmentCount)
                        {
                            foreach (var addMatList in treatmentCountList.addMaterial)
                            {
                                range.Cells[rowIndex, 1] = heatIdList.heatId;
                                range.Cells[rowIndex, 6] = treatmentCountList.treatmentCount.ToString();
                                range.Cells[rowIndex, 8] = addMatList.steelGradeId.First();
                                range.Cells[rowIndex, 13] = addMatList.materialName;
                                range.Cells[rowIndex, 17] = addMatList.sumAddAmount.ToString();
                                range.Cells[rowIndex, 20] = addMatList.note.First();
                                rowIndex++;
                            }
                        }
                    }

                }
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
                I = 4;   //导出进度显示
                bgWorkExportMatAddExcle.ReportProgress(I);
            }
        }

        private void bgWorkExportMatAddExcle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            exportForm.proBarExportExcel.Value = e.ProgressPercentage;
        }

        private void bgWorkExportMatAddExcle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportForm.Close();
        }

        private void tabControlAddMat_Selected(object sender, TabControlEventArgs e)
        {
            btnExpAddReport.Enabled = false;
        }
    }
}
