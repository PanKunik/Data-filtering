using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Helpers.Menus;
using DF.ConsoleUI.Library.Filters;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class Option
    {
        static Filtering _filteringInstance;

        public static void SetFilteringInstance(Filtering FilteringInstance)
        {
            _filteringInstance = FilteringInstance;
        }

        public static bool InvokeAction(int optionNumber)
        {
            bool result = true;

            switch(optionNumber)
            {
                case -1:
                        Message.WrongOption();
                    break;
                case 1:
                        Names();
                    break;
                case 2:
                        Categories();
                    break;
                case 3:
                        Prices();
                    break;
                case 404:
                        Message.Goodbye();
                        result = false;
                    break;
                default:
                        Message.NoOptionFound();
                    break;
            }

            return result;
        }

        private static void Names()
        {
            NameMenu.SetFilteringInstance(_filteringInstance);
            NameMenu.Display();

            NameMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private static void Categories()
        {
            CategoryMenu.SetFilteringInstance(_filteringInstance);
            CategoryMenu.Display();

            CategoryMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private static void Prices()
        {
            PriceMenu.SetFilteringInstance(_filteringInstance);
            PriceMenu.Display();

            PriceMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }
    }
}
