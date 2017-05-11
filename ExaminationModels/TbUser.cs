using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbUser
    {
        /// <summary>
        /// ID
        /// </summary>
        public int YhID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string YhName { get; set; }

        /// <summary>
        /// 学号 
        /// </summary>
        public string Xh { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string YhPwd { get; set; }

        /// <summary>
        /// 用户身份(1为管理员，2为老师，3为学生)
        /// </summary>
        public int Zt { get; set; }
    }
}
