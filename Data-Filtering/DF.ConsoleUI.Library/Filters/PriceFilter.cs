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
        private Price MinimumPrice { get; set; } = new Price();
        private Price MaximumPrice { get; set; } = new Price();

        public List<ValidationResult> TryAddMinimumPrice(decimal minPrice)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if(CanAddMinimumPrice())
            {
                Price NewMinPrice = new Price(minPrice);
                ValidationContext validationContext = new ValidationContext(NewMinPrice);

                if(Validator.TryValidateObject(NewMinPrice, validationContext, results, true))
                { 
                    AddNewMinimumPrice(minPrice);
                    results.Add(new ValidationResult("Sucessfully added minimum price."));
                }
            }
            else
            {
                results.Add(new ValidationResult("Can't add minimum price. There is already one."));
            }

            return results;
        }

        private bool CanAddMinimumPrice()
        {
            return MinimumPrice.Amount == null;
        }

        private void AddNewMinimumPrice(decimal minPrice)
        {
            MinimumPrice.Amount = minPrice;
        }
        public List<ValidationResult> TryAddMaximumPrice(decimal maxPrice)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (CanAddMaximumPrice())
            {
                Price NewMaxPrice = new Price(maxPrice);
                ValidationContext validationContext = new ValidationContext(NewMaxPrice);

                if (Validator.TryValidateObject(NewMaxPrice, validationContext, results, true))
                {
                    AddNewMaximumPrice(maxPrice);
                    results.Add(new ValidationResult("Sucessfully added maximum price."));
                }
            }
            else
            {
                results.Add(new ValidationResult("Can't add maximum price. There is already one."));
            }

            return results;
        }

        private bool CanAddMaximumPrice()
        {
            return MaximumPrice.Amount == null;
        }

        private void AddNewMaximumPrice(decimal maxPrice)
        {
            MaximumPrice.Amount = maxPrice;
        }

        public void RemoveMinimumPrice()
        {
            MaximumPrice.Amount = null;
        }

        public void RemoveMaximumPrice()
        {
            MinimumPrice.Amount = null;
        }

        public void ClearFilters()
        {
            RemoveMinimumPrice();
            RemoveMaximumPrice();
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> predicates = new List<Predicate<Product>>();

            predicates.Add(product => product.Price >= ((MinimumPrice.Amount != null) ? MinimumPrice.Amount : 0));
            predicates.Add(product => product.Price <= ((MaximumPrice.Amount != null) ? MaximumPrice.Amount : decimal.MaxValue));

            return predicates;
        }
    }
}
