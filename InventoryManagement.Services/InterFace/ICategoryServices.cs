using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.InterFace
{
    public interface ICategoryServices:IGenircServices<InventoryDbContext, ICategoryRepository, Category>
    {
    }
}
