using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IRole
    {
        /// <summary>
        /// 获取所有角色信息
        /// </summary>
        /// <returns></returns>
        IList<RoleInfo> GetAllRoles();

        /// <summary>
        /// 根据角色号获取角色信息
        /// </summary>
        /// <param name="roleId">角色号</param>
        /// <returns>角色信息</returns>
        RoleInfo GetRoleInfoByRoleId(int roleId);

        /// <summary>
        /// 根据角色名称获取角色信息
        /// </summary>
        /// <param name="roleName">角色名称</param>
        /// <returns>角色信息</returns>
        RoleInfo GetRoleInfoByRoleName(string roleName);

        /// <summary>
        /// 删除指定角色的所有权限信息
        /// </summary>
        /// <param name="role">角色</param>
        void DeleteRolePrivilegeInfo(RoleInfo role);


        /// <summary>
        /// 插入指定角色的所有权限信息
        /// </summary>
        /// <param name="role">角色</param>
        void InsertRolePrivilegeInfo(RoleInfo role);


        /// <summary>
        /// 更新指定角色的信息
        /// </summary>
        /// <param name="role">角色</param>
        void UpdateRoleInfo(RoleInfo role);

        /// <summary>
        /// 插入角色信息
        /// </summary>
        /// <param name="role">要插入的角色信息</param>
        void InsertRoleInfo(RoleInfo role);

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="role">要删除的角色</param>
        void DeleteRoleInfo(RoleInfo role);

    }
}
