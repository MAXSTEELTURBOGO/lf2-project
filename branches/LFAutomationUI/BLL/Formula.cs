using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class Formula
    {
        private static readonly IFormula dal = LFAutomationUI.DALFactory.DataAccess.CreateFormula();
        /// <summary>
        /// 从表tb_formula_info中获取所有公式信息
        /// </summary>
        /// <returns>公式信息</returns>
        public IList<FormulaInfo> GetAllFormulaInfo()
        {
            return dal.GetAllFormulaInfo();
        }
        /// <summary>
        /// 从表TB_STEEL_FORMULA_INFO获取所有的钢种公式信息
        /// </summary>
        /// <returns>所有钢种的公式信息</returns>
        public IList<FormulaInfo> GetALLSteelFormulaInfo()
        {
            return dal.GetALLSteelFormulaInfo();
        }
        /// <summary>
        /// 通过公式找到公式信息
        /// </summary>
        /// <param name="formulaDesc">公式</param>
        /// <returns>公式信息</returns>
        public FormulaInfo GetFormulaByFormulaDesc(string formulaDesc)
        {
            return dal.GetFormulaByFormulaDesc(formulaDesc);
        }


        /// <summary>
        /// 根据炉次号获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>公式列表</returns>
        public IList<FormulaInfo> GetFormulaListByHeatId(string heatId)
        {
            return dal.GetFormulaListByHeatId(heatId);
        }

        /// <summary>
        /// 根据钢种获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>公式列表</returns>
        public IList<FormulaInfo> GetFormulaListBySteelGradeId(string steelGradeId)
        {
            return dal.GetFormulaListBySteelGradeId(steelGradeId);
        }

        /// <summary>
        /// 插入新的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        public void InsertNewFormula(FormulaInfo formulaInfo)
        {
            dal.InsertNewFormula(formulaInfo);
        }

        /// <summary>
        /// 更新现有的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        public void UpdateFormula(FormulaInfo formulaInfo)
        {
            dal.UpdateFormula(formulaInfo);
        }
    }
}
