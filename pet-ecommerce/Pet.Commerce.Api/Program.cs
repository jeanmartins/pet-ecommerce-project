using MediatR;
using Microsoft.EntityFrameworkCore;
using Pet.Commerce.Domain.Commands.Handlers;
using Pet.Commerce.Domain.Commands.Responses;
using Pet.Commerce.Domain.Models;
using System.Reflection;
using Pet.Commerce.Domain.Commands.Handlers.Requests;
using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Infra.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Pet.Commerce.Domain.Services;
using System.Text;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c=> {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "apiagenda", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});
builder.Services.AddMvc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRequestHandler<GetProductsCommand, IEnumerable<GetProductsResponse>>, GetProductsHandler>();
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, CreateUserHandler>();
builder.Services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserResponse>, LoginUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand, CreateUserResponse>, UpdateUserCommandHandler>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
