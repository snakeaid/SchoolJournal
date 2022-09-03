using SchoolJournal.DataAccess.Abstractions;

namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a student.
/// </summary>
public class Student : IPerson
{
    /// <summary>
    /// Gets and sets the unique identifier of the student.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets and sets the class of the student.
    /// </summary>
    public Class Class { get; set; } = null!;

    /// <summary>
    /// Gets and sets the first name of the student.
    /// </summary>
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the last name of the student.
    /// </summary>
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the date of birth of the student.
    /// </summary>
    public DateOnly Birthday { get; set; }

    //TODO: Add info for student
}