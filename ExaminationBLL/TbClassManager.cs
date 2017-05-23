using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL;
using System.Data;
using System.Data.SqlClient;
using ExaminationModels;

namespace ExaminationBLL
{
    public class TbClassManager
    {
        static TbClassService tbclass = new TbClassService();

        /// <summary>
        /// 添加班级信息
        /// </summary>
        /// <param name="BjName">班级名称</param>
        /// <param name="Nj">年级</param>
        /// <param name="ZyID">专业名</param>
        /// <param name="Xz">学制</param>
        /// <param name="Bz">备注</param>
        /// <returns>Sql语句执行后返回受影响的行数</returns>
        public static int AddClass(string BjName, string Nj, int ZyID)
        {
            return tbclass.AddClass(BjName, Nj, ZyID);
        }

        /// <summary>
        /// //查找专业表对应的专业ID
        /// </summary>
        /// <param name="Zy">专业名称</param>
        /// <returns>专业ID</returns>
        public static int Sel_ZyID(string Zy)
        {
            return tbclass.Sel_ZyID(Zy);
        }

        /// <summary>
        /// 根据班级名和年级查找对应的信息
        /// </summary>
        /// <param name="BjName">班级名</param>
        /// <param name="Nj">年级</param>
        /// <returns>返回对应的班级列表</returns>
        public static DataTable Sel_Bj(string BjName, string Nj)
        {
            return tbclass.Sel_Bj(BjName, Nj);
        }

        public static SqlDataReader Sel_Zy()
        {
            return tbclass.Sel_Zy();
        }
        /// <summary>
        /// 返回当前页的班级列表信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static DataTable GetAllClassInfoPage(int len, int page)
        {
            return tbclass.GetAllClassInfoPage(len, page);
        }
        /// <summary>
        /// 根据条件模糊查询当前页的班级列表信息
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <param name="name">班级名、年级名、专业名</param>
        /// <returns></returns>
        public static DataTable GetAllClassInfoPage(int len, int page, string name)
        {
            return tbclass.GetAllClassInfoPage(len, page, name);
        }
        /// <summary>
        /// 获取所有班级列表
        /// </summary>
        /// <returns></returns>
        public static List<TbClass> GetAllClassList()
        {
            return tbclass.GetAllClassList();
        }
        /// <summary>
        /// 根据专业ID删除对应班级信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static int DeleteClassByZyID(int ZyID)
        {
            return tbclass.DeleteClassByZyID(ZyID);
        }
        /// <summary>
        /// 返回当前班级列表信息的记录总数
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllClassInfo(string ClassNameOrNj)
        {
            return tbclass.GetAllClassInfo(ClassNameOrNj);
        }
        /// <summary>
        /// 根据班级编号删除对应的班级信息
        /// </summary>
        /// <param name="BjID">班级编号</param>
        /// <returns></returns>
        public static int DeleteClassInfo(int BjID)
        {
            return tbclass.DeleteClassInfo(BjID);
        }
        /// <summary>
        /// 根据班级ID返回对应详细详细
        /// </summary>
        /// <param name="BjID">班级ID</param>
        /// <returns></returns>
        public static TbClass GetClassByID(int BjID)
        {
            return tbclass.GetClassByID(BjID);
        }
        /// <summary>
        /// 根据班级ID修改其对应的班级信息
        /// </summary>
        /// <param name="Class">班级对象</param>
        /// <returns></returns>
        public static int EditClassByID(TbClass Class)
        {
            return tbclass.EditClassByID(Class);
        }
    }
}
