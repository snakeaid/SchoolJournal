using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Update model class for entity <see cref="Subject"/>.
/// </summary>
public class SubjectUpdateModel
{
    /// <summary>
    /// Gets and sets the received identifier of the subject.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the received name of the subject.
    /// </summary>
    public string Name { get; set; } = null!;
}