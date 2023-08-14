using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.Concrete
{
    // Customer entity'sine özgü veri tabanı işlemlerini yöneten sınıf.
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private AppDbContext _context;

        // Constructor, AppDbContext tipinde bir nesne alır ve GenericRepository'nin constructor'ını çağırır.
        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
