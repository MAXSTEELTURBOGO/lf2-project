using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LFAutomationUI.BLL;
using LFAutomationUI.Model;

namespace LFAutomationUI.LFUI
{
    public partial class AdditionForm : Form
    {
        private LFHeatInfo lfHeat;
        private IList<MaterialInfo> materialList;
        public AdditionForm(LFHeatInfo lfHeat)
        {
            InitializeComponent();
            this.lfHeat = lfHeat;
        }

        private void AdditionForm_Load(object sender, EventArgs e)
        {
            this.lblHeatId.Text = lfHeat.HeatId;
            this.lblTreatmentCount.Text = lfHeat.TreatmentCount.ToString();

            Material materialBLL=new Material();
            materialList = materialBLL.GetAllMaterialInfos();
            foreach (MaterialInfo material in materialList)
            {
                this.cmbMaterialName.Items.Add(material.MaterialName);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.cmbMaterialName.Text))
            {
                MessageBox.Show("物料名称不能为空!", "错误提示");
            }
            else
            {
                if (Regex.IsMatch(this.txtAdditionAmount.Text.Trim(), @"[0-9]{1,4}"))
                {
                    string materialName = this.cmbMaterialName.Text.ToString();
                    MaterialInfo material = materialList.Single<MaterialInfo>(i=> i.MaterialName == materialName);
                    DateTime additionTime = this.dptAdditionTime.Value;
                    int additionAmount = Convert.ToInt16(this.txtAdditionAmount.Text.Trim());
                    AdditionRecordInfo addition = new AdditionRecordInfo();
                    addition.HeatId = lfHeat.HeatId;
                    addition.TreatmentCount = lfHeat.TreatmentCount;
                    addition.SiloId = null;
                    addition.AdditionMaterialId = material.MaterialId;
                    addition.AdditionAmount = additionAmount;
                    addition.AdditionTime = additionTime;

                    string msg = "炉次号:" + lfHeat.HeatId + " 冶炼次数:" + lfHeat.TreatmentCount.ToString() + " \n物料名称:" + material.MaterialName + " 加料重量:" + additionAmount.ToString() + " 加料时间:" + dptAdditionTime.Value.ToString() + "\n 你确定添加该条加料记录吗?";
                    if (MessageBox.Show(msg,"确认提示",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AdditionRecord additionBLL = new AdditionRecord();
                        additionBLL.InsertAdditionRecord(addition);
                        MessageBox.Show("加料记录添加成功!", "提示");
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("加料重量必须为1-4位的数字","错误提示");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.DialogResult == DialogResult.No || this.DialogResult == DialogResult.Yes)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
