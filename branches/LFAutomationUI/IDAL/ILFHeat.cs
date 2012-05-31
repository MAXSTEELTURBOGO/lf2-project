using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ILFHeat
    {
        /// <summary>
        /// 获取所有的炉次号  冶炼次数
        /// </summary>
        /// <returns>冶炼信息列表</returns>
        IList<LFHeatInfo> GetHeatIdList();

        /// <summary>
        /// 获取所有炉次信息
        /// </summary>
        /// <returns>炉次信息</returns>
        IList<LFHeatInfo> GetLFHeatInfo();

        /// <summary>
        /// 根据炉次号获取所有炉次信息
        /// </summary>
        /// <returns>炉次信息</returns>
        IList<LFHeatInfo> GetLFHeatInfo(string heatId);

        /// <summary>
        /// 根据炉次号和冶炼次数选取炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>炉次信息</returns>
        LFHeatInfo GetLFHeatInfo(string heatId, int treatmentCount);

        /// <summary>
        /// 根据日期获取炉次信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>炉次信息</returns>
        IList<LFHeatInfo> GetLFHeatInfo(DateTime startDate, DateTime endDate);

        /// <summary>
        /// 使用事务获取所有炉次信息
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <returns>炉次信息</returns>
        IList<LFHeatInfo> GetLFHeatInfo(OracleTransaction trans);

        /// <summary>
        /// 获取所有的炉次信息
        /// </summary>
        /// <returns>所有炉次信息</returns>
        IList<LFHeatInfo> GetAllLFHeatPlan();

        /// <summary>
        /// 将指定炉次的选择标志设置为指定值
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="selectFlag">要设置的selectFlag值</param>
        void UpdateLFHeatSelectFlag(LFHeatInfo lfHeat, bool selectFlag);

        /// <summary>
        /// 将指定炉次的选择标志设置为指定值
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="selectFlag">要设置的selectFlag值</param>
        void UpdateLFHeatSelectFlag(OracleTransaction trans, LFHeatInfo lfHeat, bool selectFlag);


        /// <summary>
        /// 将指定炉次的隐藏标志设置为指定值
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="visible">要设置的visible值</param>
        void UpdateLFHeatVisible(LFHeatInfo lfHeat, bool visible);

        /// <summary>
        /// 将指定炉次的隐藏标志设置为指定值
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="visible">要设置的visible值</param>
        void UpdateLFHeatVisible(OracleTransaction trans, LFHeatInfo lfHeat, bool visible);

        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        void DeleteLFHeatInfo(LFHeatInfo lfHeat);

        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        void DeleteLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="lfHeat">要插入的炉次信息</param>
        void InsertLFHeatInfo(LFHeatInfo lfHeat);

        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">要插入的炉次信息</param>
        void InsertLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_PLAN表
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        void InsertLFHeatPlan(LFHeatInfo lfHeat);


        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        void UpdateLFHeatInfoPK(LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat);

        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        void UpdateLFHeatInfoPK(OracleTransaction trans, LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat);

        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        void SelectLFHeatInfo(LFHeatInfo lfHeat);

        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        void SelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        void CancelSelectLFHeatInfo(LFHeatInfo lfHeat);

        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        void CancelSelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 锁住临界区
        /// </summary>
        /// <param name="trans">事务</param>
        void LockCriticalArea(OracleTransaction trans);

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        void DeleteLFHeatPlan(LFHeatInfo lfHeat);

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        void DeleteLFHeatPlan(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 处理状态6
        /// </summary>
        /// <param name="trans">所在事务</param>
        void ProcessStatusSix(OracleTransaction trans, LFHeatInfo lfHeat);

        /// <summary>
        /// 使用某事务处理signal状态
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="signal">处理状态</param>
        void ProcessStatus(OracleTransaction trans, LFHeatInfo lfHeat, ManualSignal signal);

        /// <summary>
        /// 交换正在冶炼的两个工位的所有信息
        /// </summary>
        void SwapCar(OracleTransaction trans);
    }
}
