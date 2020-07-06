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
        }

        private static void WaitForButton()
        {
            Console.WriteLine("Press [Enter] to continue...");
            Console.ReadLine();
        }
    }
}
