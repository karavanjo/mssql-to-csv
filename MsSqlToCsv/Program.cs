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
            foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
            {
                var connectionString = ConfigurationManager.ConnectionStrings[connectionStringSetting.Name].ConnectionString;
                HandleConnectionString(connectionString);
            }
        }

        static void HandleConnectionString(string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var tablesInfo = TablesGetter.GetTablesInfo(connection);
                StringBuilder stringBuilder;

                foreach (var tableInfo in tablesInfo)
                {
                    var getAllRowsSql = String.Format("SELECT * FROM [{0}]", tableInfo.Name);
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

                    CsvMaker.Make(tableInfo.TableCatalog, tableInfo.TableType, tableInfo.Name, stringBuilder);
                    Console.WriteLine(tableInfo.TableCatalog + " - " + tableInfo.TableType + " - " + tableInfo.Name);
                }

                if (tablesInfo.Count > 0)
                {
                    ZipMaker.Make(tablesInfo[0].TableCatalog);
                }
            }
        }
    }
}
