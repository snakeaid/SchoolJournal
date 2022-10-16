using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="Teacher"/>.
/// </summary>
public class TeacherViewModel
{
    /// <summary>
    /// Gets and sets the displayed identifier of the teacher.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the displayed full name of the teacher.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed date of birth of the teacher.
    /// </summary>
    public LocalDate Birthday { get; set; }

    /// <summary>
    /// Gets and sets the displayed list of classes of the teacher.
    /// </summary>
    public List<ClassViewModel>? Classes { get; set; }
}