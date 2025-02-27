using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task2
{
    class Manager : Employee
    {
        public int Bonus { get; set; }


        public override void Displaydetails()
        {
            Console.WriteLine($"Name  is {Name}  salary is {Salary}  bonus is {Bonus}");
        }


    }
}
