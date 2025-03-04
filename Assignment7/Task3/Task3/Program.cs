using Task3.Models;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<Product> products = new List<Product>
            {
                new Product{Name="chemical", Price=1200 },
                new Product{Name="washing machine", Price=10200 },
                new Product{Name="AC", Price=20000 }
            };

            var expensiveproduct = products.MaxBy(p => p.Price);
            Console.WriteLine(expensiveproduct.Name);
        }
    }
}
