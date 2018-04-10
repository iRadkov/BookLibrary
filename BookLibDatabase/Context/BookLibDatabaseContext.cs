using BookLibDatabase.Entities;
using System.Data.Entity;

namespace BookLibDatabase.Context
   
{
   public class BookLibDatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
