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
        private string[] Categories { get; set; } = new string[3] { "", "", "" };

        public List<ValidationResult> TryAddNewCategory(string category)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (CanAddNewCategory())
            {
                Category CategoryModel = MakeCategoryModel(category);
                ValidationContext validationContext = new ValidationContext(CategoryModel);

                if (Validator.TryValidateObject(CategoryModel, validationContext, result, true))
                { 
                    AddNewCategory(CategoryModel);
                    result.Add(new ValidationResult("Successfully added new filter for category."));
                }
            }
            else
            {
                result.Add(new ValidationResult("Can't add new filter for category.\nYou have reached maximum filters for categories."));
            }

            return result;
        }

        private bool CanAddNewCategory()
        {
            int count = 0;

            foreach(var category in Categories)
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

        private void AddNewCategory(Category Category)
        {
            for(int index = 0; index < Categories.Length; index++)
            {
                if(Categories[index] == "")
                {
                    Categories[index] = Category.CategoryName;
                    break;
                }
            }
        }

        public void RemoveFilter(string category)
        {
            for(int index = 0; index < Categories.Length; index++)
            {
                if(Categories[index] == category)
                {
                    Categories[index] = "";
                }
            }
        }

        public void ClearFilters()
        {
            for (int index = 0; index < Categories.Length; index++)
            {
                Categories[index] = "";
            }
        }

        public List<Predicate<Product>> MakePredicates()
        {
            List<Predicate<Product>> predicates = new List<Predicate<Product>>();

            foreach (var category in Categories)
            {
                if (category != "")
                {
                    predicates.Add(product => product.Category == category);
                }
            }

            return predicates;
        }

        public string[] GetCategories()
        {
            return Categories;
        }
    }
}
