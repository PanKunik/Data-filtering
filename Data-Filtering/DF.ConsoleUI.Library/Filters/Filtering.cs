using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
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
        private CategoryFilter CategoryFilter { get; set; }
        private NameFilter NameFilter { get; set; }
        private PriceFilter PriceFilter { get; set; }
        private InStockFilter InStockFilter { get; set; }

        public Filtering()
        {
            CategoryFilter = new CategoryFilter();
            NameFilter = new NameFilter();
            PriceFilter = new PriceFilter();
            InStockFilter = new InStockFilter();
        }
        public void Filter(List<Product> productsToFilter)
        {
            CategoryFilter.TryAddNewCategory("Rowery");
            CategoryFilter.TryAddNewCategory("Football");

            PriceFilter.TryAddMaximumPrice(1900.0M);

            NameFilter.TryAddNewNameFilter("i");

            foreach(var item in CategoryFilter.MakePredicates())
                OrPredicates.Add(item);

            foreach(var item in PriceFilter.MakePredicates())
                AndPredicates.Add(item);

            foreach (var item in NameFilter.MakePredicates())
                AndPredicates.Add(item);

            Expression<Func<Product, bool>> expression = products => OrPredicates.Any(productsToFilter => productsToFilter(products)) && AndPredicates.All(productsToFilter => productsToFilter(products));

            EnumerableQuery<Product> productsToFilterEnum = new EnumerableQuery<Product>(productsToFilter);
            var result = (from p in productsToFilterEnum.Where(expression) select p).ToList();
        }

        private void MakeFilters()
        {

        }
    }
}
