using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITempEstimate
    {
        /// <summary>
        /// 获取温度预估基础信息
        /// </summary>
        /// <returns>温度预估计算基础信息</returns>
        TempEstimateInfo GetTempEstimate(string heatId,int treatmentCount);
    }
}
