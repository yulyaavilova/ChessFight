﻿namespace ChessFight.Infrastructure.Auth
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer {  get; set; } = string.Empty;
        public string Audience {  get; set; } = string.Empty;
        public int AccessTokenExpiryMinutes { get; set; }
    }
}
