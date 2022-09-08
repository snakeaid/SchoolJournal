using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Model class for entity <see cref="Teacher"/>.
/// </summary>
public class TeacherModel
{
    /// <summary>
    /// Gets and sets the displayed full name of the teacher.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed date of birth of the teacher.
    /// </summary>
    public DateOnly Birthday { get; set; }
}