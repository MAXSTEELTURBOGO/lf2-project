using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ITempOxygenRecord
    {
        /// <summary>
        /// 取出所有的测温记录
        /// </summary>
        /// <returns>所有测温记录</returns>
        IList<TempOxygenRecordInfo> GetTempOxygenRecord();

        /// <summary>
        /// 根据炉次号查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>测温测氧记录</returns>
        IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId);

        /// <summary>
        /// 根据炉次号和冶炼次数查询测温测氧记录
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>测温测氧记录</returns>
        IList<TempOxygenRecordInfo> GetTempOxygenRecord(string heatId, int treatmentCount);

        /// <summary>
        /// 根据起始日期和结束日期获取测温测氧记录
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>测温测氧记录</returns>
        IList<TempOxygenRecordInfo> GetTempOxygenRecord(DateTime startDate, DateTime endDate);
    }
}
