using Microsoft.Extensions.DependencyInjection;

namespace SlaSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISlaRepository, SlaRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IQueueRepository, QueueRepository>();
        
        return services;
    }
}