using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class ItemDto
    {
        public string ItemName { get; set; }
        public long Price { get; set; }
        public int SupplierId { get; set; }
    }
}
