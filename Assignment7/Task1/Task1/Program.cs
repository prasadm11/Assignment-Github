using Task1.Models;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Employee> employees = new List<Employee>
            {
                new Employee("Prasd", new DateTime(2020,6,15)),
                new Employee("om", new DateTime(2020,7,25)),
                new Employee("vikas", new DateTime(2020,8,10)),

            };

            Console.WriteLine("Employee details:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.Name} has {emp.Getexperience()} years of experience.");
            }

            
            var experiencedEmployees = employees.Where(e => e.Getexperience() > 5);

            Console.WriteLine("\nEmployees with more than 5 years of experience:");
            foreach (var emp in experiencedEmployees)
            {
                Console.WriteLine(emp.Name);
            }
        }
    }
}
