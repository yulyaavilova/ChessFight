using ChessFight.Application.Commands.RegisterUser;
using ChessFight.Application.Dtos;
using ChessFight.Application.Queries.LoginUser;

namespace ChessFight.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int?> RegisterUserAsync(RegisterUserCommand request, string role);
        Task<AuthResponseDto> LoginAsync(LoginUserQuery request);
    }
}
