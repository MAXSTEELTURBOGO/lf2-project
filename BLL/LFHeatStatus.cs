using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.BLL
{
    public class LFHeatStatus
    {
        private static readonly ILFHeatStatus dal = LFAutomationUI.DALFactory.DataAccess.CreateLFHeatStatus();

        /// <summary>
        /// 获取所有炉次状态信息
        /// </summary>
        /// <returns>炉次状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus()
        {
            return dal.GetLFHeatStatus();
        }

        /// <summary>
        /// 根据炉次号获取炉次状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(string heatId)
        {
            return dal.GetLFHeatStatus(heatId);
        }

        /// <summary>
        /// 根据炉次号和冶炼次数获取炉次状态信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(string heatId, int treatmentCount)
        {
            return dal.GetLFHeatStatus(heatId, treatmentCount);
        }

        /// <summary>
        /// 根据开始时间和结束时间查询炉次运转状况
        /// </summary>
        /// <param name="startDate">起始时间</param>
        /// <param name="endDate">终止时间</param>
        /// <returns>炉次冶炼状态信息</returns>
        public IList<LFHeatStatusInfo> GetLFHeatStatus(DateTime startDate, DateTime endDate)
        {
            return dal.GetLFHeatStatus(startDate, endDate);
        }
    }
}
