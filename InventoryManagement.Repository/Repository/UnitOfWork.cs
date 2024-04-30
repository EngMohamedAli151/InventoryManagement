using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Repository
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly InventoryDbContext _context;
        public UnitOfWork(InventoryDbContext context)
        {
            _context=context;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<bool> CompleteAsync()
        {
            var Result =  _context.SaveChangesAsync().Result;
            return Result >0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
