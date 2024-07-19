using GoatPlacesRedo.Server.Domain.Entities;
using GoatPlacesRedo.Server.Repository;
using GoatPlacesRedo.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GoatDbContext>(options =>
    options.UseSqlServer(
        Environment.GetEnvironmentVariable("GOATAPP_SECRET"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)
        ));

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryService<>));
builder.Services.AddScoped(typeof(IUserServices), typeof(UserServices));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");
app.Run();
