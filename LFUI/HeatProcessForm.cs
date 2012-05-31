using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class HeatProcessForm : Form
    {
        LFHeatStatus heatStatusBll;
        IList<LFHeatStatusInfo> heatStatusList;
        LFHeat lfHeatBLL;
        IList<LFHeatInfo> lfHeatInfoList;
        public HeatProcessForm()
        {
            heatStatusBll = new LFHeatStatus();
            lfHeatBLL = new LFHeat();
            lfHeatInfoList = lfHeatBLL.GetHeatIdList();
            InitializeComponent();
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void HeatProcessForm_Load(object sender, EventArgs e)
        {
            refresh_cmbHeatId();
        }

        private void lvHeatStatusList_DataBind(IList<LFHeatStatusInfo> heatStatusInfos)
        {
            if (heatStatusInfos.Count == 0)
            {
                MessageBox.Show("您要查询的炉次运转状况信息不存在！");
            }
            lvHeatStatusList.Items.Clear();
            foreach (LFHeatStatusInfo info in heatStatusInfos)
            {
                ListViewItem item = new ListViewItem(info.StatusTimeStamp.ToString());
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add(info.TreatmentCount.ToString());
                item.SubItems.Add(info.HeatStatus.StatusName);
                item.SubItems.Add(info.PowerDuration.ToString());
                item.SubItems.Add(info.PowerConsumption.ToString());
                lvHeatStatusList.Items.Add(item);
            }
        }
        /// <summary>
        /// cmbHeatId炉次号数据绑定
        /// </summary>
        private void refresh_cmbHeatId()
        {
            cmbHeatId.Items.Clear();
            IList<string> heatIdList = (from i in lfHeatInfoList
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
            IList<int> treatmentCountList = (from i in lfHeatInfoList
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
            heatStatusList = heatStatusBll.GetLFHeatStatus(cmbHeatId.Text);
            if (cmbTreatmentCount.Text == "")
            {
                lvHeatStatusList_DataBind(heatStatusList);
            }
            else
            {
                heatStatusList = (from i in heatStatusList
                                  where i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                  select i).ToList<LFHeatStatusInfo>();
                lvHeatStatusList_DataBind(heatStatusList);
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
            heatStatusList = heatStatusBll.GetLFHeatStatus(startDate, endDate);
            lvHeatStatusList_DataBind(heatStatusList);
        }
        /// <summary>
        /// '查询近三个月通电记录'按钮方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchRecentRecord_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            heatStatusList = heatStatusBll.GetLFHeatStatus(startDate, DateTime.Now);
            lvHeatStatusList_DataBind(heatStatusList);
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
