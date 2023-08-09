using CustomerManagement.DBContext;
using CustomerManagement.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DAL.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private AppDbContext _context; // Veritabanı bağlamını temsil eden AppDbContext nesnesi

        // Yapıcı metot, AppDbContext nesnesini enjekte eder.
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        // Belirli bir ID'ye sahip nesneyi silen metot
        public async Task Delete(int id)
        {
            var entity = await GetById(id); // Veritabanından nesneyi alır
            _context.Set<T>().Remove(entity); // Nesneyi veritabanından siler
            await _context.SaveChangesAsync(); // Değişiklikleri kaydeder
        }

        // Tiplere göre tüm nesneleri getiren metot
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        // Belirli bir ID'ye sahip nesneyi getiren metot
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        // Yeni bir nesneyi oluşturan metot
        public async Task Create(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        // Bir nesneyi güncelleyen metot
        public async Task Update(T obj)
        {
            _context.Set<T>().Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
