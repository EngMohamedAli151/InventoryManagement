using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class TransportationDto
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }

    }
}
