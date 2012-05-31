using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ICCMHeatStatus
    {
        /// <summary>
        /// 通过炉次号获取CCM炉次状态
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次状态</returns>
        IList<CCMHeatStatusInfo> GetCCMHeatStatus(string heatId);
    }
}
