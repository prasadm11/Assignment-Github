using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    internal class Bank
    {
        Queue<Customer> customerList;
        public Bank()
        {
            customerList = new Queue<Customer>();
        }

        public int GetInQueue(Customer customer)
        {
            customerList.Enqueue(customer);
            Console.WriteLine($"new Customer Join Queue");
            return customerList.Count;
        }

        public void NextInQueue()
        {
            Customer customer = customerList.Peek();
            Console.WriteLine($"Customer next in queue : Id : {customer.CustomerID} \t Name : {customer.CustomerName} \t Token no. : {customer.TokenNumber}");
        }
        public void OutFromQueue()
        {
            Customer customer = customerList.Dequeue();
            Console.WriteLine($"Removed Customer : Id :{customer.CustomerID} \t Name : {customer.CustomerName} \t Token no. : {customer.TokenNumber}");
        }

    }
}