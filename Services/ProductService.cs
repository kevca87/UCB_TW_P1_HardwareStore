using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardwareStore.Services
{
    public class ProductService : IProductService
    {
        private IList<Product> _products;
        public ProductService()
        {
            _products = new List<Product>();
            _products.Add(new Tool() { Name = "Martillo", Id = 1, Price = 50, InventoryQuantity = 100 });
            _products.Add(new Tool() { Name = "Destornillador estrella", Id = 2, Price = 30, InventoryQuantity = 100 });
            _products.Add(new Tool() { Name = "Destornillador plano", Id = 3, Price = 30, InventoryQuantity = 100 });
            _products.Add(new ElectricTool() { Name = "Taladro", Id = 4, Price = 300, InventoryQuantity = 20 });
            _products.Add(new ElectricTool() { Name = "Amoladora", Id = 5, Price = 300, InventoryQuantity = 20 });
        }
        public Product GetProduct(int productId)
        {
            return _products.FirstOrDefault(p => productId == p.Id);
        }
        public IList<Product> GetProducts()
        {
            return _products;
        }
        
        public IEnumerable<Product> GetProducts(Func<Product, string> orderFunc)
        {
            return _products.OrderBy(orderFunc);
        }
        public IEnumerable<Product> GetProducts(Func<Product, int> orderFunc)
        {
            return _products.OrderBy(orderFunc);
        }
        public IEnumerable<Product> GetProducts(Func<Product, decimal> orderFunc)
        {
            return _products.OrderBy(orderFunc);
        }
    }
}
