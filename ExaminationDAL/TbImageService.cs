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
    public class TbImageService
    {
        /// <summary>
        /// 添加试卷图片
        /// </summary>
        /// <param name="image"></param>
        public void AddImage(TbImages image)
        {
            string sql = "insert into tbImages(SjID,TpYm,Tpian)values(@SjID,@TpYm,@Tpian)";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",image.SjID),
                    new SqlParameter("@TpYm",image.TpYm),
                    new SqlParameter("@Tpian",image.Tpian)
            };
            DBHelper.ExecuteCommand(sql, paras);
        }
        /// <summary>
        /// 根据试卷ID获取对应所有图片
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public DataTable GetImagesBySjid(int sjid)
        {
            string sql = "select TpYm,Tpian  from tbImages where SjID=@SjID order by TpYm asc";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.GetDataTable(sql, paras);
        }
        /// <summary>
        /// 根据试卷ID删除对应所有图片
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public int DeleteImageBySjid(int sjid)
        {
            string sql = "delete from tbImages where SjID=@SjID";
            SqlParameter[] paras = new SqlParameter[] {
                    new SqlParameter("@SjID",sjid)
            };
            return DBHelper.ExecuteCommand(sql, paras);
        }
    }
}
