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
using System.Text.RegularExpressions;

namespace LFAutomationUI.LFUI
{
    public partial class SourceForm : Form
    {
        private Source sourceBLL;
        private Material materialBLL;
        public SourceForm()
        {
            InitializeComponent();
            sourceBLL = new Source();
            materialBLL = new Material();
        }
        private void SourceForm_Load(object sender, EventArgs e)
        {
            cmbMaterialName_DataBind();
            lvSourceInfo_DataBind();
        }
        private void lvSourceInfo_DataBind()
        {
            IList<SourceInfo> sourceList = sourceBLL.GetSourceInfo();
            foreach (SourceInfo source in sourceList)
            {
                ListViewItem item = new ListViewItem(source.SourceType);
                item.SubItems.Add(source.SourceId.ToString());
                item.SubItems.Add(source.MaterialName);
                lvSourceInfo.Items.Add(item);
            }
        }
        private void cmbMaterialName_DataBind()
        {
            IList<MaterialInfo> materialInfos = materialBLL.GetAllMaterialInfos();
            foreach (MaterialInfo materialInfo in materialInfos)
            {
                cmbMaterialName.Items.Add(materialInfo.MaterialName);
            }
        }

        private void btnModifyElementInfo_Click(object sender, EventArgs e)
        {
            if (txtSourceId.Text != "")
            {
                this.btnConfirm.Enabled = true;
                this.btnCancel.Enabled = true;
                this.btnModifyElementInfo.Enabled = false;
                this.lvSourceInfo.Enabled = false;
                this.cmbMaterialName.Enabled = true;
            }
            else
            {
                MessageBox.Show("请先选择要修改的物料来源信息！");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.txtSourceId.Text, "^[0-9]{1,2}$") && !string.IsNullOrEmpty(cmbMaterialName.Text) && !string.IsNullOrEmpty(this.cmbSourceType.Text))
            {
                SourceInfo source= new SourceInfo();
                source.SourceType = this.cmbSourceType.Text;
                source.SourceId = Convert.ToInt32(this.txtSourceId.Text.Trim());
                source.MaterialName = this.cmbMaterialName.Text;

                sourceBLL.UpdataSourceInfo(source);
                sourceBLL.UpdataOPCSiloInfo();
                this.btnConfirm.Enabled = false;
                this.btnCancel.Enabled = false;
                this.btnModifyElementInfo.Enabled = true;
                this.lvSourceInfo.Enabled = true;
                this.cmbMaterialName.Enabled = false;
                lvSourceInfo.Items.Clear();
                lvSourceInfo_DataBind();
            }
            else
            {
                MessageBox.Show("物料来源类型和物料名称均不能为空,来源号值为1-2位的数字", "错误提示");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.btnConfirm.Enabled = false;
            this.btnCancel.Enabled = false;
            this.btnModifyElementInfo.Enabled = true;
            this.lvSourceInfo.Enabled = true;
            this.cmbMaterialName.Enabled = false;
            lvSourceInfo.Items.Clear();
            lvSourceInfo_DataBind();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvSiloInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSourceInfo.SelectedItems.Count > 0)
            {
                cmbSourceType.Text = lvSourceInfo.SelectedItems[0].SubItems[0].Text;
                txtSourceId.Text = lvSourceInfo.SelectedItems[0].SubItems[1].Text;
                cmbMaterialName.Text = lvSourceInfo.SelectedItems[0].SubItems[2].Text;
            }
        }
    }
}
