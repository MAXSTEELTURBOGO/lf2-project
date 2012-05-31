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
    public class Basic : IBasic
    {
        #region SQL && PARAM
        private string SQL_GET_ALL_BASIC_INFO = @"SELECT INFO_NAME,INFO_DATA,INFO_DESCRIPTION FROM TB_BASIC_INFO";
        private string SQL_INSERT_BASIC_INFO = @"INSERT INTO TB_BASIC_INFO
                                                 (INFO_NAME, INFO_DATA, INFO_DESCRIPTION)
                                                 VALUES
                                                 (:INFO_NAME, :INFO_DATA, :INFO_DESCRIPTION)";
        private string SQL_UPDATE_BASIC_INFO = @"UPDATE TB_BASIC_INFO T
                                                   SET T.INFO_DATA = :INFO_DATA, T.INFO_DESCRIPTION = :INFO_DESCRIPTION
                                                 WHERE T.INFO_NAME = :INFO_NAME";
        private string PARAM_INFO_NAME = ":INFO_NAME";
        private string PARAM_INFO_DATA = ":INFO_DATA";
        private string PARAM_INFO_DESC = ":INFO_DESCRIPTION";
        #endregion

        #region 实现 IBasic 成员中的方法
        /// <summary>
        /// 获取所有的基础信息
        /// </summary>
        /// <returns>基础信息列表</returns>
        public IList<BasicInfo> GetBasicInfos()
        {
            IList<BasicInfo> basicInfoList = new List<BasicInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_GET_ALL_BASIC_INFO,null))
            {
                while (odr.Read())
                {
                    BasicInfo basicInfo = null;
                    string infoName = odr["INFO_NAME"].ToString();
                    string infoData = odr["INFO_DATA"].ToString();
                    string infoDesc = odr["INFO_DESCRIPTION"].ToString();
                    basicInfo = new BasicInfo(infoName, infoData, infoDesc);
                    basicInfoList.Add(basicInfo);
                }
            }
            return basicInfoList;
        }
        /// <summary>
        /// 向表TB_BASIC_INFO插入基础信息
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        public void InsertBasicInfo(BasicInfo basicInfo)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_INFO_NAME, OracleType.VarChar);
            param[0].Value = basicInfo.InfoName;
            param[1] = new OracleParameter(PARAM_INFO_DATA, OracleType.VarChar);
            param[1].Value = basicInfo.InfoData;
            param[2] = new OracleParameter(PARAM_INFO_DESC, OracleType.VarChar);
            param[2].Value = basicInfo.InfoDescription;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_BASIC_INFO, param);
        }
        /// <summary>
        /// 更新基础信息
        /// </summary>
        /// <param name="basicInfo">基础信息</param>
        public void UpdateBasicInfo(BasicInfo basicInfo)
        {
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter(PARAM_INFO_NAME, OracleType.VarChar);
            param[0].Value = basicInfo.InfoName;
            param[1] = new OracleParameter(PARAM_INFO_DATA, OracleType.VarChar);
            param[1].Value = basicInfo.InfoData;
            param[2] = new OracleParameter(PARAM_INFO_DESC, OracleType.VarChar);
            param[2].Value = basicInfo.InfoDescription;
            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_BASIC_INFO, param);
        }

        #endregion
    }
}
