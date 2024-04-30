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
    public class CustomerServices : GenircServices<InventoryDbContext, ICustomerRepository, Customer>, ICustomerServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(IUnitOfWork<InventoryDbContext> unitOfWork, ICustomerRepository customerRepository)
           : base(unitOfWork, customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;

        }

    }
}
