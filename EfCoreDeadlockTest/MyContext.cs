using Microsoft.EntityFrameworkCore;

namespace EfCoreDeadlockTest
{
    public class MyContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=.;Database=ReproDeadlock;Trusted_Connection=True;MultipleActiveResultSets=True");
    }
}
