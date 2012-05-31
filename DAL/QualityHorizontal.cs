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
    public class QualityHorizontal : IQualityHorizontal
    {
        #region SQL AND PARAM

        private string SQL_GET_QUALITY_INFO_BY_HEAT_ID = @" SELECT MSG_ID,
                                                                   MSG_TIME_STAMP,
                                                                   HEAT_ID,
                                                                   TREATMENT_COUNT,
                                                                   SAMPLE_TIME,
                                                                   SAMPLE_PLACE,
                                                                   SAMPLE_NUMBER,
                                                                   ANAL_CODE,
                                                                   STATION_NO,
                                                                   ELE_C,
                                                                   ELE_SI,
                                                                   ELE_MN,
                                                                   ELE_P,
                                                                   ELE_S,
                                                                   ELE_CU,
                                                                   ELE_TAL,
                                                                   ELE_SOL,
                                                                   ELE_B,
                                                                   ELE_NI,
                                                                   ELE_CR,
                                                                   ELE_MO,
                                                                   ELE_W,
                                                                   ELE_TI,
                                                                   ELE_V,
                                                                   ELE_ZR,
                                                                   ELE_PB,
                                                                   ELE_SN,
                                                                   ELE_AS,
                                                                   ELE_CA,
                                                                   ELE_CO,
                                                                   ELE_MG,
                                                                   ELE_TE,
                                                                   ELE_BI,
                                                                   ELE_SB,
                                                                   ELE_ZN,
                                                                   ELE_NB,
                                                                   ELE_H,
                                                                   ELE_N,
                                                                   ELE_O,
                                                                   ELE_AL,
                                                                   ELE_ALT,
                                                                   ELE_SE,
                                                                   ELE_RE,
                                                                   ELE_ALS,
                                                                   ELE_CEQ,
                                                                   ELE_PCM,
                                                                   ELE_PSR,
                                                                   ELE_TA,
                                                                   ELE_ALN,
                                                                   ELE_CAS,
                                                                   ELE_CRMO,
                                                                   ELE_CRMOCU,
                                                                   ELE_CRMOCUNI,
                                                                   ELE_CUCR,
                                                                   ELE_CUNI,
                                                                   ELE_MNSI,
                                                                   ELE_NBN,
                                                                   ELE_NBJN,
                                                                   ELE_NBVTI,
                                                                   ELE_NICR,
                                                                   ELE_NICRCU,
                                                                   ELE_PS,
                                                                   ELE_TIN,
                                                                   ELE_VNB
                                                              FROM TB_QUALITY T1
                                                             WHERE T1.HEAT_ID = :HEAT_ID
                                                              ORDER BY T1.SAMPLE_TIME DESC";

        private string SQL_GET_QUALITY_INFO_BY_HEAT_ID_AND_TREATMENT_COUNT = @" SELECT MSG_ID,
                                                                                       MSG_TIME_STAMP,
                                                                                       HEAT_ID,
                                                                                       TREATMENT_COUNT,
                                                                                       SAMPLE_TIME,
                                                                                       SAMPLE_PLACE,
                                                                                       SAMPLE_NUMBER,
                                                                                       ANAL_CODE,
                                                                                       STATION_NO,
                                                                                       ELE_C,
                                                                                       ELE_SI,
                                                                                       ELE_MN,
                                                                                       ELE_P,
                                                                                       ELE_S,
                                                                                       ELE_CU,
                                                                                       ELE_TAL,
                                                                                       ELE_SOL,
                                                                                       ELE_B,
                                                                                       ELE_NI,
                                                                                       ELE_CR,
                                                                                       ELE_MO,
                                                                                       ELE_W,
                                                                                       ELE_TI,
                                                                                       ELE_V,
                                                                                       ELE_ZR,
                                                                                       ELE_PB,
                                                                                       ELE_SN,
                                                                                       ELE_AS,
                                                                                       ELE_CA,
                                                                                       ELE_CO,
                                                                                       ELE_MG,
                                                                                       ELE_TE,
                                                                                       ELE_BI,
                                                                                       ELE_SB,
                                                                                       ELE_ZN,
                                                                                       ELE_NB,
                                                                                       ELE_H,
                                                                                       ELE_N,
                                                                                       ELE_O,
                                                                                       ELE_AL,
                                                                                       ELE_ALT,
                                                                                       ELE_SE,
                                                                                       ELE_RE,
                                                                                       ELE_ALS,
                                                                                       ELE_CEQ,
                                                                                       ELE_PCM,
                                                                                       ELE_PSR,
                                                                                       ELE_TA,
                                                                                       ELE_ALN,
                                                                                       ELE_CAS,
                                                                                       ELE_CRMO,
                                                                                       ELE_CRMOCU,
                                                                                       ELE_CRMOCUNI,
                                                                                       ELE_CUCR,
                                                                                       ELE_CUNI,
                                                                                       ELE_MNSI,
                                                                                       ELE_NBN,
                                                                                       ELE_NBJN,
                                                                                       ELE_NBVTI,
                                                                                       ELE_NICR,
                                                                                       ELE_NICRCU,
                                                                                       ELE_PS,
                                                                                       ELE_TIN,
                                                                                       ELE_VNB
                                                                                  FROM TB_QUALITY T1
                                                                                 WHERE T1.HEAT_ID = :HEAT_ID AND TREATMENT_COUNT = :TREATMENT_COUNT
                                                                                  ORDER BY T1.SAMPLE_TIME DESC";
        private string PARAM_HEAT_ID = ":HEAT_ID";
        private string PARAM_TREATMENT_COUNT = ":TREATMENT_COUNT";

        #endregion

        #region IQualityDetail 成员接口的实现

        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>化验信息</returns>
        public IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId)
        {
            IList<QualityHorizontalInfo> qualityDetailList = new List<QualityHorizontalInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_QUALITY_INFO_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    QualityHorizontalInfo qualityDetailInfo = new QualityHorizontalInfo();
                    qualityDetailInfo.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    qualityDetailInfo.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    qualityDetailInfo.HeatId = heatId;
                    qualityDetailInfo.TreatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    qualityDetailInfo.SampleTime = Convert.ToDateTime(odr["SAMPLE_TIME"]);
                    qualityDetailInfo.SamplePlace = odr["SAMPLE_PLACE"].ToString();
                    qualityDetailInfo.SampleNumber = Convert.ToInt32(odr["SAMPLE_NUMBER"]);
                    qualityDetailInfo.AnalCode = odr["ANAL_CODE"].ToString();
                    qualityDetailInfo.StationId = odr["STATION_NO"].ToString();
                    qualityDetailInfo.EleC = odr["ELE_C"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_C"]));
                    qualityDetailInfo.EleSI = odr["ELE_SI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SI"]));
                    qualityDetailInfo.EleMN = odr["ELE_MN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MN"]));
                    qualityDetailInfo.EleP = odr["ELE_P"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_P"]));
                    qualityDetailInfo.EleS = odr["ELE_S"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_S"]));
                    qualityDetailInfo.EleCU = odr["ELE_CU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CU"]));
                    qualityDetailInfo.EleTAL = odr["ELE_TAL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TAL"]));
                    qualityDetailInfo.EleSOL = odr["ELE_SOL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SOL"]));
                    qualityDetailInfo.EleB = odr["ELE_B"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_B"]));
                    qualityDetailInfo.EleNI = odr["ELE_NI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NI"]));
                    qualityDetailInfo.EleCR = odr["ELE_CR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CR"]));
                    qualityDetailInfo.EleMO = odr["ELE_MO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MO"]));
                    qualityDetailInfo.EleW = odr["ELE_W"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_W"]));
                    qualityDetailInfo.EleTI = odr["ELE_TI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TI"]));
                    qualityDetailInfo.EleV = odr["ELE_V"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_V"]));
                    qualityDetailInfo.EleZR = odr["ELE_ZR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ZR"]));
                    qualityDetailInfo.ElePB = odr["ELE_PB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PB"]));
                    qualityDetailInfo.EleSN = odr["ELE_SN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SN"]));
                    qualityDetailInfo.EleAS = odr["ELE_AS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_AS"]));
                    qualityDetailInfo.EleCA = odr["ELE_CA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CA"]));
                    qualityDetailInfo.EleCO = odr["ELE_CO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CO"]));
                    qualityDetailInfo.EleMG = odr["ELE_MG"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MG"]));
                    qualityDetailInfo.EleTE = odr["ELE_TE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TE"]));
                    qualityDetailInfo.EleBI = odr["ELE_BI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_BI"]));
                    qualityDetailInfo.EleSB = odr["ELE_SB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SB"]));
                    qualityDetailInfo.EleZN = odr["ELE_ZN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ZN"]));
                    qualityDetailInfo.EleNB = odr["ELE_NB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NB"]));
                    qualityDetailInfo.EleH = odr["ELE_H"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_H"]));
                    qualityDetailInfo.EleN = odr["ELE_N"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_N"]));
                    qualityDetailInfo.EleO = odr["ELE_O"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_O"]));
                    qualityDetailInfo.EleAL = odr["ELE_AL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_AL"]));
                    qualityDetailInfo.EleALT = odr["ELE_ALT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALT"]));
                    qualityDetailInfo.EleSE = odr["ELE_SE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SE"]));
                    qualityDetailInfo.EleRE = odr["ELE_RE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_RE"]));
                    qualityDetailInfo.EleALS = odr["ELE_ALS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALS"]));
                    qualityDetailInfo.EleCEQ = odr["ELE_CEQ"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CEQ"]));
                    qualityDetailInfo.ElePCM = odr["ELE_PCM"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PCM"]));
                    qualityDetailInfo.ElePSR = odr["ELE_PSR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PSR"]));
                    qualityDetailInfo.EleTA = odr["ELE_TA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TA"]));
                    qualityDetailInfo.EleALN = odr["ELE_ALN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALN"]));
                    qualityDetailInfo.EleCAS = odr["ELE_CAS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CAS"]));
                    qualityDetailInfo.EleCRMO = odr["ELE_CRMO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMO"]));
                    qualityDetailInfo.EleCRMOCU = odr["ELE_CRMOCU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMOCU"]));
                    qualityDetailInfo.EleCRMOCUNI = odr["ELE_CRMOCUNI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMOCUNI"]));
                    qualityDetailInfo.EleCUCR = odr["ELE_CUCR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CUCR"]));
                    qualityDetailInfo.EleCUNI = odr["ELE_CUNI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CUNI"]));
                    qualityDetailInfo.EleMNSI = odr["ELE_MNSI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MNSI"]));
                    qualityDetailInfo.EleNBN = odr["ELE_NBN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBN"]));
                    qualityDetailInfo.EleNBJN = odr["ELE_NBJN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBJN"]));
                    qualityDetailInfo.EleNBVTI = odr["ELE_NBVTI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBVTI"]));
                    qualityDetailInfo.EleNICR = odr["ELE_NICR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NICR"]));
                    qualityDetailInfo.EleNICRCU = odr["ELE_NICRCU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NICRCU"]));
                    qualityDetailInfo.ElePS = odr["ELE_PS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PS"]));
                    qualityDetailInfo.EleTIN = odr["ELE_TIN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TIN"]));
                    qualityDetailInfo.EleVNB = odr["ELE_VNB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_VNB"]));
                    qualityDetailList.Add(qualityDetailInfo);
                }   
            }
            return qualityDetailList;
        }

        /// <summary>
        /// 根据炉次号取出化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <param name="treatmentCount">冶炼次数</param>
        /// <returns>化验信息</returns>
        public IList<QualityHorizontalInfo> GetQualityDetailInfo(string heatId, int treatmentCount)
        {
            IList<QualityHorizontalInfo> qualityDetailList = new List<QualityHorizontalInfo>();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param[0].Value = heatId;
            param[1] = new OracleParameter(PARAM_TREATMENT_COUNT, OracleType.Number);
            param[1].Value = treatmentCount;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text,SQL_GET_QUALITY_INFO_BY_HEAT_ID_AND_TREATMENT_COUNT, param))
            {
                while (odr.Read())
                {
                    QualityHorizontalInfo qualityDetailInfo = new QualityHorizontalInfo();
                    qualityDetailInfo.MsgId = Convert.ToDecimal(odr["MSG_ID"]);
                    qualityDetailInfo.MsgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    qualityDetailInfo.HeatId = heatId;
                    qualityDetailInfo.TreatmentCount = treatmentCount;
                    qualityDetailInfo.SampleTime = Convert.ToDateTime(odr["SAMPLE_TIME"]);
                    qualityDetailInfo.SamplePlace = odr["SAMPLE_PLACE"].ToString();
                    qualityDetailInfo.SampleNumber = Convert.ToInt32(odr["SAMPLE_NUMBER"]);
                    qualityDetailInfo.AnalCode = odr["ANAL_CODE"].ToString();
                    qualityDetailInfo.StationId = odr["STATION_NO"].ToString();
                    qualityDetailInfo.EleC = odr["ELE_C"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_C"]));
                    qualityDetailInfo.EleSI = odr["ELE_SI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SI"]));
                    qualityDetailInfo.EleMN = odr["ELE_MN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MN"]));
                    qualityDetailInfo.EleP = odr["ELE_P"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_P"]));
                    qualityDetailInfo.EleS = odr["ELE_S"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_S"]));
                    qualityDetailInfo.EleCU = odr["ELE_CU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CU"]));
                    qualityDetailInfo.EleTAL = odr["ELE_TAL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TAL"]));
                    qualityDetailInfo.EleSOL = odr["ELE_SOL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SOL"]));
                    qualityDetailInfo.EleB = odr["ELE_B"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_B"]));
                    qualityDetailInfo.EleNI = odr["ELE_NI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NI"]));
                    qualityDetailInfo.EleCR = odr["ELE_CR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CR"]));
                    qualityDetailInfo.EleMO = odr["ELE_MO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MO"]));
                    qualityDetailInfo.EleW = odr["ELE_W"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_W"]));
                    qualityDetailInfo.EleTI = odr["ELE_TI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TI"]));
                    qualityDetailInfo.EleV = odr["ELE_V"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_V"]));
                    qualityDetailInfo.EleZR = odr["ELE_ZR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ZR"]));
                    qualityDetailInfo.ElePB = odr["ELE_PB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PB"]));
                    qualityDetailInfo.EleSN = odr["ELE_SN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SN"]));
                    qualityDetailInfo.EleAS = odr["ELE_AS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_AS"]));
                    qualityDetailInfo.EleCA = odr["ELE_CA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CA"]));
                    qualityDetailInfo.EleCO = odr["ELE_CO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CO"]));
                    qualityDetailInfo.EleMG = odr["ELE_MG"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MG"]));
                    qualityDetailInfo.EleTE = odr["ELE_TE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TE"]));
                    qualityDetailInfo.EleBI = odr["ELE_BI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_BI"]));
                    qualityDetailInfo.EleSB = odr["ELE_SB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SB"]));
                    qualityDetailInfo.EleZN = odr["ELE_ZN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ZN"]));
                    qualityDetailInfo.EleNB = odr["ELE_NB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NB"]));
                    qualityDetailInfo.EleH = odr["ELE_H"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_H"]));
                    qualityDetailInfo.EleN = odr["ELE_N"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_N"]));
                    qualityDetailInfo.EleO = odr["ELE_O"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_O"]));
                    qualityDetailInfo.EleAL = odr["ELE_AL"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_AL"]));
                    qualityDetailInfo.EleALT = odr["ELE_ALT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALT"]));
                    qualityDetailInfo.EleSE = odr["ELE_SE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_SE"]));
                    qualityDetailInfo.EleRE = odr["ELE_RE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_RE"]));
                    qualityDetailInfo.EleALS = odr["ELE_ALS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALS"]));
                    qualityDetailInfo.EleCEQ = odr["ELE_CEQ"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CEQ"]));
                    qualityDetailInfo.ElePCM = odr["ELE_PCM"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PCM"]));
                    qualityDetailInfo.ElePSR = odr["ELE_PSR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PSR"]));
                    qualityDetailInfo.EleTA = odr["ELE_TA"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TA"]));
                    qualityDetailInfo.EleALN = odr["ELE_ALN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_ALN"]));
                    qualityDetailInfo.EleCAS = odr["ELE_CAS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CAS"]));
                    qualityDetailInfo.EleCRMO = odr["ELE_CRMO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMO"]));
                    qualityDetailInfo.EleCRMOCU = odr["ELE_CRMOCU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMOCU"]));
                    qualityDetailInfo.EleCRMOCUNI = odr["ELE_CRMOCUNI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CRMOCUNI"]));
                    qualityDetailInfo.EleCUCR = odr["ELE_CUCR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CUCR"]));
                    qualityDetailInfo.EleCUNI = odr["ELE_CUNI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_CUNI"]));
                    qualityDetailInfo.EleMNSI = odr["ELE_MNSI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_MNSI"]));
                    qualityDetailInfo.EleNBN = odr["ELE_NBN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBN"]));
                    qualityDetailInfo.EleNBJN = odr["ELE_NBJN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBJN"]));
                    qualityDetailInfo.EleNBVTI = odr["ELE_NBVTI"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NBVTI"]));
                    qualityDetailInfo.EleNICR = odr["ELE_NICR"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NICR"]));
                    qualityDetailInfo.EleNICRCU = odr["ELE_NICRCU"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_NICRCU"]));
                    qualityDetailInfo.ElePS = odr["ELE_PS"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_PS"]));
                    qualityDetailInfo.EleTIN = odr["ELE_TIN"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_TIN"]));
                    qualityDetailInfo.EleVNB = odr["ELE_VNB"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ELE_VNB"]));
                    qualityDetailList.Add(qualityDetailInfo);
                }
            }
            return qualityDetailList;
        }

        #endregion
    }
}
