using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Windows.Forms;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;
using System.Data.OracleClient;
using System.Configuration;
using MSScriptControl;
using System.Windows.Forms.DataVisualization.Charting;

namespace LFAutomationUI.LFUI
{
    public partial class LFMainForm : Form
    {
        private UserInfo user;
        private LoginInfo login;
        private TreatmentStation stationBLL;
        private IList<TreatmentStationInfo> stations;

        private IList<LFHeatInfo> allLFHeatList;
        private IList<LFHeatInfo> onGoingLFHeatList;
        private IList<LFHeatInfo> doneLFHeatList;
        private IList<LFHeatInfo> toBeDoneLFHeatList;
        private ScreenMode screenMode;
        private string pattern;

        public static readonly string LFDBUSERConnectionString = ConfigurationManager.ConnectionStrings["LFDBConnectionString"].ConnectionString;
        public LFMainForm()
        {
            InitializeComponent();
        }

        private void LFMainForm_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void LoadForm()
        {
            
            this.screenMode = ScreenMode.NormalMode;
            this.panelLFMain.Visible = false;
            this.Visible = false;
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.user = loginForm.User;
                login = new LoginInfo();
                login.User = this.user;
                Login loginBLL = new Login();
                loginBLL.InsertLoginInfo(login);
                this.toolStripStatusLabelUserName.Text = "当前用户:" + this.user.UserName;
                RefreshMenu();
                系统ToolStripMenuItem.Visible = true;
                退出系统ToolStripMenuItem.Visible = true;
                this.Visible = true;
                this.timerRefreshStatus.Enabled = true;
                this.timerRefreshCCMInfo.Enabled = true;
                stationBLL = new TreatmentStation();
                Control.CheckForIllegalCrossThreadCalls = false;
            }
            else
            {
                Application.Exit();
            }
        }

        private void RefreshMenu()
        {
            for (int i = 0; i < this.menuStripLFUI.Items.Count; i++)
            {
                SetUnvisibleMenuItem((ToolStripMenuItem)menuStripLFUI.Items[i]);
            }

            IList<PrivilegeInfo> privileges = user.Privileges;

            for (int i = 0; i < menuStripLFUI.Items.Count; i++)
            {
                SetPrivilegeMenuItem((ToolStripMenuItem)menuStripLFUI.Items[i], privileges);
            }
        }

        private void SetUnvisibleMenuItem(ToolStripMenuItem menuItem)
        {
            for (int i = 0; i < menuItem.DropDownItems.Count; i++)
            {
                SetUnvisibleMenuItem((ToolStripMenuItem)menuItem.DropDownItems[i]);
            }

            menuItem.Visible = false;
        }

        private void SetVisibleMenuItem(ToolStripMenuItem menuItem)
        {
            for (int i = 0; i < menuItem.DropDownItems.Count; i++)
            {
                SetVisibleMenuItem((ToolStripMenuItem)menuItem.DropDownItems[i]);
            }
            menuItem.Visible = true;
        }

        private void SetPrivilegeMenuItem(ToolStripMenuItem menuItem, IList<PrivilegeInfo> privileges)
        {
            try
            {
                PrivilegeInfo privi = (from i in privileges
                                       where i.PrivilegeName == menuItem.Text
                                       select i).First();

                if (privi.PriviDescription == 1)
                {
                    SetVisibleMenuItem(menuItem);
                }
                else
                {
                    if (privi.PriviDescription == 2)
                    {
                        SetUnvisibleMenuItem(menuItem);
                    }
                    else
                    {

                        for (int i = 0; i < menuItem.DropDownItems.Count; i++)
                        {
                            SetPrivilegeMenuItem((ToolStripMenuItem)menuItem.DropDownItems[i], privileges);
                        }
                        menuItem.Visible = true;
                    }
                }
            }
            catch (Exception)
            {
                SetUnvisibleMenuItem(menuItem);
            }

        }

        private void 当前用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleUserForm userForm = new SingleUserForm(user);
            userForm.ShowDialog();
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrivilegeInfoForm privilegeInfoForm = new PrivilegeInfoForm();
            privilegeInfoForm.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login loginBLL = new Login();
            loginBLL.UpdateLoginInfo(login);

