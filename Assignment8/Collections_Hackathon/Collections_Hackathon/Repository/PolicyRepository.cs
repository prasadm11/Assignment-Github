using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections_Hackathon.Exceptions;
using Collections_Hackathon.Interfaces;
using Collections_Hackathon.Models;

namespace Collections_Hackathon.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly List<Policy> policies = new List<Policy>();

        public void AddPolicy(Policy policy)
        {
            if (policies.Any(p => p.PolicyID == policy.PolicyID))
                throw new DuplicatePolicyException(policy.PolicyID);

            if (policy.EndDate <= policy.StartDate)
                throw new InvalidPolicyDateException();

            policies.Add(policy);
            Console.WriteLine("Policy added successfully!");
        }

        public List<Policy> GetAllPolicies() => policies;

        public Policy GetPolicyById(int policyID) =>
            policies.FirstOrDefault(p => p.PolicyID == policyID) ?? throw new PolicyNotFoundException(policyID);

        public void UpdatePolicy(int policyID, string policyHolderName, PolicyType type, DateTime startDate, DateTime endDate)
        {
            var policy = GetPolicyById(policyID);
            policy.PolicyHolderName = policyHolderName;
            policy.Type = type;
            policy.StartDate = startDate;
            policy.EndDate = endDate;

            Console.WriteLine("Policy updated successfully!");
        }

        public void DeletePolicy(int policyID)
        {
            var policy = GetPolicyById(policyID);
            policies.Remove(policy);
            Console.WriteLine("Policy deleted successfully!");
        }

        public List<Policy> GetActivePolicies() => policies.Where(p => p.IsActive()).ToList();
    }
}
