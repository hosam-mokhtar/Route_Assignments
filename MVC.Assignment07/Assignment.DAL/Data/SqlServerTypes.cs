
using static System.Formats.Asn1.AsnWriter;

namespace Mapping_View.Data
{
    internal class SqlServerTypes
    {
        public static string NVarChar(int length) => $"NVARCHAR({length})";
        public static string Decimal(int precision, int scale) => $"decimal({precision},{scale})";
    }
}
