using Microsoft.EntityFrameworkCore;    
using EVO.Repository.Data;
using EVO.Common.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Get Application connection string.
var connectionString = SettingsManger.GetDatabaseConnectionString();

// Add Database context to application.
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
