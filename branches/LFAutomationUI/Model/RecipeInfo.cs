using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RecipeInfo
    {
        #region Members and Properties
        /// <summary>
        /// 配方ID
        /// </summary>
        private decimal recipeId;
        public decimal RecipeId
        {
            get { return recipeId; }
            set { recipeId = value; }
        }
        /// <summary>
        /// 配方名称
        /// </summary>
        private string recipeName;
        public string RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; }
        }
        /// <summary>
        /// 配方类型 ALLOY OR SLAG
        /// </summary>
        private string recipeType;
        public string RecipeType
        {
            get { return recipeType; }
            set { recipeType = value; }
        }

        /// <summary>
        /// 配方描述
        /// </summary>
        private string recipeDesc;
        public string RecipeDesc
        {
            get { return recipeDesc; }
            set { recipeDesc = value; }
        }
        /// <summary>
        /// 配方物料信息
        /// </summary>
        private IList<RecipeMaterialInfo> recipeMaterialInfo;
        public IList<RecipeMaterialInfo> RecipeMaterialInfo
        {
            get { return recipeMaterialInfo; }
            set { recipeMaterialInfo = value; }
        }
        #endregion


        #region Construction Function
        public RecipeInfo()
        {
        }
        #endregion

    }
}
