using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class SlagQualityHorizontal
    {
        private static readonly ISlagQualityHorizontal dal = LFAutomationUI.DALFactory.DataAccess.CreateSlagQualityHorizontal();

        /// <summary>
        /// 根据炉次号获取渣化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>渣化验信息</returns>
        public IList<SlagQualityHorizontalInfo> GetSlagQualityInfo(string heatId)
        {
            return dal.GetSlagQualityInfo(heatId);
        }
    }
}
