using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;

namespace LFAutomationUI.IDAL
{
    public interface IEquipment
    {
        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        IList<EquipmentInfo> GetAllEquipmentInfo();

        /// <summary>
        /// 根据设备描述获取设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        EquipmentInfo GetEquipmentInfo(string equipmentDecription);


        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <param name="equipment">设备信息</param>
        void UpdateEquipmentInfo(EquipmentInfo equipment);
      
    }
}
