using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardwareStore
{
    public interface IProduct
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        
    }
    public class Cart<P> where P: IProduct
    {
        //private IPayment paymentService;
        private List<(P Product, int Quantity)> _items = new List<(P Product, int Quantity)>();

        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
            {
                totalPrice = totalPrice + item.Product.Price * item.Quantity;
            }
            return totalPrice;
        }
        public bool AddProduct(P product,int quantity)
        {
            int previousCount = _items.Count;
            _items.Add((product, quantity));
            return previousCount + 1 == _items.Count;
        }
        public void AddProduct(P product)
        {
            AddProduct(product,1);
        }
        public bool RemoveProduct(int idProduct)
        {
            bool ans = false;
            int qRemovedItems = _items.RemoveAll(item => item.Product.Id == idProduct);
            if (qRemovedItems > 0)
            {
                ans = true;
            }
            return ans;
        }
        public bool RemoveProduct(string productName)
        {
            bool ans = false;
            int qRemovedItems = _items.RemoveAll(item => item.Product.Name == productName);
            if (qRemovedItems > 0)
            {
                ans = true;
            }
            return ans;
        }
        public delegate int IntOperation(int intToSet);
        public void SetProductQuantity(int idProduct, IntOperation SetQuantityFunction)
        {
            var item = _items.FirstOrDefault(item => item.Product.Id == idProduct);
            item.Quantity = SetQuantityFunction(item.Quantity);
        }
        public void SetProductQuantityAdd1(int idProduct)
        {
            SetProductQuantity(idProduct, num => num + 1);
        }
        public void SetProductQuantitySub1(int idProduct)
        {
            SetProductQuantity(idProduct, num => num + 1);
        }
        public void SetProductQuantityDuplicate(int idProduct)
        {
            SetProductQuantity(idProduct, num => num * 2);
        }
        public decimal GetSubTotal(int idProduct)
        {
            var item = _items.FirstOrDefault(item => item.Product.Id == idProduct);
            return item.Quantity * item.Product.Price;
        }
        public List<decimal> GetSubTotals()
        {
            List<decimal> subTotals = new List<decimal>();
            foreach (var item in _items)
            {
                var subTotal = item.Product.Price * item.Quantity;
                subTotals.Add(subTotal);
            }
            return subTotals;
        }
        public string CheckOut()
        {
            return $"Su total a cancelar es { GetTotalPrice() }";
        }

        public override string ToString()
        {
            string ans = String.Format("|{0,-15}|{1,-10}|{2,-10}|{3,-10}|\n", "Name", "Price", "Quantity", "Subtotal");
            ans = ans + "--------------------------------------------------\n";
            foreach (var item in _items)
            {
                ans = ans + String.Format("|{0,-15}|{1,-10}|{2,-10}|{3,-10}|\n", item.Product.Name, item.Product.Price, item.Quantity, GetSubTotal(item.Product.Id));
            }
            ans = ans + "__________________________________________________\n";
            ans = ans + String.Format(" {0,-15} {1,-10} {2,-10} {3,-10}","Total"," "," ",GetTotalPrice());
            return ans;
        }
    }
}
