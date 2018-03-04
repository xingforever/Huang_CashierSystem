using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Microsoft.Office.Interop.Access.Dao;

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


        ////批量数据的插入
        //public static void insertToStockDataByBatch(String[] sqlArray)
        //{
        //    try
        //    {
        //        OleDbConnection aConnection = Connection;
        //        aConnection.Open();
        //        OleDbTransaction transaction = aConnection.BeginTransaction();

        //        OleDbCommand aCommand = new OleDbCommand();
        //        aCommand.Connection = aConnection;
        //        aCommand.Transaction = transaction;
        //        for (int i = 0; i < sqlArray.Length; i++)
        //        {
        //            aCommand.CommandText = sqlArray[i];
        //            aCommand.ExecuteNonQuery();
        //            LogHelper.log(Convert.ToString(i));
        //        }
        //        transaction.Commit();
        //        aConnection.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        LogHelper.log(e.Message);
        //    }
        //}

        ////产生sql语句，为批量执行做准备
        //public static String generateSQLSentence(String stockCode, String transDate, String open,
        //                                    String close, String high, String low, String turn, String volume)
        //{
        //    String sql = "INSERT INTO stockData ( stockCode, transDate, [open], [close], high, low, turn, volume ) " +
        //                "VALUES (\"" + stockCode + "\"" +
        //                       ",\"" + transDate + "\"" +
        //                       ",\"" + open + "\"" +
        //                       ",\"" + close + "\"" +
        //                       ",\"" + high + "\"" +
        //                       ",\"" + low + "\"" +
        //                       ",\"" + turn + "\"" +
        //                       ",\"" + volume + "\")";
        //    return sql;
        //}

        //public  static void  AddAllData()
        //{
        //    DAO.DBEngine dbEngine = new DAO.DBEngine();
        //    DAO.Database db = dbEngine.OpenDatabase(databasePath);

        //    DAO.Recordset rs = db.OpenRecordset("Table");
        //    DAO.Field[] myFields = new DAO.Field[9];
        //    myFields[0] = rs.Fields["F_TYPE"];
        //    myFields[1] = rs.Fields["F_TAG"];
        //    myFields[2] = rs.Fields["F_RULEID"];
        //    myFields[3] = rs.Fields["F_SOURCEID"];
        //    myFields[4] = rs.Fields["F_TAGID"];
        //    myFields[5] = rs.Fields["F_DESCRIPTION"];
        //    myFields[6] = rs.Fields["F_TASKID"];
        //    myFields[7] = rs.Fields["F_RULEGROUP"];
        //    myFields[8] = rs.Fields["F_RULENAME"];

        //    int strTagKey = -1;
        //    for (int i = 0; i < sList.Count; i++)
        //    {
        //        int key;
        //        if (int.TryParse(sList[i].TagKey, out key))
        //            strTagKey = string.IsNullOrEmpty(sList[i].TagKey) ? -1 : int.Parse(sList[i].TagKey);

        //        rs.AddNew();

        //        myFields[0].Value = sList[i].RuleGroup;
        //        myFields[1].Value = sList[i].Tag;
        //        myFields[2].Value = sList[i].CheckRule.Key;
        //        myFields[3].Value = strTagKey;
        //        myFields[4].Value = strTagKey;
        //        myFields[5].Value = sList[i].Description;
        //        myFields[6].Value = nTaskID;
        //        myFields[7].Value = sList[i].RuleGroup;
        //        myFields[8].Value = sList[i].RuleName;

        //        rs.Update();

        //    }
        //    rs.Close();
        //    db.Close();

        //    return true;
        //}
    }
}
