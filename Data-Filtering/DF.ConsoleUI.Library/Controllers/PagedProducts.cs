using DF.ConsoleUI.Library.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace DF.ConsoleUI.Library.Controllers
{
    public class PagedProducts
    {
        const int _productsPerPage = 8;
        int _page = 1;

        List<Product> _products = new List<Product>();

        public void SetListOfProducts(List<Product> products)
        {
            _products = products;
        }

        public void NextPage()
        {
            if (_products.Count > (_page * _productsPerPage))
            {
                _page++;
            }
        }

        public void PreviousPage()
        {
            if (_page > 1)
            {
                _page--;
            }
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetPage()
        {
            List<Product> PageOfProducts;

            if (NextPageIsLastPage())
                PageOfProducts = GetNextPage();
            else
                PageOfProducts = GetLastPage();

            return PageOfProducts;
        }

        private bool NextPageIsLastPage()
        {
            return _products.Count > ((_page - 1) * _productsPerPage + _productsPerPage);
        }

        private List<Product> GetNextPage()
        {
            return _products.GetRange((_page - 1) * _productsPerPage, _productsPerPage);
        }

        private List<Product> GetLastPage()
        {
            return _products.GetRange((_page - 1) * _productsPerPage, (_products.Count - ((_page - 1) * _productsPerPage)));
        }
    }
}