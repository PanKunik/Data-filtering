using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers
{
    public static class ProductsPrinter
    {
        public static void PrintProducts(List<Product> products)
        {
            foreach(Product Product in products)
            {
                PrintProduct(Product);
            }
        }

        private static void PrintProduct(Product product)
        {
            Console.Write($"{product.Id,-12}{product.Name,-21}{product.Category,-23}{product.Price,-12:C2}{product.InStock,12}");
        }
    }
}
