using Microsoft.EntityFrameworkCore;
using SlaSystem.Infrastructure.Persistence;

namespace SlaSystem.Presentation.Api.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
       
        services
            .AddSwaggerGen()
            .AddApplication()
            .AddInfrastructure(configuration)
            .AddPresentation()
            .AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });

        return services;
    }
}