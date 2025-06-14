using Fiap.Api.VerdeVolt.Models;

namespace Fiap.Api.VerdeVolt.Services
{
    public class AuthService : IAuthService
    {
        private List<UserModel> _users = new List<UserModel>
                {
                    new UserModel { UserId = 1, Username = "Izidoro", Password = "123", Role = "admin" },
                    new UserModel { UserId = 1, Username = "Marcos", Password = "123", Role = "user" },
                };
        public UserModel Authenticate(string username, string password)
        {
            // Aqui você normalmente faria a verificação de senha de forma segura
            return _users.FirstOrDefault(u => u.Username == username & u.Password == password);
        }
    }
}

