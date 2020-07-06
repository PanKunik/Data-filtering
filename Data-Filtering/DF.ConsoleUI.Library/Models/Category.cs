using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Category can't be empty.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Category must have between 3-30 letters.")]
        public string CategoryName { get; set; }

        public Category(string category)
        {
            CategoryName = category;
        }
    }
}
