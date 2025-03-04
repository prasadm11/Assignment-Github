using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Hackathon.Models
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
        public int PolicyID { get; }
        public string PolicyHolderName { get; set; }
        public PolicyType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy(int policyID, string policyHolderName, PolicyType type, DateTime startDate, DateTime endDate)
        {
            PolicyID = policyID;
            PolicyHolderName = policyHolderName;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        public bool IsActive() => DateTime.Now >= StartDate && DateTime.Now <= EndDate;

        public override string ToString() =>
            $"Policy ID: {PolicyID}, Holder: {PolicyHolderName}, Type: {Type}, " +
            $"Start: {StartDate:yyyy-MM-dd}, End: {EndDate:yyyy-MM-dd}, Active: {IsActive()}";
    }
}
