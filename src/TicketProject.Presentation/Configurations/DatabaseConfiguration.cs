using Microsoft.EntityFrameworkCore;
using TicketProject.Infrastructure.Data;
using TicketProject.Migration;

namespace TicketProject.Presentation.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TicketContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"), cfg =>
            {
                cfg.MigrationsAssembly("TicketProject.Migration");
            });
        });
        
        services.AddHostedService<MigrationsRunner<TicketContext>>();

        return services;
    }
}