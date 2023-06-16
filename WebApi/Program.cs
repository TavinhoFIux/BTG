using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Notifications;
using WebApi.Repository;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "corspolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("*").
                          AllowAnyHeader().
                          AllowAnyMethod();
                      });
});


builder.Services.AddMediatR(typeof(Program));

builder.Services.AddScoped<IErrorHandler, ErrorHandler>()
    .AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IRepositoryProduct, ProductRepository>();

builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ctx")));
var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
