using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections_Hackathon.Models;

namespace Collections_Hackathon.Interfaces
{
    public interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy GetPolicyById(int policyID);
        void UpdatePolicy(int policyID, string policyHolderName, PolicyType type, DateTime startDate, DateTime endDate);
        void DeletePolicy(int policyID);
        List<Policy> GetActivePolicies();
    }
}
