using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToCsv.model
{
    public class TableInfo
    {   
        public string Name { get; set; }
        public string TableType { get; set; }
        public string TableCatalog { get; set; }
    }
}
