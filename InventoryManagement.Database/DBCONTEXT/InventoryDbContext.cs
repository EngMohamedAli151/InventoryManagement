using InventoryManagement.Database.Model;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Item>()
            .HasOne<Supplier>()
            .WithMany()
            .HasForeignKey(s => s.SupplierId);

        }
        public DbSet<Supplier> Suppliers { get; set; } 
        public DbSet<Item> Items { get; set; } 
        
    }
}
