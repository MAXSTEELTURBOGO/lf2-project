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
    public partial class MaterialInfoForm : Form
    {
        Material material;
        MaterialAnalysis materialAnalysis;
        IList<MaterialInfo> materialInfoList;
        IList<MaterialTypeInfo> materialTypeList;

        /// <summary>
        /// 构造函数
        /// </summary>
        public MaterialInfoForm()
        {
            InitializeComponent();
            lvMaterialList.Columns.Add("物料代码", 80, HorizontalAlignment.Center);
            lvMaterialList.Columns.Add("物料名称", 105, HorizontalAlignment.Center);
            dgvElementAnalysis.AutoGenerateColumns = false;
            dgvCompoundAnalysis.AutoGenerateColumns = false;
            cmbMaterialNote.Items.Add("kg");
            cmbMaterialNote.Items.Add("m");
            cmbMaterialNote.Items.Add("");
        }

        /// <summary>
        /// 窗口加载事件触发的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialInfoMaintenanceUI_Load(object sender, EventArgs e)
        {
            material = new Material();
            materialAnalysis = new MaterialAnalysis();
            MaterialType materialType = new MaterialType();
            materialInfoList = material.GetAllMaterialInfos();
            materialTypeList = materialType.GetMaterialTypeInfo();
            lvMateriailList_DataBind();
            cmbMaterialType_DataBind();
        }

        private void cmbMaterialType_DataBind()
        {

            foreach (MaterialTypeInfo item in materialTypeList)
            {
                cmbMaterialType.Items.Add(item.MaterialTypeName);
            }
            cmbMaterialType.Items.Add("");
        }

        /// <summary>
        /// 初始化窗口时调用的lvMaterialList的数据绑定方法，把所有物料取出形成列表，供选择
        /// </summary>
        private void lvMateriailList_DataBind()
        {
            foreach (MaterialInfo materialInfo in materialInfoList)
            {
                ListViewItem item = new ListViewItem(materialInfo.MaterialId.ToString());
                item.SubItems.Add(materialInfo.MaterialName);
                lvMaterialList.Items.Add(item);
            }
        }

        /// <summary>
        /// 选择物料时，或点击“修改”按钮时，dgvCompoundAnalysis所要调用的绑定数据的方法
        /// </summary>
        /// <param name="materialAnalysisInfos">物料元素含量信息</param>
        private void dgvCompoundAnalysis_DataBind(IList<MaterialAnalysisInfo> materialAnalysisInfos)
        {
            foreach (MaterialAnalysisInfo item in materialAnalysisInfos)
            {
                object[] rows = new object[] { item.ElemInfo.ElementShortName, item.NetContent };
                dgvCompoundAnalysis.Rows.Add(rows);
            }
        }

        /// <summary>
        /// 点击“新增”按钮时，dgvCompoundAnalysis所要调用的绑定数据的方法
        /// </summary>
        private void dgvCompoundAnalysis_Add_DataBind()
        {
            Element element = new Element();
            IList<ElementInfo> elementInfos = element.GetCompoundInfo();
            foreach (ElementInfo item in elementInfos)
            {
                object[] rows = new object[] { item.ElementShortName, 0 };
                dgvCompoundAnalysis.Rows.Add(rows);
            }
        }

        /// <summary>
        /// 选择物料时，或点击“修改”按钮时，dgvElementAnalysis所要调用的绑定数据的方法
        /// </summary>
        /// <param name="materialAnalysisInfos">物料元素含量信息</param>
        private void dgvElementAnalysis_DataBind(IList<MaterialAnalysisInfo> materialAnalysisInfos)
        {
            foreach (MaterialAnalysisInfo i in materialAnalysisInfos)
            {
                object[] row = new object[] { i.ElemInfo.ElementShortName, i.NetContent, i.Yield };
                dgvElementAnalysis.Rows.Add(row);
            }
        }

        /// <summary>
        /// 点击“新增”按钮时，dgvElementAnalysis所要调用的绑定数据的方法
        /// </summary>
        private void dgvElementAnalysis_Add_DataBind()
        {
            Element element = new Element();
            IList<ElementInfo> elementInfos = element.GetElementInfo();
            foreach (ElementInfo i in elementInfos)
            {
                object[] row = new object[] { i.ElementShortName, 0, 100 };
                dgvElementAnalysis.Rows.Add(row);
            }
        }

        /// <summary>
        /// lvMaterialList选择事件，每次选择，都将选择的物料的基础信息和元素信息显示出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMaterialList.SelectedItems.Count > 0)
            {
                dgvCompoundAnalysis.Rows.Clear();
                dgvElementAnalysis.Rows.Clear();
                MaterialInfo materialInfo = (from i in materialInfoList
                                             where i.MaterialId == Convert.ToDecimal(lvMaterialList.SelectedItems[0].SubItems[0].Text)
                                             select i).First<MaterialInfo>();
                IList<MaterialAnalysisInfo> materialElementInfos = (from i in materialInfo.AnalysisList
                                                                    where i.ElemInfo.ElementType == "ELEMENT"
                                                                    select i).ToList<MaterialAnalysisInfo>();
                IList<MaterialAnalysisInfo> materialCompoundInfos = (from i in materialInfo.AnalysisList
                                                                     where i.ElemInfo.ElementType == "COMPOUND"
                                                                     select i).ToList<MaterialAnalysisInfo>();
                dgvElementAnalysis_DataBind(materialElementInfos);
                dgvCompoundAnalysis_DataBind(materialCompoundInfos);
                txtMaterialId.Text = materialInfo.MaterialId.ToString();
                txtL3MaterialId.Text = materialInfo.MaterialL3Id;
                txtMaterialName.Text = materialInfo.MaterialName;
                cmbMaterialType.Text = materialInfo.MatTypeInfo.MaterialTypeName;
                cmbMaterialNote.Text = materialInfo.MaterialNote;
                txtMaterialDescription.Text = materialInfo.MaterialDesc;
                txtMaterialYield.Text = materialInfo.Yield.ToString();
                txtChillRate.Text = materialInfo.ChillFactor.ToString();
                cmbMaterialType.Enabled = false;
                cmbMaterialNote.Enabled = false;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// “新增”按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewElementInfo_Click(object sender, EventArgs e)
        {
            txtMaterialId.ReadOnly = false;
            setEditMode();
            clearControls();
            dgvElementAnalysis_Add_DataBind();
            dgvElementAnalysis.ReadOnly = false;
            dgvElementAnalysis.Columns[0].ReadOnly = true;
            dgvCompoundAnalysis_Add_DataBind();
            dgvCompoundAnalysis.ReadOnly = false;
            dgvCompoundAnalysis.Columns[0].ReadOnly = true;
        }

        /// <summary>
        /// “修改”按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyElementInfo_Click(object sender, EventArgs e)
        {
            if (txtMaterialId.Text != "")
            {
                setEditMode();
                IList<MaterialAnalysisInfo> materialAnalysisInfos = materialAnalysis.GetMaterialAnalysisByMaterialid(Convert.ToInt32(txtMaterialId.Text));
                IList<MaterialAnalysisInfo> materialElementInfos = (from i in materialAnalysisInfos
                                                                    where i.ElemInfo.ElementType == "ELEMENT"
                                                                    select i).ToList<MaterialAnalysisInfo>();
                IList<MaterialAnalysisInfo> materialCompoundInfos = (from i in materialAnalysisInfos
                                                                     where i.ElemInfo.ElementType == "COMPOUND"
                                                                     select i).ToList<MaterialAnalysisInfo>();
                dgvElementAnalysis.Rows.Clear();
                dgvElementAnalysis_DataBind(materialElementInfos);
                dgvElementAnalysis.ReadOnly = false;
                dgvElementAnalysis.Columns[0].ReadOnly = true;
                dgvCompoundAnalysis.Rows.Clear();
                dgvCompoundAnalysis_DataBind(materialCompoundInfos);
                dgvCompoundAnalysis.ReadOnly = false;
                dgvCompoundAnalysis.Columns[0].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("请先选择要修改的物料！");
                return;
            }
        }

        /// <summary>
        /// “删除”按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteElementInfo_Click(object sender, EventArgs e)
        {
            material.DeleteMaterialInfo(Convert.ToDecimal(txtMaterialId.Text));
            clearControls();
        }

        /// <summary>
        /// “确认”按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {

            //修改物料信息
            if (txtMaterialId.ReadOnly == true)
            {
                materialAnalysis.DeleteMaterialAnalysisInfoByMatId(Convert.ToDecimal(txtMaterialId.Text));
                updateNewMaterialInfo();
            }
            //新增物料信息
            else if (txtMaterialId.ReadOnly == false)
            {
                if (txtMaterialId.Text != "" && txtMaterialName.Text != "")
                {
                    if ((from i in materialInfoList where i.MaterialId == Convert.ToDecimal(txtMaterialId.Text) select i).Count() == 0)
                    {
                        insertNewMaterialInfo();
                    }
                    else
                    {
                        MessageBox.Show("该物料代码已存在！");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("物料代码和物料名称不能为空，请重新填写！");
                    return;
                }
            }
            clearControls();
            cancelEditMode();
        }

        /// <summary>
        /// 设置编辑模式
        /// </summary>
        private void setEditMode()
        {
            lvMaterialList.Enabled = false;
            cmbMaterialNote.Enabled = true;
            cmbMaterialType.Enabled = true;
            btnConfirm.Enabled = true;
            btnCancel.Enabled = true;
            btnAddNewElementInfo.Enabled = false;
            btnDeleteElementInfo.Enabled = false;
            btnModifyElementInfo.Enabled = false;
            txtBulkWgt.ReadOnly = false;
            txtChillRate.ReadOnly = false;
            txtFeContent.ReadOnly = false;
            txtL3MaterialId.ReadOnly = false;
            txtMaterialDescription.ReadOnly = false;
            txtMaterialName.ReadOnly = false;
            txtWireWgt.ReadOnly = false;
            txtMaterialYield.ReadOnly = false;
        }

        /// <summary>
        /// 取消编辑模式
        /// </summary>
        private void cancelEditMode()
        {
            dgvElementAnalysis.ReadOnly = true;
            dgvCompoundAnalysis.ReadOnly = true;
            lvMaterialList.Enabled = true;
            btnAddNewElementInfo.Enabled = true;
            btnModifyElementInfo.Enabled = true;
            btnDeleteElementInfo.Enabled = true;
            btnConfirm.Enabled = false;
            btnCancel.Enabled = false;
            txtMaterialId.ReadOnly = true;
            txtMaterialName.ReadOnly = true;
            txtBulkWgt.ReadOnly = true;
            txtChillRate.ReadOnly = true;
            txtFeContent.ReadOnly = true;
            txtL3MaterialId.ReadOnly = true;
            txtMaterialDescription.ReadOnly = true;
            txtWireWgt.ReadOnly = true;
            txtMaterialYield.ReadOnly = true;
            cmbMaterialType.Enabled = false;
            cmbMaterialNote.Enabled = false;
        }

        /// <summary>
        /// 清空控件中的内容
        /// </summary>
        private void clearControls()
        {
            materialInfoList = material.GetAllMaterialInfos();
            txtBulkWgt.Text = "";
            txtChillRate.Text = "";
            txtFeContent.Text = "";
            txtL3MaterialId.Text = "";
            txtMaterialDescription.Text = "";
            txtMaterialId.Text = "";
            txtMaterialName.Text = "";
            txtWireWgt.Text = "";
            txtMaterialYield.Text = "";
            cmbMaterialType.Text = "";
            cmbMaterialNote.Text = "";
            dgvCompoundAnalysis.Rows.Clear();
            dgvElementAnalysis.Rows.Clear();
            lvMaterialList.Items.Clear();
            lvMateriailList_DataBind();
        }

        /// <summary>
        /// “取消”按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelEditMode();
            clearControls();
        }

        /// <summary>
        /// 向表TB_MATERIAL_INFO和TB_MATERIAL_ANALYSIS插入新的信息
        /// </summary>
        private void insertNewMaterialInfo()
        {
            IList<MaterialAnalysisInfo> materialAnalysisInfos = new List<MaterialAnalysisInfo>();
            MaterialTypeInfo materialTypeInfo = new MaterialTypeInfo();
            try
            {
                materialTypeInfo = (from i in materialTypeList where i.MaterialTypeName == cmbMaterialType.Text select i).First<MaterialTypeInfo>();
            }
            catch
            {
            }
            decimal materialId = Convert.ToDecimal(txtMaterialId.Text);
            string materialL3Id = txtL3MaterialId.Text;
            string materialName = txtMaterialName.Text;
            string materialNote = cmbMaterialNote.Text;
            string materialDesc = txtMaterialDescription.Text;
            string materialShape = "";
            double? wireSpecWgt = string.IsNullOrEmpty(txtWireWgt.Text) ? null : new Nullable<double>(Convert.ToDouble(txtWireWgt.Text));
            double? bulkSpecWgt = string.IsNullOrEmpty(txtBulkWgt.Text) ? null : new Nullable<double>(Convert.ToDouble(txtBulkWgt.Text));
            double? chillRate = string.IsNullOrEmpty(txtChillRate.Text) ? null : new Nullable<double>(Convert.ToDouble(txtChillRate.Text));
            double? feContent = string.IsNullOrEmpty(txtFeContent.Text) ? null : new Nullable<double>(Convert.ToDouble(txtFeContent.Text));
            double? materialYield = string.IsNullOrEmpty(txtMaterialYield.Text) ? null : new Nullable<double>(Convert.ToDouble(txtMaterialYield.Text));
            MaterialInfo materialInfo = new MaterialInfo(materialId, materialL3Id, materialName, materialTypeInfo, materialNote, materialDesc, materialShape,
                                                         wireSpecWgt, bulkSpecWgt, chillRate, feContent, materialYield);
            material.InsertMaterialInfo(materialInfo);
            for (int index = 0; index < dgvCompoundAnalysis.Rows.Count; index++)
            {
                ElementInfo elementInfo = new ElementInfo();
                MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 0);
                materialAnalysisInfo.MaterialId = Convert.ToDecimal(txtMaterialId.Text);
                elementInfo.ElementShortName = dgvCompoundAnalysis.Rows[index].Cells[0].Value.ToString();
                materialAnalysisInfo.ElemInfo = elementInfo;
                try
                {
                    materialAnalysisInfo.NetContent = Convert.ToDouble(dgvCompoundAnalysis.Rows[index].Cells[1].Value.ToString());
                    if (materialAnalysisInfo.NetContent != 0)
                    {
                        materialAnalysisInfos.Add(materialAnalysisInfo);
                    }
                }
                catch
                {
                }
            }
            for (int index = 0; index < dgvElementAnalysis.Rows.Count; index++)
            {
                ElementInfo elementInfo = new ElementInfo();
                MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 100);
                materialAnalysisInfo.MaterialId = Convert.ToDecimal(txtMaterialId.Text);
                elementInfo.ElementShortName = dgvElementAnalysis.Rows[index].Cells[0].Value.ToString();
                materialAnalysisInfo.ElemInfo = elementInfo;
                try
                {
                    materialAnalysisInfo.Yield = Convert.ToDouble(dgvElementAnalysis.Rows[index].Cells[2].Value.ToString());
                }
                catch
                {
                    materialAnalysisInfo.Yield = 100;
                }
                try
                {
                    materialAnalysisInfo.NetContent = Convert.ToDouble(dgvElementAnalysis.Rows[index].Cells[1].Value.ToString());
                    if (materialAnalysisInfo.NetContent != 0)
                    {
                        materialAnalysisInfos.Add(materialAnalysisInfo);
                    }
                }
                catch
                {
                }
            }
            materialAnalysis.InsertMaterialAnalysisInfo(materialAnalysisInfos);
        }

        /// <summary>
        /// 更新表TB_MATERIAL_INFO，并向表TB_MATERIAL_ANALYSIS插入新的信息
        /// </summary>
        private void updateNewMaterialInfo()
        {
            IList<MaterialAnalysisInfo> materialAnalysisInfos = new List<MaterialAnalysisInfo>();
            MaterialTypeInfo materialTypeInfo = new MaterialTypeInfo();
            try
            {
                materialTypeInfo = (from i in materialTypeList where i.MaterialTypeName == cmbMaterialType.Text select i).First<MaterialTypeInfo>();
            }
            catch
            {
            }
            decimal materialId = Convert.ToDecimal(txtMaterialId.Text);
            string materialL3Id = txtL3MaterialId.Text;
            string materialName = txtMaterialName.Text;
            string materialNote = cmbMaterialNote.Text;
            string materialDesc = txtMaterialDescription.Text;
            string materialShape = "";
            double? wireSpecWgt = string.IsNullOrEmpty(txtWireWgt.Text) ? null : new Nullable<double>(Convert.ToDouble(txtWireWgt.Text));
            double? bulkSpecWgt = string.IsNullOrEmpty(txtBulkWgt.Text) ? null : new Nullable<double>(Convert.ToDouble(txtBulkWgt.Text));
            double? chillRate = string.IsNullOrEmpty(txtChillRate.Text) ? null : new Nullable<double>(Convert.ToDouble(txtChillRate.Text));
            double? feContent = string.IsNullOrEmpty(txtFeContent.Text) ? null : new Nullable<double>(Convert.ToDouble(txtFeContent.Text));
            double? materialYield = string.IsNullOrEmpty(txtMaterialYield.Text) ? null : new Nullable<double>(Convert.ToDouble(txtMaterialYield.Text));
            MaterialInfo materialInfo = new MaterialInfo(materialId, materialL3Id, materialName, materialTypeInfo, materialNote, materialDesc, materialShape,
                                                         wireSpecWgt, bulkSpecWgt, chillRate, feContent, materialYield);
            material.UpdateMaterialInfo(materialInfo);
            for (int index = 0; index < dgvCompoundAnalysis.Rows.Count; index++)
            {
                ElementInfo elementInfo = new ElementInfo();
                MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 0);
                materialAnalysisInfo.MaterialId = Convert.ToDecimal(txtMaterialId.Text);
                elementInfo.ElementShortName = dgvCompoundAnalysis.Rows[index].Cells[0].Value.ToString();
                materialAnalysisInfo.ElemInfo = elementInfo;
                try
                {
                    materialAnalysisInfo.NetContent = Convert.ToDouble(dgvCompoundAnalysis.Rows[index].Cells[1].Value.ToString());
                    if (materialAnalysisInfo.NetContent != 0)
                    {
                        materialAnalysisInfos.Add(materialAnalysisInfo);
                    }
                }
                catch
                {
                }
            }
            for (int index = 0; index < dgvElementAnalysis.Rows.Count; index++)
            {
                ElementInfo elementInfo = new ElementInfo();
                MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 100);
                materialAnalysisInfo.MaterialId = Convert.ToDecimal(txtMaterialId.Text);
                elementInfo.ElementShortName = dgvElementAnalysis.Rows[index].Cells[0].Value.ToString();
                materialAnalysisInfo.ElemInfo = elementInfo;
                try
                {
                    materialAnalysisInfo.Yield = Convert.ToDouble(dgvElementAnalysis.Rows[index].Cells[2].Value.ToString());
                }
                catch
                {
                    materialAnalysisInfo.Yield = 100;
                }
                try
                {
                    materialAnalysisInfo.NetContent = Convert.ToDouble(dgvElementAnalysis.Rows[index].Cells[1].Value.ToString());
                    if (materialAnalysisInfo.NetContent != 0)
                    {
                        materialAnalysisInfos.Add(materialAnalysisInfo);
                    }
                }
                catch
                {
                }
            }
            materialAnalysis.InsertMaterialAnalysisInfo(materialAnalysisInfos);
        }

        /// <summary>
        /// “关闭窗口“按钮调用Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dgvCompoundAnalysis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvCompoundAnalysis.CurrentCell.Value == null)
                {
                    dgvCompoundAnalysis.CurrentCell.Value = 0;
                }
                else if (!Regex.IsMatch(dgvCompoundAnalysis.CurrentCell.Value.ToString(), @"^100$|^\d{1,2}$|^\d{1,2}\.\d{1,4}$"))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvCompoundAnalysis.CurrentCell.Value = 0;
                }
            }
        }

        private void dgvElementAnalysis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvElementAnalysis.CurrentCell.Value == null)
                {
                    dgvElementAnalysis.CurrentCell.Value = 0;
                }
                else if (!Regex.IsMatch(dgvElementAnalysis.CurrentCell.Value.ToString(), @"^100$|^\d{1,2}$|^\d{1,2}\.\d{1,4}$"))
                {
                    MessageBox.Show("输入数字超出了允许范围，请重新输入！");
                    dgvElementAnalysis.CurrentCell.Value = 0;
                }
            }
        }

        private void txtMaterialId_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMaterialId.Text, @"^\d{0,10}$"))
            {
                MessageBox.Show("您输入的物料代码 \"" + txtMaterialId.Text + "\" 不符合格式要求，请重新输入！");
                txtMaterialId.Text = "";
            }
        }

        private void txtMaterialName_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMaterialName.Text, @"^[A-Za-z0-9\u4e00-\u9fa5]{0,20}$"))
            {
                MessageBox.Show("您输入的物料名称 \"" + txtMaterialName.Text + "\" 不符合格式要求，请重新输入！");
                txtMaterialName.Text = "";
            }
        }

        private void txtL3MaterialId_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtL3MaterialId.Text, @"^[A-Za-z0-9]{0,30}$"))
            {
                MessageBox.Show("您输入的物料三级代码 \"" + txtL3MaterialId.Text + "\" 不符合格式要求，请重新输入！");
                txtL3MaterialId.Text = "";
            }
        }

        private void txtMaterialDescription_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMaterialDescription.Text, @"^.{0,50}$"))
            {
                MessageBox.Show("您输入的物料描述 \"" + txtMaterialDescription.Text + "\" 不符合格式要求，请重新输入！");
                txtMaterialDescription.Text = "";
            }
        }

        private void txtFeContent_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtFeContent.Text, @"^100$|^\d{0,2}$|^\d{1,2}\.\d{1,4}$"))
            {
                MessageBox.Show("您输入的铁含量 \"" + txtFeContent.Text + "\" 不符合格式要求，请重新输入！ ");
                txtFeContent.Text = "";
            }
        }

        private void txtWireWgt_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtWireWgt.Text, @"^\d{0,5}$|^\d{1,5}\.\d{1,5}$"))
            {
                MessageBox.Show("您输入的线密度 \"" + txtWireWgt.Text + "\" 不符合格式要求，请重新输入！ ");
                txtWireWgt.Text = "";
            }
        }

        private void txtBulkWgt_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtBulkWgt.Text, @"^\d{0,5}$|^\d{1,5}\.\d{1,5}$"))
            {
                MessageBox.Show("您输入的块密度 \"" + txtBulkWgt.Text + "\" 不符合格式要求，请重新输入！ ");
                txtBulkWgt.Text = "";
            }
        }

        private void txtChillRate_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtChillRate.Text, @"^-\d{1,3}$|^\d{0,3}$|^-?\d{1,3}\.\d{1,2}$"))
            {
                MessageBox.Show("您输入的每秒钟温度变化 \"" + txtChillRate.Text + "\" 不符合格式要求，请重新输入！ ");
                txtChillRate.Text = "";
            }
        }

        private void txtMaterialYield_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtMaterialYield.Text, @"^100$|^\d{0,3}$|^\d{1,3}\.\d{1,2}$"))
            {
                MessageBox.Show("您输入的物料的收得率 \"" + txtMaterialYield.Text + "\" 不符合格式要求，请重新输入！ ");
                txtMaterialYield.Text = "";
            }
        }





    }
}
