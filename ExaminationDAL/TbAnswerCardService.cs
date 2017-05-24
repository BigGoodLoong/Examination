using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ExaminationModels;
using System.Data;

namespace ExaminationDAL
{
    public class TbAnswerCardService
    {
        /// <summary>
        /// 根据试卷ID返回题型名称及题型个数的表
        /// </summary>
        /// <param name="Sjid">试卷ID</param>
        /// <returns></returns>
        public DataTable DtAnswer(int Sjid)
        {
            string sql = "select * from tbQuestionTypes where SjID=" + Sjid;
            return DBHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 保存客观题答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public int AddObjAnswer(TbObjectiveTopic Tobj)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("insert into tbObjTopic(SjID,YhID,DxtNo,DxtAnswer,DuoxtNo,DuoxtAnswer,PdtNo,PdtAnswer,Zt,Remark) ");
            sbsql.Append("values(@SjID,@YhID,@DxtNo,@DxtAnswer,@DuoxtNo,@DuoxtAnswer,@PdtNo,@PdtAnswer,@Zt,@Remark);select @@IDENTITY");
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",Tobj.SjID),
                    new SqlParameter("@YhID",Tobj.YhID),
                    new SqlParameter("@DxtNo",Tobj.DxtNo),
                    new SqlParameter("@DxtAnswer",Tobj.DxtAnwser),
                    new SqlParameter("@DuoxtNo",Tobj.DuoxtNo),
                    new SqlParameter("@DuoxtAnswer",Tobj.DuoxtAnwser),
                    new SqlParameter("@PdtNo",Tobj.PdtNo),
                    new SqlParameter("@PdtAnswer",Tobj.PdtAnswer),
                    new SqlParameter("@Zt",Tobj.Zt),
                    new SqlParameter("@Remark",Tobj.Remark)
            };
            return DBHelper.GetScalar(sbsql.ToString(), paras);
        }
        /// <summary>
        /// 保存主观题答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public int AddResultAnswer(TbObjectiveTopic Tobj)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("insert into tbResult(KgtID,ZgtNo,ZgtAnswer,Zt,Remark) ");
            sbsql.Append("values(@KgtID,@ZgtNo,@ZgtAnswer,@Zt,@Remark) ;select @@IDENTITY");
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@KgtID",Tobj.KgtID),
                    new SqlParameter("@ZgtNo",Tobj.ZgtNo),
                    new SqlParameter("@ZgtAnswer",Tobj.ZgtAnswer),
                    new SqlParameter("@Zt",2),
                    new SqlParameter("@Remark",Tobj.Remark)
            };
            return DBHelper.GetScalar(sbsql.ToString(), paras);
        }

        /// <summary>
        /// 获得答题卡内所有内容 
        /// </summary>
        /// <param name="Zt">查找（答题卡）状态筛选,如果为1，就是除老师以为的所有答题卡信息</param>
        /// <returns></returns>
        public DataTable getAnswerCard(int Zt)
        {
            string sql = "";
            if (Zt == 1)
                sql = "select * from tbObjTopic where Zt > 1";
            else
                sql = "select * from tbObjTopic where Zt=" + Zt;
            return DBHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 返回考卷基本信息的总条数
        /// </summary>
        /// <param name="EditAnwer">查找条件</param>
        /// <returns></returns>
        public DataTable getAnswerCardCount(string EditAnwer)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select  stu.XsName,u.Xh,tp.SjName,sb.KmName,ot.Zt,ot.YhID,ot.SjID,ot.KgtID ");
            sbsql.Append(" from tbStudent as stu,tbUser as u,tbTestPaper as tp,tbSubject as sb,tbObjTopic as ot ");
            sbsql.Append("  where u.YhID=ot.YhID ");
            sbsql.Append(" and u.YhID=stu.YhID and sb.KmID=tp.KmID and ot.SjID=tp.SjID and ot.Zt>1 ");
            sbsql.Append(" and (stu.XsName like '%" + EditAnwer + "%' or u.Xh like '%" + EditAnwer + "%' ");
            sbsql.Append("or tp.SjName like '%" + EditAnwer + "%' or sb.KmName like '%" + EditAnwer + "%' ) ");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        public DataTable getAnswerCardCount(string EditAnwer, int zt)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select  stu.XsName,u.Xh,tp.SjName,sb.KmName,ot.Zt,ot.YhID,ot.SjID,ot.KgtID ");
            sbsql.Append(" from tbStudent as stu,tbUser as u,tbTestPaper as tp,tbSubject as sb,tbObjTopic as ot ");
            sbsql.Append("  where u.YhID=ot.YhID ");
            sbsql.Append(" and u.YhID=stu.YhID and sb.KmID=tp.KmID and ot.SjID=tp.SjID and ot.Zt=" + zt + " ");
            sbsql.Append(" and (stu.XsName like '%" + EditAnwer + "%' or u.Xh like '%" + EditAnwer + "%' ");
            sbsql.Append("or tp.SjName like '%" + EditAnwer + "%' or sb.KmName like '%" + EditAnwer + "%' ) ");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        /// <summary>
        /// 根据试卷ID 和答题卡状态 获得答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <returns></returns>
        public DataTable getAnswerCard2(TbObjectiveTopic toc)
        {
            string sql = "select * from tbObjTopic where SjID=@SjID and Zt=@Zt";
            SqlParameter[] sqle = new SqlParameter[]{
                new SqlParameter("@SjID",toc.SjID),
                new SqlParameter("@Zt",toc.Zt)
            };
            return DBHelper.GetDataTable(sql, sqle);

        }

        /// <summary>
        ///根据试卷ID 用户ID 答题卡状态  获得答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public DataTable getAnswerCard2(TbObjectiveTopic toc, int YhID)
        {
            string sql = "select * from tbObjTopic where SjID=@SjID and Zt=@Zt and YhID=@YhID";
            SqlParameter[] sqle = new SqlParameter[]{
                new SqlParameter("@SjID",toc.SjID),
                new SqlParameter("@Zt",toc.Zt),
                new SqlParameter("@YhID",YhID)
            };
            return DBHelper.GetDataTable(sql, sqle);

        }

        /// <summary>
        ///根据试卷ID 用户ID 答题卡状态 获得主观题答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <returns></returns>
        public DataTable getAnswerCardZgt(TbObjectiveTopic toc)
        {
            string sql = "select * from tbResult where Zt=@Zt and KgtID=@KgtID ";
            SqlParameter[] sqle = new SqlParameter[]{
                new SqlParameter("@Zt",toc.Zt),
                new SqlParameter("@KgtID",toc.KgtID)
            };
            return DBHelper.GetDataTable(sql, sqle);

        }
        /// <summary>
        /// 根据客观题ID获得客观题详细答案
        /// </summary>
        /// <param name="KgtID">客观题ID</param>
        /// <returns></returns>
        public DataTable getAnswerCard2(int KgtID)
        {
            string sql = "select * from tbObjTopic where KgtID=" + KgtID;
            return DBHelper.GetDataTable(sql);
        }

        /// <summary>
        /// 更新主观题答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public int UpdatResultAnswer(TbObjectiveTopic Tobj)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("update tbResult set ZgtNo=@ZgtNo,ZgtAnswer=@ZgtAnswer,Zt=@Zt");
            sbsql.Append(" where KgtID=@KgtID");
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@ZgtNo",Tobj.ZgtNo),
                    new SqlParameter("@ZgtAnswer",Tobj.ZgtAnswer),
                    new SqlParameter("@KgtID",Tobj.KgtID),
                    new SqlParameter("@Zt",Tobj.Zt)
            };
            return DBHelper.ExecuteCommand(sbsql.ToString(), paras);
        }

        /// <summary>
        /// 更新客观题状态
        /// </summary>
        /// <param name="Ts">需要设置客观题ID及状态</param>
        /// <returns></returns>
        public int UpdateObjZt(TbScore Ts)
        {
            string sql = "update tbObjTopic set Zt=@Zt where KgtID=@KgtID";
            SqlParameter[] sqla = new SqlParameter[]{
                new SqlParameter("@Zt",Ts.Zt),
                new SqlParameter("@KgtId",Ts.KgtID)
            };

            return DBHelper.ExecuteCommand(sql, sqla);
        }

        /// <summary>
        /// 更新客观题答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public int UpdateObjTiveAnswer(TbObjectiveTopic Tobj)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("update tbObjTopic set DxtNo=@DxtNo,DxtAnswer=@DxtAnswer,DuoxtNo=@DuoxtNo,DuoxtAnswer=@DuoxtAnswer,PdtNo=@PdtNo,PdtAnswer=@PdtAnswer");
            sbsql.Append(" where SjID=@SjID and Zt=@Zt");
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",Tobj.SjID),
                    new SqlParameter("@Zt",Tobj.Zt),
                    new SqlParameter("@DxtNo",Tobj.DxtNo),
                    new SqlParameter("@DxtAnswer",Tobj.DxtAnwser),
                    new SqlParameter("@DuoxtNo",Tobj.DuoxtNo),
                    new SqlParameter("@DuoxtAnswer",Tobj.DuoxtAnwser),
                    new SqlParameter("@PdtNo",Tobj.PdtNo),
                    new SqlParameter("@PdtAnswer",Tobj.PdtAnswer)
            };
            return DBHelper.ExecuteCommand(sbsql.ToString(), paras);
        }
        /// <summary>
        /// 根据 试卷ID 获得老师标准答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public DataTable getAnswerTeacher(TbObjectiveTopic Tobj)
        {
            string sql = "select * from tbObjTopic where Zt=1 and SjID=" + Tobj.SjID.ToString();
            return DBHelper.GetDataTable(sql);
        }
        /// <summary>
        /// 返回当前页的考卷信息列表
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public DataTable GetObjTopicList(int len, int page)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " stu.XsName,u.Xh,tp.SjName,sb.KmName,ot.Zt,ot.YhID,ot.SjID,ot.KgtID");
            sbsql.Append(" from tbStudent as stu,tbUser as u,tbTestPaper as tp,tbSubject as sb,tbObjTopic as ot");
            sbsql.Append(" where ot.KgtID not in(select top " + page * len + " KgtID from tbObjTopic) and u.YhID=ot.YhID");
            sbsql.Append(" and u.YhID=stu.YhID and sb.KmID=tp.KmID and ot.SjID=tp.SjID and ot.Zt>1");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        public DataTable GetObjTopicList(int len, int page, string EditAnwer)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " stu.XsName,u.Xh,tp.SjName,sb.KmName,ot.Zt,ot.YhID,ot.SjID,ot.KgtID ");
            sbsql.Append(" from tbStudent as stu,tbUser as u,tbTestPaper as tp,tbSubject as sb,tbObjTopic as ot ");
            sbsql.Append("  where ot.KgtID not in(select top " + len * page + " KgtID from tbObjTopic) and u.YhID=ot.YhID ");
            sbsql.Append(" and u.YhID=stu.YhID and sb.KmID=tp.KmID and ot.SjID=tp.SjID and ot.Zt>1 ");
            sbsql.Append(" and (stu.XsName like '%" + EditAnwer + "%' or u.Xh like '%" + EditAnwer + "%' ");
            sbsql.Append("or tp.SjName like '%" + EditAnwer + "%' or sb.KmName like '%" + EditAnwer + "%' ) ");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
        public DataTable GetObjTopicList(int len, int page, string EditAnwer, int zt)
        {
            page--;
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("select top " + len + " stu.XsName,u.Xh,tp.SjName,sb.KmName,ot.Zt,ot.YhID,ot.SjID,ot.KgtID ");
            sbsql.Append(" from tbStudent as stu,tbUser as u,tbTestPaper as tp,tbSubject as sb,tbObjTopic as ot ");
            sbsql.Append("  where ot.KgtID not in(select top " + len * page + " KgtID from tbObjTopic) and u.YhID=ot.YhID ");
            sbsql.Append(" and u.YhID=stu.YhID and sb.KmID=tp.KmID and ot.SjID=tp.SjID and ot.Zt=" + zt + " ");
            sbsql.Append(" and (stu.XsName like '%" + EditAnwer + "%' or u.Xh like '%" + EditAnwer + "%' ");
            sbsql.Append("or tp.SjName like '%" + EditAnwer + "%' or sb.KmName like '%" + EditAnwer + "%' ) ");
            return DBHelper.GetDataTable(sbsql.ToString());
        }
    }
}
