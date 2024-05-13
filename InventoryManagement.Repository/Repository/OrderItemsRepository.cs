using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;


namespace InventoryManagement.Repository.Repository
{
    public class OrderItemsRepository:BaseRepository<OrderItem>, IOrderItemsRepository
    {
        public OrderItemsRepository(InventoryDbContext context):base(context) 
        {
            
        }
    }
}
