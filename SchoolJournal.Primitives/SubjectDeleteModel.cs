using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Delete model class for entity <see cref="Subject"/>.
/// </summary>
public class SubjectDeleteModel
{
    /// <summary>
    /// Gets and sets the received identifier of the subject.
    /// </summary>
    public int Id { get; set; }
}