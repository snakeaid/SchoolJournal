using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="Student"/>.
/// </summary>
public class StudentViewModel
{
    /// <summary>
    /// Gets and sets the displayed identifier of the student.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the displayed full name of the student.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed date of birth of the student.
    /// </summary>
    public LocalDate Birthday { get; set; }
}