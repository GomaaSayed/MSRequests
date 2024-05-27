
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MSRequests.API.Middlewares;
using MSRequests.Application;
using MSRequests.Domain.DTOs;
using MSRequests.Domain.IRepositories;
using MSRequests.Infrastructure.Contexts;
using MSRequests.Infrastructure.Repositries;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<MSRDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSRequests"),
        sqlServerOptionsAction: sqlServerOptions =>
        {
            sqlServerOptions.MigrationsAssembly("MSRequests.Infrastructure"); 
        });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Description = "",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        BearerFormat = "JWT"
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.Configure<JWTDTO>(builder.Configuration.GetSection("JWT"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MSRDBContext>();
builder.Services.AddApplicationDependencies();
builder.Services.AddScoped<IUserRepository, UserRepositroy>();
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepositroy>();
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
