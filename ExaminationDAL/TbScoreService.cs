using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ExaminationModels;

namespace ExaminationDAL
{
    public class TbScoreService
    {
        /// <summary>
        /// 添加成绩返回新添加信息成绩ID
        /// </summary>
        /// <param name="Ts">成绩表对象</param>
        /// <returns></returns>
        public int AddScore(TbScore Ts)
        {
            string sql = "insert into tbScore (KgtID,DxtScore,DuoxtScore,PdtScore,ZgtScore,Zt) values(@KgtID,@DxtScore,@DuoxtScore,@PdtScore,@ZgtScore,@Zt);select @@IDENTITY";
            SqlParameter[] sqle = new SqlParameter[]
            {
            new SqlParameter("@KgtID",Ts.KgtID),
            new SqlParameter("@DxtScore",Ts.DxtScore),
            new SqlParameter("@DuoxtScore",Ts.DuoxtScore),
            new SqlParameter("@PdtScore",Ts.PdtScore),
            new SqlParameter("@ZgtScore",Ts.ZgtScore),
            new SqlParameter("@Zt",Ts.Zt)
            };
            return DBHelper.GetScalar(sql, sqle);
        }
        /// <summary>
        /// 更新成绩表信息返回受影响行数
        /// </summary>
        /// <param name="Ts"></param>
        /// <returns></returns>
        public int UpdScroe(TbScore Ts)
        {
            Ts.ZgtScore = 0;
            string sql = "update tbScore set DxtScore=@DxtScore,DuoxtScore=@DuoxtScore,PdtScore=@PdtScore,ZgtScore=@ZgtScore,Zt=@Zt where CjID=@CjID or KgtID=@KgtID";
            SqlParameter[] sqle = new SqlParameter[]
            {
                new SqlParameter("@DxtScore",Ts.DxtScore),
                new SqlParameter("@DuoxtScore",Ts.DuoxtScore),
                new SqlParameter("@PdtScore",Ts.PdtScore),
                new SqlParameter("@ZgtScore",Ts.ZgtScore),
                new SqlParameter("@Zt",Ts.Zt),
                new SqlParameter("@CjID",Ts.CjID),
                new SqlParameter("@KgtID",Ts.KgtID)

            };
            int OK = DBHelper.ExecuteCommand(sql, sqle);
            return OK;
        }

        /// <summary>
        /// 更新成绩表分数主观题信息返回受影响行数
        /// </summary>
        /// <param name="Defen"></param>
        /// <param name="Zt"></param>
        /// <param name="KgtID"></param>
        /// <returns></returns>
        public int UpdScroe(TbScore Tscore, int KgtID)
        {
            string sql = "update tbScore set ZgtScore=@ZgtScore,Zt=2 where KgtID=@KgtID";
            SqlParameter[] sqle = new SqlParameter[]
            {
                new SqlParameter("@ZgtScore",Tscore.ZgtScore),
                new SqlParameter("@KgtID",Tscore.KgtID)

            };
            return DBHelper.ExecuteCommand(sql, sqle);

        }


        /// <summary>
        /// 答题卡ID 或者根据成绩ID 返回一条成绩信息并生成对象
        /// </summary>
        /// <param name="Ts">成绩对象</param>
        /// <returns></returns>
        public TbScore getScore(TbScore Ts)
        {
            TbScore nowts = new TbScore();
            string sql = "select * from tbScore where KgtID=@KgtID or CjID=@CjID";
            SqlParameter[] sqle = new SqlParameter[]{
                new SqlParameter("@KgtID",Ts.KgtID),
                new SqlParameter("@CjID",Ts.CjID)
            };
            DataTable dt = DBHelper.GetDataTable(sql, sqle);
            if (dt.Rows.Count == 0)
            {
                nowts.Zt = 0;
            }
            else
            {
                nowts.KgtID = int.Parse(dt.Rows[0]["KgtID"].ToString());
                nowts.CjID = int.Parse(dt.Rows[0]["CjID"].ToString());
                nowts.DxtScore = float.Parse(dt.Rows[0]["DxtScore"].ToString());
                nowts.DuoxtScore = float.Parse(dt.Rows[0]["DuoxtScore"].ToString());
                nowts.PdtScore = float.Parse(dt.Rows[0]["PdtScore"].ToString());
                nowts.ZgtScore = float.Parse(dt.Rows[0]["ZgtScore"].ToString());
                nowts.Zt = int.Parse(dt.Rows[0]["Zt"].ToString());
            }

            return nowts;
        }

