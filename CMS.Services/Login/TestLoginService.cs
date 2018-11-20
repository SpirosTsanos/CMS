using CMS.Services.Interfaces;
using System.Threading.Tasks;

namespace CMS.Services.Login
{
    public class TestLoginService : ILoginService
    {
        public Task<string> AuthenticateAsync()
        {
            return Task.FromResult("Instead of token");
        }
    }
}
