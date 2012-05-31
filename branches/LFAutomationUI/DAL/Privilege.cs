using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class Privilege:IPrivilege
    {
        #region SQL AND PARAM
        private const string SQL_SELECT_ALL_PRIVILEGES = "SELECT PRIVILEGE_ID,PRIVILEGE_NAME,CREATED_DATE,LAST_MODIFIED_DATE,PARENT_PRIVI_ID FROM TB_SYS_PRIVILEGE_INFO";
        private const string SQL_SELECT_PRIVILEGE_BY_NAME = "SELECT PRIVILEGE_ID,PRIVILEGE_NAME,CREATED_DATE,LAST_MODIFIED_DATE,PARENT_PRIVI_ID FROM TB_SYS_PRIVILEGE_INFO WHERE PRIVILEGE_NAME = :PRIVILEGE_NAME ";
        private const string SQL_UPDATE_PRIVILEGE = @"UPDATE TB_SYS_PRIVILEGE_INFO T
                                                       SET PRIVILEGE_NAME    = :PRIVILEGE_NAME,
                                                           T.PARENT_PRIVI_ID = :PARENT_PRIVI_ID
                                                     WHERE T.PRIVILEGE_ID = :PRIVILEGE_ID";
        private const string SQL_INSERT_PRIVILEGE = @"INSERT INTO TB_SYS_PRIVILEGE_INFO(PRIVILEGE_NAME,PARENT_PRIVI_ID)
                                                    VALUES(:PRIVILEGE_NAME,:PARENT_PRIVI_ID)";
        private const string SQL_DELETE_PRIVILEGE = @"DELETE FROM TB_SYS_PRIVILEGE_INFO WHERE PRIVILEGE_ID = :PRIVILEGE_ID";

        private const string PARAM_PRIVILEGE_ID = ":PRIVILEGE_ID";
        private const string PARAM_PRIVILEGE_NAME = ":PRIVILEGE_NAME";
        private const string PARAM_PARENT_PRIVI_ID = ":PARENT_PRIVI_ID";
        #endregion
        

        #region IPrivilege 成员

        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns>所有权限信息</returns>
        public IList<PrivilegeInfo> GetAllPrivileges()
        {
            int privilegeId;
            string privilegeName;
            DateTime createdDate;
            DateTime lastModifiedDate;
            int parentPrivilegeId;

            IList<PrivilegeInfo> privileges = new List<PrivilegeInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_PRIVILEGES, null))
            {
                while (odr.Read())
                {
                    privilegeId = Convert.ToInt16(odr[0]);
                    privilegeName = odr[1].ToString();
                    createdDate = Convert.ToDateTime(odr[2]);
                    lastModifiedDate = Convert.ToDateTime(odr[3]);
                    try
                    {
                        parentPrivilegeId = Convert.ToInt16(odr[4]);
                    }
                    catch (Exception)
                    {
                        parentPrivilegeId = 0;
                    }
                    PrivilegeInfo privilege = new PrivilegeInfo(privilegeId, privilegeName, parentPrivilegeId, createdDate, lastModifiedDate);
                    privileges.Add(privilege);
                }
            }
            return privileges;
        }

        /// <summary>
        /// 根据权限名称获取权限信息
        /// </summary>
        /// <param name="privilegeName">权限名称</param>
        /// <returns>具有指定权限名称的权限信息，没有则返回null</returns>
        public PrivilegeInfo GetPrivilegeInfoByName(string privilegeName)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_PRIVILEGE_NAME, OracleType.VarChar);
            param[0].Value = privilegeName;

            int privilegeId;
            DateTime createdDate;
            DateTime lastModifiedDate;
            int parentPrivilegeId;
            PrivilegeInfo privilege = null;
            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_PRIVILEGE_BY_NAME,param))
            {
                if (odr.Read())
                {
                    privilegeId = Convert.ToInt32(odr[0]);
                    createdDate = Convert.ToDateTime(odr[2]);
                    lastModifiedDate = Convert.ToDateTime(odr[3]);
                    try
                    {
                        parentPrivilegeId = Convert.ToInt32(odr[4]);
                    }
                    catch (Exception)
                    {
                        parentPrivilegeId = 0;
                    }
                    privilege = new PrivilegeInfo(privilegeId, privilegeName, parentPrivilegeId, createdDate, lastModifiedDate);
                }
            }
            return privilege;
        }


        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="privilege">进行更新的权限信息</param>
        public void UpdatePrivilegeInfo(PrivilegeInfo privilege)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_PRIVILEGE_NAME, OracleType.VarChar);
            param[0].Value = privilege.PrivilegeName;
            param[1] = new OracleParameter(PARAM_PARENT_PRIVI_ID, OracleType.Number);
            if (privilege.ParentPrivilegeId == 0)
            {
                param[1].Value = DBNull.Value;
            }
            else
            {
                param[1].Value = privilege.ParentPrivilegeId;
            }
            param[2] = new OracleParameter(PARAM_PRIVILEGE_ID, OracleType.Number);
            param[2].Value = privilege.PrivilegeId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_PRIVILEGE, param);
        }

        /// <summary>
        /// 插入一条新的权限信息
        /// </summary>
        /// <param name="privilege">进行插入的权限信息</param>
        public void InsertPrivilegeInfo(PrivilegeInfo privilege)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_PRIVILEGE_NAME, OracleType.VarChar);
            param[0].Value = privilege.PrivilegeName;
            param[1] = new OracleParameter(PARAM_PARENT_PRIVI_ID,OracleType.Number);
            if (privilege.ParentPrivilegeId == 0)
            {
                param[1].Value = DBNull.Value;
            }
            else
            {
                param[1].Value = privilege.ParentPrivilegeId;
            }
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_PRIVILEGE, param);
        }


        /// <summary>
        /// 删除一条权限信息
        /// </summary>
        /// <param name="privilege">所要删除的权限信息</param>
        public void DeletePrivilegeInfo(PrivilegeInfo privilege)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_PRIVILEGE_ID, OracleType.Number);
            param[0].Value = privilege.PrivilegeId;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_PRIVILEGE, param);
        }
        #endregion
    }
}
