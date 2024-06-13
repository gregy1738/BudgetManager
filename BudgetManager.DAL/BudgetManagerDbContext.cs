using System.Collections.Generic;
using System.Reflection.Emit;
using BudgetManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BudgetManager.DAL
{
    public class BudgetManagerDbContext : IdentityDbContext<User>
    {
        public BudgetManagerDbContext(DbContextOptions<BudgetManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ReportCategory> ReportCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Account relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany(a => a.Transactions)
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Category relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure PaymentMethod relationship
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.PaymentMethod)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);



            // Seed data for AccountTypes and Categories with positive IDs
            modelBuilder.Entity<AccountType>().HasData(
                new AccountType { AccountTypeId = 1, AccountName = "Checking" },
                new AccountType { AccountTypeId = 2, AccountName = "Savings" },
                new AccountType { AccountTypeId = 3, AccountName = "Investments" }
            );


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Food" },
                new Category { CategoryId = 2, CategoryName = "Rent" },
                new Category { CategoryId = 3, CategoryName = "Utilities" },
                new Category { CategoryId = 4, CategoryName = "Transportation" },
                new Category { CategoryId = 5, CategoryName = "Entertainment" },
                new Category { CategoryId = 6, CategoryName = "Clothing" },
                new Category { CategoryId = 7, CategoryName = "Health" },
                new Category { CategoryId = 8, CategoryName = "Insurance" },
                new Category { CategoryId = 9, CategoryName = "PersonalCare" },
                new Category { CategoryId = 10, CategoryName = "Miscellaneous" }
            );

            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { PaymentMethodId = 1, PaymentMethodName = "Cash" },
                new PaymentMethod { PaymentMethodId = 2, PaymentMethodName = "Credit Card" },
                new PaymentMethod { PaymentMethodId = 3, PaymentMethodName = "Debit Card" },
                new PaymentMethod { PaymentMethodId = 4, PaymentMethodName = "Check" },
                new PaymentMethod { PaymentMethodId = 5, PaymentMethodName = "Bank Transfer" },
                new PaymentMethod { PaymentMethodId = 6, PaymentMethodName = "Crypto" }
           );



        }

    }

}
