using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Library.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Menus
{
    public class NameMenu
    {
        Filtering _filteringInstance;

        public NameMenu(Filtering filteringInstance)
        {
            _filteringInstance = filteringInstance;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Name Menu");
            Console.WriteLine("1. New phrase");
            Console.WriteLine("2. Clear phrase");
        }

        public void InvokeAction(int optionNumber)
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

        private void AddNewNameFilter()
        {
            Message.PrintValidationSummary(_filteringInstance.AddNameFilter(UserInput.CatchString("Type new phrase: ")));
        }

        private void ClearNameFilter()
        {
            _filteringInstance.RemoveNameFilter();
        }
    }
}
