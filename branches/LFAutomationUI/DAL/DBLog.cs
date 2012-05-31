using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class DBLog:IDBLog
    {
        #region SQL and PARAM

        private const string SQL_INSERT_DBLOG = @"INSERT INTO TB_DB_LOG(ORIGINAL,SOURCES,SQL_CODE,SQL_ERROR_MSG,ORIGINAL_USER) VALUES(:ORIGINAL,:SOURCES,:SQL_CODE,:SQL_ERROR_MSG,:ORIGINAL_USER)";
        private const string SQL_SELECT_ALL_DBLOG = @" SELECT MSG_ID,MSG_TIME_STAMP,ORIGINAL,SOURCES,SQL_CODE,SQL_ERROR_MSG,ORIGINAL_USER FROM TB_DB_LOG";


        private const string PARAM_ORIGINAL = ":ORIGINAL";
        private const string PARAM_SOURCES = ":SOURCES";
        private const string PARAM_SQL_CODE = ":SQL_CODE";
        private const string PARAM_SQL_ERROR_MSG = ":SQL_ERROR_MSG";
        private const string PARAM_SQL_ORIGINAL_USER = ":ORIGINAL_USER";
        
        #endregion

        /// <summary>
        /// 插入数据库日志信息
        /// </summary>
        /// <param name="dbLog">日志信息</param>
        public void InsertDBLogInfo(DBLogInfo dbLog)
        {
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter(PARAM_ORIGINAL, OracleType.VarChar);
            param[0].Value = dbLog.Original;
            param[1] = new OracleParameter(PARAM_SOURCES, OracleType.VarChar);
            param[1].Value = dbLog.Source;
            param[2] = new OracleParameter(PARAM_SQL_CODE, OracleType.Number);
            param[2].Value = dbLog.SqlCode;
            param[3] = new OracleParameter(PARAM_SQL_ERROR_MSG, OracleType.VarChar);
            param[3].Value = dbLog.SqlErrorMessage;
            param[4] = new OracleParameter(PARAM_SQL_ORIGINAL_USER, OracleType.VarChar);
            param[4].Value = dbLog.OriginalUser;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_INSERT_DBLOG,param);
        }



        /// <summary>
        /// 获取所有日志信息
        /// </summary>
        /// <returns>所有日志信息</returns>
        public IList<DBLogInfo> GetAllDBLog()
        {
            IList<DBLogInfo> dbLogList = new List<DBLogInfo>();

            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_DBLOG,null))
            {
                while (odr.Read())
                {
                    decimal msgId = Convert.ToDecimal(odr["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(odr["MSG_TIME_STAMP"]);
                    string original = odr["ORIGINAL"].ToString();
                    string source = odr["SOURCES"].ToString();
                    int sqlCode = Convert.ToInt16(odr["SQL_CODE"]);
                    string sqlErrorMessage = odr["SQL_ERROR_MSG"].ToString();
                    string originalUser;
                    try
                    {
                        originalUser = odr["ORIGINAL_USER"].ToString();
                    }
                    catch
                    {
                        originalUser = null;
                    }
                    DBLogInfo dbLog = new DBLogInfo(msgId, msgTimeStamp, original, source, sqlCode, sqlErrorMessage, originalUser);
                    dbLogList.Add(dbLog);
                }
            }
            return dbLogList;
        }
    }
}
