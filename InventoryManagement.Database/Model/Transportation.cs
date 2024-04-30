using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryManagement.Database.Model
{
    public class Transportation
    {
        public int TransportationID { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int ItemFk { get; set; }
        public int Quantity { get; set; }

    }
}
