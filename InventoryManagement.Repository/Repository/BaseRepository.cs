using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        protected InventoryDbContext _context;
        protected readonly DbSet<T> _Dbset;
        public BaseRepository(InventoryDbContext context)
        {
            _context=context;
          this._Dbset  = _context.Set<T>();
        }
        /// <summary>
        /// implementation retrive one id with sync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(int id)
        {
            return _Dbset.Find(id);
        }

        /// <summary>
        /// implementation retrive one id with async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _Dbset.FindAsync(id);
        }

        /// <summary>
        /// implementation to retrive all rows in entity
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IQueryable<T>> GetAllAsync()
        {
            var list = await _Dbset.AsNoTracking().ToListAsync();
            return list.AsQueryable();
        }

        /// <summary>
        /// to retrive Any entity Join 
        /// </summary>
        /// <param name="match"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<T?> Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _Dbset;
            if (includes != null)
            {
                foreach (var items in includes)
                    query = query.Include(items);

            }
            return  query.SingleOrDefault(match);
        }

        /// <summary>
        /// to retrive Any entity Join 
        /// </summary>
        /// <param name="match"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _Dbset;
            if (includes != null)
            {
                foreach (var items in includes)
                    query = query.Include(items);

            }
            return query.Where(match).ToList();
        }

        /// <summary>
        /// implementation Add  new one row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> AddAsync(T entity)
        {
           await _Dbset.AddAsync(entity);
          //  _context.SaveChangesAsync();
            return true;
             
        }

        /// <summary>
        /// implementation update one row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> Update(T entity)
        {
            _Dbset.Update(entity);
            _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// implementation delete one row by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            _Dbset.Remove(model);
            _context.SaveChangesAsync();
            return true;

        }

        
    }
}

