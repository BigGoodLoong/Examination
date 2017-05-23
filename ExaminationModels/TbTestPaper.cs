using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    /// <summary>
    /// 试卷类
    /// </summary>
    public class TbTestPaper
    {
        public int SjID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string LsName { get; set; }
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string SjName { get; set; }
        /// <summary>
        /// 科目ID
        /// </summary>
        public int KmID { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime KsTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime JsTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CjTime { get; set; }
        /// <summary>
        /// 试卷状态，1为没有标准答案，2为有标准答案
        /// </summary>
        public int Zt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }


    }
}
