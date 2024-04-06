using Microsoft.EntityFrameworkCore;
using LibApp.Domain.Entities;

namespace LibApp.Infrastructure.Data
{
    public class LibAppDbContext : DbContext
    {
        public LibAppDbContext(DbContextOptions<LibAppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
