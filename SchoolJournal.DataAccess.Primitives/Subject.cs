using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a school subject.
/// </summary>
public class Subject : ISoftDeletable
{
    /// <summary>
    /// Gets and sets the unique identifier of the subject.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the name of the subject.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }
}