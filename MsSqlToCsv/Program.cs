using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString =  ConfigurationManager.ConnectionStrings["mssql"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {   
                connection.Open();
                var tables = connection.GetSchema("Tables");

                var tablesNames = new List<string>();

                foreach (DataRow tableInfo in connection.GetSchema("Tables").Rows)
                {
                    tablesNames.Add(tableInfo["TABLE_NAME"].ToString());
                }
            }
        }
    }
}
