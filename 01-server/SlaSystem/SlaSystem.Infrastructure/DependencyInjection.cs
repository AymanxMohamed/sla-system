using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlaSystem.Infrastructure.Persistence;

namespace SlaSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISlaRepository, SlaRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IQueueRepository, QueueRepository>();
        
        return services;
    }
}