using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.DAL
{
    public class User : IUser
    {
        #region SQL AND PARAM
        private string SQL_SELECT_USER_BY_NAME_AND_PASSWORD = @"SELECT USER_ID,
                                                               USER_NAME,
                                                               USER_PASSWORD,
                                                               CLASS_ID,
                                                               USER_CREATED_DATE,
                                                               USER_LAST_MODIFIED_DATE,
                                                               ROLE_ID,
                                                               ROLE_NAME,
                                                               ROLE_CREATED_DATE,
                                                               ROLE_LAST_MODIFIED_DATE,
                                                               PRIVILEGE_ID,
                                                               PRIVILEGE_NAME,
                                                               PARENT_PRIVI_ID,
                                                               PRIVI_CREATED_DATE,
                                                               PRIVI_LAST_MODIFIED_DATE,
                                                               PRIVI_DESC
                                                            FROM V_SYS_USER_DETAIL_INFO
                                                            WHERE USER_NAME = :USER_NAME
                                                            AND USER_PASSWORD = :USER_PASSWORD";

        private string SQL_SELECT_USER_BY_NAME = @"SELECT USER_ID,
                                                   USER_NAME,
                                                   USER_PASSWORD,
                                                   CLASS_ID,
                                                   USER_CREATED_DATE,
                                                   USER_LAST_MODIFIED_DATE,
                                                   ROLE_ID,
                                                   ROLE_NAME,
                                                   ROLE_CREATED_DATE,
                                                   ROLE_LAST_MODIFIED_DATE,
                                                   PRIVILEGE_ID,
                                                   PRIVILEGE_NAME,
                                                   PARENT_PRIVI_ID,
                                                   PRIVI_CREATED_DATE,
                                                   PRIVI_LAST_MODIFIED_DATE,
                                                   PRIVI_DESC
                                                FROM V_SYS_USER_DETAIL_INFO
                                                WHERE USER_NAME = :USER_NAME";

        private string SQL_SELECT_ALL_USERS = @"SELECT USER_ID,
                                                   USER_NAME,
                                                   USER_PASSWORD,
                                                   CLASS_ID,
                                                   USER_CREATED_DATE,
                                                   USER_LAST_MODIFIED_DATE,
                                                   ROLE_ID,
                                                   ROLE_NAME,
                                                   ROLE_CREATED_DATE,
                                                   ROLE_LAST_MODIFIED_DATE,
                                                   PRIVILEGE_ID,
                                                   PRIVILEGE_NAME,
                                                   PARENT_PRIVI_ID,
                                                   PRIVI_CREATED_DATE,
                                                   PRIVI_LAST_MODIFIED_DATE,
                                                   PRIVI_DESC
                                                FROM V_SYS_USER_DETAIL_INFO";

        private const string SQL_INSERT_USER = "INSERT INTO TB_SYS_USER_INFO(USER_NAME,USER_PASSWORD,CLASS_ID) VALUES(:USER_NAME,:USER_PASSWORD,:CLASS_ID)";

        private const string SQL_UPDATE_USER = "UPDATE TB_SYS_USER_INFO SET USER_PASSWORD=:USER_PASSWORD ,CLASS_ID=:CLASS_ID WHERE USER_ID=:USER_ID";

        private const string SQL_DELETE_USER = "DELETE FROM TB_SYS_USER_INFO WHERE USER_ID=:USER_ID";

        private const string SQL_INSERT_USER_ROLE_INFO = "INSERT INTO TB_SYS_USER_ROLE_INFO(USER_ID,ROLE_ID) VALUES(:USER_ID{0},:ROLE_ID{0})";
        private const string SQL_DELETE_USER_ROLE_INFO = "DELETE FROM TB_SYS_USER_ROLE_INFO WHERE USER_ID=:USER_ID";

        private const string PARAM_USER_ID = ":USER_ID";
        private const string PARAM_USER_NAME = ":USER_NAME";
        private const string PARAM_USER_PASSWORD = ":USER_PASSWORD";
        private const string PARAM_CLASS_ID = ":CLASS_ID";
        private const string PARAM_ROLE_ID = ":ROLE_ID";

        #endregion

        #region IUser 成员

        /// <summary>
        /// 根据用户名和密码获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns>用户信息</returns>
        public UserInfo GetUserInfo(string userName, string userPassword)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_USER_NAME, OracleType.VarChar);
            param[0].Value = userName;
            param[1] = new OracleParameter(PARAM_USER_PASSWORD, OracleType.VarChar);
            param[1].Value = Encryption.Encrypt(userPassword,userName);


            UserInfo user = null;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_USER_BY_NAME_AND_PASSWORD, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumUser = (from i in dt.AsEnumerable()
                                    select new
                                    {
                                        UserId = Convert.ToInt16(i["USER_ID"]),
                                        UserName = i["USER_NAME"].ToString(),
                                        UserPassword = i["USER_PASSWORD"].ToString(),
                                        ClassID = i["CLASS_ID"].ToString(),
                                        CreatedDate = Convert.ToDateTime(i["USER_CREATED_DATE"]),
                                        LastModifiedDate = Convert.ToDateTime(i["USER_LAST_MODIFIED_DATE"])
                                    }).Distinct();

                    var item = enumUser.First();
                    user = new UserInfo(item.UserId, item.UserName, item.ClassID, item.CreatedDate, item.LastModifiedDate);
                    user.EncryptedPassword = item.UserPassword;
                    IList<RoleInfo> roles = new List<RoleInfo>();

                    try
                    {
                        var enumRole = (from i in dt.AsEnumerable()
                                        select new
                                        {
                                            RoleId = Convert.ToInt16(i["ROLE_ID"]),
                                            RoleName = i["ROLE_NAME"].ToString(),
                                            CreatedDate = Convert.ToDateTime(i["ROLE_CREATED_DATE"]),
                                            LastModifiedDate = Convert.ToDateTime(i["ROLE_LAST_MODIFIED_DATE"])
                                        }).Distinct();

                        foreach (var i in enumRole)
                        {
                            RoleInfo role = new RoleInfo(i.RoleId, i.RoleName, i.CreatedDate, i.LastModifiedDate);
                            roles.Add(role);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        user.Roles = roles;
                    }
                    
                    

                    IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                    try
                    {
                        if (roles.Count > 0)
                        {
                            var enumPrivi = (from i in dt.AsEnumerable()
                                             select new
                                             {
                                                 PrivilegeId = Convert.ToInt16(i["PRIVILEGE_ID"]),
                                                 PrivilegeName = i["PRIVILEGE_NAME"].ToString(),
                                                 ParentPrivilegeId = Convert.ToInt16(i["PARENT_PRIVI_ID"] == DBNull.Value ? 0 : i["PARENT_PRIVI_ID"]),
                                                 CreatedDate = Convert.ToDateTime(i["PRIVI_CREATED_DATE"]),
                                                 LastModifiedDate = Convert.ToDateTime(i["PRIVI_LAST_MODIFIED_DATE"]),
                                                 PriviDescription = Convert.ToInt16(i["PRIVI_DESC"])
                                             }).Distinct();
                            foreach (var i in enumPrivi)
                            {
                                PrivilegeInfo privilege = new PrivilegeInfo(i.PrivilegeId, i.PrivilegeName, i.ParentPrivilegeId, i.CreatedDate, i.LastModifiedDate, i.PriviDescription);
                                privileges.Add(privilege);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        user.Privileges = privileges;
                    } 
                }
            }
            return user;
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户信息</returns>
        public UserInfo GetUserInfo(string userName)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USER_NAME, OracleType.VarChar);
            param[0].Value = userName;

            UserInfo user = null;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_USER_BY_NAME, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumUser = (from i in dt.AsEnumerable()
                                    select new
                                    {
                                        UserId = Convert.ToInt16(i["USER_ID"]),
                                        UserName = i["USER_NAME"].ToString(),
                                        UserPassword = i["USER_PASSWORD"].ToString(),
                                        ClassID = i["CLASS_ID"].ToString(),
                                        CreatedDate = Convert.ToDateTime(i["USER_CREATED_DATE"]),
                                        LastModifiedDate = Convert.ToDateTime(i["USER_LAST_MODIFIED_DATE"])
                                    }).Distinct();

                    var item = enumUser.First();
                    user = new UserInfo(item.UserId, item.UserName, item.ClassID, item.CreatedDate, item.LastModifiedDate);
                    user.EncryptedPassword = item.UserPassword;

                    IList<RoleInfo> roles = new List<RoleInfo>();
                    try
                    {
                        var enumRole = (from i in dt.AsEnumerable()
                                        select new
                                        {
                                            RoleId = Convert.ToInt16(i["ROLE_ID"]),
                                            RoleName = i["ROLE_NAME"].ToString(),
                                            CreatedDate = Convert.ToDateTime(i["ROLE_CREATED_DATE"]),
                                            LastModifiedDate = Convert.ToDateTime(i["ROLE_LAST_MODIFIED_DATE"])
                                        }).Distinct();

                        foreach (var i in enumRole)
                        {
                            RoleInfo role = new RoleInfo(i.RoleId, i.RoleName, i.CreatedDate, i.LastModifiedDate);
                            roles.Add(role);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        user.Roles = roles;
                    }

                    IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                    try
                    {
                        if (roles.Count > 0)
                        {
                            var enumPrivi = (from i in dt.AsEnumerable()
                                             select new
                                             {
                                                 PrivilegeId = Convert.ToInt16(i["PRIVILEGE_ID"]),
                                                 PrivilegeName = i["PRIVILEGE_NAME"].ToString(),
                                                 ParentPrivilegeId = Convert.ToInt16(i["PARENT_PRIVI_ID"] == DBNull.Value ? 0 : i["PARENT_PRIVI_ID"]),
                                                 CreatedDate = Convert.ToDateTime(i["PRIVI_CREATED_DATE"]),
                                                 LastModifiedDate = Convert.ToDateTime(i["PRIVI_LAST_MODIFIED_DATE"]),
                                                 PriviDescription = Convert.ToInt16(i["PRIVI_DESC"])
                                             }).Distinct();
                            foreach (var i in enumPrivi)
                            {
                                PrivilegeInfo privilege = new PrivilegeInfo(i.PrivilegeId, i.PrivilegeName, i.ParentPrivilegeId, i.CreatedDate, i.LastModifiedDate, i.PriviDescription);
                                privileges.Add(privilege);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        user.Privileges = privileges;
                    }          
                }
            }
            return user;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns>所有用户信息</returns>
        public IList<UserInfo> GetAllUsers()
        {
            IList<UserInfo> users = new List<UserInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_USERS, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumUser = (from i in dt.AsEnumerable()
                                    select new
                                    {
                                        UserId = Convert.ToInt16(i["USER_ID"]),
                                        UserName = i["USER_NAME"].ToString(),
                                        UserPassword = i["USER_PASSWORD"].ToString(),
                                        ClassID = i["CLASS_ID"].ToString(),
                                        CreatedDate = Convert.ToDateTime(i["USER_CREATED_DATE"]),
                                        LastModifiedDate = Convert.ToDateTime(i["USER_LAST_MODIFIED_DATE"])
                                    }).Distinct();
                    foreach (var i in enumUser)
                    {
                        UserInfo user = new UserInfo(i.UserId, i.UserName, i.ClassID, i.CreatedDate, i.LastModifiedDate);
                        user.EncryptedPassword = i.UserPassword; 
                        users.Add(user);
                    }

                    for (int i = 0; i < users.Count; i++)
                    {
                        IList<RoleInfo> roles = new List<RoleInfo>();
                        try
                        {
                            var enumRole = (from item in dt.AsEnumerable()
                                            where Convert.ToInt16(item["USER_ID"]) == users[i].UserId
                                            select new
                                            {
                                                RoleId = Convert.ToInt16(item["ROLE_ID"]),
                                                RoleName = item["ROLE_NAME"].ToString(),
                                                CreatedDate = Convert.ToDateTime(item["ROLE_CREATED_DATE"]),
                                                LastModifiedDate = Convert.ToDateTime(item["ROLE_LAST_MODIFIED_DATE"])
                                            }).Distinct();

                            foreach (var item in enumRole)
                            {
                                RoleInfo role = new RoleInfo(item.RoleId, item.RoleName, item.CreatedDate, item.LastModifiedDate);
                                roles.Add(role);
                            }
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            users[i].Roles = roles;
                        }            

                        IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                        try
                        {
                            if (roles.Count > 0)
                            {
                                var enumPrivi = (from item in dt.AsEnumerable()
                                                 where Convert.ToInt16(item["USER_ID"]) == users[i].UserId
                                                 select new
                                                 {
                                                     PrivilegeId = Convert.ToInt16(item["PRIVILEGE_ID"]),
                                                     PrivilegeName = item["PRIVILEGE_NAME"].ToString(),
                                                     ParentPrivilegeId = Convert.ToInt16(item["PARENT_PRIVI_ID"] == DBNull.Value ? 0 : item["PARENT_PRIVI_ID"]),
                                                     CreatedDate = Convert.ToDateTime(item["PRIVI_CREATED_DATE"]),
                                                     LastModifiedDate = Convert.ToDateTime(item["PRIVI_LAST_MODIFIED_DATE"]),
                                                     PriviDescription = Convert.ToInt16(item["PRIVI_DESC"])
                                                 }).Distinct();
                                foreach (var item in enumPrivi)
                                {
                                    PrivilegeInfo privilege = new PrivilegeInfo(item.PrivilegeId, item.PrivilegeName, item.ParentPrivilegeId, item.CreatedDate, item.LastModifiedDate, item.PriviDescription);
                                    privileges.Add(privilege);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            users[i].Privileges = privileges;
                        }     
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <param name="user">要插入的用户信息</param>
        public void InsertUserInfo(UserInfo user)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_USER_NAME, OracleType.VarChar);
            param[0].Value = user.UserName;
            param[1] = new OracleParameter(PARAM_USER_PASSWORD, OracleType.VarChar);
            param[1].Value = user.EncryptedPassword;
            param[2] = new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[2].Value = user.ClassId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_USER, param);
        }

        /// <summary>
        /// 更新指定用户信息
        /// </summary>
        /// <param name="user">用户</param>
        public void UpdateUserInfo(UserInfo user)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_USER_PASSWORD, OracleType.VarChar);
            param[0].Value = user.EncryptedPassword;
            param[1] = new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[1].Value = user.ClassId;
            param[2] = new OracleParameter(PARAM_USER_ID, OracleType.Number);
            param[2].Value = user.UserId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_USER, param);

        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="user">用户</param>
        public void DeleteUserInfo(UserInfo user)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USER_ID, OracleType.Number);
            param[0].Value = user.UserId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_USER, param);
        }

        /// <summary>
        /// 删除指定用户的角色信息
        /// </summary>
        /// <param name="user">用户</param>
        public void DeleteUserRoleInfo(UserInfo user)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_USER_ID, OracleType.Number);
            param[0].Value = user.UserId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_USER_ROLE_INFO, param);
        }

        /// <summary>
        /// 插入用户的角色信息
        /// </summary>
        /// <param name="user">用户</param>
        public void InsertUserRoleInfo(UserInfo user)
        {
            int numberOfParameters = 2 * user.Roles.Count;
            if (numberOfParameters > 0)
            {
                OracleParameter[] param = new OracleParameter[numberOfParameters];

                StringBuilder finalSQLQuery = new StringBuilder("BEGIN ");
                int index = 0;
                int i = 1;
                int userId = user.UserId;
                foreach (RoleInfo role in user.Roles)
                {
                    param[index] = new OracleParameter(PARAM_USER_ID + i, OracleType.Number);
                    param[index++].Value = userId;
                    param[index] = new OracleParameter(PARAM_ROLE_ID + i, OracleType.Number);
                    param[index++].Value = role.RoleID;
                    finalSQLQuery.Append(string.Format(SQL_INSERT_USER_ROLE_INFO, i));
                    finalSQLQuery.Append("; ");
                    i++;
                }
                finalSQLQuery.Append(" END; ");
                OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, finalSQLQuery.ToString(), param);
            }
        }

        #endregion
    }
}
