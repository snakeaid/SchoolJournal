namespace SchoolJournal.DataAccess.Primitives;

/// <summary>
/// Entity class which represents a group of students.
/// </summary>
public class Class
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
    /// Gets and sets the specialization (main subjects) of the class.
    /// </summary>
    public List<Subject> Specialization { get; set; } = null!;

    //TODO: Add schedule for class

    /// <summary>
    /// Gets and sets the list of students in the class.
    /// </summary>
    public List<Student> Students { get; set; } = null!;

    /// <summary>
    /// Gets and sets the list of subjects with specified teachers for the class.
    /// </summary>
    public Dictionary<Subject, Teacher> Subjects { get; set; } = null!;

    /// <summary>
    /// Gets and sets the class teacher of the class.
    /// </summary>
    public Teacher ClassTeacher { get; set; } = null!;
}