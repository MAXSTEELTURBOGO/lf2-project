using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class CCMHeat
    {
        private static readonly ICCMHeat dal = LFAutomationUI.DALFactory.DataAccess.CreateCCMHeat();

        /// <summary>
        /// 获取CCM的炉次信息
        /// </summary>
        /// <returns>CCM炉次信息</returns>
        public CCMHeatInfo GetCCMHeatInfo()
        {
            return dal.GetCCMHeatInfo();
        }
        /// <summary>
        /// 获取CCM最近的中包测温信息
        /// </summary>
        /// <returns>中包测温信息</returns>
        public IList<CCMHeatInfo> GetCCMTempInfo()
        {
            return dal.GetCCMTempInfo();
        }
    }
}
