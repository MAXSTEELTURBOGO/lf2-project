using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;

namespace LFAutomationUI.BLL
{
    public class Equipment
    {
        private static readonly IEquipment dal = LFAutomationUI.DALFactory.DataAccess.CreateEquipment();

        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        public IList<EquipmentInfo> GetAllEquipmentInfo()
        {
            return dal.GetAllEquipmentInfo();
        }

        public EquipmentInfo GetEquipmentInfo(string equipmentDescription)
        {
            return dal.GetEquipmentInfo(equipmentDescription);
        }

        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <param name="equipment">设备信息</param>
        public void UpdateEquipmentInfo(EquipmentInfo equipment)
        {
            dal.UpdateEquipmentInfo(equipment);
        }

        /// <summary>
        /// 将设备寿命为0
        /// </summary>
        /// <param name="equipment">设备信息</param>
        public void ResetEquipmentAge(EquipmentInfo equipment)
        {
            equipment.EquipmentAge = 0;
            dal.UpdateEquipmentInfo(equipment);
        }
    }
}
