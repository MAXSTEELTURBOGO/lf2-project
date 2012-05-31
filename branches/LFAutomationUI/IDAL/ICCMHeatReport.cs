using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ICCMHeatReport
    {
        /// <summary>
        /// 通过炉次号获取CCM炉次报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次报告</returns>
        CCMHeatReportInfo GetCCMHeatReport(string heatId);
    }
}
