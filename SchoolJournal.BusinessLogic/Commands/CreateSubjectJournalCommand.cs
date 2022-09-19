using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to add a new subject journal and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class CreateSubjectJournalCommand : IRequest<SubjectJournalViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject journal to be added.
    /// </summary>
    public SubjectJournalCreateModel Model { get; set; } = null!;
}