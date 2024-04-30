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
    public class CategoryServices : GenircServices<InventoryDbContext, ICategoryRepository, Category>, ICategoryServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryServices(IUnitOfWork<InventoryDbContext> unitOfWork, ICategoryRepository categoryRepository)
           : base(unitOfWork, categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;

        }
    }

}
