using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationDAL;
using System.Data.SqlClient;
using System.Data;
using ExaminationModels;

namespace ExaminationBLL
{
    public class tbAnswerCardManager
    {
        static TbAnswerCardService Tcs = new TbAnswerCardService();
        static TbScore Ts = new TbScore();


        /// <summary>
        /// 获得题型卡内所有内容
        /// </summary>
        /// <param name="SjID"></param>
        /// <returns></returns>
        public static DataTable DtAnswerMg(int SjID)
        {
            return Tcs.DtAnswer(SjID);
        }

        /// <summary>
        /// 保存答案到数据库
        /// </summary>
        /// <param name="Tobj">答题卡对象</param>
        /// <param name="CjZt">答题卡对象</param>
        /// <returns></returns>
        public static int inserAnswer(TbObjectiveTopic Tobj, int CjZt)
        {
            if (Tobj.Zt == 1)
            {
                return Tcs.AddObjAnswer(Tobj);      //教师新增答案到数据库
            }
            else
            {

                Ts = NowScore(Tobj);    //获得当前分数
                Ts.KgtID = Tcs.AddObjAnswer(Tobj);
                Tobj.KgtID = Ts.KgtID;
                Ts.Zt = CjZt;
                Ts.CjID = TbScoreManager.AddScore(Ts);  //添加当前成绩
                int i = Tcs.AddResultAnswer(Tobj);  //添加当前答案 客观题/主观题
                return Ts.KgtID;
            }
        }

        /// <summary>
        ///更新答案
        /// </summary>
        /// <param name="Tobj"></param>
        /// <param name="Zt">成绩表状态1，未交卷，2，已交卷</param>
        /// <returns></returns>
        public static int UpdateAnswer(TbObjectiveTopic Tobj, int Zt)
        {
            if (Tobj.Zt == 1)
            {
                return Tcs.UpdateObjTiveAnswer(Tobj);
            }
            else
            {
                Ts.KgtID = int.Parse(getAnswerCard2(Tobj, Tobj.YhID).Rows[0]["KgtID"].ToString());
                Ts = NowScore(Tobj);    // 重新获得当前分数
                Ts.Zt = Zt;             //更新成绩表状态
                int upt = TbScoreManager.UpdScore(Ts);    //更新分数
                return Tcs.UpdatResultAnswer(Tobj) + Tcs.UpdateObjTiveAnswer(Tobj);     //更新答案

            }
        }


        /// <summary>
        /// 更新客观题状态
        /// </summary>
        /// <param name="Ts">需要设置客观题ID及状态</param>
        /// <returns></returns>
        public static int UpdateObjZt(TbScore Tscore)
        {
            return Tcs.UpdateObjZt(Tscore);
        }


        /// <summary>
        /// 获得答题卡内所有内容 
        /// </summary>
        /// <param name="Zt">查找状态筛选,如果为1，就是除老师以为的所有答题卡信息</param>
        /// <returns></returns>
        public static DataTable getAnswerCard(int Zt)
        {
            return Tcs.getAnswerCard(Zt);
        }

        /// <summary>
        /// 返回考卷基本信息的总条数
        /// </summary>
        /// <param name="EditAnwer">模糊查找条件</param>
        /// <returns></returns>
        public static DataTable getAnswerCardCount(string EditAnwer)
        {
            return Tcs.getAnswerCardCount(EditAnwer);
        }
        public static DataTable getAnswerCardCount(string EditAnwer, int zt)
        {
            return Tcs.getAnswerCardCount(EditAnwer, zt);
        }

        /// <summary>
        /// 获得答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <returns></returns>
        public static DataTable getAnswerCard2(TbObjectiveTopic toc)
        {
            return Tcs.getAnswerCard2(toc);
        }

        /// <summary>
        ///根据试卷ID 用户ID 答题卡状态 获得答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <param name="YhID">用户ID</param>
        /// <returns></returns>
        public static DataTable getAnswerCard2(TbObjectiveTopic toc, int YhID)
        {
            return Tcs.getAnswerCard2(toc, YhID);
        }

        /// <summary>
        /// 根据客观题ID获得客观题详细答案
        /// </summary>
        /// <param name="KgtID">客观题ID</param>
        /// <returns></returns>
        public static DataTable getAnswerCard2(int KgtID)
        {
            return Tcs.getAnswerCard2(KgtID);
        }

