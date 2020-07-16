using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Library.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Menus
{
    public class InStockMenu
    {
        Filtering _filteringInstance;

        public InStockMenu(Filtering filteringInstance)
        {
            _filteringInstance = filteringInstance;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("InStock Menu");
            Console.WriteLine("1. Add min in stock");
            Console.WriteLine("2. Remove");
        }

        public void InvokeAction(int optionNumber)
        {
            switch(optionNumber)
            {
                case -1:
                        Message.IntegerExpected();
                    break;
                case 1:
                        AddMinInStockFilter();
                    break;
                case 2:
                        ClearMinInStockFilter();
                    break;
                default:
                    Message.NoOptionFound();
                    break;
            }
        }

        private void AddMinInStockFilter()
        {
            Message.PrintValidationSummary(_filteringInstance.AddInStockFilter(UserInput.CatchInt("Type min in stock: ")));
        }

        private void ClearMinInStockFilter()
        {
            _filteringInstance.RemoveInStockFilter();
        }
    }
}
