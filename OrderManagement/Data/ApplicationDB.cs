using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OrderManagement.Models;
using System.Reflection.Metadata;

namespace OrderManagement.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options) 
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany<OrderItem>()
                .WithOne()
                .HasForeignKey(e => e.OrderId)
                .IsRequired();
        }
    }
}
