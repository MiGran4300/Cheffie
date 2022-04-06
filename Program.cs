using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cheffie.Data;
using Microsoft.AspNetCore.Identity;
using static Cheffie.Data.SeedData;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CheffieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CheffieContext")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CheffieContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();
SeedData(app);
void SeedData(IHost app)
{
    var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopeFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<DbInitializer>();
        service.Initialize();
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();



app.Run();
