using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Update model class for entity <see cref="Class"/>.
/// </summary>
public class ClassUpdateModel
{
    /// <summary>
    /// Gets and sets the received identifier of the class.
    /// </summary>
    public int Id { get; set; }

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
    public List<StudentUpdateModel> Students { get; set; } = null!;
}