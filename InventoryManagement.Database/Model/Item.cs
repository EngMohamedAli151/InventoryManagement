using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public long Price { get; set; }
        public int SupplierId { get; set; }
        
    }
}
