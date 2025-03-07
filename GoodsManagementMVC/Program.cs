using GoodsManagementMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<HangHoaService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration); // Đăng ký cấu hình

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HangHoa}/{action=Index}/{id?}"); // Mặc định mở HangHoa

app.Run();
