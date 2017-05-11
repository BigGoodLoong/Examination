using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    /// <summary>
    /// 试卷图片类
    /// </summary>
    public class TbImages
    {
        public int TpID { get; set; }
        /// <summary>
        /// 试卷ID
        /// </summary>
        public int SjID { get; set; }
        /// <summary>
        /// 图片页码
        /// </summary>
        public int TpYm { get; set; }
        /// <summary>
        /// 图片名，存放在固定目录
        /// </summary>
        public string Tpian { get; set; }

    }
}
