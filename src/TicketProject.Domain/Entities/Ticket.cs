using TicketProject.Domain.Abstractions;

namespace TicketProject.Domain.Entities;

public class Ticket() : AuditEntity
{
    #region Properties

    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public DateTime ResponseDate { get; private set; }

    #endregion Properties

    #region Constructors

    public Ticket(
        string title,
        string description,
        DateTime responseDate) : this()
    {
        Title = title;
        Description = description;
        ResponseDate = responseDate;
    }

    #endregion Constructors
}