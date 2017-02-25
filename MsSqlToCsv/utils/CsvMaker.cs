using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv.utils
{
    public static class CsvMaker
    {
        public static void Make(string dbName, string tableName, StringBuilder stringBuilder)
        {
            var filePath = String.Format(@"{0}csv\{1}-{2}.csv", 
                AppDomain.CurrentDomain.BaseDirectory,
                dbName, tableName);

            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            File.WriteAllText(file.FullName, stringBuilder.ToString());
        }
    }
}
