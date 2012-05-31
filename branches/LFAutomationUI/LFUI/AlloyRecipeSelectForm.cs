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
using System.Text.RegularExpressions;

namespace LFAutomationUI.LFUI
{
    public partial class AlloyRecipeSelectForm : Form
    {
        Recipe materialRecipe;
        Material material;
        IList<MaterialInfo> materialList;

        public AlloyRecipeSelectForm()
        {
            InitializeComponent();;
        }

        private void AlloyRecipeSelectForm_Load(object sender, EventArgs e)
        {
            materialRecipe = new Recipe();
            material = new Material();
            materialList = material.GetAllMaterialInfos();
            materialList_DataBind();
        }

        private void materialList_DataBind()
        {
            foreach (MaterialInfo info in materialList.Where(i=>i.MatTypeInfo.MaterialTypeName == "ALLOY"))
            {
                ListViewItem item = new ListViewItem(info.MaterialId.ToString());
                item.SubItems.Add(info.MaterialName);
                lvChoosingMaterialList.Items.Add(item);
            }
        }

        private void btnAlloyRecipeSelectClose_Click(object sender, EventArgs e)
        {
            materialRecipe.DeleteRecipeInfo(1);
            this.Close();
        }

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

        private void btnAlloyRecipeSelectCancel_Click(object sender, EventArgs e)
        {
            lvChoosingMaterialList.Items.Clear();
            lvChosenMaterialList.Items.Clear();
            material = new Material();
            materialList = material.GetAllMaterialInfos();
            materialList_DataBind();
        }

        private void btnAlloyRecipeSelectOK_Click(object sender, EventArgs e)
        {
            if (lvChosenMaterialList.Items.Count > 0)
            {
                materialRecipe.DeleteRecipeInfo(1);

                RecipeInfo recipeInfo = new RecipeInfo();
                IList<RecipeMaterialInfo> recipeMatInfos = new List<RecipeMaterialInfo>();
                recipeInfo.RecipeId = 1;
                recipeInfo.RecipeName = "临时配方";
                recipeInfo.RecipeType = "ALLOY";
                recipeInfo.RecipeDesc = "";
                foreach (ListViewItem item in lvChosenMaterialList.Items)
                {
                    RecipeMaterialInfo recipeMaterialInfo = new RecipeMaterialInfo();
                    recipeMaterialInfo.RecipeId = recipeInfo.RecipeId;
                    recipeMaterialInfo.MaterialInfo.MaterialId = Convert.ToDecimal(item.SubItems[0].Text);
                    recipeMatInfos.Add(recipeMaterialInfo);
                }
                recipeInfo.RecipeMaterialInfo = recipeMatInfos;
                materialRecipe.InsertNewRecipeInfo(recipeInfo);
                this.Close();
            }
            else
            {
                MessageBox.Show("尚未选择物料!请先选择物料后,再确定操作!");
            }
        }
    }
}
