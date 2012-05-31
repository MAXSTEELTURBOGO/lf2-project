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
    public class Material : IMaterial
    {
        #region SQL

        private const string SQL_SELECT_MATERIAL_INFO_BY_MATERIAL_ID = "SELECT  MATERIAL_ID,"
                                                                            + " MATERIAL_L3_ID,"
                                                                            + " MATERIAL_NAME,"
                                                                            + " MATERIAL_TYPE_ID,"
                                                                            + " MATERIAL_TYPE_NAME,"
                                                                            + " NOTE,"
                                                                            + " MATERIAL_DESC,"
                                                                            + " SHAPE,"
                                                                            + " WIRE_SPEC_WGT,"
                                                                            + " BULK_SPEC_WGT,"
                                                                            + " CHILL_FACTOR,"
                                                                            + " FE_CONTENTS, "
                                                                            + " YIELD "
                                                                            + " FROM V_MATERIAL_INFO V1 "
                                                                        + " WHERE V1.MATERIAL_ID=:MATERIAL_ID";

        private const string SQL_SELECT_ALL_MATERIAL_INFO = "SELECT  MATERIAL_ID,"
                                                                 + " MATERIAL_L3_ID,"
                                                                 + " MATERIAL_NAME,"
                                                                 + " MATERIAL_TYPE_ID,"
                                                                 + " MATERIAL_TYPE_NAME,"
                                                                 + " NOTE,"
                                                                 + " MATERIAL_DESC,"
                                                                 + " SHAPE,"
                                                                 + " WIRE_SPEC_WGT,"
                                                                 + " BULK_SPEC_WGT,"
                                                                 + " CHILL_FACTOR,"
                                                                 + " FE_CONTENTS, "
                                                                 + " YIELD "
                                                         + " FROM V_MATERIAL_INFO V1 "
                                                         + " ORDER BY V1.MATERIAL_ID ";

        private const string SQL_DELETE_MATERIAL_INFO_BY_MATERIAL_ID = "DELETE FROM TB_MATERIAL_INFO WHERE MATERIAL_ID=:MATERIAL_ID";

        private const string SQL_INSERT_MATERIAL_INFO = @"INSERT INTO TB_MATERIAL_INFO
                                                              (MATERIAL_ID,
                                                               MATERIAL_L3_ID,
                                                               MATERIAL_NAME,
                                                               MATERIAL_TYPE_ID,
                                                               SHAPE,
                                                               NOTE,
                                                               MATERIAL_DESC,
                                                               WIRE_SPEC_WGT,
                                                               BULK_SPEC_WGT,
                                                               CHILL_FACTOR,
                                                               FE_CONTENTS,
                                                               YIELD)
                                                            VALUES
                                                             ( :MATERIAL_ID,
                                                               :MATERIAL_L3_ID,
                                                               :MATERIAL_NAME,
                                                               :MATERIAL_TYPE_ID,
                                                               :SHAPE,
                                                               :MATERIAL_NOTE,
                                                               :MATERIAL_DESC,
                                                               :WIRE_SPEC_WGT,
                                                               :BULK_SPEC_WGT,
                                                               :CHILL_FACTOR,
                                                               :FE_CONTENTS,
                                                               :YIELD)";
        private const string SQL_UPDATE_MATERIAL_INFO = @"UPDATE TB_MATERIAL_INFO T
                                                           SET T.MATERIAL_L3_ID   = :MATERIAL_L3_ID,
                                                               T.MATERIAL_NAME    = :MATERIAL_NAME,
                                                               T.MATERIAL_TYPE_ID = :MATERIAL_TYPE_ID,
                                                               T.MATERIAL_DESC    = :MATERIAL_DESC,
                                                               T.SHAPE            = :SHAPE,
                                                               T.NOTE             = :MATERIAL_NOTE,
                                                               T.WIRE_SPEC_WGT    = :WIRE_SPEC_WGT,
                                                               T.BULK_SPEC_WGT    = :BULK_SPEC_WGT,
                                                               T.CHILL_FACTOR     = :CHILL_FACTOR,
                                                               T.FE_CONTENTS      = :FE_CONTENTS,
                                                               T.YIELD            = :YIELD
                                                         WHERE T.MATERIAL_ID = :MATERIAL_ID";
        private const string SQL_UPDATE_MATERIAL_CHILL_FACTOR = @"UPDATE TB_MATERIAL_INFO T
                                                                   SET  T.CHILL_FACTOR     = :CHILL_FACTOR
                                                                 WHERE T.MATERIAL_ID = :MATERIAL_ID";
        #endregion
        #region PARAM
        private string PARAM_MATERIAL_ID = ":MATERIAL_ID";
        private string PARAM_MATERIAL_L3_ID = ":MATERIAL_L3_ID";
        private string PARAM_MATERIAL_NAME = ":MATERIAL_NAME";
        private string PARAM_MATERIAL_TYPE = ":MATERIAL_TYPE_ID";
        private string PARAM_SHAPE = ":SHAPE";
        private string PARAM_MATERIAL_NOTE = ":MATERIAL_NOTE";
        private string PARAM_MATERIAL_DESC = ":MATERIAL_DESC";
        private string PARAM_WIRE_SPEC_WGT = ":WIRE_SPEC_WGT";
        private string PARAM_BULK_SPEC_WGT = ":BULK_SPEC_WGT";
        private string PARAM_CHILL_FACTOR = ":CHILL_FACTOR";
        private string PARAM_FE_CONTENTS = ":FE_CONTENTS";
        private string PARAM_YIELD = ":YIELD";
        #endregion
        #region Methods
        /// <summary>
        /// 取得所有的物料信息
        /// </summary>
        /// <returns>物料信息</returns>
        public IList<MaterialInfo> GetAllMaterialInfos()
        {
            IList<MaterialInfo> materialInfos = new List<MaterialInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_MATERIAL_INFO, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    MaterialAnalysis materialAnalysis = new MaterialAnalysis();
                    IList<MaterialAnalysisInfo> materialAnalysisInfos = materialAnalysis.GetAllMaterialAnalysis();
                    var enumMaterialBasicinfo = (from i in dt.AsEnumerable()
                                                 select new
                                                 {
                                                     materialId = Convert.ToDecimal(i[0]),
                                                     materialL3Id = i[1].ToString(),
                                                     materialName = i[2].ToString(),
                                                     materialTypeId = i[3] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i[3])),
                                                     materialTypeName = i[4].ToString(),
                                                     note = i[5].ToString(),
                                                     materialDesc = i[6].ToString(),
                                                     shape = i[7].ToString(),
                                                     wireSpecWgt = i[8] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i[8])),
                                                     bulkSpecWgt = i[9] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i[9])),
                                                     chillFactor = i[10] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i[10])),
                                                     feContents = i[11] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i[11])),
                                                     yield = i[12] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i[12]))
                                                 }).Distinct();
                    foreach (var i in enumMaterialBasicinfo)
                    {
                        IList<MaterialAnalysisInfo> materialAnalysisList = (from j in materialAnalysisInfos
                                                                            where j.MaterialId == i.materialId
                                                                            select j).ToList<MaterialAnalysisInfo>();
                        MaterialTypeInfo materialTypeInfo = new MaterialTypeInfo(i.materialTypeId, i.materialTypeName);
                        MaterialInfo materialInfo = new MaterialInfo(i.materialId, i.materialL3Id, i.materialName, materialTypeInfo, i.note, i.materialDesc, i.shape, i.wireSpecWgt,
                                                                        i.bulkSpecWgt, i.chillFactor, i.feContents, i.yield, materialAnalysisList);
                        materialInfos.Add(materialInfo);
                    }
                }
            }
            return materialInfos;
        }
        /// <summary>
        /// 根据物料代码取得物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        /// <returns>物料信息</returns>
        public MaterialInfo GetMaterialInfoByMaterialId(decimal materialId)
        {
            MaterialInfo materialInfo = new MaterialInfo(0, "", "", null, null, null, null, null, null, null, null, null, null);
            OracleParameter param = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
            param.Value = materialId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_MATERIAL_INFO_BY_MATERIAL_ID, param))
            {
                while (odr.Read())
                {
                    materialInfo.MaterialId = Convert.ToDecimal(odr.GetOracleNumber(0).ToString());
                    try
                    {
                        materialInfo.MaterialL3Id = odr.GetString(1);
                    }
                    catch
                    {
                        materialInfo.MaterialL3Id = "";
                    }
                    materialInfo.MaterialName = odr.GetString(2);
                    materialInfo.MatTypeInfo.MaterialTypeId = Convert.ToInt32(odr.GetOracleNumber(3).ToString());
                    materialInfo.MatTypeInfo.MaterialTypeName = odr.GetString(4);
                    try
                    {
                        materialInfo.MaterialNote = odr.GetString(5);
                    }
                    catch
                    {
                        materialInfo.MaterialNote = "";
                    }
                    try
                    {
                        materialInfo.MaterialDesc = odr.GetString(6);
                    }
                    catch
                    {
                        materialInfo.MaterialDesc = "";
                    }
                    try
                    {
                        materialInfo.MaterialShape = odr.GetString(7);
                    }
                    catch
                    {
                        materialInfo.MaterialShape = "";
                    }
                    try
                    {
                        materialInfo.WireSpecWgt = Convert.ToDouble(odr.GetOracleNumber(8).ToString());
                    }
                    catch
                    {
                        materialInfo.WireSpecWgt = 0;
                    }
                    try
                    {
                        materialInfo.BulkSpecWgt = Convert.ToDouble(odr.GetOracleNumber(9).ToString());
                    }
                    catch
                    {
                        materialInfo.BulkSpecWgt = 0;
                    }
                    try
                    {
                        materialInfo.ChillFactor = Convert.ToDouble(odr.GetOracleNumber(10).ToString());
                    }
                    catch
                    {
                        materialInfo.ChillFactor = 0;
                    }
                    try
                    {
                        materialInfo.FeContents = Convert.ToDouble(odr.GetOracleNumber(15).ToString());
                    }
                    catch
                    {
                        materialInfo.FeContents = 0;
                    }
                    materialInfo.Yield = Convert.ToDouble(odr.GetOracleNumber(16).ToString());
                }
            }
            return materialInfo;
        }

        /// <summary>
        /// 插入新的物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        public void InsertMaterialInfo(MaterialInfo materialInfo)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[12];
            param[index] = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number, 10);
            param[index++].Value = materialInfo.MaterialId;
            param[index] = new OracleParameter(PARAM_MATERIAL_L3_ID, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialL3Id == null ? DBNull.Value : (object)(materialInfo.MaterialL3Id);
            param[index] = new OracleParameter(PARAM_MATERIAL_NAME, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialName;
            param[index] = new OracleParameter(PARAM_MATERIAL_TYPE, OracleType.VarChar);
            param[index++].Value = materialInfo.MatTypeInfo.MaterialTypeId == null ? DBNull.Value : (object)(materialInfo.MatTypeInfo.MaterialTypeId);
            param[index] = new OracleParameter(PARAM_SHAPE, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialShape == null ? DBNull.Value : (object)(materialInfo.MaterialShape);
            param[index] = new OracleParameter(PARAM_MATERIAL_NOTE, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialNote == null ? DBNull.Value : (object)(materialInfo.MaterialNote);
            param[index] = new OracleParameter(PARAM_MATERIAL_DESC, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialDesc == null ? DBNull.Value : (object)(materialInfo.MaterialDesc);
            param[index] = new OracleParameter(PARAM_WIRE_SPEC_WGT, OracleType.Number);
            param[index++].Value = materialInfo.WireSpecWgt == null ? DBNull.Value : (object)(materialInfo.WireSpecWgt);
            param[index] = new OracleParameter(PARAM_BULK_SPEC_WGT, OracleType.Number);
            param[index++].Value = materialInfo.BulkSpecWgt == null ? DBNull.Value : (object)(materialInfo.BulkSpecWgt);
            param[index] = new OracleParameter(PARAM_CHILL_FACTOR, OracleType.Number);
            param[index++].Value = materialInfo.ChillFactor == null ? DBNull.Value : (object)(materialInfo.ChillFactor);
            param[index] = new OracleParameter(PARAM_FE_CONTENTS, OracleType.Number);
            param[index++].Value = materialInfo.FeContents == null ? DBNull.Value : (object)(materialInfo.FeContents);
            param[index] = new OracleParameter(PARAM_YIELD, OracleType.Number);
            param[index].Value = materialInfo.Yield == null ? DBNull.Value : (object)(materialInfo.Yield);
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_MATERIAL_INFO, param);
        }

        /// <summary>
        /// 根据物料代码删除物料信息
        /// </summary>
        /// <param name="materialId">物料代码</param>
        public void DeleteMaterialInfo(decimal materialId)
        {
            OracleParameter param = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number);
            param.Value = materialId;
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_MATERIAL_INFO_BY_MATERIAL_ID, param);
        }

        /// <summary>
        /// 根据物料ID更新物料信息
        /// </summary>
        /// <param name="materialInfo">物料信息内容</param>
        public void UpdateMaterialInfo(MaterialInfo materialInfo)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[12];
            param[index] = new OracleParameter(PARAM_MATERIAL_ID, OracleType.Number, 10);
            param[index++].Value = materialInfo.MaterialId;
            param[index] = new OracleParameter(PARAM_MATERIAL_L3_ID, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialL3Id == null ? DBNull.Value : (object)(materialInfo.MaterialL3Id);
            param[index] = new OracleParameter(PARAM_MATERIAL_NAME, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialName;
            param[index] = new OracleParameter(PARAM_MATERIAL_TYPE, OracleType.VarChar);
            param[index++].Value = materialInfo.MatTypeInfo.MaterialTypeId == null ? DBNull.Value : (object)(materialInfo.MatTypeInfo.MaterialTypeId);
            param[index] = new OracleParameter(PARAM_SHAPE, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialShape == null ? DBNull.Value : (object)(materialInfo.MaterialShape);
            param[index] = new OracleParameter(PARAM_MATERIAL_NOTE, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialNote == null ? DBNull.Value : (object)(materialInfo.MaterialNote);
            param[index] = new OracleParameter(PARAM_MATERIAL_DESC, OracleType.VarChar);
            param[index++].Value = materialInfo.MaterialDesc == null ? DBNull.Value : (object)(materialInfo.MaterialDesc);
            param[index] = new OracleParameter(PARAM_WIRE_SPEC_WGT, OracleType.Number);
            param[index++].Value = materialInfo.WireSpecWgt == null ? DBNull.Value : (object)(materialInfo.WireSpecWgt);
            param[index] = new OracleParameter(PARAM_BULK_SPEC_WGT, OracleType.Number);
            param[index++].Value = materialInfo.BulkSpecWgt == null ? DBNull.Value : (object)(materialInfo.BulkSpecWgt);
            param[index] = new OracleParameter(PARAM_CHILL_FACTOR, OracleType.Number);
            param[index++].Value = materialInfo.ChillFactor == null ? DBNull.Value : (object)(materialInfo.ChillFactor);
            param[index] = new OracleParameter(PARAM_FE_CONTENTS, OracleType.Number);
            param[index++].Value = materialInfo.FeContents == null ? DBNull.Value : (object)(materialInfo.FeContents);
            param[index] = new OracleParameter(PARAM_YIELD, OracleType.Number);
            param[index].Value = materialInfo.Yield == null ? DBNull.Value : (object)(materialInfo.Yield);
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_MATERIAL_INFO, param);
        }

        /// <summary>
        /// 根据物料ID更新物料温降信息
        /// </summary>
        /// <param name="materialId">物料ID</param>
        /// <param name="chillFactor">温降值</param>
        public void UpdateMaterialInfo(int materialId, double chillFactor)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_MATERIAL_ID, materialId);
            param[1] = new OracleParameter(PARAM_CHILL_FACTOR, chillFactor);
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_MATERIAL_CHILL_FACTOR, param);
        }
        #endregion
    }
}
