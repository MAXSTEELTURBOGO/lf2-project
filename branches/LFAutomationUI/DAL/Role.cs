using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

using LFAutomationUI.Model;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;

namespace LFAutomationUI.DAL
{
    public class Role : IRole
    {
        #region SQL AND PARAM
        private const string SQL_SELECT_ALL_ROLES = @"SELECT ROLE_ID,
                                                           ROLE_NAME,
                                                           ROLE_CREATED_DATE,
                                                           ROLE_LAST_MODIFIED_DATE,
                                                           PRIVILEGE_ID,
                                                           PRIVILEGE_NAME,
                                                           PRIVI_DESC,
                                                           PRIVI_CREATED_DATE,
                                                           PRIVI_LAST_MODIFIED_DATE,
                                                           PARENT_PRIVI_ID
                                                      FROM V_SYS_ROLE_DETAIL_INFO V
                                                      ORDER BY ROLE_ID ASC";

        private const string SQL_SELECT_ROLE_INFO_BY_ROLE_ID = @"SELECT ROLE_ID,
                                                           ROLE_NAME,
                                                           ROLE_CREATED_DATE,
                                                           ROLE_LAST_MODIFIED_DATE,
                                                           PRIVILEGE_ID,
                                                           PRIVILEGE_NAME,
                                                           PRIVI_DESC,
                                                           PRIVI_CREATED_DATE,
                                                           PRIVI_LAST_MODIFIED_DATE,
                                                           PARENT_PRIVI_ID
                                                      FROM V_SYS_ROLE_DETAIL_INFO V WHERE ROLE_ID=:ROLE_ID
                                                      ORDER BY ROLE_ID ASC ";

        private const string SQL_SELECT_ROLE_INFO_BY_ROLE_NAME = @"SELECT ROLE_ID,
                                                           ROLE_NAME,
                                                           ROLE_CREATED_DATE,
                                                           ROLE_LAST_MODIFIED_DATE,
                                                           PRIVILEGE_ID,
                                                           PRIVILEGE_NAME,
                                                           PRIVI_DESC,
                                                           PRIVI_CREATED_DATE,
                                                           PRIVI_LAST_MODIFIED_DATE,
                                                           PARENT_PRIVI_ID
                                                      FROM V_SYS_ROLE_DETAIL_INFO V WHERE ROLE_NAME=:ROLE_NAME
                                                      ORDER BY ROLE_ID ASC ";

        private const string SQL_DELETE_ROLE_PRIVILEGE_BY_ROLE_ID = "DELETE FROM TB_SYS_ROLE_PRIVI_INFO WHERE ROLE_ID=:ROLE_ID";

        private const string SQL_UPDATE_ROLE_INFO = @"UPDATE TB_SYS_ROLE_INFO SET ROLE_NAME=:ROLE_NAME WHERE ROLE_ID=:ROLE_ID";
        private const string SQL_INSERT_ROLE_INFO = @"INSERT INTO TB_SYS_ROLE_INFO(ROLE_NAME) VALUES(:ROLE_NAME)";
        private const string SQL_DELETE_ROLE_INFO = @"DELETE FROM TB_SYS_ROLE_INFO WHERE ROLE_ID = :ROLE_ID";

        private const string SQL_INSERT_ROLE_PRIVILEGE = @"INSERT INTO TB_SYS_ROLE_PRIVI_INFO(ROLE_ID,PRIVILEGE_ID,PRIVI_DESC)
                                                           VALUES(:ROLE_ID{0},:PRIVILEGE_ID{0},:PRIVI_DESC{0})";

        private const string PARAM_ROLE_ID = ":ROLE_ID";
        private const string PARAM_ROLE_NAME = ":ROLE_NAME";
        private const string PARAM_PRIVILEGE_ID = ":PRIVILEGE_ID";
        private const string PARAM_PRIVI_DESC = ":PRIVI_DESC";
        #endregion

        #region IRole 成员

        public IList<RoleInfo> GetAllRoles()
        {
            IList<RoleInfo> roles = new List<RoleInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_ROLES, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);

