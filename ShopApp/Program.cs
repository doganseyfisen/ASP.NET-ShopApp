using Entities.Models;
using ShopApp.Infrastructure.Extensions;
using ShopApp.Infrastructure.Mapper;
using ShopApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<Cart>(cart => SessionCart.GetCart(cart));
builder.Services.ConfigureSession();
builder.Services.ConfigureStripe(builder.Configuration);
builder.Services.ConfigureApplicationCookie();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();

app.UseHttpsRedirection();

app.UseRouting();

// Order is important!!
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();

app.Run();
