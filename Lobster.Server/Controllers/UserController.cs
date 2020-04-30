using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lobster.Core.Data;
using Lobster.Core.Domain;
using Lobster.Server.Services.Authentication;
using Lobster.Server.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace Lobster.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        public UserController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public RestResponse PostLoginModel(LoginModel model)
        {
            return new RestResponse(HttpStatusCode.OK, _authenticationService.LoginUser(model));
        }

        [HttpPost]
        [Route("register")]
        public RestResponse PostRegisterModel(RegisterModel model)
        {
            return new RestResponse(HttpStatusCode.OK, _authenticationService.RegisterUser(model));
        }

        [HttpGet]
        [Route("{userId}/public")]
        public RestResponse GetPublicUserData(int userId)
        {
            User user = _userService.GetPublicUserData(userId);

            if (user != null) return new RestResponse(HttpStatusCode.OK, user);

            return new RestResponse(HttpStatusCode.NotFound);
        }
    }
}