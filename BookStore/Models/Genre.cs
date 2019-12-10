using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    [Table("genre")]
    public partial class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        [Column("genreId")]
        public int GenreId { get; set; }
        [Required]
        [Column("genre")]
        [StringLength(30)]
        public string Genre1 { get; set; }

        [InverseProperty("Genre")]
        public ICollection<Book> Book { get; set; }
    }
}
