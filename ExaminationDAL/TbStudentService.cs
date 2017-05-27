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
    public class TbStudentService
    {
        /// <summary>
        /// 查询班级表数据条数
        /// </summary>
        /// <returns></returns>
        public int GetStuCount()
        {
            string Sql_Select = "select count(*) from tbStudent ";
            return DBHelper.GetScalar(Sql_Select);
        }

        /// <summary>
        /// 添加学员信息，返回当前标示符
        /// </summary>
        /// <param name="stu">当前添加学员信息</param>
        /// <returns></returns>
        public int AddStudent(TbStudent stu)
        {
            string sql = "insert into tbStudent(XsName,XsSex,YhID,BjName,Remark)values(@XsName,@XsSex,@YhID,@BjName,@Remark)select @@IDENTITY";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@XsName",stu.XsName),
                    new SqlParameter("@XsSex",stu.XsSex),
                    new SqlParameter("@YhID",stu.YhID),
                    new SqlParameter("@BjName",stu.BjName),
                    new SqlParameter("@Remark",stu.Remark)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 删除所有学员用户信息
        /// </summary>
        /// <returns></returns>
        public int DeleteAllStu()
        {
            string sql = "delete from tbStudent";
            return DBHelper.ExecuteCommand(sql);
        }

        /// <summary>
        /// 根据用户ID删除学生信息
        /// </summary>
        /// <param name="yuid">用户ID</param>
        /// <returns></returns>
        public int DeleteStuByYuID(int yuid)
        {
            int num = 0;
            string sql = "delete from tbStudent where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@YhID",yuid)
            };
            //学员信息表删除成功后同时删除用户信息表对应数据
            if (DBHelper.ExecuteCommand(sql, paras) > 0)
                num = new TbUserService().DeleteStuByID(yuid);
            return num;

        }

        /// <summary>
        /// 查询所有学员信息，关联TbUser表，供导出学员信息使用
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllStuInfo()
        {
            StringBuilder sqlsb = new StringBuilder();
            sqlsb.Append("select s.XsName as '姓名',s.XsSex as '性别',s.BjName as '班级'");
            sqlsb.Append(",u.Xh as '学号',u.YhName as '用户名',u.YhPwd as '密码',s.Remark as '备注'");
            sqlsb.Append(" from tbUser as u,tbStudent as s where s.YhID=u.YhID");
            return DBHelper.GetDataTable(sqlsb.ToString());
        }

        /// <summary>
        /// 分页查询学生信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <param name="BjName">班级名称</param>
        /// <returns></returns>
        public DataTable GetAllStuInfo(int len, int page, string BjName)
        {
            page--;
            StringBuilder sqlsb = new StringBuilder();
            sqlsb.Append("select top  " + len + "u.YhID, s.XsName as '姓名',s.XsSex as '性别',s.BjName as '班级'");
            sqlsb.Append(",u.Xh as '学号',u.YhName as '用户名',u.YhPwd as '密码',s.Remark as '备注'");
            sqlsb.Append(" from tbUser as u,tbStudent as s where s.YhID=u.YhID");
            sqlsb.Append(" and s.XsID not in(select top " + len * page + " XsID from tbStudent) and (BjName like '%" + BjName + "%' or XsName like '%" + BjName + "%' or Xh like '%" + BjName + "%' or YhName like '%" + BjName + "%')");
            return DBHelper.GetDataTable(sqlsb.ToString());
        }

        public DataTable GetAllStuInfo(string BjName)
        {
            StringBuilder sqlsb = new StringBuilder();
            sqlsb.Append("select ");
            sqlsb.Append("*");
            sqlsb.Append(" from tbStudent,tbUser where tbStudent.YhID=tbUser.YhID and");
            sqlsb.Append(" (BjName like '%" + BjName + "%' or XsName like '%" + BjName + "%' or Xh like '%" + BjName + "%' or YhName like '%" + BjName + "%')");
            return DBHelper.GetDataTable(sqlsb.ToString());
        }
        /// <summary>
        ///  根据用户ID返回对应详细信息
        /// </summary>
        /// <param name="ZyID">用户ID</param>
        /// <returns></returns>
        public TbStudent GetStudentByID(int YhID)
        {
            TbStudent student = null;
            string sql = "select * from tbStudent where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[] {
                   new SqlParameter("@YhID",YhID)
            };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                student = new TbStudent();
                student.YhID = YhID;
                student.XsName = reader["XsName"].ToString();
                student.Remark = reader["Remark"].ToString();
                student.XsSex = reader["XsSex"].ToString();
                student.BjName = reader["BjName"].ToString();
                reader.Close();
            }
            return student;
        }
        /// <summary>
        /// 根据用户ID修改学生信息
        /// </summary>
        /// <param name="stu">学生对象</param>
        /// <returns></returns>
        public int SetStudent(TbStudent stu)
        {
            string Sql_update = "update tbStudent set XsName=@XsName,XsSex=@XsSex,BjName=@BjName,Remark=@Remark where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@XsName",stu.XsName),
                    new SqlParameter("@XsSex",stu.XsSex),
                    new SqlParameter("@BjName",stu.BjName),
                    new SqlParameter("@YhID",stu.YhID),
                    new SqlParameter("@Remark",stu.Remark)
            };
            return DBHelper.ExecuteCommand(Sql_update, paras);
        }
    }
}
