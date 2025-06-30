
using ChessFight.Api;
using ChessFight.Api.Extensions;
using ChessFight.Application.Queries.LoginUser;
using ChessFight.Application.Services.Interfaces;
using ChessFight.Domain.Entities;
using ChessFight.Infrastructure.Auth;
using ChessFight.Infrastructure.Data;
using Infrastructure.Background;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

string connection = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<ChessDataContext>(options =>
    {
        options.UseNpgsql(connection);
    }
);

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.Zero;
    options.Lockout.MaxFailedAccessAttempts = int.MaxValue;
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ChessDataContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddHostedService<TokenCleanupService>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(LoginUserQuery).Assembly)
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ChessDataContext>();

    if (app.Environment.IsDevelopment())
    {
        db.Database.EnsureCreated();
        db.Database.Migrate();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        await RoleInitializer.InitializeAsync(roleManager);
    }
    else
    {
        if (!db.Database.CanConnect())
            throw new Exception("Database not found");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
