using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Access.Dao;
using Model;

namespace Dal
{
    public class SqlHelper
    {
     //64位机器用
     //Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 文件路径; HDR=YES;
     //32位机器用
     //Provider = Microsoft.Jet.OLEDB.4.0; Data Source = 文件路径; HDR=YES
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


        public static bool  ExecuteNonQuery(string safeSql)
        {
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string d = ex.Message;
                return false;
            }
            finally
            {
                cmd.Dispose();
                Connection.Close();
            }
            return true ;
        }
        public static int ExecuteQueryId(string safeSql)
        {
            int id = 0;
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            try
            {

                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@identity as id";
                cmd.Parameters.Clear();
                id = Convert.ToInt32(cmd.ExecuteScalar());
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
            return id;

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
        /// <summary>
        /// 快速插入
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dt"></param>
        public static bool ExcuteTableSql(string tableName, DataTable dt, out string error)
        {
            error = "错误";
            try
            {
                List<string> columnList = new List<string>();
                foreach (DataColumn one in dt.Columns)
                {
                    columnList.Add(one.ColumnName);
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("select * from " + tableName, connection);
                using (OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter))
                {
                    adapter.InsertCommand = builder.GetInsertCommand();
                    foreach (string one in columnList)
                    {
                        adapter.InsertCommand.Parameters.Add(new OleDbParameter(one, dt.Columns[one].DataType));
                    }
                    adapter.Update(dt);
                }
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }

        }

        public void InsertDataByDAOEngine(DataTable dt)
        {
            // DAO.DBEngine dbEngine = new DAO.DBEngine();
            //DAO.Database db = dbEngine.OpenDatabase(DbPath);
            //DAO.Recordset rs = db.OpenRecordset(TableName);
            //DAO.Field[] fields = new DAO.Field[dt.Columns.Count];
            //int i = 0;
            //foreach (DataColumn one in dt.Columns)
            //{
            //    fields[i++] = rs.Fields[one.ColumnName];
            //}
            //foreach (DataRow dr in dt.Rows)
            //{
            //    rs.AddNew();
            //    for (int j = 0; j < fields.Length; j++)
            //    {
            //        fields[j].Value = dr[j];
            //    }
            //    rs.Update();
            //}

            //rs.Close();
            //db.Close();
        }
        public static bool ExcuteTableSql2(string tableName, List<GoodsInfo> GoodsInfoList, out List<string> errors)
        {
            errors = new List<string>();
            OleDbTransaction tran = null;
            int index = 0;
            try
            {
                //开始事务
                tran = Connection.BeginTransaction();
                OleDbCommand cmd = Connection.CreateCommand();
                cmd.Transaction = tran;
                for (int i = 0; i < GoodsInfoList.Count; i++)
                {
                    index = i;
                    GoodsInfo goodInfo = GoodsInfoList[i];
                    string modelName = goodInfo.GetModelName();
                    string sqls = goodInfo.GetSql();
                    string pamerSql = goodInfo.GetAddSql();
                    string sql_insert = "Insert into " + "[" + modelName + "]" + sqls + pamerSql;
                    cmd.CommandText = sql_insert;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();//提交事务
                return true;

            }
            catch (Exception e)
            {
                errors.Add("第" + index + "数据出错,错误信息:" + e.Message);
                tran.Rollback();
                return false;
            }
            finally
            {
                
               
                Connection.Close();
            }

        }



        
    }
}
