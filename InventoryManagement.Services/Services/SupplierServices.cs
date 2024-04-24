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
    public class SupplierServices:GenircServices<InventoryDbContext,ISupplierRepository,Supplier>,ISupplierServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly ISupplierRepository _supplierRepository;
        public SupplierServices(IUnitOfWork<InventoryDbContext> unitOfWork, ISupplierRepository supplierRepository)
            :base(unitOfWork,supplierRepository)
        {
            _unitOfWork=unitOfWork;
            _supplierRepository=supplierRepository;
        }

    }
}
