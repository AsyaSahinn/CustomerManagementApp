using CustomerManagement.DAL.Abstract;
using CustomerManagement.DAL.GenericRepository;
using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DAL.Concrete
{
    // Admin entity'sine özgü veri tabanı işlemlerini yöneten sınıf.
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private AppDbContext _context;

        // Constructor, AppDbContext tipinde bir nesne alır ve GenericRepository'nin constructor'ını çağırır.
        public AdminRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        // Kullanıcı adı ve şifreye göre admin bilgilerini sorgular.
        // Eğer admin bulunursa true, bulunmazsa false döner.
        public async Task<bool> GetAdminInfoByUsernameAndPassword(string username, string password)
        {
            // Veri tabanında admin tablosunda kullanıcı adı ve şifre kontrolü yapılır.
            var admin = await _context.Set<Admin>().FirstOrDefaultAsync(x => x.UserName == username && x.UserPassword == password);
            if (admin == null)
            {
                return false; // Eğer admin bulunamazsa false döner.
            }
            return true; // Admin bulunursa true döner.
        }
    }
}
