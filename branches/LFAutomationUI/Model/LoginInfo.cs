using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class LoginInfo
    {
        #region Inernal members

        private decimal msgId;
        private DateTime msgTimeStamp;
        private UserInfo user;
        private DateTime loginTime;
        private DateTime logoffTime;

        #endregion

        #region Properties

        public decimal MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }


        public DateTime MsgTimeStamp
        {
            get { return msgTimeStamp; }
            set { msgTimeStamp = value; }
        }


        public UserInfo User
        {
            get { return user; }
            set { user = value; }
        }


        public DateTime LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }


        public DateTime LogoffTime
        {
            get { return logoffTime; }
            set { logoffTime = value; }
        }
        
        #endregion

        #region Methods

        public LoginInfo()
        { }

        public LoginInfo(decimal msgId, DateTime msgTimeStamp, UserInfo user, DateTime loginTime, DateTime logoffTime)
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.user = user;
            this.loginTime = loginTime;
            this.logoffTime = logoffTime;
        }

        #endregion
        
        

        
    }
}
