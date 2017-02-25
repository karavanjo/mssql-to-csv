using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv.utils
{
    public static class ColumnsGetter
    {
        public static List<string> GetColumnsNames(SqlDataReader reader)
        {
            var columns = new List<string>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }

            return columns;
        }
    }
}
