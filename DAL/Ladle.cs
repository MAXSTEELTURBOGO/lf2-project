using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class Ladle : ILadle
    {
        #region SQL AND PARAM

        private const string SQL_SELECT_LADLE_INFO_BY_HEAT_ID = @"SELECT MSG_ID,
                                                                   MSG_TIME_STAMP,
                                                                   HEAT_ID,
                                                                   LADLE_ID,
                                                                   LADLE_MATERIAL,
                                                                   LADLE_EMP_WGT,
                                                                   LADLE_STATE,
                                                                   LADLE_STATUS,
                                                                   LADLE_AGE
                                                              FROM TB_L3_LADLE_MSG 
                                                              WHERE HEAT_ID=:HEAT_ID";

        private const string PARAM_HEAT_ID = @":HEAT_ID";
        #endregion


        #region Methods

        /// <summary>
        /// 根据炉次号获取钢包信息
        /// </summary>
        /// <param name="heatID">炉次号</param>
        /// <returns>钢包信息</returns>
        public LadleInfo GetLadleInfo(string heatId)
        {
            LadleInfo ladle = null;

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LADLE_INFO_BY_HEAT_ID, param))
            {
                if (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    string ladleId = odr["LADLE_ID"].ToString();
                    string ladleMaterial = odr["LADLE_MATERIAL"] == DBNull.Value ? null : odr["LADLE_MATERIAL"].ToString();
                    double? ladleEmptyWeight = odr["LADLE_EMP_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LADLE_EMP_WGT"]));
                    string ladleState = odr["LADLE_STATE"] == DBNull.Value ? null : odr["LADLE_STATE"].ToString();
                    string ladleStatus = odr["LADLE_STATUS"] == DBNull.Value ? null : odr["LADLE_STATUS"].ToString();
                    int? ladleAge = odr["LADLE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["LADLE_AGE"]));
                    ladle = new LadleInfo(msgId, msgTimeStamp, heatId, ladleId, ladleMaterial, ladleEmptyWeight, ladleState, ladleStatus, ladleAge);
                }
            }
            return ladle;
        }


        /// <summary>
        /// 根据炉次信息获取钢包信息
        /// </summary>
        /// <param name="heat">炉次信息</param>
        /// <returns>钢包信息</returns>
        public LadleInfo GetLadleInfo(LFHeatInfo heat)
        {
            LadleInfo ladle = null;

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heat.HeatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LADLE_INFO_BY_HEAT_ID, param))
            {
                if (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    string ladleId = odr["LADLE_ID"].ToString();
                    string ladleMaterial = odr["LADLE_MATERIAL"] == DBNull.Value ? null : odr["LADLE_MATERIAL"].ToString();
                    double? ladleEmptyWeight = odr["LADLE_EMP_WGT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LADLE_EMP_WGT"]));
                    string ladleState = odr["LADLE_STATE"] == DBNull.Value ? null : odr["LADLE_STATE"].ToString();
                    string ladleStatus = odr["LADLE_STATUS"] == DBNull.Value ? null : odr["LADLE_STATUS"].ToString();
                    int? ladleAge = odr["LADLE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["LADLE_AGE"]));
                    ladle = new LadleInfo(msgId, msgTimeStamp, heat.HeatId, ladleId, ladleMaterial, ladleEmptyWeight, ladleState, ladleStatus, ladleAge);
                }
            }
            return ladle;
        }

        #endregion

    }
}
