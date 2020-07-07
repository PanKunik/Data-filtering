using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class ProductsPrinter
    {
        public static void PrintProducts(List<Product> Products)
        {
            foreach(var Product in Products)
            {
                PrintProduct(Product);
            }
        }

        private static void PrintProduct(Product Product)
        {
            Console.Write($"{Product.Id,-12}{Product.Name,-21}{Product.Category,-23}{Product.Price,-12:C2}{Product.InStock,12}");
        }
    }
}
