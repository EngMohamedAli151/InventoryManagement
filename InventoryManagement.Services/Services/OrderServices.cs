using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Services
{
    public class OrderServices:GenircServices<InventoryDbContext, IOrderRepository, Order>, IOrderServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly IOrderRepository _orderRepository;
        public OrderServices(IUnitOfWork<InventoryDbContext> unitOfWork, IOrderRepository orderRepository)
             : base(unitOfWork, orderRepository)
        { 
             _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;

        }

    }

}
