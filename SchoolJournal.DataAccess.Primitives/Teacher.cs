using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a teacher.
/// </summary>
public class Teacher : IPerson
{
    /// <summary>
    /// Gets and sets the unique identifier of the teacher.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the list of classes of the teacher.
    /// </summary>
    public List<Class> Classes { get; set; } = null!;

    /// <summary>
    /// Gets and sets the specialization of the teacher.
    /// </summary>
    public List<Subject> Specialization { get; set; } = null!;

    /// <summary>
    /// Gets and sets the first name of the teacher.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the last name of the teacher.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the teacher.
    /// </summary>
    public DateOnly Birthday { get; set; }

    //TODO: Add schedule for the teacher
}