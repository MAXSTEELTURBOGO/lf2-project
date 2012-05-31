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
    public class TransformerParam : ITransformerParam
    {
        #region SQL && PARAM
        private const string SQL_SELECT_ALL_TRANSFORMER_PARAM_INFO = @"SELECT T.TRANSFORMER_TAP_POSITION,
                                                                              T.TRANSFORMER_TAP_POSITION_POINT,
                                                                              T.TRANSFORMER_VOLTAGE,
                                                                              T.TRANSFORMER_CURRENT,
                                                                              T.TEMP_PER_MINUTE,
                                                                              T.TRANSFORMER_POWER
                                                                         FROM TB_TRANSFORMER_PARAMETERS T
                                                                        ORDER BY T.TRANSFORMER_TAP_POSITION,T.TRANSFORMER_TAP_POSITION_POINT";
        private const string SQL_DEL_TRANSFORMER_PARAM_INFO = @"DELETE FROM TB_TRANSFORMER_PARAMETERS T
                                                                 WHERE T.TRANSFORMER_TAP_POSITION = :TRANSFORMER_TAP_POSITION
                                                                   AND T.TRANSFORMER_TAP_POSITION_POINT = :TRANSFORMER_TAP_POSITION_POINT";
        private const string SQL_INS_TRANS_PARAM_INFO = @"INSERT INTO TB_TRANSFORMER_PARAMETERS
                                                              (TRANSFORMER_TAP_POSITION,
                                                               TRANSFORMER_TAP_POSITION_POINT,
                                                               TRANSFORMER_VOLTAGE,
                                                               TRANSFORMER_CURRENT,
                                                               TEMP_PER_MINUTE,
                                                               TRANSFORMER_POWER)
                                                            VALUES
                                                              (:TRANSFORMER_TAP_POSITION,
                                                               :TRANSFORMER_TAP_POSITION_POINT,
                                                               :TRANSFORMER_VOLTAGE,
                                                               :TRANSFORMER_CURRENT,
                                                               :TEMP_PER_MINUTE,
                                                               :TRANSFORMER_POWER)";
        private const string SQL_UPD_TRANS_PARAM_WARMING_FACTOR = @"UPDATE TB_TRANSFORMER_PARAMETERS
                                                                      SET TEMP_PER_MINUTE=:TEMP_PER_MINUTE
                                                                    WHERE TRANSFORMER_TAP_POSITION=:TRANSFORMER_TAP_POSITION 
                                                                      AND TRANSFORMER_TAP_POSITION_POINT=:TRANSFORMER_TAP_POSITION_POINT";
        private const string PARAM_TAP_POSITION = ":TRANSFORMER_TAP_POSITION";
        private const string PARAM_TAP_POSITION_POINT = ":TRANSFORMER_TAP_POSITION_POINT";
        private const string PARAM_VOLTAGE = ":TRANSFORMER_VOLTAGE";
        private const string PARAM_CURRENT = ":TRANSFORMER_CURRENT";
        private const string PARAM_TEMP_PER_MIN = ":TEMP_PER_MINUTE";
        private const string PARAM_POWER = ":TRANSFORMER_POWER";

        #endregion

        #region Methods

        /// <summary>
        /// 从数据库获取所有的变压器参数信息
        /// </summary>
        /// <returns>变压器参数信息列表</returns>
        public IList<TransformerParamInfo> GetAllTransFormerParamInfo()
        {
            IList<TransformerParamInfo> transformerInfos = new List<TransformerParamInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ALL_TRANSFORMER_PARAM_INFO, null))
            {
                while (odr.Read())
                {
                    int tapPosition = Convert.ToInt32(odr[0]);
                    int tapPositionPoint = Convert.ToInt32(odr[1]);
                    double voltage = Convert.ToDouble(odr[2]);
                    double current = Convert.ToDouble(odr[3]);
                    double tempPerMin = Convert.ToDouble(odr[4]);
                    double power = Convert.ToDouble(odr[5]);
                    TransformerParamInfo transformerInfo = new TransformerParamInfo(tapPosition, tapPositionPoint, voltage, current, tempPerMin, power);
                    transformerInfos.Add(transformerInfo);
                }
            }
            return transformerInfos;
        }

        /// <summary>
        /// 删除指定变压器档位及其设定点的信息
        /// </summary>
        /// <param name="tapPosition">变压器档位</param>
        /// <param name="tapPoint">变压器单位设定点</param>
        public void DelTransParamInfoByTapPositionAndTapPoint(int tapPosition, int tapPoint)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_TAP_POSITION, OracleType.Number);
            param[0].Value = tapPosition;
            param[1] = new OracleParameter(PARAM_TAP_POSITION_POINT, OracleType.Number);
            param[1].Value = tapPoint;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DEL_TRANSFORMER_PARAM_INFO, param);
        }

        /// <summary>
        /// 插入一条变压器参数信息
        /// </summary>
        /// <param name="transformerInfo">新增的变压器参数信息</param>
        public void InsTransParamInfo(TransformerParamInfo transformerInfo)
        {
            int index = 0;
            OracleParameter[] param = new OracleParameter[6];
            param[index] = new OracleParameter(PARAM_TAP_POSITION, OracleType.Number);
            param[index++].Value = transformerInfo.TapPosition;
            param[index] = new OracleParameter(PARAM_TAP_POSITION_POINT, OracleType.Number);
            param[index++].Value = transformerInfo.TapPositionPoint;
            param[index] = new OracleParameter(PARAM_VOLTAGE, OracleType.Number);
            param[index++].Value = transformerInfo.Voltage;
            param[index] = new OracleParameter(PARAM_CURRENT, OracleType.Number);
            param[index++].Value = transformerInfo.Current;
            param[index] = new OracleParameter(PARAM_TEMP_PER_MIN, OracleType.Number);
            param[index++].Value = transformerInfo.TempPerMin;
            param[index] = new OracleParameter(PARAM_POWER, OracleType.Number);
            param[index++].Value = transformerInfo.Power;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INS_TRANS_PARAM_INFO, param);
        }

        /// <summary>
        /// 根据变压器档位、设定点更新温升信息
        /// </summary>
        /// <param name="tapPosition">档位</param>
        /// <param name="tapPositionPoint">档位设定点</param>
        /// <param name="chillFactor">升温系数</param>
        public void UpdateTransParam(int tapPosition, int tapPositionPoint, double chillFactor)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0]=new OracleParameter(PARAM_TAP_POSITION, tapPosition);
            param[1] = new OracleParameter(PARAM_TAP_POSITION_POINT, tapPositionPoint);
            param[2] = new OracleParameter(PARAM_TEMP_PER_MIN, chillFactor);
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPD_TRANS_PARAM_WARMING_FACTOR, param);
        }
        #endregion
    }
}
