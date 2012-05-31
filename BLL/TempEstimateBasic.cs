using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class TempEstimateBasic
    {
        private static readonly ITempEstimateBasic dal = LFAutomationUI.DALFactory.DataAccess.CreateTempEstimateBasic();
        /// <summary>
        /// 获取所有的温度预估基础信息
        /// </summary>
        /// <returns>温度预估基础信息</returns>
        public IList<TempEstimateBasicInfo> GetTempEstimateBasic()
        {
            return dal.GetTempEstimateBasic();
        }
        /// <summary>
        /// 更新温度预估基础信息
        /// </summary>
        /// <param name="tempEstBasicInfo"></param>
        public void UpdateTempEstimateBasic(TempEstimateBasicInfo tempEstBasicInfo)
        {
            dal.UpdateTempEstimateBasic(tempEstBasicInfo);
        }
    }
}
