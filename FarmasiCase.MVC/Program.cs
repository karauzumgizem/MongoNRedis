using FarmasiCase.Data.Concrete.EntityFramework.Repositories;
using FarmasiCase.Services.Abstract;
using FarmasiCase.Services.AutoMapper.Profiles;
using FarmasiCase.Services.Concrete;
using FarmasiCase.Services.Extensions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.LoadMyServices();
builder.Services.AddAutoMapper(typeof(ProductProfile));
IConfiguration configuration = builder.Configuration;
//var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
//builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = configuration.GetConnectionString("Redis");
});

//builder.Services.AddAutoMapper();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
