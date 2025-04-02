using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LibraryManagement.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active";

        // One-to-One Relationship with Member
        public Member? Member { get; set; }

        // One-to-Many Relationship: A User can have multiple Loans
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
