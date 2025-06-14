using Fiap.Api.VerdeVolt.Models;

namespace Fiap.Api.VerdeVolt.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}
