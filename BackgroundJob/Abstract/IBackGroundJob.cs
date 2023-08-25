using System.Threading.Tasks;

namespace CustomerManagement.BackgroundJob
{
    public interface IBackgroundJob
    {
		Task UserCache();


	}
}
