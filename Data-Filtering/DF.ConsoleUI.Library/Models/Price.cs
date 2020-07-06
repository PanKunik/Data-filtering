using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class Price
    {
        [Required(ErrorMessage = "Price can't be empty.")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "Price must be positive number.")]
        public decimal? Amount { get; set; } = null;

        public Price()
        {

        }

        public Price(decimal price)
        {
            Amount = price;
        }
    }
}
