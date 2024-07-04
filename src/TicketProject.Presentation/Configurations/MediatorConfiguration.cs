using TicketProject.Application;

namespace TicketProject.Presentation.Configurations;

public static class MediatorConfiguration
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(ApplicationAssembly.Assembly);
        });
        
        // services.AddScoped(typeof(IPipelineBehavior<,>),
        //     typeof(ValidationPipelineBehavior<,>));
        // services.AddValidatorsFromAssembly(ApplicationAssembly.Assembly);

        return services;
    }
}