using ChessFight.Application.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ChessFight.Application.Queries.LoginUser
{
    public class LoginUserQuery : IRequest<AuthResponseDto>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
