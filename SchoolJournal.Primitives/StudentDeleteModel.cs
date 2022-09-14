using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Delete model class for entity <see cref="Student"/>.
/// </summary>
public class StudentDeleteModel
{
    /// <summary>
    /// Gets and sets the received identifier of the student.
    /// </summary>
    public int Id { get; set; }
}