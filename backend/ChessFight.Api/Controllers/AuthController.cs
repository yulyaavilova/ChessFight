using ChessFight.Application.Commands.Logout;
using ChessFight.Application.Commands.RegisterUser;
using ChessFight.Application.Commands.UpdateToken;
using ChessFight.Application.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChessFight.Api.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand request)
        {
            var response = await _mediator.Send(request);

            if (response is null) return BadRequest();

            return CreatedAtAction("Login", new { id = response });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserQuery request)
        {
            var response = await _mediator.Send(request);

            if (!response.Success) return Unauthorized(response.Message);

            SetAuthCookies(response.AccessToken!, response.RefreshToken!);

            return Ok(response.Message);
        }

        [HttpGet("check-auth")]
        public IActionResult CheckAuth()
        {
            var accessToken = Request.Cookies["access-token"];
            var refreshToken = Request.Cookies["refresh-token"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                Response.Cookies.Delete("access-token");
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(accessToken))
                return Ok(new { isAuthenticated = false });

            return Ok(new { isAuthenticated = true });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refresh-token"];
            if (string.IsNullOrEmpty(refreshToken)) return Unauthorized();

            var response = await _mediator.Send(new UpdateTokenCommand(refreshToken));
            if (!response.Success) return Unauthorized(response.Message);

            SetAuthCookies(response.AccessToken!, response.RefreshToken!);
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("access-token");
            Response.Cookies.Delete("refresh-token");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return BadRequest("Not authorized");

            await _mediator.Send(new LogoutCommand(int.Parse(userId)));

            return NoContent();
        }

        private void SetAuthCookies(string accessToken, string refreshToken)
        {
            Response.Cookies.Append("access-token", accessToken, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddMinutes(15),
                Path = "/"
            });

            Response.Cookies.Append("refresh-token", refreshToken, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(7),
                Path = "/"
            });
        }
    }
}
