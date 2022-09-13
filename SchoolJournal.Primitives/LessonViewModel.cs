using NodaTime;
using SchoolJournal.DataAccess.Primitives;

namespace SchoolJournal.Primitives;

/// <summary>
/// View model class for entity <see cref="Lesson"/>.
/// </summary>
public class LessonViewModel
{
    /// <summary>
    /// Gets and sets the displayed list of marks for students on the lesson.
    /// </summary>
    public Dictionary<StudentViewModel, Mark?> Marks { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed beginning time of the lesson.
    /// </summary>
    public LocalDateTime BeginDateTime { get; set; }

    /// <summary>
    /// Gets and sets the displayed ending time of the lesson.
    /// </summary>
    public LocalDateTime EndDateTime { get; set; }

    /// <summary>
    /// Gets and sets the displayed home task of the lesson.
    /// </summary>
    public string? HomeTask { get; set; }
}