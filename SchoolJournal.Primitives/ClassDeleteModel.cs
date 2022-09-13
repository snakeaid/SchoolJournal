using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Delete model class for entity <see cref="Class"/>.
/// </summary>
public class ClassDeleteModel
{
    /// <summary>
    /// Gets and sets the received identifier of the class.
    /// </summary>
    public int Id { get; set; }
}