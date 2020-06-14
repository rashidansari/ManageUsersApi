using Microsoft.EntityFrameworkCore;

namespace ManageUsersApi.Models
{
    public class ManageUsersContext : DbContext
    {
        public ManageUsersContext(DbContextOptions<ManageUsersContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
            .HasIndex(u => u.EmailAdress)
            .IsUnique();
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Account> Accounts {get; set;}
    }
}