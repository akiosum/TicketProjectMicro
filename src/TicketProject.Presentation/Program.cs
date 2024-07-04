using TicketProject.Presentation.Configurations;
using TicketProject.Presentation.Handlers;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfiguration(builder.Configuration)
    .AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler(o => { });
app.UseHttpsRedirection();
app.UseCors("Productions");
app.UseSwaggerDocumentation();
app.MapControllers();
app.Run();