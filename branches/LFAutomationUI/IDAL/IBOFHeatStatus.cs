using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IBOFHeatStatus
    {
        /// <summary>
        /// 获取当前BOF各站的冶炼状态信息
        /// </summary>
        /// <returns>BOF各站的冶炼状态信息</returns>
        IList<BOFHeatStatusInfo> GetBOFCurrentHeatStatus();

        /// <summary>
        /// 根据炉次号获取炉次状态信息列表
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次状态列表</returns>
        IList<BOFHeatStatusInfo> GetBOFHeatStatusList(string heatId);

    }
}
