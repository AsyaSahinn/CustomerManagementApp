using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.Abstract
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<bool> GetAdminInfoByUsernameAndPassword(string username, string password);
    }
}
