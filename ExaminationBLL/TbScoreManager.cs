using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExaminationModels;
using ExaminationDAL;
using System.Data.SqlClient;
using System.Data;

namespace ExaminationBLL
{
    public static class TbScoreManager
    {
        static TbScoreService Tss = new TbScoreService();

        /// <summary>
        /// 管理添加成绩并返回CjID
        /// </summary>
        /// <param name="Ts">成绩表对象</param>
        /// <returns></returns>
        public static int AddScore(TbScore Ts)
        {
            return Tss.AddScore(Ts);
        }

        /// <summary>
        /// 更新成绩表总分
        /// </summary>
        /// <param name="Ts">成绩表对象x</param>
        /// <returns></returns>
        public static int UpdScore(TbScore Ts)
        {
            return Tss.UpdScroe(Ts);
        }

        /// <summary>
        /// 更新成绩表主观题信息返回受影响行数
        /// </summary>
        /// <param name="Tscore"></param>
        /// <param name="KgtID">客观题ID</param>
        /// <returns></returns>
        public static int UpdScroe(TbScore Tscore, int KgtID)
        {
            return Tss.UpdScroe(Tscore, KgtID);
        }

        /// <summary>
        /// 答题卡ID 或者根据成绩ID 返回一条成绩信息并生成对象
        /// </summary>
        /// <param name="Ts">成绩对象</param>
        /// <returns></returns>
        public static TbScore getScore(TbScore Ts)
        {
            return Tss.getScore(Ts);
        }

        /// <summary>
        /// 根据试卷ID及用户ID查找当前用户成绩详细信息
        /// </summary>
        /// <param name="yhID"></param>
        /// <param name="SjID"></param>
        /// <returns></returns>
        public static TbScore getScore(string yhID, string SjID)
        {
            return Tss.getScore(yhID, SjID);
        }

        /// <summary>
        /// 根据用户DI 返回该用户所有成绩信息
        /// </summary>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public static DataTable GetTableScore(int YhID)
        {
            return Tss.GetTableScore(YhID);
        }
        /// <summary>
        /// 返回所有成绩列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetScoreList()
        {
            return Tss.GetScoreList();
        }
        /// <summary>
        /// 返回当前页数的成绩列表
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static DataTable GetScoreList(int len, int page)
        {
            return Tss.GetScoreList(len, page);
        }
        /// <summary>
        /// 根据条件返回当前所有成绩列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public static DataTable GetScoreList(string whereStr, int type)
        {
            return Tss.GetScoreList(whereStr, type);
        }

        /// <summary>
        /// 查询当前成绩列表里面所有不重复的班级名列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public static DataTable GetClassList(string whereStr, int type)
        {
            return Tss.GetClassList(whereStr, type);
        }
        /// <summary>
        /// 查询当前成绩列表里面所有不重复的试卷列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public static DataTable GetTestPaperList(string whereStr, int type)
        {
            return Tss.GetTestPaperList(whereStr, type);
        }
        /// <summary>
        /// 根据试卷ID查询所有成绩信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static DataTable GetScoreListByKgtid(int kgtid)
        {
            return Tss.GetScoreListByKgtid(kgtid);
        }
        /// <summary>
        /// 根据试卷ID和班级名查询所有成绩信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <param name="classname">班级名</param>
        /// <returns></returns>
        public static DataTable GetScoreListBySjidAndClassname(int sjid, string classname)
        {
            return Tss.GetScoreListBySjidAndClassname(sjid, classname);
        }
        /// <summary>
        /// 根据用户ID返回所有考卷成绩列表信息
        /// </summary>
        /// <param name="yhid">用户ID</param>
        /// <returns></returns>
        public static DataTable GetTestPaperScoreByYhid(int yhid, string sjName)
        {
            return Tss.GetTestPaperScoreByYhid(yhid, sjName);
        }
        /// <summary>
        /// 根据答题卡ID删除对应的成绩信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public static int deleteScoreInfo(int KgtID)
        {
            return Tss.deleteScoreInfo(KgtID);
        }
    }
}
