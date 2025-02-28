using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class FourWheelerInsurance : VehicleInsurance
    {
        public FourWheelerInsurance() { VehicleType = "Four-Wheeler"; }

        public override double CalculatePremium()
        {
            return 10000 * 0.03;
        }
    }

}
