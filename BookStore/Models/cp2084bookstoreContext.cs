using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStore.Models
{
    //modify the dbcontext definition to also handle user identities and roles 
    //the last parameter indicates userid pk values are strings 
    public partial class cp2084bookstoreContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public cp2084bookstoreContext()
        {
        }

        public cp2084bookstoreContext(DbContextOptions<cp2084bookstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=den1.mssql7.gear.host;Initial Catalog=cp2084bookstore;Persist Security Info=True;User ID=cp2084bookstore;Password=Be5OC~-ezCKi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add to get Identity to work so we don't get primary key errors. Bug fix for the Identity library. 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_author_fk");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("item_genre_fk");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Genre1).IsUnicode(false);
            });
        }
    }
}
