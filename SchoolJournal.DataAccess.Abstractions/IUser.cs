using NodaTime;

namespace SchoolJournal.DataAccess.Abstractions;

/// <summary>
/// Interface which describes a user.
/// </summary>
public interface IUser
{
    /// <summary>
    /// Gets and sets the names of the user.
    /// </summary>
    public string[] Names { get; set; }

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
    public LocalDate Birthday { get; set; }

    //TODO: Add contact information and passport/birth certificate (blob storage)
}