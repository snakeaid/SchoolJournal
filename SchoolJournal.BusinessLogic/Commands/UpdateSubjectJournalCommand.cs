using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to update a subject journal and
/// implements <see cref="IRequest"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class UpdateSubjectJournalCommand : IRequest<SubjectJournalViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject journal to be updated.
    /// </summary>
    public SubjectJournalUpdateModel Model { get; set; } = null!;
}