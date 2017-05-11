using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    /// <summary>
    /// 题型类
    /// </summary>
    public class TbQuestionTypes
    {
        public int TxID { get; set; }
        /// <summary>
        /// 题型名称
        /// </summary>
        public string TxName { get; set; }
        /// <summary>
        /// 题型总数
        /// </summary>
        public int TxCount { get; set; }
        /// <summary>
        /// 题型总分
        /// </summary>
        public int Txzf { get; set; }
        /// <summary>
        /// 试卷ID
        /// </summary>
        public int SjID { get; set; }
    }
}
