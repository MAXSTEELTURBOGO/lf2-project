using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DALFactory;

namespace LFAutomationUI.BLL
{
    public class Privilege
    {
        private static readonly IPrivilege dal = DALFactory.DataAccess.CreatePrivilege();

        /// <summary>
        /// 获取所有权限信息
        /// </summary>
        /// <returns>所有权限信息</returns>
        public IList<PrivilegeInfo> GetAllPrivileges()
        {
            return dal.GetAllPrivileges();
        }

        /// <summary>
        /// 根据权限名称获取权限信息
        /// </summary>
        /// <param name="privilegeName">权限名称</param>
        /// <returns>具有指定权限名称的权限信息，没有则返回null</returns>
        public PrivilegeInfo GetPrivilegeInfoByName(string privilegenName)
        {
            return dal.GetPrivilegeInfoByName(privilegenName);
        }

        /// <summary>
        /// 更新权限信息
        /// </summary>
        /// <param name="privilege">进行更新的权限信息</param>
        public void UpdatePrivilegeInfo(PrivilegeInfo privilege)
        {
            dal.UpdatePrivilegeInfo(privilege);
        }

        /// <summary>
        /// 插入一条新的权限信息
        /// </summary>
        /// <param name="privilege">进行插入的权限信息</param>
        public void InsertPrivilegeInfo(PrivilegeInfo privilege)
        {
            dal.InsertPrivilegeInfo(privilege);
        }

        /// <summary>
        /// 删除一条权限信息
        /// </summary>
        /// <param name="privilege">所要删除的权限信息</param>
        public void DeletePrivilegeInfo(PrivilegeInfo privilege)
        {
            dal.DeletePrivilegeInfo(privilege);
        }
    }
}
