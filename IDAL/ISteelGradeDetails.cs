using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ISteelGradeDetails
    {
        /// <summary>
        /// 获取钢种号列表
        /// </summary>
        /// <returns>钢种号</returns>
        IList<string> GetSteelGradeIdList();
        /// <summary>
        /// 从钢种信息表取出所有的钢种基本信息 tb_steel_info
        /// </summary>
        /// <returns>所有钢种信息</returns>
        IList<SteelGradeDetailInfo> GetAllSteelGradeInfo();
        /// <summary>
        /// 通过钢种号取出钢种的基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>该钢种基本信息</returns>
        SteelGradeDetailInfo GetSteelGradeInfoBySteelGradeId(string steelGradeId);
        /// <summary>
        /// 删除钢种基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        void DeleteSteelGradeInfoBySteelGradeId(string steelGradeId);
        /// <summary>
        /// 插入钢钟信息
        /// </summary>
        /// <param name="steelGradeDetailInfos"></param>
        void InsertSteelGradeInfo(SteelGradeDetailInfo steelGradeDetailInfos);

        /// <summary>
        /// 更新钢种液相线温度
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <param name="liquidTemp">液相线温度</param>
        void UpdateSteelGradeLiquidTemp(string steelGradeId, double liquidTemp);
    }
}
