using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class RoleInfo
    {
        #region Internal members

        private int roleId;
        private string roleName;
        private DateTime createdDate;
        private DateTime lastModifiedDate;
        private IList<PrivilegeInfo> privileges;

        #endregion
        

        #region Properties

        public int RoleID
        {
            get { return roleId; }
            set { roleId = value; }
        }
        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
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

        public IList<PrivilegeInfo> Privileges
        {
            get { return privileges; }
            set { privileges = value; }
        }

        #endregion

        public RoleInfo() { }

        public RoleInfo(int roleId,string roleName,DateTime createdDate,DateTime lastModifiedDate)
        {
            this.roleId = roleId;
            this.roleName = roleName;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
        }

        public RoleInfo(int roleId, string roleName, DateTime createdDate, DateTime lastModifiedDate,IList<PrivilegeInfo> privileges)
        {
            this.roleId = roleId;
            this.roleName = roleName;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
            this.privileges = privileges;
        }
        
    }
}
