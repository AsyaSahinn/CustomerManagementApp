using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DAL.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private AppDbContext _context;

        public AdminRepository(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<bool> GetAdminInfoByUsernameAndPassword(string username, string password)
        {
            var admin= await _context.Set<Admin>().FirstOrDefaultAsync(x => x.UserName == username && x.UserPassword == password);
            if( admin == null )
            {
                return false;
            }
            return true;
        }
    }
}
