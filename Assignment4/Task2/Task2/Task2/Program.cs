namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee e1 = new Employee();

            Manager m2 = new Manager { Name = "adesh", Bonus = 3000, Salary = 50000 };
            m2.Displaydetails();
        }
    }
}
