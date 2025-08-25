using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination
{
    internal static class ConsoleHelper
    {
        public static int ReadInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            do
            {
                Console.WriteLine(message);
            }
            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);

            return value;
        }
        public static string ReadString(string message)
        {
            string value;
            do
            {
                Console.WriteLine(message);
                value = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(value));

            return value;
        }

    }
}
