using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagement.Domain
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int PublishedYear { get; set; }
        public int CopiesAvailable { get; set; }

        // Navigation Properties
        
        public Category? Category { get; set; }
        
        public ICollection<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
