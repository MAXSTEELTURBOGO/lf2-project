using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IFormula
    {
        /// <summary>
        /// 从表tb_formula_info中获取所有公式信息
        /// </summary>
        /// <returns>公式信息</returns>
        IList<FormulaInfo> GetAllFormulaInfo();

        /// <summary>
        /// 从表TB_STEEL_FORMULA_INFO获取所有的钢种公式信息
        /// </summary>
        /// <returns>所有钢种的公式信息</returns>
        IList<FormulaInfo> GetALLSteelFormulaInfo();

        /// <summary>
        /// 通过公式找到公式信息
        /// </summary>
        /// <param name="formulaDesc">公式</param>
        /// <returns>公式信息</returns>
        FormulaInfo GetFormulaByFormulaDesc(string formulaDesc);


        /// <summary>
        /// 根据炉次号获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>公式列表</returns>
        IList<FormulaInfo> GetFormulaListByHeatId(string heatId);

        /// <summary>
        /// 根据钢种获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>公式列表</returns>
        IList<FormulaInfo> GetFormulaListBySteelGradeId(string steelGradeId);

        /// <summary>
        /// 插入新的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        void InsertNewFormula(FormulaInfo formulaInfo);

        /// <summary>
        /// 更新现有的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        void UpdateFormula(FormulaInfo formulaInfo);

        /// <summary>
        /// 根据钢种号删除钢种公式信息
        /// </summary>
        /// <param name="steelGradeId"></param>
        void DeleteSteelFormulaBySteelGradeId(string steelGradeId);

        /// <summary>
        /// 插入钢种公式信息
        /// </summary>
        /// <param name="formulaList"></param>
        void InsertSteelFormula(IList<FormulaInfo> formulaList);
    }
}
