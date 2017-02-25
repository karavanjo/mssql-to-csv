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
        public static List<string> GetTablesNames (SqlConnection connection)
        {
            var tables = connection.GetSchema("Tables");

            var tablesNames = new List<string>();

            foreach (DataRow tableInfo in connection.GetSchema("Tables").Rows)
            {
                tablesNames.Add(tableInfo["TABLE_NAME"].ToString());
            }

            return tablesNames;
        }
    }
}
