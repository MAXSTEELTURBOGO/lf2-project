using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LFAutomationUI.Model;
using LFAutomationUI.BLL;

namespace LFAutomationUI.LFUI
{
    public partial class EuipmentInfoForm : Form
    {
        private IList<EquipmentInfo> equipmentList;

        public EuipmentInfoForm()
        {
            InitializeComponent();
        }

        private void EuipmentInfoForm_Load(object sender, EventArgs e)
        {

            loadForm();
        }

        private void loadForm()
        {
            Equipment equipmentBLL = new Equipment();
            equipmentList = equipmentBLL.GetAllEquipmentInfo();
            this.lvEquipmentInfo.Items.Clear();
            foreach (EquipmentInfo item in equipmentList)
            {
                ListViewItem lvItem = new ListViewItem(item.EquipmentName);
                lvItem.SubItems.Add(item.EquipmentAge.ToString());
                lvItem.SubItems.Add(item.EquipmentDescription);
                lvEquipmentInfo.Items.Add(lvItem);
            }

        }
        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void btnResetEquipmentAge_Click(object sender, EventArgs e)
        {
            EquipmentInfo equipment = equipmentList.Single<EquipmentInfo>(i => i.EquipmentName == this.lvEquipmentInfo.SelectedItems[0].Text);

            if (MessageBox.Show("你确定更换该设备吗?\n更换设备将使得该设备寿命归零", "确认更换设备", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                equipment.EquipmentAge = 0;
                Equipment equipmentBLL = new Equipment();
                equipmentBLL.UpdateEquipmentInfo(equipment);
                MessageBox.Show("设备更换成功!", "提示");
                loadForm();
                this.btnEditEquipment.Enabled = false;
                this.btnResetEquipmentAge.Enabled = false;
            }
        }

        private void lvEquipmentInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvEquipmentInfo.SelectedItems.Count == 1)
            {
                EquipmentInfo equipment = equipmentList.Single<EquipmentInfo>(i => i.EquipmentName == this.lvEquipmentInfo.SelectedItems[0].Text);
                this.lblEquipmentName.Text = equipment.EquipmentName;
                this.txtEquipmentAge.Text = equipment.EquipmentAge.ToString();
                this.txtEquipmentDescription.Text = equipment.EquipmentDescription;

                this.btnResetEquipmentAge.Enabled = true;
                this.btnEditEquipment.Enabled = true;
            }
            else
            {
                this.btnResetEquipmentAge.Enabled = false;
                this.btnEditEquipment.Enabled = false;
            }
        }

        private void setEditMode()
        {
            this.txtEquipmentAge.ReadOnly = false;
            this.txtEquipmentDescription.ReadOnly = false;
            this.lvEquipmentInfo.Enabled = false;

            this.btnResetEquipmentAge.Enabled = false;
            this.btnOK.Enabled = true;
            this.btnCancel.Enabled = true;
        }

        private void clearEditMode()
        {
            this.txtEquipmentAge.ReadOnly = true;
            this.txtEquipmentDescription.ReadOnly = true;
            this.lvEquipmentInfo.Enabled = true;

            this.btnOK.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        private void btnEditEquipment_Click(object sender, EventArgs e)
        {
            setEditMode();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearEditMode();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.lblEquipmentName.Text.Trim()))
            {
                EquipmentInfo equipment = equipmentList.Single<EquipmentInfo>(i => i.EquipmentName == this.lvEquipmentInfo.SelectedItems[0].Text);
                Equipment equipmentBLL = new Equipment();
                if (MessageBox.Show("你确定要更新" + equipment.EquipmentName + "的设备信息吗?", "确认更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string pattern = @"^\d{1,10}$";
                    if (Regex.IsMatch(this.txtEquipmentAge.Text.Trim(), pattern))
                    {
                        int equipmentAge = Convert.ToInt32(this.txtEquipmentAge.Text.Trim());
                        pattern = @"^.{1,100}$";
                        if (Regex.IsMatch(this.txtEquipmentDescription.Text.Trim(), pattern))
                        {
                            string equipmentDescription = this.txtEquipmentDescription.Text.Trim();
                            equipment.EquipmentAge = equipmentAge;
                            equipment.EquipmentDescription = equipmentDescription;
                            equipmentBLL.UpdateEquipmentInfo(equipment);
                            MessageBox.Show("设备信息更新成功", "提示");
                            this.btnEditEquipment.Enabled = false;
                            clearEditMode();
                            loadForm();
                        }
                        else
                        {
                            MessageBox.Show("设备描述必须为1-100位的字符序列", "提示");
                        }
                    }
                    else
                    {
                        MessageBox.Show("设备寿命必须为证书", "提示");
                    }
                }
            }
        }

    }
}
