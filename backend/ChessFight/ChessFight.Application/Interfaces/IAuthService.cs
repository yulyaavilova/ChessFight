﻿using ChessFight.Application.Dtos;

namespace ChessFight.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterModerator(RegisterRequest request);
        Task<AuthResponse> RegisterUser(RegisterRequest request);
        Task<AuthResponse> Login(LoginRequest request);
    }
}
