using Microsoft.EntityFrameworkCore;
using EVO.Repository.Data;
using EVO.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    // Add 'EnvironmentDevelopmentPolicy' to handler CORS.
    builder.Services.AddCors(cors =>
    {
        cors.AddPolicy("EnvironmentDevelopmentPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });
}

// Add services to the container.
builder.Services.AddControllers();

// Get Application connection string.
var connectionString = SettingsManger.GetDatabaseConnectionString();

// Add Database context to application.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Use policy 'EnvironmentDevelopmentPolicy' to handle CORS.
    app.UseCors("EnvironmentDevelopmentPolicy");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
