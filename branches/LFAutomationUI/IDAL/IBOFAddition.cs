using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;


namespace LFAutomationUI.IDAL
{
    public interface IBOFAddition
    {
        /// <summary>
        /// 根据炉次号获取BOF加料记录信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF加料记录</returns>
        IList<BOFAdditionInfo> GetBOFAdditionRecord(string heatId);


        /// <summary>
        /// 根据炉次号获取BOF加料统计信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns></returns>
        IList<BOFAdditionInfo> GetBOFAdditionStatistic(string heatId);
    }
}
