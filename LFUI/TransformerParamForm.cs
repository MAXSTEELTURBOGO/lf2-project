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
    public partial class TransformerParamForm : Form
    {
        TransformerParam transformerParam = new TransformerParam();
        public TransformerParamForm()
        {
            InitializeComponent();
        }
        private void TransformerParamMaintenanceForm_Load(object sender, EventArgs e)
        {
            lvTransParamInfo_DataBind();
        }
        private void lvTransParamInfo_DataBind()
        {
            IList<TransformerParamInfo> transformerInfos = transformerParam.GetAllTransFormerParamInfo();
            foreach (TransformerParamInfo transformerInfo in transformerInfos)
            {
                ListViewItem item = new ListViewItem(transformerInfo.TapPosition.ToString());
                item.SubItems.Add(transformerInfo.TapPositionPoint.ToString());
                item.SubItems.Add(transformerInfo.Voltage.ToString());
                item.SubItems.Add(transformerInfo.Current.ToString());
                item.SubItems.Add(transformerInfo.TempPerMin.ToString());
                item.SubItems.Add(transformerInfo.Power.ToString());
                lvTransParamInfo.Items.Add(item);
            }
        }

        private void btnAddNewElementInfo_Click(object sender, EventArgs e)
        {
            txtTapPosition.ReadOnly = false;
            txtTapPositionPoint.ReadOnly = false;
            txtCurrent.ReadOnly = false;
            txtVoltage.ReadOnly = false;
            txtTempPerMin.ReadOnly = false;
            txtPower.ReadOnly = false;
            btnCancel.Enabled = true;
            btnConfirm.Enabled = true;
            btnDeleteElementInfo.Enabled = false;
            btnModifyElementInfo.Enabled = false;
            btnAddNewElementInfo.Enabled = false;
        }

        private void btnModifyElementInfo_Click(object sender, EventArgs e)
        {
            txtCurrent.ReadOnly = false;
            txtVoltage.ReadOnly = false;
            txtTempPerMin.ReadOnly = false;
            txtPower.ReadOnly = false;
            btnCancel.Enabled = true;
            btnConfirm.Enabled = true;
            btnDeleteElementInfo.Enabled = false;
            btnModifyElementInfo.Enabled = false;
            btnAddNewElementInfo.Enabled = false;
        }

        private void btnDeleteElementInfo_Click(object sender, EventArgs e)
        {
            transformerParam.DelTransParamInfoByTapPositionAndTapPoint(Convert.ToInt32(txtTapPosition.Text), Convert.ToInt32(txtTapPositionPoint.Text));
            lvTransParamInfo.Items.Clear();
            lvTransParamInfo_DataBind();
            MessageBox.Show("你选择的变压器参数信息已删除！");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtTapPosition.Text != "")
            {
                if (txtTapPositionPoint.Text != "")
                {
                    if (txtVoltage.Text != "")
                    {
                        if (txtCurrent.Text != "")
                        {
                            if (txtTempPerMin.Text != "")
                            {
                                if (txtPower.Text != "")
                                {
                                    //修改
                                    if (txtTapPosition.ReadOnly == true)
                                    {
                                        txtCurrent.ReadOnly = true;
                                        txtVoltage.ReadOnly = true;
                                        txtTempPerMin.ReadOnly = true;
                                        txtPower.ReadOnly = true;
                                        btnCancel.Enabled = false;
                                        btnConfirm.Enabled = false;
                                        btnDeleteElementInfo.Enabled = true;
                                        btnModifyElementInfo.Enabled = true;
                                        btnAddNewElementInfo.Enabled = true;
                                        TransformerParamInfo transParamInfo = new TransformerParamInfo(0, 0, 0, 0, 0, 0);
                                        transParamInfo.TapPosition = Convert.ToInt32(txtTapPosition.Text);
                                        transParamInfo.TapPositionPoint = Convert.ToInt32(txtTapPositionPoint.Text);
                                        transParamInfo.Voltage = Convert.ToDouble(txtVoltage.Text);
                                        transParamInfo.Current = Convert.ToDouble(txtCurrent.Text);
                                        transParamInfo.TempPerMin = Convert.ToDouble(txtTempPerMin.Text);
                                        transParamInfo.Power = Convert.ToDouble(txtPower.Text);
                                        transformerParam.DelTransParamInfoByTapPositionAndTapPoint(Convert.ToInt32(txtTapPosition.Text), Convert.ToInt32(txtTapPositionPoint.Text));
                                        transformerParam.InsTransParamInfo(transParamInfo);
                                        lvTransParamInfo.Items.Clear();
                                        lvTransParamInfo_DataBind();
                                    }
                                    //新增
                                    else
                                    {
                                        txtTapPosition.ReadOnly = true;
                                        txtTapPositionPoint.ReadOnly = true;
                                        txtCurrent.ReadOnly = true;
                                        txtVoltage.ReadOnly = true;
                                        txtTempPerMin.ReadOnly = true;
                                        txtPower.ReadOnly = true;
                                        btnCancel.Enabled = false;
                                        btnConfirm.Enabled = false;
                                        btnDeleteElementInfo.Enabled = true;
                                        btnModifyElementInfo.Enabled = true;
                                        btnAddNewElementInfo.Enabled = true;
                                        TransformerParamInfo transParamInfo = new TransformerParamInfo(0, 0, 0, 0, 0, 0);
                                        transParamInfo.TapPosition = Convert.ToInt32(txtTapPosition.Text);
                                        transParamInfo.TapPositionPoint = Convert.ToInt32(txtTapPositionPoint.Text);
                                        transParamInfo.Voltage = Convert.ToDouble(txtVoltage.Text);
                                        transParamInfo.Current = Convert.ToDouble(txtCurrent.Text);
                                        transParamInfo.TempPerMin = Convert.ToDouble(txtTempPerMin.Text);
                                        transParamInfo.Power = Convert.ToDouble(txtPower.Text);
                                        transformerParam.InsTransParamInfo(transParamInfo);
                                        lvTransParamInfo.Items.Clear();
                                        lvTransParamInfo_DataBind();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请输入该档位功率值！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请输入该档位温升值！");
                            }
                        }
                        else
                        {
                            MessageBox.Show("请输入该档位电流值！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入该档位电压值！");
                    }
                }
                else
                {
                    MessageBox.Show("请输入该档位设定点！");
                }
            }
            else
            {
                MessageBox.Show("请输入档位值！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTapPosition.ReadOnly = true;
            txtTapPositionPoint.ReadOnly = true;
            txtCurrent.ReadOnly = true;
            txtVoltage.ReadOnly = true;
            txtTempPerMin.ReadOnly = true;
            txtPower.ReadOnly = true;
            btnCancel.Enabled = false;
            btnConfirm.Enabled = false;
            btnDeleteElementInfo.Enabled = true;
            btnModifyElementInfo.Enabled = true;
            btnAddNewElementInfo.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lvTransParamInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTransParamInfo.SelectedItems.Count > 0)
            {
                txtTapPosition.Text = lvTransParamInfo.SelectedItems[0].SubItems[0].Text;
                txtTapPositionPoint.Text = lvTransParamInfo.SelectedItems[0].SubItems[1].Text;
                txtVoltage.Text = lvTransParamInfo.SelectedItems[0].SubItems[2].Text;
                txtCurrent.Text = lvTransParamInfo.SelectedItems[0].SubItems[3].Text;
                txtTempPerMin.Text = lvTransParamInfo.SelectedItems[0].SubItems[4].Text;
                txtPower.Text = lvTransParamInfo.SelectedItems[0].SubItems[5].Text;
            }
            else
            {
                return;
            }
        }

    }
}
