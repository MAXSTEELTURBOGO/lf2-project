using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IHeatQuality
    {
        /// <summary>
        /// 获取所有化验信息
        /// </summary>
        /// <returns>所有化验信息</returns>
        IList<HeatQualityInfo> GetAllHeatQualityInfo();

        /// <summary>
        /// 根据炉次号和处理次数获取化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>化验信息</returns>
        IList<HeatQualityInfo> GetHeatQualityInfo(string heatId);


        /// <summary>
        /// 根据炉次号和处理次数获取化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>化验信息</returns>
        IList<HeatQualityInfo> GetHeatQualityInfo(string heatId, int treatmentCount);

    }
}
