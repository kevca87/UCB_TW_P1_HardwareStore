using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    class Toilet : IProduct
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
    }
}
