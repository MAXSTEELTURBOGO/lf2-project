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
    public class Step : IStep
    {
        #region SQL &&  PARAM

        private const string SQL_GET_STEPS_INFO = @"SELECT STEP_ID,STEP_NAME FROM TB_STEPS_INFO";
        private const string SQL_INSERT_STEP_INFO = @"INSERT INTO TB_STEPS_INFO(STEP_ID,STEP_NAME) VALUES(:STEP_ID,:STEP_NAME)";
        private const string SQL_UPDATE_STEP_INFO = @"UPDATE TB_STEPS_INFO SET STEP_NAME = :STEP_NAME WHERE STEP_ID = :STEP_ID";
        private const string PARAM_STEP_ID = ":STEP_ID";
        private const string PARAM_STEP_NAME = ":STEP_NAME";

        #endregion

        /// <summary>
        /// 从TB_STEPS_INFO表获取所有的步骤信息
        /// </summary>
        /// <returns>步骤信息</returns>
        public IList<StepInfo> GetAllStepInfo()
        {
            IList<StepInfo> stepInfos = new List<StepInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_GET_STEPS_INFO, null))
            {
                while (odr.Read())
                {
                    int stepId = Convert.ToInt32(odr[0]);
                    string stepName = odr.GetString(1);
                    StepInfo stepInfo = new StepInfo(stepId, stepName);
                    stepInfos.Add(stepInfo);
                }
            }
            return stepInfos;
        }

        /// <summary>
        /// 插入新的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        public void InsertNewStepInfo(StepInfo stepInfo)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_STEP_ID, OracleType.Number);
            param[0].Value = stepInfo.StepId;
            param[1] = new OracleParameter(PARAM_STEP_NAME, OracleType.VarChar);
            param[1].Value = stepInfo.StepName;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_STEP_INFO, param);
        }

        /// <summary>
        /// 更新已有的步骤信息
        /// </summary>
        /// <param name="stepInfo">步骤信息</param>
        public void UpdateStepInfoByStepId(StepInfo stepInfo)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_STEP_ID, OracleType.Number);
            param[0].Value = stepInfo.StepId;
            param[1] = new OracleParameter(PARAM_STEP_NAME, OracleType.VarChar);
            param[1].Value = stepInfo.StepName;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_STEP_INFO, param);
        }
    }
}
