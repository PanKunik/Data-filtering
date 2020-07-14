using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Input
{
    public static class Input
    {
        public static string CatchInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
    }
}
