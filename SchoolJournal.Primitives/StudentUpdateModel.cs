using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Update model class for entity <see cref="Student"/>.
/// </summary>
public class StudentUpdateModel
{
    /// <summary>
    /// Gets and sets the received identifier of the student.
    /// </summary>
    public int Id { get; set; }

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