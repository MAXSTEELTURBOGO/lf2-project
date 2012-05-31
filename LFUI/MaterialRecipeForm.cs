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
    public partial class MaterialRecipeForm : Form
    {
        Recipe materialRecipe;
        IList<RecipeInfo> materialRecipeList;
        Material material;
        IList<MaterialInfo> materialList;
        IList<MaterialInfo> choosingMatList;
        IList<MaterialInfo> chosenMatList;
        /// <summary>
        /// 窗口构造函数
        /// </summary>
        public MaterialRecipeForm()
        {
            materialRecipe = new Recipe();
            materialRecipeList = materialRecipe.GetMaterialRecipe();
            material = new Material();
            materialList = material.GetAllMaterialInfos();
            choosingMatList = new List<MaterialInfo>();
            chosenMatList = new List<MaterialInfo>();
            InitializeComponent();
        }
        /// <summary>
        /// 窗口加载程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaterialRecipeForm_Load(object sender, EventArgs e)
        {
            cmbRecipeId_DataBind(materialRecipeList);
        }
        /// <summary>
        /// lvChoosingMaterial数据绑定
        /// </summary>
        /// <param name="materialInfo"></param>
        private void lvChoosingMaterial_DataBind(IList<MaterialInfo> materialInfo)
        {
            lvChoosingMaterialList.Items.Clear();
            foreach (MaterialInfo info in materialInfo)
            {
                ListViewItem item = new ListViewItem(info.MaterialId.ToString());
                item.SubItems.Add(info.MaterialName);
                lvChoosingMaterialList.Items.Add(item);
            }
        }
        /// <summary>
        /// lvChosenMaterial数据绑定
        /// </summary>
        /// <param name="materialInfo"></param>
        private void lvChosenMaterial_DataBind(IList<MaterialInfo> materialInfo)
        {
            lvChosenMaterialList.Items.Clear();
            foreach (MaterialInfo info in materialInfo)
            {
                ListViewItem item = new ListViewItem(info.MaterialId.ToString());
                item.SubItems.Add(info.MaterialName);
                lvChosenMaterialList.Items.Add(item);
            }
        }
        /// <summary>
        /// cmbRecipeId数据绑定
        /// </summary>
        /// <param name="materialRecipeInfo"></param>
        private void cmbRecipeId_DataBind(IList<RecipeInfo> materialRecipeInfo)
        {
            cmbRecipeId.Items.Clear();
            IList<decimal> recipeId = (from i in materialRecipeInfo
                                       orderby i.RecipeId
                                       select i.RecipeId).Distinct().ToList<decimal>();
            foreach (decimal item in recipeId)
            {
                cmbRecipeId.Items.Add(item.ToString());
            }
            cmbRecipeId.Items.Add("");
        }
        /// <summary>
        /// 选择配方种类时响应的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRecipeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvChoosingMaterialList.Items.Clear();
            lvChosenMaterialList.Items.Clear();
            choosingMatList = (from i in materialList
                               where i.MatTypeInfo.MaterialTypeName == cmbRecipeType.Text
                               select i).ToList<MaterialInfo>();

            if (!string.IsNullOrEmpty(cmbRecipeId.Text))
            {
                try
                {
                    chosenMatList = new List<MaterialInfo>();
                    var qurey = (from i in materialRecipeList
                                 where i.RecipeId == Convert.ToDecimal(cmbRecipeId.Text) && i.RecipeType == cmbRecipeType.Text
                                 select i.RecipeMaterialInfo).First();
                    foreach (var item in qurey)
                    {
                        MaterialInfo materialInfo = new MaterialInfo();
                        materialInfo.MaterialId = item.MaterialInfo.MaterialId;
                        materialInfo.MaterialName = item.MaterialInfo.MaterialName;
                        chosenMatList.Add(materialInfo);
                    }
                    lvChosenMaterial_DataBind(chosenMatList);
                    foreach (MaterialInfo item in chosenMatList)
                    {
                        choosingMatList.Remove(choosingMatList.Where(i => i.MaterialId == item.MaterialId).First());
                    }
                }
                catch
                {
                }
            }
            lvChoosingMaterial_DataBind(choosingMatList);
        }
        /// <summary>
        /// 关闭窗口时响应的方法
        /// </summary>
        /// <param name="e"></param>
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
        /// <summary>
        /// 关闭窗口按钮调用方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// cmbRecipeId数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbRecipeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbRecipeId.Text))
            {
                RecipeInfo recipeInfo = (from i in materialRecipeList
                                         where i.RecipeId == Convert.ToDecimal(cmbRecipeId.Text)
                                         select i).First();
                txtRecipeDesc.Text = recipeInfo.RecipeDesc;
                txtRecipeName.Text = recipeInfo.RecipeName;
                cmbRecipeType.Text = recipeInfo.RecipeType;
            }
            else
            {
                clearControls();
            }
        }
        /// <summary>
        /// 清除控件显示的信息
        /// </summary>
        private void clearControls()
        {
            cmbRecipeId.Text = "";
            cmbRecipeType.Text = "";
            txtRecipeName.Text = "";
            txtRecipeDesc.Text = "";
            lvChoosingMaterialList.Items.Clear();
            lvChosenMaterialList.Items.Clear();
        }
        /// <summary>
        /// lvChoosingMaterialList数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvChoosingMaterialList_ItemActivate(object sender, EventArgs e)
        {
            if (lvChoosingMaterialList.SelectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem(lvChoosingMaterialList.SelectedItems[0].SubItems[0].Text);
                item.SubItems.Add(lvChoosingMaterialList.SelectedItems[0].SubItems[1].Text);
                lvChosenMaterialList.Items.Add(item);
                lvChoosingMaterialList.Items.Remove(lvChoosingMaterialList.SelectedItems[0]);
            }
        }
        /// <summary>
        /// lvChosenMaterialList数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvChosenMaterialList_ItemActivate(object sender, EventArgs e)
        {
            if (lvChosenMaterialList.SelectedItems.Count > 0)
            {
                ListViewItem item = new ListViewItem(lvChosenMaterialList.SelectedItems[0].SubItems[0].Text);
                item.SubItems.Add(lvChosenMaterialList.SelectedItems[0].SubItems[1].Text);
                lvChoosingMaterialList.Items.Add(item);
                lvChosenMaterialList.Items.Remove(lvChosenMaterialList.SelectedItems[0]);
            }
        }
        /// <summary>
        /// 设置编辑模式
        /// </summary>
        private void setEditMode()
        {
            txtRecipeName.Text = "";
            txtRecipeDesc.Text = "";
            cmbRecipeType.Text = "";
            txtRecipeName.ReadOnly = false;
            txtRecipeDesc.ReadOnly = false;
            cmbRecipeId.Enabled = false;
            cmbRecipeType.Enabled = true;
            lvChoosingMaterialList.Enabled = true;
            lvChosenMaterialList.Enabled = true;
        }
        /// <summary>
        /// 取消编辑模式
        /// </summary>
        private void cancelEditMode()
        {
            cmbRecipeId.Text = "";
            txtRecipeName.Text = "";
            txtRecipeDesc.Text = "";
            cmbRecipeType.Text = "";
            txtRecipeName.ReadOnly = true;
            txtRecipeDesc.ReadOnly = true;
            cmbRecipeId.Enabled = true;
            cmbRecipeType.Enabled = false;
            lvChoosingMaterialList.Enabled = false;
            lvChosenMaterialList.Enabled = false;
        }
        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            cmbRecipeId.Text = "";
            setEditMode();
            clearControls();
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyRecipe_Click(object sender, EventArgs e)
        {
            setEditMode();
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRecipeId.Text))
            {
                MessageBox.Show("请先选择配方，再进行删除操作！");
            }
            else
            {
                materialRecipe.DeleteRecipeInfo(Convert.ToDecimal(cmbRecipeId.Text));
                clearControls();
                materialRecipeList = materialRecipe.GetMaterialRecipe();
                cmbRecipeId_DataBind(materialRecipeList);
                MessageBox.Show("配方删除成功！");
            }
        }
        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRecipeId.Text)) //新增
            {
                if (string.IsNullOrEmpty(txtRecipeName.Text))
                {
                    MessageBox.Show("配方名称不能为空，请输入后再点‘确认’按钮！");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(cmbRecipeType.Text))
                    {
                        MessageBox.Show("配方类型不能为空，请选择后再点‘确认’按钮！");
                        return;
                    }
                    else
                    {
                        decimal maxRecipeId = (from i in materialRecipeList
                                               select i.RecipeId).Max();
                        RecipeInfo recipeInfo = new RecipeInfo();
                        IList<RecipeMaterialInfo> recipeMatInfos = new List<RecipeMaterialInfo>();
                        recipeInfo.RecipeId = maxRecipeId + 1;
                        recipeInfo.RecipeName = txtRecipeName.Text;
                        recipeInfo.RecipeType = cmbRecipeType.Text;
                        recipeInfo.RecipeDesc = txtRecipeDesc.Text;
                        foreach (ListViewItem item in lvChosenMaterialList.Items)
                        {
                            RecipeMaterialInfo recipeMaterialInfo = new RecipeMaterialInfo();
                            recipeMaterialInfo.RecipeId = recipeInfo.RecipeId;
                            recipeMaterialInfo.MaterialInfo.MaterialId = Convert.ToDecimal(item.SubItems[0].Text);
                            recipeMatInfos.Add(recipeMaterialInfo);
                        }
                        recipeInfo.RecipeMaterialInfo = recipeMatInfos;
                        materialRecipe.InsertNewRecipeInfo(recipeInfo);
                        MessageBox.Show("配方添加成功！");
                    }
                }
            }
            else //修改
            {
                if (string.IsNullOrEmpty(txtRecipeName.Text))
                {
                    MessageBox.Show("配方名称不能为空，请输入后再点‘确认’按钮！");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(cmbRecipeType.Text))
                    {
                        MessageBox.Show("配方类型不能为空，请选择后再点‘确认’按钮！");
                        return;
                    }
                    else
                    {
                        materialRecipe.DeleteRecipeInfo(Convert.ToDecimal(cmbRecipeId.Text));
                        RecipeInfo recipeInfo = new RecipeInfo();
                        IList<RecipeMaterialInfo> recipeMatInfos = new List<RecipeMaterialInfo>();
                        recipeInfo.RecipeId = Convert.ToDecimal(cmbRecipeId.Text);
                        recipeInfo.RecipeName = txtRecipeName.Text;
                        recipeInfo.RecipeType = cmbRecipeType.Text;
                        recipeInfo.RecipeDesc = txtRecipeDesc.Text;
                        foreach (ListViewItem item in lvChosenMaterialList.Items)
                        {
                            RecipeMaterialInfo recipeMaterialInfo = new RecipeMaterialInfo();
                            recipeMaterialInfo.RecipeId = Convert.ToDecimal(cmbRecipeId.Text);
                            recipeMaterialInfo.MaterialInfo.MaterialId = Convert.ToDecimal(item.SubItems[0].Text);
                            recipeMatInfos.Add(recipeMaterialInfo);
                        }
                        recipeInfo.RecipeMaterialInfo = recipeMatInfos;
                        materialRecipe.InsertNewRecipeInfo(recipeInfo);
                        MessageBox.Show("配方修改成功！");
                    }
                }
            }
            cancelEditMode();
            materialRecipeList = materialRecipe.GetMaterialRecipe();
            cmbRecipeId_DataBind(materialRecipeList);
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelEditMode();
            clearControls();
        }
    }
}
