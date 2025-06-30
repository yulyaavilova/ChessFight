
using ChessFight.Application.Services.Interfaces;
using MediatR;

namespace ChessFight.Application.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
    {
        private readonly ITokenService _tokenService;

        public LogoutCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _tokenService.RevokeTokenAsync(request.UserId);
        }
    }
}
