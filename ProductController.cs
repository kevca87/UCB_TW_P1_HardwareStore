using HardwareStore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    public class ProductController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> GetProducts()
        {
            var products = _productService.GetProducts();
            return products;
        }
        public Product GetProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            return product;
        }
        public IEnumerable<Product> GetProductsOrderByName()
        {
            var products = _productService.GetProducts(p => p.Name);
            return products;
        }
        public IEnumerable<Product> GetProductsOrderById()
        {
            var products = _productService.GetProducts(p => p.Id);
            return products;
        }
        public IEnumerable<Product> GetProductsOrderByPrice()
        {
            var products = _productService.GetProducts(p => p.Price);
            return products;
        }
    }
}
