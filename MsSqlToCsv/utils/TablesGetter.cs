using MsSqlToCsv.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv.utils
{
    public static class TablesGetter
    {
        public static List<TableInfo> GetTablesInfo(SqlConnection connection)
        {
            var tables = connection.GetSchema("Tables");

            var tablesNames = new List<TableInfo>();

            foreach (DataRow tableInfo in connection.GetSchema("Tables").Rows)
            {
                tablesNames.Add(new TableInfo()
                {
                    Name = tableInfo["TABLE_NAME"].ToString(),
                    TableCatalog = tableInfo["TABLE_CATALOG"].ToString(),
                    TableType = tableInfo["TABLE_TYPE"].ToString().Replace(" ", "_")
                });
            }

            return tablesNames;
        }
    }
}
