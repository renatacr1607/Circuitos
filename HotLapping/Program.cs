// Example LINQ query to fetch all "Volta" objects with a time less than 90 seconds
using Circuitos.Data;
using Circuitos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("CircuitosDbConnection");
builder.Services.AddDbContext<CircuitosContext>(options => options.UseSqlServer(connectionString));

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

app.MapControllerRoute(
    name: "circuito",
    pattern: "{controller=Circuito}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "carro",
    pattern: "{controller=Carro}/{action=Index}/{id?}");

// LINQ query to fetch "Volta" objects with a time less than 90 seconds
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<CircuitosContext>();

    var voltaQuery = dbContext.Voltas
        .Where(v => v.Tempo < 90)
        .ToList();

    foreach (var volta in voltaQuery)
    {
        Console.WriteLine($"Volta ID: {volta.VoltaID}, Tempo: {volta.Tempo}");
    }
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CircuitosContext>();
    CircuitoDbInitializer.Initialize(context);
}
app.Run();
