using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private AppDbContext _context;

        public AdminRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
