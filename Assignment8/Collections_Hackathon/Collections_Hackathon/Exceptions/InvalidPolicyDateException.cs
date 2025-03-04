using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Hackathon.Exceptions
{
    public class InvalidPolicyDateException : Exception
    {
        public InvalidPolicyDateException()
            : base("End Date must be after the Start Date.") { }
    }
}
