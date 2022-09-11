using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Create model class for entity <see cref="Student"/>.
/// </summary>
public class StudentCreateModel
{
    /// <summary>
    /// Gets and sets the received full name of the student.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the received date of birth of the student.
    /// </summary>
    public LocalDate Birthday { get; set; }
}