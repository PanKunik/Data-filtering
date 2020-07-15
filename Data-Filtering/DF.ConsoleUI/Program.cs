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
        static void Main(string[] args)
        {
            ProductController ProductsController = CreateProductControllerInstance();
            Filtering filter = CreateFilteringInstance();

            Menu.SetInstanceForDisplaying(filter);

            bool programMainLoop;

            do
            {
                List<Product> prods = filter.Filter(ProductsController.Products);
                Menu.Display(prods);

                Option option = new Option(filter);
                programMainLoop = option.InvokeAction(UserInput.CatchPositiveInt("Type your option: "));
            }
            while (programMainLoop);
        }

        static ProductController CreateProductControllerInstance()
        {
            ProductController ControllerForProducts = new ProductController();
            ControllerForProducts.PopulateProducts();

            return ControllerForProducts;
        }

        static Filtering CreateFilteringInstance()
        {
            return new Filtering();
        }
    }
}
