using System.Diagnostics;
using System.Xml.Serialization;

namespace A2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //salary calculation system
            float salary;
            Console.WriteLine("Enter the salary");
            salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"tax deduction 10% is: {salary * 0.10}");

            int rating;
            Console.WriteLine("Enter rating out of 10: ");
            rating = Convert.ToInt32(Console.ReadLine());
            if (rating <= 10 && rating>0)
            {
                if (rating < 5)
                {
                    Console.WriteLine("No bonus applied");
                }

                else if (rating >= 8)
                {
                    Console.WriteLine($"congratulations, You got bonus of 20%: {salary * 0.20} and final amount is {salary + (salary * 0.10)}");
                }
                else if (rating >= 5 && rating < 8)
                {
                    Console.WriteLine($"congratulations, You got bonus of 10%: {salary * 0.10} and final amount is {salary}");

                }
            }
            else
            {
                Console.WriteLine("Invalid rating");
            }


            //online train ticket booking
            int userinput;
            Console.WriteLine("ticket types and costs- 1.general-200 2.sleeper-500 3.ac-1000 4.press4 to exit ");
            Console.WriteLine("enter your choice of ticket");
            int general = 200;
            int sleeper = 500;
            int ac = 1000;
            int genticketno=0;
            int sleeperticketno=0;
            int acticketno=0;
            userinput = Convert.ToInt32(Console.ReadLine());
            


            while (userinput != 4)

            {

                switch (userinput)
                {
                    case 1:

                        Console.WriteLine("enter general ticket no");
                        genticketno += Convert.ToInt32(Console.ReadLine());
                        
                        break;

                    case 2:

                        Console.WriteLine("enter sleeper ticket no");
                        sleeperticketno += Convert.ToInt32(Console.ReadLine());

                        break;

                    case 3:

                        Console.WriteLine("enter ac ticket no");
                        acticketno += Convert.ToInt32(Console.ReadLine());

                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.WriteLine("enter your choice of ticket");

                userinput = Convert.ToInt32(Console.ReadLine());



            }

            Console.WriteLine($"total amount is {(genticketno * 200) + (sleeperticketno * 500) + (acticketno * 1000)}");


            //online shopping platform

            double[,] userData =
            {
                { 101, 500.75 },
                { 102, 1200.50 },
                { 103, 300.00 },
                { 104, 750.25 },
                { 105, 950.00 }
            };

            bool validUser = true;
            int userId;

            Console.WriteLine("Welcome to the Online Shopping Wallet System!");
            while (validUser)
            {
                Console.WriteLine("Enter User Id::");
                userId = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < userData.GetLength(0); i++)
                {
                    if (userData[i, 0] == userId)
                    {
                        validUser = true;
                        Console.WriteLine($"Wallet Balance:{userData[i, 1]}");
                        break;
                    }
                }
                if (validUser)
                {
                    Console.WriteLine("Invalid User ID");
                }

            }


        }
    }
}
