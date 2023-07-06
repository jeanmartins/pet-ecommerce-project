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

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( c=> {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pet.Commerce.API", Version = "v1" });

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

builder.Services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISalesProductRepository, SalesProductRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();


builder.Services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, CreateUserHandler>();
builder.Services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserResponse>, LoginUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetProfileCommand, GetProfileResponse>, GetProfileCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand, CreateUserResponse>, UpdateUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<InsertUserSaleCommand, bool>, InsertUserSaleCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserSaleCommand, bool>, DeleteUserSaleCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetUserSalesCommand, IEnumerable<GetUserSalesResponse>>, GetUserSalesCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllUsersSalesCommand, IEnumerable<GetUserSalesResponse>>, GetAllUsersSalesCommandHandler>();

builder.Services.AddScoped<IRequestHandler<CreateProductCommand, bool>, CreateProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetProductsCommand, IEnumerable<GetProductsResponse>>, GetProductsCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, UpdateProductCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, DeleteProductCommandHandler>();

builder.Services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CreateCategoryCommandHandler>();
builder.Services.AddScoped<IRequestHandler<GetCategoriasCommand, IEnumerable<GetCategoriasResponse>>, GetCategoriasCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, UpdateCategoryCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteCategoryCommand, bool>, DeleteCategoryCommandHandler>();


string connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<EcommerceContext>(opt => opt.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
