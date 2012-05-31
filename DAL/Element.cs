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
    public class Element : IElement
    {
        #region SQL&&PARAM
        private const string SQL_SELECT_ELEMENT_LIST = @"SELECT ELEMENT_ID,
                                                               ELEMENT_SHORT_NAME,
                                                               ELEMENT_FULL_NAME,
                                                               ELEMENT_TYPE,
                                                               VIEW_SEQUENCE,
                                                               FIXED_RATIO
                                                          FROM TB_ELEMENT_INFO
                                                            ORDER BY ELEMENT_TYPE";

        private const string SQL_SELECT_ELEMENT_INFO = @"SELECT ELEMENT_ID,
                                                               ELEMENT_SHORT_NAME,
                                                               ELEMENT_FULL_NAME,
                                                               ELEMENT_TYPE,
                                                               VIEW_SEQUENCE,
                                                               FIXED_RATIO
                                                          FROM TB_ELEMENT_INFO
                                                         WHERE ELEMENT_TYPE = 'ELEMENT'
                                                         ORDER BY ELEMENT_ID";

        private const string SQL_SELECT_COMPOUND_INFO = @"SELECT ELEMENT_ID,
                                                               ELEMENT_SHORT_NAME,
                                                               ELEMENT_FULL_NAME,
                                                               ELEMENT_TYPE,
                                                               VIEW_SEQUENCE,
                                                               FIXED_RATIO
                                                          FROM TB_ELEMENT_INFO
                                                         WHERE ELEMENT_TYPE = 'COMPOUND'
                                                         ORDER BY ELEMENT_ID";

        private const string SQL_DELETE_ELEMENT_INFO_BY_ELEMENT_ID = "DELETE FROM TB_ELEMENT_INFO WHERE ELEMENT_ID=:ELEMENT_ID";
        private const string SQL_INSERT_ELEMENT_INFO = @"INSERT INTO TB_ELEMENT_INFO
                                                                      (ELEMENT_ID,
                                                                       ELEMENT_SHORT_NAME,
                                                                       ELEMENT_FULL_NAME,
                                                                       ELEMENT_TYPE,
                                                                       VIEW_SEQUENCE,
                                                                       FIXED_RATIO)
                                                                    VALUES
                                                                      (:ELEMENT_ID,
                                                                       :ELEMENT_SHORT_NAME,
                                                                       :ELEMENT_FULL_NAME,
                                                                       :ELEMENT_TYPE,
                                                                       :VIEW_SEQUENCE,
                                                                       :FIXED_RATIO)";
        private const string SQL_ELEMENT_INFO_BY_ELEMENT_ID = @"SELECT ELEMENT_ID,
                                                                       ELEMENT_SHORT_NAME,
                                                                       ELEMENT_FULL_NAME,
                                                                       ELEMENT_TYPE,
                                                                       VIEW_SEQUENCE,
                                                                       FIXED_RATIO 
                                                                      FROM TB_ELEMENT_INFO 
                                                                    WHERE ELEMENT_ID=:ELEMENT_ID";
        
        private const string PARAM_ELEMENT_ID = ":ELEMENT_ID";
        private const string PARAM_ELEMENT_SHORT_NAME = ":ELEMENT_SHORT_NAME";
        private const string PARAM_ELEMENT_FULL_NAME = ":ELEMENT_FULL_NAME";
        private const string PARAM_ELEMENT_TYPE = ":ELEMENT_TYPE";
        private const string PARAM_VIEW_SEQUENCE = ":VIEW_SEQUENCE";
        private const string PARAM_FIXED_RATIO = ":FIXED_RATIO";

        #endregion

        #region Methods

        /// <summary>
        /// 获取所有元素信息
        /// </summary>
        /// <returns></returns>
        public IList<ElementInfo> GetElementList()
        {
            IList<ElementInfo> elementList = new List<ElementInfo>();
            using (OracleDataReader odr= OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ELEMENT_LIST,null))
            {
                while (odr.Read())
                {
                    ElementInfo elem = new ElementInfo();
                    elem.ElementId = odr["ELEMENT_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["ELEMENT_ID"]));
                    elem.ElementShortName = odr["ELEMENT_SHORT_NAME"].ToString();
                    elem.ElementFullName = odr["ELEMENT_FULL_NAME"].ToString();
                    elem.ElementType = odr["ELEMENT_TYPE"].ToString();
                    elem.ViewSequence = Convert.ToDecimal(odr["VIEW_SEQUENCE"]);
                    elem.FixedRatio = Convert.ToDouble(odr["FIXED_RATIO"]);
                    elementList.Add(elem);
                }
            }
            return elementList;
        }


        /// <summary>
        /// 取得元素信息
        /// </summary>
        /// <returns>元素信息（包括：元素代码、元素简称、元素全称）</returns>
        public IList<ElementInfo> GetElementInfo()
        {

            IList<ElementInfo> getAllElementInfo = new List<ElementInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_ELEMENT_INFO, null))
            {
                while (odr.Read())
                {
                    ElementInfo elem = new ElementInfo();
                    elem.ElementId = odr["ELEMENT_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["ELEMENT_ID"]));
                    elem.ElementShortName = odr["ELEMENT_SHORT_NAME"].ToString();
                    elem.ElementFullName = odr["ELEMENT_FULL_NAME"].ToString();
                    elem.ElementType = odr["ELEMENT_TYPE"].ToString();
                    elem.ViewSequence = Convert.ToDecimal(odr["VIEW_SEQUENCE"]);
                    elem.FixedRatio = Convert.ToDouble(odr["FIXED_RATIO"]);

                    getAllElementInfo.Add(elem);
                }
            }
            return getAllElementInfo;
        }

        /// <summary>
        /// 取得化合物信息
        /// </summary>
        /// <returns>化合物信息</returns>
        public IList<ElementInfo> GetCompoundInfo()
        {
            IList<ElementInfo> getAllElementInfo = new List<ElementInfo>();
            using (OracleDataReader odr = OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_SELECT_COMPOUND_INFO, null))
            {
                while (odr.Read())
                {
                    ElementInfo elem = new ElementInfo();
                    elem.ElementId = odr["ELEMENT_ID"] == DBNull.Value ? null : new Nullable<int>(Convert.ToInt16(odr["ELEMENT_ID"]));
                    elem.ElementShortName = odr["ELEMENT_SHORT_NAME"].ToString();
                    elem.ElementFullName = odr["ELEMENT_FULL_NAME"].ToString();
                    elem.ElementType = odr["ELEMENT_TYPE"].ToString();
                    elem.ViewSequence = Convert.ToDecimal(odr["VIEW_SEQUENCE"]);
                    elem.FixedRatio = Convert.ToDouble(odr["FIXED_RATIO"]);
                    getAllElementInfo.Add(elem);
                }
            }
            return getAllElementInfo;
        }

        /// <summary>
        /// 删除指定元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        public void DeleteElementInfoByElementId(int elementId)
        {
            OracleParameter param = new OracleParameter(PARAM_ELEMENT_ID, OracleType.Number);
            param.Value = elementId;
            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_ELEMENT_INFO_BY_ELEMENT_ID, param);
        }
        /// <summary>
        /// 插入元素信息
        /// </summary>
        /// <param name="elem">元素号</param>
        public void InsertElementInfo(ElementInfo elem)
        {
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter(PARAM_ELEMENT_ID, OracleType.Number);
            param[0].Value = elem.ElementId;
            param[1] = new OracleParameter(PARAM_ELEMENT_SHORT_NAME, OracleType.VarChar);
            param[1].Value = elem.ElementShortName;
            param[2] = new OracleParameter(PARAM_ELEMENT_FULL_NAME, OracleType.VarChar);
            param[2].Value = elem.ElementFullName;
            param[3] = new OracleParameter(PARAM_ELEMENT_TYPE, OracleType.VarChar);
            param[3].Value = elem.ElementType;
            param[4] = new OracleParameter(PARAM_VIEW_SEQUENCE, OracleType.Number);
            param[4].Value = elem.ViewSequence;
            param[5] = new OracleParameter(PARAM_FIXED_RATIO, OracleType.Number);
            param[5].Value = elem.FixedRatio;

            OracleHelper.ExecuteScalar(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_ELEMENT_INFO, param);
        }
        /// <summary>
        /// 由元素号得到该元素号的元素信息
        /// </summary>
        /// <param name="elementId">元素号</param>
        /// <returns>个数count</returns>
        public ElementInfo GetElementInfoByElementId(int elementId)
        {
            OracleParameter param = new OracleParameter(PARAM_ELEMENT_ID, OracleType.Number);
            param.Value = elementId;
            ElementInfo elem = null;
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_ELEMENT_INFO_BY_ELEMENT_ID,param))
            {
                if (odr.Read())
                {
                    elem = new ElementInfo();
                    elem.ElementId = odr["ELEMENT_ID"] == DBNull.Value? null: new Nullable<int>(Convert.ToInt16(odr["ELEMENT_ID"]));
                    elem.ElementShortName = odr["ELEMENT_SHORT_NAME"].ToString();
                    elem.ElementFullName = odr["ELEMENT_FULL_NAME"].ToString();
                    elem.ElementType = odr["ELEMENT_TYPE"].ToString();
                    elem.ViewSequence = Convert.ToDecimal(odr["VIEW_SEQUENCE"]);
                    elem.FixedRatio = Convert.ToDouble(odr["FIXED_RATIO"]);
                }
            }
            return elem;
        }

        #endregion

    }
}
