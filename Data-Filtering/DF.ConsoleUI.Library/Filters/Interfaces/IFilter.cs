using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters.Interfaces
{
    public interface IFilter
    {
        void ClearFilters();
        List<Predicate<Product>> MakePredicates();
    }
}
