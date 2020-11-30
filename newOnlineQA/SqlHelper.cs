using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineQA
{
    class SqlHelper
    {
        private static readonly string connString = "server =47.98.232.57; database=onlineQA;uid=sa;pwd=Sqlroot123;";
        /// <summary>
        /// 执行T-SQL语句，返回datatable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] paras)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //创建Command对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                if (paras != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddRange(paras);
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dataTable);
            }
            return dataTable;
        }

        /// <summary>
        /// 执行T-SQL语句，返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] paras)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            return count;
        }

        /// <summary>
        /// 执行T-SQL语句，返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public static SqlDataReader ExecutReader(string sql, params SqlParameter[] paras)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (SqlException ex)
            {
                conn.Close();
                throw new Exception("执行查询出现异常", ex);
            }
        }

        /// <summary>
        /// 执行T-SQL语句，返回结果第一行第一列的值
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, SqlParameter[] paras)
        {
            object o = null;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //创建Command对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
                conn.Open();
                o = cmd.ExecuteScalar();
            }
            return o;
        }

    }
}
