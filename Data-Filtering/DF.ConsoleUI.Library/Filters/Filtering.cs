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
        private List<Predicate<Product>> _orPredicates;
        private List<Predicate<Product>> _andPredicates;
        private CategoryFilter _categoryFilter = new CategoryFilter();
        private NameFilter _nameFilter = new NameFilter();
        private PriceFilter _priceFilter = new PriceFilter();
        private InStockFilter _inStockFilter = new InStockFilter();

        public List<Product> Filter(List<Product> productsToFilter)
        {
            MakeFilters();

            Expression<Func<Product, bool>> Expression = Products => ((_orPredicates.Count() > 0 ? _orPredicates.Any(productsToFilter => productsToFilter(Products)) : true) && (_andPredicates.Count() > 0 ? _andPredicates.All(productsToFilter => productsToFilter(Products)) : true));

            EnumerableQuery<Product> ProductsToFilterEnum = new EnumerableQuery<Product>(productsToFilter);
            var result = (from p in ProductsToFilterEnum.Where(Expression) select p).ToList();

            return result;
        }

        private void MakeFilters()
        {
            _orPredicates = new List<Predicate<Product>>();
            _andPredicates = new List<Predicate<Product>>();

            MakeCategoryFilters();
            MakeNameFilter();
            MakePriceFilters();
            MakeInStockFilter();
        }

        private void MakeCategoryFilters()
        {
            foreach(var category in _categoryFilter.MakePredicates())
            {
                if(category != null)
                {
                    _orPredicates.Add(category);
                }
            }
        }

        private void MakeNameFilter()
        {
            if (_nameFilter.MakePredicate() != null)
            {
                _andPredicates.Add(_nameFilter.MakePredicate());
            }
        }

        private void MakePriceFilters()
        {
            foreach (var price in _priceFilter.MakePredicates())
            {
                if (price != null)
                {
                    _andPredicates.Add(price);
                }
            }
        }

        private void MakeInStockFilter()
        {
            if (_inStockFilter.MakePredicate() != null)
            {
                _andPredicates.Add(_inStockFilter.MakePredicate());
            }
        }

        public List<ValidationResult> AddCategoryFilter(string category)
        {
            return _categoryFilter.TryAddNewCategory(category);
        }

        public List<ValidationResult> AddNameFilter(string name)
        {
            return _nameFilter.TryAddNewNameFilter(name);
        }

        public List<ValidationResult> AddMinPriceFilter(decimal minPrice)
        {
            return _priceFilter.TryAddMinimumPrice(minPrice);
        }

        public List<ValidationResult> AddMaxPriceFilter(decimal maxPrice)
        {
            return _priceFilter.TryAddMaximumPrice(maxPrice);
        }

        public List<ValidationResult> AddInStockFilter(int minInStock)
        {
            return _inStockFilter.TryAddInStockFilter(minInStock);
        }

        public void RemoveCategoryFilter(string category)
        {
            _categoryFilter.RemoveFilter(category);
        }

        public void RemoveAllCategories()
        {
            _categoryFilter.ClearFilters();
        }

        public void RemoveNameFilter()
        {
            _nameFilter.ClearFilter();
        }

        public void RemoveMinPriceFilter()
        {
            _priceFilter.RemoveMinimumPrice();
        }

        public void RemoveMaxPriceFilter()
        {
            _priceFilter.RemoveMaximumPrice();
        }

        public void RemoveBothPriceFilters()
        {
            _priceFilter.ClearFilters();
        }

        public void RemoveInStockFilter()
        {
            _inStockFilter.ClearFilter();
        }

        public string GetNameFilter()
        {
            return _nameFilter.GetName();
        }

        public decimal? GetMinimumPriceFilter()
        {
            return _priceFilter.GetMinimalPrice();
        }

        public decimal? GetMaximumPriceFilter()
        {
            return _priceFilter.GetMaximumPrice();
        }

        public int? GetInStockFilter()
        {
            return _inStockFilter.GetInStock();
        }

        public string[] GetCategoryFilters()
        {
            return _categoryFilter.GetCategories();
        }
    }
}