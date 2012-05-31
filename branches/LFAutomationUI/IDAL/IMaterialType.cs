using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IMaterialType
    {
        /// <summary>
        /// 获取物料类型信息
        /// </summary>
        /// <returns>物料类型信息</returns>
        IList<MaterialTypeInfo> GetMaterialTypeInfo();
    }
}
