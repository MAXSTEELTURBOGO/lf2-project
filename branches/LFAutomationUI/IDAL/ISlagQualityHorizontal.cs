using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ISlagQualityHorizontal
    {
        /// <summary>
        /// 根据炉次号获取渣化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>渣化验信息</returns>
        IList<SlagQualityHorizontalInfo> GetSlagQualityInfo(string heatId);
    }
}
