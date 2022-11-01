using CHK.Commands;
using CHK.Common;
using CHK.Infrastructure;
using CHK.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cs = builder.Configuration.GetConnectionString("cs");
builder.Services.AddDbContext<WriteContext>(options =>
{
    options.UseSqlServer(cs);
});

builder.Services.AddTransient<DeviceRepository>();
builder.Services.AddTransient<InfoRepository>();
builder.Services.AddTransient<ICommandHandler<AddDeviceCommand>, AddDeviceCommandHandler>();
builder.Services.AddTransient<ICommandHandler<AddInfoCommand>, AddInfoCommandHandler>();
builder.Services.AddTransient<Sender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
