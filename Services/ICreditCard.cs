using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Services
{
    public interface ICreditCard
    {
        public string OwnerName { get; set; }
        public long CardNumber { get; set; }
        public int CVC { get; set; }
        public decimal Founds { get; set; }
        public bool ProccessPayment(string ownerName, long cardNumber, int cvc, decimal totalToPay);
        public void AddFounds(decimal foundsToAdd);
    }
}
