using MediatR;
using Microsoft.EntityFrameworkCore;
using Pet.Commerce.Domain.Commands.Handlers;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.Models;
using System.Reflection;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Infra.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRequestHandler<GetProductsCommand, IEnumerable<GetProductsResponse>>, GetProductsHandler>();
string connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<EcommerceContext>(opt => opt.UseNpgsql(connectionString));

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
