using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a teacher and implements <see cref="IUser"/>.
/// </summary>
public class Teacher : IUser, ISoftDeletable
{
    /// <summary>
    /// Gets and sets the unique identifier of the teacher.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }

    /// <summary>
    /// Gets and sets the first name of the teacher.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the first name of the teacher.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the teacher.
    /// </summary>
    public LocalDate Birthday { get; set; }
}