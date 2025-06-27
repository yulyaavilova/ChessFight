
using ChessFight.Application.Dtos;
using ChessFight.Application.Services.Interfaces;
using MediatR;

namespace ChessFight.Application.Commands.UpdateToken
{
    public class UpdateTokenCommandHandler : IRequestHandler<UpdateTokenCommand, AuthResponseDto>
    {
        private readonly ITokenService _tokenService;

        public UpdateTokenCommandHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> Handle(UpdateTokenCommand request, CancellationToken cancellationToken)
        {
            return await _tokenService.UpdateTokensAsync(request.RefreshToken);
        }
    }
}
