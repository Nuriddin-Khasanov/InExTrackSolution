//   aspnetcore.Authentication
//   AspNetCore.Authorization

using InExTrack.Application.DTOs.Requests;
using InExTrack.Application.Interfaces.Services;
using InExTrack.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService _userService) : ApiBaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest_ request)
        {
            var token = await _userService.AuthenticateAsync(request.Username, request.Password);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser([FromForm] UserRequestsDto request, CancellationToken cancellationToken)
        {
            var success = await _userService.RegisterUserAsync(request, cancellationToken);

            return Ok(success);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync(CancellationToken cancellationToken)
        {
            var a = await _userService.GetUserById(GetUserId(), cancellationToken);

            return Ok(a);
        }

      //  [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UserRequestsDto userDto, CancellationToken cancellationToken)
        {
            return Ok(await _userService.UpdateUserById(GetUserId(), userDto, cancellationToken));
        }

      //  [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(CancellationToken cancellationToken)
        {
            return Ok(await _userService.DeleteUser(GetUserId(), cancellationToken));
        }
    }
}
