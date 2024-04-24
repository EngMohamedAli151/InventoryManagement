using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Repository.Interface
{
    public interface IUnitOfWork<T>:IDisposable
    {
        /// <summary>
        /// to save data
        /// </summary>
        /// <returns></returns>
        public int Complete();
        public Task<bool> CompleteAsync();
    }
}
