using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DF.ConsoleUI.Library.Controllers
{
    public class ProductController
    {
        private List<Product> _products;

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public ProductController()
        {
            if(_products == null)
            {
                _products = new List<Product>();

                _products.Add(new Product() 
                {
                    Id = 1,
                    Name = "Rower trekingowy",
                    Description = "Rower trekingowy firmy KROSS, model Earth 1.0",
                    Price = 2899M,
                    Category = "Rowery",
                    InStock = 2
                });

                _products.Add(new Product()
                {
                    Id = 2,
                    Name = "Rower miejski",
                    Description = "Rower miejski firmy MERIDA, model APK A3",
                    Price = 1899M,
                    Category = "Rowery",
                    InStock = 1
                });

                _products.Add(new Product()
                {
                    Id = 3,
                    Name = "Piłka football",
                    Description = "Replika piłki do footballu firmy ADIDAS. Wystąpiła na mundialu w roku 2010.",
                    Price = 139.99M,
                    Category = "Football",
                    InStock = 12
                });

                _products.Add(new Product()
                {
                    Id = 4,
                    Name = "Mleko UHT 3,2%",
                    Description = "Mmmm... Dobre mleko!",
                    Price = 3.99M,
                    Category = "Nabiał",
                    InStock = 1220
                });

                _products.Add(new Product()
                {
                    Id = 5,
                    Name = "Chleb pszenno-żytni",
                    Description = "Mniam",
                    Price = 4.99M,
                    Category = "Pieczywo",
                    InStock = 3541
                });

                _products.Add(new Product()
                {
                    Id = 6,
                    Name = "Ser żółty gouda",
                    Description = "Mlekpolik",
                    Price = 3.69M,
                    Category = "Nabiał",
                    InStock = 1258
                });

                _products.Add(new Product()
                {
                    Id = 7,
                    Name = "Wędlina Polska",
                    Description = "PolMies",
                    Price = 7.29M,
                    Category = "Wędliny",
                    InStock = 584
                });

                _products.Add(new Product()
                {
                    Id = 8,
                    Name = "Wędka dla kota",
                    Description = "Tripix",
                    Price = 3.29M,
                    Category = "Akcesoria zwierzęce",
                    InStock = 3256
                });

                _products.Add(new Product()
                {
                    Id = 9,
                    Name = "Smycz dla psa",
                    Description = "Melaos",
                    Price = 18.99M,
                    Category = "Akcesoria zwierzęce",
                    InStock = 951
                });
            }
        }
    }
}
