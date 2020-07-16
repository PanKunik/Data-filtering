using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class InStockFilter : ISingleFilter
    {
        private InStock _minimumInStock = new InStock();

        public List<ValidationResult> TryAddInStockFilter(int minInStock)
        {
            List<ValidationResult> Results = new List<ValidationResult>();

            if(CanAddNewInStock())
            {
                InStock NewInStock = new InStock(minInStock);
                ValidationContext ValidationContext = new ValidationContext(NewInStock);

                if(Validator.TryValidateObject(NewInStock, ValidationContext, Results, true))
                {
                    AddNewInStock(minInStock);
                    Results.Add(new ValidationResult("Successfully added new in stock filter."));
                }
            }
            else
            {
                Results.Add(new ValidationResult("Can't add in stock filter. There already is one."));
            }

            return Results;
        }

        private bool CanAddNewInStock()
        {
            return _minimumInStock.InStockAmount == null;
        }

        private void AddNewInStock(int minInStock)
        {
            _minimumInStock.InStockAmount = minInStock;
        }

        public void ClearFilter()
        {
            _minimumInStock.InStockAmount = null;
        }

        public Predicate<Product> MakePredicate()
        {
            return _minimumInStock.InStockAmount != null ? Product => Product.InStock >= _minimumInStock.InStockAmount : (Predicate<Product>)null;
        }

        public int? GetInStock()
        {
            return _minimumInStock.InStockAmount;
        }
    }
}
