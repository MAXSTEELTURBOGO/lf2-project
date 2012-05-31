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
    public partial class RouteModifyForm : Form
    {
        public string selectRouteCode;
        public string selectRouteDesc;
        private Route route;
        private RouteInfo routeInfo;
        public RouteModifyForm()
        {
            InitializeComponent();
            route = new Route();
            selectRouteCode = "";
            selectRouteDesc = "";
        }
        private void RouteModifyForm_Load(object sender, EventArgs e)
        {
            lvRouteInfoList_DataBind();
        }
        private void lvRouteInfoList_DataBind()
        {
            IList<RouteInfo> routeInfos = route.GetAllRouteInfo();
            foreach (RouteInfo info in routeInfos)
            {
                ListViewItem item = new ListViewItem(info.RouteId);
                item.SubItems.Add(info.RouteDesc);
                lvRouteInfoList.Items.Add(item);
            }
        }

        private void btnCloseRoute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void btnClearRoute_Click(object sender, EventArgs e)
        {
            selectRouteCode = "";
            txtRouteInfoDesc.Text = "";
            lvRouteInfoList.Items.Clear();
            lvRouteInfoList_DataBind();
        }

        private void btnConfirmRoute_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            routeInfo = new RouteInfo(selectRouteCode, txtRouteInfoDesc.Text);
            this.Close();
        }

        private void lvRouteInfoList_ItemActivate(object sender, EventArgs e)
        {
            if (lvRouteInfoList.SelectedItems.Count == 1)
            {
                selectRouteCode = selectRouteCode + lvRouteInfoList.SelectedItems[0].SubItems[0].Text;
                selectRouteDesc = selectRouteDesc + "->" + lvRouteInfoList.SelectedItems[0].SubItems[1].Text;
                txtRouteInfoDesc.Text = selectRouteDesc;
                lvRouteInfoList.SelectedItems[0].Remove();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult==DialogResult.OK||this.DialogResult==DialogResult.Abort)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
            
        }
    }
}