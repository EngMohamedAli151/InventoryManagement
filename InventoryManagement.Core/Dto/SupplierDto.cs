﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class SupplierDto
    {
        public string SupplierName { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
    }
}
