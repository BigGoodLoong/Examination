using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbSubject
    {
        /// <summary>
        /// 科目ID
        /// </summary>
        public int KmID { get; set; }
        /// <summary>
        /// 科目名称
        /// </summary>
        public string KmName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 专业ID
        /// </summary>
        public int ZyID { get; set; }
    }
}
