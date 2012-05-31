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
    public class SlagQualityHorizontal : ISlagQualityHorizontal
    {
        #region SQL && PARAM
        private string SQL_GET_SLAG_QUALITY_INFO_BY_HEAT_ID = @"select MSG_ID,
                                                                       MSG_TIME_STAMP,
                                                                       HEAT_ID,
                                                                       TREATMENT_COUNT,
                                                                       SAMPLE_ADDR,
                                                                       SAMPLE_NUMBER,
                                                                       SAMPLE_TIME,
                                                                       ANAL_SIO2,
                                                                       ANAL_CAO,
                                                                       ANAL_MNO,
                                                                       ANAL_MGO,
                                                                       ANAL_P2O5,
                                                                       ANAL_AL2O3,
                                                                       ANAL_FEOX,
                                                                       ANAL_FE_TOT,
                                                                       ANAL_OX,
                                                                       ANAL_CAF2,
                                                                       ANAL_O2,
                                                                       ANAL_S,
                                                                       ANAL_NA2O,
                                                                       ANAL_CR2O3,
                                                                       ANAL_TIO2,
                                                                       ANAL_K2O
                                                                  from tb_slag_quality t WHERE T.HEAT_ID=:HEAT_ID";
        private string PARAM_HEAT_ID = ":HEAT_ID";
        #endregion

        #region ISlagQualityHorizontal 成员

        /// <summary>
        /// 根据炉次号获取渣化验信息
        /// </summary>
        /// <param name="heatId">炉次号</param>
        /// <returns>渣化验信息</returns>
        public IList<SlagQualityHorizontalInfo> GetSlagQualityInfo(string heatId)
        {
            IList<SlagQualityHorizontalInfo> slagQualityList = new List<SlagQualityHorizontalInfo>();
            OracleParameter param = new OracleParameter(PARAM_HEAT_ID, OracleType.VarChar);
            param.Value = heatId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_SLAG_QUALITY_INFO_BY_HEAT_ID, param))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    int treatmentCount = Convert.ToInt32(odr["TREATMENT_COUNT"]);
                    DateTime? sampleTime = odr["SAMPLE_TIME"] == DBNull.Value ? null : new Nullable<DateTime>(Convert.ToDateTime(odr["SAMPLE_TIME"]));
                    string samplePlace = odr["SAMPLE_ADDR"] == DBNull.Value ? null : odr["SAMPLE_ADDR"].ToString();
                    int? sampleNumber = odr["SAMPLE_NUMBER"] == DBNull.Value ? null : new Nullable<Int32>(Convert.ToInt32(odr["SAMPLE_NUMBER"]));
                    double? analSIO2 = odr["ANAL_SIO2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_SIO2"]));
                    double? analCAO = odr["ANAL_CAO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_CAO"]));
                    double? analMNO = odr["ANAL_MNO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_MNO"]));
                    double? analMGO = odr["ANAL_MGO"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_MGO"]));
                    double? analP2O5 = odr["ANAL_P2O5"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_P2O5"]));
                    double? analAL2O3 = odr["ANAL_AL2O3"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_AL2O3"]));
                    double? analFEOX = odr["ANAL_FEOX"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_FEOX"]));
                    double? analFE_TOT = odr["ANAL_FE_TOT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_FE_TOT"]));
                    double? analOX = odr["ANAL_OX"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_OX"]));
                    double? analCAF2 = odr["ANAL_CAF2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_CAF2"]));
                    double? analO2 = odr["ANAL_O2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_O2"]));
                    double? analS = odr["ANAL_S"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_S"]));
                    double? analNA2O = odr["ANAL_NA2O"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_NA2O"]));
                    double? analCR2O3 = odr["ANAL_CR2O3"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_CR2O3"]));
                    double? analTIO2 = odr["ANAL_TIO2"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_TIO2"]));
                    double? analK2O = odr["ANAL_K2O"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(odr["ANAL_K2O"]));
                    SlagQualityHorizontalInfo slagQualityInfo = new SlagQualityHorizontalInfo(msgId, msgTimeStamp, heatId, treatmentCount, sampleTime, 
                                                                samplePlace, sampleNumber, analSIO2, analCAO, analMNO, analMGO, analP2O5, analAL2O3, 
                                                                analFEOX, analFE_TOT, analOX, analCAF2, analO2, analS, analNA2O, analCR2O3, analTIO2, analK2O);
                    slagQualityList.Add(slagQualityInfo);
                }
            }
            return slagQualityList;
        }

        #endregion
    }
}
