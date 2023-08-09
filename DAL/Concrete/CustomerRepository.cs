using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private AppDbContext _context;

        public CustomerRepository(AppDbContext context): base(context) 
        {
            _context = context;
        }
    }
}
