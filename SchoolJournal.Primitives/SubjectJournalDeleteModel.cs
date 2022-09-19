using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Delete model class for entity <see cref="SubjectJournal"/>.
/// </summary>
public class SubjectJournalDeleteModel
{
    /// <summary>
    /// Gets and sets the received identifier of the subject journal.
    /// </summary>
    public int Id { get; set; }
}