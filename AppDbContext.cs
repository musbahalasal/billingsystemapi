using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace billingsystem2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Normalitem> NormalItems { get; set; }
        public DbSet<MedicalItem> MedicalItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { //GO BACK and add the info asapppp
            optionsBuilder.UseSqlServer("Server=.;Database=BillingDB2;Trusted_Connection=True;TrustServerCertificate=True;");

        }

    }
}
