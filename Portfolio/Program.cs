using Application.Mappings;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Portfolio.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register the database context using SQL Server and the connection string from configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register custom application services (defined in an extension method)
builder.Services.RegisterServices(builder.Configuration);

// AutoMapper 
// Mapping configuration for converting between domain models and DTOs.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);


// Add controllers to the service container (for API endpoints)
builder.Services.AddControllers();

var app = builder.Build();

// Enable HTTPS redirection to enforce secure communication
app.UseHttpsRedirection();

// Enable authorization middleware (used with [Authorize] attributes)
app.UseAuthorization();

// Map attribute-routed controllers (i.e., APIs)
app.MapControllers();

// Start the application
app.Run();
