using RazorPizzeria.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using MySqlConnector;
using Microsoft.AspNetCore.Identity;
using RazorPizzeria.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options =>

    options.UseNpgsql(builder.Configuration["ConnectionStrings:cockroachlabsDBstring"])
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()

);

builder.Services.AddDefaultIdentity<RazorPizzeriaUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".RazorPizzeria.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


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

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
