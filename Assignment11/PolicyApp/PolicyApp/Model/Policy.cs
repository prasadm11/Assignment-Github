using System;

namespace InsurancePolicyManagementApp.Model
{
    public enum PolicyType
    {
        Life,
        Health,
        Vehicle,
        Property
    }

    public class Policy
    {
        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy(int id, string name, PolicyType type, DateTime start, DateTime end)
        {
            PolicyID = id;
            PolicyHolderName = name;
            Type = type;
            StartDate = start;
            EndDate = end;
        }

        public override string ToString()
        {
            return $"Policy ID: {PolicyID}\nHolder: {PolicyHolderName}\nType: {Type}\n" +
                   $"Start: {StartDate:yyyy-MM-dd}\nEnd: {EndDate:yyyy-MM-dd}\n";
        }
    }
}