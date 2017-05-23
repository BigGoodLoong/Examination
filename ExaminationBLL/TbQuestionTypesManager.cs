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
    public class TbQuestionTypesManager
    {
        static TbQuestionTypeService qtypeServices = new TbQuestionTypeService();

        /// <summary>
        /// 添加题型
        /// </summary>
        /// <param name="qtype">题型对象</param>
        /// <returns></returns>
        public static int AddQuestionType(TbQuestionTypes qtype)
        {
            return qtypeServices.AddQuestionType(qtype);
        }
        /// <summary>
        /// 根据试卷ID返回总分
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static int GetSumScoreBySjid(int sjid)
        {
            return qtypeServices.GetSumScoreBySjid(sjid);
        }
        /// <summary>
        /// 根据试卷ID返回当前试卷题型分布信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static DataTable GetAllQuestionTypesBySjid(int sjid)
        {
            return qtypeServices.GetAllQuestionTypesBySjid(sjid);
        }
        /// <summary>
        /// 根据试卷ID删除对应题型分布信息
        /// </summary>
        /// <param name="sjid">试卷ID</param>
        /// <returns></returns>
        public static int DeleteQuestionTypesBySjid(int sjid)
        {
            return qtypeServices.DeleteQuestionTypesBySjid(sjid);
        }
    }
}
