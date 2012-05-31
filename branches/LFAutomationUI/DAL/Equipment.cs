using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;

namespace LFAutomationUI.DAL
{
    public class Equipment : IEquipment
    {

        #region SQL AND PARAM

        private const string SQL_SELECT_ALL_EQUIPMENT_INFO = @"SELECT MAINTENANCE_NAME,
                                                                        MAINTENANCE_DATA,
                                                                        MAINTENANCE_DESCRIPTION
                                                                        FROM TB_MAINTENANCE_INFO";
        private const string SQL_SELECT_ALL_EQUIPMENT_INFO_BY_DESC = @"SELECT MAINTENANCE_NAME,
                                                                        MAINTENANCE_DATA,
                                                                        MAINTENANCE_DESCRIPTION
                                                                        FROM TB_MAINTENANCE_INFO
                                                                        WHERE MAINTENANCE_DESCRIPTION = :MAINTENANCE_DESCRIPTION";


        private const string SQL_UPDATE_EQUIPMENT_INFO = @"UPDATE TB_MAINTENANCE_INFO T
                                                           SET T.MAINTENANCE_DATA        = :MAINTENANCE_DATA,
                                                               T.MAINTENANCE_DESCRIPTION = :MAINTENANCE_DESCRIPTION
                                                         WHERE T.MAINTENANCE_NAME = :MAINTENANCE_NAME";

        private const string PARAM_MAINTENANCE_NAME = ":MAINTENANCE_NAME";
        private const string PARAM_MAINTENANCE_DATA = ":MAINTENANCE_DATA";
        private const string PARAM_MAINTENANCE_DESCRIPTION = ":MAINTENANCE_DESCRIPTION";

        #endregion

        /// <summary>
        /// 获取所有设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        public IList<EquipmentInfo> GetAllEquipmentInfo()
        {
            IList<EquipmentInfo> equipmentList = new List<EquipmentInfo>();

            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_EQUIPMENT_INFO, null))
            {
                while (odr.Read())
                {
                    string maintenanceName = odr["MAINTENANCE_NAME"].ToString();
                    int maintenaceAge = Convert.ToInt16(odr["MAINTENANCE_DATA"]);
                    string maintenanceDescription = odr["MAINTENANCE_DESCRIPTION"] == DBNull.Value ? null : odr["MAINTENANCE_DESCRIPTION"].ToString();
                    EquipmentInfo equipment = new EquipmentInfo(maintenanceName, maintenaceAge, maintenanceDescription);

                    equipmentList.Add(equipment);
                }
            }
            return equipmentList;
        }

        /// <summary>
        /// 根据设备描述获取设备信息
        /// </summary>
        /// <returns>设备信息</returns>
        public EquipmentInfo GetEquipmentInfo(string equipmentDecription)
        {
            EquipmentInfo equipment = null;

            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_MAINTENANCE_DESCRIPTION, OracleType.VarChar);
            param[0].Value = equipmentDecription;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_EQUIPMENT_INFO_BY_DESC, param))
            {
                while (odr.Read())
                {
                    string maintenanceName = odr["MAINTENANCE_NAME"].ToString();
                    int maintenaceAge = Convert.ToInt16(odr["MAINTENANCE_DATA"]);
                    string maintenanceDescription = odr["MAINTENANCE_DESCRIPTION"] == DBNull.Value ? null : odr["MAINTENANCE_DESCRIPTION"].ToString();
                    equipment = new EquipmentInfo(maintenanceName, maintenaceAge, maintenanceDescription);
                }
            }
            return equipment;
        }

        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <param name="equipment">设备信息</param>
        public void UpdateEquipmentInfo(EquipmentInfo equipment)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_MAINTENANCE_NAME, OracleType.VarChar);
            param[0].Value = equipment.EquipmentName;
            param[1] = new OracleParameter(PARAM_MAINTENANCE_DATA, OracleType.Number);
            param[1].Value = equipment.EquipmentAge;
            param[2] = new OracleParameter(PARAM_MAINTENANCE_DESCRIPTION, OracleType.VarChar);
            param[2].Value = equipment.EquipmentDescription;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_EQUIPMENT_INFO, param);
        }
    }
}
