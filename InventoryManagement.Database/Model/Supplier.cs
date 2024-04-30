using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Database.Model
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        [MaxLength(100)]
        public string SupplierName { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }

        
    }
}
