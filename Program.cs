using HardwareStore.Controllers;
using HardwareStore.Models;
using HardwareStore.Services;
using System;
using System.Collections.Generic;

namespace HardwareStore
{
    class Program
    {
        //Cart UIFunctions
        static public void CheckOutMyCart(Cart<IProduct> myCart)
        {
            Console.Write("NOMBRE EN LA TARJETA: ");
            string myName = Console.ReadLine();
            Console.Write("NUMERO EN LA TARJETA: ");
            long myCardNumber = Int64.Parse(Console.ReadLine());
            Console.Write("CVC: ");
            int myCVC = Int32.Parse(Console.ReadLine());
            VisaCreditCard myCreditCard = new VisaCreditCard()
            {
                OwnerName = myName,
                CardNumber = myCardNumber,
                CVC = myCVC,
                Founds = 10000,
                Limit = 5000
            };
            Console.WriteLine(myCart.CheckOut(myName,myCardNumber,myCVC,myCreditCard));
        }

        static public void AddProductToCart(Cart<IProduct> myCart)
        {
            IProductService productService = new ProductService();
            ProductController pC = new ProductController(productService);
            Console.Write("Id of the product that you want to add to your cart: ");
            int idProd = Int32.Parse(Console.ReadLine());
            try
            {
                Product product = pC.GetProduct(idProd);
                Console.Write("How many items of this product? : ");
                int q = Int32.Parse(Console.ReadLine());
                bool allOk = myCart.AddProduct(product, q);
                if (allOk)
                {
                    Console.WriteLine("Successful addition");
                }
                else
                {
                    Console.Write("Something fail, dont questions");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
            

        static public void ShowMyCart(Cart<IProduct> cart)
        {
            Console.WriteLine(cart.ToString());
        }

        //Product UIFunctions

        static public void SelectProduct(Cart<IProduct> cart)
        {
            IProductService productService = new ProductService();
            ProductController pC = new ProductController(productService);
            Console.Write("\nId del producto que quiera ver: ");
            int idProd = Int32.Parse(Console.ReadLine());
            try
            {
                Product product = pC.GetProduct(idProd);
                Console.WriteLine(product.ShowDetail());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static public void ShowProducts(Cart<IProduct> cart)
        {
            Console.Clear();
            IProductService productService = new ProductService();
            ProductController pC = new ProductController(productService);
            Menu<int> orderBy = new Menu<int>();
            IEnumerable<Product> products;
            Console.Write("Order products by:\n1) Name\n2) Id\n3) Price: ");
            int optionOrder = Int32.Parse(Console.ReadLine());
            if (optionOrder == 1)
            {
                products = pC.GetProductsOrderByName();
            }
            else if(optionOrder ==2)
            {
                products = pC.GetProductsOrderById();
            }
            else
            {
                products = pC.GetProductsOrderByPrice();
            }
            Console.Clear();
            foreach (Product p in products)
            {
                Console.WriteLine(p.Show());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--------------------------------------");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Menu<int> menuProducts = new Menu<int>(){Name="PRODUCTS MENU" };
            menuProducts.AddOption(1, "Select product", SelectProduct);
            menuProducts.AddOption(2, "Add product to cart",AddProductToCart);
            menuProducts.ShowMenu();
            Console.Write("Choose an option: ");
            int option = Int32.Parse(Console.ReadLine());
            try
            {
                menuProducts.ChooseOption(option)(cart);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        static void Main(string[] args)
        {
            Menu<string> menu = new Menu<string>(){Name="PRINCIPAL MENU"};
            Cart<IProduct> cart = new Cart<IProduct>();
            menu.AddOption("1", "Show products", ShowProducts);
            menu.AddOption("2", "Show my cart", ShowMyCart);
            menu.AddOption("3", "Check out", CheckOutMyCart);
            menu.AddOption("0", "Exit",(cart) => { Console.WriteLine("See you later : )"); });
            string option = "";
            while (option != "0")
            {
                menu.ShowMenu();
                Console.Write("Choose an option: ");
                option = Console.ReadLine();
                Console.WriteLine("-------------------------------------------");
                try
                {
                    var fun = menu.ChooseOption(option);
                    fun(cart);
                    cart = option == "3" ? new Cart<IProduct>():cart;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
