using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagement.Domain
{
    public class Member
    {
        [Key, ForeignKey("ApplicationUser")] // Use ApplicationUser.Id as Primary Key
        public string UserId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active";

        // One-to-One Relationship
        public ApplicationUser ApplicationUser { get; set; } = null!;

        // One-to-Many Relationship: A Member can have multiple Loans
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
