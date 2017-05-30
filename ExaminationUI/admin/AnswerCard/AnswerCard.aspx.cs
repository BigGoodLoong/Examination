using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExaminationDAL;
using ExaminationModels;
using ExaminationBLL;
using System.Data;
using System.Drawing;

public partial class admin_AnswerCard_AnswerCard : System.Web.UI.Page
{
    public static int num = 0;  //初始计量
    public static int shou = 0;//控制位置
    public static int[] max = new int[] { 0, 0, 0, 0 };  //此题目有多少道
    public bool[] panduan = new bool[] { true, true, true, true };//判断是否停止循环
    public static string[] strText = new string[] { "单选题", "多选题", "判断题", "简答题" };

    public TbObjectiveTopic Top = new TbObjectiveTopic();

    public static DataRow drPaper; //获取试卷信息
    public static int intUserZt = 0;
    static bool pan = true;        //用户判断当前用户第几次进入

    string add = "";

    DataTable dt;  //根据试卷ID和状态获得答题卡答案
    public string[] stu;        //获得主观题答案


    public static int ScoreZt = 0;

    /// <summary>
    /// 窗体加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = new DataTable();
        stu = new string[] { };
        HttpCookie ck = Request.Cookies["nowloginuser"];
        string user = ck.Value;//获得当前登录用户用户名
        int YhID = TbUserManager.GetStudentID(user);
        string sjid = Request["SJID"];  //获得当前答案对应的试卷ID
        string Zt = Request["User"];    //获得当前登录用户状态


        Top.SjID = int.Parse(sjid); //将试卷ID赋值给答题卡对象
        Top.Remark = "";            //备注为空赋值给答题卡对象
        Top.YhID = TbUserManager.GetStudentID(user);    //将获得的用户ID赋值给答题卡对象
        if (Zt == "1")
        {
            Top.Zt = int.Parse(Zt); //将状态赋值给题型表标示为答题卡状态
            dt = tbAnswerCardManager.getAnswerCard2(Top);       // 获得答题卡内老师答案
            if (dt.Rows.Count == 0)
            {
                add = "insert";
            }
            else
            {
                add = "update";
            }
        }
        else
        {
            Top.Zt = 2;
            TbScore ts = new TbScore();
            dt = tbAnswerCardManager.getAnswerCard2(Top, Top.YhID);       // 获得答题卡内本学生答案
            if (dt.Rows.Count > 0)
            {
                ts.KgtID = int.Parse(dt.Rows[0]["KgtID"].ToString());
                Top.KgtID = ts.KgtID;
            }
            ts = TbScoreManager.getScore(ts);
            if (ts.Zt == 0)
            {
                add = "insert";
            }
            else
            {
                add = "update";

                stu = tbAnswerCardManager.getAnswerCardZgt(Top).Rows[0]["ZgtAnswer"].ToString().Split('︵');      //获得答题卡内本学生主观题答案
            }
        }

        DataTable dtPaper = TbTestPaperManager.getOnePaperInfo(sjid);       //根据试卷ID获得此试卷的全部基本信息
        if (dtPaper.Rows.Count != 0)
        {
            drPaper = dtPaper.Rows[0];
        }

        max = new int[4] { 0, 0, 0, 0 };
        foreach (DataRow item in tbAnswerCardManager.DtAnswerMg(Top.SjID).Rows)
        {
            getMax(item["TxName"].ToString(), int.Parse(item["TxCount"].ToString()));  //获得题型类型名，获得对应题型个数
        }




