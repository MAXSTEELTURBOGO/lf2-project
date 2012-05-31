using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IHeatSlagQuality
    {
        /// <summary>
        /// 获取所有渣料化验信息
        /// </summary>
        /// <returns>渣料化验信息</returns>
        IList<HeatSlagQualityInfo> GetAllHeatSlagQualityInfo();

        /// <summary>
        /// 根据炉次号和处理次数获取渣料化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>渣料化验信息</returns>
        IList<HeatSlagQualityInfo> GetHeatSlagQualityInfo(string heatId);


        /// <summary>
        /// 根据炉次号和处理次数获取渣料化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>渣料化验信息</returns>
        IList<HeatSlagQualityInfo> GetHeatSlagQualityInfo(string heatId, int treatmentCount);
    }
}
