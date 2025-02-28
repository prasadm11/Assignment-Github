using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class TwoWheelerInsurance : VehicleInsurance
    {
        public TwoWheelerInsurance() { VehicleType = "Two-Wheeler"; }

        public override double CalculatePremium()
        {
            return 5000 * 0.02;
        }
    }

}
