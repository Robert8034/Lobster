using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Data;

namespace Lobster.Server.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> LoginUser(LoginModel loginModel)
        {
            User tempUser = _userRepository.Table.SingleOrDefault(a => a.Username == loginModel.Username);

            if (tempUser != null || tempUser.Password == loginModel.Password) return tempUser;
            
            return null;
        }
        public async Task<User> RegisterUser(RegisterModel registerModel)
        {
            if (_userRepository.Table.SingleOrDefault(a => a.Username == registerModel.Username) == null)
            {
                User user = new User
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password,
                    Email = registerModel.Email
                };
                _userRepository.Insert(user);
                return user;
            }
            return null;
        }
    }
}
