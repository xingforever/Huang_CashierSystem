
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var dbConnectionString = "Provider=Microsoft.ACE.OleDb.12.0;Data source=Access文件绝对路径;Persist Security Info=False";
            conn = new OleDbConnection(dbConnectionString);
            conn.Open();
            var exists = conn.GetSchema("Tables", new string[4] { null, null, "__MigrationHistory", "TABLE" }).Rows.Count > 0;

            if (!exists)
            {
                OleDbCommand cmd = new OleDbCommand("CREATE TABLE __MigrationHistory([MigrationId] TEXT, [ContextKey] MEMO, [Model] OleObject, [ProductVersion] TEXT)", conn);
                cmd.ExecuteNonQuery();

                cmd = new OleDbCommand("INSERT INTO __MigrationHistory(MigrationId, ContextKey, ProductVersion) VALUES('" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "', '" + typeof(ATOrionContext).Namespace + ".ATOrionContext', '6.1.3-40302')", conn);
                cmd.ExecuteNonQuery();

            }
        }
    }
}
