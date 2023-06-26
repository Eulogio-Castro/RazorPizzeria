using RazorPizzeria.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
string connectionStr = "Server=aws.connect.psdb.cloud;Database=razorpizzeriadb;user=ueg7ahbtdaecvzjiw0kw;password=pscale_pw_gQNdUv6EgT2BSfX3rs3BKjfMTmfa2BByfmrfiONlF4b;";

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options =>

    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()

);


builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
