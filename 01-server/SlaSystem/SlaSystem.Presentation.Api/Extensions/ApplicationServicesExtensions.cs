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
            .AddInfrastructure()
            .AddPresentation();

        return services;
    }
}