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
    public class LocationRepository:BaseRepository<Location>,ILocationRepository
    {
        public LocationRepository(InventoryDbContext context):base(context) 
        {
            
        }
    }
}
