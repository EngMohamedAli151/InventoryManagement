using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerFk { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int TotalAmount { get; set; }
        public string Status { get; set; }

    }
}
