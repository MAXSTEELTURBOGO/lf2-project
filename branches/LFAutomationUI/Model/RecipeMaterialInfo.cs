using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RecipeMaterialInfo
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
        /// 物料信息
        /// </summary>
        private MaterialInfo materialInfo;
        public MaterialInfo MaterialInfo
        {
            get { return materialInfo; }
            set { materialInfo = value; }
        }
        /// <summary>
        /// 主元素信息
        /// </summary>
        private ElementInfo chiefElementInfo;
        public ElementInfo ChiefElementInfo
        {
            get { return chiefElementInfo; }
            set { chiefElementInfo = value; }
        }
        /// <summary>
        /// 主元素含量
        /// </summary>
        private double? chiefElementContent;
        public double? ChiefElementContent
        {
            get { return chiefElementContent; }
            set { chiefElementContent = value; }
        }
        #endregion


        #region Construction Function
        public RecipeMaterialInfo()
        {
            this.materialInfo = new MaterialInfo();
            this.chiefElementInfo = new ElementInfo();
        }
        #endregion
    }
}
