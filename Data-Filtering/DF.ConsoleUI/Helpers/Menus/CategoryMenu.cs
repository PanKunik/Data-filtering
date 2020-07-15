using DF.ConsoleUI.Helpers.Input;
using DF.ConsoleUI.Library.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Helpers.Menus
{
    public class CategoryMenu
    {
        Filtering _filteringInstance;
        public CategoryMenu(Filtering FilteringInstance)
        {
            _filteringInstance = FilteringInstance;
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Category Menu");
            Console.WriteLine("1. Add new category (max. 3)");
            Console.WriteLine("2. Remove category");
            Console.WriteLine("3. Clear all categories");
        }

        public void InvokeAction(int optionNumber)
        {
            switch (optionNumber)
            {
                case -1:
                    Message.WrongOption();
                    break;
                case 1:
                    AddNewCategory();
                    break;
                case 2:
                    RemoveCategory();
                    break;
                case 3:
                    ClearAllCategories();
                    break;
                default:
                    Message.NoOptionFound();
                    break;
            }
        }

        private void AddNewCategory()
        {
            Message.PrintValidationSummary(_filteringInstance.AddCategoryFilter(UserInput.CatchString("Type category name: ")));
        }

        private void RemoveCategory()
        {
            _filteringInstance.RemoveCategoryFilter(UserInput.CatchString("Type category name: "));
        }

        private void ClearAllCategories()
        {
            _filteringInstance.RemoveAllCategories();
        }
    }
}