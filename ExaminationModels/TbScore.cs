using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationModels
{
    public class TbScore
    {
        /// <summary>
        /// 成绩ID
        /// </summary>
        public int CjID { get; set; }

        /// <summary>
        /// 答题卡ID
        /// </summary>
        public int KgtID { get; set; }

        private float dxtScore = -1;

        /// <summary>
        /// 单选题得分
        /// </summary>
        public float DxtScore
        {
            get { return dxtScore; }
            set { dxtScore = value; }
        }

        private float duoxtScore = -1;

        /// <summary>
        /// 多选题得分
        /// </summary>
        public float DuoxtScore
        {
            get { return duoxtScore; }
            set { duoxtScore = value; }
        }

        private float pdtScore = -1;

        /// <summary>
        /// 判读题得分
        /// </summary>
        public float PdtScore
        {
            get { return pdtScore; }
            set { pdtScore = value; }
        }

        private float zgtScore = -1;

        /// <summary>
        /// 简答题得分
        /// </summary>
        public float ZgtScore
        {
            get { return zgtScore; }
            set { zgtScore = value; }
        }


        /// <summary>
        /// 试卷ID
        /// </summary>
        public int SjID { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int Zt { get; set; }
    }
}
