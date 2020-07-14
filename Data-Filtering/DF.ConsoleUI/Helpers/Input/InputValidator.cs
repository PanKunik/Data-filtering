using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Input
{
    public static class InputValidator
    {
        public static bool TryValidateInt(string input, out int output)
        {
            bool result = true;

            if (int.TryParse(input, out output) == false)
            {
                output = -1;
                result = false;
            }

            return result;
        }

        public static bool TryValidateDecimal(string input, out decimal output)
        {
            bool result = true;

            if (decimal.TryParse(input, out output) == false)
            {
                output = -1M;
                result = false;
            }

            return result;
        }
    }
}
