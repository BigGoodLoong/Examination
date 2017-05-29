using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL;
using ExaminationModels;
using System.Data.SqlClient;
using System.Data;
namespace ExaminationBLL
{
    public class TbTeacherManager
    {
        static TbTeacherService tbteacherservice = new TbTeacherService();


        /// <summary>
        /// 新增教师信息
        /// </summary>
        /// <param name="user">账号</param>
        /// <returns></returns>
        public static int CheckTeacherUser(string user)
        {
            return tbteacherservice.CheckTeacherUser(user);
        }
        /// <summary>
        /// 将教师的用户名和密码添加到用户表里
        /// </summary>
        /// <param name="user">账号</param>
        /// <param name="xh">学号</param>
        /// <param name="pwd">密码</param>
        /// <param name="zt">状态</param>
        /// <returns></returns>
        public static int InsertTeacherUser(string user, string xh, string pwd, int zt)
        {
            return tbteacherservice.InsertTeacherUser(user, xh, pwd, zt);
        }

        /// <summary>
        /// 获取教师所教专业的专业ID
        /// </summary>
        /// <param name="zy">专业</param>
        /// <returns></returns>
        public static int GetTeacherZyID(string zy)
        {
            return tbteacherservice.GetTeacherZyID(zy);
        }
        /// <summary>
        /// 新增教师信息
        /// </summary>
        /// <param name="yhid">用户ID</param>
        /// <param name="name">教师姓名</param>
        /// <param name="zyid">专业ID</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public static int InsertTeacherInfo(int yhid, string name, int zyid, string remark)
        {
            return tbteacherservice.InsertTeacherInfo(yhid, name, zyid, remark);
        }
        /// <summary>
        /// 返回当前教师列表信息的记录总数
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllTeachersInfo(string lsname)
        {
            return tbteacherservice.GetAllTeachersInfo(lsname);
        }

        /// <summary>
        /// 返回当前教师列表信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static DataTable GetAllTeacherInfoPage(int len, int page, string lsname)
        {
            return tbteacherservice.GetAllTeacherInfoPage(len, page, lsname);
        }
        /// <summary>
        /// 根据专业ID删除对应老师信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static int DeleteTeaByZyID(int ZyID)
        {
            return tbteacherservice.DeleteTeaByZyID(ZyID);
        }
        /// </summary>
        /// <param name="LsID">教师编号</param>
        /// <returns></returns>
        public static int DeleteTeacherInfo(int YhID)
        {
            return tbteacherservice.DeleteTeacherInfo(YhID);
        }
        /// <summary>
        /// 根据教师的用户编号获取教师的详细信息
        /// </summary>
        /// <param name="YhID"></param>
        /// <returns></returns>
        public static TbTeacher GetTeacherInfoByLsID(int YhID)
        {
            return tbteacherservice.GetTeacherInfoByLsID(YhID);
        }
        /// <summary>
        /// 修改教师信息
        /// </summary>
        /// <param name="teacher">修改后的教师信息</param>
        /// <returns></returns>
        public static int UpdateTeacherInfoByYhID(TbTeacher teacher)
        {
            return tbteacherservice.UpdateTeacherInfoByYhID(teacher);
        }
    }
}
