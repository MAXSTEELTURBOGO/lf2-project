using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITempEstimateBasic
    {
        /// <summary>
        /// 获取所有的温度预估基础信息
        /// </summary>
        /// <returns>温度预估基础信息</returns>
        IList<TempEstimateBasicInfo> GetTempEstimateBasic();

        /// <summary>
        /// 更新温度预估基础信息
        /// </summary>
        /// <param name="tempEstBasicInfo"></param>
        void UpdateTempEstimateBasic(TempEstimateBasicInfo tempEstBasicInfo);
    }
}
