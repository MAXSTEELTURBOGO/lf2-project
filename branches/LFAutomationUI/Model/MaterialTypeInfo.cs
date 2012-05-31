using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class MaterialTypeInfo
    {
        #region members
        int? materialTypeId;
        string materialTypeName;
        #endregion

        #region Properties
        public int? MaterialTypeId
        {
            get { return materialTypeId; }
            set { materialTypeId = value; }
        }
        public string MaterialTypeName
        {
            get { return materialTypeName; }
            set { materialTypeName = value; }
        }
        #endregion

        #region Methods
        public MaterialTypeInfo()
        { }

        public MaterialTypeInfo(int? materialTypeId, string materialTypeName)
        {
            this.materialTypeId = materialTypeId;
            this.materialTypeName = materialTypeName;
        }
        #endregion
    }
}
