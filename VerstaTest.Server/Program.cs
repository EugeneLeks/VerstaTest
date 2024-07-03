using Microsoft.EntityFrameworkCore;
using VerstaTest.Core.Abstractions;
using VerstaTest.DataAccess;
using VerstaTest.Application;
using VerstaTest.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VerstaTestDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(VerstaTestDbContext)));
    });

builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:5173");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});
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

app.UseCors();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
