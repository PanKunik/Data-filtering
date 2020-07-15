using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Helpers.Menus;
using DF.ConsoleUI.Library.Filters;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public class Option
    {
        Filtering _filteringInstance;

        public Option(Filtering FilteringInstance)
        {
            _filteringInstance = FilteringInstance;
        }

        public bool InvokeAction(int optionNumber)
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
                case 4:
                        InStock();
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

        private void Names()
        {
            NameMenu nameMenu = new NameMenu(_filteringInstance);

            nameMenu.Display();
            nameMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void Categories()
        {
            CategoryMenu categoryMenu = new CategoryMenu(_filteringInstance);

            categoryMenu.Display();
            categoryMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void Prices()
        {
            PriceMenu priceMenu = new PriceMenu(_filteringInstance);

            priceMenu.Display();
            priceMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void InStock()
        {
            InStockMenu inStockMenu = new InStockMenu(_filteringInstance);

            inStockMenu.Display();
            inStockMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }
    }
}
