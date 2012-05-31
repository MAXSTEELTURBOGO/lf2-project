using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class TreatmentStation:ITreatmentStation
    {
        #region Internal members
        private const string SQL_SELECT_TREATMENTSTATIONS = "SELECT T.TREATMENT_STATION_ID,T.TREATMENT_STATION_NAME,T.TREATMENT_STATION_STATUS,T.TREATMENT_STATION_IP_ADDRESS,T.TREATMENT_STATION_USER_NAME,T.TREATMENT_STATION_PASSWORD FROM LFOPCUSER.TB_STATION_INFO T";
        private const string SQL_SELECT_TREATMENTSTATION_BY_TREATMENTSTATIONNAME = "SELECT T.TREATMENT_STATION_ID,T.TREATMENT_STATION_NAME,T.TREATMENT_STATION_STATUS,T.TREATMENT_STATION_IP_ADDRESS,T.TREATMENT_STATION_USER_NAME,T.TREATMENT_STATION_PASSWORD "
                                                                                 + "FROM LFOPCUSER.TB_STATION_INFO T WHERE T.TREATMENT_STATION_NAME=:TREATMENT_STATION_NAME";
        private const string SQL_UPDATE_TREATMENT_STATION_STATUS = "UPDATE LFOPCUSER.TB_STATION_INFO SET TREATMENT_STATION_STATUS=:TREATMENT_STATION_STATUS{0} WHERE TREATMENT_STATION_NAME=:TREATMENT_STATION_NAME{0}";
        private const string PARAM_TREATMENT_STATION_NAME=":TREATMENT_STATION_NAME";
        private const string PARAM_TREATMENT_STATION_STATUS = ":TREATMENT_STATION_STATUS";
	    #endregion
        

        /// <summary>
        /// Method definition to search all treatment station infromation
        /// </summary>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        public IList<TreatmentStationInfo> GetTreatmentStations()
        {
            IList<TreatmentStationInfo> treatmentStations = new List<TreatmentStationInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TREATMENTSTATIONS,null))
            {
                while (odr.Read())
                {
                    string treatmentStationId = odr.GetString(0);
                    string treatmentStationName = odr.GetString(1);
                    string treatmentStationStatus = odr.GetString(2);
                    string treatmentStationIpAddress = null;
                    try
                    {
                        treatmentStationIpAddress = odr.GetString(3);
                    }
                    catch { }
                    string treatmentStationUserName = null;
                    try
                    {
                        treatmentStationUserName = odr.GetString(4);
                    }
                    catch { }
                    string treatmentStationPassword = null;
                    try
                    {
                        treatmentStationPassword = odr.GetString(5);
                    }
                    catch { }
                    TreatmentStationInfo treatmentStation = new TreatmentStationInfo(treatmentStationId,treatmentStationName,treatmentStationStatus,treatmentStationIpAddress,treatmentStationUserName,treatmentStationPassword);
                    treatmentStations.Add(treatmentStation);
                }
            }
            return treatmentStations;
        }

        /// <summary>
        /// Method definition to search treatment station by specified treatment station name
        /// </summary>
        /// <param name="treatmentStationName">specified treatment station name</param>
        /// <returns>treatment station information with specified treatment station name</returns>
        public TreatmentStationInfo GetTreatmentStationByTreatmentStationName(string treatmentStationName)
        {
            TreatmentStationInfo treatmentStation = null;
            OracleParameter param = new OracleParameter(PARAM_TREATMENT_STATION_NAME, OracleType.VarChar);
            param.Value = treatmentStationName;
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_TREATMENTSTATION_BY_TREATMENTSTATIONNAME,param))
            {
                odr.Read();
                string treatmentStationId = odr.GetString(0);
                string treatmentStationStatus = odr.GetString(2);
                string treatmentStationIpAddress = odr.GetString(3);

                string treatmentStationUserName = null;
                try
                {
                    treatmentStationUserName = odr.GetString(4);
                }
                catch { }
                string treatmentStationPassword = null;
                try
                {
                    treatmentStationPassword = odr.GetString(5);
                }
                catch { }
                treatmentStation = new TreatmentStationInfo(treatmentStationId, treatmentStationName, treatmentStationStatus, treatmentStationIpAddress, treatmentStationUserName, treatmentStationPassword);
            }
            return treatmentStation;
        }

        /// <summary>
        /// Method definition to update specified treatment stations
        /// </summary>
        /// <param name="treatmentStations">specified treatment stations</param>
        public void UpdateTreatmentStationStatus(IList<TreatmentStationInfo> treatmentStations) 
        {
            // Total number of parameters = (2 * number of lines)
            int numberOfParameters = 2 * treatmentStations.Count;
            
            // Create a parameters array based on the number of items in the array
            OracleParameter[] completeParameters = new OracleParameter[numberOfParameters];

            // Create a string builder to hold the entire query
            // Start the PL/SQL block
            StringBuilder finalSQLQuery = new StringBuilder("BEGIN ");
            int index = 0;
            int i = 1;
            foreach (TreatmentStationInfo treatmentStation in treatmentStations)
            {
                completeParameters[index] = new OracleParameter(PARAM_TREATMENT_STATION_NAME + i, OracleType.VarChar);
                completeParameters[index++].Value = treatmentStation.TreatmentStationName;
                completeParameters[index] = new OracleParameter(PARAM_TREATMENT_STATION_STATUS + i, OracleType.VarChar);
                completeParameters[index++].Value = treatmentStation.GetTreatmentStationStatus();
                finalSQLQuery.Append(string.Format(SQL_UPDATE_TREATMENT_STATION_STATUS, i));
                finalSQLQuery.Append("; ");
                i++;
            }
            finalSQLQuery.Append("END;");
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, finalSQLQuery.ToString(), completeParameters);
        }
    }
}
