
using ChessFight.Application.Services.Interfaces;
using MediatR;

namespace ChessFight.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int?>
    {
        private readonly IAuthService _authService;

        public RegisterUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<int?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterUserAsync(request, "User");
        }
    }
}
