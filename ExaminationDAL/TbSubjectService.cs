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
    public class TbSubjectService
    {

        /// <summary>
        /// 返回科目列表
        /// </summary>
        /// <param name="len">页面显示的科目信息条数</param>
        /// <param name="apge">当前页数</param>
        /// <returns></returns>
        public DataTable GetSubject(int len, int apge, string ZyName)
        {
            apge--;
            StringBuilder Str_Bu = new StringBuilder();
            Str_Bu.Append("select top " + len + " Su.KmID,Su.KmName,Su.Remark,Sp.ZyName from tbSubject as Su,tbSpeciality as Sp");
            Str_Bu.Append(" where Su.ZyID=Sp.ZyID and KmID not in(select top " + len * apge + " KmID from tbSubject) and Sp.ZyName like '%" + ZyName + "%' order by KmID");
            return DBHelper.GetDataTable(Str_Bu.ToString());
        }
        public DataTable GetSubject(string ZyName)
        {
            StringBuilder Str_Bu = new StringBuilder();
            Str_Bu.Append("select Su.KmID,Su.KmName,Su.Remark,Sp.ZyName from tbSubject as Su,tbSpeciality as Sp");
            Str_Bu.Append(" where Su.ZyID=Sp.ZyID and Sp.ZyName like '%" + ZyName + "%' order by KmID");
            return DBHelper.GetDataTable(Str_Bu.ToString());
        }

        /// <summary>
        /// 删除相应ID的科目信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns>返回受影响的行数</returns>
        public int Dele_Sub(int KmID)
        {
            string Sql_Delete = "delete from tbSubject where KmID=@KmID";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@KmID",KmID)
            };
            return DBHelper.GetScalar(Sql_Delete, paras);
        }
        /// <summary>
        /// 查询科目表数据条数
        /// </summary>
        /// <returns></returns>
        public int GetSubCount(string Txt_ZyName)
        {
            string Sql_Select = "";
            if (Txt_ZyName == "")
            {
                Sql_Select = "select count(*) from tbSubject ";
            }
            else
            {
                Sql_Select = "select count(*) from tbSubject where ZyID in ( select ZyID from tbSpeciality where ZyName like '%" + Txt_ZyName + "%')";
            }
            return DBHelper.GetScalar(Sql_Select);
        }
        /// <summary>
        /// 获取所有科目列表
        /// </summary>
        /// <returns></returns>
        public List<TbSubject> GetAllSubjectList()
        {
            List<TbSubject> SpecialityList = new List<TbSubject>();
            TbSubject sbt = null;
            string sql = "select * from tbSubject";
            SqlDataReader reader = DBHelper.GetReader(sql);
            while (reader.Read())
            {
                sbt = new TbSubject();
                sbt.KmID = (int)reader["KmID"];
                sbt.KmName = reader["KmName"].ToString();
                sbt.ZyID = (int)reader["ZyID"];
                sbt.Remark = reader["Remark"].ToString();
                SpecialityList.Add(sbt);
            }
            reader.Close();
            return SpecialityList;
        }
        /// <summary>
        /// 根据专业绑定科目信息
        /// </summary>
        /// <param name="zyid"></param>
        /// <returns></returns>
        public List<TbSubject> GetSubjectListByZyId(int zyid)
        {
            List<TbSubject> SpecialityList = new List<TbSubject>();
            TbSubject sbt = null;
            string sql = "select * from tbSubject where ZyID=@zyid";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@zyid",zyid)
            };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            while (reader.Read())
            {
                sbt = new TbSubject();
                sbt.KmID = (int)reader["KmID"];
                sbt.KmName = reader["KmName"].ToString();
                sbt.ZyID = (int)reader["ZyID"];
                sbt.Remark = reader["Remark"].ToString();
                SpecialityList.Add(sbt);
            }
            reader.Close();
            return SpecialityList;
        }
        /// <summary>
        /// 查询科目信息
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <returns>返回满足条件的数据行数</returns>
        public int seeSujectcount(TbSubject subject)
        {
            string sql = "select count(*) from tbSubject where KmName=@KmName";
            SqlParameter[] paras = new SqlParameter[]{
                    new SqlParameter("@KmName",subject.KmName)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 新增科目信息
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <param name="Remark">备注</param>
        /// <param name="ZyID">专业ID</param>
        /// <returns>返回受影响的行数</returns>
        public int addSubject(TbSubject subject)
        {
            string sql = "insert into tbSubject values(@KmName,@Remark,@ZyID)";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KmName",subject.KmName),
                    new SqlParameter("@Remark",subject.Remark),
                    new SqlParameter("@ZyID",subject.ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 根据专业ID删除对应的科目信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public int DeleteSubByZyID(int ZyID)
        {
            string sql = "delete from tbSubject where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 根据专业ID查询受影响的行数
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public int QuerySubjectInfo(int ZyID)
        {
            string sql = "select * from dbo.tbSubject where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 根据科目ID查找对应科目信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns></returns>
        public TbSubject GetSubjectByID(int KmID)
        {
            TbSubject subject = null;
            string Sql_Select = "select * from tbSubject where KmID=@KmID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KmID",KmID)
            };
            SqlDataReader reader = DBHelper.GetReader(Sql_Select, paras);
            if (reader.Read())
            {
                subject = new TbSubject();
                subject.KmID = (int)reader["KmID"];
                subject.KmName = reader["KmName"].ToString();
                subject.Remark = reader["Remark"].ToString();
                subject.ZyID = (int)reader["ZyID"];
            }
            return subject;
        }
        /// <summary>
        /// 根据科目名称查询科目ID
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <returns></returns>
        public int GetSubjectByKmName(string KmName, int ZyID)
        {
            string Sql_Select = "select KmID from tbsubject where KmName=@KmName and ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KmName",KmName),
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.GetScalar(Sql_Select, paras);
        }


        /// <summary>
        /// 修改对应科目ID的信息并返回对应的专业ID
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public void Get_SubjectBy(TbSubject subject)
        {
            string Sql_Update = "update tbSubject set KmName=@KmName,Remark=@Remark,ZyID=@ZyID where KmID=@KmID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KmName",subject.KmName),
                    new SqlParameter("@Remark",subject.Remark),
                    new SqlParameter("@ZyID",subject.ZyID),
                    new SqlParameter("@KmID",subject.KmID)
            };
            DBHelper.ExecuteCommand(Sql_Update, paras);
        }
        /// <summary>
        /// 根据专业ID返回科目列表
        /// </summary>
        /// <param name="zyid">专业ID</param>
        /// <returns></returns>
        public DataTable GetSubjectListByZyid(int zyid)
        {
            string sql = "select KmID,KmName,ZyID from tbSubject where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",zyid)
            };
            return DBHelper.GetDataTable(sql, paras);
        }
    }
}
