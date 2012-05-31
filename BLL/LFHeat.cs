using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using System.Collections;

namespace LFAutomationUI.BLL
{
    public class LFHeat
    {
        private static readonly ILFHeat dal = LFAutomationUI.DALFactory.DataAccess.CreateLFHeat();

        /// <summary>
        /// 获取所有的炉次号  冶炼次数
        /// </summary>
        /// <returns>冶炼信息列表</returns>
        public IList<LFHeatInfo> GetHeatIdList()
        {
            return dal.GetHeatIdList();
        }

        /// <summary>
        /// 获取炉次信息，包括未冶炼、正在冶炼和已经冶炼完成的炉次
        /// </summary>
        /// <param name="onGoingLFHeatList">返回正在冶炼的炉次信息</param>
        /// <param name="doneLFHeatList">返回冶炼完成的炉次</param>
        /// <param name="toBeDoneLFHeatList">返回还未冶炼的炉次</param>
        /// <returns>所有炉次</returns>
        public IList<LFHeatInfo> GetLFHeatDetailInfo(out IList<LFHeatInfo> onGoingLFHeatList, out IList<LFHeatInfo> doneLFHeatList, out IList<LFHeatInfo> toBeDoneLFHeatList)
        {
            IList<LFHeatInfo> lfHeatList = dal.GetLFHeatInfo();
            onGoingLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "ON GOING").ToList();
            doneLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "DONE").ToList();
            toBeDoneLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "TO BE DONE").ToList();
            return lfHeatList;
        }

        /// <summary>
        /// 获取指定炉次号的所有炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>炉次信息</returns>
        public IList<LFHeatInfo> GetLFHeatInfo(string heatId)
        {
            IList<LFHeatInfo> lfHeatInfoList = dal.GetLFHeatInfo(heatId);
            return lfHeatInfoList;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数选取炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>炉次信息</returns>
        public LFHeatInfo GetLFHeatInfo(string heatId, int treatmentCount)
        {
            LFHeatQuality lfHeatQualityBLL = new LFHeatQuality();
            LFHeatInfo lfHeatInfo = dal.GetLFHeatInfo(heatId, treatmentCount);
            lfHeatInfo.LFHeatQualityList = lfHeatQualityBLL.GetLFHeatQualityInfo(lfHeatInfo.HeatId, lfHeatInfo.TreatmentCount);
            return lfHeatInfo;
        }

        /// <summary>
        /// 根据日期获取炉次信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>炉次信息</returns>
        public IList<LFHeatInfo> GetLFHeatInfo(DateTime startDate, DateTime endDate)
        {
            return dal.GetLFHeatInfo(startDate, endDate);
        }

        /// <summary>
        /// 获取炉次信息，包括未冶炼、正在冶炼和已经冶炼完成的炉次
        /// </summary>
        /// <param name="onGoingLFHeatList">返回正在冶炼的炉次信息</param>
        /// <param name="doneLFHeatList">返回冶炼完成的炉次</param>
        /// <param name="toBeDoneLFHeatList">返回还未冶炼的炉次</param>
        /// <returns>所有炉次</returns>
        public IList<LFHeatInfo> GetLFHeatDetailInfo(OracleTransaction trans, out IList<LFHeatInfo> onGoingLFHeatList, out IList<LFHeatInfo> doneLFHeatList, out IList<LFHeatInfo> toBeDoneLFHeatList)
        {
            IList<LFHeatInfo> lfHeatList = dal.GetLFHeatInfo(trans);
            onGoingLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "ON GOING").ToList();
            doneLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "DONE").ToList();
            toBeDoneLFHeatList = lfHeatList.Where<LFHeatInfo>(i => i.CurrentHeatStatus == "TO BE DONE").ToList();
            return lfHeatList;
        }

        /// <summary>
        /// 获取所有的炉次信息
        /// </summary>
        /// <returns>所有炉次信息</returns>
        public IList<LFHeatInfo> GetAllLFHeatPlan()
        {
            return dal.GetAllLFHeatPlan();
        }

        /// <summary>
        /// 选择指定炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void SetLFHeatSelectFlag(LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatSelectFlag(lfHeat, true);
        }
        /// <summary>
        /// 选择指定炉次
        /// </summary>
        /// <param name="trans">事务处理</param>
        /// <param name="lfHeat">炉次信息</param>
        public void SetLFHeatSelectFlag(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatSelectFlag(trans, lfHeat, true);
        }

        /// <summary>
        /// 取消指定炉次的选择标志
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void ResetLFHeatSelectFlag(LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatSelectFlag(lfHeat, false);
        }
        /// <summary>
        /// 取消指定炉次的选择标志
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void ResetLFHeatSelectFlag(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatSelectFlag(trans, lfHeat, false);
        }

        /// <summary>
        /// 将指定炉次的设置为可见
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void SetLFHeatVisible(LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatVisible(lfHeat, true);
        }
        /// <summary>
        /// 将指定炉次的设置为可见
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void SetLFHeatVisible(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatVisible(trans, lfHeat, true);
        }

        /// <summary>
        /// 将指定炉次的设置为不可见
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void ResetLFHeatVisible(LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatVisible(lfHeat, false);
        }
        /// <summary>
        /// 将指定炉次的设置为不可见
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void ResetLFHeatVisible(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.UpdateLFHeatVisible(trans, lfHeat, false);
        }


        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatInfo(LFHeatInfo lfHeat)
        {
            dal.DeleteLFHeatInfo(lfHeat);
        }
        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.DeleteLFHeatInfo(trans, lfHeat);
        }


        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatInfo(LFHeatInfo lfHeat)
        {
            dal.InsertLFHeatInfo(lfHeat);
        }

        /// <summary>
        /// 将炉次信息插入至TB_LF_L3_PLAN表
        /// </summary>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatPlan(LFHeatInfo lfHeat)
        {
            dal.InsertLFHeatPlan(lfHeat);
        }
        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.InsertLFHeatInfo(trans, lfHeat);
        }

        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        public void UpdateLFHeatInfoPK(LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat)
        {
            dal.UpdateLFHeatInfoPK(oldLFHeat, newLFHeat);
        }
        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        public void UpdateLFHeatInfoPK(OracleTransaction trans, LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat)
        {
            dal.UpdateLFHeatInfoPK(trans, oldLFHeat, newLFHeat);
        }


        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void SelectLFHeatInfo(LFHeatInfo lfHeat)
        {
            dal.SelectLFHeatInfo(lfHeat);
        }
        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void SelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.SelectLFHeatInfo(trans, lfHeat);
        }

        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void CancelSelectLFHeatInfo(LFHeatInfo lfHeat)
        {
            dal.CancelSelectLFHeatInfo(lfHeat);
        }
        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void CancelSelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.CancelSelectLFHeatInfo(trans, lfHeat);
        }


        /// <summary>
        /// 锁定关键区域
        /// </summary>
        /// <param name="trans">事务</param>
        public void LockCriticalArea(OracleTransaction trans)
        {
            dal.LockCriticalArea(trans);
        }

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatPlan(LFHeatInfo lfHeat)
        {
            dal.DeleteLFHeatPlan(lfHeat);
        }

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatPlan(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.DeleteLFHeatPlan(trans, lfHeat);
        }

        /// <summary>
        /// 处理状态6
        /// </summary>
        /// <param name="trans">所在事务</param>
        public void ProcessStatusSix(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            dal.ProcessStatusSix(trans, lfHeat);
        }

        /// <summary>
        /// 使用事务处理指定炉次的状态
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="signal">状态</param>
        public void ProcessStatus(OracleTransaction trans, LFHeatInfo lfHeat, ManualSignal signal)
        {
            dal.ProcessStatus(trans, lfHeat, signal);
        }

        /// <summary>
        /// 交换正在冶炼的两个工位的所有信息
        /// </summary>
        public void SwapCar(OracleTransaction trans)
        {
            dal.SwapCar(trans);
        }
    }
}
