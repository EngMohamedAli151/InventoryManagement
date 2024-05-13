using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Services
{
    public class OrderItemsServices:GenircServices<InventoryDbContext,IOrderItemsRepository,OrderItem>,IOrderItemServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly IOrderItemsRepository _orderItemsRepository;
        public OrderItemsServices(IUnitOfWork<InventoryDbContext> unitOfWork, IOrderItemsRepository orderItemsRepository)
            :base(unitOfWork, orderItemsRepository)
        {
            _unitOfWork=unitOfWork; 
            _orderItemsRepository=orderItemsRepository;
        }
    }
}
