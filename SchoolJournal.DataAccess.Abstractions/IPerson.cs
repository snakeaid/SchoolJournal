namespace SchoolJournal.DataAccess.Abstractions;

/// <summary>
/// Interface which describes a person.
/// </summary>
public interface IPerson
{
    /// <summary>
    /// Gets and sets the first name of the person.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets and sets the last name of the person.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets and sets the date of birth of the person.
    /// </summary>
    public DateOnly Birthday { get; set; }

    //TODO: Add contact information
}