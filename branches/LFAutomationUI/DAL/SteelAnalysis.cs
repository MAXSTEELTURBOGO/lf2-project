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
    public class SteelAnalysis : ISteelAnalysis
    {
        #region SQL && PARAMETER

        private const string SQL_SELECT_STEEL_ANALYSIS_BY_STEEL_GRADE_ID = @"SELECT T1.STEEL_GRADE_ID,
                                                                                    T1.ELEMENT_ID,
                                                                                    T2.ELEMENT_SHORT_NAME,
                                                                                    T2.ELEMENT_FULL_NAME,
                                                                                    T2.ELEMENT_TYPE,
                                                                                    T1.MIN_VALUE,
                                                                                    T1.AIM_VALUE,
                                                                                    T1.MAX_VALUE
                                                                               FROM TB_STEEL_ANALYSIS T1 LEFT JOIN TB_ELEMENT_INFO T2
                                                                              ON T1.ELEMENT_ID = T2.ELEMENT_ID
                                                                              WHERE (T1.MIN_VALUE IS NOT NULL
                                                                                OR T1.AIM_VALUE IS NOT NULL
                                                                                OR T1.MAX_VALUE IS NOT NULL)
                                                                                AND STEEL_GRADE_ID = :STEEL_GRADE_ID";
        private const string SQL_SELECT_STEEL_ANALYSIS_BY_HEAT_ID = @"SELECT V1.HEAT_ID,
                                                                               V1.STEEL_GRADE_ID,
                                                                               T1.ELEMENT_ID,
                                                                               V1.ELEMENT_SHORT_NAME,
                                                                               T1.ELEMENT_FULL_NAME,
                                                                               T1.ELEMENT_TYPE,
                                                                               V1.MIN_VALUE,
                                                                               V1.AIM_VALUE,
                                                                               V1.MAX_VALUE
                                                                          FROM V_STEEL_ANALYSIS V1 LEFT JOIN TB_ELEMENT_INFO T1
                                                                         ON V1.ELEMENT_SHORT_NAME = T1.ELEMENT_SHORT_NAME
                                                                          WHERE (V1.MIN_VALUE <> 0 OR V1.AIM_VALUE <> 0
                                                                            OR V1.MAX_VALUE <> 0)
                                                                           AND V1.HEAT_ID = :HEAT_ID";
        private const string SQL_SELECT_STEEL_ALL_ELEMENT_ANALYSIS_BY_STEEL_GRADE_ID = @"SELECT T1.ELEMENT_ID,
                                                                                                   T1.ELEMENT_SHORT_NAME,
                                                                                                   T1.ELEMENT_FULL_NAME,
                                                                                                   T1.ELEMENT_TYPE,
                                                                                                   NVL(T2.MIN_VALUE, 0) MIN_VALUE,
                                                                                                   NVL(T2.AIM_VALUE, 0) AIM_VALUE,
                                                                                                   NVL(T2.MAX_VALUE, 0) MAX_VALUE
                                                                                              FROM TB_ELEMENT_INFO T1
                                                                                              LEFT JOIN (SELECT *
                                                                                                           FROM TB_STEEL_ANALYSIS
                                                                                                          WHERE STEEL_GRADE_ID = :STEEL_GRADE_ID) T2
                                                                                                ON T1.ELEMENT_ID = T2.ELEMENT_ID
                                                                                             ORDER BY T1.ELEMENT_ID";
        private const string SQL_INSERT_STEEL_ANALYSIS = @"INSERT INTO TB_STEEL_ANALYSIS
                                                      (STEEL_GRADE_ID, ELEMENT_ID, MIN_VALUE, AIM_VALUE, MAX_VALUE)
                                                    VALUES
                                                      (:STEEL_GRADE_ID, :ELEMENT_ID, :MIN_VALUE, :AIM_VALUE, :MAX_VALUE)";

        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_STEEL_GRADE_ID = ":STEEL_GRADE_ID";
        private const string PARAM_ELEMENT_ID = ":ELEMENT_ID";
        private const string PARAM_MIN_VALUE = ":MIN_VALUE";
        private const string PARAM_AIM_VALUE = ":AIM_VALUE";
        private const string PARAM_MAX_VALUE = ":MAX_VALUE";

        #endregion

        #region ISteelAnalysis接口实现

        /// <summary>
        /// 通过钢种号获取钢种元素分析信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAnalysisBySteelGradeId(string steelGradeId)
        {
            IList<SteelAnalysisInfo> steelAnalisisInfos = new List<SteelAnalysisInfo>();
            OracleParameter param = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param.Value = steelGradeId == null ? (object)DBNull.Value : (object)steelGradeId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_STEEL_ANALYSIS_BY_STEEL_GRADE_ID, param))
            {
                while (odr.Read())
                {
                    if (odr[5] != DBNull.Value || odr[6] != DBNull.Value || odr[7] != DBNull.Value)
                    {
                        SteelAnalysisInfo steelAnalysisInfo = new SteelAnalysisInfo(null, null, 0, 0, 0);
                        ElementInfo elementInfo = new ElementInfo(0, null, null, null);
                        steelAnalysisInfo.SteelGradeId = odr.GetString(0);
                        elementInfo.ElementId = Convert.ToInt32(odr[1]);
                        elementInfo.ElementShortName = odr.GetString(2);
                        try
                        {
                            elementInfo.ElementFullName = odr.GetString(3);
                        }
                        catch 
                        {
                            elementInfo.ElementFullName = null;
                        }
                        elementInfo.ElementType = odr.GetString(4);
                        steelAnalysisInfo.MinValue = odr[5] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr[5]));
                        steelAnalysisInfo.AimValue = odr[6] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr[6]));
                        steelAnalysisInfo.MaxValue = odr[7] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr[7]));
                        steelAnalysisInfo.ElemInfo = elementInfo;
                        steelAnalisisInfos.Add(steelAnalysisInfo);
                    }
                }
            }
            return steelAnalisisInfos;
        }

        /// <summary>
        /// 通过钢种号获取钢种元素所有元素的最小 最大 目标值
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAllElementAnalysisBySteelGradeId(string steelGradeId)
        {
            IList<SteelAnalysisInfo> steelAnalisisInfos = new List<SteelAnalysisInfo>();
            OracleParameter param = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param.Value = steelGradeId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_STEEL_ALL_ELEMENT_ANALYSIS_BY_STEEL_GRADE_ID, param))
            {
                while (odr.Read())
                {
                    SteelAnalysisInfo steelAnalysisInfo = new SteelAnalysisInfo(steelGradeId, null, 0, 0, 0);
                    ElementInfo elementInfo = new ElementInfo(0, null, null, null);
                    elementInfo.ElementId = Convert.ToInt32(odr[0]);
                    elementInfo.ElementShortName = odr.GetString(1);
                    try
                    {
                        elementInfo.ElementFullName = odr.GetString(2);
                    }
                    catch
                    {
                        elementInfo.ElementFullName = null;
                    }
                    elementInfo.ElementType = odr.GetString(3);
                    steelAnalysisInfo.MinValue = odr["MIN_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MIN_VALUE"]));
                    steelAnalysisInfo.AimValue = odr["AIM_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AIM_VALUE"]));
                    steelAnalysisInfo.MaxValue = odr["MAX_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MAX_VALUE"]));
                    steelAnalysisInfo.ElemInfo = elementInfo;
                    steelAnalisisInfos.Add(steelAnalysisInfo);
                }
            }
            return steelAnalisisInfos;
        }

        /// <summary>
        /// 根据炉次号获取钢分析
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>钢分析</returns>
        public IList<SteelAnalysisInfo> GetSteelAnalysisByHeatId(string heatId)
        {
            IList<SteelAnalysisInfo> steelAnalisisInfos = new List<SteelAnalysisInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_STEEL_ANALYSIS_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    SteelAnalysisInfo steelAnalysisInfo = new SteelAnalysisInfo(steelGradeId, null, 0, 0, 0);
                    ElementInfo elementInfo = new ElementInfo(0, null, null, null);
                    elementInfo.ElementId = Convert.ToInt32(odr["ELEMENT_ID"]);
                    elementInfo.ElementShortName = odr["ELEMENT_SHORT_NAME"].ToString();
                    try
                    {
                        elementInfo.ElementFullName = odr["ELEMENT_FULL_NAME"].ToString();
                    }
                    catch
                    {
                        elementInfo.ElementFullName = null;
                    }
                    elementInfo.ElementType = odr["ELEMENT_TYPE"].ToString();
                    steelAnalysisInfo.MinValue = odr["MIN_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MIN_VALUE"]));
                    steelAnalysisInfo.AimValue = odr["AIM_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["AIM_VALUE"]));
                    steelAnalysisInfo.MaxValue = odr["MAX_VALUE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["MAX_VALUE"]));
                    steelAnalysisInfo.ElemInfo = elementInfo;
                    steelAnalisisInfos.Add(steelAnalysisInfo);
                }
            }
            return steelAnalisisInfos;
        }
        /// <summary>
        /// 插入钢种分析信息
        /// </summary>
        /// <param name="steelAnalysisInfos">钢种分析信息</param>
        public void InsSteelAnalysisInfos(SteelAnalysisInfo steelAnalysisInfo)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[5];
            param[index] = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param[index++].Value = steelAnalysisInfo.SteelGradeId;
            param[index] = new OracleParameter(PARAM_ELEMENT_ID, OracleType.Number);
            param[index++].Value = steelAnalysisInfo.ElemInfo.ElementId;
            param[index] = new OracleParameter(PARAM_MIN_VALUE, OracleType.Number);
            param[index++].Value = steelAnalysisInfo.MinValue;
            param[index] = new OracleParameter(PARAM_AIM_VALUE, OracleType.Number);
            param[index++].Value = steelAnalysisInfo.AimValue;
            param[index] = new OracleParameter(PARAM_MAX_VALUE, OracleType.Number);
            param[index++].Value = steelAnalysisInfo.MaxValue;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_STEEL_ANALYSIS, param);
        }
        #endregion
    }
}
