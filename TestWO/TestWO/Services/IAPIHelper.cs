using TestWO.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestWO.Services

{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string username, string password);
        Task GetLoggedInUserInfo(string token);
    }
}