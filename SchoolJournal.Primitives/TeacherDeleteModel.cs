using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Delete model class for entity <see cref="Teacher"/>.
/// </summary>
public class TeacherDeleteModel
{
    /// <summary>
    /// Gets and sets the received identifier of the teacher.
    /// </summary>
    public int Id { get; set; }
}