using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class InStockFilter : IFilter
    {
        private InStock MinimumInStock { get; set; } = new InStock();

        public List<ValidationResult> TryAddInStockFilter(int minInStock)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if(CanAddNewInStock())
            {
                InStock NewInStock = new InStock(minInStock);
                ValidationContext validationContext = new ValidationContext(NewInStock);

                if(Validator.TryValidateObject(NewInStock, validationContext, results, true))
                {
                    AddNewInStock(minInStock);
                    results.Add(new ValidationResult("Successfully added new in stock filter."));
                }
            }
            else
            {
                results.Add(new ValidationResult("Can't add in stock filter. There already is one."));
            }

            return results;
        }

        private bool CanAddNewInStock()
        {
            return MinimumInStock.InStockAmount == null;
        }

        private void AddNewInStock(int minInStock)
        {
            MinimumInStock.InStockAmount = minInStock;
        }

        public void ClearFilters()
        {
            MinimumInStock.InStockAmount = null;
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> predicates = new List<Predicate<Product>>();

            predicates.Add(product => product.InStock >= MinimumInStock.InStockAmount);

            return predicates;
        }
    }
}
