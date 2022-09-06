namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents lesson journal for a subject and class.
/// </summary>
public class SubjectJournal
{
    /// <summary>
    /// Gets and sets the unique identifier of the subject journal.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets and sets the subject of the journal.
    /// </summary>
    public Subject Subject { get; set; } = null!;

    /// <summary>
    /// Gets and sets the teacher for the subject.
    /// </summary>
    public Teacher Teacher { get; set; } = null!;

    /// <summary>
    /// Gets and sets the class for the subject.
    /// </summary>
    public Class Class { get; set; } = null!;

    /// <summary>
    /// Gets and sets the list of lessons for the journal.
    /// </summary>
    public List<Lesson> Lessons { get; set; } = null!;
}