        /// <summary>
        /// 根据试卷ID及用户ID查找当前用户成绩详细信息
        /// </summary>
        /// <param name="yhID"></param>
        /// <param name="SjID"></param>
        /// <returns></returns>
        public TbScore getScore(string yhID, string SjID)
        {
            string sql = "select * from tbScore where KgtID=(select KgtID from tbObjTopic where SjID=@SjID and YhID=@YhID)";
            SqlParameter[] sqle = new SqlParameter[]{
                new SqlParameter("@SjID",SjID),
                new SqlParameter("@YhID",yhID)
            };
            TbScore nowts = new TbScore();
            DataTable dt = DBHelper.GetDataTable(sql, sqle);
            if (dt.Rows.Count == 0)
            {
                nowts.Zt = 0;
            }
            else
            {
                nowts.KgtID = int.Parse(dt.Rows[0]["KgtID"].ToString());
                nowts.CjID = int.Parse(dt.Rows[0]["CjID"].ToString());
                nowts.DxtScore = float.Parse(dt.Rows[0]["DxtScore"].ToString());
                nowts.DuoxtScore = float.Parse(dt.Rows[0]["DuoxtScore"].ToString());
                nowts.PdtScore = float.Parse(dt.Rows[0]["PdtScore"].ToString());
                nowts.ZgtScore = float.Parse(dt.Rows[0]["ZgtScore"].ToString());
                nowts.Zt = int.Parse(dt.Rows[0]["Zt"].ToString());
            }

            return nowts;
        }

        /// <summary>
        /// 根据用户DI 返回该用户所有成绩信息
        /// </summary>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public DataTable GetTableScore(int YhID)
        {
            string sql = "select * from tbScore where YhID=@YhID";
            SqlParameter[] sqle = new SqlParameter[]{
            new SqlParameter("@YhID",YhID)};
            return DBHelper.GetDataTable(sql, sqle);
        }
        /// <summary>
        /// 返回所有成绩列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetScoreList()
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select s.KgtID,stu.XsName,stu.BjName,tp.SjName,sp.ZyName,sb.KmName,s.DxtScore,s.DuoxtScore,s.PdtScore,s.ZgtScore");
            sbsql.Append(" from tbScore as s,tbObjTopic as ot,tbTestPaper as tp,tbUser as u,tbStudent as stu,tbSubject as sb,tbSpeciality as sp");
            sbsql.Append(" where s.KgtID=ot.KgtID and tp.SjID=ot.SjID and u.YhID=ot.YhID and stu.YhID=ot.YhID");
            sbsql.Append(" and sb.KmID=tp.KmID and sp.ZyID=sb.ZyID order by s.KgtID");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 返回当前页数的成绩列表
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public DataTable GetScoreList(int len, int page)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " s.KgtID,stu.XsName,stu.BjName,tp.SjName,sp.ZyName,sb.KmName,s.DxtScore,s.DuoxtScore,s.PdtScore,s.ZgtScore");
            sbsql.Append(" from tbScore as s,tbObjTopic as ot,tbTestPaper as tp,tbUser as u,tbStudent as stu,tbSubject as sb,tbSpeciality as sp");
            sbsql.Append(" where s.KgtID=ot.KgtID and tp.SjID=ot.SjID and u.YhID=ot.YhID and stu.YhID=ot.YhID");
            sbsql.Append(" and sb.KmID=tp.KmID and sp.ZyID=sb.ZyID and s.KgtID not in(select top " + len * page + " KgtID from tbScore) order by s.KgtID");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据条件返回当前所有成绩列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public DataTable GetScoreList(string whereStr, int type)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select s.KgtID,stu.XsName,stu.BjName,tp.SjName,sp.ZyName,sb.KmName,s.DxtScore,s.DuoxtScore,s.PdtScore,s.ZgtScore");
            sbsql.Append(" from tbScore as s,tbObjTopic as ot,tbTestPaper as tp,tbUser as u,tbStudent as stu,tbSubject as sb,tbSpeciality as sp");
            sbsql.Append(" where s.KgtID=ot.KgtID and tp.SjID=ot.SjID and u.YhID=ot.YhID and stu.YhID=ot.YhID");
            sbsql.Append(" and sb.KmID=tp.KmID and sp.ZyID=sb.ZyID");
            switch (type)
            {
                case 1:
                    sbsql.Append(" and (SjName like '%" + whereStr + "%' or XsName like '%" + whereStr + "%')"); break;
                case 2:
                    sbsql.Append(" and ZyName = '" + whereStr + "'"); break;
                case 3:
                    sbsql.Append(" and KmName like '" + whereStr + "'"); break;
            }
            sbsql.Append(" order by s.KgtID");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /**       以下操作的是试图view_score       **/

