using NodaTime;
using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a group of students.
/// </summary>
public class Class : ISoftDeletable
{
    /// <summary>
    /// Gets and sets the unique identifier of the class.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the number of the class.
    /// </summary>
    public int Number { get; set; }

    /// <summary>
    /// Gets and sets the letter of the class.
    /// </summary>
    public string Letter { get; set; } = null!;

    /// <summary>
    /// Gets and sets the class teacher of the class.
    /// </summary>
    public Teacher ClassTeacher { get; set; } = null!;

    /// <summary>
    /// Gets and sets the unique identifier of class teacher of the class.
    /// </summary>
    public int ClassTeacherId { get; set; }

    /// <summary>
    /// Gets and sets the list of students in the class.
    /// </summary>
    public List<Student> Students { get; set; } = null!;

    /// <summary>
    /// Gets and sets the class journal.
    /// </summary>
    public List<SubjectJournal>? Journal { get; set; }

    /// <summary>
    /// Gets and sets the date and time of deletion.
    /// </summary>
    public LocalDateTime? DateTimeDeleted { get; set; }
}