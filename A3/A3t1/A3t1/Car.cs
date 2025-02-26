using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3t1
{
    class Car
    {
        public int carID;
        public string brand;
        public string model;
        public int year;
        public decimal price;



        public void AcceptCarDetails(int carid, string brandName, string modelName, int carYear, decimal carPrice)
        {
            Console.WriteLine("car information:");

            carID = carid;
            brand = brandName;
            model = modelName;
            year = carYear;
            price = carPrice;
        }
         
        public void printcardetails()
        {
            Console.WriteLine($"Car id is: {carID}");

            Console.WriteLine($"Brand name is: {brand}");

            Console.WriteLine($"Model  is: {model}");

            Console.WriteLine($"Manufacturing year is: {year}");

            Console.WriteLine($"Price  is: {price}");
        }
    }
}
