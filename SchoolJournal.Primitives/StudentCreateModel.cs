using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Create model class for entity <see cref="Student"/>.
/// </summary>
public class StudentCreateModel
{
    /// <summary>
    /// Gets and sets the received first name of the student.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the received last name of the student.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the received date of birth of the student.
    /// </summary>
    public LocalDate Birthday { get; set; }

    /// <summary>
    /// Gets and sets the received unique identifier of the class of the student.
    /// </summary>
    public int ClassId { get; set; }
}