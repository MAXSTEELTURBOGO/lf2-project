using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ILadle
    {
        /// <summary>
        /// 根据炉次号获取钢包信息
        /// </summary>
        /// <param name="heatID">炉次号</param>
        /// <returns>钢包信息</returns>
        LadleInfo GetLadleInfo(string heatId);


        /// <summary>
        /// 根据炉次信息获取钢包信息
        /// </summary>
        /// <param name="heat">炉次信息</param>
        /// <returns>钢包信息</returns>
        LadleInfo GetLadleInfo(LFHeatInfo heat);
    }
}
