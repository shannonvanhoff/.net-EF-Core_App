using Microsoft.EntityFrameworkCore;

using Webapi.Data.Migrations;
using Webapi.Services.Services.Customerservice;
using Webapi.Services.Services.Helperservice;
using Webapi.Services.Services.HTaskservice;
using AppContext = Webapi.Data.Migrations.AppContext;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IHTaskService, HTaskService>();
builder.Services.AddScoped<IHelperService, HelperService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
  //  endpoints.MapControllers();
//});

app.MapControllers();

app.Run();
