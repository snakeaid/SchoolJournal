using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="Subject"/>.
/// </summary>
public class SubjectViewModel
{
    /// <summary>
    /// Gets and sets the displayed name of the subject.
    /// </summary>
    public string Name { get; set; } = null!;
}