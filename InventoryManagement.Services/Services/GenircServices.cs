using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Services
{
    public class GenircServices<Context, BaseRepo, Model> : IGenircServices<Context, BaseRepo, Model>
        where Context : InventoryDbContext
        where BaseRepo : IBaseRepository<Model>
        where Model : class
        
    {
        private IUnitOfWork<Context> _unitOfWork;
        private BaseRepo _baseRepository;
       
      

        public GenircServices(IUnitOfWork<Context> unitOfWork, BaseRepo baseRepository) 
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// implementation retrive one id with sync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model GetById(int id)
        {
            return _baseRepository.GetById(id);
        }

        /// <summary>
        /// implementation delete one row by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            //_baseRepository.GetByIdAsync(id);
            
            if (id == null)
                Console.WriteLine($"Not Found The Id=> {id}");
            var delete=await _baseRepository.DeleteAsync(id);
            _unitOfWork.CompleteAsync();
            return delete;

          
        }

        /// <summary>
        /// implementation to retrive all rows in entity
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Model>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        /// <summary>
        /// implementation retrive one id with async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Task<Model> GetByIdAsync(int id)
        {
            if(id==null) 
                throw new ArgumentNullException(nameof(id));
           return _baseRepository.GetByIdAsync(id);
         
        }

        /// <summary>
        /// implementation Add  new one row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Task<bool> AddAsync(Model entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var response = _baseRepository.AddAsync(entity);
            var result = _unitOfWork.CompleteAsync();
            return response;

        }

        /// <summary>
        /// implementation update one row
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> Update(Model entity)
        {

            _baseRepository.Update(entity);
            _unitOfWork.CompleteAsync();
            return true;
        }

    }
}
