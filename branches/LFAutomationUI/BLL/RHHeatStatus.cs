using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class RHHeatStatus
    {
        private static readonly IRHHeatStatus dal = LFAutomationUI.DALFactory.DataAccess.CreateRHHeatStatus();
        /// <summary>
        /// 获取当前RH状态信息
        /// </summary>
        /// <returns>当前RH状态信息</returns>
        public IList<RHHeatStatusInfo> GetCurrentRHHeatStatusInfo()
        {
            return dal.GetCurrentRHHeatStatusInfo();
        }

        /// <summary>
        /// 按照炉次号获取RH状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>RH状态信息</returns>
        public IList<RHHeatStatusInfo> GetRHHeatStatusInfo(string heatId)
        {
            return dal.GetRHHeatStatusInfo(heatId);
        }
    }
}
