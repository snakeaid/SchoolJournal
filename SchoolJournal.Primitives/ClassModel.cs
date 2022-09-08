using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Model class for entity <see cref="Class"/>.
/// </summary>
public class ClassModel
{
    /// <summary>
    /// Gets and sets the displayed number of the class.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets and sets the displayed class teacher of the class.
    /// </summary>
    public Teacher ClassTeacher { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed list of students in the class.
    /// </summary>
    public List<StudentModel> Students { get; set; } = null!;
}