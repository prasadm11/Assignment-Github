using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4t2
{
    class Manager : Employee
    {
        public int Bonus { get; set; }


        public override void displaydetails()
        {
            Console.WriteLine($"Name : {name}  salary : {salary}  bonus : {Bonus}");
        }


    }
}
