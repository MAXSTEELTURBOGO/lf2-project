using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;


namespace LFAutomationUI.BLL
{
    public class Role
    {
        private static readonly IRole dal=DALFactory.DataAccess.CreateRole();

        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        public IList<RoleInfo> GetAllRoles()
        {
            return dal.GetAllRoles();
        }

        /// <summary>
        /// 更新角色信息
        /// </summary>
        /// <param name="role"></param>
        public void UpdateRoleInfo(RoleInfo role)
        {
            dal.UpdateRoleInfo(role);
            dal.DeleteRolePrivilegeInfo(role);
            if (role.Privileges!=null)
            {
                dal.InsertRolePrivilegeInfo(role);
            }
        }



        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        public void InsertRoleInfo(RoleInfo role)
        {
            dal.InsertRoleInfo(role);
            RoleInfo tempRole = dal.GetRoleInfoByRoleName(role.RoleName);
            role.RoleID = tempRole.RoleID;
            dal.InsertRolePrivilegeInfo(role);
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="role">角色信息</param>
        public void DeleteRoleInfo(RoleInfo role)
        {
            dal.DeleteRoleInfo(role);  
        }
    }
}
