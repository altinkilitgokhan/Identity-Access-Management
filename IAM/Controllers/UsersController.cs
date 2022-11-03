using AutoMapper;
using IAM.Api.Authorization;
using IAM.Api.Models;
using IAM.Application.Helpers;
using IAM.Application.Interfaces;
using IAM.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace IAM.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequestModel model)
        {
            var requestModel = _mapper.Map<AuthenticateRequestModel, AuthenticateApplicationRequestModel>(model);
            var response = _userService.Authenticate(requestModel);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequestModel model)
        {
            var requestModel = _mapper.Map<RegisterRequestModel, RegisterApplicationRequestModel>(model);
            _userService.Register(requestModel);
            return Ok(new { message = "Registration Successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequestModel model)
        {
            var requestModel = _mapper.Map<UpdateRequestModel, UpdateApplicationRequestModel>(model);
            _userService.Update(id, requestModel);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
