using ChessFight.Application.Dtos;
using MediatR;

namespace ChessFight.Application.Commands.UpdateToken
{
    public record UpdateTokenCommand(string RefreshToken) : IRequest<AuthResponseDto>;
}
