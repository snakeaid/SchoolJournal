namespace SchoolJournal.DataAccess.Abstractions;

/// <summary>
/// Interface which describes a user.
/// </summary>
public interface IUser
{
    /// <summary>
    /// Gets and sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets and sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets and sets login of the user.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Gets and sets password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets and sets the date of birth of the user.
    /// </summary>
    public DateOnly Birthday { get; set; }

    //TODO: Add contact information
}