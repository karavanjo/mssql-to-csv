using MsSqlToCsv.utils;
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

                var tablesNames = TablesGetter.GetTablesNames(connection);
                StringBuilder stringBuilder;

                foreach (var tableName in tablesNames)
                {
                    var getAllRowsSql = String.Format("SELECT * FROM {0}", tableName);
                    var getAllRowsCommand = new SqlCommand(getAllRowsSql, connection);

                    using (SqlDataReader reader = getAllRowsCommand.ExecuteReader())
                    {
                        var columnsNames = ColumnsGetter.GetColumnsNames(reader);

                        stringBuilder = new StringBuilder();

                        foreach (var columnName in columnsNames)
                        {
                            var value = columnName;
                            stringBuilder.Append(value.Trim()).Append("\t");
                        }
                        stringBuilder.AppendLine();

                        while (reader.Read())
                        {
                            
                            foreach (var columnName in columnsNames)
                            {
                                var value = reader[columnName].ToString();
                                stringBuilder.Append(value.Trim()).Append("\t");
                            }
                            stringBuilder.AppendLine();
                        }
                    }

                    CsvMaker.Make(connection.Database.ToString(), tableName, stringBuilder);
                }

                
            }
        }
    }
}
