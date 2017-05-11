using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbAnswerCard
    {
        /// <summary>
        /// 题号
        /// </summary>
        public string Tihao { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 题型
        /// </summary>
        public string Tixing { get; set; }

        /// <summary>
        /// 题型个数
        /// </summary>
        public int TxCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remar { get; set; }

        /// <summary>
        /// 试卷ID
        /// </summary>
        public int SjID { get; set; }


        /// <summary>
        /// 当前用户
        /// </summary>
        public string UserName { get; set; }
    }
}
