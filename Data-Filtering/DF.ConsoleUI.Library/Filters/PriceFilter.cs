using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class PriceFilter : IFilter
    {
        private Price _minimumPrice = new Price();
        private Price _maximumPrice = new Price();

        public List<ValidationResult> TryAddMinimumPrice(decimal minPrice)
        {
            List<ValidationResult> Results = new List<ValidationResult>();

            if(CanAddMinimumPrice())
            {
                Price NewMinPrice = new Price(minPrice);
                ValidationContext ValidationContext = new ValidationContext(NewMinPrice);

                if(Validator.TryValidateObject(NewMinPrice, ValidationContext, Results, true))
                { 
                    AddNewMinimumPrice(minPrice);
                    Results.Add(new ValidationResult("Sucessfully added minimum price."));
                }
            }
            else
            {
                Results.Add(new ValidationResult("Can't add minimum price. There is already one."));
            }

            return Results;
        }

        private bool CanAddMinimumPrice()
        {
            return _minimumPrice.Amount == null;
        }

        private void AddNewMinimumPrice(decimal minPrice)
        {
            _minimumPrice.Amount = minPrice;
        }
        public List<ValidationResult> TryAddMaximumPrice(decimal maxPrice)
        {
            List<ValidationResult> Results = new List<ValidationResult>();

            if (CanAddMaximumPrice())
            {
                Price NewMaxPrice = new Price(maxPrice);
                ValidationContext ValidationContext = new ValidationContext(NewMaxPrice);

                if (Validator.TryValidateObject(NewMaxPrice, ValidationContext, Results, true))
                {
                    AddNewMaximumPrice(maxPrice);
                    Results.Add(new ValidationResult("Sucessfully added maximum price."));
                }
            }
            else
            {
                Results.Add(new ValidationResult("Can't add maximum price. There is already one."));
            }

            return Results;
        }

        private bool CanAddMaximumPrice()
        {
            return _maximumPrice.Amount == null;
        }

        private void AddNewMaximumPrice(decimal maxPrice)
        {
            _maximumPrice.Amount = maxPrice;
        }

        public void RemoveMinimumPrice()
        {
            _maximumPrice.Amount = null;
        }

        public void RemoveMaximumPrice()
        {
            _minimumPrice.Amount = null;
        }

        public void ClearFilters()
        {
            RemoveMinimumPrice();
            RemoveMaximumPrice();
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> Predicates = new List<Predicate<Product>>();

            Predicates.Add(Product => Product.Price >= ((_minimumPrice.Amount != null) ? _minimumPrice.Amount : 0) && Product.Price <= ((_maximumPrice.Amount != null) ? _maximumPrice.Amount : decimal.MaxValue));

            return Predicates;
        }

        public decimal? GetMinimalPrice()
        {
            return _minimumPrice.Amount;
        }

        public decimal? GetMaximumPrice()
        {
            return _maximumPrice.Amount;
        }
    }
}
