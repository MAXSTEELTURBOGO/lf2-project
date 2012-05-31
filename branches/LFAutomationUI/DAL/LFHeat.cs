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
    public class LFHeat : ILFHeat
    {
        #region Internal members

        private const string SQL_SELECT_DISTINCT_HEAT_ID = "SELECT DISTINCT MSG_TIME_STAMP,HEAT_ID,TREATMENT_COUNT FROM TB_LF_HEAT_INFO ORDER BY MSG_TIME_STAMP DESC";
        private const string SQL_SELECT_LF_HEAT_INFO = @"SELECT *
                                                          FROM (SELECT T1.MSG_TIME_STAMP,
                                                                       T1.PLAN_ID,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T2.CAR,
                                                                       T1.STEEL_GRADE_ID,
                                                                       T1.LF_TMP_TGT,
                                                                       V2.ARRIVAL_TIME,
                                                                       V2.DEPART_TIME,
                                                                       V1.CURR_HEAT_STATUS,
                                                                       V1.CURR_DETAIL_STATUS_ID,
                                                                       V1.CURR_DETAIL_STATUS_NAME,
                                                                       T1.ROUTE_ID,
                                                                       LF_BLL.FUN_TRANSLATE_ROUTE(T1.ROUTE_ID) AS ROUTE_DESCR,
                                                                       T1.PRE_START_DTIME,
                                                                       DECODE(T1.TREATMENT_COUNT,1,T3.LADLE_ID,T1.LADLE_ID) LADLE_ID,
                                                                       DECODE(T1.TREATMENT_COUNT,1,T3.LADLE_AGE,0) LADLE_AGE,
                                                                       T1.SELECT_FLAG,
                                                                       T1.VISIBLE
                                                                  FROM TB_L3_LF_PLAN T1
                                                                  LEFT JOIN TB_LF_HEAT_INFO T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_CURR_STATUS_INFO V1
                                                                    ON T1.HEAT_ID = V1.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = V1.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_ARRIVAL_DEPART_TIME V2
                                                                    ON T1.HEAT_ID = V2.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = V2.TREATMENT_COUNT
                                                                  LEFT JOIN TB_L3_LADLE_MSG T3
                                                                    ON T1.HEAT_ID = T3.HEAT_ID
                                                                 WHERE T1.VISIBLE = 1
                                                                 ORDER BY T1.MSG_TIME_STAMP DESC)
                                                         WHERE ROWNUM <= 200";

        private const string SQL_SELECT_ALL_LF_PLAN_INFO = @"SELECT *
                                                                  FROM (SELECT T1.MSG_TIME_STAMP,
                                                                               T1.PLAN_ID,
                                                                               T1.HEAT_ID,
                                                                               T1.TREATMENT_COUNT,
                                                                               T2.CAR,
                                                                               T1.STEEL_GRADE_ID,
                                                                               T1.LF_TMP_TGT,
                                                                               V2.ARRIVAL_TIME,
                                                                               V2.DEPART_TIME,
                                                                               V1.CURR_HEAT_STATUS,
                                                                               V1.CURR_DETAIL_STATUS_ID,
                                                                               V1.CURR_DETAIL_STATUS_NAME,
                                                                               T1.ROUTE_ID,
                                                                               LF_BLL.FUN_TRANSLATE_ROUTE(T1.ROUTE_ID) AS ROUTE_DESCR,
                                                                               T1.PRE_START_DTIME,
                                                                               DECODE(T1.TREATMENT_COUNT, 1, T3.LADLE_ID, T1.LADLE_ID) LADLE_ID,
                                                                               DECODE(T1.TREATMENT_COUNT, 1, T3.LADLE_AGE, 0) LADLE_AGE,
                                                                               T1.SELECT_FLAG,
                                                                               T1.VISIBLE
                                                                          FROM TB_L3_LF_PLAN T1
                                                                          LEFT JOIN TB_LF_HEAT_INFO T2
                                                                            ON T1.HEAT_ID = T2.HEAT_ID
                                                                           AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                          LEFT JOIN V_HEAT_CURR_STATUS_INFO V1
                                                                            ON T1.HEAT_ID = V1.HEAT_ID
                                                                           AND T1.TREATMENT_COUNT = V1.TREATMENT_COUNT
                                                                          LEFT JOIN V_HEAT_ARRIVAL_DEPART_TIME V2
                                                                            ON T1.HEAT_ID = V2.HEAT_ID
                                                                           AND T1.TREATMENT_COUNT = V2.TREATMENT_COUNT
                                                                          LEFT JOIN TB_L3_LADLE_MSG T3
                                                                            ON T1.HEAT_ID = T3.HEAT_ID
                                                                            WHERE T1.MSG_TIME_STAMP>SYSDATE-60)";

        private const string SQL_SELECT_LF_HEAT_INFO_BY_HEAT_ID = @"SELECT T1.MSG_ID,
                                                                           T1.MSG_TIME_STAMP,
                                                                           T1.PLAN_ID,
                                                                           T1.HEAT_ID,
                                                                           T1.TREATMENT_COUNT,
                                                                           T1.STEEL_GRADE_ID,
                                                                           T1.LADLE_ID,
                                                                           T2.CAR,
                                                                           T2.CLASS_NAME,
                                                                           T2.OPERATOR_NAME,
                                                                           T2.BUB_GAS_CONSUMPTION,
                                                                           T2.BUB_TOTAL_DURATION,
                                                                           T2.HEATING_DURATION,
                                                                           T2.ELECTRIC_CONSUMPTION,
                                                                           T2.FED_SPD,
                                                                           V3.ARRIVAL_TIME,
                                                                           V3.DEPART_TIME,
                                                                           V4.ARRIVAL_TEMP_TIME,
                                                                           V4.ARRIVAL_TEMP_DATA,
                                                                           V4.DEPART_TEMP_TIME,
                                                                           V4.DEPART_TEMP_DATA,
                                                                           V5.MSG_TIME_STAMP       AS LAST_HEATING_TEMP_TIME,
                                                                           V5.TEMPERATURE_DATA     AS LAST_HEATING_TEMP_DATA,
                                                                           V6.SOFT_STIR_DURATION,
                                                                           V6.SOFT_STIR_ARGON_CONSUMPTION
                                                                      FROM TB_L3_LF_PLAN T1
                                                                      FULL JOIN TB_LF_HEAT_INFO T2
                                                                        ON T1.HEAT_ID = T2.HEAT_ID
                                                                       AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                      LEFT JOIN V_HEAT_ARRIVAL_DEPART_TIME V3
                                                                        ON V3.HEAT_ID = T1.HEAT_ID
                                                                       AND V3.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                      LEFT JOIN V_HEAT_ARRIVAL_DEPART_TEMP V4
                                                                        ON V4.HEAT_ID = T1.HEAT_ID
                                                                       AND V4.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                      LEFT JOIN V_HEAT_TEMP_AFT_LAST_HEATING V5
                                                                        ON V5.HEAT_ID = T1.HEAT_ID
                                                                       AND V5.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                      LEFT JOIN V_HEAT_INFO_SOFT_STIR_INFO V6
                                                                        ON T1.HEAT_ID = V6.HEAT_ID
                                                                       AND T1.TREATMENT_COUNT = V6.TREATMENT_COUNT
                                                                     WHERE T1.HEAT_ID = :HEAT_ID";

        private const string SQL_SELECT_LF_HEAT_INFO_BY_HEAT_ID_AND_TREATMENT_COUNT = @"SELECT T9.PLAN_ID,
                                                                                               DECODE(T9.MSG_TIME_STAMP, NULL, T6.MSG_TIME_STAMP, T9.MSG_TIME_STAMP) AS MSG_TIME_STAMP,
                                                                                               DECODE(T9.HEAT_ID, NULL, T6.HEAT_ID, T9.HEAT_ID) AS HEAT_ID,
                                                                                               DECODE(T9.TREATMENT_COUNT,
                                                                                                      NULL,
                                                                                                      T6.TREATMENT_COUNT,
                                                                                                      T9.TREATMENT_COUNT) AS TREATMENT_COUNT,
                                                                                               T6.CAR,
                                                                                               
                                                                                               T6.CLASS_NAME    AS CLASS_NAME,
                                                                                               T6.OPERATOR_NAME AS OPERATOR_NAME,
                                                                                               
                                                                                               DECODE(T6.FACTORY_CODE, NULL, T9.FACTORY_CODE, T6.FACTORY_CODE) AS FACTORY_CODE,
                                                                                               
                                                                                               T9.PLAN_STATION_ID AS PLAN_STATION_ID,
                                                                                               DECODE(T6.CURR_STATION_ID,
                                                                                                      NULL,
                                                                                                      T9.CURR_STATION_ID,
                                                                                                      T6.CURR_STATION_ID) AS CURRENT_STATION_ID,
                                                                                               
                                                                                               T9.STEEL_GRADE_ID,
                                                                                               T9.AIM_TEMPERATURE,
                                                                                               T6.ARRIVAL_SLAG_WEIGHT,
                                                                                               T6.ARRIVAL_STEEL_WEIGHT,
                                                                                               T6.ARRIVAL_TIME AS ARRIVAL_TIME,
                                                                                               T6.DEPART_TIME AS DEPART_TIME,
                                                                                               NVL(T6.CURR_HEAT_STATUS, 'TO BE DONE') AS CURR_HEAT_STATUS,
                                                                                               NVL(T6.CURR_DETAIL_STATUS_ID, 0) AS CURR_DETAIL_STATUS_ID,
                                                                                               DECODE(NVL(T6.CURR_DETAIL_STATUS_ID, 0),
                                                                                                      0,
                                                                                                      T10.STATUS_NAME,
                                                                                                      DECODE(FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 10),
                                                                                                             0,
                                                                                                             T10.STATUS_NAME,
                                                                                                             DECODE(FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 100),
                                                                                                                    0,
                                                                                                                    T10.STATUS_NAME || '(第' ||
                                                                                                                    MOD(NVL(T6.CURR_DETAIL_STATUS_ID, 0), 10) || '次)',
                                                                                                                    T10.STATUS_NAME || '(第' ||
                                                                                                                    MOD(NVL(T6.CURR_DETAIL_STATUS_ID, 0), 100) || '次)'))) AS CURR_DETAIL_STATUS_NAME,
                                                                                               T9.ROUTE_ID AS ROUTE_ID,
                                                                                               T9.ROUTE_DESCR AS ROUTE_DESCR,
                                                                                               T9.PRE_START_DTIME,
                                                                                               T9.LF_TMP_TGT,
                                                                                               
                                                                                               T6.AR_CONSUMPTION,
                                                                                               T6.AR_DURATION,
                                                                                               T6.POWER_DURATION,
                                                                                               T6.POWER_CONSUMPTION,
                                                                                               V4.SOFT_STIR_ARGON_CONSUMPTION AS AR_CONSUMPTION_AFT_FEED,
                                                                                               V4.SOFT_STIR_DURATION AS AR_DURATION_AFT_FEED,
                                                                                               T6.FEED_SPEED,
                                                                                               T6.A_ELECTRODE_AGE,
                                                                                               T6.B_ELECTRODE_AGE,
                                                                                               T6.C_ELECTRODE_AGE,
                                                                                               T6.A_POLE_CIRL_USE_CNT,
                                                                                               T6.B_POLE_CIRL_USE_CNT,
                                                                                               T6.C_POLE_CIRL_USE_CNT,
                                                                                               T6.ROOF_ID,
                                                                                               T6.ROOF_AGE,
                                                                                               
                                                                                               T9.LADLE_ID,
                                                                                               T9.LADLE_MATERIAL,
                                                                                               T9.LADLE_EMPTY_WEIGHT,
                                                                                               T9.LADLE_STATE,
                                                                                               T9.LADLE_STATUS,
                                                                                               T9.LADLE_AGE,
                                                                                               DECODE(NVL(T6.CURR_HEAT_STATUS, 'TO BE DONE'),
                                                                                                      'DONE',
                                                                                                      0,
                                                                                                      DECODE(NVL(T6.CURR_HEAT_STATUS, 'TO BE DONE'),
                                                                                                             'ON GOING',
                                                                                                             1,
                                                                                                             T9.SELECT_FLAG)) AS SELECT_FLAG,
                                                                                               T9.VISIBLE

                                                                                          FROM (SELECT T7.MSG_ID,
                                                                                                       T7.MSG_TIME_STAMP,
                                                                                                       T7.PLAN_ID,
                                                                                                       T7.HEAT_ID,
                                                                                                       T7.TREATMENT_COUNT,
                                                                                                       
                                                                                                       LF_BLL.FUN_GET_BASIC_INFO('FACTORY CODE') AS FACTORY_CODE,
                                                                                                       
                                                                                                       T7.STATION_ID AS PLAN_STATION_ID,
                                                                                                       LF_BLL.FUN_GET_BASIC_INFO('STATION ID') AS CURR_STATION_ID,
                                                                                                       
                                                                                                       T7.STEEL_GRADE_ID,
                                                                                                       T7.LF_TMP_TGT AS AIM_TEMPERATURE,
                                                                                                       T7.ROUTE_ID AS ROUTE_ID,
                                                                                                       LF_BLL.FUN_TRANSLATE_ROUTE(T7.ROUTE_ID) AS ROUTE_DESCR,
                                                                                                       T7.PRE_START_DTIME,
                                                                                                       DECODE(T7.LADLE_ID, NULL, T8.LADLE_ID, T7.LADLE_ID) AS LADLE_ID,
                                                                                                       T8.LADLE_MATERIAL,
                                                                                                       T8.LADLE_EMP_WGT AS LADLE_EMPTY_WEIGHT,
                                                                                                       T8.LADLE_STATE,
                                                                                                       T8.LADLE_STATUS,
                                                                                                       T8.LADLE_AGE,
                                                                                                       T7.SELECT_FLAG,
                                                                                                       T7.VISIBLE,
                                                                                                       T7.LF_TMP_TGT
                                                                                                  FROM TB_L3_LF_PLAN T7
                                                                                                  LEFT JOIN TB_L3_LADLE_MSG T8
                                                                                                    ON T7.HEAT_ID = T8.HEAT_ID) T9
                                                                                          FULL JOIN (SELECT T1.MSG_TIME_STAMP,
                                                                                                            T1.HEAT_ID,
                                                                                                            T1.TREATMENT_COUNT,
                                                                                                            LF_BLL.FUN_GET_BASIC_INFO('STATION ID') AS CURR_STATION_ID,
                                                                                                            T1.CAR,
                                                                                                            T1.CLASS_NAME AS CLASS_NAME,
                                                                                                            T1.OPERATOR_NAME AS OPERATOR_NAME,
                                                                                                            
                                                                                                            LF_BLL.FUN_GET_BASIC_INFO('FACTORY CODE') AS FACTORY_CODE,
                                                                                                            LF_BLL.FUN_GET_BASIC_INFO('LF_INITIAL_SLAG_WEIGHT') AS ARRIVAL_SLAG_WEIGHT,
                                                                                                            
                                                                                                            V1.STEEL_WEIGHT            AS ARRIVAL_STEEL_WEIGHT,
                                                                                                            V3.ARRIVAL_TIME            AS ARRIVAL_TIME,
                                                                                                            V3.DEPART_TIME             AS DEPART_TIME,
                                                                                                            V2.CURR_HEAT_STATUS        AS CURR_HEAT_STATUS,
                                                                                                            V2.CURR_DETAIL_STATUS_ID   AS CURR_DETAIL_STATUS_ID,
                                                                                                            V2.CURR_DETAIL_STATUS_NAME AS CURR_DETAIL_STATUS_NAME,
                                                                                                            T1.BUB_GAS_CONSUMPTION     AS AR_CONSUMPTION,
                                                                                                            T1.BUB_TOTAL_DURATION      AS AR_DURATION,
                                                                                                            T1.HEATING_DURATION        AS POWER_DURATION,
                                                                                                            T1.ELECTRIC_CONSUMPTION    AS POWER_CONSUMPTION,
                                                                                                            T1.ATR_FED_AR_USE_QTY      AS AR_CONSUMPTION_AFT_FEED,
                                                                                                            T1.ATR_FED_AR_DUR_TIME     AS AR_DURATION_AFT_FEED,
                                                                                                            T1.FED_SPD                 AS FEED_SPEED,
                                                                                                            T1.A_ELECTRODE_AGE,
                                                                                                            T1.B_ELECTRODE_AGE,
                                                                                                            T1.C_ELECTRODE_AGE,
                                                                                                            T1.A_POLE_CIRL_USE_CNT,
                                                                                                            T1.B_POLE_CIRL_USE_CNT,
                                                                                                            T1.C_POLE_CIRL_USE_CNT,
                                                                                                            
                                                                                                            T1.CAP_NO      AS ROOF_ID,
                                                                                                            T1.CAP_USE_CNT AS ROOF_AGE
                                                                                                       FROM TB_LF_HEAT_INFO T1
                                                                                                       LEFT JOIN V_HEAT_STATUS_STEEL_WEIGHT V1
                                                                                                         ON T1.HEAT_ID = V1.HEAT_ID
                                                                                                        AND T1.TREATMENT_COUNT = V1.TREATMENT_COUNT
                                                                                                        AND V1.HEAT_STATUS = 1
                                                                                                       LEFT JOIN V_HEAT_CURR_STATUS_INFO V2
                                                                                                         ON T1.HEAT_ID = V2.HEAT_ID
                                                                                                        AND T1.TREATMENT_COUNT = V2.TREATMENT_COUNT
                                                                                                       LEFT JOIN V_HEAT_ARRIVAL_DEPART_TIME V3
                                                                                                         ON V3.HEAT_ID = T1.HEAT_ID
                                                                                                        AND V3.TREATMENT_COUNT = T1.TREATMENT_COUNT) T6
                                                                                            ON T6.HEAT_ID = T9.HEAT_ID
                                                                                           AND T6.TREATMENT_COUNT = T9.TREATMENT_COUNT
                                                                                          LEFT JOIN TB_STATUS_INFO T10
                                                                                            ON DECODE(NVL(T6.CURR_DETAIL_STATUS_ID, 0),
                                                                                                      0,
                                                                                                      NVL(T6.CURR_DETAIL_STATUS_ID, 0),
                                                                                                      DECODE(FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 10),
                                                                                                             0,
                                                                                                             NVL(T6.CURR_DETAIL_STATUS_ID, 0),
                                                                                                             DECODE(FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 100),
                                                                                                                    0,
                                                                                                                    FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 10),
                                                                                                                    FLOOR(NVL(T6.CURR_DETAIL_STATUS_ID, 0) / 100)))) =
                                                                                               T10.STATUS_ID
                                                                                           LEFT JOIN V_HEAT_INFO_SOFT_STIR_INFO V4
                                                                                           ON T9.HEAT_ID=V4.HEAT_ID
                                                                                          AND T9.TREATMENT_COUNT=V4.TREATMENT_COUNT
                                                                                  WHERE T9.HEAT_ID = :HEAT_ID AND T9.TREATMENT_COUNT = :TREATMENT_COUNT";

        private const string SQL_SELECT_LF_HEAT_INFO_BY_DATE = @"SELECT T1.MSG_ID,
                                                                       T1.MSG_TIME_STAMP,
                                                                       T1.PLAN_ID,
                                                                       T1.HEAT_ID,
                                                                       T1.TREATMENT_COUNT,
                                                                       T1.STEEL_GRADE_ID,
                                                                       T1.LADLE_ID,
                                                                       T2.CAR,
                                                                       T2.CLASS_NAME,
                                                                       T2.OPERATOR_NAME,
                                                                       T2.BUB_GAS_CONSUMPTION,
                                                                       T2.BUB_TOTAL_DURATION,
                                                                       T2.HEATING_DURATION,
                                                                       T2.ELECTRIC_CONSUMPTION,
                                                                       T2.FED_SPD,
                                                                       V3.ARRIVAL_TIME,
                                                                       V3.DEPART_TIME,
                                                                       V4.ARRIVAL_TEMP_TIME,
                                                                       V4.ARRIVAL_TEMP_DATA,
                                                                       V4.DEPART_TEMP_TIME,
                                                                       V4.DEPART_TEMP_DATA,
                                                                       V5.MSG_TIME_STAMP       AS LAST_HEATING_TEMP_TIME,
                                                                       V5.TEMPERATURE_DATA     AS LAST_HEATING_TEMP_DATA,
                                                                       V6.SOFT_STIR_DURATION,
                                                                       V6.SOFT_STIR_ARGON_CONSUMPTION
                                                                  FROM TB_L3_LF_PLAN T1
                                                                  FULL JOIN TB_LF_HEAT_INFO T2
                                                                    ON T1.HEAT_ID = T2.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = T2.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_ARRIVAL_DEPART_TIME V3
                                                                    ON V3.HEAT_ID = T1.HEAT_ID
                                                                   AND V3.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_ARRIVAL_DEPART_TEMP V4
                                                                    ON V4.HEAT_ID = T1.HEAT_ID
                                                                   AND V4.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_TEMP_AFT_LAST_HEATING V5
                                                                    ON V5.HEAT_ID = T1.HEAT_ID
                                                                   AND V5.TREATMENT_COUNT = T1.TREATMENT_COUNT
                                                                  LEFT JOIN V_HEAT_INFO_SOFT_STIR_INFO V6
                                                                    ON T1.HEAT_ID = V6.HEAT_ID
                                                                   AND T1.TREATMENT_COUNT = V6.TREATMENT_COUNT
                                                            WHERE T1.MSG_TIME_STAMP > :START_DATE AND T1.MSG_TIME_STAMP < :END_DATE
                                                               ORDER BY T1.MSG_ID";


        private const string SQL_UPDATE_LF_HEAT_SELECT_FLAG = @"UPDATE TB_L3_LF_PLAN T
                                                               SET T.SELECT_FLAG = :SELECT_FLAG
                                                             WHERE T.HEAT_ID = :HEAT_ID
                                                               AND T.TREATMENT_COUNT = :TREATMENT_COUNT";

        private const string SQL_UPDATE_LF_HEAT_VISIBLE = @"UPDATE TB_L3_LF_PLAN T
                                                               SET T.VISIBLE = :VISIBLE
                                                             WHERE T.HEAT_ID = :HEAT_ID
                                                               AND T.TREATMENT_COUNT = :TREATMENT_COUNT";

        private const string SQL_DELETE_LF_HEAT_INFO = @"DELETE FROM TB_LF_HEAT_INFO
                                                         WHERE HEAT_ID = :HEAT_ID
                                                           AND TREATMENT_COUNT = :TREATMENT_COUNT";

        private const string SQL_INSERT_LF_HEAT_INFO = @"INSERT INTO TB_LF_HEAT_INFO
                                                          (HEAT_ID, TREATMENT_COUNT, CAR, CLASS_NAME, OPERATOR_NAME)
                                                        VALUES
                                                          (:HEAT_ID, :TREATMENT_COUNT, :CAR, :CLASS_NAME, :OPERATOR_NAME)";

        private const string SQL_INSERT_LF_HEAT_PLAN = @"INSERT INTO TB_L3_LF_PLAN
                                                                      (MSG_TIME_STAMP,
                                                                       PLAN_ID,
                                                                       HEAT_ID,
                                                                       TREATMENT_COUNT,
                                                                       STATION_ID,
                                                                       STEEL_GRADE_ID,
                                                                       ROUTE_ID,
                                                                       SELECT_FLAG,
                                                                       LADLE_ID,
                                                                       PRE_START_DTIME,
                                                                       VISIBLE,
                                                                       LF_TMP_TGT)
                                                                    VALUES
                                                                      (SYSDATE,
                                                                       :PLAN_ID,
                                                                       :HEAT_ID,
                                                                       :TREATMENT_COUNT,
                                                                       :STATION_ID,
                                                                       :STEEL_GRADE_ID,
                                                                       :ROUTE_ID,
                                                                       0,
                                                                       :LADLE_ID,
                                                                       :PRE_START_DTIME,
                                                                       1,
                                                                       :LF_TMP_TGT)";

        private const string SQL_DELETE_LF_HEAT_PLAN = @"DELETE FROM TB_L3_LF_PLAN
                                                         WHERE HEAT_ID = :HEAT_ID
                                                           AND TREATMENT_COUNT = :TREATMENT_COUNT";

        private const string SQL_LOCK_CRITICAL_AREA = "LOCK TABLE V_LF_HEAT_DETAIL_INFO,V_OPC_HEAT_DETAIL_INFO IN EXCLUSIVE MODE";

        private const string PARAM_PLAN_ID = ":PLAN_ID";
        private const string PARAM_HEAT_ID = ":HEAT_ID";
        private const string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";
        private const string PARAM_NEW_HEAT_ID = ":NEW_HEAT_ID";
        private const string PARAM_NEW_TREATMENT_COUNT = ":NEW_TREATMENT_COUNT";
        private const string PARAM_OLD_HEAT_ID = ":OLD_HEAT_ID";
        private const string PARAM_OLD_TREATMENT_COUNT = ":OLD_TREATMENT_COUNT";
        private const string PARAM_CAR = ":CAR";
        private const string PARAM_CLASS_NAME = ":CLASS_NAME";
        private const string PARAM_OPERATOR_NAME = ":OPERATOR_NAME";
        private const string PARAM_SELECT_FLAG = ":SELECT_FLAG";
        private const string PARAM_VISIBLE = ":VISIBLE";
        private const string PARAM_STATUS_ID = ":STATUS_ID";
        private const string PARAM_STATION_ID = ":STATION_ID";
        private const string PARAM_STEEL_GRADE_ID = ":STEEL_GRADE_ID";
        private const string PARAM_ROUTE_ID = ":ROUTE_ID";
        private const string PARAM_LADLE_ID = ":LADLE_ID";
        private const string PARAM_PRE_START_DTIME = ":PRE_START_DTIME";
        private const string PARAM_LF_TEMP_TGT = ":LF_TMP_TGT";
        private const string PARAM_START_DATE = ":START_DATE";
        private const string PARAM_END_DATE = ":END_DATE";

        #endregion

        #region Methods

        /// <summary>
        /// 获取所有的炉次号  冶炼次数
        /// </summary>
        /// <returns>冶炼信息列表</returns>
        public IList<LFHeatInfo> GetHeatIdList()
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_DISTINCT_HEAT_ID, null))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfheatInfo = new LFHeatInfo();
                    lfheatInfo.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfheatInfo.HeatId = odr["HEAT_ID"].ToString();
                    lfheatInfo.TreatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    lfHeatList.Add(lfheatInfo);
                }
            }
            return lfHeatList;
        }

        public IList<LFHeatInfo> GetLFHeatInfo()
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LF_HEAT_INFO, null))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfHeat = new LFHeatInfo();

                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();
                    lfHeat.ArrivalTime = odr["ARRIVAL_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TIME"]));
                    lfHeat.DepartTime = odr["DEPART_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TIME"]));
                    lfHeat.CurrentHeatStatus = odr["CURR_HEAT_STATUS"] == DBNull.Value ? null : odr["CURR_HEAT_STATUS"].ToString();
                    lfHeat.CurrentDetailStatusId = Convert.ToInt16(odr["CURR_DETAIL_STATUS_ID"]);
                    lfHeat.CurrentDetailStatusName = odr["CURR_DETAIL_STATUS_NAME"].ToString();

                    lfHeat.SteelGrade.RouteId = odr["ROUTE_ID"] == DBNull.Value ? null : odr["ROUTE_ID"].ToString();
                    lfHeat.SteelGrade.RouteDesc = odr["ROUTE_DESCR"] == DBNull.Value ? null : odr["ROUTE_DESCR"].ToString();

                    lfHeat.PreStartTime = odr["PRE_START_DTIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["PRE_START_DTIME"]));

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();
                    lfHeat.Ladle.LadleAge = odr["LADLE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["LADLE_AGE"]));
                    lfHeat.SelectedFlag = Convert.ToBoolean(Convert.ToInt32(odr["SELECT_FLAG"]));
                    lfHeat.Visible = Convert.ToBoolean(Convert.ToInt16(odr["VISIBLE"]));

                    lfHeatList.Add(lfHeat);
                }
            }
            return lfHeatList;
        }

        /// <summary>
        /// 获取所有炉次信息
        /// </summary>
        /// <returns>炉次信息</returns>
        public IList<LFHeatInfo> GetLFHeatInfo(string heatId)
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LF_HEAT_INFO_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfHeat = new LFHeatInfo();

                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.OperatorUser.ClassId = odr["CLASS_NAME"].ToString();
                    lfHeat.OperatorUser.UserName = odr["OPERATOR_NAME"].ToString();
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();

                    lfHeat.ArConsumptin = odr["BUB_GAS_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["BUB_GAS_CONSUMPTION"]));
                    lfHeat.ArDuration = odr["BUB_TOTAL_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["BUB_TOTAL_DURATION"]));
                    lfHeat.PowerConsumption = odr["ELECTRIC_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["ELECTRIC_CONSUMPTION"]));
                    lfHeat.PowerDuration = odr["HEATING_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["HEATING_DURATION"]));
                    lfHeat.ArConsumptionAfterFeed = odr["SOFT_STIR_ARGON_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_ARGON_CONSUMPTION"]));
                    lfHeat.ArDurationAfterFeed = odr["SOFT_STIR_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_DURATION"]));

                    lfHeat.FeedSpeed = odr["FED_SPD"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["FED_SPD"]));

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();

                    lfHeat.ArrivalTime = odr["ARRIVAL_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TIME"]));
                    lfHeat.DepartTime = odr["DEPART_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TIME"]));

                    TempOxygenRecordInfo arrivalTempInfo = new TempOxygenRecordInfo();
                    arrivalTempInfo.MsgTimeStamp = odr["ARRIVAL_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TEMP_TIME"]));
                    arrivalTempInfo.TemperatureData = odr["ARRIVAL_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARRIVAL_TEMP_DATA"]));
                    TempOxygenRecordInfo departTempInfo = new TempOxygenRecordInfo();
                    departTempInfo.MsgTimeStamp = odr["DEPART_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TEMP_TIME"]));
                    departTempInfo.TemperatureData = odr["DEPART_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["DEPART_TEMP_DATA"]));
                    TempOxygenRecordInfo lastHeatTempInfo = new TempOxygenRecordInfo();
                    lastHeatTempInfo.MsgTimeStamp = odr["LAST_HEATING_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["LAST_HEATING_TEMP_TIME"]));
                    lastHeatTempInfo.TemperatureData = odr["LAST_HEATING_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LAST_HEATING_TEMP_DATA"]));
                    lfHeat.ArrivalTemperature = arrivalTempInfo;
                    lfHeat.DepartTemperature = departTempInfo;
                    lfHeat.LastHeatTemperature = lastHeatTempInfo;

                    lfHeat.ArDurationAfterFeed = odr["SOFT_STIR_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_DURATION"]));
                    lfHeat.ArConsumptionAfterFeed = odr["SOFT_STIR_ARGON_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_ARGON_CONSUMPTION"]));

                    lfHeatList.Add(lfHeat);
                }
            }
            return lfHeatList;
        }

        /// <summary>
        /// 根据炉次号和冶炼次数选取炉次信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>炉次信息</returns>
        public LFHeatInfo GetLFHeatInfo(string heatId, int treatmentCount)
        {
            LFHeatInfo lfHeat = new LFHeatInfo();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LF_HEAT_INFO_BY_HEAT_ID_AND_TREATMENT_COUNT, param))
            {
                if (odr.Read())
                {
                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.OperatorUser.ClassId = odr["CLASS_NAME"].ToString();
                    lfHeat.OperatorUser.UserName = odr["OPERATOR_NAME"].ToString();
                    lfHeat.FactoryCode = odr["FACTORY_CODE"].ToString();
                    lfHeat.PlanStationId = odr["PLAN_STATION_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["PLAN_STATION_ID"]));
                    lfHeat.CurrentStationId = Convert.ToInt16(odr["CURRENT_STATION_ID"]);
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();
                    lfHeat.ArrivalTime = odr["ARRIVAL_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TIME"]));
                    lfHeat.DepartTime = odr["DEPART_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TIME"]));
                    lfHeat.ArrivalSteelWeight = odr["ARRIVAL_STEEL_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARRIVAL_STEEL_WEIGHT"]));
                    lfHeat.ArrivalSlagWeight = odr["ARRIVAL_SLAG_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARRIVAL_SLAG_WEIGHT"]));
                    lfHeat.CurrentHeatStatus = odr["CURR_HEAT_STATUS"] == DBNull.Value ? null : odr["CURR_HEAT_STATUS"].ToString();
                    lfHeat.CurrentDetailStatusId = Convert.ToInt16(odr["CURR_DETAIL_STATUS_ID"]);
                    lfHeat.CurrentDetailStatusName = odr["CURR_DETAIL_STATUS_NAME"].ToString();

                    lfHeat.SteelGrade.RouteId = odr["ROUTE_ID"] == DBNull.Value ? null : odr["ROUTE_ID"].ToString();
                    lfHeat.SteelGrade.RouteDesc = odr["ROUTE_DESCR"] == DBNull.Value ? null : odr["ROUTE_DESCR"].ToString();

                    lfHeat.PreStartTime = odr["PRE_START_DTIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["PRE_START_DTIME"]));
                    lfHeat.ArConsumptin = odr["AR_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["AR_CONSUMPTION"]));
                    lfHeat.ArDuration = odr["AR_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["AR_DURATION"]));
                    lfHeat.PowerConsumption = odr["POWER_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_CONSUMPTION"]));
                    lfHeat.PowerDuration = odr["POWER_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["POWER_DURATION"]));
                    lfHeat.ArConsumptionAfterFeed = odr["AR_CONSUMPTION_AFT_FEED"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["AR_CONSUMPTION_AFT_FEED"]));
                    lfHeat.ArDurationAfterFeed = odr["AR_DURATION_AFT_FEED"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["AR_DURATION_AFT_FEED"]));

                    lfHeat.FeedSpeed = odr["FEED_SPEED"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["FEED_SPEED"]));

                    lfHeat.HeatEquipment.AElectrodeAge = odr["A_ELECTRODE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["A_ELECTRODE_AGE"]));
                    lfHeat.HeatEquipment.BElectrodeAge = odr["B_ELECTRODE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["B_ELECTRODE_AGE"]));
                    lfHeat.HeatEquipment.CElectrodeAge = odr["C_ELECTRODE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["C_ELECTRODE_AGE"]));
                    lfHeat.HeatEquipment.APoleCircleUseCount = odr["A_POLE_CIRL_USE_CNT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["A_POLE_CIRL_USE_CNT"]));
                    lfHeat.HeatEquipment.BPoleCircleUseCount = odr["B_POLE_CIRL_USE_CNT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["B_POLE_CIRL_USE_CNT"]));
                    lfHeat.HeatEquipment.CPoleCircleUseCount = odr["C_POLE_CIRL_USE_CNT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["C_POLE_CIRL_USE_CNT"]));
                    lfHeat.HeatEquipment.RoofId = odr["ROOF_ID"] == DBNull.Value ? null : odr["ROOF_ID"].ToString();
                    lfHeat.HeatEquipment.RoofAge = odr["ROOF_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["ROOF_AGE"]));

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();
                    lfHeat.Ladle.LadleMaterial = odr["LADLE_MATERIAL"] == DBNull.Value ? null : odr["LADLE_MATERIAL"].ToString();
                    lfHeat.Ladle.LadlEmptyWeight = odr["LADLE_EMPTY_WEIGHT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LADLE_EMPTY_WEIGHT"]));
                    lfHeat.Ladle.LadleState = odr["LADLE_STATE"] == DBNull.Value ? null : odr["LADLE_STATE"].ToString();
                    lfHeat.Ladle.LadleStatus = odr["LADLE_STATUS"] == DBNull.Value ? null : odr["LADLE_STATUS"].ToString();
                    lfHeat.Ladle.LadleAge = odr["LADLE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["LADLE_AGE"]));

                    lfHeat.SelectedFlag = Convert.ToBoolean(Convert.ToInt32(odr["SELECT_FLAG"]));
                    lfHeat.Visible = Convert.ToBoolean(Convert.ToInt16(odr["VISIBLE"]));

                }
                SteelGradeDetails steelGradeDAL = new SteelGradeDetails();
                lfHeat.SteelGrade = steelGradeDAL.GetSteelGradeInfoBySteelGradeId(lfHeat.SteelGrade.SteelGradeId);
                AdditionRecord additionRecordDal = new AdditionRecord();
                lfHeat.AdditionList = additionRecordDal.GetAdditionMaterialRecords(heatId, treatmentCount);
                QualityHorizontal qualityDAL = new QualityHorizontal();
                lfHeat.LfHeatQualityHorizontalList = qualityDAL.GetQualityDetailInfo(heatId, treatmentCount);

                TempOxygenRecord tempOxygenRecordDAL = new TempOxygenRecord();
                lfHeat.TempOxygenList = tempOxygenRecordDAL.GetTempOxygenRecord(heatId, treatmentCount);
                LFHeatStatus lfHeatStatus = new LFHeatStatus();
                lfHeat.LFHeatStatusList = lfHeatStatus.GetLFHeatStatus(heatId, treatmentCount);
                PowerOnRecord powerOnDAL = new PowerOnRecord();
                lfHeat.PowerOnList = powerOnDAL.GetPowerOnRecord(heatId, treatmentCount);
                RealTime realTimeBll = new RealTime();
                lfHeat.ReatTimeList = realTimeBll.GetRealTimeInfo(heatId, treatmentCount);
            }
            return lfHeat;
        }

        /// <summary>
        /// 根据日期获取炉次信息
        /// </summary>
        /// <param name="startDate">起始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>炉次信息</returns>
        public IList<LFHeatInfo> GetLFHeatInfo(DateTime startDate, DateTime endDate)
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_START_DATE, OracleType.DateTime);
            param[0].Value = startDate;
            param[1] = new OracleParameter(PARAM_END_DATE, OracleType.DateTime);
            param[1].Value = endDate;

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LF_HEAT_INFO_BY_DATE, param))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfHeat = new LFHeatInfo();

                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.OperatorUser.ClassId = odr["CLASS_NAME"].ToString();
                    lfHeat.OperatorUser.UserName = odr["OPERATOR_NAME"].ToString();
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();

                    lfHeat.ArConsumptin = odr["BUB_GAS_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["BUB_GAS_CONSUMPTION"]));
                    lfHeat.ArDuration = odr["BUB_TOTAL_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["BUB_TOTAL_DURATION"]));
                    lfHeat.PowerConsumption = odr["ELECTRIC_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["ELECTRIC_CONSUMPTION"]));
                    lfHeat.PowerDuration = odr["HEATING_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["HEATING_DURATION"]));
                    lfHeat.ArConsumptionAfterFeed = odr["SOFT_STIR_ARGON_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_ARGON_CONSUMPTION"]));
                    lfHeat.ArDurationAfterFeed = odr["SOFT_STIR_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_DURATION"]));

                    lfHeat.FeedSpeed = odr["FED_SPD"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["FED_SPD"]));

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();

                    lfHeat.ArrivalTime = odr["ARRIVAL_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TIME"]));
                    lfHeat.DepartTime = odr["DEPART_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TIME"]));

                    TempOxygenRecordInfo arrivalTempInfo = new TempOxygenRecordInfo();
                    arrivalTempInfo.MsgTimeStamp = odr["ARRIVAL_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TEMP_TIME"]));
                    arrivalTempInfo.TemperatureData = odr["ARRIVAL_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ARRIVAL_TEMP_DATA"]));
                    TempOxygenRecordInfo departTempInfo = new TempOxygenRecordInfo();
                    departTempInfo.MsgTimeStamp=odr["DEPART_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TEMP_TIME"]));
                    departTempInfo.TemperatureData = odr["DEPART_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["DEPART_TEMP_DATA"]));
                    TempOxygenRecordInfo lastHeatTempInfo = new TempOxygenRecordInfo();
                    lastHeatTempInfo.MsgTimeStamp = odr["LAST_HEATING_TEMP_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["LAST_HEATING_TEMP_TIME"]));
                    lastHeatTempInfo.TemperatureData = odr["LAST_HEATING_TEMP_DATA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["LAST_HEATING_TEMP_DATA"]));
                    lfHeat.ArDurationAfterFeed = odr["SOFT_STIR_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_DURATION"]));
                    lfHeat.ArConsumptionAfterFeed = odr["SOFT_STIR_ARGON_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["SOFT_STIR_ARGON_CONSUMPTION"]));
                    lfHeat.ArrivalTemperature = arrivalTempInfo;
                    lfHeat.DepartTemperature = departTempInfo;
                    lfHeat.LastHeatTemperature = lastHeatTempInfo;
                    lfHeatList.Add(lfHeat);
                }
            }
            return lfHeatList;
        }


        /// <summary>
        /// 使用事务获取所有炉次信息
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IList<LFHeatInfo> GetLFHeatInfo(OracleTransaction trans)
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(trans, CommandType.Text, SQL_SELECT_LF_HEAT_INFO, null))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfHeat = new LFHeatInfo();

                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();
                    lfHeat.ArrivalTime = odr["ARRIVAL_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["ARRIVAL_TIME"]));
                    lfHeat.DepartTime = odr["DEPART_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["DEPART_TIME"]));
                    lfHeat.CurrentHeatStatus = odr["CURR_HEAT_STATUS"] == DBNull.Value ? null : odr["CURR_HEAT_STATUS"].ToString();
                    lfHeat.CurrentDetailStatusId = Convert.ToInt16(odr["CURR_DETAIL_STATUS_ID"]);
                    lfHeat.CurrentDetailStatusName = odr["CURR_DETAIL_STATUS_NAME"].ToString();

                    lfHeat.SteelGrade.RouteId = odr["ROUTE_ID"] == DBNull.Value ? null : odr["ROUTE_ID"].ToString();
                    lfHeat.SteelGrade.RouteDesc = odr["ROUTE_DESCR"] == DBNull.Value ? null : odr["ROUTE_DESCR"].ToString();

                    lfHeat.PreStartTime = odr["PRE_START_DTIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["PRE_START_DTIME"]));

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();
                    lfHeat.Ladle.LadleAge = odr["LADLE_AGE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(odr["LADLE_AGE"]));
                    lfHeat.SelectedFlag = Convert.ToBoolean(Convert.ToInt32(odr["SELECT_FLAG"]));
                    lfHeat.Visible = Convert.ToBoolean(Convert.ToInt16(odr["VISIBLE"]));

                    lfHeatList.Add(lfHeat);
                }
            }
            return lfHeatList;
        }

        /// <summary>
        /// 获取所有的炉次信息
        /// </summary>
        /// <returns>所有炉次信息</returns>
        public IList<LFHeatInfo> GetAllLFHeatPlan()
        {
            IList<LFHeatInfo> lfHeatList = new List<LFHeatInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_LF_PLAN_INFO, null))
            {
                while (odr.Read())
                {
                    LFHeatInfo lfHeat = new LFHeatInfo();
                    lfHeat.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    lfHeat.PlanId = odr["PLAN_ID"] == DBNull.Value ? null : new Nullable<decimal>(Convert.ToDecimal(odr["PLAN_ID"]));
                    lfHeat.HeatId = odr["HEAT_ID"].ToString();
                    lfHeat.TreatmentCount = Convert.ToInt16(odr["TREATMENT_COUNT"]);
                    lfHeat.Car = (Car)(odr["CAR"] == DBNull.Value ? 0 : new Nullable<int>(Convert.ToInt16(odr["CAR"])));
                    lfHeat.SteelGrade.SteelGradeId = odr["STEEL_GRADE_ID"] == DBNull.Value ? null : odr["STEEL_GRADE_ID"].ToString();
                    lfHeat.CurrentHeatStatus = odr["CURR_HEAT_STATUS"] == DBNull.Value ? null : odr["CURR_HEAT_STATUS"].ToString();
                    lfHeat.CurrentDetailStatusId = Convert.ToInt16(odr["CURR_DETAIL_STATUS_ID"]);
                    lfHeat.CurrentDetailStatusName = odr["CURR_DETAIL_STATUS_NAME"].ToString();

                    lfHeat.SteelGrade.RouteId = odr["ROUTE_ID"] == DBNull.Value ? null : odr["ROUTE_ID"].ToString();
                    lfHeat.SteelGrade.RouteDesc = odr["ROUTE_DESCR"] == DBNull.Value ? null : odr["ROUTE_DESCR"].ToString();

                    lfHeat.Ladle.LadleId = odr["LADLE_ID"] == DBNull.Value ? null : odr["LADLE_ID"].ToString();
                    lfHeat.SelectedFlag = Convert.ToBoolean(Convert.ToInt32(odr["SELECT_FLAG"]));
                    lfHeat.Visible = Convert.ToBoolean(Convert.ToInt16(odr["VISIBLE"]));

                    lfHeatList.Add(lfHeat);
                }
            }
            return lfHeatList;
        }

        /// <summary>
        /// 将指定炉次的选择标志设置为指定值
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="selectFlag">要设置的selectFlag值</param>
        public void UpdateLFHeatSelectFlag(LFHeatInfo lfHeat, bool selectFlag)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_SELECT_FLAG, OracleType.Number);
            param[0].Value = Convert.ToInt16(selectFlag);
            param[1] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[1].Value = lfHeat.HeatId;
            param[2] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[2].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_LF_HEAT_SELECT_FLAG, param);
        }

        /// <summary>
        /// 将指定炉次的选择标志设置为指定值
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="selectFlag">要设置的selectFlag值</param>
        public void UpdateLFHeatSelectFlag(OracleTransaction trans, LFHeatInfo lfHeat, bool selectFlag)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_SELECT_FLAG, OracleType.Number);
            param[0].Value = Convert.ToInt16(selectFlag);
            param[1] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[1].Value = lfHeat.HeatId;
            param[2] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[2].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_LF_HEAT_SELECT_FLAG, param);
        }


        /// <summary>
        /// 将指定炉次的隐藏标志设置为指定值
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="visible">要设置的visible值</param>
        public void UpdateLFHeatVisible(LFHeatInfo lfHeat, bool visible)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_VISIBLE, OracleType.Number);
            param[0].Value = Convert.ToInt16(visible);
            param[1] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[1].Value = lfHeat.HeatId;
            param[2] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[2].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_LF_HEAT_VISIBLE, param);
        }

        /// <summary>
        /// 将指定炉次的隐藏标志设置为指定值
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="visible">要设置的visible值</param>
        public void UpdateLFHeatVisible(OracleTransaction trans, LFHeatInfo lfHeat, bool visible)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_VISIBLE, OracleType.Number);
            param[0].Value = Convert.ToInt16(visible);
            param[1] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[1].Value = lfHeat.HeatId;
            param[2] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[2].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_UPDATE_LF_HEAT_VISIBLE, param);
        }

        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatInfo(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_LF_HEAT_INFO, param);
        }

        /// <summary>
        /// 将炉次信息从TB_LF_Heat_Info表中删除
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_DELETE_LF_HEAT_INFO, param);
        }

        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatInfo(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;
            param[2] = new OracleParameter(PARAM_CAR, OracleType.Number);
            param[2].Value = lfHeat.IntParseCar() == null ? (object)DBNull.Value : lfHeat.IntParseCar();
            param[3] = new OracleParameter(PARAM_CLASS_NAME, OracleType.VarChar);
            param[3].Value = lfHeat.OperatorUser.ClassId;
            param[4] = new OracleParameter(PARAM_OPERATOR_NAME, OracleType.VarChar);
            param[4].Value = lfHeat.OperatorUser.UserName;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_LF_HEAT_INFO, param);
        }

        /// <summary>
        /// 将炉次信息插入至TB_LF_Heat_Info表
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;
            param[2] = new OracleParameter(PARAM_CAR, OracleType.Number);
            param[2].Value = lfHeat.IntParseCar() == null ? (object)DBNull.Value : lfHeat.IntParseCar();
            param[3] = new OracleParameter(PARAM_CLASS_NAME, OracleType.VarChar);
            param[3].Value = lfHeat.OperatorUser.ClassId;
            param[4] = new OracleParameter(PARAM_OPERATOR_NAME, OracleType.VarChar);
            param[4].Value = lfHeat.OperatorUser.UserName;

            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_INSERT_LF_HEAT_INFO, param);
        }

        /// <summary>
        /// 将炉次信息插入至TB_LF_L3_PLAN表中
        /// </summary>
        /// <param name="lfHeat">要插入的炉次信息</param>
        public void InsertLFHeatPlan(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter(PARAM_PLAN_ID, OracleType.VarChar);
            param[0].Value = lfHeat.PlanId == null ? (object)DBNull.Value : (object)lfHeat.PlanId;
            param[1] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[1].Value = lfHeat.HeatId == null ? (object)DBNull.Value : (object)lfHeat.HeatId;
            param[2] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[2].Value = lfHeat.TreatmentCount;
            param[3] = new OracleParameter(PARAM_STATION_ID, OracleType.Number);
            param[3].Value = lfHeat.PlanStationId == null ? (object)DBNull.Value : (object)lfHeat.PlanStationId;
            param[4] = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param[4].Value = lfHeat.SteelGrade.SteelGradeId == null ? (object)DBNull.Value : (object)lfHeat.SteelGrade.SteelGradeId;
            param[5] = new OracleParameter(PARAM_ROUTE_ID, OracleType.VarChar);
            param[5].Value = lfHeat.SteelGrade.RouteId == null ? (object)DBNull.Value : (object)lfHeat.SteelGrade.RouteId;
            param[6] = new OracleParameter(PARAM_LADLE_ID, OracleType.VarChar);
            param[6].Value = lfHeat.Ladle.LadleId == null ? (object)DBNull.Value : (object)lfHeat.Ladle.LadleId;
            param[7] = new OracleParameter(PARAM_PRE_START_DTIME, OracleType.DateTime);
            param[7].Value = lfHeat.PreStartTime == null ? (object)DBNull.Value : (object)lfHeat.PreStartTime;
            param[8] = new OracleParameter(PARAM_LF_TEMP_TGT, OracleType.Number);
            param[8].Value = lfHeat.TargetTemperature == null ? (object)DBNull.Value : (object)lfHeat.TargetTemperature;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_LF_HEAT_PLAN, param);
        }

        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        public void UpdateLFHeatInfoPK(LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("PARAM_NEW_HEAT_ID", OracleType.VarChar);
            param[0].Value = newLFHeat.HeatId;
            param[1] = new OracleParameter("PARAM_NEW_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = newLFHeat.TreatmentCount;
            param[2] = new OracleParameter("PARAM_OLD_HEAT_ID", OracleType.VarChar);
            param[2].Value = oldLFHeat.HeatId;
            param[3] = new OracleParameter("PARAM_OLD_TREATMENT_COUNT", OracleType.Number);
            param[3].Value = oldLFHeat.TreatmentCount;
            param[4] = new OracleParameter("PARAM_NEW_CLASS_NAME", OracleType.VarChar);
            param[4].Value = newLFHeat.OperatorUser.ClassId;
            param[5] = new OracleParameter("PARAM_NEW_OPERATOR_NAME", OracleType.VarChar);
            param[5].Value = newLFHeat.OperatorUser.UserName;


            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_UPD_LF_HEAT_INFO", param);
        }

        /// <summary>
        /// 更新TB_LF_HEAT_INFO的炉次信息的主键
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="oldLFHeat">原炉次信息</param>
        /// <param name="newLFHeat">新炉次信息</param>
        public void UpdateLFHeatInfoPK(OracleTransaction trans, LFHeatInfo oldLFHeat, LFHeatInfo newLFHeat)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("PARAM_NEW_HEAT_ID", OracleType.VarChar);
            param[0].Value = newLFHeat.HeatId;
            param[1] = new OracleParameter("PARAM_NEW_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = newLFHeat.TreatmentCount;
            param[2] = new OracleParameter("PARAM_OLD_HEAT_ID", OracleType.VarChar);
            param[2].Value = oldLFHeat.HeatId;
            param[3] = new OracleParameter("PARAM_OLD_TREATMENT_COUNT", OracleType.Number);
            param[3].Value = oldLFHeat.TreatmentCount;
            param[4] = new OracleParameter("PARAM_NEW_CLASS_NAME", OracleType.VarChar);
            param[4].Value = newLFHeat.OperatorUser.ClassId;
            param[5] = new OracleParameter("PARAM_NEW_OPERATOR_NAME", OracleType.VarChar);
            param[5].Value = newLFHeat.OperatorUser.UserName;

            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_UPD_LF_HEAT_INFO", param);
        }

        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void SelectLFHeatInfo(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PARAM_HEAT_ID", OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter("PARAM_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;
            param[2] = new OracleParameter("PARAM_CAR", OracleType.Number);
            param[2].Value = lfHeat.IntParseCar() == null ? (object)DBNull.Value : lfHeat.IntParseCar();
            param[3] = new OracleParameter("PARAM_CLASS_NAME", OracleType.VarChar);
            param[3].Value = lfHeat.OperatorUser.ClassId;
            param[4] = new OracleParameter("PARAM_OPERATOR_NAME", OracleType.VarChar);
            param[4].Value = lfHeat.OperatorUser.UserName;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_SELECT_HEAT_INFO", param);
        }

        /// <summary>
        /// 使用存储过程选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void SelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("PARAM_HEAT_ID", OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter("PARAM_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;
            param[2] = new OracleParameter("PARAM_CAR", OracleType.Number);
            param[2].Value = lfHeat.IntParseCar() == null ? (object)DBNull.Value : lfHeat.IntParseCar();
            param[3] = new OracleParameter("PARAM_CLASS_NAME", OracleType.VarChar);
            param[3].Value = lfHeat.OperatorUser.ClassId;
            param[4] = new OracleParameter("PARAM_OPERATOR_NAME", OracleType.VarChar);
            param[4].Value = lfHeat.OperatorUser.UserName;

            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_SELECT_HEAT_INFO", param);
        }


        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void CancelSelectLFHeatInfo(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PARAM_HEAT_ID", OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter("PARAM_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_CANCEL_SELECT_HEAT_INFO", param);
        }

        /// <summary>
        /// 使用存储过程取消选择炉次
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void CancelSelectLFHeatInfo(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PARAM_HEAT_ID", OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter("PARAM_TREATMENT_COUNT", OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_CANCEL_SELECT_HEAT_INFO", param);
        }

        /// <summary>
        /// 锁住临界区
        /// </summary>
        /// <param name="trans">事务</param>
        public void LockCriticalArea(OracleTransaction trans)
        {
            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_LOCK_CRITICAL_AREA, null);
        }

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatPlan(LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_LF_HEAT_PLAN, param);
        }

        /// <summary>
        /// 从TB_L3_LF_PLAN中删除指定炉次信息
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void DeleteLFHeatPlan(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = lfHeat.HeatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = lfHeat.TreatmentCount;

            OracleHelper.ExecuteNonQuery(trans, CommandType.Text, SQL_DELETE_LF_HEAT_PLAN, param);
        }

        /// <summary>
        /// 处理状态6
        /// </summary>
        /// <param name="trans">所在事务</param>
        /// <param name="lfHeat">炉次信息</param>
        public void ProcessStatusSix(OracleTransaction trans, LFHeatInfo lfHeat)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PARAM_CAR", OracleType.Number);
            param[0].Value = lfHeat.IntParseCar();
            param[1] = new OracleParameter("PARAM_HEAT_STATUS", OracleType.Number);
            param[1].Value = 4;
            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_LF_DATA_PROCESS_L2", param);
        }

        /// <summary>
        /// 使用某事务处理signal状态
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="lfHeat">炉次信息</param>
        /// <param name="signal">处理状态</param>
        public void ProcessStatus(OracleTransaction trans, LFHeatInfo lfHeat, ManualSignal signal)
        {
            int status = Convert.ToInt32(signal);

            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PARAM_CAR", OracleType.Number);
            param[0].Value = lfHeat.IntParseCar();
            param[1] = new OracleParameter("PARAM_HEAT_STATUS", OracleType.Number);
            param[1].Value = status;
            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_LF_DATA_PROCESS_L2", param);

        }

        /// <summary>
        /// 交换正在冶炼的两个工位的所有信息
        /// </summary>
        /// <param name="trans">所在事务</param>
        public void SwapCar(OracleTransaction trans)
        {
            OracleHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "LFDBUSER.LF_BLL.SP_SWAP_CAR", null);
        }

        #endregion
    }
}
