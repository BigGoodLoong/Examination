using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace ExaminationDAL
{
    public class DBHelper
    {
        public static string conString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private static SqlConnection connection;

        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                if (connection == null)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        /// <summary>
        /// 调用存储过程，传递参数，返回受影响的行数
        /// </summary>
        /// <param name="StoredProcedure">存储过程名</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static int ExecuteCommandPro(string StoredProcedure, params SqlParameter[] values)
        {
            int result = -1;
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(conString);
            cmd.Connection = con;
            cmd.CommandText = StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        /// <summary>
        /// 通过sql语句返回第一行第一列的值
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static string ReturnStringScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            try
            {
                string result = cmd.ExecuteScalar().ToString();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// 通过sql语句返回受影响的行数
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static int ExecuteCommand(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(safeSql, con);
            int result = -1;

            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        /// <summary>
        /// 通过sql语句，同时传递对应的参数，返回受影响的行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        /// <summary>
        /// 通过sql语句返回第一行第一列的值(整型)
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static int GetScalar(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(safeSql, con);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return result;
        }
        /// <summary>
        /// 通过存储过程，返回第一行第一列的值(整型)
        /// </summary>
        /// <param name="StoredProcedure">存储过程名</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static int GetScalar_pro(string StoredProcedure, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        /// <summary>
        /// 通过sql语句返回第一行和第一列的值(字符串)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static string GetScalarByString(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            string result = null;
            try
            {
                con.Open();
                result = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        /// <summary>
        /// 通过sql语句返回第一行和第一列的值(整型)
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            int result = -1;
            try
            {
                con.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        /// <summary>
        /// 根据sql语句返回SqlDataReader对象
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(safeSql, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        /// <summary>
        /// 根据sql语句返回SqlDataReader对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static SqlDataReader GetReaderPro(string Pro, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Pro;
            cmd.Connection = Connection;
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// 根据sql语句返回DataTable对象
        /// </summary>
        /// <param name="safeSql">sql语句</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string safeSql)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 根据sql语句返回DataTable对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="values">参数列表</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 跟据存储过程返回DataTable对象
        /// </summary>
        /// <param name="pro"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataTable GetDataTable_Pro(string pro, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(pro, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataSet GetDataSet_Pro1(string sql, string name, params SqlParameter[] values)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, name);
            return ds;
        }
        public static DataSet GetDataSet_Pro2(string sql, string name)
        {
            SqlConnection con = new SqlConnection(conString);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, name);
            return ds;
        }
        //用于显示树形菜单
        public static DataTable GetDataSetByProc(string sql, params SqlParameter[] paras)
        {
            SqlConnection con = Connection;
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            if (paras != null)
            {
                cmd.Parameters.Add(paras);
            }
            SqlDataAdapter adpat = new SqlDataAdapter(cmd);
            adpat.Fill(ds);
            return ds.Tables[0];
        }
        //自行转换
        public static SqlParameter Redpara(string prs, SqlDbType dbtype, int size, object value)
        {
            SqlParameter spar = new SqlParameter();
            spar.ParameterName = prs;
            spar.SqlDbType = dbtype;
            spar.Size = size;
            spar.Value = value;
            return spar;
        }
        public static SqlParameter Redpara1(string prs, DbType dbtype, int size, object value)
        {
            SqlParameter spar = new SqlParameter();
            spar.ParameterName = prs;
            spar.DbType = dbtype;
            spar.Size = size;
            spar.Value = value;
            return spar;
        }
    }
}