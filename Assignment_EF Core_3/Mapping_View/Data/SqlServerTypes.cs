using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping_View.Data
{
    internal class SqlServerTypes
    {
        public static string NVarChar(int length) => $"NVARCHAR({length})";
    }
}
