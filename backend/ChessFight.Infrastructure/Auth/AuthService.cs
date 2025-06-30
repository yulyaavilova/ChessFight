using ChessFight.Application.Commands.RegisterUser;
using ChessFight.Application.Dtos;
using ChessFight.Application.Queries.LoginUser;
using ChessFight.Application.Services.Interfaces;
using ChessFight.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ChessFight.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(
            UserManager<User> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<int?> RegisterUserAsync(RegisterUserCommand request, string role)
        {
            if (await _userManager.FindByEmailAsync(request.Email) != null
                || await _userManager.FindByNameAsync(request.UserName) != null)
                return null;

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return null;

            await _userManager.AddToRoleAsync(user, role);

            return user.Id;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginUserQuery request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return new() { Success = false, Message = "Invalid credentials" };

            var response = await _tokenService.CreateTokensAsync(user);
            response.Message = "Authenticated";

            return response;
        }
    }
}
