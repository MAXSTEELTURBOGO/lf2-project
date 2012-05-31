using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class CCMHeatStatus
    {
        private static readonly ICCMHeatStatus dal = LFAutomationUI.DALFactory.DataAccess.CreateCCMHeatStatus();

        /// <summary>
        /// 通过炉次号获取CCM炉次状态
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次状态</returns>
        public IList<CCMHeatStatusInfo> GetCCMHeatStatus(string heatId)
        {
            return dal.GetCCMHeatStatus(heatId);
        }
    }
}
