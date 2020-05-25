using Lobster.Core.Data;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

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
            var tempUser = _userRepository.Table.Include(e => e.Follows).SingleOrDefault(usr => usr.Id == userId);

            return new User()
            {
                Username = tempUser.Username,
                Karma = tempUser.Karma,
                Follows = tempUser.Follows,
                Id = tempUser.Id
            };
             
        }
    }
}
 