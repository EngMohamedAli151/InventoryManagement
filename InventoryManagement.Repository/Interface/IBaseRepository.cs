using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {/// <summary>
     /// Signture to Method of BaseRepository
     /// </summary>
     /// <param name="id"></param>
     /// <returns></returns>
        public T GetById(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<bool> AddAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> Update(T entity);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> Find(Expression<Func<T, bool>> match, string[] includes = null);
        public Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> match, string[] includes = null);
        
    }
}
