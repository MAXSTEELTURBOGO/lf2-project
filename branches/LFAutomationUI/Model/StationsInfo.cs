using System;
using System.Collections.Generic;
using System.Linq;

namespace LFAutomationUI.Model
{
    public class Stations
    {
        #region Internal members
        private IList<TreatmentStationInfo> stationsInfo;
        #endregion
        

        #region Properties
        public IList<TreatmentStationInfo> StationsInfo
        {
            get { return this.stationsInfo; }
            set { this.stationsInfo = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public Stations() 
        {
        }

        public TreatmentStationInfo GetTreatmentStationInfoByName(string treatmentStationName)
        {
            try
            {
                return stationsInfo.Single<TreatmentStationInfo>(treatmentStation => treatmentStation.TreatmentStationName == treatmentStationName);
            }
            catch (Exception)
            {
                return null;               
            }
            
        }
        #endregion
        
    }
}
