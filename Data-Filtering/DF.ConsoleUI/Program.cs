using DF.ConsoleUI.Helpers;
using DF.ConsoleUI.Library.Controllers;
using DF.ConsoleUI.Library.Filters;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace DF.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductController ProductsController = new ProductController();
            ProductsController.PopulateProducts();

            Filtering filter = new Filtering();

            Menu.SetInstanceForDisplaying(filter);
            Menu.Display(ProductsController.Products);

            filter.AddMaxPriceFilter(2000);
            filter.AddMinPriceFilter(1.5M);

            filter.AddInStockFilter(1);

            filter.AddCategoryFilter("Rowery");
            filter.AddCategoryFilter("Football");
            filter.AddCategoryFilter("Nabiał");
            // List<ValidationResult> results;
            Console.WriteLine("\nClick to continue ... ");
            
            Console.ReadLine();
            Console.Clear();

            List<Product> prods = filter.Filter(ProductsController.Products);

            Menu.Display(prods);

            Console.WriteLine("\nClick to continue ... ");
            Console.ReadLine();
        }
    }
}
