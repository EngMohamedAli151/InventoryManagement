using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class CustomerDto
    {
        [MaxLength(100)]
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
