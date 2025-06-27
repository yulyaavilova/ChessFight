using ChessFight.Application.Dtos;
using ChessFight.Domain.Entities;

namespace ChessFight.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateRefreshTokenAsync(int userId);
        Task<AuthResponse> CreateTokensAsync(User user);
        Task<AuthResponse> UpdateTokensAsync(string refreshToken);
        Task RevokeTokenAsync(int userId);
    }
}
