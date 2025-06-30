using Microsoft.AspNetCore.Identity;

namespace ChessFight.Api
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            string[] roleNames = { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }
        }
    }
}
