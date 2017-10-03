using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
    }
}