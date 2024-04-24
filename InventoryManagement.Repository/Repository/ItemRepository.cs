using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Repository
{
    public class ItemRepository:BaseRepository<Item>,IItemRepository
    {
        public ItemRepository(InventoryDbContext context) : base(context)
        {
            
        }
    }
}
