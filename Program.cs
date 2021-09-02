using HardwareStore.Services;
using System;
using System.Collections.Generic;

namespace HardwareStore
{
    class Program
    {
        static public ICreditCard CreditCardForm()
        {
            Console.Write("NOMBRE EN LA TARJETA: ");
            string myName = Console.ReadLine();
            Console.Write("NUMERO EN LA TARJETA: ");
            int myCardNumber = Int32.Parse(Console.ReadLine());
            Console.Write("CVC: ");
            int myCVC = Int32.Parse(Console.ReadLine());
            VisaCreditCard myCreditCard = new VisaCreditCard()
            {
                OwnerName = myName,
                CardNumber = myCardNumber,
                CVC = myCVC,
                Founds = 10000
            };
            return myCreditCard;
        }
        public delegate void CreditCardMenuFun(ICreditCard obj);
        public delegate void CreditCardMenuFunParam(ICreditCard obj, int param);
        
        static public CreditCardMenuFun CreditCardMenu(int option,Cart<IProduct> myCart)
        {
            CreditCardMenuFun fun;
            if (option == 1)
            {
                int foundsToAdd = Console.Read();
                fun = (cCard) => cCard.AddFounds(foundsToAdd);
            }
            else
            {
                Console.Write("NOMBRE EN LA TARJETA: ");
                string myName = Console.ReadLine();
                Console.Write("NUMERO EN LA TARJETA: ");
                int myCardNumber = Int32.Parse(Console.ReadLine());
                Console.Write("CVC: ");
                int myCVC = Int32.Parse(Console.ReadLine());
                decimal toPay = myCart.GetTotalPrice();
                fun = (cCard) => cCard.ProccessPayment(myName, myCardNumber, myCVC, toPay);
            }
            return fun;
        }

        static public void AddProductToCart(Cart<IProduct> myCart)
        {
            IProductService productService = new ProductService();
            ProductController pC = new ProductController(productService);
            Console.Write("Id of the product that you want to add to your cart: ");
            int idProd = Int32.Parse(Console.ReadLine());
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

        static public void ShowMyCart(Cart<IProduct> cart)
        {
            Console.WriteLine(cart.ToString());
        }

        static public void SelectProduct(Cart<IProduct> cart)
        {
            IProductService productService = new ProductService();
            ProductController pC = new ProductController(productService);
            Console.Write("\nId del producto que quiera ver: ");
            int idProd = Int32.Parse(Console.ReadLine());
            Product product = pC.GetProduct(idProd);
            Console.WriteLine(product.ShowDetail());
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
            menuProducts.AddOption(1,SelectProduct);
            menuProducts.AddOption(2,AddProductToCart);
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
            menu.AddOption("1", ShowProducts);
            menu.AddOption("2", ShowMyCart);
            menu.AddOption("exit", (cart) => { Console.WriteLine("See you later : )"); });
            string option = "0";
            while (option != "exit")
            {
                menu.ShowMenu();
                Console.Write("Choose an option: ");
                option = Console.ReadLine();
                Console.WriteLine("-------------------------------------------");
                try
                {
                    var fun = menu.ChooseOption(option);
                    fun(cart);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
