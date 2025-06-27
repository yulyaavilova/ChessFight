using MediatR;

namespace ChessFight.Application.Commands.Logout
{
    public record LogoutCommand(int UserId) : IRequest;
}
