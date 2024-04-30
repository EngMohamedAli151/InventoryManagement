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
    public class OrderConfigrations: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(s => s.CustomerFk);

           builder.HasMany<OrderItem>()
          .WithOne()
          .HasForeignKey(s => s.OrderFk);

        
        }
    }
}
