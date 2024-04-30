using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class OrderDto
    {
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public int TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
