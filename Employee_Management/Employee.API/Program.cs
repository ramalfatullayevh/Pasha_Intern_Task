using AutoMapper;
using Employee.Service.Extensions;
using Employee.Service.Helper;
using EmployeeManagement.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ServiceExtension(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfiles));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
