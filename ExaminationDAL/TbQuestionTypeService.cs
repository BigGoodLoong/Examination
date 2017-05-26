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
    public class TbQuestionTypeService
    {
        /// <summary>
        /// 添加题型
        /// </summary>
        /// <param name="qtype">题型对象</param>
        /// <returns></returns>
        public int AddQuestionType(TbQuestionTypes qtype)
        {
            StringBuilder sbsql = new StringBuilder();
            sbsql.Append("insert into tbQuestionTypes(TxName,TxCount,Txzf,SjID)");
            sbsql.Append("values(@TxName,@TxCount,@Txzf,@SjID);select @@IDENTITY");
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@TxName",qtype.TxName),
                    new SqlParameter("@TxCount",qtype.TxCount),
                    new SqlParameter("@Txzf",qtype.Txzf),
                    new SqlParameter("@SjID",qtype.SjID)
            };
            return DBHelper.GetScalar(sbsql.ToString(), paras);
        }
        /// <summary>
        /// 根据试卷ID返回总分
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public int GetSumScoreBySjid(int sjid)
        {
            string sql = "select sum(Txzf) from tbQuestionTypes where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.GetScalar(sql, paras);
        }
        /// <summary>
        /// 根据试卷ID返回当前试卷题型分布信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public DataTable GetAllQuestionTypesBySjid(int sjid)
        {
            string sql = "select * from tbQuestionTypes where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.GetDataTable(sql, paras);
        }
        /// <summary>
        /// 根据试卷ID删除对应题型分布信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public int DeleteQuestionTypesBySjid(int sjid)
        {
            string sql = "delete from tbQuestionTypes where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
