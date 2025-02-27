namespace A3t1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Car hyundai = new Car();
            hyundai.AcceptCarDetails(1,"hyundai","x200",2010,130000);
            hyundai.Printcardetails();
        }
    }
}
