using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class RealTime
    {

        private static readonly IRealTime dal = LFAutomationUI.DALFactory.DataAccess.CreateRealTime();


        /// <summary>
        /// 通过炉次号获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>实时信息</returns>
        public IList<RealTimeInfo> GetRealTimeInfo(string heatId)
        {
            return dal.GetRealTimeInfo(heatId);
        }

        /// <summary>
        /// 通过炉次号和冶炼次数获取实时信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">处理次数</param>
        /// <returns>实时信息</returns>
        public IList<RealTimeInfo> GetRealTimeInfo(string heatId, int treatmentCount)
        {
            return dal.GetRealTimeInfo(heatId,treatmentCount);
        }

    }
}
