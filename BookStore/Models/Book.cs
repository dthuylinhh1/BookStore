using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("book")]
    public partial class Book
    {
        [Column("bookId")]
        public int BookId { get; set; }
        [Required]
        [Column("title")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column("publishedYear", TypeName = "date")]
        public DateTime PublishedYear { get; set; }
        [Column("authorId")]
        public int AuthorId { get; set; }
        [Column("genreId")]
        public int GenreId { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty("Book")]
        public Author Author { get; set; }
        [ForeignKey("GenreId")]
        [InverseProperty("Book")]
        public Genre Genre { get; set; }
    }
}
