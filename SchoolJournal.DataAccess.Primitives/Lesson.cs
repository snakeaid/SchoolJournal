using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a lesson.
/// </summary>
public class Lesson : ISoftDeletable
{
    /// <summary>
    /// Gets and sets the unique identifier of the lesson.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets and sets the journal for the lesson.
    /// </summary>
    public SubjectJournal SubjectJournal { get; set; } = null!;

    /// <summary>
    /// Gets and sets the unique identifier of the journal for the lesson.
    /// </summary>
    public Guid SubjectJournalId { get; set; }

    /// <summary>
    /// Gets and sets the list of marks for students on the lesson.
    /// </summary>
    public Dictionary<Student, Mark?> Marks { get; set; } = null!; //TODO: Add mark handling

    /// <summary>
    /// Gets and sets the beginning time of the lesson.
    /// </summary>
    public LocalDateTime BeginDateTime { get; set; }

    /// <summary>
    /// Gets and sets the ending time of the lesson.
    /// </summary>
    public LocalDateTime EndDateTime { get; set; }

    /// <summary>
    /// Gets and sets the home task of the lesson.
    /// </summary>
    public string? HomeTask { get; set; }

    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }
}