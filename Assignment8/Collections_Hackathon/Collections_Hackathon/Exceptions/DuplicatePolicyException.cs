using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Hackathon.Exceptions
{
    public class DuplicatePolicyException : Exception
    {
        public DuplicatePolicyException(int policyID)
            : base($"Policy with ID {policyID} already exists. Please enter a unique ID.") { }
    }

}
