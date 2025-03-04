using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Models
{
    public static class EmployeeExtensions
    {
        public static int Getexperience(this Employee emp)
        {
            int experience = DateTime.Now.Year - emp.Joiningdate.Year;

            if (emp.Joiningdate.Date > DateTime.Now.Date.AddYears(-experience))
            {
                experience--;
            }
            return experience;
        }
    }
}
