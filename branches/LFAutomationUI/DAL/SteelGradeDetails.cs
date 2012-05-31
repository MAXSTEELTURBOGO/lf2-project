using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using LFAutomationUI.DBUtility;
using LFAutomationUI.IDAL;
using LFAutomationUI.Model;
using System.ComponentModel;

namespace LFAutomationUI.DAL
{
    public class SteelGradeDetails : ISteelGradeDetails
    {
        #region SQL_PARAM
        private const string SQL_SELECT_STEEL_GRADE_ID_LIST = @"SELECT STEEL_GRADE_ID FROM TB_STEEL_INFO ORDER BY STEEL_GRADE_ID";
        private const string SQL_SELECT_ALL_STEEL_GRADE_INFO = @"SELECT STEEL_GRADE_ID,
                                                                           STEEL_GRADE_NAME,
                                                                           STEEL_GRADE_GROUP_CODE,
                                                                           STEEL_GRADE_GROUP_NAME,
                                                                           STEEL_GRADE_DESCR
                                                                      FROM TB_STEEL_INFO
                                                                    ORDER BY STEEL_GRADE_ID";
        private const string SQL_SELECT_STEEL_GRADE_INFO_BY_STEEL_GRADE_ID = @"SELECT V1.STEEL_GRADE_ID,
                                                                                       V1.STEEL_GRADE_NAME,
                                                                                       V1.STEEL_GRADE_GROUP_CODE,
                                                                                       V1.STEEL_GRADE_GROUP_NAME,
                                                                                       V1.STEEL_GRADE_DESCR,
                                                                                       V1.LIQUID_TEMP,
                                                                                       V1.SLAG_MODEL,
                                                                                       V1.ARGON_MODEL,
                                                                                       V1.MAX_DURA_EACH_HEATING,
                                                                                       V1.HEATING_COUNT,
                                                                                       V1.FETI_AFT_HEATING,
                                                                                       V1.WIRE_WGT_AFT_HEATING,
                                                                                       V1.AR_DURA_BEF_FED_WIRE,
                                                                                       V1.AR_DURA_AFT_FED_WIRE,
                                                                                       V1.ROUTE_ID,
                                                                                       V1.ROUTE_DESC,
                                                                                       V1.TECHNICS_ID,
                                                                                       V1.TECHNICS_NAME,
                                                                                       V1.STEP_ID,
                                                                                       V1.STEP_NAME,
                                                                                       V1.PLAN_DURATION,
                                                                                       V1.PLAN_POWERON_DURATION,
                                                                                       V1.TRANSFORMER_TAP_POSITION,
                                                                                       V1.TRANSFORMER_TAP_POSITION_POINT,
                                                                                       V1.PLAN_TOP_AR_CONSUMPTION,
                                                                                       V1.PLAN_BOTTOM_AR_CONSUMPTION,
                                                                                       V1.TRANSFORMER_VOLTAGE,
                                                                                       V1.TRANSFORMER_CURRENT,
                                                                                       V1.TEMP_PER_MINUTE,
                                                                                       V1.TRANSFORMER_POWER,
                                                                                       V1.STEP_SEQUENCE
                                                                                  FROM V_STEEL_DETAIL_INFO V1
                                                                                    WHERE V1.STEEL_GRADE_ID=:STEEL_GRADE_ID";

