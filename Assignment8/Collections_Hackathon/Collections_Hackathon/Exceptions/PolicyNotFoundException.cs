using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Hackathon.Exceptions
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException(int policyID) 
            : base($"Policy with ID {policyID} not found.") { }
    }
}
