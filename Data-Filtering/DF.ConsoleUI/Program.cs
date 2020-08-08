using DF.ConsoleUI.Helpers;
using DF.ConsoleUI.Helpers.Input;
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
        private const int WindowWidth = 80;
        private const int WindowHeight = 25;

        static void Main(string[] args)
        {
            Console.SetWindowSize(WindowWidth, WindowHeight);

            ProductController ProductsController = CreateProductControllerInstance();
            Filtering Filter = CreateFilteringInstance();
            PagedProducts Products = CreatePagedProductsInstance();

            Menu.SetInstanceForDisplaying(Filter);

            bool programMainLoop;

            do
            {
                Products.SetListOfProducts(Filter.Filter(ProductsController.GetAllProducts()));
                Menu.Display(Products.GetPage());

                Option Option = new Option(Filter, Products);
                programMainLoop = Option.InvokeAction(UserInput.CatchPositiveInt("Type your option: "));
            }
            while (programMainLoop);
        }

        static ProductController CreateProductControllerInstance()
        {
            return new ProductController();
        }

        static Filtering CreateFilteringInstance()
        {
            return new Filtering();
        }

        static PagedProducts CreatePagedProductsInstance()
        {
            return new PagedProducts();
        }
    }
}
