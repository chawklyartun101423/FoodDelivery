using FoodDelivery;
using FoodDelivery.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("DbConnection").Value;

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<FoodService>();

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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Food}/{action=FoodListing}");

app.Run();
