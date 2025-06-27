using ChessFight.Domain.Entities;

namespace ChessFight.Application.Services.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateAccessToken(User user, IList<string> roles);
    }
}
