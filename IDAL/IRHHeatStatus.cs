using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IRHHeatStatus
    {
        /// <summary>
        /// 获取当前RH状态信息
        /// </summary>
        /// <returns>当前RH状态信息</returns>
        IList<RHHeatStatusInfo> GetCurrentRHHeatStatusInfo();

        /// <summary>
        /// 按照炉次号获取RH状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>RH状态信息</returns>
        IList<RHHeatStatusInfo> GetRHHeatStatusInfo(string heatId);
    }
}
