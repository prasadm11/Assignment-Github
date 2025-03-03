using Task1.Model;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Customer customer1 = new Customer(1, "Prasad");
            customer1.GetTokenNumber(bank);
            Customer customer2 = new Customer(2, "Navin");
            customer2.GetTokenNumber(bank);
            Customer customer3 = new Customer(3, "Surya");
            customer3.GetTokenNumber(bank);

            bank.NextInQueue();
            bank.OutFromQueue();
            bank.NextInQueue();
        }
    }
}
