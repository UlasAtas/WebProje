using Microsoft.EntityFrameworkCore;
using WebProje.Models;

var builder = WebApplication.CreateBuilder(args);
// Oturum hizmetini ekleyin
builder.Services.AddDistributedMemoryCache(); // Oturum için gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true; // Güvenlik
    options.Cookie.IsEssential = true; // GDPR uyumluluðu
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyAppContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
