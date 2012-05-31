using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    /// <summary>
    /// 取横表数据类
    /// </summary>
    public interface IQualityHorizontal
    {
        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>化验信息</returns>
        IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId);

        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>化验信息</returns>
        IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId, int treatmentCount);
    }
}
