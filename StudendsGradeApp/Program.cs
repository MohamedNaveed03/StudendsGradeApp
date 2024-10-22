using Microsoft.EntityFrameworkCore;
using StudendsGradeApp.Data;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Set the database path based on the environment
string dbPath;
if (builder.Environment.IsDevelopment())
{
    // Local development path
    dbPath = Path.Combine("StudentDB.db"); // Relative to the current directory
}
else
{
    // Azure or production path
    dbPath = Path.Combine(Environment.CurrentDirectory, "StudentDB.db");
}

// Update the connection string to use the correct database path
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration["ConnectionStrings:localDb"] = $"Data Source={dbPath}";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localDb")));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
