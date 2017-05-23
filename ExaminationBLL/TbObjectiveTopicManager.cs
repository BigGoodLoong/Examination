using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ExaminationDAL;
using ExaminationModels;

namespace ExaminationBLL
{
    public class TbObjectiveTopicManager
    {
        static TbObjectiveTopicService tbObjectiveTopicService = new TbObjectiveTopicService();

        /// <summary>
        /// 查询学员答卷列表信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllReviewTestPaperInfo()
        {
            return tbObjectiveTopicService.GetAllReviewTestPaperInfo();
        }
        /// <summary>
        /// 查询所有学员答卷列表信息的条数
        /// </summary>
        /// <returns></returns>
        public static int GetATestPaperCount()
        {
            return tbObjectiveTopicService.GetATestPaperCount();
        }
        /// <summary>
        /// 根据答题卡ID删除对应答题卡信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public static int deleteReviewTestPaperInfo(int KgtID)
        {
            return tbObjectiveTopicService.deleteReviewTestPaperInfo(KgtID);
        }
    }
}
