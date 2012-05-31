using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITempEstimateCoeffic
    {
        /// <summary>
        /// 获取温度预估计算系数
        /// </summary>
        /// <returns>预估计算系数</returns>
        IList<TempEstimateCoefficInfo> GetTempEstimateCoeffic();

        /// <summary>
        /// 更新温度预估系数
        /// </summary>
        /// <param name="tempEstimateCoeffic">温度预估系数信息</param>
        void UpdateTempEstimateCoeffic(IList<TempEstimateCoefficInfo> tempEstimateCoeffic);
    }
}
