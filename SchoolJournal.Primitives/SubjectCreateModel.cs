using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Create model class for entity <see cref="Subject"/>.
/// </summary>
public class SubjectCreateModel
{
    /// <summary>
    /// Gets and sets the received name of the subject.
    /// </summary>
    public string Name { get; set; } = null!;
}