using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITempEstimateBasicInfo
    {
        /// <summary>
        /// 获取温度预估基础信息
        /// </summary>
        /// <returns>温度预估计算基础信息</returns>
        TempEstimateBasicInfo GetTempEstimateBasic(string heatId,int treatmentCount);
    }
}
