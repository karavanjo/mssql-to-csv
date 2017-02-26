using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv.utils
{
    public static class ZipMaker
    {
        public static void Make(string dbName)
        {
            var dirPath = String.Format(@"{0}csv\{1}\",
                AppDomain.CurrentDomain.BaseDirectory,
                dbName);

            var zipPath = String.Format(@"{0}csv\{1}.zip",
                AppDomain.CurrentDomain.BaseDirectory,
                dbName);

            ZipFile.CreateFromDirectory(dirPath, zipPath);
        }
    }
}
