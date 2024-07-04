using System.Reflection;

namespace TicketProject.Application;

public class ApplicationAssembly
{
    public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}