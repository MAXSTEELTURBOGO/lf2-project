using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class BOFAddition
    {

        private static readonly IBOFAddition dal = LFAutomationUI.DALFactory.DataAccess.CreateBOFAddition();

        /// <summary>
        /// 根据炉次号获取BOF加料记录信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>BOF加料记录</returns>
        public IList<BOFAdditionInfo> GetBOFAdditionRecord(string heatId)
        {
            return dal.GetBOFAdditionRecord(heatId);
        }


        /// <summary>
        /// 根据炉次号获取BOF加料统计信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns></returns>
        public IList<BOFAdditionInfo> GetBOFAdditionStatistic(string heatId)
        {
            return dal.GetBOFAdditionStatistic(heatId);
        }
    }
}
