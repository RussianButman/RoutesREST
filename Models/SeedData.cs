using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RoutesREST.Models
{
    public class SeedData
    {
        public static async Task CreateAdminAccount(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                UserManager<AppUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string username = "admin";
                string email = "admin@example.com";
                string password = "TheStr0ne$tP@ssw0rd";
                string role = "Admin";
                string fullname = "Фамилия Имя Отчество";
                string phoneNumber = "+79999999999";
                if (await userManager.FindByNameAsync(username) == null)
                {
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }

                    AppUser user = new AppUser
                    {
                        UserName = username,
                        Email = email,
                        FullName = fullname,
                        PhoneNumber = phoneNumber
                    };

                    IdentityResult result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
        public static void EnsureCreated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}
