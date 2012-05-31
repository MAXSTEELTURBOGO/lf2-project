using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.DALFactory;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class SteelAnalysis
    {
        private static readonly ISteelAnalysis dal = LFAutomationUI.DALFactory.DataAccess.CreateSteelAnalysis();

        /// <summary>
        /// 通过钢种号获取钢种元素分析信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAnalysisBySteelGradeId(string steelGradeId)
        {
            return dal.GetSteelAnalysisBySteelGradeId(steelGradeId);
        }


        /// <summary>
        /// 根据炉次号获取钢分析
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAnalysisByHeatId(string heatId)
        {
            return dal.GetSteelAnalysisByHeatId(heatId);
        }

        /// <summary>
        /// 通过钢种号获取钢种元素所有元素的最小 最大 目标值
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAllElementAnalysisBySteelGradeId(string steelGradeId)
        {
            return dal.GetSteelAllElementAnalysisBySteelGradeId(steelGradeId);
        }

        /// <summary>
        /// 插入钢种分析信息
        /// </summary>
        /// <param name="steelAnalysisInfos">钢种分析信息</param>
        public void InsSteelAnalysisInfos(IList<SteelAnalysisInfo> steelAnalysisInfos)
        {
            foreach (SteelAnalysisInfo steelAnalysisInfo in steelAnalysisInfos)
            {
                dal.InsSteelAnalysisInfos(steelAnalysisInfo);
            }
        }

    }
}
