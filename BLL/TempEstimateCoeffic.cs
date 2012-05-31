using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class TempEstimateCoeffic
    {
        private static readonly ITempEstimateCoeffic dal = LFAutomationUI.DALFactory.DataAccess.CreateTempEstimateCoeffic();

        /// <summary>
        /// 获取温度预估计算系数
        /// </summary>
        /// <returns>预估计算系数</returns>
        public IList<TempEstimateCoefficInfo> GetTempEstimateCoeffic()
        {
            return dal.GetTempEstimateCoeffic();
        }

        /// <summary>
        /// 更新温度预估系数
        /// </summary>
        /// <param name="tempEstimateCoeffic">温度预估系数信息</param>
        public void UpdateTempEstimateCoeffic(IList<TempEstimateCoefficInfo> tempEstimateCoeffic)
        {
            dal.UpdateTempEstimateCoeffic(tempEstimateCoeffic);
        }
    }
}
