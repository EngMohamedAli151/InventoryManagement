using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class User
    {
        public int UserID { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }

    }
}

