using Microsoft.EntityFrameworkCore;
using LibApp.Domain.Entities;
using LibApp.Application.Resources;
using System.Security.Principal;

namespace LibApp.Infrastructure.Data
{
    public class LibAppDbContext : DbContext
    {
        public LibAppDbContext(DbContextOptions<LibAppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var userId = Guid.NewGuid();
            //modelBuilder.Entity<User>().HasData(
            //new User
            //{
            //    Id = userId,
            //});

            //modelBuilder.Entity<Account>().HasData(
            //new Account
            //{
            //    Id = Guid.NewGuid(),
            //    Password = Utilities.EncryptKey("123456aA@"),
            //    UserId = userId,
            //    UserName="admin"
            //});
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
