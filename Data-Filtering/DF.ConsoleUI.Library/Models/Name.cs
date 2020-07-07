using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class Name
    {
        [Required(ErrorMessage = "Name filter can't be empty.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name filter must have between 3-20 letters.")]
        private string NameFilter { get; set; }

        public Name(string name)
        {
            NameFilter = name;
        }
    }
}
