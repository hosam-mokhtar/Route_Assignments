using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Data
{
    internal class SqlServerTypes
    {
        public static string NVarChar(int length) => $"NVARCHAR({length})";
    }
}
