using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;
using System.Data;

namespace ExaminationDAL
{
    public class TbSpecialityService
    {
        /// <summary>
        /// 获取所有专业列表
        /// </summary>
        /// <returns></returns>
        public List<TbSpeciality> GetAllSpecialityList()
        {
            List<TbSpeciality> subjectList = new List<TbSpeciality>();
            TbSpeciality sbt = null;
            string sql = "select * from tbSpeciality";
            SqlDataReader reader = DBHelper.GetReader(sql);
            while (reader.Read())
            {
                sbt = new TbSpeciality();
                sbt.ZyName = reader["ZyName"].ToString();
                sbt.ZyID = (int)reader["ZyID"];
                sbt.Remark = reader["Remark"].ToString();
                subjectList.Add(sbt);
            }
            reader.Close();
            return subjectList;
        }
        /// <summary>
        /// 根据当前已有成绩获取对应所有专业列表
        /// </summary>
        /// <returns></returns>
        public List<TbSpeciality> GetAllSpecialityListByScore()
        {
            List<TbSpeciality> subjectList = new List<TbSpeciality>();
            TbSpeciality sbt = null;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select * from tbSpeciality where ZyID in (select ZyID from tbSubject where KmID in (select KmID from tbTestPaper ");
            sbsql.Append(" where SjID in (select SjID from tbObjTopic where KgtID in(select KgtID from tbScore))))");
            SqlDataReader reader = DBHelper.GetReader(sbsql.ToString());
            while (reader.Read())
            {
                sbt = new TbSpeciality();
                sbt.ZyName = reader["ZyName"].ToString();
                sbt.ZyID = (int)reader["ZyID"];
                sbt.Remark = reader["Remark"].ToString();
                subjectList.Add(sbt);
            }
            reader.Close();
            return subjectList;
        }
        /// <summary>
        /// 新增专业信息
        /// </summary>
        /// <param name="ZyName">专业名称</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回受影响的行数</returns>
        public int addSpeciality(string ZyName, string Remark)
        {
            string sql = "insert into dbo.tbSpeciality values(@ZyName,@Remark)";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyName",ZyName),
                    new SqlParameter("@Remark",Remark)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }


        /// <summary>
        /// 查询专业信息
        /// </summary>
        /// <param name="ZyName">专业名称</param>
        /// <returns>返回符合条件的专业ID</returns>
        public int seeSpecialityID(string ZyName)
        {
            string sql = "select ZyID from dbo.tbSpeciality where ZyName=@ZyName";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyName",ZyName)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 根据专业名模糊查询专业信息
        /// </summary>
        /// <param name="len">页面显示行数</param>
        /// <param name="Page">页号</param>
        /// <param name="specName">专业名</param>
        /// <returns></returns>
        public DataTable GetAllSpecialityinfo(int len, int Page, string specName)
        {
            Page--;
            StringBuilder sqlSb = new StringBuilder();
            sqlSb.Append("select top " + len + " ZyID,ZyName,Remark from dbo.tbSpeciality ");
            sqlSb.Append("where ZyID not in (select top " + len * Page + " ZyID from dbo.tbSpeciality)");
            sqlSb.Append(" and ZyName like '%" + specName + "%'");
            return DBHelper.GetDataTable(sqlSb.ToString());
        }
        /// <summary>
        ///  根据专业名模糊查询所有专业信息
        /// </summary>
        /// <param name="specName"></param>
        /// <returns></returns>
        public DataTable GetAllSpecialityinfo(string specName)
        {
            StringBuilder sqlSb = new StringBuilder();
            sqlSb.Append("select  ZyID,ZyName,Remark from dbo.tbSpeciality");
            sqlSb.Append(" where ZyName like '%" + specName + "%'");
            return DBHelper.GetDataTable(sqlSb.ToString());
        }
        /// <summary>
        /// 根据专业ID删除对应专业信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public int DeleteSpecByZyID(int ZyID)
        {
            string sql = "delete from tbSpeciality where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                   new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        ///  根据专业ID返回对应详细信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public TbSpeciality GetSpecialByID(int ZyID)
        {
            TbSpeciality spec = null;
            string sql = "select * from tbSpeciality where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                   new SqlParameter("@ZyID",ZyID)
            };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                spec = new TbSpeciality();
                spec.ZyID = ZyID;
                spec.ZyName = reader["ZyName"].ToString();
                spec.Remark = reader["Remark"].ToString();
                reader.Close();
            }
            return spec;
        }
        /// <summary>
        /// 根据专业ID修改专业信息
        /// </summary>
        /// <param name="spec">专业对象</param>
        /// <returns></returns>
        public int EditSpecByID(TbSpeciality spec)
        {
            string sql = "update tbSpeciality set ZyName=@ZyName,Remark=@Remark where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyName",spec.ZyName),
                    new SqlParameter("@Remark",spec.Remark),
                    new SqlParameter("@ZyID",spec.ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 绑定专业信息下拉框
        /// </summary>
        /// <returns></returns>
        public DataTable BangdingZy()
        {
            string sql = "select ZyID,ZyName from tbSpeciality";
            return DBHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 根据专业ID返回对应的专业名称
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public string GetSpecialityName(int ZyID)
        {
            string sql = "select ZyName from dbo.tbSpeciality where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.GetScalarByString(sql, paras);
        }
    }
}
