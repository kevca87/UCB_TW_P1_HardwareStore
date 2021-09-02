using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Models
{
    public class Product : IProduct
    {
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public decimal InventoryQuantity { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public override string ToString()
        {
            return Name;
        }
        public virtual string Show()
        {
            string ans;
            ans = $"{Name}\n"+
                $"Id: {Id}\n" +
                $"Brand: {Brand}\n"+
                $"Price: {Price}\n";
            return ans;
        }

        public virtual string ShowDetail()
        {
            string ans=$"----------------------------------\n";
            ans = $"{ans}{Name}\n" +
                $"Id: {Id}\n" +
                $"Brand: {Brand}\n" +
                $"Price: {Price}\n"+
                $"----------------------------------\n";
            return ans;
        }
    }
}
