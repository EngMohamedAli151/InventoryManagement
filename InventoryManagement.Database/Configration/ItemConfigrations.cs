using InventoryManagement.Database.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Configration
{
    public class ItemConfigrations : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasOne<Supplier>()
            .WithMany()
            .HasForeignKey(s => s.SupplierFk);

            builder.HasOne<Category>()
            .WithMany()
            .HasForeignKey(s => s.CategoryFk);

            builder.HasMany<OrderItem>()
                    .WithOne()
                    .HasForeignKey(t => t.ItemFk);

         builder.HasMany<Transportation>()
         .WithOne()
         .HasForeignKey(s => s.ItemFk);

         builder.HasMany<Location>()
         .WithMany()
         .UsingEntity(i => i.ToTable("ItemLocation"));
            
        }
    }
}
