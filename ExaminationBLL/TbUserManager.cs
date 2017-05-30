using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL;
using ExaminationModels;

namespace ExaminationBLL
{
    public class TbUserManager
    {
        static TbUserService tbuserservice = new TbUserService();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public static int Login(string user, string pwd)
        {
            return tbuserservice.Login(user, pwd);
        }
        /// <summary>
        /// 添加用户(管理员，老师，学员),返回当前添加后的标识符
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AddUser(TbUser user)
        {
            return tbuserservice.AddUser(user);
        }
        /// <summary>
        /// 删除所有学生用户
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllStuUser()
        {
            return tbuserservice.DeleteAllStuUser();
        }
        /// <summary>
        /// 根据ID删除用户信息
        /// </summary>
        /// <param name="id">YhID</param>
        /// <returns></returns>
        public static int DeleteStuByID(int id)
        {
            return tbuserservice.DeleteStuByID(id);
        }

        /// <summary>
        /// 根据相应信息查找对应用户是否存在
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <returns>返回对应用户的个数</returns>
        public static int SeeUser(TbUser user)
        {
            return tbuserservice.SeeUser(user);
        }
        /// <summary>
        /// 新增教师用户信息，返回标识列
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="xh">学号</param>
        /// <param name="pwd">密码</param>
        /// <param name="zt">状态</param>
        /// <returns></returns>
        public static int InsertTeacherUser(string user, string xh, string pwd, int zt)
        {
            return tbuserservice.InsertTeacherUser(user, xh, pwd, zt);
        }
        /// <summary>
        /// 根据教师编号获取该教师的用户编号YhID
        /// </summary>
        /// <param name="LsID">教师编号</param>
        /// <returns></returns>
        public static int GetTeacherUserYhID(int LsID)
        {
            return tbuserservice.GetTeacherUserYhID(LsID);
        }
        /// <summary>
        /// 根据教师编号LsID删除对应的教师用户信息
        /// </summary>
        /// <param name="LsID">教师编号</param>
        /// <returns></returns>
        public static int DeleteUserByYhID(int yhid)
        {
            return tbuserservice.DeleteUserByYhID(yhid);
        }
        /// <summary>
        /// 新增教师信息
        /// </summary>
        /// <param name="user">账号</param>
        /// <returns></returns>
        public static int CheckTeacherUser(string user)
        {
            return tbuserservice.CheckTeacherUser(user);
        }
        /// <summary>
        /// 根据用户ID查找对应的用户详细信息
        /// </summary>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public static TbUser GetAllUser(int YhID)
        {
            return tbuserservice.GetAllUser(YhID);
        }
        /// <summary>
        /// 根据学号或者用户名查找用户ID
        /// </summary>
        /// <param name="Xh">学号或用户名</param>
        /// <returns></returns>
        public static int GetStudentID(string Xh)
        {
            return tbuserservice.GetStudentID(Xh);
        }
        /// <summary>
        /// 根据用户ID修改User表
        /// </summary>
        /// <param name="user">User对象</param>
        /// <returns></returns>
        public static int SetUser(TbUser user)
        {
            return tbuserservice.SetUser(user);
        }
        /// <summary>
        /// 根据用户编号获得用户的详细信息-
        /// </summary>
        /// <param name="yhid">用户编号</param>
        /// <returns></returns>
        public static TbUser GetUserInfoByYhID(int yhid)
        {
            return tbuserservice.GetUserInfoByYhID(yhid);
        }
        /// <summary>
        /// 查询是否存在对应的用户信息
        /// </summary>
        /// <param name="YhName"></param>
        /// <returns>返回用户编号YhID</returns>
        public static int SelectUserYhName(string YhName)
        {
            return tbuserservice.SelectUserYhName(YhName);
        }
        /// <summary>
        /// 根据用户编号修改教师用户的角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateUserRoleByYhID(TbUser user)
        {
            return tbuserservice.UpdateUserRoleByYhID(user);
        }
    }
}
