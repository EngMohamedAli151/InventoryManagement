﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Dto
{
    public class ItemDto
    {
        [MaxLength(100)]
        public string ItemName { get; set; }
        public long Price { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public int CategoryID { get; set; }

    }
}
