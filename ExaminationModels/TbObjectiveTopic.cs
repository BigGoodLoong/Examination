using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbObjectiveTopic
    {
        /// <summary>
        /// 试卷Id
        /// </summary>
        public int SjID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary> 
        public int YhID { get; set; }


        /// <summary>
        /// 答题卡ID
        /// </summary>
        public int KgtID { get; set; }

        /// <summary>
        /// 单选题题号
        /// </summary>
        private string dxtNo = "0";
        public string DxtNo
        {
            get { return dxtNo; }
            set { dxtNo = value; }
        }

        /// <summary>
        /// 单选题答案
        /// </summary>
        private string dxtAnwser = "0";

        public string DxtAnwser
        {
            get { return dxtAnwser; }
            set { dxtAnwser = value; }
        }
        /// <summary>
        /// 多选题题号
        /// </summary>
        private string duoxtNo = "0";

        public string DuoxtNo
        {
            get { return duoxtNo; }
            set { duoxtNo = value; }
        }
        /// <summary>
        /// 多选题答案
        /// </summary>
        private string duoxtAnwser = "0";

        public string DuoxtAnwser
        {
            get { return duoxtAnwser; }
            set { duoxtAnwser = value; }
        }
        /// <summary>
        /// 判断题题号
        /// </summary>
        private string pdtNo = "0";

        public string PdtNo
        {
            get { return pdtNo; }
            set { pdtNo = value; }
        }

        /// <summary>
        /// 判断题答案
        /// </summary>
        private string pdtAnswer = "0";

        public string PdtAnswer
        {
            get { return pdtAnswer; }
            set { pdtAnswer = value; }
        }
        /// <summary>
        /// 主观题题号
        /// </summary>
        private string zgtNo = "0";

        public string ZgtNo
        {
            get { return zgtNo; }
            set { zgtNo = value; }
        }
        /// <summary>
        /// 主观题答案
        /// </summary>
        private string zgtAnswer = "0";

        public string ZgtAnswer
        {
            get { return zgtAnswer; }
            set { zgtAnswer = value; }
        }

        /// <summary>
        /// 状态(状态1.老师2.未改3.已改)
        /// </summary>
        public int Zt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
