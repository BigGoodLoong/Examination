using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;
using ExaminationDAL;
using System.Data;

namespace ExaminationBLL
{
    public class TbStudentManager
    {
        static TbStudentService tbstuservice = new TbStudentService();

        /// <summary>
        /// 查询班级表数据条数
        /// </summary>
        /// <returns></returns>
        public static int GetStuCount()
        {
            return tbstuservice.GetStuCount();
        }

        /// <summary>
        /// 添加学员信息，返回当前标示符
        /// </summary>
        /// <param name="stu">当前添加学员信息</param>
        /// <returns></returns>
        public static int AddStudent(TbStudent stu)
        {
            return tbstuservice.AddStudent(stu);
        }
        /// <summary>
        /// 删除所有学员用户信息
        /// </summary>
        /// <returns></returns>
        public static int DeleteAllStu()
        {
            return tbstuservice.DeleteAllStu();
        }
        /// <summary>
        /// 根据用户ID删除学生信息
        /// </summary>
        /// <param name="yuid">用户ID</param>
        /// <returns></returns>
        public static int DeleteStuByYuID(int yuid)
        {
            return tbstuservice.DeleteStuByYuID(yuid);
        }
        /// <summary>
        /// 查询所有学员信息，关联TbUser表，供导出学员信息使用
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllStuInfo()
        {
            return tbstuservice.GetAllStuInfo();
        }

        /// <summary>
        /// 分页查询学生信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <param name="BjName">班级名称</param>
        /// <returns></returns>
        public static DataTable GetAllStuInfo(int len, int page, string BjName)
        {
            return tbstuservice.GetAllStuInfo(len, page, BjName);
        }
        public static DataTable GetAllStuInfo(string BjName)
        {
            return tbstuservice.GetAllStuInfo(BjName);
        }
        /// <summary>
        ///  根据用户ID返回对应详细信息
        /// </summary>
        /// <param name="ZyID">用户ID</param>
        /// <returns></returns>
        public static TbStudent GetStudentByID(int YhID)
        {
            return tbstuservice.GetStudentByID(YhID);
        } /// <summary>
          /// 根据用户ID修改学生信息
          /// </summary>
          /// <param name="stu">学生对象</param>
          /// <returns></returns>
        public static int SetStudent(TbStudent stu)
        {
            return tbstuservice.SetStudent(stu);
        }
    }
}
