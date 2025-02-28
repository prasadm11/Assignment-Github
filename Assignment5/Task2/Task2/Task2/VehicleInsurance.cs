using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public abstract class VehicleInsurance
    {
        public string VehicleType { get; set; }

        public abstract double CalculatePremium();

        public void DisplayPremium()
        {
            Console.WriteLine($"{VehicleType} Insurance Premium: ${CalculatePremium():0.00}");
        }
    }

}
