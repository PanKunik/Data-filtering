using DF.ConsoleUI.Library.Filters.Interfaces;
using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;

namespace DF.ConsoleUI.Library.Filters
{
    public class CategoryFilter : IFilter
    {
        private string[] _categories { get; set; } = new string[3] { "", "", "" };

        public List<ValidationResult> TryAddNewCategory(string category)
        {
            List<ValidationResult> Results = new List<ValidationResult>();

            if (CanAddNewCategory())
            {
                Category CategoryModel = MakeCategoryModel(category);
                ValidationContext ValidationContext = new ValidationContext(CategoryModel);

                if (Validator.TryValidateObject(CategoryModel, ValidationContext, Results, true))
                { 
                    AddNewCategory(CategoryModel);
                    Results.Add(new ValidationResult("Successfully added new filter for category."));
                }
            }
            else
            {
                Results.Add(new ValidationResult("Can't add new filter for category.\nYou have reached maximum filters for categories."));
            }

            return Results;
        }

        private bool CanAddNewCategory()
        {
            int count = 0;

            foreach(var category in _categories)
            {
                if(category != "")
                {
                    count++;
                }
            }

            return count < 3;
        }

        private Category MakeCategoryModel(string category)
        {
            return new Category(category);
        }

        private void AddNewCategory(Category category)
        {
            for(int index = 0; index < _categories.Length; index++)
            {
                if(_categories[index] == "")
                {
                    _categories[index] = category.CategoryName;
                    break;
                }
            }
        }

        public void RemoveFilter(string category)
        {
            for(int index = 0; index < _categories.Length; index++)
            {
                if(_categories[index] == category)
                {
                    _categories[index] = "";
                }
            }
        }

        public void ClearFilters()
        {
            for (int index = 0; index < _categories.Length; index++)
            {
                _categories[index] = "";
            }
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> Predicates = new List<Predicate<Product>>();

            foreach (var category in _categories)
            {
                if (category != "")
                {
                    Predicates.Add(Product => Product.Category == category);
                }
            }

            return Predicates;
        }

        public string[] GetCategories()
        {
            return _categories;
        }
    }
}
