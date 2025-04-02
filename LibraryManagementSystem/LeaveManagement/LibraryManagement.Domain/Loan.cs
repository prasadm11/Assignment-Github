using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagement.Domain
{
    public class Loan
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign key for ApplicationUser
        //[ForeignKey("ApplicationUser")]
        //public string UserId { get; set; } = string.Empty; ==>changed here


        [ForeignKey("Member")]
        public string UserId { get; set; } = string.Empty;

        // Foreign key for Book
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Borrowed";

        // Navigation Properties
        //public ApplicationUser? ApplicationUser { get; set; } // ✅ Add ApplicationUser

        public Member? Member { get; set; }
        public Book? Book { get; set; }
    }
}
