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
    public class MaterialType:IMaterialType
    {
        #region SQL && PARAMETER
        private const string SQL_SELECT_MATERIAL_TYPE_INFO = "SELECT * FROM TB_MATERIAL_TYPE_INFO";
        #endregion

        #region 实现接口IMaterialType中的方法

        /// <summary>
        /// 获取物料类型信息
        /// </summary>
        /// <returns>物料类型信息</returns>
        public IList<MaterialTypeInfo> GetMaterialTypeInfo()
        {
            IList<MaterialTypeInfo> materialTypeList = new List<MaterialTypeInfo>();
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_MATERIAL_TYPE_INFO,null))
            {
                while (odr.Read())
                {
                    int? materialTypeId = Convert.ToInt32(odr["MATERIAL_TYPE_ID"]);
                    string materialTypeName = odr["MATERIAL_TYPE_NAME"].ToString();
                    MaterialTypeInfo item = new MaterialTypeInfo(materialTypeId, materialTypeName);
                    materialTypeList.Add(item);
                }
            }
            return materialTypeList;
        }

        #endregion

    }
}
