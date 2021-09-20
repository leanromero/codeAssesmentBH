using Microsoft.EntityFrameworkCore;
using BHBank.API.Domain.Models;


namespace BHBank.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.SurName).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().HasMany(p => p.Accounts).WithOne(p => p.Customer).HasForeignKey(p => p.CustomerId);

            builder.Entity<Customer>().HasData
            (
                new Customer { Id = 1000, Name = "Adam", SurName = "Smith" }, // Id set manually due to in-memory provider
                new Customer { Id = 1001, Name = "Bob", SurName = "Smith" },
                new Customer { Id = 1002, Name = "Carol", SurName = "Smith" },
                new Customer { Id = 1003, Name = "Diana", SurName = "Smith" }
            );

            builder.Entity<Account>().ToTable("Accounts");
            builder.Entity<Account>().HasKey(p => p.Id);
            builder.Entity<Account>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Account>().Property(p => p.Type).IsRequired().HasMaxLength(50);
            builder.Entity<Account>().HasMany(p => p.Transactions).WithOne(p => p.Account).HasForeignKey(p => p.AccountId);


            builder.Entity<Transaction>().ToTable("Transactions");
            builder.Entity<Transaction>().HasKey(p => p.Id);
            builder.Entity<Transaction>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Transaction>().Property(p => p.Value).IsRequired();
            
        }


    }
}
