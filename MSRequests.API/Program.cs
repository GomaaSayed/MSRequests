
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MSRequests.Application;
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
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MSRDBContext>();
builder.Services.AddApplicationDependencies();
builder.Services.AddScoped<IUserRepository, UserRepositroy>();
builder.Services.AddScoped<IServiceRequestRepository, ServiceRequestRepositroy>();
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
