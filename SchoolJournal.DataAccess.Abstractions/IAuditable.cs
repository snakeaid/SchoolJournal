using NodaTime;

namespace SchoolJournal.DataAccess.Abstractions;

/// <summary>
/// This interface represents all entities which are auditable for addition/modification.
/// </summary>
public class IAuditable : ISoftDeletable
{
    public LocalDateTime? DateTimeDeleted { get; set; }
}