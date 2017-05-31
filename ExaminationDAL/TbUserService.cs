using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;

namespace ExaminationDAL
{
    public class TbUserService
    {
        /// <summary>
        /// 用户登录,返回当前用户的身份
        /// </summary>
        /// <param name="user">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public int Login(string user, string pwd)
        {
            string sql = "select Zt from tbUser where (YhName=@user or Xh=@user) and YhPwd=@pwd";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@user",user),
                    new SqlParameter("@pwd",pwd)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 添加用户(管理员，老师，学员),返回当前添加后的标识符
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(TbUser user)
        {
            string sql = "insert into tbUser(YhName,Xh,YhPwd,Zt)values(@YhName,@Xh,@YhPwd,@Zt);select @@IDENTITY";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@YhName",user.YhName),
                    new SqlParameter("@Xh",user.Xh),
                    new SqlParameter("@YhPwd",user.YhPwd),
                    new SqlParameter("@Zt",user.Zt)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 删除所有学员用户登录信息
        /// </summary>
        /// <returns></returns>
        public int DeleteAllStuUser()
        {
            string sql = "delete from tbUser where Zt=3";
            return DBHelper.ExecuteCommand(sql);
        }
        /// <summary>
        /// 根据ID删除用户信息
        /// </summary>
        /// <param name="id">YhID</param>
        /// <returns></returns>
        public int DeleteStuByID(int id)
        {
            string sql = "delete from tbUser where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@YhID",id)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }

        /// <summary>
        /// 根据相应信息查找对应用户是否存在
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>返回对应用户的个数</returns>
        public int SeeUser(TbUser user)
        {
            string Sql_Select = "select count(*) from tbUser where YhName=@YhName or Xh=@Xh";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@YhName",user.YhName),
                    new SqlParameter("@Xh",user.Xh)
            };
            return DBHelper.GetScalar(Sql_Select, paras);
        }
        /// <summary>
        /// 根据教师编号获取该教师的用户编号YhID
        /// </summary>
        /// <param name="LsID">教师编号</param>
        /// <returns></returns>
        public int GetTeacherUserYhID(int LsID)
        {
            /*根据教师编号获取该教师的用户编号YhID*/
            string sql1 = "select YhID from tbUser where YhID in (select YhID from tbTeacher where LsID=@LsID )";
            SqlParameter[] paras1 = new SqlParameter[] { new SqlParameter("@LsID", LsID) };
            return DBHelper.GetScalar(sql1, paras1);
        }
        /// <summary>
        /// 根据用户编号删除教师用户信息
        /// </summary>
        /// <param name="LsID">教师用户编号</param>
        /// <returns></returns>
        public int DeleteUserByYhID(int yhid)
        {
            /*根据教师的用户编号删除教师的用户信息*/
            string sql3 = "delete from tbUser where YhID =@yhid";
            SqlParameter[] paras3 = new SqlParameter[] { new SqlParameter("@yhid", yhid) };
            return DBHelper.ExecuteCommand(sql3, paras3);
        }
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
        /// 新增教师用户信息，返回标识列
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
        /// 根据用户ID查找对应的用户详细信息
        /// </summary>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public TbUser GetAllUser(int YhID)
        {
            TbUser user = null;
            string Sql_Select = "select * from dbo.tbUser where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@YhID",YhID)
            };
            SqlDataReader reader = DBHelper.GetReader(Sql_Select, paras);
            if (reader.Read())
            {
                user = new TbUser();
                user.YhID = YhID;
                user.YhName = reader["YhName"].ToString();
                user.Xh = reader["Xh"].ToString();
                user.YhPwd = reader["YhPwd"].ToString();
                reader.Close();
            }
            return user;
        }
        /// <summary>
        /// 根据学号或者用户名查找用户ID
        /// </summary>
        /// <param name="Xh">学号</param>
        /// <returns></returns>
        public int GetStudentID(string Xh)
        {
            string Sql_Select = "select YhID from tbUser where (Xh=@Xh or YhName=@Xh)";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@Xh",Xh)
            };
            return DBHelper.GetScalar(Sql_Select, paras);
        }
        /// <summary>
        /// 根据用户ID修改User表
        /// </summary>
        /// <param name="user">User对象</param>
        /// <returns></returns>
        public int SetUser(TbUser user)
        {
            string Sql_Update = "update tbUser set Xh=@Xh where YhID=@YhID";
            SqlParameter[] paras = new SqlParameter[]
            {
            new SqlParameter("@Xh",user.Xh),
             new SqlParameter("@YhID",user.YhID)
            };
            return DBHelper.ExecuteCommand(Sql_Update, paras);
        }

        /// <summary>
        /// 根据用户编号获得用户的详细信息-
        /// </summary>
        /// <param name="yhid">用户编号</param>
        /// <returns></returns>
        public TbUser GetUserInfoByYhID(int yhid)
        {
            string sql = "select * from tbUser where YhID=@yhid";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@yhid",yhid)};
            TbUser user = null;
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                user = new TbUser();
                user.YhID = yhid;
                user.YhName = reader["YhName"].ToString();
                user.YhPwd = reader["YhPwd"].ToString();
                user.Zt = int.Parse(reader["Zt"].ToString());
                reader.Close();
            }
            return user;
        }
        /// <summary>
        /// 查询是否存在对应的用户信息
        /// </summary>
        /// <param name="YhName"></param>
        /// <returns>返回用户编号YhID</returns>
        public int SelectUserYhName(string YhName)
        {
            string sql = "select YhID from tbUser where YhName=@YhName";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@YhName",YhName)};
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 根据用户编号修改教师用户的角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserRoleByYhID(TbUser user)
        {
            string sql = "update tbUser set Zt=@zt where YhID=@yhid";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@zt",user.Zt),
            new SqlParameter("@yhid",user.YhID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
