using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class CCMHeatReport
    {
        private static readonly ICCMHeatReport dal = LFAutomationUI.DALFactory.DataAccess.CreateCCMHeatReport();

        /// <summary>
        /// 通过炉次号获取CCM炉次报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次报告</returns>
        public CCMHeatReportInfo GetCCMHeatReport(string heatId)
        {
            return dal.GetCCMHeatReport(heatId);
        }

    }
}
