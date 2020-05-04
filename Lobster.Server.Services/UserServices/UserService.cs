using Lobster.Core.Data;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Lobster.Server.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetPublicUserData(int userId)
        {
           return _userRepository.Table.SingleOrDefault(usr => usr.Id == userId);

        }
    }
}
 