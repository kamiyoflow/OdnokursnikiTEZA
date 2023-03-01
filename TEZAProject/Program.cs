using Microsoft.EntityFrameworkCore;
using TEZAProject.API.Infrastructure.Extensions;
using TEZAProject.Bll.Interfaces;
using TEZAProject.Bll.Profiles;
using TEZAProject.Bll.Services;
using TEZAProject.Dal;
using TEZAProject.Dal.Interfaces;
using TEZAProject.Dal.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("TEZAProjectDBConnection");
builder.Services.AddDbContext<TEZAProjectDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddAutoMapper(typeof(UserProfileProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseDbTransaction();

app.UseHttpsRedirection();
app.UseExceptionHandling();

app.UseAuthorization();

app.MapControllers();

app.Run();
