using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;


namespace ExaminationBLL
{
    public static class PublicClass
    {
        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <param name="cookie">当前cookie</param>
        /// <param name="str">标识来源,main和空两种</param>
        /// <returns></returns>
        public static string CheckLogin(HttpCookie cookie, string str)
        {
            string url = "";
            if (cookie == null)
            {
                if (str == "main")
                    url = "<script>window.parent.parent.location.href='../../Login.aspx'</script>";
                else
                    url = "../Login.aspx";
            }
            return url;
        }

        /// <summary>
        /// 返回两个时间的时间差
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public static int GetMinutes(DateTime beginTime, DateTime endTime)
        {
            TimeSpan ts = endTime.Subtract(beginTime);
            return (int)ts.TotalMinutes;
        }
        /// <summary>
        /// 将文件保存到指定目录下
        /// </summary>
        /// <param name="ms">数据转换后的流</param>
        /// <param name="fileName">保存文件路径</param>
        public static void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }

        }
        /// <summary>
        /// 将DataTable转换成流(必须导入NPOI.dll包)
        /// </summary>
        /// <param name="dataSource">当前要写入的数据源</param>
        /// <param name="workname">工作表名</param>
        /// <returns></returns>
        public static MemoryStream GetTable(DataTable dataSource, string workname)
        {
            MemoryStream ms = new MemoryStream();
            IWorkbook workbook = new HSSFWorkbook();//创建Workbook对象
            ISheet sheet = workbook.CreateSheet(workname);
            IRow headerRow = sheet.CreateRow(0);

            foreach (DataColumn column in dataSource.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);

            int rowIndex = 1;
            foreach (DataRow row in dataSource.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dataSource.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }
                rowIndex++;
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }
    }
}
