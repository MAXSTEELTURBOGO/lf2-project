using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IRealTime
    {
        /// <summary>
        /// 通过炉次号获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>实时信息</returns>
        IList<RealTimeInfo> GetRealTimeInfo(string heatId);

        /// <summary>
        /// 通过炉次号和冶炼次数获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>实时信息</returns>
        IList<RealTimeInfo> GetRealTimeInfo(string heatId, int treatmentCount);
    }
}
