using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.Abstract
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
