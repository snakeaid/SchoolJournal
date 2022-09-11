using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Create model class for entity <see cref="Class"/>.
/// </summary>
public class ClassCreateModel
{
    /// <summary>
    /// Gets and sets the received number of the class.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets and sets the received identifier of the class teacher of the class.
    /// </summary>
    public int ClassTeacherId { get; set; }

    /// <summary>
    /// Gets and sets the received list of students in the class.
    /// </summary>
    public List<StudentCreateModel> Students { get; set; } = null!;
}