using System;

namespace LFAutomationUI.Model
{
    [Serializable]
    public class TreatmentStationInfo
    {
        #region Internal members
        private string treatmentStationId;
        private string treatmentStationName;
        private CommStatus treatmentStationStatus;
        private string treatmentStationIpAddress;
        private string treatmentStationUserName;
        private string treatmentStationPassword;
        #endregion
        #region Properties
        public string TreatmentStationId
        {
            get { return this.treatmentStationId; }
            set { this.treatmentStationId = value; }
        }
        public string TreatmentStationName
        {
            get { return this.treatmentStationName; }
            set { this.treatmentStationName = value; }
        }
        public string TreatmentStationIpAddress
        {
            get { return this.treatmentStationIpAddress; }
            set { this.treatmentStationIpAddress = value; }
        }
        public CommStatus TreatmentStationStatus
        {
            get { return this.treatmentStationStatus; }
            set { this.treatmentStationStatus = value; }
        }
        public string TreatmentStationUserName
        {
            get { return this.treatmentStationUserName; }
            set { this.treatmentStationUserName = value; }
        }
        public string TreatmentStationPassword
        {
            get { return this.treatmentStationPassword; }
            set { this.treatmentStationPassword = value; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Default constructor
        /// </summary>
        public TreatmentStationInfo() { }

        /// <summary>
        /// Constructor with specified parameters
        /// </summary>
        /// <param name="treatmentStationId">treatmnet station id</param>
        /// <param name="treatmentStationName">treatment station name</param>
        /// <param name="treatmentStationStatus">treatment station status</param>
        /// <param name="treatmentStationIpAddress">treatment station Ip address</param>
        /// <param name="treatmentStationUserName">treatment station user name</param>
        /// <param name="treatmentStationPassword">treatment station password</param>
        public TreatmentStationInfo(string treatmentStationId, string treatmentStationName, string treatmentStationStatus, string treatmentStationIpAddress, string treatmentStationUserName, string treatmentStationPassword)
        {
            this.treatmentStationId = treatmentStationId;
            this.treatmentStationName = treatmentStationName;
            SetTreatmentStationStatus(treatmentStationStatus);
            this.treatmentStationIpAddress = treatmentStationIpAddress;
            this.treatmentStationUserName = treatmentStationUserName;
            this.treatmentStationPassword = treatmentStationPassword;
        }

        /// <summary>
        /// Method to set treatment station status
        /// </summary>
        /// <param name="treatmentStationStatus">treatment station status,"1" refer to normal,"0" refers to abnormal </param>
        private void SetTreatmentStationStatus(string treatmentStationStatus)
        {
            switch (treatmentStationStatus)
            {
                case "1":
                    this.treatmentStationStatus = CommStatus.Good;
                    break;
                case "2":
                    this.treatmentStationStatus = CommStatus.Bad;
                    break;
                case "3":
                    this.treatmentStationStatus = CommStatus.Unknown;
                    break;
            }
        }

        /// <summary>
        /// Method to get treatment station status
        /// </summary>
        /// <returns>treatment station status,"1" refer to normal,"0" refers to abnormal</returns>
        public string GetTreatmentStationStatus()
        {
            switch (this.treatmentStationStatus)
            {
                case CommStatus.Unknown:
                    return "3";
                case CommStatus.Good:
                    return "1";
                case CommStatus.Bad:
                    return "2";
                default:
                    return "3";
            }
        }
        
        /// <summary>
        /// Method to update connection status
        /// </summary>
        public void UpdateStatus()
        {
            bool status = this.CheckConnection();
            switch (status)
            {
                case true:
                    treatmentStationStatus = CommStatus.Good;
                    break;
                case false:
                    treatmentStationStatus = CommStatus.Bad;
                    break;
                default:
                    treatmentStationStatus = CommStatus.Unknown;
                    break;
            }
        }

        /// <summary>
        /// Method to check connection status
        /// </summary>
        /// <returns>connection status,true refers to normal,false refers to abnormal</returns>
        protected bool CheckConnection()
        {
            string error = null;
            return ConnectionDiagnose.CheckConnection(this.treatmentStationIpAddress, out error);
        }
        #endregion
    }
}
