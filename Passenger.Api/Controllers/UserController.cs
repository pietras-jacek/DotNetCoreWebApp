using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Controller]
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<UserDto> GetAsync(string email) =>
            await _userService.GetAsync(email);

        [HttpPost("")]
        public async Task Post([FromBody] CreateUser request) =>
            await _userService.RegisterAsync(request.Email, request.UserName, request.Password);
    }
}