                if (dt.Rows.Count > 0)
                {
                    var enumRole = from i in dt.AsEnumerable()
                                   select new
                                   {
                                       RoleId = Convert.ToInt16(i[0]),
                                       RoleName = i[1].ToString(),
                                       RoleCreatedDate = Convert.ToDateTime(i[2]),
                                       RoleLastModifiedDate = Convert.ToDateTime(i[3])
                                   };
                    foreach (var item in enumRole.Distinct())
                    {
                        RoleInfo role = new RoleInfo(item.RoleId, item.RoleName, item.RoleCreatedDate, item.RoleLastModifiedDate);
                        roles.Add(role);
                    }

                    for (int j = 0; j < roles.Count; j++)
                    {
                        IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                        try
                        {
                            var enumPrivileges = from i in dt.AsEnumerable()
                                                 where Convert.ToInt16(i[0]) == roles[j].RoleID
                                                 select new
                                                 {
                                                     PrivilegeId = Convert.ToInt16(i[4]),
                                                     PrivilegeName = i[5].ToString(),
                                                     PrivilegeDescription = Convert.ToInt16(i[6]),
                                                     PrivilegeCreatedDate = Convert.ToDateTime(i[7]),
                                                     PrivilegeLastModifiedDate = Convert.ToDateTime(i[8]),
                                                     ParentPrivilegeId = Convert.ToInt16(i[9] == DBNull.Value ? 0 : i[9])
                                                 };

                            foreach (var item in enumPrivileges)
                            {
                                PrivilegeInfo privilege = new PrivilegeInfo(item.PrivilegeId, item.PrivilegeName, item.ParentPrivilegeId, item.PrivilegeCreatedDate, item.PrivilegeLastModifiedDate, item.PrivilegeDescription);
                                privileges.Add(privilege);
                            }
                            roles[j].Privileges = privileges;
                        }
                        catch (Exception)
                        {
                            roles[j].Privileges = null;
                        }
                    }
                }
                
            }
            return roles;
        }

        /// <summary>
        /// 删除指定角色的所有权限信息
        /// </summary>
        /// <param name="role">角色</param>
        public void DeleteRolePrivilegeInfo(RoleInfo role)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_ROLE_ID, OracleType.Number);
            param[0].Value = role.RoleID;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_ROLE_PRIVILEGE_BY_ROLE_ID, param);

        }

        /// <summary>
        /// 插入指定角色的所有权限信息
        /// </summary>
        /// <param name="role">角色</param>
        public void InsertRolePrivilegeInfo(RoleInfo role)
        {
            int numberOfParameters=3*role.Privileges.Count;
            if (numberOfParameters > 0)
            {
                OracleParameter[] param = new OracleParameter[numberOfParameters];

                StringBuilder finalSQLQuery = new StringBuilder("BEGIN ");
                int index = 0;
                int i = 1;
                int roleId=role.RoleID;
                foreach (PrivilegeInfo privi in role.Privileges)
                {
                    param[index] = new OracleParameter(PARAM_ROLE_ID+i, OracleType.Number);
                    param[index++].Value = role.RoleID;
                    param[index] = new OracleParameter(PARAM_PRIVILEGE_ID+i, OracleType.Number);
                    param[index++].Value = privi.PrivilegeId;
                    param[index] = new OracleParameter(PARAM_PRIVI_DESC+i, OracleType.Number);
                    param[index++].Value = privi.PriviDescription;
                    finalSQLQuery.Append(string.Format(SQL_INSERT_ROLE_PRIVILEGE,i));
                    finalSQLQuery.Append(";  ");
                    i++;
                }

                finalSQLQuery.Append(" END; ");

                OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, finalSQLQuery.ToString(), param);
            }
        }

        /// <summary>
        /// 根据角色号获取角色信息
        /// </summary>
        /// <param name="roleId">角色号</param>
        /// <returns>角色信息</returns>
        public RoleInfo GetRoleInfoByRoleId(int roleId)
        {
            
            RoleInfo role=null;

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_ROLE_ID, OracleType.Number);
            param[0].Value = roleId;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ROLE_INFO_BY_ROLE_ID, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0 )
                {
                    var enumRole = from i in dt.AsEnumerable()
                                   select new
                                   {
                                       RoleId = Convert.ToInt16(i[0]),
                                       RoleName = i[1].ToString(),
                                       RoleCreatedDate = Convert.ToDateTime(i[2]),
                                       RoleLastModifiedDate = Convert.ToDateTime(i[3])
                                   };
                    var item = enumRole.Distinct().First();
                    role = new RoleInfo(item.RoleId, item.RoleName, item.RoleCreatedDate, item.RoleLastModifiedDate);


                    IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                    try
                    {
                        var enumPrivileges = from i in dt.AsEnumerable()
                                             where Convert.ToInt16(i[0]) == role.RoleID
                                             select new
                                             {
                                                 PrivilegeId = Convert.ToInt16(i[4]),
                                                 PrivilegeName = i[5].ToString(),
                                                 PrivilegeDescription = Convert.ToInt16(i[6]),
                                                 PrivilegeCreatedDate = Convert.ToDateTime(i[7]),
                                                 PrivilegeLastModifiedDate = Convert.ToDateTime(i[8]),
                                                 ParentPrivilegeId = Convert.ToInt16(i[9] == DBNull.Value ? 0 : i[9])
                                             };

                        foreach (var privi in enumPrivileges)
                        {
                            PrivilegeInfo privilege = new PrivilegeInfo(privi.PrivilegeId, privi.PrivilegeName, privi.ParentPrivilegeId, privi.PrivilegeCreatedDate, privi.PrivilegeLastModifiedDate, privi.PrivilegeDescription);
                            privileges.Add(privilege);
                        }
                        role.Privileges = privileges;
                    }
                    catch (Exception)
                    {
                        role.Privileges = null;
                    }
                }  
            }
            return role;
        }

        /// <summary>
        /// 根据角色名称获取角色信息
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns>角色信息</returns>
        public RoleInfo GetRoleInfoByRoleName(string roleName)
        {

            RoleInfo role = null;

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_ROLE_NAME, OracleType.VarChar);
            param[0].Value = roleName;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ROLE_INFO_BY_ROLE_NAME, param))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    var enumRole = from i in dt.AsEnumerable()
                                   select new
                                   {
                                       RoleId = Convert.ToInt16(i[0]),
                                       RoleName = i[1].ToString(),
                                       RoleCreatedDate = Convert.ToDateTime(i[2]),
                                       RoleLastModifiedDate = Convert.ToDateTime(i[3])
                                   };
                    var item = enumRole.Distinct().First();
                    role = new RoleInfo(item.RoleId, item.RoleName, item.RoleCreatedDate, item.RoleLastModifiedDate);


                    IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();
                    try
                    {
                        var enumPrivileges = from i in dt.AsEnumerable()
                                             where Convert.ToInt16(i[0]) == role.RoleID
                                             select new
                                             {
                                                 PrivilegeId = Convert.ToInt16(i[4]),
                                                 PrivilegeName = i[5].ToString(),
                                                 PrivilegeDescription = Convert.ToInt16(i[6]),
                                                 PrivilegeCreatedDate = Convert.ToDateTime(i[7]),
                                                 PrivilegeLastModifiedDate = Convert.ToDateTime(i[8]),
                                                 ParentPrivilegeId = Convert.ToInt16(i[9] == DBNull.Value ? 0 : i[9])
                                             };

                        foreach (var privi in enumPrivileges)
                        {
                            PrivilegeInfo privilege = new PrivilegeInfo(privi.PrivilegeId, privi.PrivilegeName, privi.ParentPrivilegeId, privi.PrivilegeCreatedDate, privi.PrivilegeLastModifiedDate, privi.PrivilegeDescription);
                            privileges.Add(privilege);
                        }
                        role.Privileges = privileges;
                    }
                    catch (Exception)
                    {
                        role.Privileges = null;
                    }
                }
            }
            return role;
        }

        /// <summary>
        /// 更新指定角色的信息
        /// </summary>
        /// <param name="role">角色</param>
        public void UpdateRoleInfo(RoleInfo role)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter(PARAM_ROLE_NAME, OracleType.VarChar);
            param[0].Value = role.RoleName;
            param[1] = new OracleParameter(PARAM_ROLE_ID, OracleType.Number);
            param[1].Value = role.RoleID;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_UPDATE_ROLE_INFO,param);
        }

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="role">要插入的角色信息</param>
        public void InsertRoleInfo(RoleInfo role)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_ROLE_NAME, OracleType.VarChar);
            param[0].Value = role.RoleName;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_ROLE_INFO, param);

        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="role">要删除的角色</param>
        public void DeleteRoleInfo(RoleInfo role)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_ROLE_ID, OracleType.Number);
            param[0].Value = role.RoleID;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_ROLE_INFO, param);
        }
        #endregion
    }
}