using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("author")]
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        [Column("authorId")]
        public int AuthorId { get; set; }
        [Required]
        [Column("firstName")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [Column("lastName")]
        [StringLength(20)]
        public string LastName { get; set; }
        [Column("dateOfBirth", TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [InverseProperty("Author")]
        public ICollection<Book> Book { get; set; }
    }
}
