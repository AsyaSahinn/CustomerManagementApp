using CustomerManagement.DAL.Abstract;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CustomerManagement.BackgroundJob.Concrete
{
    public class BackGroundJob : IBackgroundJob
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDatabase _redis;

        public BackGroundJob(ICustomerRepository customerRepository, IConnectionMultiplexer redis)
        {
            _customerRepository = customerRepository;
            _redis = redis.GetDatabase();
        }

        public async  Task UserCache()
        {
           var result= await _customerRepository.GetAll();
            await _redis.StringSetAsync("user", JsonConvert.SerializeObject(result));
        }
    }
}
