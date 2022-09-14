using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Update model class for entity <see cref="Teacher"/>.
/// </summary>
public class TeacherUpdateModel
{
    /// <summary>
    /// Gets and sets the received identifier of the teacher.
    /// </summary>
    public int Id { get; set; }

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
}