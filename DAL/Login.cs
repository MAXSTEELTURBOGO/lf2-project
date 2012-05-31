using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class Login : ILogin
    {
        #region SQL AND PARAM
        private const string SQL_SELECT_ALL_LOGIN_INFO = @"SELECT MSG_ID,
                                                           MSG_TIME_STAMP,
                                                           USER_ID,
                                                           USER_NAME,
                                                           LOGIN_TIME,
                                                           LOGOFF_TIME,
                                                           CLASS_ID,
                                                           USER_PASSWORD,
                                                           USER_CREATED_DATE,
                                                           USER_LAST_MODIFIED_DATE      
                                                     FROM V_SYS_LOGIN_DETAIL_INFO
                                                     ORDER BY MSG_TIME_STAMP DESC ";
        private const string SQL_SELECT_LOGIN_INFO_BY_USER_ID = @"SELECT MSG_ID,
                                                               MSG_TIME_STAMP,
                                                               USER_ID,
                                                               USER_NAME,
                                                               LOGIN_TIME,
                                                               LOGOFF_TIME,
                                                               CLASS_ID,
                                                               USER_PASSWORD,
                                                               USER_CREATED_DATE,
                                                               USER_LAST_MODIFIED_DATE      
                                                         FROM V_SYS_LOGIN_DETAIL_INFO
                                                         WHERE USER_ID=:USER_ID 
                                                         ORDER BY MSG_TIME_STAMP DESC ";
        private const string SQL_SELECT_LOGIN_INFO_BY_START_END_TIME = @"SELECT MSG_ID,
                                                                       MSG_TIME_STAMP,
                                                                       USER_ID,
                                                                       USER_NAME,
                                                                       LOGIN_TIME,
                                                                       LOGOFF_TIME,
                                                                       CLASS_ID,
                                                                       USER_PASSWORD,
                                                                       USER_CREATED_DATE,
                                                                       USER_LAST_MODIFIED_DATE      
                                                                 FROM V_SYS_LOGIN_DETAIL_INFO
                                                                 WHERE LOGIN_TIME BETWEEN :START_TIME  AND :END_TIME                                                      
                                                                 ORDER BY MSG_TIME_STAMP DESC ";

        private const string SQL_INSERT_LOGIN_INFO = @"INSERT INTO TB_SYS_LOGIN_INFO(LOGIN_USER) VALUES(:USER_NAME)";

        private const string SQL_UPDATE_LOGIN_INFO = @"UPDATE TB_SYS_LOGIN_INFO T
                                                       SET T.LOGOFF_TIME = SYSDATE
                                                     WHERE T.LOGIN_USER = :USER_NAME
                                                       AND NOT EXISTS (SELECT *
                                                              FROM TB_SYS_LOGIN_INFO T1
                                                             WHERE T1.LOGIN_USER = T.LOGIN_USER
                                                               AND T1.LOGIN_TIME > T.LOGIN_TIME)";

        private const string PARAM_USER_ID = ":USER_ID";
        private const string PARAM_USRE_NAME = ":USER_NAME";
        private const string PARAM_START_TIME = ":START_TIME";
        private const string PARAM_END_TIME = ":END_TIME";
        #endregion


        /// <summary>
        /// 获取所有登录信息
        /// </summary>
        /// <returns>所有登录信息</returns>
        public IList<LoginInfo> GetAllLoginInfo()
        {
            IList<LoginInfo> loginList = new List<LoginInfo>();

            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_LOGIN_INFO,null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);

                foreach (var item in dt.AsEnumerable())
                {
                    decimal msgId = Convert.ToDecimal(item["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(item["MSG_TIME_STAMP"]);
                    int userId = Convert.ToInt16(item["USER_ID"]);
                    string userName = item["USER_NAME"].ToString();
                    DateTime loginTime = Convert.ToDateTime(item["LOGIN_TIME"]);
                    DateTime logoffTime = Convert.ToDateTime(item["LOGOFF_TIME"]);
                    string classId = item["CLASS_ID"] == DBNull.Value ? null : item["CLASS_ID"].ToString();
                    string userPassword = item["USER_PASSWORD"].ToString();
                    DateTime userCreatedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    DateTime userLastModifiedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    UserInfo user = new UserInfo(userId, userName, userPassword, classId, userCreatedDate, userLastModifiedDate);
                    LoginInfo loginInfo = new LoginInfo(msgId, msgTimeStamp, user, loginTime, logoffTime);
                    loginList.Add(loginInfo);
                }
            }
            return loginList;
        }

        /// <summary>
        /// 根据用户获取该用户的登录信息
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>指定用户的登录信息</returns>
        public IList<LoginInfo> GetLoginInfo(UserInfo user)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USER_ID,OracleType.Number);
            param[0].Value = user.UserId;

            IList<LoginInfo> loginList = new List<LoginInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LOGIN_INFO_BY_USER_ID, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);

                foreach (var item in dt.AsEnumerable())
                {
                    decimal msgId = Convert.ToDecimal(item["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(item["MSG_TIME_STAMP"]);
                    int userId = Convert.ToInt16(item["USER_ID"]);
                    string userName = item["USER_NAME"].ToString();
                    DateTime loginTime = Convert.ToDateTime(item["LOGIN_TIME"]);
                    DateTime logoffTime = Convert.ToDateTime(item["LOGOFF_TIME"]);
                    string classId = item["CLASS_ID"] == DBNull.Value ? null : item["CLASS_ID"].ToString();
                    string userPassword = item["USER_PASSWORD"].ToString();
                    DateTime userCreatedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    DateTime userLastModifiedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    user = new UserInfo(userId, userName, userPassword, classId, userCreatedDate, userLastModifiedDate);
                    LoginInfo loginInfo = new LoginInfo(msgId, msgTimeStamp, user, loginTime, logoffTime);
                    loginList.Add(loginInfo);
                }
            }
            return loginList;
        }

        /// <summary>
        /// 获取某时间段的所有登录信息
        /// </summary>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns>指定时间段的登录信息</returns>
        public IList<LoginInfo> GetLoginInfo(DateTime startTime, DateTime endTime)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_START_TIME, OracleType.DateTime);
            param[0].Value = startTime;
            param[1] = new OracleParameter(PARAM_END_TIME, OracleType.DateTime);
            param[1].Value = endTime;

            IList<LoginInfo> loginList = new List<LoginInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_LOGIN_INFO_BY_START_END_TIME, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);

                foreach (var item in dt.AsEnumerable())
                {
                    decimal msgId = Convert.ToDecimal(item["MSG_ID"]);
                    DateTime msgTimeStamp = Convert.ToDateTime(item["MSG_TIME_STAMP"]);
                    int userId = Convert.ToInt16(item["USER_ID"]);
                    string userName = item["USER_NAME"].ToString();
                    DateTime loginTime = Convert.ToDateTime(item["LOGIN_TIME"]);
                    DateTime logoffTime = Convert.ToDateTime(item["LOGOFF_TIME"]);
                    string classId = item["CLASS_ID"] == DBNull.Value ? null : item["CLASS_ID"].ToString();
                    string userPassword = item["USER_PASSWORD"].ToString();
                    DateTime userCreatedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    DateTime userLastModifiedDate = Convert.ToDateTime(item["USER_CREATED_DATE"]);
                    UserInfo user = new UserInfo(userId, userName, userPassword, classId, userCreatedDate, userLastModifiedDate);
                    LoginInfo loginInfo = new LoginInfo(msgId, msgTimeStamp, user, loginTime, logoffTime);
                    loginList.Add(loginInfo);
                }
            }
            return loginList;
        }


        /// <summary>
        /// 插入登录信息
        /// </summary>
        /// <param name="user">登录信息</param>
        public void InsertLoginInfo(LoginInfo login)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USRE_NAME,OracleType.VarChar);
            param[0].Value = login.User.UserName;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_LOGIN_INFO, param);

        }

        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="login">登录信息</param>
        public void UpdateLoginInfo(LoginInfo login)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USRE_NAME, OracleType.VarChar);
            param[0].Value = login.User.UserName;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_LOGIN_INFO, param);

        }
    }
}