        private const string SQL_DELETE_STEEL_GRADE_INFO_BY_STEEL_GRADE_ID = "DELETE FROM TB_STEEL_INFO WHERE STEEL_GRADE_ID=:STEEL_GRADE_ID";
        private const string SQL_INSERT_STEEL_GRADE_INFO = @"INSERT INTO TB_STEEL_INFO
                                                      (STEEL_GRADE_ID,
                                                       STEEL_GRADE_NAME,
                                                       STEEL_GRADE_GROUP_CODE,
                                                       STEEL_GRADE_GROUP_NAME,
                                                       STEEL_GRADE_DESCR,
                                                       LIQUID_TEMP,
                                                       SLAG_MODEL,
                                                       ARGON_MODEL,
                                                       MAX_DURA_EACH_HEATING,
                                                       HEATING_COUNT,
                                                       FETI_AFT_HEATING,
                                                       WIRE_WGT_AFT_HEATING,
                                                       AR_DURA_BEF_FED_WIRE,
                                                       AR_DURA_AFT_FED_WIRE,
                                                       ROUTE_ID,
                                                       TECHNIC_ID)
                                                    VALUES
                                                      (:STEEL_GRADE_ID,
                                                       :STEEL_GRADE_NAME,
                                                       :STEEL_GRADE_GROUP_CODE,
                                                       :STEEL_GRADE_GROUP_NAME,
                                                       :STEEL_GRADE_DESCR,
                                                       :LIQUID_TEMP,
                                                       :SLAG_MODEL,
                                                       :ARGON_MODEL,
                                                       :MAX_DURA_EACH_HEATING,
                                                       :HEATING_COUNT,
                                                       :FETI_AFT_HEATING,
                                                       :WIRE_WGT_AFT_HEATING,
                                                       :AR_DURA_BEF_FED_WIRE,
                                                       :AR_DURA_AFT_FED_WIRE,
                                                       :ROUTE_ID,
                                                       :TECHNIC_ID)";
        private const string SQL_UPD_STEEL_LIQUID_TEMP = @"UPDATE TB_STEEL_INFO T
                                                            SET T.LIQUID_TEMP=:LIQUID_TEMP
                                                          WHERE T.STEEL_GRADE_ID=:STEEL_GRADE_ID";
        private const string PARAM_STEEL_GRADE_ID = ":STEEL_GRADE_ID";
        private const string PARAM_STEEL_GRADE_NAME = ":STEEL_GRADE_NAME";
        private const string PARAM_STEEL_GRUOP_CODE = ":STEEL_GRADE_GROUP_CODE";
        private const string PARAM_STEEL_GRADE_GROUP_NAME = ":STEEL_GRADE_GROUP_NAME";
        private const string PARAM_STEEL_GRADE_DESCR = ":STEEL_GRADE_DESCR";
        private const string PARAM_FORMULA_ID = ":FORMULA_ID";
        private const string PARAM_LIQUID_TEMP = ":LIQUID_TEMP";
        private const string PARAM_SLAG_MODEL = ":SLAG_MODEL";
        private const string PARAM_ARGON_MODEL = ":ARGON_MODEL";
        private const string PARAM_MAX_DURA_EACH_HEATING = ":MAX_DURA_EACH_HEATING";
        private const string PARAM_HEATING_COUNT = ":HEATING_COUNT";
        private const string PARAM_FETI_AFT_HEATING = ":FETI_AFT_HEATING";
        private const string PARAM_WIRE_WGT_AFT_HEATING = ":WIRE_WGT_AFT_HEATING";
        private const string PARAM_AR_DURA_BEF_FED_WIRE = ":AR_DURA_BEF_FED_WIRE";
        private const string PARAM_AR_DURA_AFT_FED_WIRE = ":AR_DURA_AFT_FED_WIRE";
        private const string PARAM_ROUTE_ID = ":ROUTE_ID";
        private const string PARAM_TECHNIC_ID = ":TECHNIC_ID";
        #endregion

        #region ISteelGradeDetails 成员实现