            Application.Exit();
        }

        private void 角色信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoleInfoForm roleInfoForm = new RoleInfoForm();
            roleInfoForm.ShowDialog();
        }

        private void 钢种信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SteelInfoForm steelInfoForm = new SteelInfoForm();
            steelInfoForm.ShowDialog();
        }

        private void 所有用户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllUsersInfoForm allUserInfoForm = new AllUsersInfoForm();
            allUserInfoForm.ShowDialog();
        }

        private void 班组信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassInfoForm classInfoForm = new ClassInfoForm();
            classInfoForm.ShowDialog();
        }

        private void 重新登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Login loginBLL = new Login();
            loginBLL.UpdateLoginInfo(login);
            LoadForm();
        }

        private void 用户登录日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginInfoForm loginInfoForm = new LoginInfoForm();
            loginInfoForm.ShowDialog();
        }

        /// <summary>
        /// 检查连接状态
        /// </summary>
        /// 
        private void checkCommStatus()
        {
            if (stations == null)
            {
                stations = stationBLL.GetTreatmentStations();
            }
            else
            {
                stations.Clear();
                stations = stationBLL.GetTreatmentStations();
            }

            #region 检查状态
            switch (stations.Single<TreatmentStationInfo>(i => i.TreatmentStationName == "L3").TreatmentStationStatus)
            {
                case CommStatus.Good:
                    this.toolStripStatusL3Status.ForeColor = Color.Green;
                    break;
                case CommStatus.Bad:
                    this.toolStripStatusL3Status.ForeColor = Color.Red;
                    break;
                case CommStatus.Unknown:
                    this.toolStripStatusL3Status.ForeColor = Color.Yellow;
                    break;
                default:
                    this.toolStripStatusL3Status.ForeColor = Color.Yellow;
                    break;
            }

            switch (stations.Single<TreatmentStationInfo>(i => i.TreatmentStationName == "BOF").TreatmentStationStatus)
            {
                case CommStatus.Good:
                    this.toolStripStatusL2Status.ForeColor = Color.Green;
                    break;
                case CommStatus.Bad:
                    this.toolStripStatusL2Status.ForeColor = Color.Red;
                    break;
                case CommStatus.Unknown:
                    this.toolStripStatusL2Status.ForeColor = Color.Yellow;
                    break;
                default:
                    this.toolStripStatusL2Status.ForeColor = Color.Yellow;
                    break;
            }

            switch (stations.Single<TreatmentStationInfo>(i => i.TreatmentStationName == "L1_PSC1").TreatmentStationStatus)
            {
                case CommStatus.Good:
                    this.toolStripStatusPLCStatus.ForeColor = Color.Green;
                    break;
                case CommStatus.Bad:
                    this.toolStripStatusPLCStatus.ForeColor = Color.Red;
                    break;
                case CommStatus.Unknown:
                    this.toolStripStatusPLCStatus.ForeColor = Color.Yellow;
                    break;
                default:
                    this.toolStripStatusPLCStatus.ForeColor = Color.Yellow;
                    break;
            }

            TreatmentStationInfo treatStation = stations.Single<TreatmentStationInfo>(i => i.TreatmentStationName == "Server");
            treatStation.UpdateStatus();
            switch (treatStation.TreatmentStationStatus)
            {
                case CommStatus.Good:
                    this.toolStripStatusLabelClientToServer.ForeColor = Color.Green;
                    break;
                case CommStatus.Bad:
                    this.toolStripStatusLabelClientToServer.ForeColor = Color.Red;
                    break;
                case CommStatus.Unknown:
                    this.toolStripStatusLabelClientToServer.ForeColor = Color.Yellow;
                    break;
                default:
                    this.toolStripStatusLabelClientToServer.ForeColor = Color.Yellow;
                    break;
            }

            #endregion
        }

        private void 过程控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panelLFMain.Visible = true;
            this.panelLFMain.BringToFront();
        }

        private void 钢种信息查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SteelInfoSearchForm steelInfoSearchForm = new SteelInfoSearchForm();
            steelInfoSearchForm.ShowDialog();
        }

        private void btnCloseMainControl_Click(object sender, EventArgs e)
        {
            this.panelLFMain.Visible = false;
        }

        private void setAllLFContentPanelUnvisible()
        {
            this.panelMainControl.Visible = false;
            this.panelSteelGradeDetailInfo.Visible = false;
            this.panelQualityInfo.Visible = false;
            this.panelBOFRHHeatDetail.Visible = false;
            this.panelLFHeatDetail.Visible = false;
            this.panelLFProcessInfo.Visible = false;
            this.panelTempEstimate.Visible = false;
            this.panelAlloyCalculator.Visible = false;
        }

        private void setAllControlButtonEnabled()
        {
            this.btnMainControl.Enabled = true;
            this.btnLFHeatSteelDetailInfo.Enabled = true; ;
            this.btnQualityInfo.Enabled = true;
            this.btnBOFRHHeatInfo.Enabled = true;
            this.btnLFDetailHeatInfo.Enabled = true;
            this.btnLFProcessInfo.Enabled = true;
            this.btnTemperaturePrediction.Enabled = true;
            this.btnAlloyCalculate.Enabled = true;
        }

        private void toolStripSplitButtonFullScreen_ButtonClick(object sender, EventArgs e)
        {
            int heightInc = 55;
            if (this.screenMode == ScreenMode.NormalMode)
            {
                this.toolStripSplitButtonFullScreen.Text = "正常显示";
                this.screenMode = ScreenMode.FullScreenMode;
                this.SetVisibleCore(false);
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

                this.panelLFContainer.Height += heightInc;
                this.panelLFContent.Height += heightInc;
                this.panelHearListAndEditButton.Height += heightInc;
                this.panelHeatListInfo.Height += heightInc;

                this.SetVisibleCore(true);
            }
            else
            {
                this.toolStripSplitButtonFullScreen.Text = "全屏显示";
                this.screenMode = ScreenMode.NormalMode;
                this.SetVisibleCore(false);
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Maximized;

                this.panelLFContainer.Height -= heightInc;
                this.panelLFContent.Height -= heightInc;
                this.panelHearListAndEditButton.Height -= heightInc;
                this.panelHeatListInfo.Height -= heightInc;

                this.SetVisibleCore(true);
            }

        }

        private void 元素信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElementInfoForm elementInfoForm = new ElementInfoForm();
            elementInfoForm.ShowDialog();
        }

        private void 物料信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialInfoForm materialInfoForm = new MaterialInfoForm();
            materialInfoForm.ShowDialog();
        }

        private void 料仓管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SourceForm siloForm = new SourceForm();
            siloForm.ShowDialog();
        }

        private void 变压器维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransformerParamForm transformerParamForm = new TransformerParamForm();
            transformerParamForm.ShowDialog();
        }

        private void 步骤信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepInfoForm stepInfoForm = new StepInfoForm();
            stepInfoForm.ShowDialog();
        }

        private void 设备信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EuipmentInfoForm equipmentInfoForm = new EuipmentInfoForm();
            equipmentInfoForm.ShowDialog();
        }

        private void 工艺过程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechnicInfoForm technicInfoForm = new TechnicInfoForm();
            technicInfoForm.ShowDialog();
        }

        private void 基础信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasicInfoForm basicInfoForm = new BasicInfoForm();
            basicInfoForm.ShowDialog();
        }

        private void 物料配方管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialRecipeForm matRecipeForm = new MaterialRecipeForm();
            matRecipeForm.ShowDialog();
        }

        private void 加料日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdditionRecordForm additionMaterialRecordForm = new AdditionRecordForm();
            additionMaterialRecordForm.ShowDialog();
        }

        private void 通电日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PowerRecordForm powerOnRecordForm = new PowerRecordForm();
            powerOnRecordForm.ShowDialog();
        }

        private void 测温测氧日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TempOxygenRecordForm tempOxygenRecordForm = new TempOxygenRecordForm();
            tempOxygenRecordForm.ShowDialog();
        }

        private void 冶炼进程日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeatProcessForm heatProcessForm = new HeatProcessForm();
            heatProcessForm.ShowDialog();
        }

        private void 事件记录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EventRecordForm eventRecordForm = new EventRecordForm();
            eventRecordForm.ShowDialog();
        }

        private void 单炉次信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SingleHeatReportForm singleReportForm = new SingleHeatReportForm();
            singleReportForm.ShowDialog();
        }

        private void 多炉次信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiHeatReportForm multiReportForm = new MultiHeatReportForm();
            multiReportForm.ShowDialog();
        }

        private void panelMainControl_VisibleChanged(object sender, EventArgs e)
        {
            if (panelMainControl.Visible == true)
            {
                refreshLFHeatList();
            }
        }

        private void bindLFHeatList()//done
        {
            int doneCount = Convert.ToInt32(this.numericUpDownDoneCount.Value);
            int toBeDoneCount = Convert.ToInt32(this.numericUpDownToBeDoneHeatCount.Value);

            appendLFHeatList(doneLFHeatList.OrderByDescending<LFHeatInfo, DateTime?>(i => i.DepartTime).Take<LFHeatInfo>(doneCount).OrderBy<LFHeatInfo, DateTime?>(i => i.DepartTime));
            appendLFHeatList(onGoingLFHeatList);
            appendLFHeatList(toBeDoneLFHeatList.OrderByDescending<LFHeatInfo, int>(i => Convert.ToInt16(i.SelectedFlag)).ThenBy<LFHeatInfo, DateTime>(i => i.MsgTimeStamp).Take<LFHeatInfo>(toBeDoneCount));
            if (onGoingLFHeatList.Count == 2)
            {
                this.btnSwapCar.Enabled = true;
            }
        }

        private void refreshLFHeatList()
        {
            LFHeat lfHeatBLL = new LFHeat();
            allLFHeatList = lfHeatBLL.GetLFHeatDetailInfo(out onGoingLFHeatList, out  doneLFHeatList, out toBeDoneLFHeatList);//done
            this.lvHeatInfo.Items.Clear();
            bindLFHeatList();
        }

        private void appendLFHeatList(IEnumerable<LFHeatInfo> bindHeatList)//done
        {
            foreach (LFHeatInfo item in bindHeatList)
            {
                ListViewItem lvItem = new ListViewItem(item.HeatId.ToString());
                //lvItem.SubItems.Add(item.HeatId);
                lvItem.SubItems.Add(item.TreatmentCount.ToString());
                lvItem.SubItems.Add(item.IntParseCar().ToString());
                lvItem.SubItems.Add(item.SteelGrade.SteelGradeId);
                lvItem.SubItems.Add(item.SteelGrade.StaffCod);
                lvItem.SubItems.Add(item.SLD_ID);
                lvItem.SubItems.Add(item.ArrivalTime.ToString());
                lvItem.SubItems.Add(item.DepartTime.ToString());
                lvItem.SubItems.Add(item.CurrentDetailStatusName);
                lvItem.SubItems.Add(item.SteelGrade.RouteDesc);
                if (item.SelectedFlag == true || item.CurrentHeatStatus == "ON GOING")
                {
                    lvItem.BackColor = Color.Pink;
                }
                else
                {
                    if (item.CurrentHeatStatus == "DONE")
                    {
                        lvItem.BackColor = Color.FromArgb(220, 220, 220);
                    }
                    else
                    {
                        lvItem.BackColor = Color.LightYellow;
                    }
                }
                this.lvHeatInfo.Items.Add(lvItem);
            }
        }

        private void lvSelectedQualityList_DataBind()
        {
            if (string.IsNullOrEmpty(lblHeatId.Text.Trim()) == false)
            {
                lvSelectedQualityList.Items.Clear();
                QualityHorizontal qualityDetailBLL = new QualityHorizontal();
                IList<QualityHorizontalInfo> qualityDetailList = qualityDetailBLL.GetQualityDetailInfo(lblHeatId.Text.Trim());
                foreach (QualityHorizontalInfo info in qualityDetailList)
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
                    item.SubItems.Add(info.EleALS.ToString());
                    item.SubItems.Add(info.EleALT.ToString());
                    item.SubItems.Add(info.EleNB.ToString());
                    item.SubItems.Add(info.EleV.ToString());
                    item.SubItems.Add(info.EleTI.ToString());
                    item.SubItems.Add(info.EleNI.ToString());
                    item.SubItems.Add(info.EleCR.ToString());
                    item.SubItems.Add(info.EleCU.ToString());
                    item.SubItems.Add(info.EleB.ToString());
                    item.SubItems.Add(info.EleMO.ToString());
                    item.SubItems.Add(info.EleW.ToString());
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
                    item.SubItems.Add(info.EleH.ToString());
                    item.SubItems.Add(info.EleN.ToString());
                    item.SubItems.Add(info.EleO.ToString());
                    item.SubItems.Add(info.EleAL.ToString());
                    item.SubItems.Add(info.EleSE.ToString());
                    item.SubItems.Add(info.EleRE.ToString());
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
                    lvSelectedQualityList.Items.Add(item);
                }
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, 22);
                lvSelectedQualityList.SmallImageList = imgList;
            }
        }

        private void lvSelectedSLagQuality_DataBind()
        {
            if (string.IsNullOrEmpty(lblHeatId.Text.Trim()) == false)
            {
                lvSLagQuality.Items.Clear();
                SlagQualityHorizontal slagQualityBLL = new SlagQualityHorizontal();
                IList<SlagQualityHorizontalInfo> selectedSlagQualityList = slagQualityBLL.GetSlagQualityInfo(lblHeatId.Text);
                foreach (SlagQualityHorizontalInfo info in selectedSlagQualityList)
                {
                    ListViewItem item = new ListViewItem(info.HeatId);
                    item.SubItems.Add(info.SampleTime.ToString());
                    item.SubItems.Add(info.SamplePlace);
                    item.SubItems.Add(info.SampleNumber.ToString());
                    item.SubItems.Add(info.AnalSIO2.ToString());
                    item.SubItems.Add(info.AnalCAO.ToString());
                    item.SubItems.Add(info.AnalMNO.ToString());
                    item.SubItems.Add(info.AnalMGO.ToString());
                    item.SubItems.Add(info.AnalP2O5.ToString());
                    item.SubItems.Add(info.AnalAL2O3.ToString());
                    item.SubItems.Add(info.AnalFEOX.ToString());
                    item.SubItems.Add(info.AnalFE_TOT.ToString());
                    item.SubItems.Add(info.AnalOX.ToString());
                    item.SubItems.Add(info.AnalCAF2.ToString());
                    item.SubItems.Add(info.AnalO2.ToString());
                    item.SubItems.Add(info.AnalS.ToString());
                    item.SubItems.Add(info.AnalNA2O.ToString());
                    item.SubItems.Add(info.AnalCR2O3.ToString());
                    item.SubItems.Add(info.AnalTIO2.ToString());
                    item.SubItems.Add(info.AnalK2O.ToString());
                    lvSLagQuality.Items.Add(item);
                }
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(1, 22);
                lvSLagQuality.SmallImageList = imgList;
            }
        }

        private void refreshQualityList()
        {
            lvSelectedQualityList_DataBind();
            lvSelectedSLagQuality_DataBind();
        }

        private void btnManualRefresh_Click(object sender, EventArgs e)
        {
            resetEditButton();
            this.btnManualRefresh.Enabled = false;
            refreshLFHeatList();
            this.btnManualRefresh.Enabled = true;
        }

        private void lvHeatInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetEditButton();
            if (this.lvHeatInfo.SelectedItems.Count == 1)
            {
                string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
                int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);
                LFHeatInfo lfHeatInfo = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);

                if (lfHeatInfo.SelectedFlag == false)
                {
                    this.btnHidePlan.Enabled = true;
                }

                if (lfHeatInfo.CurrentHeatStatus == "TO BE DONE" && lfHeatInfo.SelectedFlag == false)
                {
                    this.btnSelectPlan.Enabled = true;
                }

                if (lfHeatInfo.SelectedFlag && lfHeatInfo.CurrentHeatStatus == "TO BE DONE")
                {
                    this.btnCancelSelect.Enabled = true;
                }

                if (lfHeatInfo.SelectedFlag || lfHeatInfo.CurrentHeatStatus == "ON GOING")
                {
                    this.btnManualControl.Enabled = true;
                }

                if (lfHeatInfo.CurrentHeatStatus == "ON GOING")
                {
                    this.btnAddition.Enabled = true;
                }
            }
        }

        private void resetEditButton()
        {
            this.btnSelectPlan.Enabled = false;
            this.btnHidePlan.Enabled = false;
            this.btnCancelSelect.Enabled = false;
            this.btnAddition.Enabled = false;
            this.btnSwapCar.Enabled = false;
            this.btnManualControl.Enabled = false;
        }

        private void btnCancelSelect_Click(object sender, EventArgs e)
        {
            string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
            int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);

            LFHeat lfHeatBLL = new LFHeat();
            using (OracleConnection con = new OracleConnection(LFDBUSERConnectionString))
            {
                con.Open();
                OracleTransaction trans = con.BeginTransaction();
                try
                {
                    lfHeatBLL.LockCriticalArea(trans);
                    allLFHeatList = lfHeatBLL.GetLFHeatDetailInfo(trans, out onGoingLFHeatList, out doneLFHeatList, out toBeDoneLFHeatList);
                    try
                    {
                        LFHeatInfo lfHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                        string msg = "炉次号:" + heatId + ",处理次数:" + treatmentCount.ToString() +
                        "\n该炉次已经被选择，但是炉次尚未到达，你可以取消选择该炉次。" +
                        "\n你确定取消选择该炉次信息吗?";

                        if (lfHeat.CurrentHeatStatus == "TO BE DONE")
                        {
                            if (MessageBox.Show(msg, "确认取消选择", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {
                                cancelSelectHeatInfo(trans, lfHeat);
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"该炉次已经不再处于‘尚未到达’状态,不能取消选择", "提示");
                        }
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("取消选择炉次过程中出现错误:" + ex.Message, "错误提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("取消选择炉次时发生不可预知的错误:" + ex.Message + "事务将回滚!", "错误提示");
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception exTrans)
                    {
                        MessageBox.Show("事务回滚过程中出错" + exTrans.Message, "错误提示");
                        throw;
                    }
                }
            }
            refreshLFHeatList();
            resetEditButton();
        }

        private void btnSelectPlan_Click(object sender, EventArgs e)
        {
            string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
            int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);

            using (OracleConnection con = new OracleConnection(LFDBUSERConnectionString))
            {
                con.Open();
                OracleTransaction trans = con.BeginTransaction();
                try
                {
                    LFHeat lfHeatBLL = new LFHeat();
                    lfHeatBLL.LockCriticalArea(trans);
                    allLFHeatList = lfHeatBLL.GetLFHeatDetailInfo(trans, out onGoingLFHeatList, out doneLFHeatList, out toBeDoneLFHeatList);

                    SelectCarForm selectHeatForm = new SelectCarForm(heatId);
                    if (selectHeatForm.ShowDialog() == DialogResult.Yes)
                    {
                        Car car = selectHeatForm.Car;

                        if (this.allLFHeatList.Any<LFHeatInfo>(i => i.Car == car && i.SelectedFlag))
                        {
                            if (this.allLFHeatList.Where<LFHeatInfo>(i => i.Car == car && i.SelectedFlag).Count() == 1)
                            {
                                LFHeatInfo existedSelectedHeat = allLFHeatList.Single<LFHeatInfo>(i => i.Car == car && i.SelectedFlag);
                                if (existedSelectedHeat.CurrentHeatStatus == "ON GOING")
                                {
                                    string msg = "炉次号:" + existedSelectedHeat.HeatId + ",处理次数:" + existedSelectedHeat.TreatmentCount.ToString()
                                                + " 的炉次正在工位" + LFHeatInfo.IntParseCar(car) + "进行冶炼."
                                                + "\n 选择其他炉次在该工位冶炼将导致" + existedSelectedHeat.HeatId + ",处理次数:" + existedSelectedHeat.TreatmentCount.ToString() + " 的炉次处于未冶炼状态,"
                                                + "\n 原炉次的所有冶炼信息将成为新炉次的冶炼信息。"
                                                + "\n你确认要选择炉次号:" + heatId + ",处理次数:" + treatmentCount.ToString() + " 的炉次在工位" + LFHeatInfo.IntParseCar(car) + "上冶炼吗?";

                                    LFHeatInfo lfHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                                    ChooseHeatOptionForm chooseHeatOptionForm = new ChooseHeatOptionForm(lfHeat, existedSelectedHeat, car);
                                    DialogResult diaResult = chooseHeatOptionForm.ShowDialog();

                                    if (diaResult == DialogResult.Yes)
                                    {
                                        lfHeat.Car = car;
                                        lfHeat.OperatorUser = user;
                                        if (chooseHeatOptionForm.Option == ChooseOption.ReplaceExistHeat)
                                        {
                                            //1.将TB_LF_HEAT_INFO中原炉次的主键更改为新炉次的主键
                                            //2.将此炉次的SelectFlag置1

                                            //如果为未知炉次信息，将未知炉次信息从plan表中删除
                                            if (Regex.IsMatch(existedSelectedHeat.HeatId, @"\?"))
                                            {
                                                lfHeatBLL.DeleteLFHeatPlan(trans, existedSelectedHeat);
                                            }
                                            lfHeatBLL.UpdateLFHeatInfoPK(trans, existedSelectedHeat, lfHeat);
                                            lfHeatBLL.ResetLFHeatSelectFlag(trans, existedSelectedHeat);
                                            lfHeatBLL.SetLFHeatSelectFlag(trans, lfHeat);
                                        }
                                        else
                                        {
                                            if (chooseHeatOptionForm.Option == ChooseOption.EndLastAndStartNew)
                                            {
                                                lfHeatBLL.ProcessStatusSix(trans, existedSelectedHeat);
                                                selectHeatInfo(lfHeat);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string msg = "炉次号:" + existedSelectedHeat.HeatId + ",处理次数:" + existedSelectedHeat.TreatmentCount.ToString()
                                                + " 的炉次已经选择要在工位" + LFHeatInfo.IntParseCar(car).ToString() + "进行冶炼，"
                                                + "该炉次尚未到达。\n"
                                                + "你确认要选择炉次号:" + heatId + ",处理次数:" + treatmentCount.ToString() + " 的炉次在工位" + LFHeatInfo.IntParseCar(car).ToString() + "上冶炼吗?";
                                    if (MessageBox.Show(msg, "请仔细阅读并确认选择", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                    {
                                        LFHeatInfo lfHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                                        cancelSelectHeatInfo(trans, existedSelectedHeat);
                                        lfHeat.Car = car;
                                        lfHeat.OperatorUser = user;
                                        selectHeatInfo(trans, lfHeat);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("根据当前系统数据库记录,工位" + LFHeatInfo.IntParseCar(car).ToString() + "同时存在一个以上炉次被选择,系统可能发生了不可预测的错误,请与系统管理联系!", "错误提示");
                            }
                        }
                        else
                        {
                            LFHeatInfo lfHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                            lfHeat.Car = car;
                            lfHeat.OperatorUser = user;
                            selectHeatInfo(trans, lfHeat);
                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("选择炉次时发生不可预知的错误:" + ex.Message, "错误提示");
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception exTrans)
                    {
                        MessageBox.Show("事务回滚过程中出错" + exTrans.Message, "错误提示");
                        throw;
                    }
                }
                refreshLFHeatList();
                resetEditButton();
            }
        }

        /// <summary>
        /// 取消选择炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        private void cancelSelectHeatInfo(LFHeatInfo lfHeat)
        {
            LFHeat lfHeatBLL = new LFHeat();
            lfHeatBLL.CancelSelectLFHeatInfo(lfHeat);
        }

        /// <summary>
        /// 取消选择炉次信息
        /// </summary>
        /// <param name="trans">所用事务</param>
        /// <param name="lfHeat">炉次信息</param>
        private void cancelSelectHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            LFHeat lfHeatBLL = new LFHeat();
            lfHeatBLL.CancelSelectLFHeatInfo(trans, lfHeat);
        }

        /// <summary>
        /// 选择炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        private void selectHeatInfo(LFHeatInfo lfHeat)
        {
            LFHeat lfHeatBLL = new LFHeat();

            //1.将此炉次的SelectFlag置1
            //2.将此炉次在TB_LF_HEAT_INFO表中信息删除
            //3 向TB_LF_HEAT_INFO表插入该炉次的最新信息
            lfHeatBLL.SelectLFHeatInfo(lfHeat);
        }


        /// <summary>
        /// 选择炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        private void selectHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            LFHeat lfHeatBLL = new LFHeat();

            //1.将此炉次的SelectFlag置1
            //2.将此炉次在TB_LF_HEAT_INFO表中信息删除
            //3 向TB_LF_HEAT_INFO表插入该炉次的最新信息
            lfHeatBLL.SelectLFHeatInfo(trans, lfHeat);
        }

        private void btnHidePlan_Click(object sender, EventArgs e)
        {
            string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
            int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);
            string msg = @"炉次号:" + heatId + ",处理次数:" + treatmentCount.ToString() +
                        ",该炉次未被选择，你可以隐藏该炉次.\n" +
                        "隐藏炉次信息后，炉次信息将不会显示在列表中.\n" +
                        "你可以通过点击'查看所有计划'按钮，重新设置炉次信息显示\n" +
                        "你确定隐藏该炉次信息吗?";
            if (MessageBox.Show(msg, "确认取消选择", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                LFHeatInfo lfHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                LFHeat lfHeatBLL = new LFHeat();
                lfHeatBLL.ResetLFHeatVisible(lfHeat);
                refreshLFHeatList();
                resetEditButton();
            }
        }

        private void btnSwapCar_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(LFDBUSERConnectionString))
            {
                con.Open();
                OracleTransaction trans = con.BeginTransaction();
                try
                {
                    LFHeat lfHeatBLL = new LFHeat();
                    lfHeatBLL.LockCriticalArea(trans);
                    allLFHeatList = lfHeatBLL.GetLFHeatDetailInfo(trans, out onGoingLFHeatList, out doneLFHeatList, out toBeDoneLFHeatList);

                    if (allLFHeatList.Where<LFHeatInfo>(i => i.Car == Car.One && i.CurrentHeatStatus == "ON GOING").Count() == 1)
                    {
                        if (allLFHeatList.Where<LFHeatInfo>(i => i.Car == Car.Two && i.CurrentHeatStatus == "ON GOING").Count() == 1)
                        {
                            if (MessageBox.Show("你确定要更换两个工位上的炉次信息吗?", "确认调换工位", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                            {
                                lfHeatBLL.SwapCar(trans);
                            }
                        }
                        else
                        {
                            MessageBox.Show("根据当前系统数据库记录,工位2同时存在一个以上炉次在运行或没有正在运行的炉次。\n系统可能发生了不可预测的错误,请与系统管理联系!", "错误提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("根据当前系统数据库记录,工位1同时存在一个以上炉次在运行或没有正在运行的炉次。\n系统可能发生了不可预测的错误,请与系统管理联系!", "错误提示");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("交换工位时发生不可预知的错误:" + ex.Message, "错误提示");
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception exTrans)
                    {
                        MessageBox.Show("事务回滚过程中出错" + exTrans.Message, "错误提示");
                        throw;
                    }
                }
                refreshLFHeatList();
                resetEditButton();
            }
        }

        private void btnShowAllPlan_Click(object sender, EventArgs e)
        {
            AllLFHeatPlanForm allLFHeatPlanForm = new AllLFHeatPlanForm();
            allLFHeatPlanForm.ShowDialog();
        }

        private void bgWorkerRefreshStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            checkCommStatus();
        }

        private void bgWorkerRefreshStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripStatusLabelTime.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            bgWorkerRefreshStatus.RunWorkerAsync();
        }

        private void timerRefreshStatus_Tick(object sender, EventArgs e)
        {
            if (!bgWorkerRefreshStatus.IsBusy)
            {
                bgWorkerRefreshStatus.RunWorkerAsync();
            }
        }

        private void lvHeatInfo_ItemActivate(object sender, EventArgs e)
        {
            if (this.lvHeatInfo.SelectedItems.Count == 1)
            {
                string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
                int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);
                LFHeatInfo activatedLFHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
                //this.lblPlanId.Text = activatedLFHeat.PlanId.ToString();
                this.lblHeatId.Text = activatedLFHeat.HeatId;
                this.lblTreatmentCount.Text = activatedLFHeat.TreatmentCount.ToString();
                this.lblCar.Text = activatedLFHeat.IntParseCar().ToString();
                this.lblLadleId.Text = activatedLFHeat.Ladle.LadleId;
                this.lblSteelGradeId.Text = activatedLFHeat.SteelGrade.SteelGradeId;
                this.lblLadleAge.Text = activatedLFHeat.Ladle.LadleAge.ToString();
                this.lblStuffCod.Text = activatedLFHeat.SteelGrade.StaffCod;
                lvSelectedQualityList_DataBind();
                lvSelectedSLagQuality_DataBind();
            }
        }

        private void bgWorkerRefreshWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CCMHeat ccmHeatBLL = new CCMHeat();
            CCMHeatInfo ccmHeatInfo = ccmHeatBLL.GetCCMHeatInfo();
            e.Result = ccmHeatInfo;
        }

        private void bgWorkerRefreshWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CCMHeatInfo ccmHeat = (CCMHeatInfo)e.Result;
            showCCMHeatInfo(ccmHeat);
            cmbCCMRecentTundishTemp_DataBind();
        }

        private void timerRefreshCCMInfo_Tick(object sender, EventArgs e)
        {
            if (!bgWorkerRefreshCCMInfo.IsBusy)
            {
                bgWorkerRefreshCCMInfo.RunWorkerAsync();
            }
        }

        private void stopMainControlTimers()
        {
            this.timerRefreshCCMInfo.Enabled = false;
        }

        private void cmbCCMRecentTundishTemp_DataBind()
        {
            CCMHeat ccmHeatBLL = new CCMHeat();
            IList<CCMHeatInfo> ccmHeatInfoList = ccmHeatBLL.GetCCMTempInfo();
            cmbCCMRecentTundishTemp.Items.Clear();
            foreach (CCMHeatInfo item in ccmHeatInfoList)
            {
                cmbCCMRecentTundishTemp.Items.Add(item.MsgTimeStamp.TimeOfDay.ToString() + "测温:" + item.TundishTemperature.ToString());
            }
            cmbCCMRecentTundishTemp.Text = cmbCCMRecentTundishTemp.Items[0].ToString();
        }

        private void showCCMHeatInfo(CCMHeatInfo ccmHeat)
        {
            this.lblCCMMsgTimeStamp.Text = ccmHeat.MsgTimeStamp.ToString();
            this.lblCCMHeatId.Text = ccmHeat.HeatId;
            this.lblCCMID.Text = ccmHeat.CCMId;
            this.lblCCMSteelGradeId.Text = ccmHeat.SteelGradeId;
            this.lblCCMHeatStatus.Text = ccmHeat.HeatStatus;
            this.lblCCMCastNumber.Text = ccmHeat.CastNumber;
            this.lblCCMSequenceInCast.Text = ccmHeat.SequenceInCast.ToString();
            this.lblCCMCastTotalTime.Text = ccmHeat.CastTotalTime.ToString();
            this.lblCCMCastRemainTime.Text = ccmHeat.CastRemainTime.ToString();
            this.lblCCMHeatStatusTime.Text = ccmHeat.StatusTimeStamp.ToString(); ;
            this.lblCCMCastSpeed.Text = ccmHeat.CastingSpeed.ToString();
            this.lblCCMLastTempTime.Text = ccmHeat.LastTemperatureDate.ToString();
            this.lblCCMArConsumption.Text = ccmHeat.ArConsumped.ToString();
            this.lblCCMSteelWeightLadle.Text = ccmHeat.SteelWeightLadle.ToString();
            this.lblCCMStartArTime.Text = ccmHeat.StartArTime.ToString();
            this.lblCCMEndArTime.Text = ccmHeat.EndArTime.ToString();
            this.lblCCMSlabWidth.Text = ccmHeat.SlabWidth.ToString();
            this.lblCCMLastTemperature.Text = ccmHeat.TundishTemperature.ToString();
            this.lblCCMTotalLength.Text = ccmHeat.TotalLength.ToString();
            this.lblCCMSteelWeightTundish.Text = ccmHeat.SteelWeightTundish.ToString();
        }

        private void timerRefreshBOFRHHeatStatus_Tick(object sender, EventArgs e)
        {
            if (!bgWorkerRefreshBOFRHHeatStatus.IsBusy)
            {
                bgWorkerRefreshBOFRHHeatStatus.RunWorkerAsync();
            }
        }

        private void bgWorkerRefreshBOFHeatStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            BOFHeatStatus bofHeatStatusBLL = new BOFHeatStatus();
            RHHeatStatus rhHeatStatusBLL = new RHHeatStatus();
            IList<BOFHeatStatusInfo> currentBOFHeatStatus = bofHeatStatusBLL.GetBOFCurrentHeatStatus();
            IList<RHHeatStatusInfo> currentRHHeatStatus = rhHeatStatusBLL.GetCurrentRHHeatStatusInfo();
            lvBOFHeatStatus_DataBind(currentBOFHeatStatus);
            lvRHCurrentHeatStatus_DataBind(currentRHHeatStatus);
        }

        private void lvBOFHeatStatus_DataBind(IList<BOFHeatStatusInfo> bofHeatStatusList)
        {
            this.lvBOFCurrentHeatStatus.Items.Clear();
            foreach (BOFHeatStatusInfo item in bofHeatStatusList)
            {
                ListViewItem lvItem = new ListViewItem(item.StationId.ToString());
                lvItem.SubItems.Add(item.StatusTimeStamp.ToString());
                lvItem.SubItems.Add(item.PlanId.ToString());
                lvItem.SubItems.Add(item.HeatId);
                lvItem.SubItems.Add(item.SteelGradeId);
                lvItem.SubItems.Add(item.HeatStatus);
                this.lvBOFCurrentHeatStatus.Items.Add(lvItem);
            }
        }

        private void lvRHCurrentHeatStatus_DataBind(IList<RHHeatStatusInfo> rhHeatStatusList)
        {
            lvRHCurrentHeatStatus.Items.Clear();
            foreach (RHHeatStatusInfo info in rhHeatStatusList)
            {
                ListViewItem item = new ListViewItem(info.StationId.ToString());
                item.SubItems.Add(info.StatusTimeStamp.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(info.HeatId);
                item.SubItems.Add("");
                item.SubItems.Add(info.HeatStatus);
                lvRHCurrentHeatStatus.Items.Add(item);
            }
        }

        private void tabControlPaceData_Selected(object sender, TabControlEventArgs e)
        {
            this.timerRefreshBOFRHHeatStatus.Enabled = false;
            this.timerRefreshCCMInfo.Enabled = false;
            this.timerRefreshQualityList.Enabled = false;
            if (e.TabPage.Text == "CCM信息")
            {
                timerRefreshCCMInfo.Enabled = true;
            }
            else if (e.TabPage.Text == "BOF/RH节奏信息")
            {
                timerRefreshBOFRHHeatStatus.Enabled = true;
            }
            else if (e.TabPage.Text == "合金化验信息")
            {
                timerRefreshQualityList.Enabled = true;
            }
            else if (e.TabPage.Text == "渣化验信息")
            {
                timerRefreshQualityList.Enabled = true;
            }
        }

        private void btnLFHeatSteelDetailInfo_Click(object sender, EventArgs e)
        {
            showPanelLFHeatSteelGradeDetailInfo();
        }

        private void showPanelLFHeatSteelGradeDetailInfo()
        {
            setAllLFContentPanelUnvisible();
            setAllControlButtonEnabled();
            this.btnLFHeatSteelDetailInfo.Enabled = false;
            this.panelSteelGradeDetailInfo.Visible = true;
            this.panelSteelGradeDetailInfo.BringToFront();
            SteelGradeDetailInfo steelInfo = null;
            steelInfo = getSteelGradeDetailInfo();
            if (steelInfo != null)
            {
                showSteelBasicData(steelInfo);
            }
        }

        private SteelGradeDetailInfo getSteelGradeDetailInfo()
        {
            if (!string.IsNullOrEmpty(this.lblHeatId.Text.Trim()) && !string.IsNullOrEmpty(this.lblTreatmentCount.Text.Trim()))
            {
                string heatId = this.lblHeatId.Text.Trim();
                int treatmentCount = Convert.ToInt16(this.lblTreatmentCount.Text.Trim());
                string steelGradeId = this.lblSteelGradeId.Text.Trim();
                LFHeatInfo activatedLFHeatInfo = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);

                SteelGradeDetails steelGradeDetailBLL = new SteelGradeDetails();
                SteelAnalysis steelAnalysisBLL = new SteelAnalysis();

                if (!string.IsNullOrEmpty(this.lblSteelGradeId.Text.Trim()))
                {
                    activatedLFHeatInfo.SteelGrade = steelGradeDetailBLL.GetSteelGradeInfoBySteelGradeId(steelGradeId);
                }

                if (activatedLFHeatInfo.SteelGrade != null)
                {
                    if (!Regex.IsMatch(heatId, @"\?"))
                    {
                        activatedLFHeatInfo.SteelGrade.SteelAnalysisList = steelAnalysisBLL.GetSteelAnalysisByHeatId(heatId);
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(activatedLFHeatInfo.SteelGrade.SteelGradeId))
                        {
                            activatedLFHeatInfo.SteelGrade.SteelAnalysisList = steelAnalysisBLL.GetSteelAnalysisBySteelGradeId(activatedLFHeatInfo.SteelGrade.SteelGradeId);
                        }
                    }

                    if (activatedLFHeatInfo.SteelGrade.SteelAnalysisList != null && activatedLFHeatInfo.SteelGrade.SteelAnalysisList.Count == 0)
                    {
                        activatedLFHeatInfo.SteelGrade.SteelAnalysisList = steelAnalysisBLL.GetSteelAnalysisBySteelGradeId(activatedLFHeatInfo.SteelGrade.SteelGradeId);
                    }
                }
                return activatedLFHeatInfo.SteelGrade;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// lvSteelFormulaInfos钢种公式信息数据绑定
        /// </summary>
        /// <param name="formulaInfos"></param>
        private void lvSteelFormulaInfo_DataBind(IList<FormulaInfo> formulaInfos)
        {
            lvSteelFormulaInfo.Items.Clear();
            foreach (FormulaInfo info in formulaInfos)
            {
                ListViewItem item = new ListViewItem(info.FormulaId);
                item.SubItems.Add(info.FormulaType);
                item.SubItems.Add(info.Formula);
                lvSteelFormulaInfo.Items.Add(item);
            }
        }
        /// <summary>
        /// lvProcessRoute工艺步骤数据绑定
        /// </summary>
        /// <param name="technicStepInfos">工艺步骤信息</param>
        private void lvProcessRoute_DataBind(IList<TechnicStepInfo> technicStepInfos)
        {
            lvProcessRoute.Items.Clear();
            foreach (TechnicStepInfo technicStepInfo in technicStepInfos)
            {
                ListViewItem item = new ListViewItem(technicStepInfo.Steps.StepName);
                item.SubItems.Add(technicStepInfo.PlanDuration.ToString());
                item.SubItems.Add(technicStepInfo.PlanPowerDuration.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TapPosition.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TapPositionPoint.ToString());
                item.SubItems.Add(technicStepInfo.PlanTopArConsumption.ToString());
                item.SubItems.Add(technicStepInfo.PlanBottomArConsumption.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Voltage.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Current.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.TempPerMin.ToString());
                item.SubItems.Add(technicStepInfo.TransFormerParams.Power.ToString());
                lvProcessRoute.Items.Add(item);
            }
        }
        /// <summary>
        /// dgvSteelAnalysis钢种化学分析数据绑定
        /// </summary>
        /// <param name="steelAnalysisInfos">钢种化学分析信息</param>
        private void dgvSteelAnalysis_DataBind(IList<SteelAnalysisInfo> steelAnalysisInfos)
        {
            dgvSteelAnalysis.Rows.Clear();
            if (steelAnalysisInfos != null)
            {
                foreach (SteelAnalysisInfo steelAnalysisInfo in steelAnalysisInfos)
                {
                    object[] row = new object[] { steelAnalysisInfo.ElemInfo.ElementId, steelAnalysisInfo.ElemInfo.ElementShortName, steelAnalysisInfo.MinValue.ToString(), steelAnalysisInfo.AimValue.ToString(), steelAnalysisInfo.MaxValue.ToString() };
                    dgvSteelAnalysis.Rows.Add(row);
                }
            }

        }

        /// <summary>
        /// 该方法用于清空该界面数据
        /// </summary>
        private void clearControls()
        {
            txtSteelGradeId.Text = "";
            txtSteelGradeName.Text = "";
            txtSteelGradeGroupId.Text = "";
            txtSteelGradeGroupName.Text = "";
            txtSteelGradeDesc.Text = "";
            txtHeatingCount.Text = "";
            txtLiquidTemp.Text = "";
            txtSlagModel.Text = "";
            txtArgonModel.Text = "";
            txtTiFeAftMainHeating.Text = "";
            txtMaxHeatingDuraPerHeat.Text = "";
            txtMinArDuraAftFeedWire.Text = "";
            txtMinArDuraBefFeedWire.Text = "";
            txtRoute.Text = "";
            txtWireFeedWgt.Text = "";
            cmbTechnicId.Text = "";
            lvSteelFormulaInfo.Items.Clear();
            lvProcessRoute.Items.Clear();
            dgvSteelAnalysis.Rows.Clear();
        }

        /// <summary>
        /// 显示钢种的基本信息
        /// </summary>
        /// <param name="steelGradeDetailsInfo">要显示的钢种基本信息</param>
        private void showSteelBasicData(SteelGradeDetailInfo steelGradeDetailsInfo)
        {
            txtSteelGradeId.Text = steelGradeDetailsInfo.SteelGradeId;
            txtSteelGradeName.Text = steelGradeDetailsInfo.SteelGradeName;
            txtSteelGradeGroupId.Text = steelGradeDetailsInfo.SteelGradeGroupCode;
            txtSteelGradeGroupName.Text = steelGradeDetailsInfo.SteelGradeGroupName;
            txtSteelGradeDesc.Text = steelGradeDetailsInfo.SteelGradeDescr;
            txtLiquidTemp.Text = steelGradeDetailsInfo.LiquidTemp.ToString();
            txtHeatingCount.Text = steelGradeDetailsInfo.HeatingCount.ToString();
            txtSlagModel.Text = steelGradeDetailsInfo.SlagModel;
            txtArgonModel.Text = steelGradeDetailsInfo.ArgonModel;
            txtMinArDuraBefFeedWire.Text = steelGradeDetailsInfo.ArDuraBefFeedWire.ToString();
            txtMinArDuraAftFeedWire.Text = steelGradeDetailsInfo.ArDuraAftFeedWire.ToString();
            txtTiFeAftMainHeating.Text = steelGradeDetailsInfo.FeTiAftHeating.ToString();
            txtMaxHeatingDuraPerHeat.Text = steelGradeDetailsInfo.MaxDuraEachHeating.ToString();
            txtWireFeedWgt.Text = steelGradeDetailsInfo.WireWgtAftHeating.ToString();
            txtRoute.Text = steelGradeDetailsInfo.RouteDesc;

            cmbTechnicId.Text = steelGradeDetailsInfo.TechnicsInfo == null ? "" : steelGradeDetailsInfo.TechnicsInfo.TechnicId.ToString();
            txtTechnicName.Text = steelGradeDetailsInfo.TechnicsInfo == null ? "" : steelGradeDetailsInfo.TechnicsInfo.TechnicName;
            //---------------------------------------------------------------
            dgvSteelAnalysis_DataBind(steelGradeDetailsInfo.SteelAnalysisList);
            lvSteelFormulaInfo_DataBind(steelGradeDetailsInfo.FormulaInfos);
            if (steelGradeDetailsInfo.TechnicsInfo != null && steelGradeDetailsInfo.TechnicsInfo.TechnicStepInfo != null)
            {
                lvProcessRoute_DataBind(steelGradeDetailsInfo.TechnicsInfo.TechnicStepInfo);
            }

        }

        private void btnMainControl_Click(object sender, EventArgs e)
        {
            showPanelMainControl();
        }

        private void showPanelMainControl()
        {
            if (this.btnMainControl.Enabled)
            {
                setAllLFContentPanelUnvisible();
                setAllControlButtonEnabled();
                resetEditButton();
                this.btnMainControl.Enabled = false;
                this.panelMainControl.Visible = true;
                this.panelMainControl.BringToFront();
            }
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
            int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);
            LFHeatInfo lfHeatInfo = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);
            AdditionForm additionForm = new AdditionForm(lfHeatInfo);
            DialogResult result = additionForm.ShowDialog();
        }

        protected void resetQualityInfo()
        {
            dgvLFHeatQuailtyDetailInfo.Rows.Clear();
            dgvLFHeatQuailtyDetailInfo.Columns.Clear();
            initializeQualityInfo();
        }

        private void initializeQualityInfo()
        {
            this.dgvLFHeatQuailtyDetailInfo.AllowUserToAddRows = false;
            this.dgvLFHeatQuailtyDetailInfo.AllowUserToDeleteRows = false;
            this.dgvLFHeatQuailtyDetailInfo.ColumnHeadersHeight = 50;
            this.dgvLFHeatQuailtyDetailInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMinValue,
            this.colAimValue,
            this.colMaxValue});
            this.dgvLFHeatQuailtyDetailInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLFHeatQuailtyDetailInfo.Location = new System.Drawing.Point(3, 22);
            this.dgvLFHeatQuailtyDetailInfo.Name = "dgvLFHeatQuailtyDetailInfo";
            this.dgvLFHeatQuailtyDetailInfo.ReadOnly = true;
            this.dgvLFHeatQuailtyDetailInfo.RowHeadersWidth = 70;
            this.dgvLFHeatQuailtyDetailInfo.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLFHeatQuailtyDetailInfo.RowTemplate.Height = 23;
            this.dgvLFHeatQuailtyDetailInfo.Size = new System.Drawing.Size(596, 512);
            this.dgvLFHeatQuailtyDetailInfo.TabIndex = 0;
        }

        private void btnQualityInfo_Click(object sender, EventArgs e)
        {
            showPanelHeatQualityInfo();
        }

        private void showPanelHeatQualityInfo()
        {
            setAllLFContentPanelUnvisible();
            setAllControlButtonEnabled();
            this.btnQualityInfo.Enabled = false;

            this.panelQualityInfo.Visible = true;
            this.panelQualityInfo.BringToFront();


            if (!string.IsNullOrEmpty(this.lblHeatId.Text.Trim()) && !Regex.IsMatch(this.lblHeatId.Text.Trim(), @"\?"))
            {

                SteelGradeDetailInfo steelInfo = null;
                steelInfo = getSteelGradeDetailInfo();
                HeatQuality heatQualityBLL = new HeatQuality();
                resetQualityInfo();

                string heatId = this.lblHeatId.Text.Trim();

                FormulaCalculator fc = new FormulaCalculator();

                MSScriptControl.ScriptControl sc = new ScriptControl();
                sc.Language = "JScript";

                Formula formulaBLL = new Formula();
                IList<FormulaInfo> formulaList = formulaBLL.GetFormulaListByHeatId(heatId);
                if (formulaList.Count != 0)
                {
                    steelInfo.FormulaInfos = formulaList;
                }

                IList<HeatQualityInfo> heatQualityList = heatQualityBLL.GetHeatQualityInfo(heatId);
                int i = 0;
                dgvLFHeatQuailtyDetailInfo.Rows.Add();
                dgvLFHeatQuailtyDetailInfo.Rows[i].HeaderCell.Value = "取样地点";
                dgvLFHeatQuailtyDetailInfo.Rows[i++].Height = 40;
                dgvLFHeatQuailtyDetailInfo.Rows.Add();
                dgvLFHeatQuailtyDetailInfo.Rows[i].HeaderCell.Value = "取样次数";
                dgvLFHeatQuailtyDetailInfo.Rows[i++].Height = 40;

                //绑定钢分析信息
                foreach (SteelAnalysisInfo item in steelInfo.SteelAnalysisList)
                {
                    dgvLFHeatQuailtyDetailInfo.Rows.Add(item.MinValue, item.AimValue, item.MaxValue);
                    dgvLFHeatQuailtyDetailInfo.Rows[i++].HeaderCell.Value = item.ElemInfo.ElementFullName;
                }

                //化验信息的起始列号
                int colNum = 3;


                //遍历每次化验信息
                foreach (HeatQualityInfo heatQuality in heatQualityList.OrderByDescending<HeatQualityInfo, DateTime>(j => j.SampleTime))
                {
                    dgvLFHeatQuailtyDetailInfo.Columns.Add(heatQuality.SampleTime.ToString(), heatQuality.SampleTime.ToString());
                    dgvLFHeatQuailtyDetailInfo.Columns[colNum].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dgvLFHeatQuailtyDetailInfo.Rows[0].Cells[colNum].Value = heatQuality.SamplePlace;
                    dgvLFHeatQuailtyDetailInfo.Rows[1].Cells[colNum].Value = heatQuality.SampleNumber;

                    //对于本次化验信息，遍历所有有要求的元素
                    for (int j = 2; j < dgvLFHeatQuailtyDetailInfo.Rows.Count; j++)
                    {
                        if (dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[0].Value == null || string.IsNullOrEmpty(dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[0].Value.ToString()))
                        {
                            continue;
                        }
                        else
                        {
                            double minValue = Convert.ToDouble(dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[0].Value);
                            double maxValue = Convert.ToDouble(dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[2].Value);

                            string elemFullName = dgvLFHeatQuailtyDetailInfo.Rows[j].HeaderCell.Value.ToString();

                            QualityInfo tmpQuaitliy = heatQuality.QualityList.Where<QualityInfo>(k => k.Element.ElementFullName == elemFullName).First();

                            if (tmpQuaitliy.Element.ElementType == "ELEMENT" || tmpQuaitliy.Element.ElementType == "COMPOUND")
                            {
                                double? qualityValue = tmpQuaitliy.QualityValue;
                                if (qualityValue.HasValue)
                                {
                                    if (qualityValue < minValue)
                                    {
                                        dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.PowderBlue;
                                    }
                                    else
                                    {
                                        if (qualityValue > maxValue)
                                        {
                                            dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.Pink;
                                        }
                                    }
                                    dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Value = qualityValue;
                                }
                            }
                            else
                            {

                                if (tmpQuaitliy.Element.ElementType == "FORMULA")
                                {
                                    string digitalFormulaString = fc.FormulaParse(heatQuality.QualityList, elemFullName);
                                    try
                                    {
                                        double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                        if (result < minValue)
                                        {
                                            dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.PowderBlue;
                                        }
                                        else
                                        {
                                            if (result > maxValue)
                                            {
                                                dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.Pink;
                                            }
                                        }
                                        dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Value = result;
                                    }
                                    catch { }
                                }
                                else
                                {
                                    //计算CEQ
                                    try
                                    {
                                        FormulaInfo formula = steelInfo.FormulaInfos.Single<FormulaInfo>(k => k.FormulaType.ToUpper() == elemFullName);
                                        string digitalFormulaString = fc.FormulaParse(heatQuality.QualityList, formula.Formula);

                                        double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                        if (result < minValue)
                                        {
                                            dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.PowderBlue;
                                        }
                                        else
                                        {
                                            if (result > maxValue)
                                            {
                                                dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Style.BackColor = Color.Pink;
                                            }
                                        }
                                        dgvLFHeatQuailtyDetailInfo.Rows[j].Cells[colNum].Value = Math.Round(result, 5);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                    colNum++;
                }
            }
        }

        private void btnManualControl_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(LFDBUSERConnectionString))
            {
                con.Open();
                OracleTransaction trans = con.BeginTransaction();
                try
                {
                    LFHeat lfHeatBLL = new LFHeat();
                    lfHeatBLL.LockCriticalArea(trans);
                    allLFHeatList = lfHeatBLL.GetLFHeatDetailInfo(trans, out onGoingLFHeatList, out doneLFHeatList, out toBeDoneLFHeatList);

                    string heatId = this.lvHeatInfo.SelectedItems[0].SubItems[1].Text;
                    int treatmentCount = Convert.ToInt16(this.lvHeatInfo.SelectedItems[0].SubItems[2].Text);

                    LFHeatInfo selectedLFHeat = allLFHeatList.Single<LFHeatInfo>(i => i.HeatId == heatId && i.TreatmentCount == treatmentCount);

                    ManualControlForm manualControlForm = new ManualControlForm();
                    DialogResult result = manualControlForm.ShowDialog();
                    if (DialogResult.Yes == result)
                    {
                        ManualSignal manualSignal = manualControlForm.ManualSignal;
                        lfHeatBLL.ProcessStatus(trans, selectedLFHeat, manualSignal);
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生不可预知的错误:" + ex.Message, "错误提示");
                    try
                    {
                        trans.Rollback();
                    }
                    catch (Exception exTrans)
                    {
                        MessageBox.Show("事务回滚过程中出错" + exTrans.Message, "错误提示");
                        throw;
                    }
                }
            }
            refreshLFHeatList();
            resetEditButton();
        }

        private void timerRefreshMainControl_Tick(object sender, EventArgs e)
        {

        }

        private void btnNewPlan_Click(object sender, EventArgs e)
        {
            NewLFHeatPlanForm newLFHeatPlanForm = new NewLFHeatPlanForm();
            DialogResult result = newLFHeatPlanForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                refreshLFHeatList();
            }

        }

        private void ckbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbAutoRefresh.Checked)
            {
                this.timerRefreshLFHeatList.Enabled = true;
            }
            else
            {
                this.timerRefreshLFHeatList.Enabled = false;
            }
        }

        private void timerRefreshLFHeatList_Tick(object sender, EventArgs e)
        {
            if (!bgWorkerRefreshLFHeatList.IsBusy)
            {
                bgWorkerRefreshLFHeatList.RunWorkerAsync();
            }
        }

        private void bgWorkerRefreshLFHeatList_DoWork(object sender, DoWorkEventArgs e)
        {
            btnManualRefresh_Click(null, null);
        }

        private void timerRefreshQualityList_Tick(object sender, EventArgs e)
        {
            if (!bgWorkerRefreshQualityList.IsBusy)
            {
                bgWorkerRefreshQualityList.RunWorkerAsync();
            }
        }

        private void bgWorkerRefreshQualityList_DoWork(object sender, DoWorkEventArgs e)
        {
            refreshQualityList();
        }

        private void lvAddition_DataBind(IList<AdditionRecordInfo> addMatList)
        {
            lvLFAdditionEach.Items.Clear();
            foreach (AdditionRecordInfo info in addMatList)
            {
                ListViewItem item = new ListViewItem(info.AdditionTime.ToString());
                item.SubItems.Add(info.AdditionType);
                item.SubItems.Add(info.SiloId.ToString());
                item.SubItems.Add(info.MaterialName);
                item.SubItems.Add(info.AdditionAmount.ToString());
                lvLFAdditionEach.Items.Add(item);
            }
            lvLFAdditionSum.Items.Clear();
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
                lvLFAdditionSum.Items.Add(item);
            }
        }

        private void lvHeatStatus_DataBind(IList<LFHeatStatusInfo> lfHeatStatusInfos)
        {
            lvLFHeatStatus.Items.Clear();
            foreach (LFHeatStatusInfo info in lfHeatStatusInfos)
            {
                ListViewItem item = new ListViewItem(info.StatusTimeStamp.ToString());
                item.SubItems.Add(info.HeatStatus.StatusName);
                item.SubItems.Add(info.StausTemperature.ToString());
                item.SubItems.Add(info.SteelWeight.ToString());
                lvLFHeatStatus.Items.Add(item);
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
            lvLFPowerRecord.Items.Clear();
            foreach (PowerOnRecordInfo info in powerOnInfos)
            {
                ListViewItem item = new ListViewItem(info.StartPowerOnTime.ToString());
                item.SubItems.Add(info.EndPowerOnTime.ToString());
                item.SubItems.Add((info.EndPowerOnTime - info.StartPowerOnTime).ToString());
                item.SubItems.Add(info.PowerConsumption.ToString());
                lvLFPowerRecord.Items.Add(item);
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
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 20);
            lvQuality.SmallImageList = imgList;
        }

        private void showHeatDetailInfos(LFHeatInfo heatInfo)
        {
            txtArrivalTime.Text = heatInfo.ArrivalTime == null ? null : heatInfo.ArrivalTime.ToString();
            txtDepartTime.Text = heatInfo.DepartTime == null ? null : heatInfo.DepartTime.ToString();
            txtArrivalTemperature.Text = heatInfo.ArrivalTemperature == null ? null : heatInfo.ArrivalTemperature.TemperatureData.ToString();
            txtDepartTemperature.Text = heatInfo.DepartTemperature == null ? null : heatInfo.DepartTemperature.TemperatureData.ToString();
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

        private void btnLFDetailHeatInfo_Click(object sender, EventArgs e)
        {
            showPanelLFHeatDetailInfo();
        }

        private void btnBOFRHHeatInfo_Click(object sender, EventArgs e)
        {
            showPanelBOFRHCCMHeatInfo();
        }

        private void showPanelBOFRHCCMHeatInfo()
        {
            setAllLFContentPanelUnvisible();
            setAllControlButtonEnabled();
            this.btnBOFRHHeatInfo.Enabled = false;

            this.panelBOFRHHeatDetail.Visible = true;
            this.panelBOFRHHeatDetail.BringToFront();

            string heatId = this.lblHeatId.Text;
            clearBOFHeatAllInfo();
            clearRHHeatAllInfo();
            clearCCMHeatAllInfo();

            if (!string.IsNullOrEmpty(heatId) && !Regex.IsMatch(heatId, @"\?"))
            {
                BOFHeat bofHeatBLL = new BOFHeat();
                BOFHeatInfo bofHeat = bofHeatBLL.GetBOFHeatInfo(heatId);
                BOFHeatStatus bofHeatStatusBLL = new BOFHeatStatus();
                IList<BOFHeatStatusInfo> bofHeatStatusList = bofHeatStatusBLL.GetBOFHeatStatusList(heatId);
                BOFAddition bofAdditionBLL = new BOFAddition();
                IList<BOFAdditionInfo> bofAdditionList = bofAdditionBLL.GetBOFAdditionRecord(heatId);
                IList<BOFAdditionInfo> bofAdditionStatistic = bofAdditionBLL.GetBOFAdditionStatistic(heatId);

                CCMHeatReport ccmHeatReportBLL = new CCMHeatReport();
                CCMHeatReportInfo ccmHeatReport = ccmHeatReportBLL.GetCCMHeatReport(heatId);

                CCMHeatStatus ccmHeatStatusBLL = new CCMHeatStatus();
                IList<CCMHeatStatusInfo> ccmHeatStatusList = ccmHeatStatusBLL.GetCCMHeatStatus(heatId);

                CCMSlabReport ccmSlabReportBLL = new CCMSlabReport();
                IList<CCMSlabReportInfo> ccmSlabReportList = ccmSlabReportBLL.GetCCMSlabReport(heatId);

                RHHeatStatus rhHeatStatusBLL = new RHHeatStatus();
                IList<RHHeatStatusInfo> rhHeatStatusList = rhHeatStatusBLL.GetRHHeatStatusInfo(heatId);

                showBOFHeatInfo(bofHeat);
                showBOFHeatStatusList(bofHeatStatusList);
                showBOFAdditionRecord(bofAdditionList);
                showBOFAdditionStatistic(bofAdditionStatistic);

                showRHHeatStatusList(rhHeatStatusList);

                showCCMHeatReport(ccmHeatReport);
                showCCMHeatStatus(ccmHeatStatusList);
                showCCMSlabReport(ccmSlabReportList);

            }
        }

        private void showRHHeatStatusList(IList<RHHeatStatusInfo> rhHeatStatusInfos)
        {
            foreach (RHHeatStatusInfo info in rhHeatStatusInfos)
            {
                ListViewItem item = new ListViewItem(info.StatusTimeStamp.ToString());
                item.SubItems.Add(info.HeatStatus);
                lvRHHeatStatusList.Items.Add(item);
            }
        }

        private void showCCMHeatReport(CCMHeatReportInfo ccmHeatReport)
        {
            if (ccmHeatReport != null)
            {
                this.lblCCMDetailArFlowSealing.Text = ccmHeatReport.ArFlowSealing.ToString();
                this.lblCCMDetailArFlowShroud.Text = ccmHeatReport.ArFlowShroud.ToString();
                this.lblCCMDetailArFlowUpnozzle.Text = ccmHeatReport.ArFlowUpnozzle.ToString();
                this.lblCCMDetailArFlowStopper.Text = ccmHeatReport.ArFlowStopper.ToString();
                this.lblCCMDetailArrivalTemp.Text = ccmHeatReport.LadleTempStart.ToString();
                this.lblCCMDetailCastEndLength.Text = ccmHeatReport.CastEndLength.ToString();
                this.lblCCMDetailCastNo.Text = ccmHeatReport.CastNo;
                this.lblCCMDetailCastStartLength.Text = ccmHeatReport.CastStartLength.ToString();
                this.lblCCMDetailCastTotalLength.Text = ccmHeatReport.CastTotalLength.ToString();
                this.lblCCMDetailCastWeight.Text = ccmHeatReport.CastWeight.ToString();
                this.lblCCMDetailLadleArrivalWeight.Text = ccmHeatReport.LadleArrivalWeight.ToString();
                this.lblCCMDetailLadleDepartWeight.Text = ccmHeatReport.LadleDepartWeight.ToString();
                this.lblCCMDetailMoldAlarmPosition.Text = ccmHeatReport.AlarmPosition;
                this.lblCCMDetailMoldAlarmTime.Text = ccmHeatReport.AlarmTime.Value.ToString("yy/MM/dd HH:mm");
                this.lblCCMDetailMoldFriction.Text = ccmHeatReport.MoldFriction.ToString();
                this.lblCCMDetailMoldLevelMax.Text = ccmHeatReport.MoldLevelMax.ToString();
                this.lblCCMDetailMoldLevelMin.Text = ccmHeatReport.MoldLevelMin.ToString();
                this.lblCCMDetailMoldSetLevel.Text = ccmHeatReport.MoldSetLevel.ToString();
                this.lblCCMDetailSequenceInCast.Text = ccmHeatReport.SequenceInCast.ToString();
                this.lblCCMDetailSlabTotalLength.Text = ccmHeatReport.SlabTotalLength.ToString();
                this.lblCCMDetailSteelNetWeight.Text = ccmHeatReport.PouredWeight.ToString();
                this.lblCCMDetailTundishMinWeight.Text = ccmHeatReport.TundishMinWeight.ToString();
                this.lblCCMDetailFluidTemp.Text = ccmHeatReport.FluidTemperature.ToString();
            }
        }

        private void showCCMHeatStatus(IList<CCMHeatStatusInfo> ccmHeatStatusList)
        {
            foreach (CCMHeatStatusInfo item in ccmHeatStatusList)
            {
                ListViewItem lvItem = new ListViewItem(item.StatusTimeStamp.ToString());
                lvItem.SubItems.Add(item.HeatStatus);
                lvCCMDetailHeatStatus.Items.Add(lvItem);
            }
        }

        private void showCCMSlabReport(IList<CCMSlabReportInfo> ccmSlabReportList)
        {
            foreach (CCMSlabReportInfo item in ccmSlabReportList.OrderBy(i => i.MsgTimeStamp))
            {
                ListViewItem lvItem = new ListViewItem(item.MsgTimeStamp.ToString("MM/dd HH:mm:ss"));
                lvItem.SubItems.Add(item.SlabId);
                lvItem.SubItems.Add(item.SlabThickness.ToString());
                lvItem.SubItems.Add(item.SlabLength.ToString());
                lvItem.SubItems.Add(item.SlabWidth.ToString());
                lvItem.SubItems.Add(item.SampleCut.ToString());
                lvItem.SubItems.Add(item.ProductType);
                lvItem.SubItems.Add(item.SlabWeight.ToString());
                lvItem.SubItems.Add(item.CuttingTime.HasValue ? item.CuttingTime.Value.ToString("MM/dd HH:mm:ss") : null);
                lvItem.SubItems.Add(item.CuttingPosition.ToString());
                lvItem.SubItems.Add(item.SlabSequence.ToString());
                lvItem.SubItems.Add(item.SlabInitialWidth.ToString());
                lvItem.SubItems.Add(item.SlabFinalWidth.ToString());
                lvItem.SubItems.Add(item.SlabType);
                lvItem.SubItems.Add(item.Destination.ToString());
                lvCCMDetailSlab.Items.Add(lvItem);
            }
        }

        private void clearBOFHeatAllInfo()
        {
            this.lblBOFStationID.Text = "";
            this.lblBOFBlowCount.Text = "";
            this.lblBOFIsBlowing.Text = "";
            this.lblBOFReblowingConsumption.Text = "";
            this.lblBOFOxygenConsumption.Text = "";
            this.lblBOFStartTime.Text = "";
            this.lblBOFEndTime.Text = "";
            this.lblBOFEndTemp.Text = "";

            this.lblBOFTSOOxygen.Text = "";
            this.lblBOFTSOCarbon.Text = "";
            this.lblBOFTSOTemp.Text = "";
            this.lblBOFTSCCarbon.Text = "";
            this.lblBOFTSCTemp.Text = "";
            this.lblBOFSteelNetWeight.Text = "";
            this.lblBOFScrapInWeight.Text = "";
            this.lblBOFHotMetalWeight.Text = "";

            this.lvBOFAdditionRecord.Items.Clear();
            this.lvBOFAdditionStatistic.Items.Clear();
            this.lvBOFHeatStatusDetail.Items.Clear();
        }

        private void clearRHHeatAllInfo()
        {
            lvRHAdditionEach.Items.Clear();
            lvRHAdditionSum.Items.Clear();
            lvRHHeatStatusList.Items.Clear();
        }

        private void clearCCMHeatAllInfo()
        {
            this.lblCCMDetailArFlowSealing.Text = "";
            this.lblCCMDetailArFlowShroud.Text = "";
            this.lblCCMDetailArFlowUpnozzle.Text = "";
            this.lblCCMDetailArFlowStopper.Text = "";
            this.lblCCMDetailArrivalTemp.Text = "";
            this.lblCCMDetailCastEndLength.Text = "";
            this.lblCCMDetailCastNo.Text = "";
            this.lblCCMDetailCastStartLength.Text = "";
            this.lblCCMDetailCastTotalLength.Text = "";
            this.lblCCMDetailCastWeight.Text = "";
            this.lblCCMDetailLadleArrivalWeight.Text = "";
            this.lblCCMDetailLadleDepartWeight.Text = "";
            this.lblCCMDetailMoldAlarmPosition.Text = "";
            this.lblCCMDetailMoldAlarmTime.Text = "";
            this.lblCCMDetailMoldFriction.Text = "";
            this.lblCCMDetailMoldLevelMax.Text = "";
            this.lblCCMDetailMoldLevelMin.Text = "";
            this.lblCCMDetailMoldSetLevel.Text = "";
            this.lblCCMDetailSequenceInCast.Text = "";
            this.lblCCMDetailSlabTotalLength.Text = "";
            this.lblCCMDetailSteelNetWeight.Text = "";
            this.lblCCMDetailTundishMinWeight.Text = "";
            this.lblCCMDetailFluidTemp.Text = "";

            this.lvCCMDetailHeatStatus.Items.Clear();
            this.lvCCMDetailSlab.Items.Clear();
        }

        private void showBOFHeatInfo(BOFHeatInfo bofHeat)
        {
            if (bofHeat != null)
            {
                this.lblBOFStationID.Text = bofHeat.StationId.ToString();
                this.lblBOFBlowCount.Text = bofHeat.BlowCount.ToString();
                this.lblBOFIsBlowing.Text = bofHeat.IsBlowingToString();
                this.lblBOFReblowingConsumption.Text = bofHeat.ReblowingOxygenConsumption.ToString();
                this.lblBOFOxygenConsumption.Text = bofHeat.OxygenConsumption.ToString();
                this.lblBOFStartTime.Text = bofHeat.StartTime.ToString();
                this.lblBOFEndTime.Text = bofHeat.EndTime.ToString();
                this.lblBOFEndTemp.Text = bofHeat.EndTemperature.ToString();

                this.lblBOFTSOOxygen.Text = bofHeat.TsoOxygen.ToString();
                this.lblBOFTSOCarbon.Text = bofHeat.TsoCarbon.ToString();
                this.lblBOFTSOTemp.Text = bofHeat.TsoTemperature.ToString();
                this.lblBOFTSCCarbon.Text = bofHeat.TscCarbon.ToString();
                this.lblBOFTSCTemp.Text = bofHeat.TscTemperature.ToString();

                this.lblBOFSteelNetWeight.Text = (bofHeat.SteelNetWeight / 1000).ToString();
                this.lblBOFScrapInWeight.Text = (bofHeat.ScrapInWeight / 1000).ToString();
                this.lblBOFHotMetalWeight.Text = (bofHeat.HotMetalWeight / 1000).ToString();
            }
        }

        private void showBOFHeatStatusList(IList<BOFHeatStatusInfo> bofHeatStatusList)
        {
            foreach (BOFHeatStatusInfo item in bofHeatStatusList)
            {
                ListViewItem lvItem = new ListViewItem(item.StatusTimeStamp.ToString());
                lvItem.SubItems.Add(item.HeatStatus);
                lvBOFHeatStatusDetail.Items.Add(lvItem);
            }
        }

        private void showBOFAdditionRecord(IList<BOFAdditionInfo> bofAdditionList)
        {
            foreach (BOFAdditionInfo item in bofAdditionList)
            {
                ListViewItem lvItem = new ListViewItem(item.AdditionTime.ToString());
                lvItem.SubItems.Add(item.MaterialName);
                lvItem.SubItems.Add(item.AdditionPlace);
                lvItem.SubItems.Add(item.AdditionAmount.ToString());
                lvBOFAdditionRecord.Items.Add(lvItem);
            }
        }

        private void showBOFAdditionStatistic(IList<BOFAdditionInfo> bofAdditionStatistic)
        {
            foreach (BOFAdditionInfo item in bofAdditionStatistic)
            {
                ListViewItem lvItem = new ListViewItem(item.MaterialCode);
                lvItem.SubItems.Add(item.MaterialName);
                lvItem.SubItems.Add(item.AdditionAmount.ToString());
                lvBOFAdditionStatistic.Items.Add(lvItem);
            }
        }

        private void showPanelLFHeatDetailInfo()
        {
            setAllLFContentPanelUnvisible();
            setAllControlButtonEnabled();
            this.btnLFDetailHeatInfo.Enabled = false;
            this.panelLFHeatDetail.Visible = true;
            this.panelLFHeatDetail.BringToFront();
            if (!string.IsNullOrEmpty(lblHeatId.Text))
            {
                LFHeat lfHeatBll = new LFHeat();
                LFHeatInfo heatInfo = lfHeatBll.GetLFHeatInfo(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
                showHeatDetailInfos(heatInfo);
            }
        }

        private void LFMainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.showPanelMainControl();
                    break;
                case Keys.F2:
                    this.showPanelLFHeatSteelGradeDetailInfo();
                    break;
                case Keys.F3:
                    this.showPanelHeatQualityInfo();
                    break;
                case Keys.F4:
                    this.showPanelBOFRHCCMHeatInfo();
                    break;
                case Keys.F5:
                    this.showPanelLFHeatDetailInfo();
                    break;
                case Keys.F6:
                    this.showPanelLFProcessInfo();
                    break;
                case Keys.F7:
                    this.showPanelTempEstimate();
                    break;
                case Keys.F8:
                    this.btnAlloyCalculate.PerformClick();
                    break;
                case Keys.F9:
                    break;
                default:
                    break;
            }
        }

        private void btnLFProcessInfo_Click(object sender, EventArgs e)
        {
            showPanelLFProcessInfo();
        }

        private void showPanelLFProcessInfo()
        {
            if (this.btnLFProcessInfo.Enabled)
            {
                setAllLFContentPanelUnvisible();
                setAllControlButtonEnabled();
                this.btnLFProcessInfo.Enabled = false;
                this.panelLFProcessInfo.Visible = true;
                this.panelLFProcessInfo.BringToFront();
                string heatId = this.lblHeatId.Text;

                clearChartPoints();

                if (!string.IsNullOrEmpty(heatId))
                {
                    int treatmentCount = Convert.ToInt16(this.lblTreatmentCount.Text);
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

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        #region PanelTempEstimate 温度预估

        private void btnTemperaturePrediction_Click(object sender, EventArgs e)
        {
            int count = (from i in onGoingLFHeatList
                         where i.HeatId == lblHeatId.Text
                         select i).Count();
            if (!string.IsNullOrEmpty(lblHeatId.Text) && count == 1)
            {
                showPanelTempEstimate();
            }
            else
            {
                MessageBox.Show("请先选择正在冶炼的炉次！");
            }
        }

        private void showPanelTempEstimate()
        {
            setAllLFContentPanelUnvisible();
            setAllControlButtonEnabled();
            this.btnTemperaturePrediction.Enabled = false;
            this.panelTempEstimate.Visible = true;
            this.panelTempEstimate.BringToFront();
            cmbTempEstTapPosition.Text = "9";
            cmbTempEstTapPositionPoint.Text = "9";
            refreshTempPredictioin();
        }

        private void refreshTempPredictioin()
        {
            TempEstimate tempEstimateBasicBLL = new TempEstimate();
            TempEstimateInfo tempPredictionInfo = tempEstimateBasicBLL.GetTempEstimate(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
            RealTime realTimeBLL = new RealTime();
            IList<RealTimeInfo> realTimeList = realTimeBLL.GetRealTimeInfo(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
            lblTeEstActualLadleAge.Text = tempPredictionInfo.LadleInfo.LadleAge.ToString();
            txtTeEstLadleAge.Text = lblTeEstActualLadleAge.Text;
            lblTeEstLastTempTime.Text = tempPredictionInfo.LastTemperatureTime.ToString();
            lblTeEstLastTempValue.Text = tempPredictionInfo.LastTemperature.ToString();
            lblTeEstSteelWeight.Text = (tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_STEEL_NET_WEIGHT").First()).InfoValue;
            txtTeEstSteelWeight.Text = lblTeEstSteelWeight.Text;
            lblTeEstLiquidTemp.Text = tempPredictionInfo.LiquidTemp.ToString();
            txtTeEstLiquidTemp.Text = lblTeEstLiquidTemp.Text;
            txtCalCurrentTemp.Text = Math.Round(Convert.ToDouble(tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA").First().InfoValue), 0).ToString();
            txtlOperatorTempModify.Text = Math.Round(Convert.ToDouble(txtCalCurrentTemp.Text), 0).ToString();
            cmbLadleStatus.Text = (tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_LADLE_STATUS").First()).InfoValue; ;
            if (tempPredictionInfo.LiquidTemp != 0)
            {
                txtTheoryAimTemp.Text = (tempPredictionInfo.LiquidTemp + 60).ToString();
            }
            dgvTempEstimateCoefficient_DatatBind(tempPredictionInfo.CoefficientList);
            dgvTempHistory_DataBind(tempPredictionInfo.TemperatureList);
            dgvTempEstMatInfo_DataBind(tempPredictionInfo.MaterialList);
            dgvTempEstTapInfo_DataBind(tempPredictionInfo.TransformerParamList);
        }

        private void dgvTempEstimateCoefficient_DatatBind(IList<TempEstimateCoefficInfo> tempEstimateCoefficInfos)
        {
            dgvTempEstimateCoefficient.Rows.Clear();
            foreach (TempEstimateCoefficInfo info in tempEstimateCoefficInfos)
            {
                object[] row = new object[] { info.CoefficientName, info.CoefficientDesc, info.CoefficientDefaultVal.ToString(), info.CoefficientModifyVal.ToString() };
                dgvTempEstimateCoefficient.Rows.Add(row);
            }
        }

        private void dgvTempEstMatInfo_DataBind(IList<MaterialInfo> materialInfos)
        {
            dgvTempEstMatInfo.Rows.Clear();
            foreach (MaterialInfo info in materialInfos)
            {
                object[] row = new object[] { info.MaterialId.ToString(), info.MaterialName, info.ChillFactor.ToString() };
                dgvTempEstMatInfo.Rows.Add(row);
            }
        }

        private void dgvTempEstTapInfo_DataBind(IList<TransformerParamInfo> transFormerInfos)
        {
            dgvTempEstTapInfo.Rows.Clear();
            foreach (TransformerParamInfo info in transFormerInfos)
            {
                object[] row = new object[] { info.TapPosition.ToString(), info.TapPositionPoint.ToString(), info.Voltage.ToString(), info.Current.ToString(), info.TempPerMin.ToString() };
                dgvTempEstTapInfo.Rows.Add(row);
            }
        }

        private void dgvTempHistory_DataBind(IList<TempOxygenRecordInfo> tempList)
        {
            dgvTempHistory.Rows.Clear();
            foreach (TempOxygenRecordInfo info in tempList.OrderByDescending(i => i.MsgId).ToList<TempOxygenRecordInfo>())
            {
                object[] row = new object[] { info.MsgTimeStamp.ToString(), "LF", info.TemperatureData.ToString() };
                dgvTempHistory.Rows.Add(row);
            }
        }

        private void btnEditTempCoeffic_Click(object sender, EventArgs e)
        {
            dgvTempEstimateCoefficient.ReadOnly = false;
            dgvTempEstimateCoefficient.Columns[1].ReadOnly = true;
            dgvTempEstimateCoefficient.Columns[2].ReadOnly = true;
            btnConfirmTempCoeffic.Enabled = true;
            btnCancelTempCoeffic.Enabled = true;
            btnEditTempCoeffic.Enabled = false;
        }

        private void btnConfirmTempCoeffic_Click(object sender, EventArgs e)
        {
            TempEstimateCoeffic tempEstCoefficBLL = new TempEstimateCoeffic();
            IList<TempEstimateCoefficInfo> tempEstCoefficients = new List<TempEstimateCoefficInfo>();
            foreach (DataGridViewRow item in dgvTempEstimateCoefficient.Rows)
            {
                try
                {
                    TempEstimateCoefficInfo tempEstCoeffic = new TempEstimateCoefficInfo();
                    tempEstCoeffic.CoefficientName = item.Cells[0].Value.ToString();
                    tempEstCoeffic.CoefficientDesc = item.Cells[1].Value.ToString();
                    tempEstCoeffic.CoefficientDefaultVal = Convert.ToDouble(item.Cells[2].Value);
                    tempEstCoeffic.CoefficientModifyVal = Convert.ToDouble(item.Cells[3].Value);
                    tempEstCoefficients.Add(tempEstCoeffic);
                }
                catch
                {

                }
            }
            tempEstCoefficBLL.UpdateTempEstimateCoeffic(tempEstCoefficients);
            dgvTempEstimateCoefficient_DatatBind(tempEstCoefficients);
            dgvTempEstimateCoefficient.ReadOnly = true;
            btnConfirmTempCoeffic.Enabled = false;
            btnCancelTempCoeffic.Enabled = false;
            btnEditTempCoeffic.Enabled = true;
        }

        private void btnCancelTempCoeffic_Click(object sender, EventArgs e)
        {
            TempEstimateCoeffic tempEstimateCoefficBLL = new TempEstimateCoeffic();
            IList<TempEstimateCoefficInfo> tempEstimateCoefficList = tempEstimateCoefficBLL.GetTempEstimateCoeffic();
            dgvTempEstimateCoefficient_DatatBind(tempEstimateCoefficList);
            dgvTempEstimateCoefficient.ReadOnly = true;
            btnConfirmTempCoeffic.Enabled = false;
            btnCancelTempCoeffic.Enabled = false;
            btnEditTempCoeffic.Enabled = true;
        }

        private void btnEditMatChillFactor_Click(object sender, EventArgs e)
        {
            dgvTempEstMatInfo.ReadOnly = false;
            dgvTempEstMatInfo.Columns[1].ReadOnly = true;
            btnConfirmMatChillFactor.Enabled = true;
            btnCancelMatChillFactor.Enabled = true;
            btnEditMatChillFactor.Enabled = false;
        }

        private void btnConfirmMatChillFactor_Click(object sender, EventArgs e)
        {
            Material materialBLL = new Material();
            foreach (DataGridViewRow item in dgvTempEstMatInfo.Rows)
            {
                if (item.Cells[0].Value != "" && item.Cells[2].Value != "")
                {
                    materialBLL.UpdateMaterialInfo(Convert.ToInt32(item.Cells[0].Value), Convert.ToDouble(item.Cells[2].Value));
                }
            }
            IList<MaterialInfo> materialList = materialBLL.GetAllMaterialInfos();
            dgvTempEstMatInfo_DataBind(materialList);
            dgvTempEstMatInfo.ReadOnly = true;
            btnConfirmMatChillFactor.Enabled = false;
            btnCancelMatChillFactor.Enabled = false;
            btnEditMatChillFactor.Enabled = true;
        }

        private void btnCancelMatChillFactor_Click(object sender, EventArgs e)
        {
            Material materialBLL = new Material();
            IList<MaterialInfo> materialList = materialBLL.GetAllMaterialInfos();
            dgvTempEstMatInfo_DataBind(materialList);
            dgvTempEstMatInfo.ReadOnly = true;
            btnConfirmMatChillFactor.Enabled = false;
            btnCancelMatChillFactor.Enabled = false;
            btnEditMatChillFactor.Enabled = true;
        }

        private void btnEditTapWarmFactor_Click(object sender, EventArgs e)
        {
            dgvTempEstTapInfo.ReadOnly = false;
            dgvTempEstTapInfo.Columns[0].ReadOnly = true;
            dgvTempEstTapInfo.Columns[1].ReadOnly = true;
            dgvTempEstTapInfo.Columns[2].ReadOnly = true;
            dgvTempEstTapInfo.Columns[3].ReadOnly = true;
            btnConfirmTapWarmFactor.Enabled = true;
            btnCancelTapWarmFactor.Enabled = true;
            btnEditTapWarmFactor.Enabled = false;
        }

        private void btnConfirmTapWarmFactor_Click(object sender, EventArgs e)
        {
            TransformerParam transParamBLL = new TransformerParam();
            foreach (DataGridViewRow item in dgvTempEstTapInfo.Rows)
            {
                transParamBLL.UpdateTransParam(Convert.ToInt32(item.Cells[0].Value), Convert.ToInt32(item.Cells[1].Value), Convert.ToDouble(item.Cells[4].Value));
            }
            IList<TransformerParamInfo> transParamList = transParamBLL.GetAllTransFormerParamInfo();
            dgvTempEstTapInfo_DataBind(transParamList);
            dgvTempEstTapInfo.ReadOnly = true;
            btnConfirmTapWarmFactor.Enabled = false;
            btnCancelTapWarmFactor.Enabled = false;
            btnEditTapWarmFactor.Enabled = true;
        }

        private void btnCancelTapWarmFactor_Click(object sender, EventArgs e)
        {
            TransformerParam transParamBLL = new TransformerParam();
            IList<TransformerParamInfo> transParamList = transParamBLL.GetAllTransFormerParamInfo();
            dgvTempEstTapInfo_DataBind(transParamList);
            dgvTempEstTapInfo.ReadOnly = true;
            btnConfirmTapWarmFactor.Enabled = false;
            btnCancelTapWarmFactor.Enabled = false;
            btnEditTapWarmFactor.Enabled = true;
        }

        private void btnCalculateTemp_Click(object sender, EventArgs e)
        {
            TempEstimateBasic tempEstimateBasicBLL = new TempEstimateBasic();
            TempEstimateBasicInfo tempEstBasicInfo = new TempEstimateBasicInfo();
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_STEEL_NET_WEIGHT";
            tempEstBasicInfo.InfoValue = txtTeEstSteelWeight.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_LADLE_STATUS";
            tempEstBasicInfo.InfoValue = cmbLadleStatus.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            if (!string.IsNullOrEmpty(txtTeEstLiquidTemp.Text) && txtTeEstLiquidTemp.Text != "0")
            {
                SteelGradeDetails steelGradeBLL = new SteelGradeDetails();
                steelGradeBLL.UpdateSteelGradeLiquidTemp(lblSteelGradeId.Text, Convert.ToDouble(txtTeEstLiquidTemp.Text));
            }
            if (txtlOperatorTempModify.Text != txtCalCurrentTemp.Text)
            {
                tempEstBasicInfo = new TempEstimateBasicInfo();
                tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA";
                tempEstBasicInfo.InfoValue = txtlOperatorTempModify.Text;
                tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            }
            tempEstBasicInfo = new TempEstimateBasicInfo();
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_MODIFY_TEMP_PER_MIN";
            tempEstBasicInfo.InfoValue = txtModifyTempPerMin.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);

            refreshTempPredictioin();

            TempEstimate tempEstimateBLL = new TempEstimate();
            TempEstimateInfo tempPredictionInfo = tempEstimateBLL.GetTempEstimate(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
            RealTime realTimeBLL = new RealTime();
            IList<RealTimeInfo> realTimeList = realTimeBLL.GetRealTimeInfo(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));



            #region 计算剩余需要加热时间
            double currentTemp = Convert.ToDouble((tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA").First()).InfoValue);
            double remainTemp = Convert.ToDouble(txtTheoryAimTemp.Text) - currentTemp + Convert.ToDouble(txtLFRemainTime.Text);
            double tapWarmingFator = Convert.ToDouble((from i in tempPredictionInfo.TransformerParamList
                                                       where i.TapPosition.ToString() == cmbTempEstTapPosition.Text && i.TapPositionPoint.ToString() == cmbTempEstTapPositionPoint.Text
                                                       select i.TempPerMin).First());
            if (remainTemp > 0)
            {
                if (Math.Round(remainTemp / tapWarmingFator, 2) < Convert.ToDouble(txtLFRemainTime.Text))
                {
                    txtLFRemainHeatingDur.Text = Math.Round(remainTemp / tapWarmingFator, 0).ToString();
                }
                else
                {
                    txtLFRemainHeatingDur.Text = "无法计算";
                }
            }
            else
            {
                txtLFRemainHeatingDur.Text = "无需加热";
            }
            #endregion
        }

        private void btnSaveTempEstParam_Click(object sender, EventArgs e)
        {
            TempEstimateBasic tempEstimateBasicBLL = new TempEstimateBasic();
            TempEstimateBasicInfo tempEstBasicInfo = new TempEstimateBasicInfo();
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_STEEL_NET_WEIGHT";
            tempEstBasicInfo.InfoValue = txtTeEstSteelWeight.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_LADLE_STATUS";
            tempEstBasicInfo.InfoValue = cmbLadleStatus.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            if (!string.IsNullOrEmpty(txtTeEstLiquidTemp.Text) && txtTeEstLiquidTemp.Text != "0")
            {
                SteelGradeDetails steelGradeBLL = new SteelGradeDetails();
                steelGradeBLL.UpdateSteelGradeLiquidTemp(lblSteelGradeId.Text, Convert.ToDouble(txtTeEstLiquidTemp.Text));
            }
        }

        private void btnRefreshCurrentCalTemp_Click(object sender, EventArgs e)
        {
            TempEstimateBasic tempEstimateBasicBLL = new TempEstimateBasic();
            TempEstimateBasicInfo tempEstBasicInfo = new TempEstimateBasicInfo();
            if (txtlOperatorTempModify.Text != txtCalCurrentTemp.Text)
            {
                tempEstBasicInfo = new TempEstimateBasicInfo();
                tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA";
                tempEstBasicInfo.InfoValue = txtlOperatorTempModify.Text;
                tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);
            }
            tempEstBasicInfo = new TempEstimateBasicInfo();
            tempEstBasicInfo.InfoName = "CAR" + lblCar.Text + "_MODIFY_TEMP_PER_MIN";
            tempEstBasicInfo.InfoValue = txtModifyTempPerMin.Text;
            tempEstimateBasicBLL.UpdateTempEstimateBasic(tempEstBasicInfo);

            TempEstimate tempEstimateBLL = new TempEstimate();
            TempEstimateInfo tempPredictionInfo = tempEstimateBLL.GetTempEstimate(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
            txtCalCurrentTemp.Text = Math.Round(Convert.ToDouble(tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA").First().InfoValue), 0).ToString();
            txtlOperatorTempModify.Text = Math.Round(Convert.ToDouble(txtCalCurrentTemp.Text), 0).ToString();

            #region 计算终点温度

            RealTime realTimeBLL = new RealTime();
            IList<RealTimeInfo> realTimeList = realTimeBLL.GetRealTimeInfo(lblHeatId.Text, Convert.ToInt32(lblTreatmentCount.Text));
            DateTime lastTempDate = realTimeList.OrderByDescending<RealTimeInfo, decimal>(i => i.MsgId).First().MsgTimeStamp;
            TimeSpan? minusDateSpan = lastTempDate - tempPredictionInfo.LastTemperatureTime;
            double minusDate = Math.Round(minusDateSpan.Value.TotalMinutes, 2);
            double minusTemp = Convert.ToDouble(realTimeList.OrderByDescending<RealTimeInfo, decimal>(i => i.MsgId).First().TheoryTemp - tempPredictionInfo.LastTemperature);
            double currentTemp = Convert.ToDouble((tempPredictionInfo.TempEstBasicList.Where(i => i.InfoName == "CAR" + lblCar.Text + "_CURRENT_TEMP_DATA").First()).InfoValue);
            txtCalTerminalTemp.Text = Math.Round(currentTemp + Convert.ToDouble(txtTempEstCalDate.Text) * minusTemp / minusDate + Convert.ToDouble(txtTempModify.Text), 0).ToString();

            #endregion
        }

        #region 温度预估界面操作员输入值有效性验证
        private void txtTeEstSteelWeight_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTeEstSteelWeight.Text, @"^\d{1,6}$"))
            {
                MessageBox.Show("钢水重量只能输入6位以内整数，您输入的格式不正确，请重新输入！ ");
                txtTeEstSteelWeight.Text = "0";
            }
        }

        private void txtTeEstRoastTemp_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTeEstRoastTemp.Text, @"^\d{1,4}$"))
            {
                MessageBox.Show("烤包温度只能输入4位以内整数，您输入的格式不正确，请重新输入！ ");
                txtTeEstRoastTemp.Text = "0";
            }
        }

        private void txtTeEstLadleAge_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTeEstLadleAge.Text, @"^\d{1,3}$"))
            {
                MessageBox.Show("钢包包龄只能输入3位以内整数，您输入的格式不正确，请重新输入！ ");
                txtTeEstLadleAge.Text = "0";
            }
        }

        private void txtTeEstLiquidTemp_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTeEstLadleAge.Text, @"^\d{1,3}$"))
            {
                MessageBox.Show("钢种液相线温度只能输入4位以内整数，您输入的格式不正确，请重新输入！ ");
                txtTeEstLadleAge.Text = "0";
            }
        }

        private void txtModifyTempPerMin_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtModifyTempPerMin.Text, @"^\d{1,3}$|^\d{1,3}\.\d{1,2}$"))
            {
                MessageBox.Show("您输入的温度自动校正系数 \"" + txtModifyTempPerMin.Text + "\" 不符合格式要求，请重新输入！ ");
                txtModifyTempPerMin.Text = "0";
            }
        }

        private void txtlOperatorTempModify_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtlOperatorTempModify.Text, @"^\d{1,4}$|^\d{1,4}\.\d{1,3}$"))
            {
                MessageBox.Show("您输入的操作员校正温度 \"" + txtlOperatorTempModify.Text + "\" 不符合格式要求，请重新输入！ ");
                txtlOperatorTempModify.Text = "0";
            }
        }

        private void txtTheoryAimTemp_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTheoryAimTemp.Text, @"^\d{1,4}$|^\d{1,4}\.\d{1,2}$"))
            {
                MessageBox.Show("您输入的钢水终点温度目标\"" + txtTheoryAimTemp.Text + "\" 不符合格式要求，请重新输入！ ");
                txtTheoryAimTemp.Text = "0";
            }
        }

        private void txtTempModify_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtTempModify.Text, @"^\d{1,2}$|^\d{1,2}\.\d{1,2}$"))
            {
                MessageBox.Show("您输入的钢水终点温度校正值\"" + txtTempModify.Text + "\" 不符合格式要求，请重新输入！ ");
                txtTempModify.Text = "0";
            }
        }

        private void txtLFRemainTime_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtLFRemainTime.Text, @"^\d{1,3}$"))
            {
                MessageBox.Show("您输入的LF剩余时间 \"" + txtLFRemainTime.Text + "\" 不符合格式要求，请重新输入！ ");
                txtLFRemainTime.Text = "0";
            }
        }

        private void dgvTempEstimateCoefficient_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvTempEstimateCoefficient.CurrentCell.Value == null)
                {
                    dgvTempEstimateCoefficient.CurrentCell.Value = 0;
                }
                else if (!Regex.IsMatch(dgvTempEstimateCoefficient.CurrentCell.Value.ToString(), @"^\-\d{1,2}$|^\d{1,2}$|^\-\d{1,2}\.\d{1,2}$|^\d{1,2}\.\d{1,2}$"))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvTempEstimateCoefficient.CurrentCell.Value = 0;
                }
            }
        }

        private void dgvTempEstMatInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvTempEstMatInfo.CurrentCell.Value == null)
                {
                    dgvTempEstMatInfo.CurrentCell.Value = 0;
                }
                else if (!Regex.IsMatch(dgvTempEstMatInfo.CurrentCell.Value.ToString(), @"^\-\d{1,2}$|^\d{1,2}$|^\-\d{1,2}\.\d{1,2}$|^\d{1,2}\.\d{1,2}$"))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvTempEstMatInfo.CurrentCell.Value = 0;
                }
            }
        }

        private void dgvTempEstTapInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvTempEstTapInfo.CurrentCell.Value == null)
                {
                    dgvTempEstTapInfo.CurrentCell.Value = 0;
                }
                else if (!Regex.IsMatch(dgvTempEstTapInfo.CurrentCell.Value.ToString(), @"^\-\d{1,2}$|^\d{1,2}$|^\-\d{1,2}\.\d{1,2}$|^\d{1,2}\.\d{1,2}$"))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvTempEstTapInfo.CurrentCell.Value = 0;
                }
            }
        }

        private void cmbTempEstTapPosition_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbTempEstTapPosition.Text) && !string.IsNullOrEmpty(cmbTempEstTapPositionPoint.Text))
            {
                TransformerParam transformerParamBLL = new TransformerParam();
                IList<TransformerParamInfo> transformParamList = transformerParamBLL.GetAllTransFormerParamInfo();
                lblTempEstTapVol.Text = (from i in transformParamList
                                         where i.TapPosition.ToString() == cmbTempEstTapPosition.Text && i.TapPositionPoint.ToString() == cmbTempEstTapPositionPoint.Text
                                         select i.Voltage).First().ToString() + "V";
                lblTempEstTapCurrent.Text = (from i in transformParamList
                                             where i.TapPosition.ToString() == cmbTempEstTapPosition.Text && i.TapPositionPoint.ToString() == cmbTempEstTapPositionPoint.Text
                                             select i.Current).First().ToString() + "A)";
            }
        }

        private void cmbTempEstTapPositionPoint_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbTempEstTapPosition.Text) && !string.IsNullOrEmpty(cmbTempEstTapPositionPoint.Text))
            {
                TransformerParam transformerParamBLL = new TransformerParam();
                IList<TransformerParamInfo> transformParamList = transformerParamBLL.GetAllTransFormerParamInfo();
                lblTempEstTapVol.Text = (from i in transformParamList
                                         where i.TapPosition.ToString() == cmbTempEstTapPosition.Text && i.TapPositionPoint.ToString() == cmbTempEstTapPositionPoint.Text
                                         select i.Voltage).First().ToString() + "V";
                lblTempEstTapCurrent.Text = (from i in transformParamList
                                             where i.TapPosition.ToString() == cmbTempEstTapPosition.Text && i.TapPositionPoint.ToString() == cmbTempEstTapPositionPoint.Text
                                             select i.Current).First().ToString() + "A)";
            }
        }
        #endregion

        #endregion

        private void btnRepaireMode_Click(object sender, EventArgs e)
        {

        }

        #region 合金计算

        private void lvAlloyCalculator_DataBind()
        {
            lvCalculatorInfo.Items.Clear();
            SteelGradeDetailInfo steelInfo = null;
            steelInfo = getSteelGradeDetailInfo();

            HeatQuality heatQualityBLL = new HeatQuality();
            string heatId = this.lblHeatId.Text.Trim();

            FormulaCalculator formulaCalBLL = new FormulaCalculator();

            MSScriptControl.ScriptControl sc = new ScriptControl();
            sc.Language = "JScript";

            Formula formulaBLL = new Formula();
            IList<FormulaInfo> formulaList = formulaBLL.GetFormulaListByHeatId(heatId);
            if (formulaList.Count != 0)
            {
                steelInfo.FormulaInfos = formulaList;
            }
            if (!string.IsNullOrEmpty(this.lblHeatId.Text.Trim()) && !Regex.IsMatch(this.lblHeatId.Text.Trim(), @"\?"))
            {
                //绑定钢分析信息 
                foreach (SteelAnalysisInfo Info in steelInfo.SteelAnalysisList)
                {
                    ListViewItem item = new ListViewItem(Info.ElemInfo.ElementFullName.ToString());
                    item.SubItems.Add(Info.MinValue.ToString());
                    item.SubItems.Add(Info.AimValue.ToString());
                    item.SubItems.Add(Info.MaxValue.ToString());
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    item.SubItems.Add("");
                    lvCalculatorInfo.Items.Add(item);
                }

                //绑定化验室信息及公式计算
                IList<HeatQualityInfo> heatQualityList = heatQualityBLL.GetHeatQualityInfo(heatId);
                IList<QualityInfo> qualityInfoList = heatQualityList.OrderByDescending(i => i.MsgId).First().QualityList;
                foreach (QualityInfo qualityInfo in qualityInfoList)
                {
                    foreach (ListViewItem item in lvCalculatorInfo.Items)
                    {
                        double minValue = Convert.ToDouble(item.SubItems[1].Text);
                        double maxValue = Convert.ToDouble(item.SubItems[3].Text);
                        double aimValue = Convert.ToDouble(item.SubItems[2].Text);
                        string elementFullName = qualityInfo.Element.ElementFullName;

                        if (qualityInfo.Element.ElementFullName == item.SubItems[0].Text)
                        {
                            if (qualityInfo.Element.ElementType == "ELEMENT" || qualityInfo.Element.ElementType == "COMPOUND")
                            {
                                double? qualityValue = qualityInfo.QualityValue;
                                item.SubItems[4].Text = qualityValue.ToString();

                                if (qualityValue.HasValue)
                                {
                                    if (qualityValue < minValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.PowderBlue;
                                    }
                                    else if (qualityValue > maxValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Pink;
                                    }
                                    else if (qualityValue > aimValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Wheat;
                                    }
                                }
                            }
                            else if (qualityInfo.Element.ElementType == "FORMULA")
                            {
                                string digitalFormulaString = formulaCalBLL.FormulaParse(qualityInfoList, elementFullName);
                                try
                                {
                                    double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                    item.SubItems[4].Text = result.ToString();

                                    if (result < minValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.PowderBlue;
                                    }
                                    else if (result > maxValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Pink;
                                    }
                                    else if (result > aimValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Wheat;
                                    }
                                }
                                catch
                                { }
                            }
                            else if (qualityInfo.Element.ElementType == "SPECIAL FORMULA")
                            {
                                try
                                {
                                    FormulaInfo formula = steelInfo.FormulaInfos.Single<FormulaInfo>(k => k.FormulaType.ToUpper() == elementFullName);
                                    string digitalFormulaString = formulaCalBLL.FormulaParse(qualityInfoList, formula.Formula);
                                    double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                    item.SubItems[4].Text = Math.Round(result, 5).ToString();


                                    if (result < minValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.PowderBlue;
                                    }
                                    else if (result > maxValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Pink;
                                    }
                                    else if (result > aimValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[4].BackColor = Color.Wheat;
                                    }
                                }
                                catch
                                { }
                            }
                        }

                    }
                }
            }
        }

        private void SiloTableNameBind()
        {
            string LabelName = "lblContainer";
            Source sourceBLL = new Source();
            IList<SourceInfo> sourceInfoList = sourceBLL.GetSourceInfo().Where(i => i.SourceType == "料仓").ToList<SourceInfo>();
            foreach (SourceInfo Info in sourceInfoList)
            {
                object obj = (System.Windows.Forms.Label)this.Controls.Find(LabelName + Info.SourceId.ToString(), true)[0];
                Label myLabel = obj as Label;
                myLabel.Text = Info.SourceId.ToString() + ":" + Info.MaterialName;
            }
        }

        private void SteelWgt_DataBind()
        {
            string heatid = this.lblHeatId.Text;
            int treatmentcount = int.Parse(this.lblTreatmentCount.Text);
            LFHeat lfheatBLL = new LFHeat();
            LFHeatInfo lfHeatList = lfheatBLL.GetLFHeatInfo(heatid, treatmentcount);
            float steelWgt = 0;
            try
            {
                steelWgt = float.Parse((lfHeatList.ArrivalSteelWeight / 1000).ToString());
            }
            catch
            {
                steelWgt = 0;
            }
            txtAlloyCalSteelWgt.Text = Math.Ceiling(steelWgt).ToString();
        }

        private void ClearSiloText()
        {
            for (int i = 0; i < 20; i++)
            {
                string TextBoxName = "txtCalculate";
                object obj = (System.Windows.Forms.TextBox)this.Controls.Find(TextBoxName + (i + 1).ToString(), true)[0];
                TextBox myTextBox = obj as TextBox;
                myTextBox.Text = "";
                myTextBox.ReadOnly = true;

                TextBoxName = "txtRealData";
                object obj1 = (System.Windows.Forms.TextBox)this.Controls.Find(TextBoxName + (i + 1).ToString(), true)[0];
                TextBox myTextBox1 = obj1 as TextBox;
                myTextBox1.Text = "";
                myTextBox1.ReadOnly = true;
            }
        }

        #region <修改TextBox的Text触发事件>
        private void txtCalculate1_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate1.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate1.Text + " 不符合格式要求，请重新输入！");
                txtCalculate1.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer1.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer1.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate1.Text;
                    }
                }
            }
        }

        private void txtCalculate2_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate2.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate2.Text + " 不符合格式要求，请重新输入！");
                txtCalculate2.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer2.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer2.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate2.Text;
                    }
                }
            }
        }

        private void txtCalculate3_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate3.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate3.Text + " 不符合格式要求，请重新输入！");
                txtCalculate3.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer3.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer3.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate3.Text;
                    }
                }
            }
        }

        private void txtCalculate4_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate4.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate4.Text + " 不符合格式要求，请重新输入！");
                txtCalculate4.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer4.Text.IndexOf(":");
                    if (item.SubItems[4].Text == lblContainer4.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate4.Text;
                    }
                }
            }
        }

        private void txtCalculate5_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate5.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate5.Text + " 不符合格式要求，请重新输入！");
                txtCalculate5.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer5.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer5.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate5.Text;
                    }
                }
            }
        }

        private void txtCalculate6_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate6.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate6.Text + " 不符合格式要求，请重新输入！");
                txtCalculate6.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer6.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer6.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate6.Text;
                    }
                }
            }
        }

        private void txtCalculate7_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate7.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate7.Text + " 不符合格式要求，请重新输入！");
                txtCalculate7.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer7.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer7.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate7.Text;
                    }
                }
            }
        }

        private void txtCalculate8_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate8.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate8.Text + " 不符合格式要求，请重新输入！");
                txtCalculate8.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer8.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer8.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate8.Text;
                    }
                }
            }
        }

        private void txtCalculate9_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate9.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate9.Text + " 不符合格式要求，请重新输入！");
                txtCalculate9.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer9.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer9.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate9.Text;
                    }
                }
            }
        }

        private void txtCalculate10_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate10.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate10.Text + " 不符合格式要求，请重新输入！");
                txtCalculate10.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer10.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer10.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate10.Text;
                    }
                }
            }
        }

        private void txtCalculate11_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate11.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate11.Text + " 不符合格式要求，请重新输入！");
                txtCalculate11.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer11.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer11.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate11.Text;
                    }
                }
            }
        }

        private void txtCalculate12_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate12.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate12.Text + " 不符合格式要求，请重新输入！");
                txtCalculate12.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer12.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer12.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate12.Text;
                    }
                }
            }
        }

        private void txtCalculate13_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate13.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate13.Text + " 不符合格式要求，请重新输入！");
                txtCalculate13.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer13.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer13.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate13.Text;
                    }
                }
            }
        }

        private void txtCalculate14_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate14.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate14.Text + " 不符合格式要求，请重新输入！");
                txtCalculate14.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer14.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer14.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate14.Text;
                    }
                }
            }
        }

        private void txtCalculate15_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate15.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate15.Text + " 不符合格式要求，请重新输入！");
                txtCalculate15.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer15.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer15.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate15.Text;
                    }
                }
            }
        }

        private void txtCalculate16_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate16.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate16.Text + " 不符合格式要求，请重新输入！");
                txtCalculate16.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer16.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer16.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate16.Text;
                    }
                }
            }
        }

        private void txtCalculate17_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate17.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate17.Text + " 不符合格式要求，请重新输入！");
                txtCalculate17.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer17.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer17.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate17.Text;
                    }
                }
            }
        }

        private void txtCalculate18_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate18.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate18.Text + " 不符合格式要求，请重新输入！");
                txtCalculate18.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer18.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer18.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate18.Text;
                    }
                }
            }
        }

        private void txtCalculate19_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate19.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate19.Text + " 不符合格式要求，请重新输入！");
                txtCalculate19.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer19.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer19.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate19.Text;
                    }
                }
            }
        }

        private void txtCalculate20_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,4}\.\d{0,4}$)|(^\d{0,4}$)";
            if (!Regex.IsMatch(txtCalculate20.Text, pattern))
            {
                MessageBox.Show("您输入的合金添加量 " + txtCalculate20.Text + " 不符合格式要求，请重新输入！");
                txtCalculate20.Text = "";
            }
            else
            {
                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    int index = lblContainer20.Text.IndexOf(":");
                    if (item.SubItems[1].Text == lblContainer20.Text.Remove(0, index + 1))
                    {
                        item.SubItems[3].Text = txtCalculate20.Text;
                    }
                }
            }
        }

        private void txtAlloyCalSteelWgt_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,3}\.\d{0,0}$)|(^\d{0,3}$)";
            if (!Regex.IsMatch(txtAlloyCalSteelWgt.Text, pattern))
            {
                MessageBox.Show("您输入的钢水重量 " + txtAlloyCalSteelWgt.Text + " 不符合格式要求，请重新输入！");
                txtAlloyCalSteelWgt.Text = "";
            }
        }

        private void txtAnalysisMin_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,1}\.\d{0,4}$)|(^\d{0,1}$)";
            if (!Regex.IsMatch(txtAnalysisMin.Text, pattern))
            {
                MessageBox.Show("您输入的元素定义值 " + txtAnalysisMin.Text + " 不符合格式要求，请重新输入！");
                txtAnalysisMin.Text = "";
            }
            else
            {
                if (lvCalculatorInfo.SelectedItems.Count > 0)
                {
                    lvCalculatorInfo.SelectedItems[0].SubItems[1].Text = txtAnalysisMin.Text;
                }
            }
        }

        private void txtAnalysisAim_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,1}\.\d{0,4}$)|(^\d{0,1}$)";
            if (!Regex.IsMatch(txtAnalysisAim.Text, pattern))
            {
                MessageBox.Show("您输入的元素定义值 " + txtAnalysisAim.Text + " 不符合格式要求，请重新输入！");
                txtAnalysisAim.Text = "";
            }
            else
            {
                if (lvCalculatorInfo.SelectedItems.Count > 0)
                {
                    lvCalculatorInfo.SelectedItems[0].SubItems[2].Text = txtAnalysisAim.Text;
                }
            }
        }

        private void txtAnalysisMax_TextChanged(object sender, EventArgs e)
        {
            pattern = @"(^\d{0,1}\.\d{0,4}$)|(^\d{0,1}$)";
            if (!Regex.IsMatch(txtAnalysisMax.Text, pattern))
            {
                MessageBox.Show("您输入的元素定义值 " + txtAnalysisMax.Text + " 不符合格式要求，请重新输入！");
                txtAnalysisMax.Text = "";
            }
            else
            {
                if (lvCalculatorInfo.SelectedItems.Count > 0)
                {
                    lvCalculatorInfo.SelectedItems[0].SubItems[3].Text = txtAnalysisMax.Text;
                }
            }
        }

        #endregion

        private void btnAlloyCalculate_Click(object sender, EventArgs e)
        {
            int count = (from i in onGoingLFHeatList
                         where i.HeatId == lblHeatId.Text
                         select i).Count();
            if (!string.IsNullOrEmpty(lblHeatId.Text) && count == 1)
            {
                setAllLFContentPanelUnvisible();
                setAllControlButtonEnabled();
                this.btnAlloyCalculate.Enabled = false;

                this.panelAlloyCalculator.Visible = true;
                this.panelAlloyCalculator.BringToFront();

                lvCalculatorInfo.Items.Clear();
                lvRecipeInfo.Items.Clear();
                ClearSiloText();
                btnAddition.Enabled = false;
                btnCheckLabValue.Enabled = false;
                SiloTableNameBind();
                SteelWgt_DataBind();
            }
            else
            {
                MessageBox.Show("尚未选择正在冶炼的炉次!请双击要选择炉次后再单击合金计算按钮!");
            }
        }

        /// <summary>
        /// 计算补加系数
        /// </summary>
        private void CalculateAppendCoefficent()
        {
            int i = 0;
            float[] TempData = new float[55];
            float Sum = 0;                             //各合金占有量之合
            float SteelData = 0;                       //纯钢水占有量 
            float AppendData = 0;                      //补加系数

            try
            {
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    if (IsNumber(item.SubItems[2].Text) && IsNumber(item.SubItems[7].Text))
                    {
                        TempData[i] = float.Parse(Math.Round(float.Parse(item.SubItems[2].Text) / float.Parse(item.SubItems[7].Text), 6).ToString());
                        Sum += TempData[i];
                        i++;
                    }
                }

                SteelData = 1 - Sum;

                i = 0;
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    AppendData = float.Parse(Math.Round(TempData[i] / SteelData, 6).ToString());
                    if (IsNumber(item.SubItems[2].Text) && IsNumber(item.SubItems[7].Text))
                    {
                        item.SubItems[9].Text = AppendData.ToString();
                        i++;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 计算合金补加量
        /// </summary>
        private void CalculateAppendAmount()
        {
            int i = 0;
            float[] TempAppend = new float[55];           //各合金初步添加量;
            float[] AlloyAppend = new float[55];          //各合金所需补加量;
            float[] FinalAppend = new float[55];          //各合金的最终添加量;
            float SumAppend = 0;                          //所有合金补加量之合;
            try
            {
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    if (IsNumber(item.SubItems[2].Text) && IsNumber(item.SubItems[4].Text) && IsNumber(item.SubItems[7].Text) && IsNumber(item.SubItems[8].Text))
                    {
                        TempAppend[i] = float.Parse(txtAlloyCalSteelWgt.Text.Trim()) * 1000 * (float.Parse(item.SubItems[2].Text) / 100 - float.Parse(item.SubItems[4].Text) / 100) / (float.Parse(item.SubItems[7].Text) / 100 * float.Parse(item.SubItems[8].Text) / 100);
                        SumAppend += TempAppend[i];
                        i++;
                    }
                }

                i = 0;
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    if (IsNumber(item.SubItems[9].Text))
                    {
                        AlloyAppend[i] = SumAppend * float.Parse(item.SubItems[9].Text);
                        FinalAppend[i] = AlloyAppend[i] + TempAppend[i];
                        i++;
                    }
                }

                i = 0;
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                    foreach (ListViewItem item1 in lvRecipeInfo.Items)
                    {
                        if (item.SubItems[6].Text == item1.SubItems[1].Text)
                        {
                            item1.UseItemStyleForSubItems = false;
                            item1.SubItems[3].Text = Math.Ceiling(FinalAppend[i]).ToString();
                            item1.SubItems[3].ForeColor = Color.Red;
                            i++;
                        }
                    }

                foreach (ListViewItem item in lvRecipeInfo.Items)
                {
                    if (item.SubItems[3].Text == "" || item.SubItems[3].Text == null)
                    {
                        item.SubItems[3].Text = "0";
                    }
                    if (float.Parse(item.SubItems[3].Text) < 0)
                    {
                        try
                        {
                            item.SubItems[3].Text = "0";
                        }
                        catch
                        {
                            item.SubItems[3].Text = "0";
                        }
                    }
                }

            }
            catch
            { }
        }

        /// <summary>
        /// 元素累加(查看合金反算值)
        /// </summary>
        /// 
        private void ElementAccumulate()
        {
            #region 计算合金
            float AdditionSum = 0;
            float TotalSteelWGT = 0;
            HeatQuality heatqualityBLL = new HeatQuality();
            Material materailBLL = new Material();
            IList<MaterialInfo> materialInfoList = materailBLL.GetAllMaterialInfos();
            string heatId = this.lblHeatId.Text.Trim();

            foreach (ListViewItem item in lvCalculatorInfo.Items)
            {
                if (!string.IsNullOrEmpty(item.SubItems[5].Text))
                {
                    item.SubItems[5].Text = "";
                }
            }

            foreach (ListViewItem item in lvRecipeInfo.Items)
            {
                if (IsNumber(item.SubItems[3].Text))
                {
                    AdditionSum += float.Parse(item.SubItems[3].Text);
                }
            }

            TotalSteelWGT = float.Parse(txtAlloyCalSteelWgt.Text.Trim()) * 1000 + AdditionSum;

            foreach (ListViewItem item in lvRecipeInfo.Items)
            {
                float materialYield = float.Parse(materialInfoList.Where(k => k.MaterialId.ToString() == item.SubItems[0].Text).First().Yield.ToString());
                IList<MaterialAnalysisInfo> materialList = materialInfoList.Where(k => k.MaterialId.ToString() == item.SubItems[0].Text).First().AnalysisList.ToList<MaterialAnalysisInfo>();
                foreach (MaterialAnalysisInfo info in materialList)
                {
                    foreach (ListViewItem item1 in lvCalculatorInfo.Items)
                    {
                        if (item1.SubItems[0].Text == info.ElemInfo.ElementFullName)
                        {
                            if (string.IsNullOrEmpty(item1.SubItems[5].Text))
                            {
                                float TempData = (float.Parse(txtAlloyCalSteelWgt.Text.Trim()) * 1000 * float.Parse(item1.SubItems[4].Text) / 100 +
                                   float.Parse(item.SubItems[3].Text) * float.Parse(info.NetContent.ToString()) / 100 * float.Parse(info.Yield.ToString()) / 100 * materialYield / 100) / TotalSteelWGT;
                                item1.SubItems[5].Text = Math.Round(TempData * 100, 4).ToString();
                            }
                            else
                            {
                                float TempData = (float.Parse(txtAlloyCalSteelWgt.Text.Trim()) * 1000 * float.Parse(item1.SubItems[4].Text) / 100 +
                                   float.Parse(item.SubItems[3].Text) * float.Parse(info.NetContent.ToString()) / 100 * float.Parse(info.Yield.ToString()) / 100 * materialYield / 100) / TotalSteelWGT;
                                float oldData = float.Parse(item1.SubItems[5].Text);
                                float redundantData = float.Parse(txtAlloyCalSteelWgt.Text.Trim()) * 1000 * float.Parse(item1.SubItems[4].Text) / 100 / TotalSteelWGT;
                                item1.SubItems[5].Text = Math.Round(TempData * 100 + oldData - redundantData * 100, 4).ToString();
                            }
                        }
                    }
                }
            }
            #endregion

            #region 计算公式
            SteelGradeDetailInfo steelInfo = null;
            steelInfo = getSteelGradeDetailInfo();
            MSScriptControl.ScriptControl sc = new ScriptControl();
            sc.Language = "JScript";
            Formula formulaBLL = new Formula();
            FormulaCalculator formulaCalBLL = new FormulaCalculator();
            IList<FormulaInfo> formulaList = formulaBLL.GetFormulaListByHeatId(heatId);
            if (formulaList.Count != 0)
            {
                steelInfo.FormulaInfos = formulaList;
            }
            IList<HeatQualityInfo> heatQualityList = heatqualityBLL.GetHeatQualityInfo(heatId);
            IList<QualityInfo> qualityInfoList = heatQualityList.OrderByDescending(i => i.MsgId).First().QualityList;
            IList<QualityInfo> newqualityInfoList = new List<QualityInfo>();
            foreach (QualityInfo Info in qualityInfoList)
            {
                newqualityInfoList.Add(Info);
            }

            //用计算化验值替换原来的化验值
            foreach (QualityInfo Info in newqualityInfoList)
            {
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    if (item.SubItems[5].Text != "")
                    {
                        if (item.SubItems[0].Text == Info.Element.ElementFullName)
                        {
                            Info.QualityValue = double.Parse(item.SubItems[5].Text);
                        }
                    }
                }
            }

            //重新计算公式
            foreach (QualityInfo qualityInfo in newqualityInfoList)
            {
                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    double minValue = Convert.ToDouble(item.SubItems[1].Text);
                    double maxValue = Convert.ToDouble(item.SubItems[3].Text);
                    double aimValue = Convert.ToDouble(item.SubItems[2].Text);
                    string elementFullName = qualityInfo.Element.ElementFullName;

                    if (qualityInfo.Element.ElementFullName == item.SubItems[0].Text)
                    {

                        if (qualityInfo.Element.ElementType == "ELEMENT" || qualityInfo.Element.ElementType == "COMPOUND")
                        {
                            double? qualityValue = qualityInfo.QualityValue;

                            if (item.SubItems[5].Text != "")
                            {
                                if (qualityValue.HasValue)
                                {
                                    if (qualityValue < minValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[5].BackColor = Color.PowderBlue;
                                    }
                                    else if (qualityValue > maxValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[5].BackColor = Color.Pink;
                                    }
                                    else if (qualityValue > aimValue)
                                    {
                                        item.UseItemStyleForSubItems = false;
                                        item.SubItems[5].BackColor = Color.Wheat;
                                    }
                                }
                            }
                        }

                        else if (qualityInfo.Element.ElementType == "FORMULA")
                        {
                            string digitalFormulaString = formulaCalBLL.FormulaParse(newqualityInfoList, elementFullName);
                            try
                            {
                                double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                item.SubItems[5].Text = result.ToString();

                                if (result < minValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.PowderBlue;
                                }
                                else if (result > maxValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.Pink;
                                }
                                else if (result > aimValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.Wheat;
                                }
                            }
                            catch
                            { }
                        }
                        else if (qualityInfo.Element.ElementType == "SPECIAL FORMULA")
                        {
                            try
                            {
                                FormulaInfo formula = steelInfo.FormulaInfos.Single<FormulaInfo>(k => k.FormulaType.ToUpper() == elementFullName);
                                string digitalFormulaString = formulaCalBLL.FormulaParse(newqualityInfoList, formula.Formula);
                                double result = Convert.ToDouble(sc.Eval(digitalFormulaString));
                                item.SubItems[5].Text = Math.Round(result, 5).ToString();


                                if (result < minValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.PowderBlue;
                                }
                                else if (result > maxValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.Pink;
                                }
                                else if (result > aimValue)
                                {
                                    item.UseItemStyleForSubItems = false;
                                    item.SubItems[5].BackColor = Color.Wheat;
                                }
                            }
                            catch
                            { }
                        }
                    }

                }
            }
            #endregion
        }

        private bool IsNumber(string MyStr)
        {
            try
            {
                float i = Convert.ToSingle(MyStr);
                return (true);
            }
            catch
            {
                return (false);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlloyCalSteelWgt.Text))
            {
                MessageBox.Show("钢水重量不能为空!请填写后重新点击计算按钮!");
            }
            else
            {
                try
                {
                    CalculateAppendCoefficent();
                    CalculateAppendAmount();
                    ElementAccumulate();

                    foreach (ListViewItem item in lvRecipeInfo.Items)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            string LabelName = "lblContainer";
                            object obj = (System.Windows.Forms.Label)this.Controls.Find(LabelName + (i + 1).ToString(), true)[0];
                            Label myLabel = obj as Label;
                            int index = myLabel.Text.IndexOf(":");

                            string TextBoxName = "txtCalculate";
                            object obj1 = (System.Windows.Forms.TextBox)this.Controls.Find(TextBoxName + (i + 1).ToString(), true)[0];
                            TextBox myTextBox = obj1 as TextBox;

                            if (item.SubItems[1].Text == myLabel.Text.Remove(0, index + 1))
                            {
                                myTextBox.Text = item.SubItems[3].Text;
                                myTextBox.ReadOnly = false;
                            }
                            btnCheckLabValue.Enabled = true;
                            btnEnsureAdd.Enabled = true;
                        }
                    }
                }
                catch
                { }
            }
        }

        private void btnCheckLabValue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAlloyCalSteelWgt.Text))
            {
                MessageBox.Show("钢水重量不能为空!请填写后重新点击查看按钮!");
            }
            else
            {
                try
                {
                    ElementAccumulate();
                }
                catch
                { }
            }
        }

        #region <显示按钮功能说明>
        private void btnCalculate_MouseHover(object sender, EventArgs e)
        {
            lblBtnInfo1.Visible = true;
            lblBtnInfo1.Left = System.Windows.Forms.Cursor.Position.X - btnCalculate.Width / 2;
            lblBtnInfo1.Top = System.Windows.Forms.Cursor.Position.Y - 260 + btnCalculate.Height;
        }

        private void btnCalculate_MouseLeave(object sender, EventArgs e)
        {
            lblBtnInfo1.Visible = false;
        }

        private void btnCheckLabValue_MouseHover(object sender, EventArgs e)
        {
            lblBtnInfo2.Visible = true;
            lblBtnInfo2.Left = System.Windows.Forms.Cursor.Position.X - btnCheckLabValue.Width / 2;
            lblBtnInfo2.Top = System.Windows.Forms.Cursor.Position.Y - 260 + btnCheckLabValue.Height;
        }

        private void btnCheckLabValue_MouseLeave(object sender, EventArgs e)
        {
            lblBtnInfo2.Visible = false;
        }
        #endregion

        private void btnEnsureAdd_Click(object sender, EventArgs e)
        {
            double[] AlloyAdditoin = new double[20];
            for (int i = 0; i < 20; i++)
            {
                string TextBoxName = "txtCalculate";
                object obj = (System.Windows.Forms.TextBox)this.Controls.Find(TextBoxName + (i + 1).ToString(), true)[0];
                TextBox myTextBox = obj as TextBox;

                string TextBoxName1 = "txtRealData";
                object obj1 = (System.Windows.Forms.TextBox)this.Controls.Find(TextBoxName1 + (i + 1).ToString(), true)[0];
                TextBox myTextBox1 = obj1 as TextBox;

                if (string.IsNullOrEmpty(myTextBox.Text))
                {
                    AlloyAdditoin[i] = 0;
                }
                else
                {
                    AlloyAdditoin[i] = double.Parse(myTextBox.Text);
                    myTextBox1.Text = myTextBox.Text;
                }
            }

            int carId = int.Parse(lblCar.Text);
            Source sourceBLL = new Source();
            sourceBLL.UpdateOpcSiloCalculateValue(AlloyAdditoin, carId);
        }

        private void btnAlloyRecpieSelect_Click(object sender, EventArgs e)
        {
            try
            {
                AlloyRecipeSelectForm alloyRecipeSelectForm = new AlloyRecipeSelectForm();
                alloyRecipeSelectForm.ShowDialog();
                Recipe recipeBLL = new Recipe();
                IList<RecipeInfo> recipeInfoList = recipeBLL.GetMaterialRecipe().ToList<RecipeInfo>();
                IList<RecipeMaterialInfo> materialRecipeList = recipeInfoList.Where(i => i.RecipeId.ToString() == "1").First().RecipeMaterialInfo;

                btnCheckLabValue.Enabled = false;
                btnEnsureAdd.Enabled = false;
                lvAlloyCalculator_DataBind();
                lvRecipeInfo.Items.Clear();
                ClearSiloText();
                foreach (RecipeMaterialInfo Info in materialRecipeList)
                {
                    ListViewItem item = new ListViewItem(Info.MaterialInfo.MaterialId.ToString());
                    item.SubItems.Add(Info.MaterialInfo.MaterialName);
                    item.SubItems.Add("KG");
                    item.SubItems.Add("");
                    lvRecipeInfo.Items.Add(item);
                }

                foreach (ListViewItem item in lvCalculatorInfo.Items)
                {
                    foreach (RecipeMaterialInfo Info in materialRecipeList)
                    {
                        if (item.SubItems[0].Text == Info.ChiefElementInfo.ElementShortName)
                        {
                            item.SubItems[6].Text = Info.MaterialInfo.MaterialName;
                            item.SubItems[7].Text = Info.ChiefElementContent.ToString();
                            item.SubItems[8].Text = Info.MaterialInfo.Yield.ToString();
                        }
                    }
                }
            }
            catch
            {
                string errorMsg = "选择物料信息有误！\r\n";
                errorMsg += "可能的原因：您选择了某种物料，但是数据库中没有该物料的元素定义信息！\r\n";
                errorMsg += "请您在<物料信息管理>界面中查看您选择的物料的元素定义信息，确认所选物料都存在元素定义信息后重新尝试！";
                MessageBox.Show(errorMsg);
            }
        }

        private void lvCalculatorInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCalculatorInfo.SelectedItems.Count > 0)
            {
                txtAnalysisAim.Text = lvCalculatorInfo.SelectedItems[0].SubItems[2].Text;
                txtAnalysisMax.Text = lvCalculatorInfo.SelectedItems[0].SubItems[3].Text;
                txtAnalysisMin.Text = lvCalculatorInfo.SelectedItems[0].SubItems[1].Text;
                lblAnalysisEleName.Text = "元素名称:" + lvCalculatorInfo.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void btnAlloyCalAnalysisModify_Click(object sender, EventArgs e)
        {
            if (lvCalculatorInfo.Items.Count > 0)
            {
                if (btnAlloyCalAnalysisModify.Text == "修改")
                {
                    txtAnalysisAim.ReadOnly = false;
                    txtAnalysisMax.ReadOnly = false;
                    txtAnalysisMin.ReadOnly = false;
                    btnAlloyCalAnalysisModify.Text = "确定";
                }
                else if (btnAlloyCalAnalysisModify.Text == "确定")
                {
                    txtAnalysisAim.ReadOnly = true;
                    txtAnalysisMax.ReadOnly = true;
                    txtAnalysisMin.ReadOnly = true;
                    btnAlloyCalAnalysisModify.Text = "修改";
                }
            }
            else
            {
                MessageBox.Show("尚未选择合金加料配方,请先选择加料配方后,再进行修改操作!");
            }
        }

        #endregion
    }
}