using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class QualityHorizontal
    {
        private static readonly IQualityHorizontal dal = LFAutomationUI.DALFactory.DataAccess.CreateQualityHorizontal();

        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>化验信息</returns>
        public IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId)
        {
            return dal.GetQualityDetailInfo(heatId);
        }

        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>化验信息</returns>
        public IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId, int treatmentCount)
        {
            return dal.GetQualityDetailInfo(heatId, treatmentCount);
        }
    }
}
