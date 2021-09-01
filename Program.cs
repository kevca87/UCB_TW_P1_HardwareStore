using System;

namespace HardwareStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Cart<Tool> myCart = new Cart<Tool>();
            Tool hammer = new Tool() { Name = "Hammer", Id = 1, Price = 500 };
            myCart.AddProduct(hammer,1);
            myCart.AddProduct(new Tool() { Name = "Screwdriver", Id = 2, Price = 100 },6);
            Console.WriteLine(myCart.ToString());
        }
    }
}
