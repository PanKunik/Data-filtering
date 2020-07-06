using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Library.Controllers
{
    public class ProductController
    {
        public List<Product> Products { get; set; }

        public void PopulateProducts()
        {
            if(Products == null)
            {
                Products = new List<Product>();

                Products.Add(new Product() 
                {
                    Id = 1,
                    Name = "Rower trekingowy",
                    Description = "Rower trekingowy firmy KROSS, model Earth 1.0",
                    Price = 2899M,
                    Category = "Rowery",
                    InStock = 2
                });

                Products.Add(new Product()
                {
                    Id = 2,
                    Name = "Rower miejski",
                    Description = "Rower miejski firmy MERIDA, model APK A3",
                    Price = 1899M,
                    Category = "Rowery",
                    InStock = 1
                });

                Products.Add(new Product()
                {
                    Id = 3,
                    Name = "Piłka football",
                    Description = "Replika piłki do footballu firmy ADIDAS. Wystąpiła na mundialu w roku 2010.",
                    Price = 139.99M,
                    Category = "Football",
                    InStock = 12
                });
            }
        }
    }
}
