# ChessFight

### How run backend for VS Code

1. Download [dotnet sdk 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) (ASP.NET Core Runtime 9)
2. Download [postgresql](https://www.postgresql.org)
3. In backend/ChessFight/ChessFight.Api/appsettings.json set ConnectionStrings:DefaultConnection
4. Move to folder backend/ChessFight.Api:
`cd backend/ChessFight/ChessFight.Api`
5. Run project: `dotnet run`
6. Database and migrations will be created automatically
7. Swagger address: http://localhost:5210/swagger
