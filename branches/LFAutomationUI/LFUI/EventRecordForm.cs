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
    public partial class EventRecordForm : Form
    {
        EventRecord eventRecordBll;
        IList<EventRecordInfo> eventRecordList;
        IList<EventRecordInfo> eventRecordNowInfos;
        IList<LFHeatInfo> eventRecordHeatInfos;

        public EventRecordForm()
        {
            eventRecordBll = new EventRecord();
            LFHeat lfHeatBll = new LFHeat();
            eventRecordHeatInfos = lfHeatBll.GetHeatIdList();
            InitializeComponent();
            dtpStartDate.MaxDate = dtpEndDate.Value;
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void EventRecordForm_Load(object sender, EventArgs e)
        {
            cmbHeatId_DataBind();
        }

        private void lvEventRecordList_DataBind(IList<EventRecordInfo> eventRecordInfos)
        {
            lvEventRecordList.Items.Clear();
            foreach (EventRecordInfo info in eventRecordInfos)
            {
                ListViewItem item = new ListViewItem(info.MsgTimeStamp.ToString());
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add(info.TreatmentCount.ToString());
                item.SubItems.Add(info.EventType);
                item.SubItems.Add(info.Info);
                lvEventRecordList.Items.Add(item);
            }
        }

        /// <summary>
        /// cmbHeatId炉次号数据绑定
        /// </summary>
        private void cmbHeatId_DataBind()
        {
            cmbHeatId.Items.Clear();
            IList<string> heatIdList = (from i in eventRecordHeatInfos
                                        select i.HeatId).Distinct().ToList<string>();
            cmbHeatId.DataSource = heatIdList;
        }
        /// <summary>
        /// cmbTreatmentCount冶炼次数数据绑定
        /// </summary>
        /// <param name="treatmentCountList">冶炼次数列表</param>
        private void cmbTreatmentCount_DataBind(IList<int> treatmentCountList)
        {
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
            eventRecordList = eventRecordBll.GetEventRecords(cmbHeatId.Text);
            if (cmbTreatmentCount.Text == "")
            {
                eventRecordNowInfos = eventRecordList;
            }
            else
            {
                eventRecordNowInfos = (from i in eventRecordList
                                       where i.HeatId == cmbHeatId.Text && i.TreatmentCount == Convert.ToInt32(cmbTreatmentCount.Text)
                                       select i).ToList<EventRecordInfo>();
            }
            if (cbAdditionMat.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "加料" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbPower.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "通电记录" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbHeatProcess.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "过程" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbTempOxygen.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "测温" || i.EventType == "测温+测氧" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbQuality.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "化验信息" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbSlagQuality.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "渣化验信息" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            lvEventRecordList_DataBind(eventRecordNowInfos);
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
            eventRecordList = eventRecordBll.GetEventRecords(startDate, endDate);
            eventRecordNowInfos = (from i in eventRecordList
                                   where i.MsgTimeStamp > dtpStartDate.Value && i.MsgTimeStamp < dtpEndDate.Value.AddDays(1)
                                   select i).ToList<EventRecordInfo>();
            if (cbAdditionMat.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "加料" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbPower.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "通电记录" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbHeatProcess.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "过程" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbTempOxygen.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "测温" || i.EventType == "测温+测氧" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbQuality.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "化验信息" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            if (cbSlagQuality.CheckState == CheckState.Unchecked)
            {
                IList<EventRecordInfo> eventRecordRemoveInfos = (from i in eventRecordNowInfos where i.EventType == "渣化验信息" select i).ToList<EventRecordInfo>();
                foreach (EventRecordInfo item in eventRecordRemoveInfos)
                {
                    eventRecordNowInfos.Remove(item);
                }
            }
            lvEventRecordList_DataBind(eventRecordNowInfos);
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
            cmbTreatmentCount.Text = "";
            IList<int> treatmentCountList = (from i in eventRecordHeatInfos
                                             where i.HeatId == cmbHeatId.Text
                                             select i.TreatmentCount).Distinct().ToList<int>();
            cmbTreatmentCount_DataBind(treatmentCountList);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpStartDate.MaxDate = dtpEndDate.Value;
        }

        private void lvEventRecordList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEventRecordList.SelectedItems.Count > 0)
            {
                txtEventDetailInfo.Text = lvEventRecordList.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                txtEventDetailInfo.Text = "";
            }
        }
    }
}
