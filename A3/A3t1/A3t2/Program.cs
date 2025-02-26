namespace A3t2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //parameterized
            Person p1 = new Person(2, "Rahul", "Pune");
            p1.DisplayInfo();

            Console.WriteLine();

            // using default constructor
            Person p2 = new Person();
            p2.DisplayInfo();




        }
    }
}
