using ChessFight.Application.Dtos;
using ChessFight.Application.Services.Interfaces;
using ChessFight.Domain.Entities;
using ChessFight.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChessFight.Infrastructure.Auth
{
    public class TokenService : ITokenService
    {
        private readonly ChessDataContext _context;
        private readonly IJwtProvider _jwtProvider;
        private readonly UserManager<User> _userManager;

        public TokenService(
            ChessDataContext context,
            IJwtProvider jwtProvider,
            UserManager<User> userManager)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _userManager = userManager;
        }

        public async Task<string> GenerateRefreshTokenAsync(int userId)
        {
            var token = Guid.NewGuid().ToString();
            var refreshToken = new RefreshToken
            {
                Token = token,
                UserId = userId,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return token;
        }

        public async Task<AuthResponse> CreateTokensAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtProvider.GenerateAccessToken(user, roles);
            var refreshToken = await GenerateRefreshTokenAsync(user.Id);

            return new()
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<AuthResponse> UpdateTokensAsync(string refreshToken)
        {
            var storedToken = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(x => x.Token == refreshToken && x.Expires > DateTime.UtcNow);

            if (storedToken == null)
                return new() { Success = false, Message = "Invalid token" };

            var user = storedToken.User;
            var roles = await _userManager.GetRolesAsync(user);
            var newAccessToken = _jwtProvider.GenerateAccessToken(user, roles);
            var newRefreshToken = await GenerateRefreshTokenAsync(user.Id);

            _context.RefreshTokens.Remove(storedToken);
            await _context.SaveChangesAsync();

            return new()
            {
                Success = true,
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task RevokeTokenAsync(int userId)
        {
            var tokens = await _context.RefreshTokens
                .Where(x => x.UserId == userId)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
        }
    }
}
