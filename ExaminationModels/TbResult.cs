using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    /// <summary>
    /// 主观题信息
    /// </summary>
    public class TbResult
    {
        /// <summary>
        /// 主观题编号
        /// </summary>
        public int ZgtID { get; set; }
        /// <summary>
        /// 答题卡编号
        /// </summary>
        public int KgtID { get; set; }
        /// <summary>
        /// 题号
        /// </summary>
        public int ZgtNo { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string ZgtAnswer { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Zt { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
