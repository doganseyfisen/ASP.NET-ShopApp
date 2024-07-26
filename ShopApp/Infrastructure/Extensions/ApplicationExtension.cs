using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace ShopApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options
                    .AddSupportedCultures("tr-TR")
                    .AddSupportedUICultures("tr-TR")
                    .SetDefaultCulture("tr-TR");
            });
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+12345";

            // User Manager
            UserManager<IdentityUser> userManager = app
                .ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Role Manager
            RoleManager<IdentityRole> roleManager = app
                .ApplicationServices.CreateAsyncScope()
                .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "doganseyfisen@gmail",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);

                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }

                var roleResult = await userManager.AddToRolesAsync(
                    user,
                    roleManager.Roles.Select(role => role.Name).ToList()
                );

                if (!roleResult.Succeeded)
                {
                    throw new Exception("Something went wrong with role for admin.");
                }
            }
        }
    }
}
