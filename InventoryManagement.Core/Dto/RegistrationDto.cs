using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class RegistrationDto
    {
        [MaxLength(100)]
        public string userName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
