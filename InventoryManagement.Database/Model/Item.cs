﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class Item
    {
        
        public int ItemId { get; set; }
        [MaxLength(100)]
        public string ItemName { get; set; }
        public long Price { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public int SupplierFk { get; set; }
        public int CategoryFk  { get; set; }

        
    }
}
