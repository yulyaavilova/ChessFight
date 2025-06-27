﻿using System.ComponentModel.DataAnnotations;

namespace ChessFight.Application.Dtos
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9а-яА-ЯёЁ]+$")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
    }
}
