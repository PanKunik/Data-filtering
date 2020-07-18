using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Library.Models
{
    public class ProductsPage
    {
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public List<Product> Products { get; set; }
    }
}
