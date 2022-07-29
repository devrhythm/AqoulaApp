using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqola.Application
{
    internal static class StringExtension
    {
        private const int SkipCommandLength = 1;

        public static object[] GetOptions(this string command)
        {
            object[] options = command.Split(' ');
            return options.Skip(SkipCommandLength).ToArray();
        }

        public static int ToInt(this object? input)
        {
            if (input == null)
            {
                return 0;
            }

            if (int.TryParse(input.ToString(), out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
