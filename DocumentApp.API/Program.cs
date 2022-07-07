using DocumentApp.API.Infrastructure.Extensions;
using DocumentApp.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

//configure custom services
builder.Services.RegisterCustomServices();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
