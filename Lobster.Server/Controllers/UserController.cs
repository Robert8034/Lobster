
using System.Net;
using AutoMapper;
using Lobster.Core.Data;
using Lobster.Core.Models;
using Lobster.Core.Models.Users;
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
        private readonly IMapper _mapper;

        public UserController(IAuthenticationService authenticationService, IUserService userService, IMapper mapper)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public RestResponse PostLoginModel(LoginModel model)
        {
            var user = _authenticationService.LoginUser(model);

            User usermodel = _mapper.Map<User>(user);

            return new RestResponse(HttpStatusCode.OK, usermodel);
        }

        [HttpPost]
        [Route("register")]
        public RestResponse PostRegisterModel(RegisterModel model)
        {
            var user = _authenticationService.RegisterUser(model);
            return new RestResponse(HttpStatusCode.OK, _mapper.Map<User>(user));
        }

        [HttpGet]
        [Route("{userId}/public")]
        public RestResponse GetPublicUserData(int userId)
        {
            var user = _userService.GetPublicUserData(userId);

            var userModel = _mapper.Map<Core.Models.Users.User>(user);

            if (user != null) return new RestResponse(HttpStatusCode.OK, _mapper.Map<User>(user));

            return new RestResponse(HttpStatusCode.NotFound);
        }

      
    }
}