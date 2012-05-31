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
    public partial class PowerRecordForm : Form
    {
        PowerOnRecord powerOnRecordBll;
        IList<PowerOnRecordInfo> powerOnRecordList;
        LFHeat lfHeatBLL;
        IList<LFHeatInfo> lfHeatList;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PowerRecordForm()
        {
            lfHeatBLL = new LFHeat();
            powerOnRecordBll = new PowerOnRecord();
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
        private void PowerRecordForm_Load(object sender, EventArgs e)
        {
            refresh_cmbHeatId();
        }
        /// <summary>
        /// lvPowerRecordList通电记录列表数据绑定
        /// </summary>
        /// <param name="powerRecordInfos">通电记录</param>
        private void lvPowerRecordList_DataBind(IList<PowerOnRecordInfo> powerOnRecordInfos)
        {
            lvPowerOnRecordList.Items.Clear();
            foreach (PowerOnRecordInfo powerOnRecordInfo in powerOnRecordInfos)
            {
                ListViewItem item = new ListViewItem(powerOnRecordInfo.HeatId);
                item.SubItems.Add(powerOnRecordInfo.TreatmentCount.ToString());
                item.SubItems.Add(powerOnRecordInfo.Car.ToString());
                item.SubItems.Add("LF" + powerOnRecordInfo.StationId.ToString());
                item.SubItems.Add(powerOnRecordInfo.StartPowerOnTime.ToString());
                item.SubItems.Add(powerOnRecordInfo.EndPowerOnTime.ToString());
                item.SubItems.Add((powerOnRecordInfo.EndPowerOnTime - powerOnRecordInfo.StartPowerOnTime).ToString());
                item.SubItems.Add(powerOnRecordInfo.PowerConsumption.ToString());
                lvPowerOnRecordList.Items.Add(item);
            }
        }
        /// <summary>
        /// cmbHeatId炉次号数据绑定
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
        /// cmbTreatmentCount冶炼次数数据绑定
        /// </summary>
        /// <param name="treatmentCountList">冶炼次数列表</param>
        private void refresh_cmbTreatmentCount()
        {
            cmbTreatmentCount.Text = "";
            IList<int> treatmentCountList = (from i in lfHeatList
                                             where i.HeatId == cmbHeatId.Text
                                             select i.TreatmentCount).Distinct().ToList<int>();
            cmbTreatmentCount.Items.Clear();
            foreach (int item in treatmentCountList)
            {
                cmbTreatmentCount.Items.Add(item);
            }
            cmbTreatmentCount.Items.Add("");
        }
        /// <summary>
        /// 按炉次号和冶炼次数查询方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchByHeatId_Click(object sender, EventArgs e)
        {
            powerOnRecordList = powerOnRecordBll.GetPowerOnRecord(cmbHeatId.Text);
            if (!string.IsNullOrEmpty(cmbHeatId.Text))
            {
                if (cmbTreatmentCount.Text == "")
                {
                    lvPowerRecordList_DataBind(powerOnRecordList);
                } 
                else
                {
                    powerOnRecordList = (from i in powerOnRecordList
                                         where i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                         select i).ToList<PowerOnRecordInfo>();
                    lvPowerRecordList_DataBind(powerOnRecordList);
                }
            }
            else
            {
                MessageBox.Show("请选择或者输入一个炉次号");
            }

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
            powerOnRecordList = powerOnRecordBll.GetPowerOnRecord(startDate, endDate);
            lvPowerRecordList_DataBind(powerOnRecordList);
        }
        /// <summary>
        /// '查询近期通电记录'按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchAllRecord_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            powerOnRecordList = powerOnRecordBll.GetPowerOnRecord(startTime, DateTime.Now);
            lvPowerRecordList_DataBind(powerOnRecordList);
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