        for (int i = 0; i < 4; i++)
        {
            Buju(strText[i], i);        //生成答题卡
        }

    }

    /// <summary>
    /// 生成界面
    /// </summary>
    /// <param name="Tex"></param>
    /// <param name="Mindex"></param>
    public void Buju(string Tex, int Mindex)
    {
        num = 0;
        Table tb = new Table();
        TableRow tr;
        TableCell cell;
        if (Mindex < 2)
        {
            while (panduan[Mindex])
            {
                tr = new TableRow();

                for (int i = 0; i < 3; i++)
                {
                    tr.Font.Size = new FontUnit(12);
                    if (!panduan[Mindex])
                    {
                        break;
                    }
                    cell = new TableCell();
                    cell.VerticalAlign = VerticalAlign.Top;
                    Table tbN = new Table();
                    for (int j = 0; j < 5; j++)
                    {
                        TableRow TrN = new TableRow();  //每列五行
                        TableCell tdN; //每行有五列个
                        num++;
                        if (num == max[Mindex] + 1)     //判断是否加载完成
                        {
                            panduan[Mindex] = false;
                            num = 0;
                            break;
                        }
                        RadioButtonList tdList = new RadioButtonList();
                        tdList.CssClass = "rdiobtnList";
                        tdList.RepeatDirection = RepeatDirection.Horizontal;
                        if (Mindex == 0)
                            tdList.ID = "Rdo" + num.ToString();


                        for (int k = 0; k < 5; k++)
                        {
                            if (k == 0)            //添加题目号
                            {
                                tdN = new TableCell();
                                Label lbN = new Label();
                                lbN.Font.Bold = true;
                                lbN.Font.Size = new FontUnit(12);
                                lbN.Text = num.ToString() + ".";
                                tdN.Controls.Add(lbN);
                                TrN.Controls.Add(tdN);     //将每一列添加至列表行
                            }
                            else if (Mindex == 0)            //添加radiobutton
                            {
                                ListItem Lt = new ListItem();
                                Lt.Text = ZhuanHuan(k);
                                Lt.Value = ZhuanHuan(k);
                                if (add == "update")
                                {
                                    int choose = setPageAnswer("DxtAnswer", num - 1);
                                    if (k - 1 == choose)
                                    {
                                        Lt.Selected = true;
                                    }
                                    tdList.CssClass = "nowrdoBtnList";
                                }
                                tdList.Items.Add(Lt);
                                if (k == 4)
                                {
                                    tdN = new TableCell();
                                    tdN.Controls.Add(tdList);
                                    TrN.Controls.Add(tdN);
                                }
                            }
                            else if (Mindex == 1)             //添加checkButton
                            {
                                TrN.CssClass = "rdiobtnList";
                                tdN = new TableCell();
                                CheckBox Chek = new CheckBox();
                                Chek.ID = num.ToString() + "_" + k.ToString();
                                if (add == "update")
                                {
                                    int choose = setPageAnswer("DuoxtAnswer", num - 1, k);  //获取被选中项目
                                    if (k - 1 == choose)
                                    {
                                        Chek.Checked = true;
                                    }
                                    TrN.CssClass = "nowrdoBtnList";
                                }
                                Chek.Text = ZhuanHuan(k);
                                tdN.Controls.Add(Chek);
                                TrN.Controls.Add(tdN);     //将每一列添加至列表行
                            }

                        }
                        tbN.Controls.Add(TrN);
                        cell.Controls.Add(tbN);
                    }
                    tr.Controls.Add(cell);       //将外三行每一列添加到每一行
                }
                tb.Controls.Add(tr);    //将每一行添加至表
            }
        }
        else
        {
            while (panduan[Mindex])
            {
                tr = new TableRow();
                if (Mindex == 2)
                {
                    for (int Pk = 0; Pk < 5; Pk++)
                    {

                        num++;
                        if (num == max[Mindex] + 1)
                        {
                            panduan[Mindex] = false;
                            num = 0;
                            break;
                        }
                        cell = new TableCell();
                        Label Plb = new Label();
                        Plb.Text = num.ToString() + ".";
                        cell.Controls.Add(Plb);
                        tr.Controls.Add(cell);
                        RadioButtonList Prdio = new RadioButtonList();
                        Prdio.RepeatDirection = RepeatDirection.Horizontal;
                        Prdio.CssClass = "rdiobtnList";
                        Prdio.ID = "Prdo" + num.ToString();
                        ListItem Plt = new ListItem();
                        Plt.Value = "1";             //值为1表示判断本题是错的
                        Plt.Text = "√";
                        if (add == "update")
                        {
                            int value = setPageAnswer("PdtAnswer", num - 1);
                            if (value == 0)
                            {
                                Plt.Selected = true;
                            }
                        }
                        Prdio.Items.Add(Plt);
                        Plt = new ListItem();
                        Plt.Value = "2";            //值为2表示判断本题是错的
                        Plt.Text = "×";
                        if (add == "update")
                        {
                            int value = setPageAnswer("PdtAnswer", num - 1);
                            if (value == 1)
                            {
                                Plt.Selected = true;
                            }
                        }
                        Prdio.Items.Add(Plt);
                        cell = new TableCell();
                        cell.Controls.Add(Prdio);
                        tr.Controls.Add(cell);
                    }
                    tb.Controls.Add(tr);

                }

                if (Mindex == 3)
                {
                    num++;
                    if (num == max[Mindex] + 1)
                    {
                        panduan[Mindex] = false;
                        num = 0;
                        break;
                    }

                    cell = new TableCell();
                    Label Jlb = new Label();
                    Jlb.Text = num.ToString() + "、";
                    cell.Controls.Add(Jlb);
                    tr.Controls.Add(cell);
                    cell = new TableCell();
                    TextBox Jtxt = new TextBox();
                    Jtxt.ID = "Jay" + num.ToString();
                    Jtxt.TextMode = TextBoxMode.MultiLine;
                    Jtxt.Wrap = true;
                    Jtxt.Rows = 5;
                    Jtxt.Height = 100;
                    if (Top.Zt == 2 && add == "update")
                    {
                        Jtxt.Text = stu[num - 1];
                    }
                    Jtxt.CssClass = "texbefor";
                    cell.Controls.Add(Jtxt);
                    tr.Controls.Add(cell);
                    tb.Controls.Add(tr);
                }
            }
        }

        switch (Mindex)
        {
            case 0:
                PanDan.Controls.Add(tb);
                break;
            case 1:
                PanDuo.Controls.Add(tb);
                break;
            case 2:
                PanPan.Controls.Add(tb);
                break;
            case 3:
                PanJay.Controls.Add(tb);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 数字《----》字母的转换
    /// </summary>
    /// <param name="rd">radioButton</param>
    /// <param name="OK">序号</param>
    public string ZhuanHuan(int OK)
    {
        string Text;
        switch (OK)
        {

            case 1:
                Text = "A";
                break;
            case 2:
                Text = "B";
                break;
            case 3:
                Text = "C";
                break;
            default:
                Text = "D";
                break;
        }
        return Text;
    }

    /// <summary>
    /// 字母《--》数字转换
    /// </summary>
    /// <param name="A"></param>
    /// <returns></returns>
    public int NtoAHuan(string A)
    {
        switch (A)
        {
            case "A":
            case "1":
                return 0;
            case "B":
            case "2":
                return 1;
            case "C":
                return 2;
            case "D":
                return 3;
            default:
                return 4;
        }
    }


    /// <summary>
    /// 获得数据库有的题型的个数并为变量赋值
    /// </summary>
    /// <param name="str">题型名</param>
    /// <param name="count">题个数</param>
    public void getMax(string str, int count)
    {
        switch (str)
        {
            case "单选题":
                max[0] = count;
                break;
            case "多选题":
                max[1] = count;
                break;
            case "判断题":
                max[2] = count;
                break;
            case "简答题":
                if (Top.Zt != 1)
                    max[3] = count;
                else
                    max[3] = 0;
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// 保存答案单击事件        //学生添加/更新答案专用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Baocun_Click1(object sender, EventArgs e)
    {
        if (max[3] == 0)
        {
            Top.Zt = 3;
        }
        GetPageAnswer();
        if (add == "insert")
        {
            Top.KgtID = tbAnswerCardManager.inserAnswer(Top, 1);
            pan = false;
        }
        else if (add == "update")
        {
            int k = tbAnswerCardManager.UpdateAnswer(Top, 1);
        }

    }


    /// <summary>
    /// 提交单击事件  //教师添加答案专用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void Tijiao_Click(object sender, EventArgs e)
    {
        GetPageAnswer();


        if (add == "insert")
        {
            int i = tbAnswerCardManager.inserAnswer(Top, 0);
            i = TbTestPaperManager.UpPaperZt(Top.SjID.ToString(), 2);  //修改试卷当前状态为 2（修改）
            add = "update";
        }
        else if (add == "update")
        {
            int k = tbAnswerCardManager.UpdateAnswer(Top, 0);
        }
        Response.Redirect("../TestPaper/EditTestPaper.aspx");   //返回查看试卷页面
    }


    /// <summary>
    /// 获得页面当前已选择的答案
    /// </summary>
    public void GetPageAnswer()
    {
        string st = "";
        string No = "";
        for (int Dan = 1; Dan <= max[0]; Dan++)        //单项选择题答案获取
        {

            string str = "Rdo" + Dan.ToString();
            RadioButtonList rdolist = (RadioButtonList)this.FindControl(str);
            No += (Dan).ToString() + ",";
            if (rdolist.SelectedValue != "")
            {
                st += rdolist.SelectedValue + ",";
            }
            else
            {
                st += "0,";
            }
            Top.DxtAnwser = st;
            Top.DxtNo = No;
        }
        st = "";
        No = "";

        for (int Duo = 1; Duo <= max[1]; Duo++)                  //多项选择题答案获取
        {
            No += Duo.ToString() + ",";
            for (int i = 1; i < 5; i++)
            {
                string Id = Duo.ToString() + "_" + i.ToString();
                CheckBox Chek = (CheckBox)this.FindControl(Id);
                if (Chek.Checked)
                {
                    st += Chek.Text;
                }
                else
                {
                    st += "0";
                }
            }
            st += ",";

            Top.DuoxtNo = No;
            Top.DuoxtAnwser = st;
        }

        st = "";
        No = "";
        for (int pan = 1; pan <= max[2]; pan++)        //判断题答案获取
        {
            RadioButtonList rdolist = (RadioButtonList)this.FindControl("Prdo" + pan);
            No += pan.ToString() + ",";
            if (rdolist.SelectedValue != "")
            {
                st += rdolist.SelectedValue + ",";
            }
            else
            {
                st += "0,";
            }

            Top.PdtNo = No;
            Top.PdtAnswer = st;
        }

        st = "";
        No = "";
        for (int Tex = 1; Tex <= max[3]; Tex++)          //简答题答案获取
        {
            TextBox txt = (TextBox)this.FindControl("Jay" + Tex.ToString());
            No += Tex.ToString() + ",";
            if (txt.Text != "")
            {
                st += txt.Text + "︵";
            }
            else
            {
                st += "︵";
            }

            Top.ZgtNo = No;
            Top.ZgtAnswer = st;
            Top.Zt = 2;
        }


    }

    /// <summary>
    /// 设置答案交换站
    /// </summary>
    /// <param name="type"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public int setPageAnswer(string type, int num)
    {
        DataRow dr = dt.Rows[0];
        string[] stl = dr[type].ToString().Split(',');
        if (num < stl.Length)
        {
            return NtoAHuan(stl[num]);
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// 设置答案交换站
    /// </summary>
    /// <param name="type"></param>
    /// <param name="num"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int setPageAnswer(string type, int num, int k)
    {
        DataRow dr = dt.Rows[0];
        string[] stl = dr[type].ToString().Split(',');
        string ch = stl[num][k - 1].ToString();
        return NtoAHuan(ch);
    }

    /// <summary>
    /// 返回试卷列表页面 --教师专用
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("../TestPaper/EditTestPaper.aspx"); //返回试卷列表
    }

    /// <summary>
    /// 学生端提交答案
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (max[3] == 0)
        {
            Top.Zt = 3;
        }
        else
        {
            Top.Zt = 2;
        }
        GetPageAnswer();
        if (add == "insert")
        {
            Top.KgtID = tbAnswerCardManager.inserAnswer(Top, Top.Zt);
            pan = false;
        }
        else if (add == "update")
        {
            int k = tbAnswerCardManager.UpdateAnswer(Top, Top.Zt);
        }
        Response.Redirect("../../exam/MyExamList.aspx");
    }
}