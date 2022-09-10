using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="SubjectJournal"/>.
/// </summary>
public class SubjectJournalViewModel
{
    /// <summary>
    /// Gets and sets the displayed subject of the journal.
    /// </summary>
    public SubjectViewModel Subject { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed teacher for the subject.
    /// </summary>
    public TeacherViewModel Teacher { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed list of lessons for the journal.
    /// </summary>
    public List<LessonViewModel> Lessons { get; set; } = null!;
}