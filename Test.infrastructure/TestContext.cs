using Test.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Test.infrastructure
{
    public class TestContext : DbContext
    {
        public TestContext()
        {
            // Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
        }
        public TestContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Customers> Customers { get; set; }

        public DbSet<SPCustomerListPaging> SPCustomerListPaging { get; set; }

        public DbSet<SPCustomerAccountsData> SPCustomerAccountsData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-G5LUVAO\SQLEXPRESS;Initial Catalog=BDOHomeWork;Persist Security Info=True;TrustServerCertificate=True;Integrated Security=SSPI;");
  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}