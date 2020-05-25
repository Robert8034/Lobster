using System;
using System.Collections.Generic;
using System.Linq;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Core.Domain.Roles;
using Lobster.Core.Models;
using Lobster.Data;
using Lobster.Server.Services.EncryptionServices;
using Microsoft.EntityFrameworkCore;

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
        public User LoginUser(LoginModel loginModel)
        {
            var tempUser =  _userRepository.Table.Include(e => e.Follows).SingleOrDefault(a => a.Username == loginModel.Username);

            if (tempUser != null && _encryptionService.Decrypt(tempUser.Password, tempUser.EncryptionKey) == loginModel.Password) return tempUser;
           
            return null;
        }
        public User RegisterUser(RegisterModel registerModel)
        {
            if (_userRepository.Table.SingleOrDefault(a => a.Username == registerModel.Username) == null)
            {
                string encryptionKey = _encryptionService.GenerateEncryptionKey();

                User user = new User
                {
                    Username = registerModel.Username,
                    Password = _encryptionService.Encrypt(registerModel.Password, encryptionKey),
                    EncryptionKey = encryptionKey,
                    Email = registerModel.Email,
                    Role = new Role
                    {
                        Name = "User",
                        Permissions = Permissions.User
                    }
                };

                _userRepository.Insert(user);
                return user;
            }
            return null;
        }

        public Role GetRole(int userId)
        {
            User user = _userRepository.Table.SingleOrDefault(a => a.Id == userId);

            if (user != null) return user.Role;

            return null;
        }
    }
}
