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
    public class TbTestPaperManager
    {
        static TbTestPaperService paperService = new TbTestPaperService();

        /// <summary>
        /// 添加一张试卷，返回当前试卷ID
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public static int AddPaper(TbTestPaper paper)
        {
            return paperService.AddPaper(paper);
        }

        /// <summary>
        /// 查询试卷列表
        /// </summary>
        /// <param name="len">每次查询的条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static DataTable GetAllTestpaperByPage(int len, int page)
        {
            return paperService.GetAllTestpaperByPage(len, page);
        }
        public static DataTable GetAllTestpaperByPages(int len, int page, string sjName)
        {
            return paperService.GetAllTestpaperByPage(len, page, sjName);
        }
        public static DataTable GetAllTestpaperByPages(int len, int page, string sjName, int OK)
        {
            return paperService.GetAllTestpaperByPage(len, page, sjName, OK);
        }

        /// <summary>
        /// 根据ID删除试卷信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static int DeleteTestpaperBySjid(int sjid)
        {
            return paperService.DeleteTestpaperBySjid(sjid);
        }
        /// <summary>
        /// 查询试卷信息的总条数
        /// </summary>
        /// <returns></returns>
        public static int GetAllTestpaperCount()
        {
            return paperService.GetAllTestpaperCount();
        }
        /// <summary>
        /// 根据科目ID查找试卷信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns></returns>
        public static int GetAllTestPaperIsExist(int KmID)
        {
            return paperService.GetAllTestPaperIsExist(KmID);
        }

        /// <summary>
        /// 修改试卷状态 用户增加答案和删除答案
        /// </summary>
        /// <param name="Sjid">试卷ID</param>
        /// <param name="Zt">试卷状态</param>
        /// <returns></returns>
        public static int UpPaperZt(string Sjid, int Zt)
        {
            return paperService.UpPaperZt(Sjid, Zt);
        }
        /// <summary>
        /// 查询所有试卷列表信息
        /// </summary>
        /// <param name="len">每页显示的列数</param>
        /// <param name="Page">页号</param>
        /// <returns></returns>
        public static DataTable GetAllTestPaperInfo(int len, int Page)
        {
            return paperService.GetAllTestPaperInfo(len, Page);
        }

        /// <summary>
        /// 查询试卷列表
        /// </summary>
        /// <param name="len">每页显示信息的条数</param>
        /// <param name="page">页号</param>
        /// <param name="testpaperName">查找条件</param>
        /// <returns></returns>
        public static DataTable GetAllTestpaperByPage(int len, int page, string testpaperName)
        {
            return paperService.GetAllTestpaperByPage(len, page, testpaperName);
        }
        /// <summary>
        /// 查询试卷列表信息的总条数
        /// </summary>
        /// <returns></returns>
        public static int GetAllTestPaperInfoCount()
        {
            return paperService.GetAllTestpaperCount();
        }
        public static DataTable GetAllTestpaperCount(string testpaper)
        {
            return paperService.GetAllTestpaperCount(testpaper);
        }
        /// <summary>
        /// 根据试卷ID获得一张试卷的全部信息
        /// </summary>
        /// <param name="SjID">试卷ID</param>
        /// <returns></returns>
        public static DataTable getOnePaperInfo(string SjID)
        {
            return paperService.getOnePaperInfo(SjID);
        }
        /// <summary>
        /// 根据试卷ID查询其对应详细信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static TbTestPaper GetAllSjInfo(int sjid)
        {
            return paperService.GetAllSjInfo(sjid);
        }
        /// <summary>
        /// 根据试卷名判断是否存在对应的试卷
        /// </summary>
        /// <param name="Sjname">试卷名</param>
        /// <returns></returns>
        public static int GetTestPaperInfo(string Sjname)
        {
            return paperService.GetTestPaperInfo(Sjname);
        }
        /// <summary>
        /// 根据试卷ID修改试卷信息
        /// </summary>
        /// <param name="SjName">试卷名</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="remark">备注</param>
        /// <param name="SjID">试卷ID</param>
        /// <returns></returns>
        public static int updateTestPaper(string SjName, DateTime startTime, DateTime endTime, string remark, int SjID)
        {
            return paperService.updateTestPaper(SjName, startTime, endTime, remark, SjID);
        }
    }
}
