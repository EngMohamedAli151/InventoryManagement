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
    public class OrderRepository:BaseRepository<Order>,IOrderRepository
    {
        public OrderRepository(InventoryDbContext context):base(context)
        {
            
        }
    }
}
