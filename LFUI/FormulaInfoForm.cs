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
    public partial class FormulaInfoForm : Form
    {
        private Formula formula;
        public FormulaInfoForm()
        {
            InitializeComponent();
            formula = new Formula();
        }

        private void FormulaInfoForm_Load(object sender, EventArgs e)
        {
            refresh_LvFormulaInfos();
        }

        private void refresh_LvFormulaInfos()
        {
            IList<FormulaInfo> formulaInfos = formula.GetAllFormulaInfo();
            lvFormulaInfos.Items.Clear();
            foreach (FormulaInfo info in formulaInfos)
            {
                ListViewItem item = new ListViewItem(info.FormulaId);
                item.SubItems.Add(info.FormulaType);
                item.SubItems.Add(info.Formula);
                lvFormulaInfos.Items.Add(item);
            }
        }

        private void btnCloseFormula_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvFormulaInfos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvFormulaInfos.SelectedItems.Count > 0)
            {
                this.txtFormulaId.Text = lvFormulaInfos.SelectedItems[0].SubItems[0].Text;
                this.txtFormulaType.Text = lvFormulaInfos.SelectedItems[0].SubItems[1].Text;
                this.txtFormula.Text = lvFormulaInfos.SelectedItems[0].SubItems[2].Text;
            }
            else
            {
                this.txtFormulaId.Text = "";
                this.txtFormulaType.Text = "";
                this.txtFormula.Text = "";
            }
        }

        private void btnNewFoumula_Click(object sender, EventArgs e)
        {
            txtFormulaId.Text = "";
            txtFormulaType.Text = "";
            txtFormula.Text = "";
            txtFormulaId.ReadOnly = false;
            txtFormulaType.ReadOnly = false;
            txtFormula.ReadOnly = false;
            btnNewFoumula.Enabled = false;
            btnModifyFormula.Enabled = false;
            btnConfirmFormula.Enabled = true;
            btnCancelFormula.Enabled = true;
        }

        private void btnModifyFormula_Click(object sender, EventArgs e)
        {
            txtFormulaType.ReadOnly = false;
            txtFormula.ReadOnly = false;
            btnNewFoumula.Enabled = false;
            btnModifyFormula.Enabled = false;
            btnConfirmFormula.Enabled = true;
            btnCancelFormula.Enabled = true;
        }

        private void btnConfirmFormula_Click(object sender, EventArgs e)
        {
            FormulaInfo formulaInfo = new FormulaInfo(txtFormulaId.Text, txtFormulaType.Text, txtFormula.Text);
            bool check = formulaCheck(txtFormula.Text);
            if (check==true)
            {
                if (txtFormulaId.ReadOnly == false) //新增
                {
                    formula.InsertNewFormula(formulaInfo);
                }
                else //修改
                {
                    formula.UpdateFormula(formulaInfo);
                }
                cancelEditMode();
            }
            else
            {
                MessageBox.Show("您输入的公式无法进行计算，请检查公式格式是否符合要求！");
            }    
        }

        private void btnCancelFormula_Click(object sender, EventArgs e)
        {
            cancelEditMode();
        }

        private void cancelEditMode()
        {
            txtFormulaId.Text = "";
            txtFormulaType.Text = "";
            txtFormula.Text = "";
            txtFormulaId.ReadOnly = true;
            txtFormulaType.ReadOnly = true;
            txtFormula.ReadOnly = true;
            btnNewFoumula.Enabled = true;
            btnModifyFormula.Enabled = true;
            btnConfirmFormula.Enabled = false;
            btnCancelFormula.Enabled = false;
            refresh_LvFormulaInfos();
        }

        /// <summary>
        /// 判断输入的公式能否进行计算
        /// </summary>
        /// <param name="formula">公式</param>
        /// <returns>正确：ture 错误：false</returns>
        private bool formulaCheck(string formula)
        {
            try
            {
                string parseFormula = formula;
                parseFormula = Regex.Replace(parseFormula, "（", "(");
                parseFormula = Regex.Replace(parseFormula, "）", ")");
                parseFormula = Regex.Replace(parseFormula, "＋", "+");
                parseFormula = Regex.Replace(parseFormula, "－", "-");
                parseFormula = Regex.Replace(parseFormula, "＊", "*");
                parseFormula = Regex.Replace(parseFormula, "／", "/");
                parseFormula = Regex.Replace(parseFormula.ToString(), @"[a-zA-Z]+", "1", RegexOptions.IgnoreCase);
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "JScript";
                sc.Eval(parseFormula);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
