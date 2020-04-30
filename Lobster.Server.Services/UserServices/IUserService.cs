using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Server.Services.UserServices
{
    public interface IUserService
    {
        User GetPublicUserData(int userId);
    }
}
