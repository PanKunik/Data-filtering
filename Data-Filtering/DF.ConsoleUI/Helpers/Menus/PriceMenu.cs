using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Library.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Menus
{
    public class PriceMenu
    {
        Filtering _filteringInstance;
        public PriceMenu(Filtering FilteringInstance)
        {
            _filteringInstance = FilteringInstance;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Price Menu");
            Console.WriteLine("1. Add min price");
            Console.WriteLine("2. Remove min price");
            Console.WriteLine("3. Add max price");
            Console.WriteLine("4. Remove max price");
            Console.WriteLine("5. Clear both filters for price");
        }

        public void InvokeAction(int optionNumber)
        {
            switch(optionNumber)
            {
                case -1:
                        Message.IntegerExpected();
                    break;
                case 1:
                        AddPriceFromFilter();
                    break;
                case 2:
                        ClearPriceFromFilter();
                    break;
                case 3:
                        AddPriceToFilter();
                    break;
                case 4:
                        ClearPriceToFilter();
                    break;
                case 5:
                        ClearBothPriceFilters();
                    break;
                default:
                        Message.NoOptionFound();
                    break;
            }
        }

        private void AddPriceFromFilter()
        {
            Message.PrintValidationSummary(_filteringInstance.AddMinPriceFilter(UserInput.CatchDecimal("Type min price for products: ")));
        }

        private void ClearPriceFromFilter()
        {
            _filteringInstance.RemoveMinPriceFilter();
        }

        private void AddPriceToFilter()
        {
            Message.PrintValidationSummary(_filteringInstance.AddMaxPriceFilter(UserInput.CatchDecimal("Type max price for products: ")));
        }

        private void ClearPriceToFilter()
        {
            _filteringInstance.RemoveMaxPriceFilter();
        }

        private void ClearBothPriceFilters()
        {
            _filteringInstance.RemoveBothPriceFilters();
        }
    }
}
