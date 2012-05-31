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
    public partial class FormulaChooseForm : Form
    {
        private Formula formula;
        public IList<FormulaInfo> chooseFormulaList;
        private IList<FormulaInfo> existFormulaInfos;

        public FormulaChooseForm()
        {
            InitializeComponent();
            formula = new Formula();
            chooseFormulaList = new List<FormulaInfo>();
            existFormulaInfos = new List<FormulaInfo>();
        }
        public FormulaChooseForm(IList<FormulaInfo> formulaInfos)
        {
            InitializeComponent();
            formula = new Formula();
            chooseFormulaList = new List<FormulaInfo>();
            existFormulaInfos = formulaInfos;
        }
        private void FormulaChooseForm_Load(object sender, EventArgs e)
        {
            refresh_lvFormulaInfos();
        }
        private void refresh_lvFormulaInfos()
        {
            lvFormulaInfos.Items.Clear();
            IList<FormulaInfo> formulaList = formula.GetAllFormulaInfo();
            foreach (FormulaInfo info in formulaList)
            {
                ListViewItem item = new ListViewItem("");
                foreach (FormulaInfo existInfo in existFormulaInfos)
                {
                    if (info.FormulaId == existInfo.FormulaId)
                    {
                        item.Checked = true;
                    }
                }
                item.SubItems.Add(info.FormulaId);
                item.SubItems.Add(info.FormulaType);
                item.SubItems.Add(info.Formula);
                lvFormulaInfos.Items.Add(item);
            }
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

        private void btnCloseFormula_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNewModifyFoumula_Click(object sender, EventArgs e)
        {
            FormulaInfoForm formulaInfoForm = new FormulaInfoForm();
            formulaInfoForm.ShowDialog();
            foreach (ListViewItem item in lvFormulaInfos.Items)
            {
                if (item.Checked == true)
                {
                    existFormulaInfos.Clear();
                    FormulaInfo formulaInfo = new FormulaInfo(item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text);
                    existFormulaInfos.Add(formulaInfo);
                }
            }
            refresh_lvFormulaInfos();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            chooseFormulaList.Clear();
            foreach (ListViewItem item in lvFormulaInfos.Items)
            {
                if (item.Checked == true)
                {
                    FormulaInfo formulaInfo = new FormulaInfo(item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text);
                    chooseFormulaList.Add(formulaInfo);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lvFormulaInfos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked==true)
            {
                foreach (ListViewItem item in lvFormulaInfos.Items)
                {
                    if (item.Checked == true && item.SubItems[1].Text != e.Item.SubItems[1].Text)
                    {
                        if (item.SubItems[2].Text == e.Item.SubItems[2].Text)
                        {
                            e.Item.Checked = false;
                            MessageBox.Show("每种类别的公式仅允许选择一种，请不要重复选择！");
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

    }
}
