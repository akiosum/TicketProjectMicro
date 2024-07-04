using MassTransit;

namespace TicketProject.Presentation.Configurations;

public static class MessageBrokerConfiguration
{
    public static IServiceCollection AddMessageBroker(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(mt => { mt.UsingRabbitMq((_, cfg) => { cfg.Host("localhost"); }); });

        return services;
    }
}