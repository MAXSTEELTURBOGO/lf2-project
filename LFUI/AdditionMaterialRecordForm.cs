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
    public partial class AdditionMaterialRecordForm : Form
    {
        private LFHeat lfHeatBLL;
        private IList<LFHeatInfo> lfHeatList;
        private AdditionRecord additionRecordBLL;
        private IList<AdditionRecordInfo> additionRecordList;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdditionMaterialRecordForm()
        {
            lfHeatBLL = new LFHeat();
            additionRecordBLL = new AdditionRecord();
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
        /// <summary>
        /// 窗体加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdditionMaterialRecordForm_Load(object sender, EventArgs e)
        {
            refresh_cmbHeatId();
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
        /// lvAdditionRecordList加料记录列表数据绑定
        /// </summary>
        /// <param name="additionRecordInfos">加料记录</param>
        private void lvAdditionRecordList_DataBind(IList<AdditionRecordInfo> additionRecordInfos)
        {
            lvAdditionRecordList.Items.Clear();
            if (additionRecordInfos.Count==0)
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
                    item.SubItems.Add("LF" + additionRecordInfo.StationId.ToString());
                    item.SubItems.Add(additionRecordInfo.AdditionTime.ToString());
                    item.SubItems.Add(additionRecordInfo.SiloId.ToString());
                    item.SubItems.Add(additionRecordInfo.AdditionMaterialId.ToString());
                    item.SubItems.Add(additionRecordInfo.MaterialL3Id);
                    item.SubItems.Add(additionRecordInfo.MaterialName);
                    item.SubItems.Add(additionRecordInfo.MaterialType);
                    item.SubItems.Add(additionRecordInfo.AdditionAmount.ToString() + additionRecordInfo.Note);
                    lvAdditionRecordList.Items.Add(item);
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
        /// '查询近期加料信息'按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchRecentRecord_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,DateTime.Now.Day, 0, 0, 0);
            additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(startDate, DateTime.Now);
            lvAdditionRecordList_DataBind(additionRecordList);
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
            additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(startDate, endDate);
            lvAdditionRecordList_DataBind(additionRecordList);
        }
        /// <summary>
        /// 按炉次号和冶炼次数查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByHeatId_Click(object sender, EventArgs e)
        {
            IList<AdditionRecordInfo> additionRecordInfos;
            if (!string.IsNullOrEmpty(cmbHeatId.Text))
            {
                additionRecordList = additionRecordBLL.GetAdditionMaterialRecords(cmbHeatId.Text);
                if (cmbTreatmentCount.Text == "")
                {
                    additionRecordInfos = (from i in additionRecordList
                                           select i).ToList<AdditionRecordInfo>();
                }
                else
                {
                    additionRecordInfos = (from i in additionRecordList
                                           where i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                           select i).ToList<AdditionRecordInfo>();
                }
                lvAdditionRecordList_DataBind(additionRecordInfos);
            }
            else
            {
                MessageBox.Show("请选择或者输入一个炉次号！");
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
    }
}
