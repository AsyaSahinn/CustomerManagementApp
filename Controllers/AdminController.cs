using CustomerManagement.DAL.Abstract;
using CustomerManagement.Models.DTO;
using CustomerManagement.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    // Admin işlemlerini yönetmek için kullanılan Controller sınıfı.

    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        // AdminController sınıfının constructor'ı. Dependency injection yoluyla IAdminRepository tipinde bir nesne alır.
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        // HTTP POST isteğiyle tetiklenen method.
        // Admin giriş işlemini gerçekleştirir.
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginModel loginModel)
        {
            var isAdmin = false;
            // loginModel, gelen parametreleri içeren bir nesnedir.
            if (loginModel != null)
            {
                // Admin bilgilerini almak için _adminRepository nesnesinin GetAdminInfoByUsernameAndPassword methodu çağrılır.
                // Kullanıcı adı ve şifre parametre olarak verilir. isAdmin, admin girişi başarılıysa true olur.
                isAdmin = await _adminRepository.GetAdminInfoByUsernameAndPassword(loginModel.UserName!, loginModel.UserPassword!);
            }

            if (isAdmin)
            {
                // Eğer isAdmin true ise, giriş başarılıdır ve CustomerController sınıfının GetCustomerList methoduna yönlendirilir.
                return RedirectToAction("GetCustomerList", "Customer");
            }
            else
            {
                // Eğer isAdmin false ise, giriş başarısızdır ve hata mesajıyla birlikte giriş sayfasına geri dönülür.
                ViewBag.ErrorMessage = "Yönetici girişi başarısız!";
                return View();
            }
        }

        // HTTP GET isteğiyle tetiklenen method.
        // Admin giriş sayfasını görüntüler.
        public IActionResult Login()
        {
            return View();
        }
    }
}
