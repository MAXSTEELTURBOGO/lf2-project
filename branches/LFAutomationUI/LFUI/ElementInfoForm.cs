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
    public partial class ElementInfoForm : Form
    {
        Element elementBLL;
        IList<ElementInfo> elementList;
        /// <summary>
        /// 判断数字正则表达式（1-3位） “\d”等价于“[0-9]”
        /// </summary>
        private string pattern = @"\b\d{1,3}\b";
        /// <summary>
        /// 初始化窗口方法
        /// </summary>
        public ElementInfoForm()
        {
            elementBLL = new Element();
            elementList = elementBLL.GetElementList();
            InitializeComponent();
            cmbElementType.Enabled = false;
        }
        /// <summary>
        /// 窗口加载方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementInfoMaintenanceUI_Load(object sender, EventArgs e)
        {
            lvElementInfo_DataBind();
        }
        /// <summary>
        /// lvElementInfo数据绑定方法
        /// </summary>
        /// <param name="elementInfos">元素信息</param>
        private void lvElementInfo_DataBind()
        {
            elementList = (from i in elementList
                           select i).OrderBy(i => i.ViewSequence).ToList<ElementInfo>();
            lvElementInfo.Items.Clear();
            foreach (ElementInfo elementInfo in elementList)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = elementInfo.ElementId.ToString();
                item.SubItems.Add(elementInfo.ElementShortName);
                item.SubItems.Add(elementInfo.ElementFullName);
                item.SubItems.Add(elementInfo.ElementType);
                item.SubItems.Add(elementInfo.ViewSequence.ToString());
                item.SubItems.Add(elementInfo.FixedRatio.ToString());
                lvElementInfo.Items.Add(item);
            }
        }
        /// <summary>
        /// 当选择lvElementInfo中的某一项时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvElementInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvElementInfo.SelectedItems.Count > 0)
            {
                txtElementId.Text = this.lvElementInfo.SelectedItems[0].SubItems[0].Text;
                txtElementShortName.Text = this.lvElementInfo.SelectedItems[0].SubItems[1].Text;
                txtElementFullName.Text = this.lvElementInfo.SelectedItems[0].SubItems[2].Text;
                cmbElementType.Text = this.lvElementInfo.SelectedItems[0].SubItems[3].Text;
                txtApearanceOrder.Text = this.lvElementInfo.SelectedItems[0].SubItems[4].Text;
                txtCalModify.Text = this.lvElementInfo.SelectedItems[0].SubItems[5].Text;
                btnDeleteElementInfo.Enabled = true;
            }
            else
            {
                btnDeleteElementInfo.Enabled = false;
                return;
            }
        }
        /// <summary>
        /// “增加”按钮调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewElementInfo_Click(object sender, EventArgs e)
        {
            txtElementId.ReadOnly = false;
            setEditMode();
            clearControls();
        }
        /// <summary>
        /// “修改”按钮调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyElementInfo_Click(object sender, EventArgs e)
        {
            if (txtElementId.Text == "")
            {
                MessageBox.Show("请选择要更新的元素！");
                return;
            }
            else
            {
                setEditMode();
            }
        }
        private void btnDeleteElementInfo_Click(object sender, EventArgs e)
        {
            Element element = new Element();
            if (txtElementId.Text == "")
            {
                MessageBox.Show("请选择要删除的元素！");
                return;
            }
            else
            {
                element.DeleteElementInfoByElementId(Convert.ToInt32(txtElementId.Text));
                clearControls();
                elementList = elementBLL.GetElementList();
                lvElementInfo_DataBind();
                MessageBox.Show("你选择的元素已删除！");
            }
        }
        /// <summary>
        /// “确认”按钮调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtElementId.ReadOnly == false)
            {
                //利用正则表达式判断填入的ElementId是否为数字
                if (Regex.IsMatch(txtElementId.Text, pattern))
                {
                    if (elementBLL.GetElementInfoByElementId(Convert.ToInt32(txtElementId.Text)) == null)
                    {
                        if (!string.IsNullOrEmpty(txtElementId.Text) && !string.IsNullOrEmpty(txtElementShortName.Text) && !string.IsNullOrEmpty(txtElementFullName.Text)
                            && !string.IsNullOrEmpty(cmbElementType.Text) && !string.IsNullOrEmpty(txtApearanceOrder.Text) && !string.IsNullOrEmpty(txtCalModify.Text))
                        {
                            if (formulaCheck(txtElementFullName.Text))
                            {
                                ElementInfo elementInfo = new ElementInfo(Convert.ToInt32(txtElementId.Text), txtElementShortName.Text, txtElementFullName.Text,
                                            cmbElementType.Text, Convert.ToDecimal(txtApearanceOrder.Text), Convert.ToDouble(txtCalModify.Text));
                                elementBLL.InsertElementInfo(elementInfo);
                                clearControls();
                                resetEditMode();
                                elementList = elementBLL.GetElementList();
                                lvElementInfo_DataBind();
                            }
                            else
                            {
                                MessageBox.Show("您输入的元素全称不符合格式要求，请重新输入！");
                                return;
                            }
                        }
                        else if (string.IsNullOrEmpty(txtElementId.Text))
                        {
                            MessageBox.Show("请填写元素号！");
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtElementShortName.Text))
                        {
                            MessageBox.Show("请填写元素简称！");
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtElementFullName.Text))
                        {
                            MessageBox.Show("请填写元素全称！");
                            return;
                        }
                        else if (string.IsNullOrEmpty(cmbElementType.Text))
                        {
                            MessageBox.Show("请选择元素类型！");
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtApearanceOrder.Text))
                        {
                            MessageBox.Show("请填写显示顺序！");
                            return;
                        }
                        else if (string.IsNullOrEmpty(txtCalModify.Text))
                        {
                            MessageBox.Show("请填写该元素计算校正值，如没有则填写 0 ！");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("该元素号已存在！");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("元素号必须为数字！请重新填写。");
                    return;
                }
            }
            else if (txtElementId.ReadOnly == true)
            {
                if (!string.IsNullOrEmpty(txtElementId.Text) && !string.IsNullOrEmpty(txtElementShortName.Text) && !string.IsNullOrEmpty(txtElementFullName.Text)
                            && !string.IsNullOrEmpty(cmbElementType.Text) && !string.IsNullOrEmpty(txtApearanceOrder.Text) && !string.IsNullOrEmpty(txtCalModify.Text))
                {
                    if (formulaCheck(txtElementFullName.Text))
                    {
                        ElementInfo elementInfo = new ElementInfo(Convert.ToInt32(txtElementId.Text), txtElementShortName.Text, txtElementFullName.Text,
                                            cmbElementType.Text, Convert.ToDecimal(txtApearanceOrder.Text), Convert.ToDouble(txtCalModify.Text));
                        //更新：先删除 再插入
                        elementBLL.DeleteElementInfoByElementId(Convert.ToInt32(txtElementId.Text));
                        elementBLL.InsertElementInfo(elementInfo);
                        clearControls();
                        resetEditMode();
                        elementList = elementBLL.GetElementList();
                        lvElementInfo_DataBind();
                    }
                    else
                    {
                        MessageBox.Show("您输入的元素全称不符合格式要求，请重新输入！");
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(txtElementId.Text))
                {
                    MessageBox.Show("请填写元素号！");
                    return;
                }
                else if (string.IsNullOrEmpty(txtElementShortName.Text))
                {
                    MessageBox.Show("请填写元素简称！");
                    return;
                }
                else if (string.IsNullOrEmpty(txtElementFullName.Text))
                {
                    MessageBox.Show("请填写元素全称！");
                    return;
                }
                else if (string.IsNullOrEmpty(cmbElementType.Text))
                {
                    MessageBox.Show("请选择元素类型！");
                    return;
                }
                else if (string.IsNullOrEmpty(txtApearanceOrder.Text))
                {
                    MessageBox.Show("请填写显示顺序！");
                    return;
                }
                else if (string.IsNullOrEmpty(txtCalModify.Text))
                {
                    MessageBox.Show("请填写该元素计算校正值，如没有则填写 0 ！");
                    return;
                }
            }
        }
        /// <summary>
        /// "取消"按键调用的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearControls();
            resetEditMode();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void setEditMode()
        {
            txtElementShortName.ReadOnly = false;
            txtElementFullName.ReadOnly = false;
            txtApearanceOrder.ReadOnly = false;
            txtCalModify.ReadOnly = false;
            cmbElementType.Enabled = true;
            lvElementInfo.Enabled = false;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
            btnDeleteElementInfo.Enabled = false;
            btnAddNewElementInfo.Enabled = false;
            btnModifyElementInfo.Enabled = false;
        }

        private void resetEditMode()
        {
            txtElementId.ReadOnly = true;
            txtElementShortName.ReadOnly = true;
            txtElementFullName.ReadOnly = true;
            txtApearanceOrder.ReadOnly = true;
            txtCalModify.ReadOnly = true;
            lvElementInfo.Enabled = true;
            cmbElementType.Enabled = false;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            btnDeleteElementInfo.Enabled = true;
            btnAddNewElementInfo.Enabled = true;
            btnModifyElementInfo.Enabled = true;
        }

        private void clearControls()
        {
            txtElementId.Text = "";
            txtElementShortName.Text = "";
            txtElementFullName.Text = "";
            txtApearanceOrder.Text = "";
            txtCalModify.Text = "";
            cmbElementType.Text = "";
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
