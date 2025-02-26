namespace A3t3
{
    internal class Program
    {
        static void Main(string[] args)
        {
        login:
            Console.WriteLine("Enter the password");
            string password = Console.ReadLine();

            int length = password.Length;
            Console.WriteLine(length);

            if(length>5 && password.Any(char.IsUpper) && password.Any(char.IsDigit))
            {
                Console.WriteLine("Valid password");
            }
            else
            {
                Console.WriteLine("Invalid password , Try again");
                goto login;
            }

        }
    }
}
