using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class MaterialType
    {
        private static readonly IMaterialType dal = LFAutomationUI.DALFactory.DataAccess.CreateMaterialType();

        /// <summary>
        /// 获取物料类型信息
        /// </summary>
        /// <returns>物料类型信息</returns>
        public IList<MaterialTypeInfo> GetMaterialTypeInfo()
        {
            return dal.GetMaterialTypeInfo();
        }
    }
}
