using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Helpers.Menus;
using DF.ConsoleUI.Library.Controllers;
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
        PagedProducts _pagedProductsInstance;

        public Option(Filtering filteringInstance, PagedProducts pagedProductsInstance)
        {
            _filteringInstance = filteringInstance;
            _pagedProductsInstance = pagedProductsInstance;
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
                case 5:
                        NextPage();
                    break;
                case 6:
                        PreviousPage();
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
            NameMenu NameMenu = new NameMenu(_filteringInstance);

            NameMenu.Display();
            NameMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void Categories()
        {
            CategoryMenu CategoryMenu = new CategoryMenu(_filteringInstance);

            CategoryMenu.Display();
            CategoryMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void Prices()
        {
            PriceMenu PriceMenu = new PriceMenu(_filteringInstance);

            PriceMenu.Display();
            PriceMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void InStock()
        {
            InStockMenu InStockMenu = new InStockMenu(_filteringInstance);

            InStockMenu.Display();
            InStockMenu.InvokeAction(UserInput.CatchPositiveInt("Type option: "));
        }

        private void NextPage()
        {
            _pagedProductsInstance.NextPage();
        }

        private void PreviousPage()
        {
            _pagedProductsInstance.PreviousPage();
        }
    }
}
