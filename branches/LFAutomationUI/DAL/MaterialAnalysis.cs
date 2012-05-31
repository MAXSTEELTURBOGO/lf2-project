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
    public class MaterialAnalysis : IMaterialAnalysis
    {
        #region SQL && PARAM

        private const string SQL_SELECT_ALL_MAT_ANALYSIS = @"SELECT  T1.MATERIAL_ID,
                                                               T1.ELEMENT_ID,
                                                               T2.ELEMENT_SHORT_NAME,
                                                               T2.ELEMENT_FULL_NAME,
                                                               T2.ELEMENT_TYPE,
                                                               T1.NET_CONTENT,
                                                               T1.YIELD
                                                          FROM TB_MATERIAL_ANALYSIS T1
                                                          LEFT JOIN TB_ELEMENT_INFO T2
                                                            ON T1.ELEMENT_ID = T2.ELEMENT_ID";

        private const string SQL_SEL_ALL_ELEMENT_MATL_ANALYSIS_BY_MAT_ID = @"SELECT  T1.ELEMENT_ID,
                                                                               T1.ELEMENT_SHORT_NAME,
                                                                               T1.ELEMENT_FULL_NAME,
                                                                               T1.ELEMENT_TYPE,
                                                                               T2.NET_CONTENT,
                                                                               T2.YIELD
                                                                          FROM TB_ELEMENT_INFO T1
                                                                          LEFT JOIN (SELECT * FROM TB_MATERIAL_ANALYSIS WHERE MATERIAL_ID = :MATERIAL_ID) T2
                                                                            ON T1.ELEMENT_ID = T2.ELEMENT_ID
                                                                         ORDER BY T1.ELEMENT_ID";

        private const string SQL_INSERT_MATERIAL_ANALYSIS_INFO = @"INSERT INTO TB_MATERIAL_ANALYSIS
                                                               (MATERIAL_ID, ELEMENT_ID, NET_CONTENT, YIELD)
                                                             VALUES
                                                               (:MATERIAL_ID,
                                                                (SELECT ELEMENT_ID FROM TB_ELEMENT_INFO WHERE ELEMENT_SHORT_NAME = :ELEMENT_SHORT_NAME),
                                                                :NET_CONTENT,
                                                                :YIELD)";

        private const string SQL_DEL_MAT_ANALYSIS_INFO_BY_MAT_ID = @"DELETE FROM TB_MATERIAL_ANALYSIS WHERE MATERIAL_ID=:MATERIAL_ID";

        private const string PARAM_MATERIAL_ID = ":MATERIAL_ID";
        private const string PARAM_ELEMENT_SHORT_NAME = ":ELEMENT_SHORT_NAME";
        private const string PARAM_NET_CONTENT = ":NET_CONTENT";
        private const string PARAM_YIELD = ":YIELD";

        #endregion

        #region Methods

        /// <summary>
        /// 取得所有物料的元素分析信息
        /// </summary>
        /// <returns>元素分析信息</returns>
        public IList<MaterialAnalysisInfo> GetAllMaterialAnalysis()
        {
            IList<MaterialAnalysisInfo> materialAnalysisInfos = new List<MaterialAnalysisInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_MAT_ANALYSIS,null))
            {
                while (odr.Read())
                {
                    ElementInfo elementInfo = new ElementInfo(null, null, null, null);
                    MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 0);
                    materialAnalysisInfo.MaterialId = Convert.ToInt32(odr[0]);
                    elementInfo.ElementId = Convert.ToInt32(odr.GetOracleNumber(1).ToString());
                    try
                    {
                        elementInfo.ElementShortName = odr.GetString(2);
                    }
                    catch
                    {
                        elementInfo.ElementShortName = "";
                    }
                    try
                    {
                        elementInfo.ElementFullName = odr.GetString(3);
                    }
                    catch
                    {
                        elementInfo.ElementFullName = "";
                    }
                    elementInfo.ElementType = odr.GetString(4);
                    try
                    {
                        materialAnalysisInfo.NetContent = Convert.ToDouble(odr.GetOracleNumber(5).ToString());
                    }
                    catch
                    {
                        materialAnalysisInfo.NetContent = 0;
                    }
                    try
                    {
                        materialAnalysisInfo.Yield = Convert.ToDouble(odr.GetOracleNumber(6).ToString());
                    }
                    catch
                    {
                        materialAnalysisInfo.Yield = 100;
                    }
                    materialAnalysisInfo.ElemInfo = elementInfo;
                    materialAnalysisInfos.Add(materialAnalysisInfo);
                }
            }
            return materialAnalysisInfos;
        }

        /// <summary>
        /// 通过物料代码获取该物料的含量信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>含量信息</returns>
        public IList<MaterialAnalysisInfo> GetMaterialAnalysisByMaterialid(int materialId)
        {

            IList<MaterialAnalysisInfo> materialAnalysisInfos = new List<MaterialAnalysisInfo>();
            OracleParameter param = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
            param.Value = materialId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SEL_ALL_ELEMENT_MATL_ANALYSIS_BY_MAT_ID, param))
            {
                while (odr.Read())
                {
                    ElementInfo elementInfo = new ElementInfo(null, null, null, null);
                    MaterialAnalysisInfo materialAnalysisInfo = new MaterialAnalysisInfo(0, null, 0, 0);
                    materialAnalysisInfo.MaterialId = materialId;
                    elementInfo.ElementId = Convert.ToInt32(odr.GetOracleNumber(0).ToString());
                    try
                    {
                        elementInfo.ElementShortName = odr.GetString(1);
                    }
                    catch
                    {
                        elementInfo.ElementShortName = "";
                    }
                    try
                    {
                        elementInfo.ElementFullName = odr.GetString(2);
                    }
                    catch
                    {
                        elementInfo.ElementFullName = "";
                    }
                    elementInfo.ElementType = odr.GetString(3);
                    try
                    {
                        materialAnalysisInfo.NetContent = Convert.ToDouble(odr.GetOracleNumber(4).ToString());
                    }
                    catch
                    {
                        materialAnalysisInfo.NetContent = 0;
                    }
                    try
                    {
                        materialAnalysisInfo.Yield = Convert.ToDouble(odr.GetOracleNumber(5).ToString());
                    }
                    catch
                    {
                        materialAnalysisInfo.Yield = 100;
                    }
                    materialAnalysisInfo.ElemInfo = elementInfo;
                    materialAnalysisInfos.Add(materialAnalysisInfo);
                }
            }
            return materialAnalysisInfos;
        }

        /// <summary>
        /// 给物料元素信息表插入元素含量与收得率信息
        /// </summary>
        /// <param name="materialAnalysisInfos">物料元素信息</param>
        public void InsertMaterialAnalysisInfo(IList<MaterialAnalysisInfo> materialAnalysisInfos)
        {
            foreach (MaterialAnalysisInfo materialAnalysisInfo in materialAnalysisInfos)
            {
                int index = 0;
                OracleParameter[] param = new OracleParameter[4];
                param[index] = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
                param[index++].Value = materialAnalysisInfo.MaterialId;
                param[index] = new OracleParameter(PARAM_ELEMENT_SHORT_NAME, OracleType.VarChar);
                param[index++].Value = materialAnalysisInfo.ElemInfo.ElementShortName;
                param[index] = new OracleParameter(PARAM_NET_CONTENT, OracleType.Number);
                param[index++].Value = materialAnalysisInfo.NetContent;
                param[index] = new OracleParameter(PARAM_YIELD, OracleType.Number);
                param[index].Value = materialAnalysisInfo.Yield;
                OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_MATERIAL_ANALYSIS_INFO, param);
            }

        }

        /// <summary>
        /// 通过物料代码删除物料元素信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        public void DeleteMaterialAnalysisInfoByMatId(decimal materialId)
        {
            OracleParameter param = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
            param.Value = materialId;
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DEL_MAT_ANALYSIS_INFO_BY_MAT_ID, param);
        }
        #endregion  
    }
}
