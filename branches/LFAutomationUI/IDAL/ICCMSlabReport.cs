using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ICCMSlabReport
    {
        /// <summary>
        /// 通过炉次号获取CCM板坯报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>板坯报告</returns>
        IList<CCMSlabReportInfo> GetCCMSlabReport(string heatId);
    }
}
