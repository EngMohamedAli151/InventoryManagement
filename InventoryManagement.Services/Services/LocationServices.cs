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
    public class LocationServices : GenircServices<InventoryDbContext, ILocationRepository, Location>, ILocationServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly ILocationRepository _locationRepository;

        public LocationServices(IUnitOfWork<InventoryDbContext> unitOfWork, ILocationRepository locationRepository)
           : base(unitOfWork, locationRepository)
        {
            _unitOfWork = unitOfWork;
            _locationRepository = locationRepository;

        }
    }
}
