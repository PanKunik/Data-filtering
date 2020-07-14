using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Library.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Menus
{
    public static class NameMenu
    {
        static Filtering _filteringInstance;

        public static void SetFilteringInstance(Filtering FilteringInstance)
        {
            _filteringInstance = FilteringInstance;
        }

        public static void Display()
        {
            Console.Clear();
            Console.WriteLine("Name Menu");
            Console.WriteLine("1. New phrase");
            Console.WriteLine("2. Clear phrase");
        }

        public static void InvokeAction(int optionNumber)
        {
            switch(optionNumber)
            {
                case -1:
                    Message.WrongOption();
                    break;
                case 1:
                    AddNewNameFilter();
                    break;
                case 2:
                    ClearNameFilter();
                    break;
                default:
                    Message.NoOptionFound();
                    break;
            }
        }

        private static void AddNewNameFilter()
        {
            Message.PrintValidationSummary(_filteringInstance.AddNameFilter(UserInput.CatchString("Type new phrase: ")));
        }

        private static void ClearNameFilter()
        {
            _filteringInstance.RemoveNameFilter();
        }
    }
}
