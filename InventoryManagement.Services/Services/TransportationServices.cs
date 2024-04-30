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
    public class TransportationServices : GenircServices<InventoryDbContext, ITransportationRepository, Transportation>, ITransportationServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly ITransportationRepository _transportationRepository;
        public TransportationServices(IUnitOfWork<InventoryDbContext> unitOfWork, ITransportationRepository transportationRepository)
             : base(unitOfWork, transportationRepository)
        {
            _unitOfWork = unitOfWork;
            _transportationRepository = transportationRepository;

        }

    }
   
}
