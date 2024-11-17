using Microsoft.Extensions.DependencyInjection;
using TechGizmos.TechGizmos.Application.Internal.Commands;
using TechGizmos.TechGizmos.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews(); 

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Register MediatR for handling commands
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateItemCommand).Assembly));

// Register MongoDBContext as Singleton
builder.Services.AddSingleton<MongoDBContext>();

// Register repositories
builder.Services.AddScoped<IItemRepository, ItemRepository>();

// Add Swagger for API documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "TechGizmos API", Version = "v1" });
});

// Configure logging (optional)
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

// Build the app
var app = builder.Build();

// Enable middleware for handling exceptions, HTTPS, etc.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Enable Swagger in Development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechGizmos API v1");
        c.RoutePrefix = "swagger";
    });
}

// Enable CORS
app.UseCors("AllowAll");

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable serving static files (like JS, CSS, etc.)
app.UseStaticFiles();

// Configure request routing
app.UseRouting();

// Enable authorization middleware
app.UseAuthorization();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Run the app
app.Run();
