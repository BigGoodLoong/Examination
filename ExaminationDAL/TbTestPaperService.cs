using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationModels;
using System.Data.SqlClient;
using System.Data;

namespace ExaminationDAL
{
    public class TbTestPaperService
    {
        /// <summary>
        /// 添加一张试卷，返回当前试卷ID
        /// </summary>
        /// <param name="paper"></param>
        /// <returns></returns>
        public int AddPaper(TbTestPaper paper)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("insert into tbTestPaper(LsName,SjName,KmID,KsTime,JsTime,Remark)");
            sbsql.Append("values(@LsName,@SjName,@KmID,@KsTime,@JsTime,@Remark);select @@IDENTITY");
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@LsName",paper.LsName),
                    new SqlParameter("@SjName",paper.SjName),
                    new SqlParameter("@KmID",paper.KmID),
                    new SqlParameter("@KsTime",paper.KsTime),
                    new SqlParameter("@JsTime",paper.JsTime),
                    new SqlParameter("@Remark",paper.Remark)
            };
            return DBHelper.GetScalar(sbsql.ToString(), paras);
        }

        /// <summary>
        /// 查询试卷列表
        /// </summary>
        /// <param name="len">每次查询的条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>

        public DataTable GetAllTestpaperByPage(int len, int page)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " tp.SjID,tp.SjName,sb.KmName,tp.LsName,tp.KsTime,tp.JsTime,tp.Zt,tp.Remark from tbTestPaper as tp, ");
            sbsql.Append("tbSubject as sb where tp.KmID=sb.KmID and SjID not in(select top " + len * page + " SjID from tbTestPaper)");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        public DataTable GetAllTestpaperByPages(int len, int page, string sjName)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " tp.SjID,tp.SjName,sb.KmName,tp.LsName,tp.KsTime,tp.JsTime,tp.Zt,tp.Remark from tbTestPaper as tp, ");
            sbsql.Append("tbSubject as sb where tp.KmID=sb.KmID and SjID not in(select top " + len * page + " SjID from tbTestPaper) and tp.SjName like '%" + sjName + "%'");
            return DBHelper.GetDataTable(sbsql.ToString());
        }

        /// <summary>
        /// 根据ID删除试卷信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public int DeleteTestpaperBySjid(int sjid)
        {
            string sql = "delete from tbTestPaper where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 查询试卷信息的总条数
        /// </summary>
        /// <returns></returns>
        public int GetAllTestpaperCount()
        {
            string sql = "select COUNT(*)from dbo.tbTestPaper as tb,dbo.tbSubject as su  where tb.KmID=su.KmID";
            return DBHelper.GetScalar(sql);
        }
        /// <summary>
        /// 根据科目ID查找试卷信息
        /// </summary>
        /// <param name="KmID">科目ID</param>
        /// <returns></returns>
        public int GetAllTestPaperIsExist(int KmID)
        {
            string Sql_Select = "select COUNT(*) from tbTestPaper where KmID=" + KmID;
            return DBHelper.GetScalar(Sql_Select);
        }

        /// <summary>
        /// 修改试卷状态 用户增加答案和删除答案
        /// </summary>
        /// <param name="Sjid">试卷ID</param>
        /// <param name="Zt">试卷状态</param>
        /// <returns></returns>
        public int UpPaperZt(string Sjid, int Zt)
        {
            string sql = "Update tbTestPaper set Zt=@Zt where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[]
            {
              new SqlParameter("@Zt",Zt),
              new SqlParameter("@SjID",Sjid)
            };

            return DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 查询所有试卷列表信息
        /// </summary>
        /// <param name="len">每页显示的列数</param>
        /// <param name="Page">页号</param>
        /// <returns></returns>
        public DataTable GetAllTestPaperInfo(int len, int Page)
        {
            Page--;
            StringBuilder sb = new StringBuilder();
            sb.Append("select top " + len + " SjID, LsName,SjName,KmName,ZyName,Zt ");
            sb.Append("from tbTestPaper as tp,tbSubject as su,tbSpeciality as sp ");
            sb.Append("where tp.KmID=su.KmID and su.ZyID=sp.ZyID and Zt in (1,2) ");
            sb.Append("and SjID not in (select top " + len * Page + " SjID from tbTestPaper )");
            return DBHelper.GetDataTable(sb.ToString());
        }

        /// <summary>
        /// 查询试卷列表
        /// </summary>
        /// <param name="len">每页显示信息的条数</param>
        /// <param name="page">页号</param>
        /// <param name="testpaperName">查找条件</param>
        /// <returns></returns>
        public DataTable GetAllTestpaperByPage(int len, int page, string testpaperName)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " tp.SjID,tp.SjName,sb.KmName,tp.LsName,tp.KsTime,tp.JsTime,tp.Zt,tp.Remark from tbTestPaper as tp, ");
            sbsql.Append("tbSubject as sb where tp.KmID=sb.KmID and SjID not in(select top " + len * page + " SjID from tbTestPaper)");
            sbsql.Append("and (tp.SjName like '%" + testpaperName + "%' or sb.KmName like '%" + testpaperName + "%' ) order by SjID desc");
            return DBHelper.GetDataTable(sbsql.ToString());
        }

        public DataTable GetAllTestpaperByPage(int len, int page, string testpaperName, int zt)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " tp.SjID,tp.SjName,sb.KmName,tp.LsName,tp.KsTime,tp.JsTime,tp.Zt,tp.Remark from tbTestPaper as tp, ");
            sbsql.Append("tbSubject as sb where tp.KmID=sb.KmID and SjID not in(select top " + len * page + " SjID from tbTestPaper)");
            sbsql.Append("and (tp.SjName like '%" + testpaperName + "%' or sb.KmName like '%" + testpaperName + "%' ) and getdate()>=KsTime and GETDATE()<=dateadd(ss,1800,KsTime)  order by KsTime asc");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 查询试卷列表信息的总条数
        /// </summary>
        /// <returns></returns>
        public int GetAllTestPaperInfoCount()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select COUNT(*) from tbTestPaper as tp,tbSubject as su,tbSpeciality as sp ");
            sb.Append("where tp.KmID=su.KmID and su.ZyID=sp.ZyID and Zt in (1,2)");
            return DBHelper.GetScalar(sb.ToString());
        }
        public DataTable GetAllTestpaperCount(string testpaper)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select * from dbo.tbTestPaper as tp,dbo.tbSubject as su  ");
            sbsql.Append("where tp.KmID=su.KmID and (tp.SjName like '%" + testpaper + "%' or su.KmName like '%" + testpaper + "%' )");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据试卷ID获得一张试卷的全部信息
        /// </summary>
        /// <param name="SjID">试卷Id</param>
        /// <returns></returns>
        public DataTable getOnePaperInfo(string SjID)
        {
            string sql = "select * from tbTestPaper where SjID=" + SjID;

            return DBHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 根据试卷ID查询其对应详细信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public TbTestPaper GetAllSjInfo(int sjid)
        {
            TbTestPaper testPaper = null;
            string sql = "select * from  dbo.tbTestPaper where SjID=@sjid";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@sjid", sjid) };
            SqlDataReader reader = DBHelper.GetReader(sql, paras);
            if (reader.Read())
            {
                testPaper = new TbTestPaper();
                testPaper.SjID = sjid;
                testPaper.LsName = reader["LsName"].ToString();
                testPaper.SjName = reader["SjName"].ToString();
                testPaper.KmID = int.Parse(reader["KmID"].ToString());
                testPaper.KsTime = (DateTime)reader["KsTime"];
                testPaper.JsTime = (DateTime)reader["JsTime"];
                testPaper.CjTime = (DateTime)reader["CjTime"];
                testPaper.Zt = int.Parse(reader["Zt"].ToString());
                testPaper.Remark = reader["Remark"].ToString();
                reader.Close();
            }
            return testPaper;
        }
        /// <summary>
        /// 根据试卷名判断是否存在对应的试卷
        /// </summary>
        /// <param name="Sjname">试卷名</param>
        /// <returns></returns>
        public int GetTestPaperInfo(string Sjname)
        {
            string sql = "select * from dbo.tbTestPaper  where SjName=@SjName";
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@SjName", Sjname) };
            return DBHelper.GetScalar(sql, paras);
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
        public int updateTestPaper(string SjName, DateTime startTime, DateTime endTime, string remark, int SjID)
        {
            string sql = "update tbTestPaper set SjName=@SjName,KsTime=@startTime,JsTime=@endTime,Remark=@remark where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjName",SjName),
                    new SqlParameter("@startTime",startTime),
                    new SqlParameter("@endTime",endTime),
                    new SqlParameter("@remark",remark),
                    new SqlParameter("@SjID",SjID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
