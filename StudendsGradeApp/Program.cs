using Microsoft.EntityFrameworkCore;
using StudendsGradeApp.Data;
using StudentsGradeApp.Data; // Ensure this is the correct namespace
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Set the database path based on the environment
string dbPath;

if (builder.Environment.IsDevelopment())
{
    // Use a relative path for local development
    dbPath = Path.Combine("StudentDB.db"); // Relative to the current directory
}
else
{
    // Use a relative path for production (e.g., Azure)
    dbPath = Path.Combine(Environment.CurrentDirectory, "StudentDB.db");
}

// Update the connection string to use the correct database path
builder.Configuration["ConnectionStrings:localDb"] = $"Data Source={dbPath}";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localDb")));

var app = builder.Build();

// Automatically apply migrations at startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // This ensures migrations are applied
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
