using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LFAutomationUI.Model;
using LFAutomationUI.IDAL;
using LFAutomationUI.DBUtility;
using System.Data;
using System.Data.OracleClient;

namespace LFAutomationUI.DAL
{
    public class TechnicStep:ITechnicStep
    {
        #region SQL && PARAM
        private string SQL_INSERT_TECHNIC_STEP_INFO = @"INSERT INTO TB_TECHNICS_STEPS_INFO
                                                          (TECHNICS_ID,
                                                           STEP_ID,
                                                           PLAN_DURATION,
                                                           PLAN_POWERON_DURATION,
                                                           TRANSFORMER_TAP_POSITION,
                                                           TRANSFORMER_TAP_POSITION_POINT,
                                                           PLAN_TOP_AR_CONSUMPTION,
                                                           PLAN_BOTTOM_AR_CONSUMPTION,
                                                           STEP_SEQUENCE)
                                                        VALUES
                                                          (:TECHNICS_ID,
                                                           :STEP_ID,
                                                           :PLAN_DURATION,
                                                           :PLAN_POWERON_DURATION,
                                                           :TRANSFORMER_TAP_POSITION,
                                                           :TRANSFORMER_TAP_POSITION_POINT,
                                                           :PLAN_TOP_AR_CONSUMPTION,
                                                           :PLAN_BOTTOM_AR_CONSUMPTION,
                                                           :STEP_SEQUENCE)";
        private string PARAM_TECHNICS_ID = ":TECHNICS_ID";
        private string PARAM_STEP_ID = ":STEP_ID";
        private string PARAM_PLAN_DURATION = ":PLAN_DURATION";
        private string PARAM_PLAN_POWERON_DURATION = ":PLAN_POWERON_DURATION";
        private string PARAM_TRANSFORMER_TAP_POSITION = ":TRANSFORMER_TAP_POSITION";
        private string PARAM_TRANSFORMER_TAP_POSITION_POINT = ":TRANSFORMER_TAP_POSITION_POINT";
        private string PARAM_PLAN_TOP_AR_CONSUMPTION = ":PLAN_TOP_AR_CONSUMPTION";
        private string PARAM_PLAN_BOTTOM_AR_CONSUMPTION = ":PLAN_BOTTOM_AR_CONSUMPTION";
        private string PARAM_STEP_SEQUENCE = ":STEP_SEQUENCE";
        #endregion

        #region 实现ITechnicStep 成员
        /// <summary>
        /// 插入工艺步骤信息
        /// </summary>
        /// <param name="technicStepList">工艺步骤信息</param>
        public void InsertTechnicStepInfo(IList<TechnicStepInfo> technicStepList)
        {
            foreach (TechnicStepInfo item in technicStepList)
            {
                int index = 0;
                OracleParameter[] param = new OracleParameter[9];
                param[index] = new OracleParameter(PARAM_TECHNICS_ID, OracleType.Number);
                param[index++].Value = item.TechnicId;
                param[index] = new OracleParameter(PARAM_STEP_ID, OracleType.Number);
                param[index++].Value = item.Steps.StepId;
                param[index] = new OracleParameter(PARAM_PLAN_DURATION, OracleType.Number);
                param[index++].Value = item.PlanDuration;
                param[index] = new OracleParameter(PARAM_PLAN_POWERON_DURATION, OracleType.Number);
                param[index++].Value = item.PlanPowerDuration;
                param[index] = new OracleParameter(PARAM_TRANSFORMER_TAP_POSITION, OracleType.Number);
                param[index++].Value = item.TransFormerParams.TapPosition;
                param[index] = new OracleParameter(PARAM_TRANSFORMER_TAP_POSITION_POINT, OracleType.Number);
                param[index++].Value = item.TransFormerParams.TapPositionPoint;
                param[index] = new OracleParameter(PARAM_PLAN_TOP_AR_CONSUMPTION, OracleType.Number);
                param[index++].Value = item.PlanTopArConsumption;
                param[index] = new OracleParameter(PARAM_PLAN_BOTTOM_AR_CONSUMPTION, OracleType.Number);
                param[index++].Value = item.PlanBottomArConsumption;
                param[index] = new OracleParameter(PARAM_STEP_SEQUENCE, OracleType.Number);
                param[index++].Value = item.Sequence;
                OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_TECHNIC_STEP_INFO, param);
            }  
        }

        #endregion
    }
}
