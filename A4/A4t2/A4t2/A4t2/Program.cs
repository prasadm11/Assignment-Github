namespace A4t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee e1 = new Employee();
            e1.name = "prasad";
            e1.salary = 10000;
            e1.displaydetails();

            Manager m1 = new Manager();
            m1.name = "rutvik";
            m1.salary = 80000;
            m1.Bonus = 5000;
            m1.displaydetails();



            Manager m2 = new Manager { name = "adesh", Bonus = 3000, salary = 50000 };
            m2.displaydetails();
        }
    }
}
