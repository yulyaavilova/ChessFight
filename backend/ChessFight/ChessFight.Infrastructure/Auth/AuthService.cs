using ChessFight.Application.Dtos;
using ChessFight.Application.Services.Interfaces;
using ChessFight.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Auth
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

        public async Task<AuthResponse> RegisterUser(RegisterRequest request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) != null
                || await _userManager.FindByNameAsync(request.UserName) != null)
                return new() { Success = false, Message = "User exists" };

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return new() { Success = false, Message = "Registration failed" };

            await _userManager.AddToRoleAsync(user, "User");

            var response = await _tokenService.CreateTokensAsync(user);
            response.Message = "Registered";

            return response;
        }

        public async Task<AuthResponse> RegisterModerator(RegisterRequest request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) != null
                || await _userManager.FindByNameAsync(request.UserName) != null)
                return new() { Success = false, Message = "User exists" };

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return new() { Success = false, Message = "Registration failed" };

            await _userManager.AddToRoleAsync(user, "Moderator");

            return new() { Success = true, Message = "Moderator successfully registered" };
        }

        public async Task<AuthResponse> Login(LoginRequest request)
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
