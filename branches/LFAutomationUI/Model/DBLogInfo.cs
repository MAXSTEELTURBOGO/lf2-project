using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFAutomationUI.Model
{
    public class DBLogInfo
    {
        #region Internal Member

        private decimal msgId;
        private DateTime msgTimeStamp;
        private string original;
        private string source;
        private int sqlCode;
        private string sqlErrorMessage;
        private string originalUser;

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

        public string Original
        {
            get { return original; }
            set { original = value; }
        }

        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        public int SqlCode
        {
            get { return sqlCode; }
            set { sqlCode = value; }
        }

        public string SqlErrorMessage
        {
            get { return sqlErrorMessage; }
            set { sqlErrorMessage = value; }
        }


        public string OriginalUser
        {
            get { return originalUser; }
            set { originalUser = value; }
        }

        #endregion

        #region Methods

        public DBLogInfo() { }

        public DBLogInfo(decimal msgId,DateTime msgTimeStamp,string original,string source,int sqlCode,string sqlErrorMessage,string originalUser) 
        {
            this.msgId = msgId;
            this.msgTimeStamp = msgTimeStamp;
            this.original = original;
            this.source = source;
            this.sqlCode = sqlCode;
            this.sqlErrorMessage = sqlErrorMessage;
            this.originalUser = originalUser;
        }

        #endregion
        

    }
}
