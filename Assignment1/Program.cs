namespace A1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studName;
            int age;
            float percentage;
            bool res;

            Console.Write("Enter the Name of Student: ");
            studName = Console.ReadLine();

            Console.Write("Enter the Age of Student: ");
            age = Convert.ToInt32(Console.ReadLine());


            Console.Write("Enter the Percentage of Student: ");
            percentage = float.Parse(Console.ReadLine());

            Console.WriteLine("\nStudent Information:");
            Console.WriteLine($"Name: {studName}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Percentage: {percentage}%");

            //check valid age
            res = int.TryParse(Console.ReadLine(), out age);
            if (!res)
            {
                Console.WriteLine("valid Age");
            }
            else
            {
                Console.WriteLine("age is not valid");
            }


            //Email
            string email;
            Console.WriteLine("Enter email of student:");
            email = Console.ReadLine();
            if (email == string.Empty)
            {
                Console.Write("EMail is Empty");
            }
            else
            {
                Console.WriteLine("Email is not empty");
            }

            //patient discharge date
            Console.WriteLine("Enter the discharge date of Patient");
            string dischargedate;
            dischargedate = Console.ReadLine();
            if (dischargedate == null)
            {
                Console.WriteLine("patient not dicaharged");

            }
            else
            {
                Console.WriteLine("patient discharged");
            }
        }
    }
}
