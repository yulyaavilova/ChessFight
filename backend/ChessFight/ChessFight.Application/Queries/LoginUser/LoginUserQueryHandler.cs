
using ChessFight.Application.Dtos;
using ChessFight.Application.Services.Interfaces;
using MediatR;

namespace ChessFight.Application.Queries.LoginUser
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthResponseDto>
    {
        private readonly IAuthService _authService;

        public LoginUserQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request);
        }
    }
}
