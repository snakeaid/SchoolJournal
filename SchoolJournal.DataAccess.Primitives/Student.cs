using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a student and implements <see cref="IUser"/>.
/// </summary>
public class Student : IUser
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
    /// Gets and sets the names of the student.
    /// </summary>
    public string[] Names { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the student.
    /// </summary>
    public LocalDate Birthday { get; set; }

    /// <summary>
    /// Gets and sets login of the student.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Gets and sets password of the person.
    /// </summary>
    public string Password { get; set; } = null!;
}