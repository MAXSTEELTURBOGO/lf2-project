using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class Formula : IFormula
    {
        #region SQL && PARAMETER
        private const string SQL_GET_ALL_FORMULA_INFO = @"SELECT FORMULA_ID, 
                                                                   FORMULA_TYPE,
                                                                   FORMULA
                                                              FROM TB_FORMULA_INFO";

        private const string SQL_GET_ALL_STEEL_FORMULA = @"SELECT T1.STEEL_GRADE_ID, T1.FORMULA_ID, T2.FORMULA_TYPE, T2.FORMULA
                                                              FROM TB_STEEL_FORMULA_INFO T1
                                                              LEFT JOIN TB_FORMULA_INFO T2
                                                                ON T1.FORMULA_ID = T2.FORMULA_ID";

        private const string SQL_GET_FORMULA_BY_FORMULA = @"SELECT FORMULA_ID, 
                                                                       FORMULA_TYPE,
                                                                       FORMULA
                                                                  FROM TB_FORMULA_INFO
                                                                 WHERE FORMULA = :FORMULA";


        private const string SQL_GET_FORMULA_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                   MSG_TIME_STAMP,
                                                                   HEAT_ID,
                                                                   STEEL_GRADE_ID,
                                                                   FORMULA_TYPE,
                                                                   FORMULA_ID,
                                                                   FORMULA,
                                                                   FORMULA_MIN,
                                                                   FORMULA_MAX,
                                                                   FORMULA_AIM
                                                              FROM V_STEEL_FORMULA_INFO
                                                              WHERE HEAT_ID =:HEAT_ID";

        private const string SQL_GET_FORMULA_BY_STEEL_GRADE_ID = @"SELECT  T1.STEEL_GRADE_ID,
                                                                           T1.FORMULA_TYPE,
                                                                           T1.FORMULA_ID,
                                                                           T2.FORMULA
                                                                      FROM TB_STEEL_FORMULA_INFO T1
                                                                      LEFT JOIN TB_FORMULA_INFO T2
                                                                        ON T1.FORMULA_ID = T2.FORMULA_ID
                                                                      WHERE T1.STEEL_GRADE_ID  = :STEEL_GRADE_ID";

        private const string SQL_INSERT_FORMULA = @"INSERT INTO TB_FORMULA_INFO
                                                      (FORMULA_ID, FORMULA_TYPE, FORMULA)
                                                    VALUES
                                                      (:FORMULA_ID, :FORMULA_TYPE, :FORMULA)";

        private const string SQL_UPDATE_FORMULA = @"UPDATE TB_FORMULA_INFO T
                                                       SET T.FORMULA_TYPE = :FORMULA_TYPE, T.FORMULA = :FORMULA
                                                     WHERE T.FORMULA_ID = :FORMULA_ID";

        private const string PARAM_STEEL_GRADE_ID = ":STEEL_GRADE_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_FORMULA_ID = ":FORMULA_ID";
        private const string PARAM_FORMULA_TYPE = ":FORMULA_TYPE";
        private const string PARAM_FORMULA = ":FORMULA";
        #endregion

        #region 实现IFormula接口中的方法
        /// <summary>
        /// 从表tb_formula_info中获取所有公式信息
        /// </summary>
        /// <returns>公式信息</returns>
        public IList<FormulaInfo> GetAllFormulaInfo()
        {
            IList<FormulaInfo> formulaInfos = new List<FormulaInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_ALL_FORMULA_INFO, null))
            {
                while (odr.Read())
                {
                    FormulaInfo formulaInfo = new FormulaInfo();

                    formulaInfo.FormulaId = odr[0].ToString();
                    formulaInfo.FormulaType = odr[1].ToString();
                    formulaInfo.Formula = odr[2].ToString();

                    formulaInfos.Add(formulaInfo);
                }
            }
            return formulaInfos;
        }

        /// <summary>
        /// 从表TB_STEEL_FORMULA_INFO获取所有的钢种公式信息
        /// </summary>
        /// <returns>所有钢种的公式信息</returns>
        public IList<FormulaInfo> GetALLSteelFormulaInfo()
        {
            IList<FormulaInfo> steelFormulaList = new List<FormulaInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_ALL_STEEL_FORMULA, null))
            {
                while (odr.Read())
                {
                    FormulaInfo formulaInfo = new FormulaInfo();
                    formulaInfo.FormulaId = odr["FORMULA_ID"].ToString();
                    formulaInfo.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    formulaInfo.FormulaType = odr["FORMULA_TYPE"].ToString();
                    formulaInfo.Formula = odr["FORMULA"].ToString();
                    steelFormulaList.Add(formulaInfo);
                }
            }
            return steelFormulaList;
        }

        /// <summary>
        /// 通过公式找到公式代号
        /// </summary>
        /// <param name="formulaDesc">公式</param>
        /// <returns>公式代号 formulaId</returns>
        public FormulaInfo GetFormulaByFormulaDesc(string formulaDesc)
        {
            FormulaInfo formulaInfo = null;

            OracleParameter param = new OracleParameter(PARAM_FORMULA, OracleType.VarChar);
            param.Value = formulaDesc;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_FORMULA_BY_FORMULA, param))
            {
                while (odr.Read())
                {
                    formulaInfo = new FormulaInfo();
                    formulaInfo.FormulaId = odr[0].ToString();
                    formulaInfo.FormulaType = odr[1].ToString();
                    formulaInfo.Formula = odr[2].ToString();
                }
            }
            return formulaInfo;
        }


        /// <summary>
        /// 根据炉次号获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>公式列表</returns>
        public IList<FormulaInfo> GetFormulaListByHeatId(string heatId)
        {
            IList<FormulaInfo> formulaList = new List<FormulaInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_FORMULA_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    FormulaInfo formula = new FormulaInfo();
                    formula.HeatId = odr["HEAT_ID"].ToString();
                    formula.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    formula.FormulaId = odr["FORMULA_ID"].ToString();
                    formula.FormulaType = odr["FORMULA_TYPE"].ToString();
                    formula.Formula = odr["FORMULA"].ToString();
                    formulaList.Add(formula);
                }
            }

            return formulaList;
        }

        /// <summary>
        /// 根据钢种获取该炉次冶炼钢种的公式信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>公式列表</returns>
        public IList<FormulaInfo> GetFormulaListBySteelGradeId(string steelGradeId)
        {
            IList<FormulaInfo> formulaList = new List<FormulaInfo>();
            OracleParameter param = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param.Value = steelGradeId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_FORMULA_BY_STEEL_GRADE_ID, param))
            {
                while (odr.Read())
                {
                    FormulaInfo formula = new FormulaInfo();
                    formula.SteelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    formula.FormulaId = odr["FORMULA_ID"].ToString();
                    formula.FormulaType = odr["FORMULA_TYPE"].ToString();
                    formula.Formula = odr["FORMULA"].ToString();
                    formulaList.Add(formula);
                }
            }
            return formulaList;
        }

        /// <summary>
        /// 插入新的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        public void InsertNewFormula(FormulaInfo formulaInfo)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_FORMULA_ID, OracleType.VarChar);
            param[0].Value = formulaInfo.FormulaId;
            param[1] = new OracleParameter(PARAM_FORMULA_TYPE, OracleType.VarChar);
            param[1].Value = formulaInfo.FormulaType;
            param[2] = new OracleParameter(PARAM_FORMULA, OracleType.VarChar);
            param[2].Value = formulaInfo.Formula;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_FORMULA, param);
        }

        /// <summary>
        /// 更新现有的公式信息
        /// </summary>
        /// <param name="formulaInfo">公式信息</param>
        public void UpdateFormula(FormulaInfo formulaInfo)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_FORMULA_ID, OracleType.VarChar);
            param[0].Value = formulaInfo.FormulaId;
            param[1] = new OracleParameter(PARAM_FORMULA_TYPE, OracleType.VarChar);
            param[1].Value = formulaInfo.FormulaType;
            param[2] = new OracleParameter(PARAM_FORMULA, OracleType.VarChar);
            param[2].Value = formulaInfo.Formula;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_FORMULA, param);
        }

        /// <summary>
        /// 根据钢种号删除钢种公式信息
        /// </summary>
        /// <param name="steelGradeId"></param>
        public void DeleteSteelFormulaBySteelGradeId(string steelGradeId)
        {

        }

        /// <summary>
        /// 插入钢种公式信息
        /// </summary>
        /// <param name="formulaList"></param>
        public void InsertSteelFormula(IList<FormulaInfo> formulaList)
        { }

        #endregion
    }
}
