/*using HardwareStore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    public delegate void CreditCardMenuFun(ICreditCard obj);
    public delegate void CreditCardMenuFunParam(ICreditCard obj, int param);
    class Menu<T> where T: CreditCardMenuFun
    {
        //TODO MENU WITH FUNCTION

        public T CreditCardMenu(int option)
        {
            CreditCardMenuFun fun;
            if (option == 1)
            {
                int foundsToAdd = Console.Read();
                fun = (cCard) => cCard.AddFounds(foundsToAdd);
            }
            else if(option ==2)
            {
                Console.Write("NOMBRE EN LA TARJETA: ");
                string myName = Console.ReadLine();
                Console.Write("NUMERO EN LA TARJETA: ");
                int myCardNumber = Int32.Parse(Console.ReadLine());
                Console.Write("CVC: ");
                int myCVC = Int32.Parse(Console.ReadLine());
                fun = (cCard, toPay) => cCard.ProccessPayment(myName, myCardNumber, myCVC, toPay);
            }
            return fun;
        }
    }
}*/
