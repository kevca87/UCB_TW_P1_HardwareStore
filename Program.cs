using HardwareStore.Services;
using System;

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
                Founds = 500
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
        static void Main(string[] args)
        {
            Cart<IProduct> myCart = new Cart<IProduct>();
            myCart.AddProduct(new Tool() { Name = "Hammer", Id = 1, Price = 500 },1);
            myCart.AddProduct(new Tool() { Name = "Screwdriver", Id = 2, Price = 100 },6);
            Console.WriteLine(myCart.ToString());
            ICreditCard myCreditCard = CreditCardForm();
            //myCreditCard.AddFounds()
            Console.WriteLine(myCart.CheckOut(myCreditCard.OwnerName,myCreditCard.CardNumber,myCreditCard.CVC,myCreditCard));
            while (true)
            {
                Console.WriteLine("Choose an option");
                int option = Int32.Parse(Console.ReadLine());
                CreditCardMenuFun creditCardFun = CreditCardMenu(option, myCart);
                creditCardFun(myCreditCard);
            }
        }
    }
}
