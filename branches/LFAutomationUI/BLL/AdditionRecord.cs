using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class AdditionRecord
    {
        private static readonly IAdditionRecord dal = LFAutomationUI.DALFactory.DataAccess.CreateAdditionRecord();

        /// <summary>
        /// 取出所有的加料记录信息
        /// </summary>
        /// <returns>所有的加料记录</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords()
        {
            return dal.GetAdditionMaterialRecords();
        }

        /// <summary>
        /// 根据炉次号取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>加料记录</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId)
        {
            return dal.GetAdditionMaterialRecords(heatId);
        }

        /// <summary>
        /// 根据炉次号取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns></returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId, int treatmentCount)
        {
            return dal.GetAdditionMaterialRecords(heatId, treatmentCount);
        }

        /// <summary>
        /// 根据日期查询加料信息
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>加料信息</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(DateTime startDate, DateTime endDate)
        {
            return dal.GetAdditionMaterialRecords(startDate, endDate);
        }

        /// <summary>
        /// 添加加料信息
        /// </summary>
        /// <param name="additionRecord">加料记录</param>
        public void InsertAdditionRecord(AdditionRecordInfo additionRecord)
        {
            dal.InsertAdditionRecord(additionRecord);
        }
    }
}
