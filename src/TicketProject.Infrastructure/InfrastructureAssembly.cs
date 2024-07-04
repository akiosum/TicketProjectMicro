using System.Reflection;

namespace TicketProject.Infrastructure;

public class InfrastructureAssembly
{
    public static Assembly Assembly => typeof(InfrastructureAssembly).Assembly;
}