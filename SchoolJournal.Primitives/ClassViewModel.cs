using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="Class"/>.
/// </summary>
public class ClassViewModel
{
    /// <summary>
    /// Gets and sets the displayed identifier of the class.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the displayed number and letter of the class.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets and sets the displayed letter of the class.
    /// </summary>
    public string Letter { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed class teacher of the class.
    /// </summary>
    public TeacherViewModel ClassTeacher { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed list of students in the class.
    /// </summary>
    public List<StudentViewModel> Students { get; set; } = null!;

    // /// <summary>
    // /// Gets and sets the displayed class journal.
    // /// </summary>
    // public List<SubjectJournalViewModel>? Journal { get; set; }
}