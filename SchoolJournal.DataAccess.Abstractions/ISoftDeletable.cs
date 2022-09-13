using NodaTime;

namespace SchoolJournal.DataAccess.Abstractions;

/// <summary>
/// This interface represents all entities which are soft-deletable.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }
}