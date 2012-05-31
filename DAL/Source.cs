using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class Source:ISource
    {
        #region SQL && PARAM
        private const string SQL_GET_SOURCE_INFO = @"SELECT T1.SOURCE_TYPE, T1.SOURCE_ID, T1.MATERIAL_ID, T2.MATERIAL_NAME
                                                      FROM TB_SOURCE_INFO T1
                                                      LEFT JOIN TB_MATERIAL_INFO T2
                                                        ON T1.MATERIAL_ID = T2.MATERIAL_ID
                                                     ORDER BY SOURCE_TYPE, SOURCE_ID";
        private const string SQL_UPD_SOURCE_INFO_BY_SOURCE = @"UPDATE TB_SOURCE_INFO T
                                                               SET T.MATERIAL_ID =
                                                                   (SELECT MATERIAL_ID
                                                                      FROM TB_MATERIAL_INFO
                                                                     WHERE MATERIAL_NAME = :MATERIAL_NAME)
                                                             WHERE T.SOURCE_ID = :SOURCE_ID
                                                               AND T.SOURCE_TYPE = :SOURCE_TYPE";
        
        private const string SQL_UPD_OPC_SILO_INFO = "LF_BLL.SP_UPD_OPC_SILO_INFO";
        private const string SQL_UPD_SILO_OPC_GUIDE_VALUE = @"UPDATE TB_OPC_ITEMS_INFO T
                                                                   SET T.ITEM_DATA = :ITEM_DATA
                                                                 WHERE T.ITEM_DESCRIPTION = :ITEM_DESCRIPTION";
        private const string PARAM_MATERIAL_NAME = ":MATERIAL_NAME";
        private const string PARAM_SOURCE_TYPE = ":SOURCE_TYPE";
        private const string PARAM_SOURCE_ID = ":SOURCE_ID";
        private const string PARAM_ITEM_DESCRIPTION = ":ITEM_DESCRIPTION";
        private const string PARAM_ITEM_DATA = ":ITEM_DATA";

        #endregion

        #region Methods
        /// <summary>
        /// 取得所有料仓信息（TB_SOURCE_INFO）
        /// </summary>
        /// <returns>料仓信息</returns>
        public IList<SourceInfo> GetSourceInfo()
        {
            IList<SourceInfo> siloInfos=new List<SourceInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_GET_SOURCE_INFO,null))
            {
                while (odr.Read())
                {
                    string sourceType = odr["SOURCE_TYPE"].ToString();
                    int sourceId = Convert.ToInt32(odr["SOURCE_ID"]);
                    int materialId = Convert.ToInt32(odr["MATERIAL_ID"]);
                    string materialName = odr["MATERIAL_NAME"].ToString();
                    SourceInfo siloInfo = new SourceInfo(sourceType,sourceId, materialId, materialName);
                    siloInfos.Add(siloInfo);
                }
            }
            return siloInfos;
        }

        /// <summary>
        /// 通过物料来源类型和编号更新信息
        /// </summary>
        /// <param name="source">物料来源信息</param>
        public void UpdataSourceInfo(SourceInfo source)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_SOURCE_TYPE, OracleType.VarChar);
            param[0].Value = source.SourceEnType;
            param[1] = new OracleParameter(PARAM_MATERIAL_NAME, OracleType.VarChar);
            param[1].Value = source.MaterialName;
            param[2] = new OracleParameter(PARAM_SOURCE_ID, OracleType.Number);
            param[2].Value = source.SourceId;
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPD_SOURCE_INFO_BY_SOURCE, param);
        }

        /// <summary>
        /// 把LFDBUSER的TB_SILO_INFO的每个料仓的信息更新到LFOPCUSER中TB_OPC_ITEM_INFO
        /// </summary>
        public void UpdataOPCSiloInfo()
        {
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.StoredProcedure, SQL_UPD_OPC_SILO_INFO, null);
        }

        /// <summary>
        /// 更新各料仓合金计算的值
        /// </summary>
        public void UpdateOpcSiloCalculateValue(double[] calCulateValue, int carId)
        {
            for (int i = 0; i < 20; i++)
            {
                OracleParameter[] param = new OracleParameter[2];
                param[0] = new OracleParameter(PARAM_ITEM_DESCRIPTION, OracleType.VarChar);
                param[0].Value = "Car"+carId+"SiloGuideWeight"+(i+1).ToString();
                param[1] = new OracleParameter(PARAM_ITEM_DATA, OracleType.VarChar);
                param[1].Value = calCulateValue[i].ToString();
                OracleHelper.ExecuteNonQuery(OracleHelper.LFOPCUSERConnectionString, CommandType.Text, SQL_UPD_SILO_OPC_GUIDE_VALUE, param);
            }
            for (int i = 0; i < 2; i++)
            {
                OracleParameter[] param = new OracleParameter[2];
                param[0] = new OracleParameter(PARAM_ITEM_DESCRIPTION, OracleType.VarChar);
                param[0].Value = "Car" + carId + "SiloGuideStatus" + (i + 1).ToString();
                param[1] = new OracleParameter(PARAM_ITEM_DATA, OracleType.VarChar);
                param[1].Value = "1";
                OracleHelper.ExecuteNonQuery(OracleHelper.LFOPCUSERConnectionString, CommandType.Text, SQL_UPD_SILO_OPC_GUIDE_VALUE, param);
            } 
        }

        #endregion
    }
}
