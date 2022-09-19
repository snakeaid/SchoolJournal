using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to delete a subject journal and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectJournalViewModel"/>.
/// </summary>
public class DeleteSubjectJournalCommand : IRequest<SubjectJournalViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject journal to be deleted.
    /// </summary>
    public SubjectJournalDeleteModel Model { get; set; } = null!;
}