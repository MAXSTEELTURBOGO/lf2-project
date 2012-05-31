using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IRecipe
    {
        /// <summary>
        /// 获取所有物料配方信息
        /// </summary>
        /// <returns>物料配方信息</returns>
        IList<RecipeInfo> GetMaterialRecipe();

        /// <summary>
        /// 插入新的配方信息
        /// </summary>
        void InsertNewRecipeInfo(RecipeInfo recipeInfo);

        /// <summary>
        /// 删除配方信息
        /// </summary>
        /// <param name="recipeId">配方Id</param>
        void DeleteRecipeInfo(decimal recipeId);
    }
}
