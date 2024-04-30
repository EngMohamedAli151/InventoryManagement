using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Services
{
    public class ItemServices:GenircServices<InventoryDbContext,IItemRepository,Item>,IItemServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly IItemRepository _itemRepository;

        public ItemServices(IUnitOfWork<InventoryDbContext> unitOfWork, IItemRepository itemRepository)
           : base(unitOfWork, itemRepository)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
            
        }
        /// <summary>
        /// to retrive Any entity Join 
        /// </summary>
        /// <param name="match"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual Task<Item> Find(Expression<Func<Item, bool>> match, string[] includes = null)
        {
            return _itemRepository.Find(match, includes);
        }

        public virtual Task<IEnumerable<Item>> FindAll(Expression<Func<Item, bool>> match, string[] includes = null)
        {
            return _itemRepository.FindAll(match, includes);
        }

    }
}
