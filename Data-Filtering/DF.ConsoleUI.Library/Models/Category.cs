using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Category can't be empty.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Category must have between 3-20 letters.")]
        public string CategoryName { get; set; }

        public Category(string category)
        {
            CategoryName = category;
        }
    }
}
