using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbStudent
    {
        /// <summary>
        /// 学生ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string XsName { get; set; }
        /// <summary>
        /// 学生性别
        /// </summary>
        public string XsSex { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int YhID { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string BjName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
