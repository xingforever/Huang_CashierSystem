using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Dal
{
    public class SqlHelper
    {
        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Sales.mdb;Persist Security Info=False";
        private static OleDbConnection connection;

        public static OleDbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new OleDbConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }

        public static int ExecuteNonQuery(string safeSql)
       {

            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string d = ex.Message;
                return 0;
            }
            finally
            {
                cmd.Dispose();
                Connection.Close();
            }
            return 1;

        }

        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sqlstr)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(sqlstr, Connection);
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlstr;
                da.SelectCommand = cmd;
                da.Fill(ds);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                Connection.Close();
            }
            return ds;
        }
        /// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ds"></param>
        public static void dataSet(string sqlstr, ref DataSet ds)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand(sqlstr, Connection);
            try
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlstr;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                cmd.Dispose();
                Connection.Close();
            }
        }
        public static DataTable GetDataTable(string safeSql)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            try
            {
                sda.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sda.Dispose();
                cmd.Dispose();
                Connection.Close();
            }
        }
    }
}
