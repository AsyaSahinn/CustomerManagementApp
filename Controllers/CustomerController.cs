using CustomerManagement.BackgroundJob;
using CustomerManagement.DAL.Abstract;
using CustomerManagement.Models.DTO;
using CustomerManagement.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CustomerManagement.Controllers
{
    // Müşteri işlemlerini yönetmek için kullanılan Controller sınıfı.
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDatabase _redis;
        private readonly IBackgroundJob _job;

        public CustomerController(ICustomerRepository customerRepository, IConnectionMultiplexer redis, IBackgroundJob job)
        {
            _customerRepository = customerRepository;
            _redis = redis.GetDatabase();
            _job = job;
        }

        // Constructor, dependency injection ile ICustomerRepository ve IConnectionMultiplexer tipinde bir nesne alır.





        // HTTP GET isteğiyle tetiklenen method.
        // Tüm müşterileri listeler ve bu bilgileri CustomerResponseModel tipine dönüştürüp görüntüler.
        [HttpGet]
        public async Task<IActionResult> GetCustomerList()
        {
            var result = await _redis.StringGetAsync("user");
            var allCustomerData = JsonConvert.DeserializeObject<List<Customer>>(result);
            var customerDTOList =allCustomerData.Select(customer => new CustomerResponseModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }).ToList();

            return View(allCustomerData);
        }

        // HTTP POST isteğiyle tetiklenen method.
        // Yeni bir müşteri ekler.
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(CustomerRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Modelin geçerli olup olmadığı kontrol edilir.
                // Eğer geçerli ise, gelen veriler kullanılarak yeni bir Customer nesnesi oluşturulur.
                Customer customer = new()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Birthday = model.Birthday,
                    Address = model.Address,
                    Job = model.Job
                };

                // Oluşturulan müşteri verisi _customerRepository üzerinden eklenir.
                await _customerRepository.Create(customer);
                await _job.UserCache();
                // İşlem başarılı ise müşteri listesine yönlendirilir.
                return RedirectToAction("GetCustomerList", "Customer");
            }
            else
            {
                // Eğer model geçerli değilse, hata mesajıyla birlikte aynı sayfaya dönülür.
                ViewBag.ErrorMessage = "Model is not valid.";
                return View();
            }
        }

        // HTTP GET isteğiyle tetiklenen method.
        // Yeni müşteri eklemek için kullanılan sayfayı görüntüler.
        public IActionResult AddNewCustomer()
        {
            return View();
        }

        // HTTP GET isteğiyle tetiklenen method.
        // Belirli bir müşterinin detaylarını görüntüler.
        [HttpGet]
        public async Task<IActionResult> GetCustomerDetailByCustomerId(int customerId)
        {
            // Veri tabanından belirli bir müşteriye ait bilgiler alınır.
            CustomerRegisterModel registerModel = new();
            var result = await _customerRepository.GetById(customerId);
            if (result != null)
            {
                // Eğer müşteri varsa, bu bilgiler CustomerRegisterModel tipine dönüştürülür.
                registerModel = new()
                {
                    Name = result.Name,
                    Surname = result.Surname,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Birthday = result.Birthday ?? null,
                    Address = result.Address,
                    Job = result.Job
                };
            }

            // Dönüştürülen bilgiler müşteri detaylarını gösteren sayfada görüntülenir.
            return View(registerModel);
        }
    }
}
