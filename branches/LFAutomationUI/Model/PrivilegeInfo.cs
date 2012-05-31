using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class PrivilegeInfo
    {
        #region Internal members

        private int privilegeId;
        private string privilegeName;
        private int parentPrivilegeId;
        private DateTime createdDate;
        private DateTime lastModifiedDate;
        private int priviDescription;

        #endregion

        #region Properties

        public int PrivilegeId
        {
            get { return privilegeId; }
            set { privilegeId = value; }
        }

        public string PrivilegeName
        {
            get { return privilegeName; }
            set { privilegeName = value; }
        }

        public int ParentPrivilegeId
        {
            get { return parentPrivilegeId; }
            set { parentPrivilegeId = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { lastModifiedDate = value; }
        }

        public int PriviDescription
        {
            get { return priviDescription; }
            set { priviDescription = value; }
        }

        #endregion

        #region Public Methods

        public PrivilegeInfo() { }

        public PrivilegeInfo(int privilegeId, string privilegeName,int parentPrivilegeId, DateTime createdDate, DateTime lastModifiedDate)
        {
            this.privilegeId = privilegeId;
            this.privilegeName = privilegeName;
            this.parentPrivilegeId = parentPrivilegeId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
        }

        public PrivilegeInfo(int privilegeId, string privilegeName, int parentPrivilegeId,DateTime createdDate, DateTime lastModifiedDate, int priviDescription)
        {
            this.privilegeId = privilegeId;
            this.privilegeName = privilegeName;
            this.parentPrivilegeId = parentPrivilegeId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
            this.priviDescription = priviDescription;
        }

        public PrivilegeInfo(string privilegeName, int parentPrivilegeId)
        {
            this.privilegeName = privilegeName;
            this.parentPrivilegeId = parentPrivilegeId;
        }
        #endregion
    }
}
