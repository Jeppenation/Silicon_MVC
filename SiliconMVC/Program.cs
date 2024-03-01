

using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FeatureItemRepository>();
builder.Services.AddScoped<FeatureRepository>();


builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<FeatureService>();


var app = builder.Build();



app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
