namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, Name = "Laptop", Category = "Electronics", Price = 55000 },
            new Product { ProductID = 2, Name = "Smartphone", Category = "Electronics", Price = 20000 },
            new Product { ProductID = 3, Name = "Headphones", Category = "Electronics", Price = 1500 },
            new Product { ProductID = 4, Name = "Mouse", Category = "Electronics", Price = 800 },
            new Product { ProductID = 5, Name = "Book", Category = "Stationery", Price = 500 }
        };

            var expensiveElectronics = products
            .Where(p => p.Category == "Electronics" && p.Price > 1000)
            .ToList();

            
            Console.WriteLine("Electronics products costing more than Rs.1000:");
            foreach (var product in expensiveElectronics)
            {
                Console.WriteLine($"ID: {product.ProductID}, Name: {product.Name}, Price: Rs.{product.Price}");
            }
        }
    }
}
