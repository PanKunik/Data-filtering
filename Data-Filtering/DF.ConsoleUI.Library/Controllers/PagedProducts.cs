using DF.ConsoleUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;

namespace DF.ConsoleUI.Library.Controllers
{
    public class PagedProducts
    {
        const int _productsPerPage = 8;
        int _page = 1;
        int _numberOfPages = 1;

        List<Product> _products = new List<Product>();

        public void SetListOfProducts(List<Product> products)
        {
            _products = products;
            _numberOfPages = (int)Math.Ceiling(_products.Count / (decimal)_productsPerPage);
        }

        public int GetCurrentPage()
        {
            return _page;
        }

        public int GetNumberOfPages()
        {
            return _numberOfPages;
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

        public ProductsPage GetAll()
        {
            return new ProductsPage()
            {
                CurrentPage = _page,
                NumberOfPages = _numberOfPages,
                Products = _products
            };
        }

        public ProductsPage GetPage()
        {
            ProductsPage PageOfProducts;

            if (NextPageIsLastPage())
            {
                PageOfProducts = new ProductsPage()
                {
                    CurrentPage = _page,
                    NumberOfPages = _numberOfPages,
                    Products = GetNextPage()
                };
            }
            else
            {
                PageOfProducts = new ProductsPage()
                {
                    CurrentPage = _page,
                    NumberOfPages = _numberOfPages,
                    Products = GetLastPage()
                };
            }

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