using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a student and implements <see cref="IUser"/>.
/// </summary>
public class Student : IUser, ISoftDeletable
{
    /// <summary>
    /// Gets and sets the unique identifier of the student.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the class of the student.
    /// </summary>
    public Class Class { get; set; } = null!;

    /// <summary>
    /// Gets and sets the unique identifier of the class of the student.
    /// </summary>
    public int ClassId { get; set; }

    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }

    /// <summary>
    /// Gets and sets the first name of the student.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the first name of the student.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the student.
    /// </summary>
    public LocalDate Birthday { get; set; }
}