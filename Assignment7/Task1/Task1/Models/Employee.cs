using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime Joiningdate { get; set; }

        public Employee(string name, DateTime joiningdate)
        {
            Name = name;
            Joiningdate = joiningdate;
        }
    }
}
