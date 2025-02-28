namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] accounts = { "123456", "654321", "789123" };

            try
            {
                Console.Write("Enter beneficiary account Number: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("Account number cannot be empty.");

                bool exists = false;
                foreach (string acc in accounts)
                {
                    if (acc == input)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                    throw new Exception("Account not found.");

                Console.WriteLine("Account verified successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction attempt completed.");
            }
        } 
    }
}
