using Lobster.Core.Models.Follows;
using Lobster.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.UserServices
{
    public interface IUserService
    {
        Task<List<User>> GetTimelineUsers(List<Follow> follows);
    }
}
