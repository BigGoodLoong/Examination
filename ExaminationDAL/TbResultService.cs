using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExaminationModels;
using System.Data.SqlClient;

namespace ExaminationDAL
{
    public class TbResultService
    {
        /// <summary>
        /// 根据答题卡ID删除对应主观题信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public int deleteResultInfo(int KgtID)
        {
            string sql = "delete from dbo.tbResult where KgtID=@KgtID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@KgtID",KgtID)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
