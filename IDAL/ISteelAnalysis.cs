using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface ISteelAnalysis
    {

        /// <summary>
        /// 通过钢种号获取钢种元素分析信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        IList<SteelAnalysisInfo> GetSteelAnalysisBySteelGradeId(string steelGradeId);

         /// <summary>
        /// 根据炉次号获取钢分析
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>钢分析</returns>
        IList<SteelAnalysisInfo> GetSteelAnalysisByHeatId(string heatId);

        /// <summary>
        /// 通过钢种号获取钢种元素所有元素的最小 最大 目标值
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        IList<SteelAnalysisInfo> GetSteelAllElementAnalysisBySteelGradeId(string steelGradeId);

        /// <summary>
        /// 插入钢种分析信息
        /// </summary>
        /// <param name="steelAnalysisInfos">钢种分析信息</param>
        void InsSteelAnalysisInfos(SteelAnalysisInfo steelAnalysisInfos);
    }
}
