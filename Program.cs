var builder = WebApplication.CreateBuilder(args);

// Includes views
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllerRoute(
    "default", 
    "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
