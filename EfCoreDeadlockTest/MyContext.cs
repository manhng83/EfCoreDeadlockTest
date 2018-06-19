using Microsoft.EntityFrameworkCore;

namespace EfCoreDeadlockTest
{
    public class MyContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
