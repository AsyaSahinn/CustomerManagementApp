using CustomerManagement.Models.Entity;

namespace CustomerManagement.DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
       
            // Tiplerine göre farklı tipte nesneleri döndüren metotlar tanımlar.
            Task<IEnumerable<T>> GetAll(); // Tiplere özgü tüm nesneleri getirir.
            Task<T> GetById(int id); // Belirli bir nesneyi ID'ye göre getirir.

            // Yeni bir nesne oluşturmak, güncellemek ve silmek için metotlar tanımlar.
            Task Create(T obj); // Yeni bir nesneyi oluşturur.
            Task Update(T obj); // Bir nesneyi günceller.
            Task Delete(int id); // Belirli bir ID'ye sahip nesneyi siler.
        
    }
}
