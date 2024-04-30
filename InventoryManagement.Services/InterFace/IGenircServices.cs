using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.InterFace
{
    public interface IGenircServices<Context,BaseRepo,Model>
    {/// <summary>
    /// Signture to Method of GenircServices
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    
        Model GetById(int id);
        public Task<Model> GetByIdAsync(int id);
        public Task<bool> AddAsync(Model entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> Update(Model entity);
        public Task<IEnumerable<Model>> GetAllAsync();

    }
}
