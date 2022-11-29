using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using VietTour.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<VietTour.Data.ViettourContext>(options =>
		options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<MainRepository>();

var app = builder.Build();

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

app.MapAreaControllerRoute(
            name: "areas",
            areaName: "admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
            name: "areas",
            areaName: "public",
            pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
