using DF.ConsoleUI.Library.Filters;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class Menu
    {
        public static Filtering FilteringInstance { get; set; }

        public static void SetInstanceForDisplaying(Filtering Instance)
        {
            FilteringInstance = Instance;
        }

        private static void MenuLabel()
        {
            Console.WriteLine($"{"Name contains:",-15}{"Categories:",20}{"Price:",15}{"Min. in stock:",25}");
        }

        private static void FilteringValues()
        {
            NameFilter();
            CategoriesFilter();
            PriceFilter();
            InStockFilter();
        }

        private static void NameFilter()
        {
            SetCursorPosition(5, 1);
            Console.Write($"{FilteringInstance.GetNameFilter()}");
        }

        private static void CategoriesFilter()
        {
            List<string> categories = new List<string>(FilteringInstance.GetCategoryFilters());
            PrintCategories(categories);
        }

        private static void PrintCategories(List<string> categories)
        {
            int verticalPosition = 1;

            foreach (var c in categories)
            {
                SetCursorPosition(26, verticalPosition);
                Console.Write($"{c}");
                verticalPosition++;
            }
        }

        private static void PriceFilter()
        {
            SetCursorPosition(45, 1);
            Console.Write($"{"Min: "}{FilteringInstance.GetMinimumPriceFilter(),0:C2}");
            SetCursorPosition(45, 2);
            Console.Write($"{"Max: "}{FilteringInstance.GetMaximumPriceFilter(),0:C2}");
        }

        private static void InStockFilter()
        {
            SetCursorPosition(75, 1);
            Console.Write($"{FilteringInstance.GetInStockFilter()}");
        }

        private static void ResetCursorPosition()
        {
            SetCursorPosition(0, 4);
        }

        private static void SetCursorPosition(int x, int y)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
        }

        public static void Display(List<Product> products)
        {
            Console.Clear();
            MenuLabel();
            FilteringValues();
            ResetCursorPosition();
            ProductsLabel();
            PrintAllProducts(products);
        }

        private static void ProductsLabel()
        {
            Console.Write($"{"ID",-8}{"NAME",8}{"CATEGORY",25}{"PRICE",20}{"IN STOCK",19}");
        }

        private static void PrintAllProducts(List<Product> products)
        {
            ProductsPrinter.PrintProducts(products);
        }
    }
}
