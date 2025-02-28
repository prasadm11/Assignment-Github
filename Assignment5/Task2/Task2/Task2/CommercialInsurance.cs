using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class CommercialInsurance : VehicleInsurance
    {
        public CommercialInsurance() { VehicleType = "Commercial Vehicle"; }

        public override double CalculatePremium()
        {
            return 20000 * 0.05;
        }
    }

}
