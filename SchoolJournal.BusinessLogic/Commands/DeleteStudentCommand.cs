using MediatR;
using SchoolJournal.Primitives;

namespace SchoolJournal.BusinessLogic.Commands;

/// <summary>
/// MediatR request class which represents a command to delete a student and
/// implements <see cref="IRequest{TResponse}"/> for <see cref="StudentViewModel"/>.
/// </summary>
public class DeleteStudentCommand : IRequest<StudentViewModel>
{
    /// <summary>
    /// Gets and sets the model of the student to be deleted.
    /// </summary>
    public StudentDeleteModel Model { get; set; } = null!;
}