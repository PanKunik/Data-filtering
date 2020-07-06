using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class InStock
    {
        [Required(ErrorMessage = "In stock number can't be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "In stock number must be integer number greater than 0.")]
        public int? InStockAmount { get; set; } = null;

        public InStock()
        {

        }

        public InStock(int inStock)
        {
            InStockAmount = inStock;
        }
    }
}
