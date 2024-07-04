using System.Reflection;

namespace TicketProject.Domain;

public class DomainAssembly
{
    public static Assembly Assembly => typeof(DomainAssembly).Assembly;
}