using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to update a subject and
/// implements <see cref="IRequest"/> for <see cref="SubjectViewModel"/>.
/// </summary>
public class UpdateSubjectCommand : IRequest<SubjectViewModel>
{
    /// <summary>
    /// Gets and sets the model of the subject to be updated.
    /// </summary>
    public SubjectUpdateModel Model { get; set; } = null!;
}