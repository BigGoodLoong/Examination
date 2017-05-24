using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExaminationDAL;
using ExaminationModels;

namespace ExaminationBLL
{
    public class TbResultManager
    {
        static TbResultService tbResultService = new TbResultService();
        /// <summary>
        /// 根据答题卡ID删除对应主观题信息
        /// </summary>
        /// <param name="KgtID">答题卡ID</param>
        /// <returns></returns>
        public static int deleteResultInfo(int KgtID)
        {
            return tbResultService.deleteResultInfo(KgtID);
        }
    }
}
