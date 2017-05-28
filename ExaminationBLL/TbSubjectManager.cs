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
    public class TbSubjectManager
    {
        static TbSubjectService tbSubjectService = new TbSubjectService();

        /// <summary>
        /// 删除相应ID的科目信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns>返回受影响的行数</returns>
        public static int Dele_Sub(int KmID)
        {
            return tbSubjectService.Dele_Sub(KmID);
        }
        /// <summary>
        /// 获取所有科目列表
        /// </summary>
        /// <returns></returns>
        public static List<TbSubject> GetAllSubjectList()
        {
            return tbSubjectService.GetAllSubjectList();
        }
        /// <summary>
        /// 根据专业绑定科目信息
        /// </summary>
        /// <param name="zyid"></param>
        /// <returns></returns>
        public static List<TbSubject> GetSubjectListByZyId(int zyid)
        {
            return tbSubjectService.GetSubjectListByZyId(zyid);
        }
        /// <summary>
        /// 查询科目信息
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <returns>返回满足条件的数据行数</returns>
        public static int seeSubjectcount(TbSubject subject)
        {
            return tbSubjectService.seeSujectcount(subject);
        }

        /// <summary>
        /// 返回科目列表
        /// </summary>
        /// <param name="len">页面显示的科目信息条数</param>
        /// <param name="apge">当前页数</param>
        /// <returns></returns>
        public static DataTable GetSubject(int len, int apge, string ZyName)
        {
            return tbSubjectService.GetSubject(len, apge, ZyName);
        }
        public static DataTable GetSubject(string ZyName)
        {
            return tbSubjectService.GetSubject(ZyName);
        }

        /// <summary>
        /// 查询班级表数据条数
        /// </summary>
        /// <returns></returns>
        public static int GetSubCount(string Txt_ZyName)
        {
            return tbSubjectService.GetSubCount(Txt_ZyName);
        }
        /// <summary>
        /// 新增科目信息
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <param name="Remark">备注</param>
        /// <param name="ZyID">专业ID</param>
        /// <returns>返回受影响的行数</returns>
        public static int addSubject(TbSubject subject)
        {
            return tbSubjectService.addSubject(subject);
        }
        /// <summary>
        /// 根据专业ID删除对应的科目信息
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static int DeleteSubByZyID(int ZyID)
        {
            return tbSubjectService.DeleteSubByZyID(ZyID);
        }
        /// <summary>
        /// 根据专业ID查询受影响的行数
        /// </summary>
        /// <param name="ZyID">专业ID</param>
        /// <returns></returns>
        public static int QuerySubjectInfo(int ZyID)
        {
            return tbSubjectService.QuerySubjectInfo(ZyID);
        }
        /// <summary>
        /// 根据科目ID查找对应科目信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns></returns>
        public static TbSubject GetSubjectByID(int KmID)
        {
            return tbSubjectService.GetSubjectByID(KmID);
        }
        /// <summary>
        /// 根据科目名称查询科目ID
        /// </summary>
        /// <param name="KmName">科目名称</param>
        /// <returns></returns>
        public static int GetSubjectByKmName(string KmName, int ZyID)
        {
            return tbSubjectService.GetSubjectByKmName(KmName, ZyID);
        }
        /// <summary>
        /// 修改对应科目ID的信息
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public static void Get_SubjectBy(TbSubject subject)
        {
            tbSubjectService.Get_SubjectBy(subject);
        }

        /// <summary>
        /// 根据专业ID返回科目列表
        /// </summary>
        /// <param name="zyid">专业ID</param>
        /// <returns></returns>
        public static DataTable GetSubjectListByZyid(int zyid)
        {
            return tbSubjectService.GetSubjectListByZyid(zyid);
        }

    }
}
