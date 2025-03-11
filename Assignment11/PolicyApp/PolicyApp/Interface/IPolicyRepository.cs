using InsurancePolicyManagementApp.Model;
using System.Collections.Generic;

namespace InsurancePolicyManagementApp.Interface
{
    public interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy GetPolicyById(int id);
        void UpdatePolicy(Policy policy);
        void DeletePolicy(int id);
    }
}