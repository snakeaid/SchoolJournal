using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// Update model class for entity <see cref="SubjectJournal"/>.
/// </summary>
public class SubjectJournalUpdateModel
{
    /// <summary>
    /// Gets and sets the received unique identifier of the subject journal.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets and sets the received unique identifier of the subject of the journal.
    /// </summary>
    public int SubjectId { get; set; }

    /// <summary>
    /// Gets and sets the received unique identifier of the teacher for the subject.
    /// </summary>
    public int TeacherId { get; set; }

    /// <summary>
    /// Gets and sets the received unique identifier of the class for the subject.
    /// </summary>
    public int ClassId { get; set; }
}