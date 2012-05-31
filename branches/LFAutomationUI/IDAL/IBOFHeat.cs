using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IBOFHeat
    {
        /// <summary>
        /// 通过炉次号获取BOF炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF炉次信息</returns>
        BOFHeatInfo GetBOFHeatInfo(string heatId);
    }
}
