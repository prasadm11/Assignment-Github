using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4t2
{
    class Employee
    {
        public string name { get; set; }
        public int salary { get; set; }

        public virtual void displaydetails()
        {
            Console.WriteLine($"Name is {name} and salary is {salary} ");
        }
    }
}
