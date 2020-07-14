using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class Filtering
    {
        private List<Predicate<Product>> OrPredicates { get; set; } = new List<Predicate<Product>>();
        private List<Predicate<Product>> AndPredicates { get; set; } = new List<Predicate<Product>>();
        private CategoryFilter CategoryFilter { get; set; } = new CategoryFilter();
        private NameFilter NameFilter { get; set; } = new NameFilter();
        private PriceFilter PriceFilter { get; set; } = new PriceFilter();
        private InStockFilter InStockFilter { get; set; } = new InStockFilter();

        public List<Product> Filter(List<Product> productsToFilter)
        {
            MakeFilters();

            Expression<Func<Product, bool>> expression = products => ((OrPredicates.Count() > 0 ? OrPredicates.Any(productsToFilter => productsToFilter(products)) : true) && (AndPredicates.Count() > 0 ? AndPredicates.All(productsToFilter => productsToFilter(products)) : true));

            EnumerableQuery<Product> productsToFilterEnum = new EnumerableQuery<Product>(productsToFilter);
            var result = (from p in productsToFilterEnum.Where(expression) select p).ToList();

            return result;
        }

        private void MakeFilters()
        {
            OrPredicates = new List<Predicate<Product>>();
            AndPredicates = new List<Predicate<Product>>();

            MakeCategoryFilters();
            MakeNameFilter();
            MakePriceFilters();
            MakeInStockFilter();
        }

        private void MakeCategoryFilters()
        {
            foreach(var category in CategoryFilter.MakePredicates())
            {
                if(category != null)
                {
                    OrPredicates.Add(category);
                }
            }
        }

        private void MakeNameFilter()
        {
            if (NameFilter.MakePredicate() != null)
            {
                AndPredicates.Add(NameFilter.MakePredicate());
            }
        }

        private void MakePriceFilters()
        {
            foreach (var price in PriceFilter.MakePredicates())
            {
                if (price != null)
                {
                    AndPredicates.Add(price);
                }
            }
        }

        private void MakeInStockFilter()
        {
            if (InStockFilter.MakePredicate() != null)
            {
                AndPredicates.Add(InStockFilter.MakePredicate());
            }
        }

        public List<ValidationResult> AddCategoryFilter(string category)
        {
            return CategoryFilter.TryAddNewCategory(category);
        }

        public List<ValidationResult> AddNameFilter(string name)
        {
            return NameFilter.TryAddNewNameFilter(name);
        }

        public List<ValidationResult> AddMinPriceFilter(decimal minPrice)
        {
            return PriceFilter.TryAddMinimumPrice(minPrice);
        }

        public List<ValidationResult> AddMaxPriceFilter(decimal maxPrice)
        {
            return PriceFilter.TryAddMaximumPrice(maxPrice);
        }

        public List<ValidationResult> AddInStockFilter(int minInStock)
        {
            return InStockFilter.TryAddInStockFilter(minInStock);
        }

        public void RemoveCategoryFilter(string category)
        {
            CategoryFilter.RemoveFilter(category);
        }

        public void RemoveAllCategories()
        {
            CategoryFilter.ClearFilters();
        }

        public void RemoveNameFilter()
        {
            NameFilter.ClearFilter();
        }

        public void RemoveMinPriceFilter()
        {
            PriceFilter.RemoveMinimumPrice();
        }

        public void RemoveMaxPriceFilter()
        {
            PriceFilter.RemoveMaximumPrice();
        }

        public void RemoveBothPriceFilters()
        {
            PriceFilter.ClearFilters();
        }

        public void RemoveInStockFilter()
        {
            InStockFilter.ClearFilter();
        }

        public string GetNameFilter()
        {
            return NameFilter.GetName();
        }

        public decimal? GetMinimumPriceFilter()
        {
            return PriceFilter.GetMinimalPrice();
        }

        public decimal? GetMaximumPriceFilter()
        {
            return PriceFilter.GetMaximumPrice();
        }

        public int? GetInStockFilter()
        {
            return InStockFilter.GetInStock();
        }

        public string[] GetCategoryFilters()
        {
            return CategoryFilter.GetCategories();
        }
    }
}
