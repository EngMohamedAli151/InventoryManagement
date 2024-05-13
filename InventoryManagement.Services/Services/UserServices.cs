using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Repository.Repository;
using InventoryManagement.Services.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services.Services
{
    public class UserServices:GenircServices<InventoryDbContext, IUserRepository, User>, IUserServices
    {
        private readonly IUnitOfWork<InventoryDbContext> _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserServices(IUnitOfWork<InventoryDbContext> unitOfWork, IUserRepository userRepository)
           : base(unitOfWork, userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;

        }

        public User FindUserByEmail(string email)
        {
           return _userRepository.FindUserByEmail(email);
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.FindUserByEmailAndPassword(email, password);
        }
    }
}
