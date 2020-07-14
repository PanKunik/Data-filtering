using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class Message
    {
        public static void PrintValidationSummary(List<ValidationResult> validationMessages)
        {
            foreach (var message in validationMessages)
            {
                Console.WriteLine(message);
            }

            WaitForButton();
        }

        public static void WrongOption()
        {
            PrintMessage("Wrong input.\nOption must be integer number greater than 0.");
        }

        public static void IntegerExpected()
        {
            PrintMessage("Wrong input.\nInteger number expected.");
        }

        public static void DecimalExpected()
        {
            PrintMessage("Wrong input.\nDecimal number expected.");
        }

        public static void Goodbye()
        {
            PrintMessage("You are exiting the program. Goodbye!");
        }

        public static void NoOptionFound()
        {
            PrintMessage("There is no option with given number.");
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
            WaitForButton();
        }

        private static void WaitForButton()
        {
            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadLine();
        }
    }
}