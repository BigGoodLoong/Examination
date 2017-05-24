using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using ExaminationModels;
using System.Data.SqlClient;

namespace ExaminationDAL
{
    public class TbObjectiveTopicService
    {
        /// <summary>
        /// 查询学员答卷列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllReviewTestPaperInfo()
        {
            StringBuilder sqlsb = new StringBuilder();
            sqlsb.Append("select ot.KgtID,u.Xh, tp.SjName,sl.ZyName, sb.KmName ,ot.Zt ");
            sqlsb.Append("from tbObjTopic as ot,tbTestPaper as tp,tbSubject as sb,tbUser as u,tbSpeciality as sl ");
            sqlsb.Append("where tp.SjID=ot.SjID and tp.KmID=sb.KmID and ot.YhID=u.YhID and sb.ZyID=sl.ZyID and ot.Zt<>1 ");
            return DBHelper.GetDataTable(sqlsb.ToString());
        }
        /// <summary>
        /// 查询所有学员答卷列表信息的条数
        /// </summary>
        /// <returns></returns>
        public int GetATestPaperCount()
        {
            StringBuilder sqlSb = new StringBuilder();
            sqlSb.Append("select COUNT(*)from tbObjTopic as ot,tbTestPaper as tp,tbSubject as sb,tbUser as u,tbSpeciality as sl ");
            sqlSb.Append("where tp.SjID=ot.SjID and tp.KmID=sb.KmID and ot.YhID=u.YhID and sb.ZyID=sl.ZyID and ot.Zt<>1 ");
            return DBHelper.GetScalar(sqlSb.ToString());
        }
        /// <summary>
        /// 根据答题卡ID删除对应答题卡信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public int deleteReviewTestPaperInfo(int KgtID)
        {
            string sql = "delete from dbo.tbObjTopic where KgtID=@KgtID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KgtID",KgtID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
