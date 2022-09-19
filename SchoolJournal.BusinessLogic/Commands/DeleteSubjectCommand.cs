using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to delete a subject and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectViewModel"/>.
/// </summary>
public class DeleteSubjectCommand : IRequest<SubjectViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject to be deleted.
    /// </summary>
    public SubjectDeleteModel Model { get; set; } = null!;
}