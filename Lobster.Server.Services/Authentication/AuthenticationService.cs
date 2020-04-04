using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Data;
using Lobster.Server.Services.Encryption;

namespace Lobster.Server.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IEncryptionService _encryptionService;
        public AuthenticationService(IRepository<User> userRepository, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _encryptionService = encryptionService;
        }
        public async Task<User> LoginUser(LoginModel loginModel)
        {
            
            User tempUser = _userRepository.Table.SingleOrDefault(a => a.Username == loginModel.Username);

            if (tempUser != null && _encryptionService.Decrypt(tempUser.Password, tempUser.EncryptionKey) == loginModel.Password) return tempUser;
            
            return null;
        }
        public async Task<User> RegisterUser(RegisterModel registerModel)
        {
            if (_userRepository.Table.SingleOrDefault(a => a.Username == registerModel.Username) == null)
            {
                string encryptionKey = _encryptionService.GenerateEncryptionKey();

                User user = new User
                {
                    Username = registerModel.Username,
                    Password = _encryptionService.Encrypt(registerModel.Password, encryptionKey),
                    EncryptionKey = encryptionKey,
                    Email = registerModel.Email
                };
                _userRepository.Insert(user);
                return user;
            }
            return null;
        }
    }
}