        /// <summary>
        ///根据试卷ID 用户ID 答题卡状态 获得主观题答题卡答案
        /// </summary>
        /// <param name="toc"></param>
        /// <returns></returns>
        public static DataTable getAnswerCardZgt(TbObjectiveTopic toc)
        {
            return Tcs.getAnswerCardZgt(toc);
        }




        /// <summary>
        /// 返回教师标准答案 根据试卷ID
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public static DataTable getAnswerTeacher(TbObjectiveTopic Tobj)
        {
            return Tcs.getAnswerTeacher(Tobj);
        }
        /// <summary>
        /// 返回学生考试分数
        /// </summary>
        /// <param name="Tobj"></param>
        /// <returns></returns>
        public static TbScore NowScore(TbObjectiveTopic Tobj)
        {
            TbScore nowScore = new TbScore();
            DataTable dbTeacher = getAnswerTeacher(Tobj);
            DataRow drTeacher = dbTeacher.Rows[0];      //教师标准答案
            DataTable dbTx = DtAnswerMg(Tobj.SjID);     //题型表
            string[] DxtAnswer = Tobj.DxtAnwser.Split(',');
            string[] DuoxtAnswer = Tobj.DuoxtAnwser.Split(',');
            string[] PdtAnswer = Tobj.PdtAnswer.Split(',');
            foreach (DataRow item in dbTx.Rows)
            {
                string type = DataType(item["TxName"].ToString());
                if (type != "0")
                {
                    string[] AnswerTeacher = drTeacher[type].ToString().Split(','); //获得当前题型答案
                    int Zsore = int.Parse(item["Txzf"].ToString()); //获得当前题型总分
                    int Tcount = int.Parse(item["TxCount"].ToString()); //获得当前题型个数
                    float sore = Zsore / Tcount;                        //获得当前题型平均分
                    int UI = 0;

                    for (int num = 0; num < AnswerTeacher.Length - 1; num++)      //length-1去掉最后一个空答案
                    {
                        string Ater = AnswerTeacher[num];
                        if (type == "DxtAnswer")
                        {
                            UI++;
                            if (UI == 1)
                            {
                                nowScore.DxtScore++;
                            }
                            if (Ater == DxtAnswer[num])
                            {
                                nowScore.DxtScore += sore;
                            }
                        }
                        else if (type == "DuoxtAnswer")
                        {
                            UI++;
                            if (UI == 1)
                            {
                                nowScore.DuoxtScore++;
                            }
                            if (Ater == DuoxtAnswer[num])
                            {
                                nowScore.DuoxtScore += sore;
                            }
                        }
                        else
                        {
                            UI++;
                            if (UI == 1)
                            {
                                nowScore.PdtScore++;
                            }
                            if (Ater == PdtAnswer[num])
                            {
                                nowScore.PdtScore += sore;
                            }
                        }
                    }
                    Ts.DxtScore = nowScore.DxtScore;
                    Ts.DuoxtScore = nowScore.DuoxtScore;
                    Ts.PdtScore = nowScore.PdtScore;
                }
            }
            return Ts;
        }




        /// <summary>
        /// 根据题型名称返回字段名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string DataType(string type)
        {
            switch (type)
            {
                case "单选题":
                    return "DxtAnswer";

                case "多选题":
                    return "DuoxtAnswer";

                case "判断题":
                    return "PdtAnswer";
                default:
                    return "0";
                    break;
            }
        }

        /// <summary>
        /// 返回当前页的考卷信息列表
        /// </summary>
        /// <param name="len">每页显示条数</param>
        /// <param name="page">当前页数</param>
        /// <returns></returns>
        public static DataTable GetObjTopicList(int len, int page)
        {
            return Tcs.GetObjTopicList(len, page);
        }
        public static DataTable GetObjTopicList(int len, int page, string EditAnwer)
        {
            return Tcs.GetObjTopicList(len, page, EditAnwer);
        }
        public static DataTable GetObjTopicList(int len, int page, string EditAnwer, int zt)
        {
            return Tcs.GetObjTopicList(len, page, EditAnwer, zt);
        }
    }
}
