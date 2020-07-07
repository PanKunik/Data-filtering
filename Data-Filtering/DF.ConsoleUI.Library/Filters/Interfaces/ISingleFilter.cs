using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Library.Filters.Interfaces
{
    public interface ISingleFilter
    {
        void ClearFilter();
        Predicate<Product> MakePredicate();
    }
}
