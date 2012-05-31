using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IPrivilege
    {
        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns>所有权限信息</returns>
        IList<PrivilegeInfo> GetAllPrivileges();


        /// <summary>
        /// 根据权限名称获取权限信息
        /// </summary>
        /// <param name="privilegeName">权限名称</param>
        /// <returns>具有指定权限名称的权限信息，没有则返回null</returns>
        PrivilegeInfo GetPrivilegeInfoByName(string privilegeName);

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="privilege">进行更新的权限信息</param>
        void UpdatePrivilegeInfo(PrivilegeInfo privilege);

        /// <summary>
        /// 插入一条新的权限信息
        /// </summary>
        /// <param name="privilege">进行插入的权限信息</param>
        void InsertPrivilegeInfo(PrivilegeInfo privilege);

        /// <summary>
        /// 删除一条权限信息
        /// </summary>
        /// <param name="privilege">所要删除的权限信息</param>
        void DeletePrivilegeInfo(PrivilegeInfo privilege);
    }
}
