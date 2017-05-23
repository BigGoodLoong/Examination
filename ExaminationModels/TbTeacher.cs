using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbTeacher
    {
        /// <summary>
        /// ID
        /// </summary>
        public int LsID { get; set; }
        /// <summary>
        /// 用户名ID（外键）
        /// </summary>
        public int YhID { get; set; }
        /// <summary>
        /// 教师姓名
        /// </summary>
        public string LsName { get; set; }
        /// <summary>
        /// 专业ID
        /// </summary>
        public int ZyID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
