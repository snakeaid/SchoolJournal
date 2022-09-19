using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to add a new subject and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="SubjectViewModel"/>.
/// </summary>
public class CreateSubjectCommand : IRequest<SubjectViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject to be added.
    /// </summary>
    public SubjectCreateModel Model { get; set; } = null!;
}