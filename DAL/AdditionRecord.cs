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
    public class AdditionRecord : IAdditionRecord
    {
        #region SQL AND PARAM

        private const string SQL_SELECT_ALL_ADDITION_MATERIAL_RECORDS = @" SELECT T.HEAT_ID,
                                                                           T.TREATMENT_COUNT,
                                                                           T.STEEL_GRADE_ID,
                                                                           T.CAR,
                                                                           T.TREATMENT_STATION,
                                                                           T.STATION_ID,
                                                                           T.ADDITION_TIME,
                                                                           T.SILO_ID,
                                                                           T.ADDITION_MATERIAL_ID,
                                                                           T.MATERIAL_L3_ID,
                                                                           T.MATERIAL_NAME,
                                                                           T.MATERIAL_TYPE_NAME,
                                                                           T.NOTE,
                                                                           T.ADDITION_AMOUNT
                                                                      FROM V_ADDITION_RECORD T
                                                                      ORDER BY T.ADDITION_TIME";
        private const string SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_HEAT_ID = @" SELECT T.HEAT_ID,
                                                                                       T.TREATMENT_COUNT,
                                                                                       T.STEEL_GRADE_ID,
                                                                                       T.CAR,
                                                                                       T.TREATMENT_STATION,
                                                                                       T.STATION_ID,
                                                                                       T.ADDITION_TIME,
                                                                                       T.SILO_ID,
                                                                                       T.ADDITION_MATERIAL_ID,
                                                                                       T.MATERIAL_L3_ID,
                                                                                       T.MATERIAL_NAME,
                                                                                       T.MATERIAL_TYPE_NAME,
                                                                                       T.NOTE,
                                                                                       T.ADDITION_AMOUNT
                                                                                  FROM V_ADDITION_RECORD T
                                                                                  WHERE T.HEAT_ID = :HEAT_ID
                                                                                  ORDER BY T.ADDITION_TIME";
        private const string SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_HEAT_ID_AND_TREAT_CNT = @" SELECT T.HEAT_ID,
                                                                                               T.TREATMENT_COUNT,
                                                                                               T.STEEL_GRADE_ID,
                                                                                               T.CAR,
                                                                                               T.TREATMENT_STATION,
                                                                                               T.STATION_ID,
                                                                                               T.ADDITION_TIME,
                                                                                               T.SILO_ID,
                                                                                               T.ADDITION_MATERIAL_ID,
                                                                                               T.MATERIAL_L3_ID,
                                                                                               T.MATERIAL_NAME,
                                                                                               T.MATERIAL_TYPE_NAME,
                                                                                               T.NOTE,
                                                                                               T.ADDITION_AMOUNT
                                                                                          FROM V_ADDITION_RECORD T
                                                                                          WHERE T.HEAT_ID = :HEAT_ID AND T.TREATMENT_COUNT = :TREATMENT_COUNT
                                                                                          ORDER BY T.ADDITION_TIME";
        private const string SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_DATE = @"SELECT T.HEAT_ID,
                                                                                   T.TREATMENT_COUNT,
                                                                                   T.STEEL_GRADE_ID,
                                                                                   T.CAR,
                                                                                   T.CLASS_NAME,
                                                                                   T.OPERATOR_NAME,
                                                                                   T.TREATMENT_STATION,
                                                                                   T.STATION_ID,
                                                                                   T.ADDITION_TIME,
                                                                                   T.SILO_ID,
                                                                                   T.ADDITION_MATERIAL_ID,
                                                                                   T.MATERIAL_L3_ID,
                                                                                   T.MATERIAL_NAME,
                                                                                   T.MATERIAL_TYPE_NAME,
                                                                                   T.NOTE,
                                                                                   T.ADDITION_AMOUNT
                                                                              FROM V_ADDITION_RECORD T
                                                                             WHERE T.ADDITION_TIME > :START_DATE
                                                                               AND T.ADDITION_TIME < :END_DATE
                                                                             ORDER BY T.ADDITION_TIME";

        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private const string PARAM_START_DATE = ":START_DATE";
        private const string PARAM_END_DATE = ":END_DATE";

        #endregion

        #region Dal Methods

        /// <summary>
        /// 取出所有的加料报告
        /// </summary>
        /// <returns>加料记录</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords()
        {
            IList<AdditionRecordInfo> additionMaterialRecords = new List<AdditionRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_HEAT_ID, null))
            {
                while (odr.Read())
                {
                    string heatId = odr["HEAT_ID"].ToString();
                    int treatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    DateTime? additionTime = odr["ADDITION_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ADDITION_TIME"]));
                    int? siloId = odr["SILO_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["SILO_ID"]));
                    decimal? additionMaterialId = odr["ADDITION_MATERIAL_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["ADDITION_MATERIAL_ID"]));
                    string materialL3Id = odr["MATERIAL_L3_ID"].ToString();
                    string additionMaterialName = odr["MATERIAL_NAME"].ToString();
                    string materialType = odr["MATERIAL_TYPE_NAME"].ToString();
                    double? additionAmount = odr["ADDITION_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ADDITION_AMOUNT"]));
                    string note = odr["NOTE"].ToString();
                    AdditionRecordInfo additionMaterialRecord = new AdditionRecordInfo(heatId, treatmentCount,steelGradeId, car, treatmentStation, stationId,
                                additionTime, siloId, additionMaterialId, materialL3Id, additionMaterialName, materialType, additionAmount, note);
                    additionMaterialRecords.Add(additionMaterialRecord);
                }
            }
            return additionMaterialRecords;
        }

        /// <summary>
        /// 根据炉次号取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>加料记录</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId)
        {
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            IList<AdditionRecordInfo> additionMaterialRecords = new List<AdditionRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    int treatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    DateTime? additionTime = odr["ADDITION_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ADDITION_TIME"]));
                    int? siloId = odr["SILO_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["SILO_ID"]));
                    decimal? additionMaterialId = odr["ADDITION_MATERIAL_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["ADDITION_MATERIAL_ID"]));
                    string materialL3Id = odr["MATERIAL_L3_ID"].ToString();
                    string additionMaterialName = odr["MATERIAL_NAME"].ToString();
                    string materialType = odr["MATERIAL_TYPE_NAME"].ToString();
                    double? additionAmount = odr["ADDITION_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ADDITION_AMOUNT"]));
                    string note = odr["NOTE"].ToString();
                    AdditionRecordInfo additionMaterialRecord = new AdditionRecordInfo(heatId, treatmentCount,steelGradeId, car, treatmentStation, stationId,
                                additionTime, siloId, additionMaterialId, materialL3Id, additionMaterialName, materialType, additionAmount, note);
                    additionMaterialRecords.Add(additionMaterialRecord);
                }
            }
            return additionMaterialRecords;
        }

        /// <summary>
        /// 根据炉次号取得加料报告
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns></returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(string heatId, int treatmentCount)
        {

            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            IList<AdditionRecordInfo> additionMaterialRecords = new List<AdditionRecordInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_HEAT_ID_AND_TREAT_CNT, param))
            {
                while (odr.Read())
                {
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    int car = Convert.ToInt32(odr["CAR"]);
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    DateTime? additionTime = odr["ADDITION_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ADDITION_TIME"]));
                    int? siloId = odr["SILO_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["SILO_ID"]));
                    decimal? additionMaterialId = odr["ADDITION_MATERIAL_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["ADDITION_MATERIAL_ID"]));
                    string materialL3Id = odr["MATERIAL_L3_ID"].ToString();
                    string additionMaterialName = odr["MATERIAL_NAME"].ToString();
                    string materialType = odr["MATERIAL_TYPE_NAME"].ToString();
                    double? additionAmount = odr["ADDITION_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ADDITION_AMOUNT"]));
                    string note = odr["NOTE"].ToString();
                    AdditionRecordInfo additionMaterialRecord = new AdditionRecordInfo(heatId, treatmentCount,steelGradeId, car, treatmentStation, stationId,
                                additionTime, siloId, additionMaterialId, materialL3Id, additionMaterialName, materialType, additionAmount, note);
                    additionMaterialRecords.Add(additionMaterialRecord);
                }
            }
            return additionMaterialRecords;
        }

        /// <summary>
        /// 根据日期查询加料信息
        /// </summary>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>加料信息</returns>
        public IList<AdditionRecordInfo> GetAdditionMaterialRecords(DateTime startDate, DateTime endDate)
        {
            IList<AdditionRecordInfo> additionRecordList = new List<AdditionRecordInfo>();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startDate;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endDate;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ADDITION_MATERIAL_RECORDS_BY_DATE, param))
            {
                while (odr.Read())
                {
                    string heatId = odr["HEAT_ID"].ToString();
                    int treatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    int car = Convert.ToInt32(odr["CAR"]);
                    string className = odr["CLASS_NAME"].ToString();
                    string operatorName = odr["OPERATOR_NAME"].ToString();
                    string treatmentStation = odr["TREATMENT_STATION"].ToString();
                    int? stationId = odr["STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["STATION_ID"]));
                    DateTime? additionTime = odr["ADDITION_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ADDITION_TIME"]));
                    int? siloId = odr["SILO_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["SILO_ID"]));
                    decimal? additionMaterialId = odr["ADDITION_MATERIAL_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["ADDITION_MATERIAL_ID"]));
                    string materialL3Id = odr["MATERIAL_L3_ID"].ToString();
                    string additionMaterialName = odr["MATERIAL_NAME"].ToString();
                    string materialType = odr["MATERIAL_TYPE_NAME"].ToString();
                    double? additionAmount = odr["ADDITION_AMOUNT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ADDITION_AMOUNT"]));
                    string note = odr["NOTE"].ToString();
                    AdditionRecordInfo additionMaterialRecord = new AdditionRecordInfo(heatId, treatmentCount,steelGradeId, car,className,operatorName, treatmentStation, stationId,
                                additionTime, siloId, additionMaterialId, materialL3Id, additionMaterialName, materialType, additionAmount, note);
                    additionRecordList.Add(additionMaterialRecord);
                }
            }
            return additionRecordList;
        }


        /// <summary>
        /// 添加加料信息
        /// </summary>
        /// <param name="additionRecord">加料记录</param>
        public void InsertAdditionRecord(AdditionRecordInfo additionRecord)
        {
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("HEAT_ID", OracleType.VarChar);
            param[0].Value = additionRecord.HeatId;
            param[1] = new OracleParameter("TREATMENT_COUNT", OracleType.Number);
            param[1].Value = additionRecord.TreatmentCount;
            param[2] = new OracleParameter("SILO_ID", OracleType.Number);
            param[2].Value = additionRecord.SiloId == null ? (object)DBNull.Value : (object)additionRecord.SiloId;
            param[3] = new OracleParameter("ADDITION_MATERIAL_ID", OracleType.Number);
            param[3].Value = additionRecord.AdditionMaterialId;
            param[4] = new OracleParameter("ADDITION_TIME", OracleType.DateTime);
            param[4].Value = additionRecord.AdditionTime;
            param[5] = new OracleParameter("ADDITION_AMOUNT", OracleType.Number);
            param[5].Value = additionRecord.AdditionAmount;
            param[6] = new OracleParameter("THEORY_TEMP_DATA",OracleType.Number);
            param[6].Value = DBNull.Value;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.StoredProcedure, "LFDBUSER.LF_DAL.SP_INS_ADDITION_RECORD", param);
        }

        #endregion
    }
}
