using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    class Tool : IProduct
    {
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Model { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public override string ToString()
        {
            return Name;
        }
    }
}
