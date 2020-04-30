using Lobster.Core.Domain;
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
