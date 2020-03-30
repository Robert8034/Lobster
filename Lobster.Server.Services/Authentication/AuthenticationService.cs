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
            _userRepository.Table.SingleOrDefault();
            
            return null;
        }
        public async Task<User> RegisterUser(RegisterModel registerModel)
        {
            return new User();
        }
    }
}
