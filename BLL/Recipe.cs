using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Recipe
    {
        private static readonly IRecipe dal = LFAutomationUI.DALFactory.DataAccess.CreateRecipe();

        /// <summary>
        /// 获取所有物料配方信息
        /// </summary>
        /// <returns>物料配方信息</returns>
        public IList<RecipeInfo> GetMaterialRecipe()
        {
            return dal.GetMaterialRecipe();
        }

        /// <summary>
        /// 插入新的配方信息
        /// </summary>
        public void InsertNewRecipeInfo(RecipeInfo recipeInfo)
        {
            dal.InsertNewRecipeInfo(recipeInfo);
        }

        /// <summary>
        /// 删除配方信息
        /// </summary>
        /// <param name="recipeId">配方Id</param>
        public void DeleteRecipeInfo(decimal recipeId)
        {
            dal.DeleteRecipeInfo(recipeId);
        }
    }
}
