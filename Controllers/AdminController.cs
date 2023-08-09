using CustomerManagement.DAL.Abstract;
using CustomerManagement.Models.DTO;
using CustomerManagement.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Controllers
{
    //[Route("api/[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginModel loginModel)
        {
            var isAdmin = false;
            if (loginModel != null)
            {
                isAdmin = await _adminRepository.GetAdminInfoByUsernameAndPassword(loginModel.UserName!, loginModel.UserPassword!);
            }

            if (isAdmin)
            {
                // Eğer giriş başarılı ise userlist sayfasına yönlendir
                return RedirectToAction("GetCustomerList", "Customer");
            }
            else
            {
                // Giriş başarısız olursa hata mesajıyla beraber giriş sayfasına geri dön
                ViewBag.ErrorMessage = "Yönetici girişi başarısız!";
                return View();
            }
        }
        //[HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    }
}
