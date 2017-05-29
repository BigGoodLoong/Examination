using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ExaminationModels;
using System.Data;
namespace ExaminationDAL
{
    public class TbTeacherService
    {

        /// <summary>
        /// 新增教师信息，返回输入的账户是否原已存在
        /// </summary>
        /// <param name="user">用户名</param>
        /// <returns></returns>
        public int CheckTeacherUser(string user)
        {
            string sql = "select Zt from tbUser where (YhName=@user)";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@user", user) };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 新增教师用户信息
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="xh">学号</param>
        /// <param name="pwd">密码</param>
        /// <param name="zt">状态</param>
        /// <returns></returns>
        public int InsertTeacherUser(string user, string xh, string pwd, int zt)
        {

            string sql = "insert into tbUser values(@user,@xh,@pwd,@zt);select @@IDENTITY";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter("@user",user),
            new SqlParameter("@xh",xh),
            new SqlParameter("@pwd",pwd),
             new SqlParameter("@zt",zt)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 获取教师所教专业的专业ID
        /// </summary>
        /// <param name="zy">专业</param>
        /// <returns></returns>
        public int GetTeacherZyID(string zy)
        {
            string sql = "select ZyID from tbSpeciality where (ZyName=@zy)";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@zy", zy) };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 新增教师信息
        /// </summary>
        /// <param name="yhid">用户ID</param>
        /// <param name="name">教师姓名</param>
        /// <param name="zyid">专业ID</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public int InsertTeacherInfo(int yhid, string name, int zyid, string remark)
        {
            string sql = "insert into tbTeacher values(@yhid,@name,@zyid,@remark)";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@yhid",yhid),
                new SqlParameter("@name",name),
                new SqlParameter("@zyid",zyid),
                new SqlParameter("@remark",remark)
            };
            return DBHelper.ExecuteCommand(sql, paras);

        }
        /// <summary>
        /// 返回当前教师列表信息的记录总数
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTeachersInfo(string lsname)
        {
            //string sql = "select * from tbTeacher where  LsName like '%" + lsname + "%'";
            //return DBHelper.GetDataTable(sql);
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select * from tbTeacher,tbSpeciality,tbUser where tbTeacher.ZyID=tbSpeciality.ZyID and ");
            sbsql.Append("  tbTeacher.YhID=tbUser.YhID and ");
            sbsql.Append(" (LsName like '%" + lsname + "%' or ZyName like '%" + lsname + "%' or YhName like '%" + lsname + "%')");
            return DBHelper.GetDataTable(sbsql.ToString());
        }

        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public DataTable GetAllTeacherInfoPage(int len, int page, string lsname)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " t.LsID ,t.LsName ,t.YhID ,");
            sbsql.Append("  u.YhName ,u.YhPwd ,s.ZyName,t.Remark");
            sbsql.Append(" from tbTeacher as t,tbUser as u,tbSpeciality as s");
            sbsql.Append("  where t.YhID=u.YhID and t.ZyID=s.ZyID and LsID not in(select top " + len * page + " LsID from tbTeacher)");
            sbsql.Append(" and ( LsName like '%" + lsname + "%' or YhName like '%" + lsname + "%' or ZyName like '%" + lsname + "%')");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据专业ID删除对应老师信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public int DeleteTeaByZyID(int ZyID)
        {
            string sql = "delete from tbTeacher where ZyID=@ZyID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZyID",ZyID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 根据教师编号LsID删除对应的教师信息
        /// </summary>
        /// <param name="LsID">教师编号</param>
        /// <returns></returns>
        public int DeleteTeacherInfo(int LsID)
        {
            /*根据教师编号删除教师信息*/
            string sql2 = "delete from tbTeacher where LsID=@LsID ";
            SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@LsID", LsID) };
            return DBHelper.ExecuteCommand(sql2, paras2);
        }
        /// <summary>
        /// 根据教师的用户编号获取教师的详细信息
        /// </summary>
        /// <param name="YhID">用户编号</param>
        /// <returns></returns>
        public TbTeacher GetTeacherInfoByLsID(int Yhid)
        {
            TbTeacher teacher = null;
            string sql = "select * from tbTeacher where YhID=@Yhid";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@YhId", Yhid) };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                teacher = new TbTeacher();
                teacher.YhID = Yhid;
                teacher.LsID = int.Parse(reader["LsID"].ToString());
                teacher.LsName = reader["LsName"].ToString();
                teacher.ZyID = int.Parse(reader["ZyID"].ToString());
                teacher.Remark = reader["Remark"].ToString();
                reader.Close();
            }
            return teacher;
        }
        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacher">修改后的教师信息</param>
        /// <returns></returns>
        public int UpdateTeacherInfoByYhID(TbTeacher teacher)
        {
            string sql = "update tbTeacher set LsName=@name,ZyID=@zyid,Remark=@remark where YhID=@Yhid";
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@name",teacher.LsName),
                new SqlParameter("@zyid",teacher.ZyID),
                new SqlParameter("@remark",teacher.Remark),
                 new SqlParameter("@Yhid",teacher.YhID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
