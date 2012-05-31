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
    public class Classes : IClasses
    {
        #region SQL AND  PARAM
        private const string SQL_SELECT_ALL_CLASSES = "SELECT CLASS_ID,CLASS_HEADER FROM TB_SYS_CLASS_INFO";

        private const string SQL_SELECT_CLASS_BY_ID = "SELECT CLASS_ID,CLASS_HEADER FROM TB_SYS_CLASS_INFO WHERE CLASS_ID=:CLASS_ID";

        private const string SQL_INSERT_CLASS = "INSERT INTO TB_SYS_CLASS_INFO(CLASS_ID,CLASS_HEADER) VALUES(:CLASS_ID,:CLASS_HEADER)";

        private const string SQL_DELETE_CLASS = "DELETE FROM TB_SYS_CLASS_INFO WHERE CLASS_ID =:CLASS_ID";

        private const string SQL_UPDATE_CLASS = "UPDATE TB_SYS_CLASS_INFO SET CLASS_HEADER=:CLASS_HEADER WHERE CLASS_ID=:CLASS_ID";

        private const string PARAM_CLASS_ID = ":CLASS_ID";
        private const string PARAM_CLASS_HEADER = ":CLASS_HEADER";
        #endregion

        #region Methods
        /// <summary>
        /// 获取所有班组信息
        /// </summary>
        /// <returns>所有班组信息</returns>
        public IList<ClassesInfo> GetAllClasses()
        {
            IList<ClassesInfo> classes = new List<ClassesInfo>();

            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_ALL_CLASSES,null))
            {
                while (odr.Read())
                {
                    string classId = odr[0].ToString();
                    string classHeader =odr[1]==DBNull.Value?null:odr[1].ToString();
                    ClassesInfo cls = new ClassesInfo(classId, classHeader);
                    classes.Add(cls);
                }
            }
            return classes;
        }

        /// <summary>
        /// 根据班组名称获取班组信息
        /// </summary>
        /// <param name="classId">班组名</param>
        /// <returns>班组信息</returns>
        public ClassesInfo GetClassInfo(string classId)
        {
            ClassesInfo cls = null;
            OracleParameter[] param = new OracleParameter[1];
            param[0]=new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[0].Value = classId;
            using (OracleDataReader odr=OracleHelper.ExecuteReader(OracleHelper.LFDBUSERConnectionString,CommandType.Text,SQL_SELECT_CLASS_BY_ID,param))
            {
                while (odr.Read())
                {
                    string classHeader = odr["CLASS_HEADER"] == DBNull.Value ? null : odr[1].ToString();
                    cls = new ClassesInfo(classId, classHeader);
                }
            }
            return cls;
            
        }


        /// <summary>
        /// 插入指定的班组信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void InsertClassInfo(ClassesInfo cls)
        {
            OracleParameter[] param = new OracleParameter[2];

            param[0] = new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[0].Value = cls.ClassId;
            param[1] = new OracleParameter(PARAM_CLASS_HEADER, OracleType.VarChar);
            param[1].Value = cls.ClassHeader;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_INSERT_CLASS, param);
        }


        /// <summary>
        /// 更新指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void UpdateClassInfo(ClassesInfo cls)
        {
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter(PARAM_CLASS_HEADER, OracleType.VarChar);
            param[0].Value = cls.ClassHeader;
            param[1] = new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[1].Value = cls.ClassId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_UPDATE_CLASS, param);
        }

        /// <summary>
        /// 删除指定班组的信息
        /// </summary>
        /// <param name="cls">班组信息</param>
        public void DeleteClassInfo(ClassesInfo cls)
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter(PARAM_CLASS_ID, OracleType.VarChar);
            param[0].Value = cls.ClassId;

            OracleHelper.ExecuteNonQuery(OracleHelper.LFDBUSERConnectionString, CommandType.Text, SQL_DELETE_CLASS, param);
        }
        #endregion
    }
}
