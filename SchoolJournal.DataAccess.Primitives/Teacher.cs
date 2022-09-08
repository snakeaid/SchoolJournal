using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a teacher and implements <see cref="IUser"/>.
/// </summary>
public class Teacher : IUser
{
    /// <summary>
    /// Gets and sets the unique identifier of the teacher.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the first name of the teacher.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the last name of the teacher.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the teacher.
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Gets and sets login of the teacher.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Gets and sets password of the teacher.
    /// </summary>
    public string Password { get; set; } = null!;
}