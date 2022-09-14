using NodaTime;

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
    /// Gets and sets the first name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets and sets the date of birth of the user.
    /// </summary>
    public LocalDate Birthday { get; set; }

    //TODO: Add contact information and passport/birth certificate (blob storage)
}