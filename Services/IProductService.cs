using HardwareStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Services
{
    public interface IProductService
    {
        public Product GetProduct(int productId);
        public IList<Product> GetProducts();
        public IEnumerable<Product> GetProducts(Func<Product, int> orderFunc);
        public IEnumerable<Product> GetProducts(Func<Product, decimal> orderFunc);
        public IEnumerable<Product> GetProducts(Func<Product, string> orderFunc);
    }
}
