using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ICCMHeat
    {
        /// <summary>
        /// 获取CCM的炉次信息
        /// </summary>
        /// <returns>CCM炉次信息</returns>
        CCMHeatInfo GetCCMHeatInfo();

        /// <summary>
        /// 获取CCM最近的中包测温信息
        /// </summary>
        /// <returns>中包测温信息</returns>
        IList<CCMHeatInfo> GetCCMTempInfo();
    }
}
