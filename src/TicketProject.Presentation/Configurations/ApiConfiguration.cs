using Serilog;

namespace TicketProject.Presentation.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(conf => { conf.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();
        services.AddSwagger();
        services.AddLog(configuration);
        services.AddCors();
        services.AddDatabase(configuration);
        services.AddIoC();
        services.AddMediator();
        services.AddMessageBroker(configuration);

        return services;
    }

    private static void AddLog(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddLogging(options =>
        {
            options.ClearProviders();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            options.AddSerilog(logger);
        });
    }

    private static void AddCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("Productions",
            cors => cors
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
    }
}