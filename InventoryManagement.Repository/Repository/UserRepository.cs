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
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
       
        public UserRepository(InventoryDbContext context) :base(context) 
        {
           
        }

        public User FindUserByEmail(string email)
        {
            if (_context.Users.Any(x => x.Email == email))
            {
                return _context.Users.First(x => x.Email == email);
            }
            return null;
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            if (_context.Users.Any(x => x.Email == email && x.Password == password))
            {
                return _context.Users.First(x => x.Email == email && x.Password == password);
            }
            return null;
        }
    }
    

}
