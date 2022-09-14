using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Create model class for entity <see cref="Teacher"/>.
/// </summary>
public class TeacherCreateModel
{
    /// <summary>
    /// Gets and sets the received first name of the teacher.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the received last name of the teacher.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the received date of birth of the teacher.
    /// </summary>
    public LocalDate Birthday { get; set; }

    /// <summary>
    /// Gets and sets the received unique identifier of the class of the teacher.
    /// </summary>
    public int ClassId { get; set; }
}