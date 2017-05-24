using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL;
using ExaminationModels;
using System.Data;
using System.Data.SqlClient;

namespace ExaminationBLL
{
    public class TbSpecialityManager
    {
        static TbSpecialityService tbSpecialityService = new TbSpecialityService();

        /// <summary>
        /// 获取所有科目列表
        /// </summary>
        /// <returns></returns>
        public static List<TbSpeciality> GetAllSpecialityList()
        {
            return tbSpecialityService.GetAllSpecialityList();
        }
        /// <summary>
        /// 根据当前已有成绩获取对应所有专业列表
        /// </summary>
        /// <returns></returns>
        public static List<TbSpeciality> GetAllSpecialityListByScore()
        {
            return tbSpecialityService.GetAllSpecialityListByScore();
        }
        /// <summary>
        /// 新增专业信息
        /// </summary>
        /// <param name="ZyName">专业名称</param>
        /// <param name="Remark">备注</param>
        /// <returns>返回受影响的行数</returns>
        public static int addSpeciality(string ZyName, string Remark)
        {
            return tbSpecialityService.addSpeciality(ZyName, Remark);
        }

        /// <summary>
        /// 查询专业信息
        /// </summary>
        /// <param name="ZyName">专业名称</param>
        /// <returns>返回符合条件的专业ID</returns>
        public static int seeSpecialityID(string ZyName)
        {
            return tbSpecialityService.seeSpecialityID(ZyName);
        }
        /// <summary>
        /// 根据专业名模糊查询专业信息
        /// </summary>
        /// <param name="len">页面显示行数</param>
        /// <param name="Page">页号</param>
        /// <param name="specName">专业名</param>
        /// <returns></returns>
        public static DataTable GetAllSpecialityinfo(int len, int Page, string specName)
        {
            return tbSpecialityService.GetAllSpecialityinfo(len, Page, specName);
        }
        /// <summary>
        ///  根据专业名模糊查询所有专业信息
        /// </summary>
        /// <param name="specName"></param>
        /// <returns></returns>
        public static DataTable GetAllSpecialityinfo(string specName)
        {
            return tbSpecialityService.GetAllSpecialityinfo(specName);
        }
        /// <summary>
        /// 根据专业ID删除对应专业信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static int DeleteSpecByZyID(int ZyID)
        {
            return tbSpecialityService.DeleteSpecByZyID(ZyID);
        }
        /// <summary>
        ///  根据专业ID返回对应详细信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static TbSpeciality GetSpecialByID(int ZyID)
        {
            return tbSpecialityService.GetSpecialByID(ZyID);
        }
        /// <summary>
        /// 根据专业ID修改专业信息
        /// </summary>
        /// <param name="spec">专业对象</param>
        /// <returns></returns>
        public static int EditSpecByID(TbSpeciality spec)
        {
            return tbSpecialityService.EditSpecByID(spec);
        }
        /// <summary>
        /// 绑定专业信息下拉框
        /// </summary>
        /// <returns></returns>
        public static DataTable BangdingZy()
        {
            return tbSpecialityService.BangdingZy();
        }
        /// <summary>
        /// 根据专业ID返回对应的专业名称
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static string GetSpecialityName(int ZyID)
        {
            return tbSpecialityService.GetSpecialityName(ZyID);
        }
    }
}
