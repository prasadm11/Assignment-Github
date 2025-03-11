using System;

namespace InsurancePolicyManagementApp.Exceptions
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException(string message) : base(message) { }
    }
}