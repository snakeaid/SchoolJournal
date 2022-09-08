namespace SchoolJournal.Primitives;

/// <summary>
/// Model class for entity 
/// </summary>
public class StudentModel
{
    /// <summary>
    /// Gets and sets the displayed class of the student.
    /// </summary>
    public ClassModel Class { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed full name of the student.
    /// </summary>
    public string FullName { get; set; } = null!;

    /// <summary>
    /// Gets and sets the displayed date of birth of the student.
    /// </summary>
    public DateOnly Birthday { get; set; }
}