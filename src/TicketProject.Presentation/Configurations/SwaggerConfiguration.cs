using System.Reflection;
using Microsoft.OpenApi.Models;

namespace TicketProject.Presentation.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Sistema para Controle de Ticket API",
                Version = "v1",
                Description = "API para gerenciar tickets de forma eficiente e organizada.",
                Contact = new OpenApiContact { Name = "Akio Serizawa" }
            });

            var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xml));
        });
        
        return services;
    }
    
    public static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}