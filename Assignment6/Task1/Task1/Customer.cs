using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    internal class Customer
    {
        public int TokenNumber { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Customer(int customerID, string customerName)
        {
            this.CustomerID = customerID;
            this.CustomerName = customerName;
        }
        public void GetTokenNumber(Bank bank)
        {
            TokenNumber = bank.GetInQueue(this);
            Console.WriteLine($"Customer Id : {CustomerID} \t Customer Name : {CustomerName} \t Token No. : {TokenNumber}");
        }
    }
}