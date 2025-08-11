using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.BLL;
using Microsoft.OpenApi.Models;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(c =>
    c.UseSqlServer("Data Source=DESKTOP-NO5EFOS;Initial Catalog=PersonManager;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPersonDal, PersonDal>();
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
