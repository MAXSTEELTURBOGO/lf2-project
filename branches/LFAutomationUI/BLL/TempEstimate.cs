using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class TempEstimate
    {
        private static readonly ITempEstimate dal = LFAutomationUI.DALFactory.DataAccess.CreateTempEstimate();
        /// <summary>
        /// 获取温度预估基础信息
        /// </summary>
        /// <returns>温度预估计算基础信息</returns>
        public TempEstimateInfo GetTempEstimate(string heatId, int treatmentCount)
        {
            return dal.GetTempEstimate(heatId, treatmentCount);
        }
    }
}
