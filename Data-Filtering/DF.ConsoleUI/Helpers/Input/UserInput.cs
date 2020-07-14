using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Input
{
    public static class UserInput
    {
        public static int CatchPositiveInt(string message)
        {
            int result;

            InputValidator.TryValidateInt(Input.CatchInput(message), out result);

            if(result < 0)
            {
                Message.WrongOption();
            }

            return result;
        }

        public static int CatchInt(string message)
        {
            int result;

            if(InputValidator.TryValidateInt(Input.CatchInput(message), out result) == false)
            {
                Message.IntegerExpected();
            }

            return result;
        }

        public static string CatchString(string message)
        {
            return Input.CatchInput(message);
        }

        public static decimal CatchDecimal(string message)
        {
            decimal result;

            if(InputValidator.TryValidateDecimal(Input.CatchInput(message), out result) == false)
            {
                Message.DecimalExpected();
            }

            return result;
        }
    }
}
