using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class SteelGradeDetails
    {
        private static readonly ISteelGradeDetails dal = LFAutomationUI.DALFactory.DataAccess.CreateSteelGrade();
        /// <summary>
        /// 获取钢种号列表
        /// </summary>
        /// <returns>钢种号</returns>
        public IList<string> GetSteelGradeIdList()
        {
            return dal.GetSteelGradeIdList();
        }
        /// <summary>
        /// 从钢种信息表(tb_steel_info)取出所有的钢种基本信息 
        /// </summary>
        /// <returns>所有钢种信息</returns>
        public IList<SteelGradeDetailInfo> GetAllSteelGradeInfo()
        {
            return dal.GetAllSteelGradeInfo();
        }
        /// <summary>
        /// 通过钢种号取出钢种的基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>该钢种基本信息</returns>
        public SteelGradeDetailInfo GetSteelGradeInfoBySteelGradeId(string steelGradeId)
        {
            return dal.GetSteelGradeInfoBySteelGradeId(steelGradeId);
        }
        /// <summary>
        /// 删除钢种基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        public void DeleteSteelGradeInfoBySteelGradeId(string steelGradeId)
        {
            dal.DeleteSteelGradeInfoBySteelGradeId(steelGradeId);
        }

        /// <summary>
        /// 插入钢钟信息
        /// </summary>
        /// <param name="steelGradeDetailInfos"></param>
        public void InsertSteelGradeInfo(SteelGradeDetailInfo steelGradeDetailInfo)
        {
            dal.InsertSteelGradeInfo(steelGradeDetailInfo);
        }

        public void UpdateSteelGradeBasicInfo(SteelGradeDetailInfo steelGradeInfo)
        {
            dal.DeleteSteelGradeInfoBySteelGradeId(steelGradeInfo.SteelGradeId);
            dal.InsertSteelGradeInfo(steelGradeInfo);
        }

        /// <summary>
        /// 更新钢种液相线温度
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <param name="liquidTemp">液相线温度</param>
        public void UpdateSteelGradeLiquidTemp(string steelGradeId, double liquidTemp)
        {
            dal.UpdateSteelGradeLiquidTemp(steelGradeId, liquidTemp);
        }
    }
}
