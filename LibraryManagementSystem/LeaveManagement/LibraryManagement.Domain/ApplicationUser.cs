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


        public Member? Member { get; set; }


        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
