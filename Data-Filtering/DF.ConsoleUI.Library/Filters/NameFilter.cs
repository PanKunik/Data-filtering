﻿using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class NameFilter : IFilter
    {
        private string Name { get; set; } = "";

        public List<ValidationResult> TryAddNewNameFilter(string name)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (CanAddNameFilter())
            {
                Name NameModel = new Name(name);
                ValidationContext validationContext = new ValidationContext(NameModel);

                if (Validator.TryValidateObject(NameModel, validationContext, result, true))
                {
                    AddNewNameFilter(name);
                    result.Add(new ValidationResult("Successfully added name filter."));
                }
            }
            else
            {
                result.Add(new ValidationResult("Can't add name filter. There already is one."));
            }

            return result;
        }

        private bool CanAddNameFilter()
        {
            return Name == "";
        }

        private void AddNewNameFilter(string name)
        {
            Name = name;
        }

        public void ClearFilters()
        {
            Name = "";
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> predicates = new List<Predicate<Product>>();

            predicates.Add(product => product.Name.Contains(Name));

            return predicates;
        }
    }
}