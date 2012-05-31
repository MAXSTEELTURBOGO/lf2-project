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
    public class Technic : ITechnics
    {
        #region SQL && PARAMETER
        private string SQL_SELECT_ALL_TECHNIC_INFO = @"SELECT V.TECHNICS_ID,
                                                              V.TECHNICS_NAME,
                                                              V.STEP_ID,
                                                              V.STEP_NAME,
                                                              V.PLAN_DURATION,
                                                              V.PLAN_POWERON_DURATION,
                                                              V.TRANSFORMER_TAP_POSITION,
                                                              V.TRANSFORMER_TAP_POSITION_POINT,
                                                              V.PLAN_TOP_AR_CONSUMPTION,
                                                              V.PLAN_BOTTOM_AR_CONSUMPTION,
                                                              V.TRANSFORMER_VOLTAGE,
                                                              V.TRANSFORMER_CURRENT,
                                                              V.TEMP_PER_MINUTE,
                                                              V.TRANSFORMER_POWER,
                                                              V.STEP_SEQUENCE
                                                         FROM V_TECHNICS_STEPS_INFO V
                                                        ORDER BY V.STEP_SEQUENCE";
        private string SQL_SELECT_TECHNIC_ID = "SELECT TECHNICS_ID FROM TB_TECHNICS_INFO WHERE TECHNICS_NAME=:TECHNICS_NAME";
        private string SQL_DELETE_TECHNIC_INFO = "DELETE FROM TB_TECHNICS_INFO T WHERE T.TECHNICS_ID=:TECHNICS_ID";
        private string SQL_INSERT_TECHNIC_INFO = "INSERT INTO TB_TECHNICS_INFO(TECHNICS_NAME) VALUES(:TECHNICS_NAME)";
        private string PARAM_TECHNICS_ID = ":TECHNICS_ID";
        private string PARAM_TECHNIC_NAME = ":TECHNICS_NAME";
        #endregion

        #region Methods实现接口ITechnics中的方法

        /// <summary>
        /// 获取所有的冶炼工艺基本信息  包括 工艺号 和 工艺名
        /// </summary>
        /// <returns>工艺基本信息</returns>
        public IList<TechnicsInfo> GetAllTechnicInfo()
        {
            IList<TechnicsInfo> technicInfoList = new List<TechnicsInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_TECHNIC_INFO, null))
            {
                DataTable dt = new DataTable();
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    IList<TechnicStepInfo> technicStepInfos = new List<TechnicStepInfo>();
                    TechnicsInfo technicInfo = null;
                    var enumSteps = (from i in dt.AsEnumerable()
                                     select new
                                     {
                                         technicId = i["TECHNICS_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["TECHNICS_ID"])),
                                         technicName = i["TECHNICS_NAME"].ToString(),
                                         stepId = i["STEP_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["STEP_ID"])),
                                         stepName = i["STEP_NAME"].ToString(),
                                         planDuration = i["PLAN_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["PLAN_DURATION"])),
                                         planPowerDuration = i["PLAN_POWERON_DURATION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["PLAN_POWERON_DURATION"])),
                                         tapPosition = i["TRANSFORMER_TAP_POSITION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["TRANSFORMER_TAP_POSITION"])),
                                         tapPositionPoint = i["TRANSFORMER_TAP_POSITION_POINT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["TRANSFORMER_TAP_POSITION_POINT"])),
                                         planTopArConsumption = i["PLAN_TOP_AR_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["PLAN_TOP_AR_CONSUMPTION"])),
                                         planBottomArConsumption = i["PLAN_BOTTOM_AR_CONSUMPTION"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["PLAN_BOTTOM_AR_CONSUMPTION"])),
                                         transformerVoltage = i["TRANSFORMER_VOLTAGE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["TRANSFORMER_VOLTAGE"])),
                                         transformerCurrent = i["TRANSFORMER_CURRENT"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["TRANSFORMER_CURRENT"])),
                                         tempPerMinute = i["TEMP_PER_MINUTE"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["TEMP_PER_MINUTE"])),
                                         transformerPower = i["TRANSFORMER_POWER"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["TRANSFORMER_POWER"])),
                                         sequence = i["STEP_SEQUENCE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["STEP_SEQUENCE"]))
                                     }).Distinct();
                    foreach (var i in enumSteps)
                    {
                        TransformerParamInfo transformerParamInfo = new TransformerParamInfo(i.tapPosition, i.tapPositionPoint, i.transformerVoltage, i.transformerCurrent, i.tempPerMinute, i.transformerPower);
                        StepInfo stepInfo = new StepInfo(i.stepId, i.stepName);
                        TechnicStepInfo technicstepInfo = new TechnicStepInfo(i.technicId, stepInfo, i.planDuration, i.planPowerDuration, i.planTopArConsumption, i.planBottomArConsumption, i.sequence, transformerParamInfo);
                        technicStepInfos.Add(technicstepInfo);
                    }
                    var enumTechnic = (from i in dt.AsEnumerable()
                                       select new
                                       {
                                           technicId = i["TECHNICS_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["TECHNICS_ID"])),
                                           technicName = i["TECHNICS_NAME"].ToString()
                                       }).Distinct();
                    foreach (var i in enumTechnic)
                    {
                        IList<TechnicStepInfo> technicStepList = (from j in technicStepInfos
                                                                  where j.TechnicId == i.technicId
                                                                  select j).ToList<TechnicStepInfo>();
                        technicInfo = new TechnicsInfo(i.technicId, i.technicName, technicStepList);
                        technicInfoList.Add(technicInfo);
                    }
                }
            }
            return technicInfoList;
        }

        /// <summary>
        /// 通过工艺名称选择工艺号
        /// </summary>
        /// <param name="technicsName">工艺名称</param>
        /// <returns>工艺号</returns>
        public int? GetTechnicsId(string technicsName)
        {
            int? technicsId = null;
            OracleParameter param = new OracleParameter(PARAM_TECHNIC_NAME, OracleType.VarChar);
            param.Value = technicsName;
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_TECHNIC_ID, param))
            {
                while (odr.Read())
                {
                    technicsId = odr["TECHNICS_ID"] == DBNull.Value ? null : new Nullable<Int32>(Convert.ToInt32(odr["TECHNICS_ID"]));
                }
            }
            return technicsId;
        }

        /// <summary>
        /// 删除工艺信息
        /// </summary>
        public void DeleteTechnicInfo(int technicsId)
        {
            OracleParameter param = new OracleParameter(PARAM_TECHNICS_ID, OracleType.Number);
            param.Value = technicsId;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_TECHNIC_INFO, param);
        }

        /// <summary>
        /// 插入一条新的工艺信息
        /// </summary>
        /// <param name="technicName"></param>
        public void InsertTechnicInfo(string technicName)
        {
            OracleParameter param = new OracleParameter(PARAM_TECHNIC_NAME, OracleType.VarChar);
            param.Value = technicName;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_TECHNIC_INFO, param);
        }
        #endregion
    }
}
