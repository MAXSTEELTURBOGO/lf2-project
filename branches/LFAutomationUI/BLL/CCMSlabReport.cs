using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class CCMSlabReport
    {
        private static readonly ICCMSlabReport dal = LFAutomationUI.DALFactory.DataAccess.CreateCCMSlabReport();

        /// <summary>
        /// 通过炉次号获取CCM板坯报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>板坯报告</returns>
        public IList<CCMSlabReportInfo> GetCCMSlabReport(string heatId)
        {
            return dal.GetCCMSlabReport(heatId);
        }
    }
}
