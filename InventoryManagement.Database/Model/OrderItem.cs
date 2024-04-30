using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderFk { get; set; }
        public int ItemFk { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }

    }
}
