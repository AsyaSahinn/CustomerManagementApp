using CustomerManagement.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; } // Admin nesnelerini temsil eder
        public DbSet<Customer> Customer { get; set; } // Customer nesnelerini temsil eder


        // Bu metot, veritabanı modelinin oluşturulma şeklini özelleştirmek için kullanılır.
        // Veritabanı tablolarının yapılandırması bu metot içinde yapılabilir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(); // Admin tablosunu oluşturur
            modelBuilder.Entity<Customer>(); // Customer tablosunu oluşturur
       
        }
    }
}