        /// <summary>
        /// 查询当前成绩列表里面所有不重复的班级名列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public DataTable GetClassList(string whereStr, int type)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select distinct BjName from view_score");
            switch (type)
            {
                case 1:
                    sbsql.Append(" where (SjName like '%" + whereStr + "%' or XsName like '%" + whereStr + "%')"); break;
                case 2:
                    sbsql.Append(" where ZyName = '" + whereStr + "'"); break;
                case 3:
                    sbsql.Append(" where KmName like '" + whereStr + "'"); break;
            }
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 查询当前成绩列表里面所有不重复的试卷列表
        /// </summary>
        /// <param name="whereStr">条件字符串</param>
        /// <param name="type">1表示试卷名或姓名，2表示专业名，3表示科目名</param>
        /// <returns></returns>
        public DataTable GetTestPaperList(string whereStr, int type)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select * from tbTestPaper where SjID in( select distinct SjID from view_score");
            switch (type)
            {
                case 1:
                    sbsql.Append(" where (SjName like '%" + whereStr + "%' or XsName like '%" + whereStr + "%')"); break;
                case 2:
                    sbsql.Append(" where ZyName = '" + whereStr + "'"); break;
                case 3:
                    sbsql.Append(" where KmName like '" + whereStr + "'"); break;
            }
            sbsql.Append(")");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据试卷ID查询所有成绩信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public DataTable GetScoreListByKgtid(int kgtid)
        {
            string sql = "select * from view_score where KgtID=@KgtID";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@KgtID",kgtid)
            };
            return DBHelper.GetDataTable(sql, paras);
        }
        /// <summary>
        /// 根据试卷ID和班级名查询所有成绩信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <param name="classname">班级名</param>
        /// <returns></returns>
        public DataTable GetScoreListBySjidAndClassname(int sjid, string classname)
        {
            string sql = "select * from view_score where SjID=@SjID and BjName=@BjName";
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@SjID",sjid),
                new SqlParameter("@BjName",classname)
            };
            return DBHelper.GetDataTable(sql, paras);
        }
        /// <summary>
        /// 根据用户ID返回所有考卷成绩列表信息
        /// </summary>
        /// <param name="yhid">用户ID</param>
        /// <returns></returns>
        public DataTable GetTestPaperScoreByYhid(int yhid, string sjName)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select tp.KgtID,tp.SjID,tsp.SjName from tbObjTopic as tp,tbScore as sc,tbTestPaper as tsp ");
            sbsql.Append("where sc.KgtID=tp.KgtID and tsp.SjID=tp.SjID and tp.YhID=@YhID  and  SjName like '%" + sjName + "%'");
            SqlParameter[] paras = new SqlParameter[]{
                new SqlParameter("@YhID",yhid)
            };
            return DBHelper.GetDataTable(sbsql.ToString(), paras);
        }
        /// <summary>
        /// 根据答题卡ID删除对应的成绩信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public int deleteScoreInfo(int KgtID)
        {
            string sql = "delete from dbo.tbScore where KgtID=@KgtID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KgtID",KgtID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
