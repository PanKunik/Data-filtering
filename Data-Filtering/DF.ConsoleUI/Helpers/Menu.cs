using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class Menu
    {
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
            Console.Write($"{"Rower miejski"}");
        }

        private static void CategoriesFilter()
        {
            List<string> categories = new List<string>()
            {
                "Odzież",
                "Rowery",
                "Buty"
            };

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
            Console.Write($"{"Min: 15 PLN"}");
            SetCursorPosition(45, 2);
            Console.Write($"{"Max: 1500 PLN"}");
        }

        private static void InStockFilter()
        {
            SetCursorPosition(75, 1);
            Console.Write($"{"325"}");
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

        public static void Display()
        {
            Console.Clear();
            MenuLabel();
            FilteringValues();
            ResetCursorPosition();
            ProductsLabel();
        }

        private static void ProductsLabel()
        {
            Console.WriteLine($"{"ID",-8}{"NAME",8}{"CATEGORY",25}{"PRICE",20}{"IN STOCK",19}");
        }
    }
}
