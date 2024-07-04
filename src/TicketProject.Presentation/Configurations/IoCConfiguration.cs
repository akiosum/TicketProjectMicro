using TicketProject.Domain;
using TicketProject.Domain.Contracts.Repositories;
using TicketProject.Infrastructure;

namespace TicketProject.Presentation.Configurations;

public static class IoCConfiguration
{
    public static IServiceCollection AddIoC(this IServiceCollection services)
    {
        AdicionarRepository(services);

        return services;
    }

    private static void AdicionarRepository(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(DomainAssembly.Assembly, InfrastructureAssembly.Assembly)
            .AddClasses(filter => filter.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}