        /// <summary>
        /// 获取钢种号列表
        /// </summary>
        /// <returns>钢种号</returns>
        public IList<string> GetSteelGradeIdList()
        {
            IList<string> steelGradeIdList = new List<string>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_STEEL_GRADE_ID_LIST, null))
            {
                while (odr.Read())
                {
                    string steelGradeId = odr["STEEL_GRADE_ID"].ToString();
                    steelGradeIdList.Add(steelGradeId);
                }
            }
            return steelGradeIdList;
        }

        /// <summary>
        /// 从钢种信息表(tb_steel_info)取出所有的钢种基本信息 
        /// </summary>
        /// <returns>所有钢种信息</returns>
        public IList<SteelGradeDetailInfo> GetAllSteelGradeInfo()
        {
            IList<SteelGradeDetailInfo> steelGradeInfoList = new List<SteelGradeDetailInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_STEEL_GRADE_INFO, null))
            {
                while (odr.Read())
                {
                    string steelGradeId = odr.GetString(0);
                    string steelGradeName = null;
                    try
                    {
                        steelGradeName = odr.GetString(1);
                    }
                    catch
                    {
                    }
                    string steelGradeGroupCode = null;
                    try
                    {
                        steelGradeGroupCode = odr.GetString(2);
                    }
                    catch
                    {
                    }
                    string steelGradeGroupName = null;
                    try
                    {
                        steelGradeGroupName = odr.GetString(3);
                    }
                    catch
                    {
                    }
                    string steelGradeDescr = "";
                    try
                    {
                        steelGradeDescr = odr.GetString(4);
                    }
                    catch (Exception)
                    {
                    }
                    SteelGradeDetailInfo steelGradeInfo = new SteelGradeDetailInfo(steelGradeId, steelGradeName, steelGradeGroupCode, steelGradeGroupName, steelGradeDescr);
                    steelGradeInfoList.Add(steelGradeInfo);
                }

            }
            return steelGradeInfoList;
        }

        /// <summary>
        /// 通过钢种号取出钢种的基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <returns>该钢种基本信息</returns>
        public SteelGradeDetailInfo GetSteelGradeInfoBySteelGradeId(string steelGradeId)
        {
            SteelGradeDetailInfo steelGradeInfo = null;
            OracleParameter param = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param.Value = steelGradeId == null ? (object)DBNull.Value : (object)steelGradeId;
            DataTable dt = new DataTable();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_STEEL_GRADE_INFO_BY_STEEL_GRADE_ID, param))
            {
                dt.Load(odr);
                if (dt.Rows.Count > 0)
                {
                    //获取钢种基本信息
                    var enumSteelGradeInfo = (from i in dt.AsEnumerable()
                                              select new
                                              {
                                                  steelGradeId = i["STEEL_GRADE_ID"].ToString(),
                                                  steelGradeName = i["STEEL_GRADE_NAME"].ToString(),
                                                  steelGradeGroupCode = i["STEEL_GRADE_GROUP_CODE"].ToString(),
                                                  steelGradeGroupName = i["STEEL_GRADE_GROUP_NAME"].ToString(),
                                                  steelGradeDesc = i["STEEL_GRADE_DESCR"].ToString(),
                                                  liquidTemp = i["LIQUID_TEMP"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["LIQUID_TEMP"])),
                                                  slagModel = i["SLAG_MODEL"].ToString(),
                                                  argonModel = i["ARGON_MODEL"].ToString(),
                                                  maxDuraEachHeating = i["MAX_DURA_EACH_HEATING"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["MAX_DURA_EACH_HEATING"])),
                                                  heatingCount = i["HEATING_COUNT"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["HEATING_COUNT"])),
                                                  feTiAftHeating = i["FETI_AFT_HEATING"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["FETI_AFT_HEATING"])),
                                                  wireWgtAftHeating = i["WIRE_WGT_AFT_HEATING"] == DBNull.Value ? null : new Nullable<double>(Convert.ToDouble(i["WIRE_WGT_AFT_HEATING"])),
                                                  arDuraBefFeedWire = i["AR_DURA_BEF_FED_WIRE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["AR_DURA_BEF_FED_WIRE"])),
                                                  arDuraAftFeedWire = i["AR_DURA_AFT_FED_WIRE"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["AR_DURA_AFT_FED_WIRE"])),
                                                  routeId = i["ROUTE_ID"].ToString(),
                                                  routeDesc = i["ROUTE_DESC"].ToString()
                                              }).Distinct();
                    var enumSteelInfo = enumSteelGradeInfo.First();

                    Formula formulaDAL = new Formula();

                    IList<FormulaInfo> formulaList = formulaDAL.GetFormulaListBySteelGradeId(steelGradeId);

                    steelGradeInfo = new SteelGradeDetailInfo(steelGradeId, enumSteelInfo.steelGradeName, enumSteelInfo.steelGradeGroupCode, enumSteelInfo.steelGradeGroupName, enumSteelInfo.steelGradeDesc, formulaList,
                                                                enumSteelInfo.liquidTemp, enumSteelInfo.slagModel, enumSteelInfo.argonModel, enumSteelInfo.maxDuraEachHeating, enumSteelInfo.heatingCount, enumSteelInfo.feTiAftHeating,
                                                                enumSteelInfo.wireWgtAftHeating, enumSteelInfo.arDuraBefFeedWire, enumSteelInfo.arDuraAftFeedWire, enumSteelInfo.routeId, enumSteelInfo.routeDesc, null);

                    //--------------------------
                    //获取工艺基本信息
                    TechnicsInfo technics = null;
                    var enumTechnics = (from i in dt.AsEnumerable()
                                        select new
                                        {
                                            technicId = i["TECHNICS_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt32(i["TECHNICS_ID"])),
                                            technicName = i["TECHNICS_NAME"].ToString()
                                        }).Distinct().First();

                    technics = new TechnicsInfo(enumTechnics.technicId, enumTechnics.technicName, null);

                    //获取工艺步骤变压器基本信息
                    IList<TechnicStepInfo> technicStepInfos = new List<TechnicStepInfo>();
                    var enumTechnicStep = (from i in dt.AsEnumerable()
                                           select new
                                           {
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
                    foreach (var i in enumTechnicStep)
                    {
                        StepInfo stepInfo = new StepInfo(i.stepId, i.stepName);
                        TransformerParamInfo transParamInfo = new TransformerParamInfo(i.tapPosition, i.tapPositionPoint, i.transformerVoltage, i.transformerCurrent, i.tempPerMinute, i.transformerPower);
                        TechnicStepInfo technicStepInfo = new TechnicStepInfo(stepInfo, i.planDuration, i.planPowerDuration, i.planTopArConsumption, i.planBottomArConsumption, i.sequence, transParamInfo);
                        technicStepInfos.Add(technicStepInfo);
                    }
                    technics.TechnicStepInfo = technicStepInfos;
                    steelGradeInfo.TechnicsInfo = technics;
                }
            }
            return steelGradeInfo;
        }

        /// <summary>
        /// 删除钢种基本信息
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        public void DeleteSteelGradeInfoBySteelGradeId(string steelGradeId)
        {
            OracleParameter param = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param.Value = steelGradeId;
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_STEEL_GRADE_INFO_BY_STEEL_GRADE_ID, param);
        }

        /// <summary>
        /// 插入钢钟信息
        /// </summary>
        /// <param name="steelGradeDetailInfos"></param>
        public void InsertSteelGradeInfo(SteelGradeDetailInfo steelGradeDetailInfo)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[16];
            param[index] = new OracleParameter(PARAM_STEEL_GRADE_ID, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SteelGradeId;
            param[index] = new OracleParameter(PARAM_STEEL_GRADE_NAME, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SteelGradeName == null ? DBNull.Value : (object)(steelGradeDetailInfo.SteelGradeName);
            param[index] = new OracleParameter(PARAM_STEEL_GRUOP_CODE, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SteelGradeGroupCode == null ? DBNull.Value : (object)steelGradeDetailInfo.SteelGradeGroupCode;
            param[index] = new OracleParameter(PARAM_STEEL_GRADE_GROUP_NAME, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SteelGradeGroupName == null ? DBNull.Value : (object)steelGradeDetailInfo.SteelGradeGroupName;
            param[index] = new OracleParameter(PARAM_STEEL_GRADE_DESCR, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SteelGradeDescr == null ? DBNull.Value : (object)steelGradeDetailInfo.SteelGradeDescr;
            param[index] = new OracleParameter(PARAM_LIQUID_TEMP, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.LiquidTemp == null ? DBNull.Value : (object)steelGradeDetailInfo.LiquidTemp;
            param[index] = new OracleParameter(PARAM_SLAG_MODEL, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.SlagModel == null ? DBNull.Value : (object)steelGradeDetailInfo.SlagModel;
            param[index] = new OracleParameter(PARAM_ARGON_MODEL, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.ArgonModel == null ? DBNull.Value : (object)steelGradeDetailInfo.ArgonModel;
            param[index] = new OracleParameter(PARAM_MAX_DURA_EACH_HEATING, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.MaxDuraEachHeating == null ? DBNull.Value : (object)steelGradeDetailInfo.MaxDuraEachHeating;
            param[index] = new OracleParameter(PARAM_HEATING_COUNT, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.HeatingCount == null ? DBNull.Value : (object)steelGradeDetailInfo.HeatingCount;
            param[index] = new OracleParameter(PARAM_FETI_AFT_HEATING, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.FeTiAftHeating == null ? DBNull.Value : (object)steelGradeDetailInfo.FeTiAftHeating;
            param[index] = new OracleParameter(PARAM_WIRE_WGT_AFT_HEATING, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.WireWgtAftHeating == null ? DBNull.Value : (object)steelGradeDetailInfo.WireWgtAftHeating;
            param[index] = new OracleParameter(PARAM_AR_DURA_BEF_FED_WIRE, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.ArDuraBefFeedWire == null ? DBNull.Value : (object)steelGradeDetailInfo.ArDuraBefFeedWire;
            param[index] = new OracleParameter(PARAM_AR_DURA_AFT_FED_WIRE, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.ArDuraAftFeedWire == null ? DBNull.Value : (object)steelGradeDetailInfo.ArDuraAftFeedWire;
            param[index] = new OracleParameter(PARAM_ROUTE_ID, OracleType.VarChar);
            param[index++].Value = steelGradeDetailInfo.RouteId == null ? DBNull.Value : (object)steelGradeDetailInfo.RouteId;
            param[index] = new OracleParameter(PARAM_TECHNIC_ID, OracleType.Number);
            param[index++].Value = steelGradeDetailInfo.TechnicsInfo.TechnicId == null ? DBNull.Value : (object)steelGradeDetailInfo.TechnicsInfo.TechnicId;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_STEEL_GRADE_INFO, param);
        }
        /// <summary>
        /// 更新钢种液相线温度
        /// </summary>
        /// <param name="steelGradeId">钢种号</param>
        /// <param name="liquidTemp">液相线温度</param>
        public void UpdateSteelGradeLiquidTemp(string steelGradeId, double liquidTemp)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_STEEL_GRADE_ID, steelGradeId);
            param[1] = new OracleParameter(PARAM_LIQUID_TEMP, liquidTemp);
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPD_STEEL_LIQUID_TEMP, param);
        }

        #endregion
    }
}
