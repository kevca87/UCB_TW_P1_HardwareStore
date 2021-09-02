using HardwareStore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    public class VisaCreditCard : ICreditCard
    {
        public string OwnerName { get; set; }
        public long CardNumber { get; set; }
        public int CVC { get; set; }
        public decimal Founds { get; set; }
        public decimal Limit { get; set; }

        //TODO CHANGE TO VOID AND THROW EXCEPTIONS
        public bool ProccessPayment(string ownerName,long cardNumber, int cvc,decimal totalToPay)
        {
            bool allOk = ownerName == OwnerName && cardNumber == CardNumber && cvc == CVC && EnoughFounds(totalToPay) && LessThanLimit(totalToPay);
            if (allOk)
            {
                Payment(totalToPay);
            }
            return allOk;
        }
        public bool EnoughFounds(decimal totalToPay)
        {
            return totalToPay < Founds;
        }
        public bool LessThanLimit(decimal totalToPay)
        {
            return totalToPay < Limit;
        }
        public void Payment(decimal totalToPay)
        {
            Founds = Founds - totalToPay;
        }
        public void AddFounds(decimal foundsToAdd)
        {
            Founds = Founds + foundsToAdd;
        }
    }
}
