using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;
using System.Data.SqlClient;
using System.Data;

namespace ExaminationDAL
{
    public class TbClassService
    {

        /// <summary>
        /// 添加班级信息
        /// </summary>
        /// <param name="BjName">班级名称</param>
        /// <param name="Nj">年级</param>
        /// <param name="ZyID">专业名</param>
        /// <param name="Xz">学制</param>
        /// <param name="Bz">备注</param>
        /// <returns>Sql语句执行后返回受影响的行数</returns>
        public int AddClass(string BjName, string Nj, int ZyID)
        {

            string Sql_Insert = "insert into TbClass(BjName,Nj,ZyID) values(@BjName,@Nj,@ZyID)";
            SqlParameter[] paras2 = new SqlParameter[]{
                new SqlParameter("@BjName",BjName),
                new SqlParameter("@Nj",Nj),
                new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.ExecuteCommand(Sql_Insert, paras2);
        }
        /// <summary>
        /// //查找专业表对应的专业ID
        /// </summary>
        /// <param name="Zy">专业名称</param>
        /// <returns>专业ID</returns>
        public int Sel_ZyID(string Zy)
        {
            string Sql_Select = "select ZyID from tbSpeciality where ZyName=@Zy ";
            SqlParameter[] paras1 = new SqlParameter[]{
                new SqlParameter("@Zy",Zy)
              };
            return DBHelper.GetScalar(Sql_Select, paras1);
        }

        /// <summary>
        /// 根据班级名和年级查找对应的信息
        /// </summary>
        /// <param name="BjName">班级名</param>
        /// <param name="Nj">年级</param>
        /// <returns>返回对应的班级列表</returns>
        public DataTable Sel_Bj(string BjName, string Nj)
        {
            string Sql_Select = "select * from TbClass where BjName=@BjName and Nj=@Nj";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@BjName",BjName),
                new SqlParameter("@Nj",Nj)
            };
            return DBHelper.GetDataTable(Sql_Select, paras);
        }

        public SqlDataReader Sel_Zy()
        {
            string Sql_Select = "select distinct ZyName from tbSpeciality";
            return DBHelper.GetReader(Sql_Select);
        }

        /// <summary>
        /// 返回当前页的班级列表信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public DataTable GetAllClassInfoPage(int len, int page)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " c.BjID , c.BJName,c.Nj,s.ZyName from tbClass as c,tbSpeciality as s");
            sbsql.Append(" where c.ZyID=s.ZyID and c.BjID not in(select top " + len * page + " BjID from tbClass)");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据条件模糊查询当前页的班级列表信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <param name="name">班级名、年级名、专业名</param>
        /// <returns></returns>
        public DataTable GetAllClassInfoPage(int len, int page, string name)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " c.BjID , c.BJName,c.Nj,s.ZyName from tbClass as c,tbSpeciality as s");
            sbsql.Append(" where c.ZyID=s.ZyID and c.BjID not in(select top " + len * page + " BjID from tbClass)");
            sbsql.Append(" and( BjName like '%" + name + "%' or Nj like '%" + name + "%' or ZyName like '%" + name + "%')");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 获取所有班级列表
        /// </summary>
        /// <returns></returns>
        public List<TbClass> GetAllClassList()
        {
            List<TbClass> ClassList = new List<TbClass>();
            TbClass sbt = null;
            string sql = "select * from TbClass";
            SqlDataReader reader = DBHelper.GetReader(sql);
            while (reader.Read())
            {
                sbt = new TbClass();
                sbt.Nj = reader["Nj"].ToString();
                sbt.BjName = reader["BjName"].ToString();
                sbt.ZyID = (int)reader["ZyID"];
                ClassList.Add(sbt);
            }
            reader.Close();
            return ClassList;
        }
        /// <summary>
        /// 根据专业ID删除对应班级信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public int DeleteClassByZyID(int ZyID)
        {
            string sql = "delete from tbClass where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 返回当前班级列表信息的记录总数
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllClassInfo(string ClassNameOrNj)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select BjID,BjName,Remark,s.ZyName from tbClass as c,tbSpeciality as s  where c.ZyID=s.ZyID and( BjName like ");
            sbSql.Append("'%" + ClassNameOrNj + "%' or Nj like '%" + ClassNameOrNj + "%' or ZyName like '%" + ClassNameOrNj + "%')");
            return DBHelper.GetDataTable(sbSql.ToString());
        }
        /// <summary>
        /// 根据班级编号删除对应的班级信息
        /// </summary>
        /// <param name="BjID">班级编号</param>
        /// <returns></returns>
        public int DeleteClassInfo(int BjID)
        {
            string sql = " delete from tbClass where BjID=@BjID";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@BjID", BjID) };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 查询所有班级信息
        /// </summary>
        /// <returns></returns>
        public DataTable QuerySubjectInfo()
        {
            string sql = "select * from dbo.tbClass";
            return DBHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 根据班级ID返回对应详细详细
        /// </summary>
        /// <param name="BjID">班级ID</param>
        /// <returns></returns>
        public TbClass GetClassByID(int BjID)
        {
            TbClass Class = null;
            string sql = "select * from dbo.tbClass where BjID=@BjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@BjID",BjID)
            };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                Class = new TbClass();
                Class.BjID = BjID;
                Class.BjName = reader["BjName"].ToString();
                Class.Nj = reader["Nj"].ToString();
                Class.ZyID = int.Parse(reader["ZyID"].ToString());
                reader.Close();
            }
            return Class;
        }
        /// <summary>
        /// 根据班级ID修改其对应的班级信息
        /// </summary>
        /// <param name="Class">班级对象</param>
        /// <returns></returns>
        public int EditClassByID(TbClass Class)
        {
            string sql = "update dbo.tbClass set BjName=@BjName,Nj=@Nj,ZyID=@ZyID where BjID=@BjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@BjName",Class.BjName),
                    new SqlParameter("@Nj",Class.Nj),
                    new SqlParameter("@ZyID",Class.ZyID),
                    new SqlParameter("@BjID",Class.BjID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
