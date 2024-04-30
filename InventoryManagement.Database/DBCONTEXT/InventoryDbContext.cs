using InventoryManagement.Database.Configration;
using InventoryManagement.Database.Model;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace InventoryManagement.Database.DBCONTEXT
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext>options): base(options)
        {
            
        }
        /// <summary>
        /// this 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ItemConfigrations ());
            modelBuilder.ApplyConfiguration(new OrderConfigrations());

        }
        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Item> Items { get; set; } 
        public DbSet<Location> Locations { get; set; } 
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderItem> OrderItems { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<User> Users { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Transportation> Transportations { get; set; } 
        
    }
}
