using ChessFight.Application.Dtos;
using ChessFight.Domain.Entities;

namespace ChessFight.Application.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateRefreshTokenAsync(int userId);
        Task<AuthResponseDto> CreateTokensAsync(User user);
        Task<AuthResponseDto> UpdateTokensAsync(string refreshToken);
        Task RevokeTokenAsync(int userId);
    }
}
