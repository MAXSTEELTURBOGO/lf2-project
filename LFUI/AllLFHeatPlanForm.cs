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
    public partial class AllLFHeatPlanForm : Form
    {
        LFHeat lfHeatBLL;
        private IList<LFHeatInfo> allLFHeatList;
        private IList<LFHeatInfo> onGoingLFHeatList;
        private IList<LFHeatInfo> doneLFHeatList;
        private IList<LFHeatInfo> toBeDoneLFHeatList;

        public AllLFHeatPlanForm()
        {
            InitializeComponent();
        }

        private void AllLFHeatPlanForm_Load(object sender, EventArgs e)
        {
            lfHeatBLL = new LFHeat();
            refreshLFHeatPlanList();
            lvNotHeatPlan_DataBind(toBeDoneLFHeatList);
            lvEndHeatPlan_DataBind(doneLFHeatList);
            heatingPlan_DataBind(onGoingLFHeatList);
        }

        private void refreshLFHeatPlanList()
        {
            allLFHeatList = lfHeatBLL.GetAllLFHeatPlan();
            toBeDoneLFHeatList = (from i in allLFHeatList
                                  where i.CurrentHeatStatus == "TO BE DONE"
                                  select i).ToList<LFHeatInfo>();
            doneLFHeatList = (from i in allLFHeatList
                              where i.CurrentHeatStatus == "DONE"
                              select i).ToList<LFHeatInfo>();
            onGoingLFHeatList = (from i in allLFHeatList
                                 where i.CurrentHeatStatus == "ON GOING"
                                 select i).ToList<LFHeatInfo>();
        }

  

        private void lvNotHeatPlan_DataBind(IList<LFHeatInfo> lfHeatPlanList)
        {
            lvNotHeatPlan.Items.Clear();
            foreach (LFHeatInfo info in lfHeatPlanList)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(info.Visible == true ? "可见" : "不可见");
                item.SubItems.Add(info.PlanId.ToString());
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add(info.TreatmentCount.ToString());
                item.SubItems.Add(info.SteelGrade.SteelGradeId);
                item.SubItems.Add(info.Ladle.LadleId);
                item.SubItems.Add(info.SteelGrade.RouteDesc);
                lvNotHeatPlan.Items.Add(item);
            }
        }

        private void lvEndHeatPlan_DataBind(IList<LFHeatInfo> lfHeatPlanList)
        {
            lvEndHeatPlan.Items.Clear();
            foreach (LFHeatInfo info in lfHeatPlanList)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(info.Visible == true ? "可见" : "不可见");
                item.SubItems.Add(info.PlanId.ToString());
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add(info.TreatmentCount.ToString());
                item.SubItems.Add(info.IntParseCar().ToString());
                item.SubItems.Add(info.SteelGrade.SteelGradeId);
                item.SubItems.Add(info.Ladle.LadleId);
                item.SubItems.Add(info.CurrentDetailStatusName);
                item.SubItems.Add(info.SteelGrade.RouteDesc);
                lvEndHeatPlan.Items.Add(item);
            }
        }

        private void heatingPlan_DataBind(IList<LFHeatInfo> lfHeatPlanList)
        {
            lvHeatingPlan.Items.Clear();
            foreach (LFHeatInfo info in lfHeatPlanList)
            {
                ListViewItem item = new ListViewItem(info.PlanId.ToString());
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add(info.TreatmentCount.ToString());
                item.SubItems.Add(info.IntParseCar().ToString());
                item.SubItems.Add(info.SteelGrade.SteelGradeId);
                item.SubItems.Add(info.Ladle.LadleId);
                item.SubItems.Add(info.CurrentDetailStatusName);
                item.SubItems.Add(info.SteelGrade.RouteDesc);
                lvHeatingPlan.Items.Add(item);
            }
        }

        private void btnAddNewPlan_Click(object sender, EventArgs e)
        {
            NewLFHeatPlanForm newLFHeatPlanForm = new NewLFHeatPlanForm();
            newLFHeatPlanForm.ShowDialog();
        }

        private void btnSetHide_Click(object sender, EventArgs e)
        {
            if (tabControlAllHeatPlan.SelectedTab.Name == "tabPageDoneHeatPlan")
            {
                foreach (ListViewItem item in lvEndHeatPlan.Items)
                {
                    if (item.Checked == true)
                    {
                        string heatId = item.SubItems[3].Text;
                        int treatmentCount = Convert.ToInt32(item.SubItems[4].Text);
                        LFHeatInfo lfHeatInfo = new LFHeatInfo(heatId, treatmentCount);
                        lfHeatBLL.ResetLFHeatVisible(lfHeatInfo);
                    }
                }
                refreshLFHeatPlanList();
                lvEndHeatPlan_DataBind(doneLFHeatList);
            }
            else if (tabControlAllHeatPlan.SelectedTab.Name == "tabPageToBeDoneHeatPlan")
            {
                foreach (ListViewItem item in lvNotHeatPlan.Items)
                {
                    if (item.Checked == true)
                    {
                        string heatId = item.SubItems[3].Text;
                        int treatmentCount = Convert.ToInt32(item.SubItems[4].Text);
                        LFHeatInfo lfHeatInfo = new LFHeatInfo(heatId, treatmentCount);
                        lfHeatBLL.ResetLFHeatVisible(lfHeatInfo);
                    }
                }
                refreshLFHeatPlanList();
                lvNotHeatPlan_DataBind(toBeDoneLFHeatList);
            }
        }

        private void btnCancelHide_Click(object sender, EventArgs e)
        {
            if (tabControlAllHeatPlan.SelectedTab.Name == "tabPageDoneHeatPlan")
            {
                foreach (ListViewItem item in lvEndHeatPlan.Items)
                {
                    if (item.Checked == true)
                    {
                        string heatId = item.SubItems[3].Text;
                        int treatmentCount = Convert.ToInt32(item.SubItems[4].Text);
                        LFHeatInfo lfHeatInfo = new LFHeatInfo(heatId, treatmentCount);
                        lfHeatBLL.SetLFHeatVisible(lfHeatInfo);
                    }
                }
                refreshLFHeatPlanList();
                lvEndHeatPlan_DataBind(doneLFHeatList);
            }
            else if (tabControlAllHeatPlan.SelectedTab.Name == "tabPageToBeDoneHeatPlan")
            {
                foreach (ListViewItem item in lvNotHeatPlan.Items)
                {
                    if (item.Checked == true)
                    {
                        string heatId = item.SubItems[3].Text;
                        int treatmentCount = Convert.ToInt32(item.SubItems[4].Text);
                        LFHeatInfo lfHeatInfo = new LFHeatInfo(heatId, treatmentCount);
                        lfHeatBLL.SetLFHeatVisible(lfHeatInfo);
                    }
                }
                refreshLFHeatPlanList();
                lvNotHeatPlan_DataBind(toBeDoneLFHeatList);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void tabControlAllHeatPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlAllHeatPlan.SelectedTab.Name == "tabPageOnGoingHeatPlan")
            {
                btnSetHide.Enabled = false;
                btnCancelHide.Enabled = false;
            }
            else
            {
                btnSetHide.Enabled = true;
                btnCancelHide.Enabled = true;
            }
        }
    }
}
