using InventoryManagement.Database.DBCONTEXT;
using InventoryManagement.Database.Model;
using InventoryManagement.Repository.Interface;


namespace InventoryManagement.Services.InterFace
{
    public interface IUserServices:IGenircServices<InventoryDbContext, IUserRepository, User>
    {
        User FindUserByEmail(string email);
        User FindUserByEmailAndPassword(string email, string password);
    }
}
