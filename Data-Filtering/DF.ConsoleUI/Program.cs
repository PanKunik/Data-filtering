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

            Menu.Display();
            List<ValidationResult> results;
            Filtering filter = new Filtering();

            filter.Filter(ProductsController.Products);

            //List<Predicate<Product>> criterias = new List<Predicate<Product>>();

            //Expression<Func<Product, bool>> expression = product => criterias.All(pToFilter => pToFilter(product));

            //do
            //{
            //    Console.Clear();

            //    EnumerableQuery<Product> productsToFilter = new EnumerableQuery<Product>(ProductsController.Products);
            //    List<Product> newProducts = (from pr in productsToFilter.Where(expression) select pr).ToList();

            //}
            //while (program);

            Console.Read();
        }
    }
}
