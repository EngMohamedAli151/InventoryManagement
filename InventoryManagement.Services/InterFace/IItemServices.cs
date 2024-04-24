using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.InterFace
{
    public interface IItemServices:IGenircServices<InventoryDbContext, ItemRepository, Item>
    {

        public Task<Item> Find(Expression<Func<Item, bool>> match, string[] includes = null);
        public Task<IEnumerable<Item>> FindAll(Expression<Func<Item, bool>> match, string[] includes = null);
    }
}
