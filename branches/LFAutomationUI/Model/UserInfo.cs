using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class UserInfo
    {
        #region Iinternal members

        private int userId;
        private string userName;
        private string userPassword;
        private string classId;
        private DateTime createdDate;
        private DateTime lastModifiedDate;
        private IList<PrivilegeInfo> privileges;
        private IList<RoleInfo> roles;

	    #endregion


        #region Properties
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }


        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string EncryptedPassword
        {
            get { return this.userPassword; }
            set { this.userPassword = value; }
        }

        public string UserPassword
        {
            get { return this.userPassword; }
            set { userPassword = Encryption.Encrypt(value,this.userName); }
        }

        public string ClassId
        {
            get { return classId; }
            set { classId = value; }
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



        public IList<RoleInfo> Roles
        {
            get { return roles; }
            set { roles = value; }
        }



        public IList<PrivilegeInfo> Privileges
        {
            get { return privileges; }
            set { privileges = value; }
        }
        #endregion

        #region puclic methods
        public UserInfo() { }

        public UserInfo(string userName, string userPassword, string classId)
        {
            this.userName = userName;
            this.UserPassword = userPassword;
            this.classId = classId;
        }

        public UserInfo(int userId,string userName, string userPassword, string classId)
        {
            this.userId = userId;
            this.userName = userName;
            this.UserPassword = userPassword;
            this.classId = classId;
        }

        public UserInfo(int userId, string userName, string userPassword, string classId, DateTime createdDate, DateTime lastModifiedDate)
        {
            this.userId = userId;
            this.userName = userName;
            this.UserPassword = userPassword;
            this.classId = classId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
        }

        public UserInfo(int userId, string userName, string classId, DateTime createdDate, DateTime lastModifiedDate)
        {
            this.userId = userId;
            this.userName = userName;
            this.classId = classId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
        }

        public UserInfo(int userId, string userName, string userPassword, string classId, DateTime createdDate, DateTime lastModifiedDate, IList<RoleInfo> roles)
        {
            this.userId = userId;
            this.userName = userName;
            this.UserPassword = userPassword;
            this.classId = classId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
            this.roles = roles;
        }

        public UserInfo(int userId, string userName, string userPassword, string classId, DateTime createdDate, DateTime lastModifiedDate, IList<RoleInfo> roles, IList<PrivilegeInfo> privileges)
        {
            this.userId = userId;
            this.userName = userName;
            this.UserPassword = userPassword;
            this.classId = classId;
            this.createdDate = createdDate;
            this.lastModifiedDate = lastModifiedDate;
            this.roles = roles;
            this.privileges = privileges;
        }

        #endregion

        
    }
}
