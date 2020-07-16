using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class NameFilter : ISingleFilter
    {
        private string _name = "";

        public List<ValidationResult> TryAddNewNameFilter(string name)
        {
            List<ValidationResult> Results = new List<ValidationResult>();

            if (CanAddNameFilter())
            {
                Name NameModel = new Name(name);
                ValidationContext ValidationContext = new ValidationContext(NameModel);

                if (Validator.TryValidateObject(NameModel, ValidationContext, Results, true))
                {
                    AddNewNameFilter(name);
                    Results.Add(new ValidationResult("Successfully added name filter."));
                }
            }
            else
            {
                Results.Add(new ValidationResult("Can't add name filter. There already is one."));
            }

            return Results;
        }

        private bool CanAddNameFilter()
        {
            return _name == "";
        }

        private void AddNewNameFilter(string name)
        {
            _name = name;
        }

        public void ClearFilter()
        {
            _name = "";
        }

        public Predicate<Product> MakePredicate()
        {
            return _name != "" ? (Product => Product.Name.Contains(_name)) : (Predicate<Product>)null;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
