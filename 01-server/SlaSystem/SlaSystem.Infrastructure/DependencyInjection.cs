using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlaSystem.Infrastructure.Persistence;
using SlaSystem.Infrastructure.Persistence.TempRepositories;

namespace SlaSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        // services.AddDbContext<ApplicationDbContext>(options =>
        // {
        //     options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        //     // options.UseSqlServer(configuration.GetConnectionString("SqlServerDatabase"));
        // });
        services.AddScoped<IUserRepository, TempUserRepository>();
        services.AddScoped<IUnitOfWork, TempUnitOfWork>();
        services.AddScoped<ISlaRepository, TempSlaRepository>();
        services.AddScoped<IRequestRepository, TempRequestRepository>();
        services.AddScoped<IQueueRepository, TempQueueRepository>();
        
        return services;
    }
}